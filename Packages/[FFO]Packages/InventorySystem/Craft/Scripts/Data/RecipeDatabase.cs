using System.Collections.Generic;
using UnityEngine;

namespace FFO.Inventory.Craft
{
    [CreateAssetMenu(fileName = "NewRecipeDatabase", menuName = "Database/Recipe", order = 1)]
    public class RecipeDatabase : ScriptableObject
    {
        public List<RecipeData> recipeDatas = new();

        //public void Init()
        //{
        //    foreach (RecipeData item in recipeDatas)
        //    {
        //        item.InitID();
        //    }
        //}
    }
}