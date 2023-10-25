using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FFO.Inventory.Storage
{
    public class StorageController : MonoBehaviour
    {
        public static StorageController Instance { get; private set; }
        public static bool IsOpenning { get; private set; }
        public SlotController CurrentSlotSelected { get; set; }

        [SerializeField] private GameObject parentSlot;
        [SerializeField] private GameObject prefabSlot;
        [SerializeField] private Text txtInfo;

        [SerializeField] private int nbSlot;

        public List<SlotController> Slots { get; private set; }

        //replace with our player
        //public PlayerController PlayerInventaire { get; private set; }

        public void Start()
        {
            Slots = new();
            for (int i = 0; i < nbSlot; i++)
            {
                SlotController newSlot = Instantiate(prefabSlot, parentSlot.transform).GetComponent<SlotController>();
                Slots.Add(newSlot);
            }

            RefreshUI();
        }


        public void AddItem(ItemData item)
        {
            if (Slots.Exists(x => x.DataItem == item))
                Slots.Find(x => x.DataItem == item).OnAdd(item);
            else
                Slots.Find(x => x.DataItem == default).OnAdd(item);
        }

        //public void OnSetOpen(bool value)
        //{
        //    Instance = value ? this : null;
        //    IsOpenning = GameManager.IsPause = value;
        //    PlayerInventaire = value ? PlayerController.Instance : null;
        //    transform.GetChild(0).gameObject.SetActive(value);
        //}

        public void OnCycleItems()
        {
            if (Slots.Count >= 2)
            {
                for (int i = 0; i < Slots.Count-1; i++)
                {
                    if (i != 0)
                    {
                        Slots[i - 1] = Slots[i];
                    }
                    else
                    {
                        Slots[^1] = Slots[i];
                    }
                }
                
                RefreshUI();
            }
            
        }

        public void OnUse()
        {
            CurrentSlotSelected?.OnUse();
        }

        public void OnDrop()
        {
            CurrentSlotSelected?.OnRemove();
        }

        public void RefreshUI(ItemData data = null)
        {
            if (data == null)
                txtInfo.text = "";
            else
                txtInfo.text = data.Caption;

            //txtInfo.text = CurrentSlotSelected ? CurrentSlotSelected.ItemData.caption : "";
        }
    }
}