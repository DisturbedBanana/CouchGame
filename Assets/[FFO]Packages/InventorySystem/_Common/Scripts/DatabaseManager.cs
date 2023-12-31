using FFO.Inventory.Craft;
using FFO.Inventory.Storage;
using System.Collections.Generic;
using UnityEngine;

namespace FFO.Inventory
{
    public class DatabaseManager : MonoBehaviour
    {
        public static DatabaseManager Instance { get; private set; }
        
        [field: SerializeField] public ItemDatabase ItemDatabase { get; private set; }
        [field: SerializeField] public RecipeDatabase RecipeDatabase { get; private set; }

        public void Awake()
        {
            if (Instance == null)
                Instance = this;

            ItemDatabase.Init();
        }
    }
}