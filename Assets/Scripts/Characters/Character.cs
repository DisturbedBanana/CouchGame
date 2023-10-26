using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private void Awake()
    {
        GetComponentInChildren<PlayerMovTest>().PlayerSpeed = MoveSpeed;
    }

    private int _playerId;
    private string _name;
    private float _heat;
    private float _moveSpeed;
    private int _invSlots;
    private bool _hasBoots;
    private bool _hasCoat;
    private bool _hasBackpack;
    private bool _hasTool;
    private bool _isInSnow;

    public int PlayerId { get { return _playerId; } set { _playerId = value; } }
    public string Name { get { return _name; } set { _name = value; } }

    public float Heat { get { return _heat; } set { _heat = value; } }

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    public int InvSlots { get { return _invSlots; } set { _invSlots= value; } }

    public bool HasBoots { get { return _hasBoots; } set { _hasBoots = value; } }

    public bool HasCoat { get { return _hasCoat; } set { _hasCoat = value; } }

    public bool HasBackpack { get { return _hasBackpack; } set { _hasBackpack = value; } }

    public bool HasTool { get { return _hasTool; } set { _hasTool = value; } }

    public bool IsInSnow { get { return _isInSnow; } set { _isInSnow = value; } }
}
