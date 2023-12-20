using FFO.Inventory.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WorldItem : MonoBehaviour
{
    public string itemType;
    private ItemData _data;

    public ItemData Data
    {
        get { return _data; }
        set { _data = value; }
    }
}
