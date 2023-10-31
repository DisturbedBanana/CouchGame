using FFO.Inventory;
using FFO.Inventory.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> itemList;
    private ItemDatabase itemDatabase;
    [SerializeField] public StorageController storageController;

    private void Start()
    {
        itemDatabase = DatabaseManager.Instance.ItemDatabase;
    }

    public List<ItemData> ItemList { get => itemList;}

    public void AddItemToInventory(string itemName)
    {
        foreach (ItemData item in itemDatabase.itemDatas)
        {
            if (item.ID == itemName)
            {
                itemList.Add(item);
                storageController.AddItem(item);
            }
            /*else
            {
                Debug.Log(item.ID + " not found");
            }*/
        }
    }
}
