using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorer : Character
{
    public Explorer()
    {
        Name = "Explorer";
        Life = 100;
        Heat = 100;
        MoveSpeed = 5f;
        InvSlots = 2;
        HasBoots = false;
        HasCoat = false;
        HasBackpack = false;
        HasTool = true;
    }
}
