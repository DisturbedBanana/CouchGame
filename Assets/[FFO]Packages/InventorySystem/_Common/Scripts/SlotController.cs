using FFO.Inventory.Craft;
using FFO.Inventory.Storage;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static FFO.Inventory.Storage.ItemData;

namespace FFO.Inventory
{
    public class SlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool Selected { get; private set; }

        [Header("COMMON :")]
        [SerializeField] private Image imgItem;
        [SerializeField] private Text txtLabel;

        [Header("STORAGE :")]
        [SerializeField] private Text txtQuantity;

        [Header("CRAFT :")]
        [SerializeField] private GameObject parentIngredient;

        public ItemData DataItem { get; private set; }
        public RecipeData DataRecipe { get; set; }
        
        private int _quantity = 0;
        public int Quantity 
        { 
            get => _quantity;
            private set { _quantity = value; RefreshUI(); }
        }

        //public void SetSelect(bool value)
        //{
        //    Selected = value;
        //}

        private void Start()
        {
            RefreshUI();
        }

        public void OnAdd(ItemData item)
        {
            Quantity++;

            if (Quantity > 1)
                return;

            DataItem = item;
            imgItem.sprite = item.sprite;
            imgItem.color = item.color;
        }

        public void OnRemove()
        {
            Quantity--;

            if (Quantity > 0)
                return;

            DataItem = default;
            imgItem.sprite = null;
            imgItem.color = Color.clear;
        }

        public void OnUse()
        {
            switch (DataItem.category)
            {
                case CATEGORIES.COIN:
                    //StorageController.Instance.PlayerInventaire.scoreController.SetPoints(DataItem.value);
                    break;

                case CATEGORIES.LIFE:
                    //StorageController.Instance.PlayerInventaire.lifeController.SetLives(DataItem.value);
                    break;
            }

            OnRemove();
        }

        public void OnSelected()
        {
            if (DataItem != default)
            {
                EventSystem.current.SetSelectedGameObject(transform.GetChild(transform.childCount - 1).gameObject);
                StorageController.Instance.CurrentSlotSelected = this;
                StorageController.Instance.RefreshUI(DataItem);
            }

            if (DataRecipe != default)
            {
                EventSystem.current.SetSelectedGameObject(gameObject);
                CraftController.Instance.CurrentSlotSelected = this;
                CraftController.Instance.RefreshUI(DataRecipe);
            }
        }

        void RefreshUI()
        {
            if (txtQuantity != null)
            {
                txtQuantity.enabled = Quantity > 0;
                txtQuantity.text = Quantity.ToString();
            }

            if (DataRecipe != default)
            {
                if (DataRecipe.TryGetItemData(DataRecipe.IDItemResult, out ItemData it))
                {
                    if (txtLabel != null)
                        txtLabel.text = it.label;

                    if (imgItem != null)
                    {
                        imgItem.sprite = it.sprite;
                        imgItem.color = it.color;
                    }

                    if (parentIngredient != null)
                    {
                        foreach (string idIngredient in DataRecipe.IDItemIngredient)
                        {
                            if (DataRecipe.TryGetItemData(idIngredient, out ItemData itIngredient))
                            {
                                GameObject newIngGo = new();
                                newIngGo.transform.parent = parentIngredient.transform;

                                Image newIma = newIngGo.AddComponent<Image>();
                                newIma.sprite = itIngredient.sprite;
                                newIma.color = itIngredient.color;
                                newIma.preserveAspect = true;
                            }
                        }
                    }
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (DataItem != default)
                StorageController.Instance.RefreshUI(DataItem);

            if(DataRecipe != default)
                CraftController.Instance.RefreshUI(DataRecipe);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (DataItem != default)
                StorageController.Instance.RefreshUI();

            if (DataRecipe != default)
                CraftController.Instance.RefreshUI();
        }
    }
}