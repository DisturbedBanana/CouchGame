using FFO.Inventory.Storage;
using System;
using System.Collections.Generic;

namespace FFO.Inventory.Craft
{
    [Serializable]
    public class RecipeData
    {
        public string ID { get; set; }

        public List<string> IDItemIngredient = new();
        public string IDItemResult;

        public bool TryGetItemData(string idItem, out ItemData itemData)
        {
            itemData = GetItemData(idItem);

            return itemData != default;

            //foreach (var database in DatabaseManager.Instance.GetAllItemDatabase())
            //    if (database.itemDatas.Exists(x => x.ID == idItem))
            //    {
            //        itemData = database.itemDatas.Find(x => x.ID == idItem);
            //        return true;
            //    }

            //return false;
        }

        public ItemData GetItemData(string idItem)
        {
            foreach (var database in DatabaseManager.Instance.GetAllItemDatabase())
                if (database.itemDatas.Exists(x => x.ID == idItem))
                    return database.itemDatas.Find(x => x.ID == idItem);

            return default;
        }
    }
}