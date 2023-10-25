using System;
using UnityEngine;

namespace FFO.Inventory.Storage
{
    [Serializable]
    public class ItemData
    {
        public enum CATEGORIES
        {
            NONE,
            ITEM,
            TOOL
        }

        public string label = "New label";
        [field: SerializeField] public string ID { get; private set; } = string.Empty;
        public string Caption { get => "Add " + value + " " + category.ToString().ToLower(); }
        public Sprite sprite;
        public Mesh mesh;
        public CATEGORIES category = CATEGORIES.NONE;
        public Color color = Color.white;
        public int value = 1;
        public int quantityMax = 99;

        public ItemData() { }

        public ItemData(string label, string caption, Mesh mesh , Sprite sprite, CATEGORIES category, Color color, int value)
        {
            ID = label[0] + "_" + category.ToString();
            this.label = label;
            //this.caption = caption;
            this.sprite = sprite;
            this.mesh = mesh;
            this.category = category;
            this.color = color;
            this.value = value;
        }

        public void InitID()
        {
            string newID = label[..3] + "_" + category.ToString();

            if (ID != newID)
                ID = newID;
        }
    }
}
