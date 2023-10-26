using FFO.Inventory.Storage;
using System.Collections;
using System.Collections.Generic;
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

            _playerInv.storageController.OnDrop();

            _flame.StartLerpFlameScale();

            /*Inventory inv = other.GetComponentInChildren<Inventory>();
            foreach (var item in inv.ItemList)
            {
                if (item.itemInformation.name == "red" && item.itemInformation.amount > 0)
                {
                    item.itemInformation.amount--;
                    transform.localScale += new Vector3(_flameGrowthFromWood, _flameGrowthFromWood, _flameGrowthFromWood);
                }
            }*/
        }
    }
}
