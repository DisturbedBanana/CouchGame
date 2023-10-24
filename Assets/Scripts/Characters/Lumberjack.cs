using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Lumberjack : Character
{
    public Lumberjack()
    {
        PlayerId = 1;
        Name = "Lumberjack";
        Life = 100;
        Heat = 100;
        MoveSpeed = 5f;
        InvSlots = 3;
        HasBoots = false;
        HasCoat = false;
        HasBackpack = false;
        HasTool = true;
    }
}
