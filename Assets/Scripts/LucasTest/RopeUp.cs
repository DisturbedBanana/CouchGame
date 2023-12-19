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
    [Range(0, 5)] public int _neededIron;
    [Range(0, 5)] public int _neededWood;

    public override void ActivateRope()
    {
        if (!IsRopeActivated)
        {
            if (CurrentPlayer.GetComponent<Character>().NbIrons >= _neededIron && CurrentPlayer.GetComponent<Character>().NbWoods >= _neededWood && CurrentPlayer.GetComponent<Character>().PlayerId == 4)
            {
                IsRopeActivated = true;

                for (int i = 0; i < _neededWood; i++)
                {
                    DropInteraction.instance.RemoveOneWoodFromInventory(CurrentPlayer.GetComponent<Character>());
                }
                for (int i = 0; i < _neededIron; i++)
                {
                    DropInteraction.instance.RemoveOneIronFromInventory(CurrentPlayer.GetComponent<Character>());
                }

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
