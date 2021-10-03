using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChoiceFiller : ScriptableObject
{
    public int mentalMod = 0;
    public int socialMod = 0;
    public int familyMod = 0;
    public int loveMod = 0;
    public int careerMod = 0;
    public string type;
    public string text;
}
