using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Career3 : ChoiceFiller
{
    public Career3()
    {
        mentalMod = -5;
        careerMod = 5;
        type = "Career";
        text = "Hi. Due to Covid tests, two of your colleagues won’t be present tomorrow. I need you to replace them. Can you help me?";
        texture = "career";
    }
}
