using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love10 : ChoiceFiller
{
    public Love10()
    {
        mentalMod = -5;
        loveMod = 5;
        type = "Love";
        text = "Hey, look! The Zoo reopened! Do we go together next weekend?";
        texture = "love";
    }
}
