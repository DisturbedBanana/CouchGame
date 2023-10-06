using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform _firstItemPosition;
    [SerializeField] GameObject _itemPrefab;
    [SerializeField] GameObject canvas;
    [SerializeField] float _offset;

    List<Item> _itemList = new List<Item>();

    public GameObject ItemPrefab{ get { return _itemPrefab; } }

    public List<Item> ItemList
    {
        get { return _itemList; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            Additem("red", Color.red);

        if (Input.GetKeyDown(KeyCode.O))
            Additem("green", Color.green);

        if (Input.GetKeyDown(KeyCode.P))
            Additem("blue", Color.blue);
    }

    private void Additem(string name, Color color)
    {
        bool itemFound = false;

        for (int i = 0; i < _itemList.Count; i++)
        {
            if (name == _itemList[i].itemInformation.name)
            {
                _itemList[i].itemInformation.amount += 1;
                _itemList[i].UpdateItemDisplay();
                itemFound = true;
            }
        }

        if (!itemFound)
        {
            Item item = new Item(name, color, _itemPrefab);
            _itemList.Add(item);

            if (_itemList.Count == 1)
            {
                item.itemDisplay.transform.position = _firstItemPosition.position;
            }
            else
            {
                item.itemDisplay.transform.position = _firstItemPosition.position + new Vector3(_offset * (_itemList.Count - 1) , 0);
            }
            item.itemDisplay.transform.SetParent(canvas.transform);
        }
    }

    private void UpdateItemPositions()
    {
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (_itemList.Count == 1)
            {
                _itemList[i].itemDisplay.transform.position = _firstItemPosition.position;
            }
            else
            {
                _itemList[i].itemDisplay.transform.position = _firstItemPosition.position + new Vector3(_offset * (_itemList.Count - 1), 0);
            }
        }
    }
}
