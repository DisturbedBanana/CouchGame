using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CraftingRecipe 
{
    public Item itemNeeded1;
    public Item itemNeeded2;
    public int amountNeeded1;
    public int amountNeeded2;
    public Item itemCrafted;
    public bool canBeCrafted;
}

public class CraftingTable : MonoBehaviour
{
    

    [SerializeField] GameObject _recipeDisplayPrefab;
    Image _recipeIngredient1;
    Image _recipeIngredient2;
    Image _recipeProduct;

    GameObject _recipeDisplay;

    [SerializeField] List<CraftingRecipe> _craftingRecipes = new List<CraftingRecipe>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            List<Item> playerItemList = other.gameObject.GetComponent<Inventory>().ItemList;
            foreach (CraftingRecipe craft in _craftingRecipes)
            {
                bool enoughItem1 = false;
                bool enoughItem2 = false;
                foreach (Item item in playerItemList)
                {
                    if (craft.itemNeeded1.itemInformation.name == item.itemInformation.name && craft.amountNeeded1 <= item.itemInformation.amount)
                    {
                        enoughItem1 = true;
                    }
                    else if (craft.itemNeeded2.itemInformation.name == item.itemInformation.name && craft.amountNeeded2 <= item.itemInformation.amount)
                    {
                        enoughItem2 = true;
                    }
                }

                if (enoughItem1 && enoughItem2)
                    craft.canBeCrafted = true;
            }
            UpdateRecipeDisplay();
        }
    }

    private void UpdateRecipeDisplay()
    {
        foreach (CraftingRecipe recipe in _craftingRecipes)
        {
            if (recipe.canBeCrafted)
            {
                _recipeDisplay = GameObject.Instantiate(_recipeDisplayPrefab, transform.position, Quaternion.identity);
                _recipeIngredient1 = _recipeDisplay.transform.GetChild(0).GetComponent<Image>();
                _recipeIngredient2 = _recipeDisplay.transform.GetChild(1).GetComponent<Image>();
                _recipeProduct = _recipeDisplay.transform.GetChild(2).GetComponent<Image>();

                _recipeIngredient1.color = recipe.itemNeeded1.itemInformation.color;
                _recipeIngredient2.color = recipe.itemNeeded2.itemInformation.color;
                _recipeProduct.color = recipe.itemCrafted.itemInformation.color;
            }
        }
    }
}
