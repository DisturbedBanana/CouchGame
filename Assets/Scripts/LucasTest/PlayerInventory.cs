using FFO.Inventory;
using FFO.Inventory.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> itemList;
    private ItemDatabase itemDatabase;
    StorageController storageController;

    private void Start()
    {
        storageController = GetComponent<StorageController>();
    }

    public List<ItemData> ItemList { get => itemList;}

    public void AddItemToInventory(string itemName)
    {
        foreach (ItemData item in itemDatabase.itemDatas)
        {
            if (item.ID == itemName)
            {
                storageController.AddItem(item);
            }
            else
            {
                Debug.Log(item.ID + " not found");
            }
        }
    }
}
