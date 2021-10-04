using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love3 : ChoiceFiller
{
    public Love3()
    {
        mentalMod = -5;
        loveMod = 5;
        type = "Love";
        text = "I’d love you to meet my other partner. I dunno if this is awkward or not. But they would like to meet you as well. Could be a nice polyamory experience, don’t you think?";
        texture = "love";
    }
}
