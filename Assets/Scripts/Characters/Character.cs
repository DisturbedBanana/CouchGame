using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _playerId;
    [SerializeField] private string _name;
    [SerializeField] private float _heat;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _invSlots;
    [SerializeField] private bool _hasBoots;
    [SerializeField] private bool _hasCoat;
    [SerializeField] private bool _hasBackpack;
    [SerializeField] private bool _hasTool;
    [SerializeField] private bool _isInSnow;
    [SerializeField] private bool _isAlive;

    [SerializeField] private int _nbWoods = 0;
    [SerializeField] private int _nbCharcoals = 0;
    [SerializeField] private int _nbIrons = 0;
    [SerializeField] private int _nbMaximumItems;

    [SerializeField] private bool _isInsideWoodZone = false;


    public int NbWoods {
       get => _nbWoods;
       set => _nbWoods = value;
    }

    public int NbCharcoals
    {
        get => _nbCharcoals;
        set => _nbCharcoals = value;
    }

    public int NbIrons
    {
        get => _nbIrons;
        set => _nbIrons = value;
    }

    public bool IsInsideWoodZone
    {
        get => _isInsideWoodZone;
        set => _isInsideWoodZone = value;
    }

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

    public bool IsAlive { get { return _isAlive; } set { _isAlive = value; } }

    public int NbMaximumItems { get { return _nbMaximumItems; } set { _nbMaximumItems = value; } }
}
