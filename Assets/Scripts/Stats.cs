using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    private GameObject mentalText;
    private GameObject socialText;
    private GameObject familyText;
    private GameObject loveText;
    private GameObject careerText;
    
    private int mental;
    private int social;
    private int family;
    private int love;
    private int career;
    
    public int Mental 
    { 
        get { return mental; }
        set {
            mental = value;
            mentalText.GetComponent<TMP_Text>().text = mental.ToString();
        } 
    }
    public int Social
    { 
        get { return social; }
        set {
            social = value;
            socialText.GetComponent<TMP_Text>().text = social.ToString();
        } 
    }
    public int Family
    { 
        get { return family; }
        set {
            family = value;
            familyText.GetComponent<TMP_Text>().text = family.ToString();
        } 
    }
    public int Love
    { 
        get { return love; }
        set {
            love = value;
            loveText.GetComponent<TMP_Text>().text = love.ToString();
        } 
    }
    public int Career
    { 
        get { return career; }
        set {
            career = value;
            careerText.GetComponent<TMP_Text>().text = career.ToString();
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        mentalText = GameObject.Find("MentalText");
        socialText = GameObject.Find("SocialText");
        familyText = GameObject.Find("FamilyText");
        loveText = GameObject.Find("LoveText");
        careerText = GameObject.Find("CareerText");

        Mental = 50;
        Social = 10;
        Family = 10;
        Love = 10;
        Career = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
