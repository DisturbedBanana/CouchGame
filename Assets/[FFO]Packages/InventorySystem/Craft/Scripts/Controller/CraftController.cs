using FFO.Inventory.Storage;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FFO.Inventory.Craft
{
    public class CraftController : MonoBehaviour
    {
        public static CraftController Instance { get; private set; }
        public static bool IsOpenning { get; private set; }
        public SlotController CurrentSlotSelected { get; set; }

        [SerializeField] private GameObject parentSlot;
        [SerializeField] private GameObject prefabSlot;

        [Header("INFO")]
        [SerializeField] private Image _imgIconResult;
        [SerializeField] private Text _txtCaptionResult;

        public List<SlotController> Slots { get; private set; }
        //public PlayerController PlayerInventaire { get; private set; }

        public void Start()
        {
            Slots = new();
            for (int i = 0; i < DatabaseManager.Instance.RecipeDatabase.recipeDatas.Count; i++)
            {
                SlotController newSlot = Instantiate(prefabSlot, parentSlot.transform).GetComponent<SlotController>();

                newSlot.DataRecipe = DatabaseManager.Instance.RecipeDatabase.recipeDatas[i];

                Slots.Add(newSlot);
            }

            RefreshUI();
        }

        //public void OnSetOpen(bool value)
        //{
        //    Instance = value ? this : null;
        //    IsOpenning = GameManager.IsPause = value;
        //    PlayerInventaire = value ? PlayerController.Instance : null;
        //    transform.GetChild(0).gameObject.SetActive(value);
        //}

        //public void OnCraft()
        //{
        //    bool recipeIsGood = false;
        //    StorageController storageController = PlayerController.Instance.storageController;
        //    List<SlotController> slotsIngredient = new List<SlotController>();

        //    foreach (string idIngredient in CurrentSlotSelected.DataRecipe.IDItemIngredient)
        //    {
        //        if (storageController.Slots.Exists(x => x.DataItem != null && x.DataItem.ID == idIngredient))
        //        {
        //            SlotController scIngredient = storageController.Slots.Find(x => x.DataItem.ID == idIngredient);

        //            if (CurrentSlotSelected.DataRecipe.IDItemIngredient.FindAll(x => x == idIngredient).Count <= scIngredient.Quantity)
        //            {
        //                slotsIngredient.Add(scIngredient);
        //                recipeIsGood = true;
        //            }
        //            else
        //            {
        //                recipeIsGood = false;
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            recipeIsGood = false;
        //            break;
        //        }
        //    }

        //    if(recipeIsGood)
        //    {
        //        foreach(SlotController slot in slotsIngredient)
        //            slot.OnRemove();

        //        if (CurrentSlotSelected.DataRecipe.TryGetItemData(CurrentSlotSelected.DataRecipe.IDItemResult, out ItemData result))
        //            storageController.AddItem(result);

        //        Debug.Log("Success craft !");
        //    }
        //    else
        //    {
        //        Debug.Log("Error craft");
        //    }
        //}

        public void RefreshUI(RecipeData data = null)
        {
            if (data == null)
            {
                _imgIconResult.sprite = null;
                _imgIconResult.color = Color.clear;
                _txtCaptionResult.text = "";
            }
            else if (data.TryGetItemData(data.IDItemResult, out ItemData it))
            {
                _imgIconResult.sprite = it.sprite;
                _imgIconResult.color = it.color;
                _txtCaptionResult.text = it.Caption;
            }
            //txtInfo.text = CurrentSlotSelected ? CurrentSlotSelected.ItemData.caption : "";
        }
    }
}