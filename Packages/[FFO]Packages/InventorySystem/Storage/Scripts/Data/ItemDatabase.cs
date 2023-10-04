using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FFO.Inventory.Storage
{
    [CreateAssetMenu(fileName = "NewItemDatabase", menuName = "Database/Item", order = 1)]
    public class ItemDatabase : ScriptableObject
    {
        public Sprite defaultSprite;
        public List<ItemData> itemDatas = new();

        public void Init()
        {
            foreach (ItemData item in itemDatas)
            {
                item.InitID();
            }
        }
    }
}