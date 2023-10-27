using FFO.Inventory.Storage;
using System.Collections;
using System.Collections.Generic;
using FFO.Inventory;
using UnityEngine;

public class WoodZone : MonoBehaviour
{
    PlayerInventory _playerInv;
    [SerializeField] private ExpandingFlame _flame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Le feu prends du bois");

            _playerInv = other.GetComponentInChildren<PlayerInventory>();

            foreach (SlotController data in _playerInv.storageController.Slots)
            {
                if (data.DataItem.ID == "Woo_NONE")
                {
                    _playerInv.storageController.OnDrop();
                    _flame.StartLerpFlameScale();
                }
            }
        }
    }
}
