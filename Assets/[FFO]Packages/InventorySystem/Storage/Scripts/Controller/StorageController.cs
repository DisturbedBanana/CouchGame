using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Cinemachine.Editor;
using UnityEngine;
using UnityEngine.UI;

namespace FFO.Inventory.Storage
{
    public class StorageController : MonoBehaviour
    {
        public ItemData item;
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
        private bool isInventoryShown = false;
        
        

        [SerializeField] public List<SlotController> SlotsList { get; private set; }

        public void Start()
        {
            myRectTransform = GetComponent<RectTransform>();
            
            SlotsList = new();
            for (int i = 0; i < nbSlot; i++)
            {
                SlotController newSlot = Instantiate(prefabSlot, parentSlot.transform).GetComponent<SlotController>();
                SlotsList.Add(newSlot);
                Image[] imgList = newSlot.GetComponentsInChildren<Image>();
                
                foreach (Image img in imgList)
                {
                    img.color = Color.clear;
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                AddItem(item);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                ToggleVisibility();
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                OnDrop(SlotsList[0]);
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
                for (int i = 0; i < SlotsList.Count; i++)
                {
                    if (SlotsList[i].DataItem == default || SlotsList[i].DataItem == null)
                    {
                        SlotsList[i].OnAdd(item);
                        
                        if (!isInventoryShown)
                        {
                            SlotsList[i].imgItem.color = Color.clear;
                        }
                        
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

        public void ToggleVisibility()
        {
            Color replacingColor;
            
            if (isInventoryShown)
            {
                replacingColor = Color.clear;
            }
            else
            {
                replacingColor = new Vector4(100, 100, 100, 100);
            }
            
            foreach (SlotController slot in SlotsList)
            {
                Image[] imgList = GetComponentsInChildren<Image>();

                foreach (Image img in imgList)
                {
                    img.color = replacingColor;
                }
            }

            isInventoryShown = !isInventoryShown;
        }


        public void OnUse()
        {
            CurrentSlotSelected?.OnUse();
        }

        public void OnDrop(SlotController slot)
        {
<<<<<<< Updated upstream
            for (int i = 1; i < Slots.Count; i++)
            {
                if (Slots[i].DataItem != null)
                {
                    Slots[i].OnRemove();
                    nbOfItems--;
                    return;
                }
            }
=======
            // for (int i = 0; i < Slots.Count; i++)
            // {
            //     if (Slots[i].DataItem != null)
            //     {
            //         Slots[i].OnRemove();
            //         nbOfItems--;
            //         return;
            //     }
            // }
            
            slot.OnRemove();
            nbOfItems--;
>>>>>>> Stashed changes
        }

        public void RefreshUI(ItemData data = null)
        {
            foreach (SlotController item in SlotsList)
            {
                item.imgItem.sprite = item.DataItem.sprite;
            }
        }
    }
}