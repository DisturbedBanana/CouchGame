using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaman : Character
{
    public Shaman()
    {
        PlayerId = 3;
        Name = "Hunter";
        Heat = 100f;
        MoveSpeed = 5f;
        InvSlots = 2;
        HasBoots = false;
        HasCoat = false;
        HasBackpack = false;
        HasTool = true;
        IsInSnow = false;
    }
}
