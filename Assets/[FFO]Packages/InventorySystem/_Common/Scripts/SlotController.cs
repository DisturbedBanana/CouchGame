using System;
using FFO.Inventory.Craft;
using FFO.Inventory.Storage;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static FFO.Inventory.Storage.ItemData;

namespace FFO.Inventory
{
    [Serializable]
    public class SlotController : MonoBehaviour, ISelectHandler
    {
        public bool Selected { get; private set; }

        [Header("COMMON :")]
        [SerializeField] public Image imgItem;
        [SerializeField] private Text txtLabel;

        [Header("STORAGE :")]
        [SerializeField] private Text txtQuantity;

        [Header("CRAFT :")]
        [SerializeField] private GameObject parentIngredient;

        public ItemData DataItem { get;  set; }
        public RecipeData DataRecipe { get; set; }
        public Image _selectImage;
        
        private int _quantity = 0;
        private StorageController _storageController;
        

        public int Quantity 
        { 
            get => _quantity;
            private set { _quantity = value; }
        }

        private void Start()
        {
            GetComponentInParent<StorageController>();
        }

        //public void SetSelect(bool value)
        //{
        //    Selected = value;
        //}

        public void OnAdd(ItemData item)
        {
            //Quantity++; <- stacking

            // if (Quantity > 1)
            //     return;

            DataItem = item;
            imgItem.sprite = item.sprite;
        }

        public void OnRemove()
        {
            //Quantity--;

            //if (Quantity > 0)
            //    return;

            DataItem = null;
            imgItem.sprite = null;
            imgItem.color = Color.clear;
        }

        public void OnUse()
        {
            switch (DataItem.category)
            {
                case CATEGORIES.ITEM :
                    break;
                case CATEGORIES.TOOL : 
                    break;
            }

            OnRemove();
        }

        public void OnSelect(BaseEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(transform.GetChild(transform.childCount-1).gameObject);
            _storageController.CurrentSlotSelected = this;
        }
    }
}