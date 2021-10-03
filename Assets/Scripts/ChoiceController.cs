using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChoiceController : MonoBehaviour
{
    private GameObject choiceLeft;
    private GameObject choiceRight;
    private GameObject choiceUp;
    private GameObject choiceDown;
    private List<string> typeList = new List<string>{"Social","Family","Love","Career"};

    // Start is called before the first frame update
    void Start()
    {
        choiceLeft = GameObject.Find("Choices").transform.Find("Left").gameObject;
        choiceRight = GameObject.Find("Choices").transform.Find("Right").gameObject;
        choiceUp = GameObject.Find("Choices").transform.Find("Up").gameObject;
        choiceDown = GameObject.Find("Choices").transform.Find("Down").gameObject;
        
        int typeIndex = Random.Range(0, typeList.Count - 1);
        string randomType = typeList[typeIndex];
        int typeIndex2 = Random.Range(0, typeList.Count - 1);
        while(typeIndex == typeIndex2){
            typeIndex2 = Random.Range(0, typeList.Count - 1);
        }
        string randomType2 = typeList[typeIndex2];

        string levelFolder = "Assets/Scripts/Choices/Social";
        DirectoryInfo dir = new DirectoryInfo(levelFolder);
        FileInfo[] info = dir.GetFiles("*.cs");
        int fileCount = info.Length;
        print(fileCount);
        Array.Clear(info, 0, info.Length);

        ChoiceFiller soLeft = (ChoiceFiller)ScriptableObject.CreateInstance("Social" + Random.Range(1, fileCount).ToString());
        //ChoiceFiller soRight = (ChoiceFiller)ScriptableObject.CreateInstance("ChoiceFiller");
        print(soLeft);
        print(soLeft.mentalMod);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateChoices()
    {

    }
}
