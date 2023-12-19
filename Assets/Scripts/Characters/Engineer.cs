using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineer : Character
{
    public Engineer()
    {
        PlayerId = 4;
        Name = "Engineer";
        Heat = 100f;
        MoveSpeed = 5f;
        InvSlots = 2;
        HasBoots = false;
        HasCoat = false;
        HasBackpack = false;
        HasTool = true;
        IsInSnow = false;
        IsAlive = true;
        NbMaximumItems = 4;
    }
}
