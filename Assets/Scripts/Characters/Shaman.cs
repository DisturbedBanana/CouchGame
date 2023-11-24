using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaman : Character
{
    public Shaman()
    {
        PlayerId = 3;
        Name = "Shaman";
        Heat = 100f;
        MoveSpeed = 7f;
        InvSlots = 2;
        HasBoots = false;
        HasCoat = false;
        HasBackpack = false;
        HasTool = true;
        IsInSnow = false;
        IsAlive = true;
    }
}
