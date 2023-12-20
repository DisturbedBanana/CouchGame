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
    [SerializeField] private GameObject _ropeModel;
    [SerializeField] private ContextualTrigger _engiRopePopupTrigger, _scoutClimbPopupTrigger, _ropeClimbPopupTrigger;

    private void Awake()
    {
        _ropeModel.SetActive(false);
        _ropeClimbPopupTrigger.enabled = false;
    }

    public override void ActivateRope()
    {
        if (!IsRopeActivated)
        {
            if (CurrentPlayer.GetComponent<Character>().NbIrons >= _neededIron && CurrentPlayer.GetComponent<Character>().NbWoods >= _neededWood && CurrentPlayer.GetComponent<Character>().PlayerId == 4)
            {
                IsRopeActivated = true;
                _ropeModel.SetActive(true);

                for (int i = 0; i < _neededWood; i++)
                {
                    DropInteraction.instance.RemoveOneWoodFromInventory(CurrentPlayer.GetComponent<Character>());
                }
                for (int i = 0; i < _neededIron; i++)
                {
                    DropInteraction.instance.RemoveOneIronFromInventory(CurrentPlayer.GetComponent<Character>());
                }

                _scoutClimbPopupTrigger.enabled = false;
                _engiRopePopupTrigger.enabled = false;
                _ropeClimbPopupTrigger.enabled = true;

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
