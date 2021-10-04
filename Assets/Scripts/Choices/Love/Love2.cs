using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love2 : ChoiceFiller
{
    public Love2()
    {
        mentalMod = -5;
        loveMod = 5;
        type = "Love";
        text = "I thought we could maybe do a video call tonight. Are you interested?";
        texture = "love";
    }
}
