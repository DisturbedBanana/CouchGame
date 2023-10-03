using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    private class CraftingRecipe
    {
        public string itemNeeded;
        public int amountNeeded;
        public string itemCrafted;
        public bool canBeCrafted;
    }

    [SerializeField] List<CraftingRecipe> _craftingRecipes = new List<CraftingRecipe>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            List<Item> playerItemList = other.gameObject.GetComponent<Inventory>().ItemList;
            foreach (CraftingRecipe craft in _craftingRecipes)
            {
                foreach (Item item in playerItemList)
                {
                    if (craft.itemNeeded == item.itemInformation.name && craft.amountNeeded <= item.itemInformation.amount)
                    {
                        craft.canBeCrafted = true;
                    }
                }
            }
        }
    }
}
