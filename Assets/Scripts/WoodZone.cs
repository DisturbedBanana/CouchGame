using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            Debug.Log("Le feu prends du bois");
            /*Inventory inv = other.GetComponentInChildren<Inventory>();
            foreach (var item in inv.ItemList)
=======
            _playerInv = other.GetComponentInChildren<PlayerInventory>();

            foreach (SlotController data in _playerInv.storageController.SlotsList)
>>>>>>> Stashed changes
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
