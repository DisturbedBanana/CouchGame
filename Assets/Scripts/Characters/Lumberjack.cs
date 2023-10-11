using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Lumberjack : Character
{
    public Lumberjack()
    {
        Name = "Lumberjack";
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
