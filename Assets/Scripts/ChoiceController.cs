using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChoiceController : MonoBehaviour
{
    private Choice choiceLeft;
    private Choice choiceRight;
    private Choice choiceUp;
    private Choice choiceDown;
    private List<string> typeList = new List<string>{"Social","Family","Love","Career"};
    private Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        choiceLeft = GameObject.Find("Choices").transform.Find("Left").gameObject.GetComponent<Choice>();
        choiceRight = GameObject.Find("Choices").transform.Find("Right").gameObject.GetComponent<Choice>();
        choiceUp = GameObject.Find("Choices").transform.Find("Up").gameObject.GetComponent<Choice>();
        choiceDown = GameObject.Find("Choices").transform.Find("Down").gameObject.GetComponent<Choice>();

        // Self choice
        choiceDown.mentalMod = 5;

        stats = GameObject.Find("Stats").GetComponent<Stats>();
        
        UpdateChoices();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            stats.Mental += choiceLeft.mentalMod;
            stats.Social += choiceLeft.socialMod;
            stats.Family += choiceLeft.familyMod;
            stats.Love += choiceLeft.loveMod;
            stats.Career += choiceLeft.careerMod;
            UpdateChoices();
        }

        if (Input.GetKeyDown("right"))
        {
            stats.Mental += choiceRight.mentalMod;
            stats.Social += choiceRight.socialMod;
            stats.Family += choiceRight.familyMod;
            stats.Love += choiceRight.loveMod;
            stats.Career += choiceRight.careerMod;
            UpdateChoices();
        }

        if (Input.GetKeyDown("up"))
        {
            stats.Mental += choiceLeft.mentalMod + choiceRight.mentalMod;
            stats.Social += choiceLeft.socialMod + choiceRight.socialMod;
            stats.Family += choiceLeft.familyMod + choiceRight.familyMod;
            stats.Love += choiceLeft.loveMod + choiceRight.loveMod;
            stats.Career += choiceLeft.careerMod + choiceRight.careerMod;
            UpdateChoices();
        }

        if (Input.GetKeyDown("down"))
        {
            stats.Mental += choiceDown.GetComponent<Choice>().mentalMod;
            
            stats.Social -= choiceLeft.socialMod;
            stats.Family -= choiceLeft.familyMod;
            stats.Love -= choiceLeft.loveMod;
            stats.Career -= choiceLeft.careerMod;

            stats.Social -= choiceRight.socialMod;
            stats.Family -= choiceRight.familyMod;
            stats.Love -= choiceRight.loveMod;
            stats.Career -= choiceRight.careerMod;

            UpdateChoices();
        }
    }

    void UpdateChoices()
    {
        // Select 2 randoms index pour the typeList
        int typeIndex = Random.Range(0, typeList.Count);
        string randomType = typeList[typeIndex];
        int typeIndex2 = Random.Range(0, typeList.Count);
        while(typeIndex == typeIndex2){
            typeIndex2 = Random.Range(0, typeList.Count);
        }
        var randomType2 = typeList[typeIndex2];

        // Count files in the folders
        string typeFolder = "Assets/Scripts/Choices/" + randomType;
        DirectoryInfo dir = new DirectoryInfo(typeFolder);
        FileInfo[] info = dir.GetFiles("*.cs");
        int fileCount = info.Length;
        Array.Clear(info, 0, info.Length);
        var fileCount2 = (int?) null;
        if(randomType2 != null){
            string typeFolder2 = "Assets/Scripts/Choices/" + randomType2;
            DirectoryInfo dir2 = new DirectoryInfo(typeFolder2);
            FileInfo[] info2 = dir2.GetFiles("*.cs");
            fileCount2 = info2.Length;
            Array.Clear(info2, 0, info2.Length);
        }

        // Instantiate filler
        ChoiceFiller soLeft = (ChoiceFiller)ScriptableObject.CreateInstance(randomType + Random.Range(1, fileCount).ToString());
        var soRight = (ChoiceFiller) null;
        if(fileCount2 != null){ 
            soRight = (ChoiceFiller)ScriptableObject.CreateInstance(randomType2 + Random.Range(1, (int)fileCount2).ToString());
        }

        // Fill the choices
        choiceLeft.mentalMod = soLeft.mentalMod;
        choiceLeft.socialMod = soLeft.socialMod;
        choiceLeft.familyMod = soLeft.familyMod;
        choiceLeft.loveMod = soLeft.loveMod;
        choiceLeft.careerMod = soLeft.careerMod;
        if (soRight != null){
            choiceRight.mentalMod = soRight.mentalMod;
            choiceRight.socialMod = soRight.socialMod;
            choiceRight.familyMod = soRight.familyMod;
            choiceRight.loveMod = soRight.loveMod;
            choiceRight.careerMod = soRight.careerMod;
        }
    }
}
