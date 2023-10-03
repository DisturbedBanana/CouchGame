using UnityEngine;
using UnityEngine.UI;
using TMPro;

public struct ItemInformation
{
    public string name;
    public Color color;
    public int amount;
}

public class Item
{
    public ItemInformation itemInformation;
    public GameObject itemDisplay;


    public Item(string name, Color color, GameObject prefab)
    {
        itemInformation.name = name;
        itemInformation.color = color;
        itemInformation.amount = 1;
        itemDisplay = GameObject.Instantiate(prefab);
        UpdateItemDisplay();
    }   

    public void UpdateItemDisplay()
    {
        itemDisplay.GetComponent<Image>().color = itemInformation.color;
        itemDisplay.GetComponentInChildren<TextMeshProUGUI>().text = itemInformation.amount.ToString();
    }   
}
