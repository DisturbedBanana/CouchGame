using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : WorldItem
{
    private void OnTriggerEnter(Collider other)
    {
        PickupAble player = other.GetComponent<PickupAble>();
        if (player != null)
        {
            player.CanPickUp = true;
            player.CurrentItem = this;
        }
    }
}
