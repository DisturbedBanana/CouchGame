using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : WorldItem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickupAble>() != null)
        {
            
        }
    }
}
