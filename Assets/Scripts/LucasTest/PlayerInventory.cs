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

    
    //Passer en type de retour bool pour savoir si on peut add un item ou non + ajouter un check du nombre d'items dans le storage controller
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
    
    public bool DoesPlayerHaveEnoughItems(string _itemNeededID, int _itemNeededAmount)
    {
        foreach (SlotController slot in storageController.Slots)
        {
            if (slot.DataItem != null && slot.DataItem.ID == _itemNeededID)
            {
                _itemNeededAmount--;
                slot.OnRemove();
            }

            if (_itemNeededAmount == 0)
            {
                return true;
            }
        }

        return false;
    }
}
