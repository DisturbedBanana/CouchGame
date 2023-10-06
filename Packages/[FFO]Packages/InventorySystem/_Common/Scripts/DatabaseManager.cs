using FFO.Inventory.Craft;
using FFO.Inventory.Storage;
using System.Collections.Generic;
using UnityEngine;

namespace FFO.Inventory
{
    public class DatabaseManager : MonoBehaviour
    {
        public static DatabaseManager Instance { get; private set; }

        [field: SerializeField] public ItemDatabase CoinDatabase { get; private set; }
        [field: SerializeField] public ItemDatabase LifeDatabase { get; private set; }
        [field: SerializeField] public RecipeDatabase RecipeDatabase { get; private set; }

        public void Awake()
        {
            if (Instance == null)
                Instance = this;

            CoinDatabase.Init();
            LifeDatabase.Init();
        }

        public List<ItemDatabase> GetAllItemDatabase()
        {
            return new()
            {
                CoinDatabase,
                LifeDatabase
            };
        }
    }
}