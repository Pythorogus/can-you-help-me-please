using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love1 : ChoiceFiller
{
    public Love1()
    {
        mentalMod = -5;
        loveMod = 5;
        type = "Love";
        text = "I miss you! Maybe we can plan next weekend together? Will you be available?";
        texture = "love";
    }
}
