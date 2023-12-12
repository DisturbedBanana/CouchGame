using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour
{
    
    
    private bool _canPickUp = false;
    private PickupItem _currentItem;

    public bool CanPickUp
    {
        set { _canPickUp = value; }
    }

    public PickupItem CurrentItem
    {
        get { return _currentItem; }
        set { _currentItem = value; }
    }

    private void Add()
    {
        GetComponentInChildren<PlayerInventory>().AddItemToInventory(_currentItem.Data.ID);
    }
}
