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
                storageController.AddItem(item);
                ItemList.Add(item);
            }
        }
    }
    
    public bool DoesPlayerHaveTheGoods(string _itemNeededID, int _itemNeededAmount)
    {
        List<ItemData> itemsToRemove = new List<ItemData>();
        int amountOfItems = 0;
        foreach (ItemData item in ItemList)
        {
            if (item.ID == _itemNeededID)
            {
                amountOfItems++;
                itemsToRemove.Add(item);
            }

            if (amountOfItems >= _itemNeededAmount)
            {
                for (int i = 0; i < itemsToRemove.Count; i++)
                {
                    //remove items here , to be implemented
                }
                return true;
            }
        }
        return false;
    }
}
