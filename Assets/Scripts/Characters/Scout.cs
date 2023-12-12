using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Character
{
    public Scout()
    {
        PlayerId = 2;
        Name = "Explorer";
        Heat = 100f;
        MoveSpeed = 5f;
        InvSlots = 2;
        HasBoots = false;
        HasCoat = false;
        HasBackpack = false;
        HasTool = true;
        IsInSnow = false;
        IsAlive = true;
    }
}
