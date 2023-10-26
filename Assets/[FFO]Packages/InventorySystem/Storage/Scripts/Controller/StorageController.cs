using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FFO.Inventory.Storage
{
    public class StorageController : MonoBehaviour
    {
        public ItemData item;
        public ItemData item2;
        public ItemData item3;
        public ItemData item4;
        public ItemData item5;
        public static StorageController Instance { get; private set; }
        public static bool IsOpenning { get; private set; }
        public SlotController CurrentSlotSelected { get; set; }

        [SerializeField] private GameObject parentSlot;
        [SerializeField] private GameObject prefabSlot;

        [SerializeField] private int nbSlot;
        [SerializeField] private bool followPlayer = false;
        [SerializeField] private Camera cam;
        [SerializeField] private GameObject player;
        [SerializeField] private float offset = 1.8f;

        private RectTransform myRectTransform;
        private int nbOfItems = 0;
        
        

        [SerializeField] public List<SlotController> Slots { get; private set; }

        public void Start()
        {
            myRectTransform = GetComponent<RectTransform>();
            
            Slots = new();
            for (int i = 0; i < nbSlot; i++)
            {
                SlotController newSlot = Instantiate(prefabSlot, parentSlot.transform).GetComponent<SlotController>();
                Slots.Add(newSlot);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                AddItem(item);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                AddItem(item2);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                AddItem(item3);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                AddItem(item4);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                AddItem(item5);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                OnCycleItems();
                Debug.Log(Slots[0].DataItem.label);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                OnDrop(Slots[0]);
            }

            if (followPlayer)
            {
                myRectTransform.position = cam.WorldToScreenPoint(player.transform.position + new Vector3(offset,0,0));
            }
        }

        public void AddItem(ItemData item)
        {
            if (nbOfItems < 5)
            {
                for (int i = 0; i < Slots.Count; i++)
                {
                    if (Slots[i].DataItem == default || Slots[i].DataItem == null)
                    {
                        Slots[i].OnAdd(item);
                        nbOfItems++;
                        return;
                    }
                }

            }
            else
            {
                Debug.Log("Inventory is full");
            }
        }

        public void OnCycleItems()
        {
            if (Slots.Count >= 2)
            {
                var lastItem = Slots[Slots.Count - 1]; 

                for (int i = Slots.Count - 1; i > 0; i--)
                {
                    Slots[i] = Slots[i - 1];
                }

                Slots[0] = lastItem;

                RefreshUI();
            }
        }


        public void OnUse()
        {
            CurrentSlotSelected?.OnUse();
        }

        public void OnDrop(SlotController slot = null)
        {
            for (int i = 0; i < Slots.Count; i++)
            {
                if (Slots[i].DataItem != null)
                {
                    Slots[i].OnRemove();
                    nbOfItems--;
                    return;
                }
            }
        }

        public void RefreshUI(ItemData data = null)
        {
            foreach (SlotController item in Slots)
            {
                item.imgItem.sprite = item.DataItem.sprite;
            }
        }
    }
}