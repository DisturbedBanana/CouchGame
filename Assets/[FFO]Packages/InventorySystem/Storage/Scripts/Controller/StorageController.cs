using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UIElements.Toggle;

namespace FFO.Inventory.Storage
{
    public class StorageController : MonoBehaviour
    {
        public ItemData item;
        public SlotController CurrentSlotSelected { get; set; }

        [Header("GD PAS TOUCHER")]
        [SerializeField] private GameObject _parentSlot;
        [SerializeField] private GameObject _prefabSlot;
        [SerializeField] private Camera _cam;
        [SerializeField] private GameObject _player;
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private bool _followPlayer = false;
        
        [Header("GD PEUT TOUCHER")]
        [SerializeField] private int _nbInvSlot;
        [SerializeField] private float _invOffset = 1.8f;

        private RectTransform _myRectTransform;
        private int _nbOfItems = 0;

        private bool _isOpened = false;
        private float _elapsedTime = 0f;
        private SlotController _selectedSlot;
        private int _selectedSlotIndex = 0;
        private IEnumerator _fadeInCoroutine;
        private IEnumerator _fadeOutCoroutine;
        private CanvasGroup _canvasGroup;
        

        [SerializeField] public List<SlotController> Slots { get; private set; }

        public void Start()
        {
            _myRectTransform = GetComponent<RectTransform>();
            
            Slots = new();
            for (int i = 0; i < _nbInvSlot; i++)
            {
                SlotController newSlot = Instantiate(_prefabSlot, _parentSlot.transform).GetComponent<SlotController>();
                Slots.Add(newSlot);
            }

            _selectedSlot = Slots[0];
            _selectedSlot._selectImage.color = Color.yellow;

            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                AddItem(item);
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                OnDrop();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveSlot();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveSlot(true);
            }
            

            if (_followPlayer)
            {
                _myRectTransform.position = _cam.WorldToScreenPoint(_player.transform.position + new Vector3(_invOffset,0,0));
            }
        }

        private void MoveSlot(bool isGoingUp = false)
        {
            if (isGoingUp)
            {
                if (_selectedSlotIndex - 1 >= 0)
                {
                    _selectedSlotIndex--;
                    UpdateSelectedSlot();
                }
            }
            else
            {
                if (_selectedSlotIndex + 1 <= Slots.Count - 1)
                {
                    _selectedSlotIndex++;
                    UpdateSelectedSlot();
                }
            }
            
            OpenInventory();
        }

        private void UpdateSelectedSlot()
        {
            _selectedSlot._selectImage.color = Color.white;
            _selectedSlot = Slots[_selectedSlotIndex];
            _selectedSlot._selectImage.color = Color.yellow;
        }

        private void OpenInventory()
        {
            if (_fadeInCoroutine == null && _fadeOutCoroutine == null)
            {
                _fadeInCoroutine = Fadein(true, true);
                StartCoroutine(_fadeInCoroutine);
            }
            else
            {
                if (_fadeOutCoroutine != null)
                {
                    StopCoroutine(_fadeOutCoroutine);
                    _fadeOutCoroutine = null;
                    _fadeInCoroutine = Fadein(true, true);
                    StartCoroutine(_fadeInCoroutine);
                }
                
                _elapsedTime = 0;
            }
        }

        public void AddItem(ItemData item)
        {
            if (_nbOfItems < 5)
            {
                for (int i = 0; i < Slots.Count; i++)
                {
                    if (Slots[i].DataItem == default || Slots[i].DataItem == null)
                    {
                        Slots[i].OnAdd(item);
                        _nbOfItems++;
                        Slots[i].DataItem.color = Color.clear;
                        OpenInventory();
                        return;
                    }
                }
            }
            
            OpenInventory();
        }

        public void OnUse()
        {
            CurrentSlotSelected?.OnUse();
        }

        public void OnDrop()
        {
            if (!_isOpened)
            {
                OpenInventory();
            }
            else
            {
                _elapsedTime = 0;
                if (_selectedSlot.DataItem != null)
                {
                    _selectedSlot.OnRemove();
                }
            }
        }

        private IEnumerator Fadein(bool doesFadein = true, bool fadeAgain = false)
        {
            float targetAlpha = 1;
            Color initialColor = Color.clear;
            Color targetColor = Color.white;
            _isOpened = true;
            
            if (!doesFadein)
            {
                targetAlpha = 0;
                _isOpened = false;
            }

            _elapsedTime = 0f;

            while (_elapsedTime < 1f)
            {
                _elapsedTime += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, targetAlpha, _elapsedTime / 1f);
                yield return null;
            }

            if (fadeAgain)
            {
                StartCoroutine(WaitToFadeAgainCoroutine());
            }
            else
            {
                _fadeInCoroutine = null;
                _fadeOutCoroutine = null;
            }
            
            
        }

        private IEnumerator WaitToFadeAgainCoroutine()
        {
            yield return new WaitForSeconds(2f);
            _fadeOutCoroutine = Fadein(false);
            StartCoroutine(_fadeOutCoroutine);
            Debug.Log("other coroutine");
        }
    }
}