using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class ChoiceController : MonoBehaviour
{
    private Choice choiceLeft;
    private Choice choiceRight;
    private Choice choiceUp;
    private Choice choiceDown;
    private GameObject left;
    private GameObject right;
    private GameObject up;
    private GameObject down;
    private List<string> typeList = new List<string>{"Social","Family","Love","Career"};
    private List<int> socialIdList = new List<int>{};
    private List<int> familyIdList = new List<int>{};
    private List<int> loveIdList = new List<int>{};
    private List<int> careerIdList = new List<int>{};
    private int currentSocialIndex = 0;
    private int currentFamilyIndex = 0;
    private int currentLoveIndex = 0;
    private int currentCareerIndex = 0;
    private Stats stats;
    private AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        left = GameObject.Find("Choices").transform.Find("Left").gameObject;
        right = GameObject.Find("Choices").transform.Find("Right").gameObject;
        up = GameObject.Find("Choices").transform.Find("Up").gameObject;
        down = GameObject.Find("Choices").transform.Find("Down").gameObject;
        choiceLeft = left.GetComponent<Choice>();
        choiceRight = right.GetComponent<Choice>();
        choiceUp = up.GetComponent<Choice>();
        choiceDown = down.GetComponent<Choice>();

        // Self choice
        choiceDown.mentalMod = 5;

        stats = GameObject.Find("Stats").GetComponent<Stats>();

        //string AssetsFolderPath = Application.dataPath;
        // Count files in the folders
        foreach(var type in typeList){
            /* //TODO Count files in folder
            string typeFolder = AssetsFolderPath + "/Scripts/Choices/" + type;
            DirectoryInfo dir = new DirectoryInfo(typeFolder);
            FileInfo[] info = dir.GetFiles("*.cs");
            int fileCount = info.Length;
            Array.Clear(info, 0, info.Length);
            */
            int fileCount = 0;
            switch(type){
                case "Social":
                    fileCount = 12;
                    break;
                case "Family":
                    fileCount = 11;
                    break;
                case "Love":
                    fileCount = 11;
                    break;
                case "Career":
                    fileCount = 10;
                    break;
            }
            
            for(var i = 0 ; i < fileCount ; i++){
                switch(type){
                    case "Social":
                        socialIdList.Add(i+1);
                        break;
                    case "Family":
                        familyIdList.Add(i+1);
                        break;
                    case "Love":
                        loveIdList.Add(i+1);
                        break;
                    case "Career":
                        careerIdList.Add(i+1);
                        break;
                }
            }
        }

        Shuffle(socialIdList);
        Shuffle(familyIdList);
        Shuffle(loveIdList);
        Shuffle(careerIdList);
        
        UpdateChoices();

        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            audioData.Play(0);
            stats.Mental += choiceLeft.mentalMod;
            stats.Social += choiceLeft.socialMod;
            stats.Family += choiceLeft.familyMod;
            stats.Love += choiceLeft.loveMod;
            stats.Career += choiceLeft.careerMod;
            UpdateChoices();
        }

        if (Input.GetKeyDown("right"))
        {
            audioData.Play(0);
            stats.Mental += choiceRight.mentalMod;
            stats.Social += choiceRight.socialMod;
            stats.Family += choiceRight.familyMod;
            stats.Love += choiceRight.loveMod;
            stats.Career += choiceRight.careerMod;
            UpdateChoices();
        }

        if (Input.GetKeyDown("up"))
        {
            audioData.Play(0);
            stats.Mental += choiceLeft.mentalMod + choiceRight.mentalMod;
            stats.Social += choiceLeft.socialMod + choiceRight.socialMod;
            stats.Family += choiceLeft.familyMod + choiceRight.familyMod;
            stats.Love += choiceLeft.loveMod + choiceRight.loveMod;
            stats.Career += choiceLeft.careerMod + choiceRight.careerMod;
            UpdateChoices();
        }

        if (Input.GetKeyDown("down"))
        {
            audioData.Play(0);
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
        // Select 2 randoms index for the typeList
        int typeIndex = Random.Range(0, typeList.Count);
        string randomType = typeList[typeIndex];
        int typeIndex2 = Random.Range(0, typeList.Count);
        while(typeIndex == typeIndex2){
            typeIndex2 = Random.Range(0, typeList.Count);
        }
        var randomType2 = typeList[typeIndex2];

        // Choose next random
        int randomId = 0;
        switch(randomType){
            case "Social":
                randomId = socialIdList[currentSocialIndex];
                currentSocialIndex++;
                if(currentSocialIndex == socialIdList.Count){
                    Shuffle(socialIdList);
                    currentSocialIndex = 0;
                }
                break;
            case "Family":
                randomId = familyIdList[currentFamilyIndex];
                currentFamilyIndex++;
                if(currentFamilyIndex == familyIdList.Count){
                    Shuffle(familyIdList);
                    currentFamilyIndex = 0;
                }
                break;
            case "Love":
                randomId = loveIdList[currentLoveIndex];
                currentLoveIndex++;
                if(currentLoveIndex == loveIdList.Count){
                    Shuffle(loveIdList);
                    currentLoveIndex = 0;
                }
                break;
            case "Career":
                randomId = careerIdList[currentCareerIndex];
                currentCareerIndex++;
                if(currentCareerIndex == careerIdList.Count){
                    Shuffle(careerIdList);
                    currentCareerIndex = 0;
                }
                break;
        }

        int randomId2 = 0;
        switch(randomType2){
            case "Social":
                randomId2 = socialIdList[currentSocialIndex];
                currentSocialIndex++;
                if(currentSocialIndex == socialIdList.Count){
                    Shuffle(socialIdList);
                    currentSocialIndex = 0;
                }
                break;
            case "Family":
                randomId2 = familyIdList[currentFamilyIndex];
                currentFamilyIndex++;
                if(currentFamilyIndex == familyIdList.Count){
                    Shuffle(familyIdList);
                    currentFamilyIndex = 0;
                }
                break;
            case "Love":
                randomId2 = loveIdList[currentLoveIndex];
                currentLoveIndex++;
                if(currentLoveIndex == loveIdList.Count){
                    Shuffle(loveIdList);
                    currentLoveIndex = 0;
                }
                break;
            case "Career":
                randomId2 = careerIdList[currentCareerIndex];
                currentCareerIndex++;
                if(currentCareerIndex == careerIdList.Count){
                    Shuffle(careerIdList);
                    currentCareerIndex = 0;
                }
                break;
        }
        
        // Instantiate filler
        ChoiceFiller soLeft = (ChoiceFiller)ScriptableObject.CreateInstance(randomType + randomId.ToString());
        ChoiceFiller soRight = (ChoiceFiller)ScriptableObject.CreateInstance(randomType2 + randomId2.ToString());

        // Fill the choices
        choiceLeft.mentalMod = soLeft.mentalMod;
        choiceLeft.socialMod = soLeft.socialMod;
        choiceLeft.familyMod = soLeft.familyMod;
        choiceLeft.loveMod = soLeft.loveMod;
        choiceLeft.careerMod = soLeft.careerMod;
        left.transform.Find("Text").gameObject.GetComponent<TMP_Text>().text = soLeft.text;
        left.transform.Find("Image").gameObject.GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/" + soLeft.texture);

        choiceRight.mentalMod = soRight.mentalMod;
        choiceRight.socialMod = soRight.socialMod;
        choiceRight.familyMod = soRight.familyMod;
        choiceRight.loveMod = soRight.loveMod;
        choiceRight.careerMod = soRight.careerMod;
        right.transform.Find("Text").gameObject.GetComponent<TMP_Text>().text = soRight.text;
        right.transform.Find("Image").gameObject.GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/" + soRight.texture);
    }

    private void Shuffle<T>(List<T> list)  
    {  
        for (int i = 0; i < list.Count; i++) {
            var current = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = current;
        }
    }
}
