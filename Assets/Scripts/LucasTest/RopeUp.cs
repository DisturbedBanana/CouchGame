using System;
using System.Collections;
using System.Collections.Generic;
using FFO.Inventory.Storage;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class RopeUp : Rope
{
    [SerializeField] private string _itemNeededID;
    [Range(0, 5)] public int _itemNeededAmount; 
    
    public override void ActivateRope()
    {
        if (!IsRopeActivated)
        {
            if (CurrentPlayer.GetComponentInChildren<PlayerInventory>().DoesPlayerHaveEnoughItems(_itemNeededID,_itemNeededAmount) && CurrentPlayer.GetComponent<Character>().PlayerId == 4)
            {
                IsRopeActivated = true;
                return;
            }
            if (CurrentPlayer.GetComponent<Character>().PlayerId == 2)
            {
                CurrentPlayer.transform.position = TargetRope.transform.position;
            }
        }
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CurrentPlayer = other.gameObject.GetComponent<RopeTeleportable>();

            if (CurrentPlayer != null)
            {
                CurrentPlayer.CanActivateRope = true;
                CurrentPlayer.CurrentRope = this;
            }
        }
    }
    
}
