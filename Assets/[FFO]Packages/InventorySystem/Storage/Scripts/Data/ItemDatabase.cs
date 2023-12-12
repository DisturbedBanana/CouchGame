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

        Object[] itemsInScene;

        public void Init()
        {
            itemsInScene = FindObjectsOfType(typeof(WorldItem));

            foreach (ItemData item in itemDatas)
            {
                item.InitID();
            }

            foreach (WorldItem item in itemsInScene)
            {
                foreach (ItemData itemData in itemDatas)
                {
                    if (item.itemType == itemData.label)
                    {
                        item.Data = itemData;
                        break;
                    }
                }
            }
        }
    }
}