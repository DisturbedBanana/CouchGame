using FFO.Inventory.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsInRange = new List<GameObject>();
    [SerializeField] private bool _isPickingUp = false;
    [SerializeField] private float _pickUpCooldown;
    [SerializeField] private Vector3 _closestDistance = new Vector3(1000,1000,1000);
    [SerializeField] private GameObject _closestItemInRange;

    //[SerializeField] private GameObject _player;
    private PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = this.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(_closestItemInRange);
            PickUpItem(_closestItemInRange);
        }

        if (_closestItemInRange == null)
        {
            _objectsInRange.Remove(_closestItemInRange);
        }

        FindNearestItem();
        GlowNearestObject();

        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            for (int i = 0; i < _objectsInRange.Count; i++)
            {
                if (_objectsInRange[i] == null)
                {
                    _objectsInRange.Remove(_objectsInRange[i]);
                }
            }
        }
    }

    private void PickUpItem(GameObject item)
    {
        //ADD ITEM TO INVENTORY VIA REFERENCE TO PLAYER HERE
        Debug.Log(item);
        _playerInventory.AddItemToInventory(item.GetComponent<WorldItem>().itemData.ID);

        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            if (player.GetComponentInChildren<PickUp>()._objectsInRange.Contains(item))
            {
                player.GetComponentInChildren<PickUp>()._objectsInRange.Remove(item);
            }
        }

        Destroy(item);
    }

    private void FindNearestItem()
    {
        if (_objectsInRange.Count == 0)
        {
            _closestItemInRange = null;
        }
        else
        {
            for (int i = 0; i < _objectsInRange.Count; i++)
            {
                if (_closestItemInRange == null)
                {
                    _closestItemInRange = _objectsInRange[i];
                }

                if (Vector3.Distance(transform.position, _closestItemInRange.transform.position) > Vector3.Distance(transform.position, _objectsInRange[i].transform.position))
                {
                    _closestItemInRange = _objectsInRange[i];
                }
            }
        }
    }

    private void GlowNearestObject()
    {
        //if (_closestItemInRange != null)
        //{
        //    _closestItemInRange.gameObject.GetComponent<Outline>().enabled = true;
        //    Debug.Log(_closestItemInRange);
        //}

        foreach (GameObject item in _objectsInRange)
        {
            if (item != _closestItemInRange)
            {
                item.gameObject.GetComponent<Outline>().enabled = false;
            }
            else
            {
                item.gameObject.GetComponent<Outline>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            _objectsInRange.Add(other.gameObject);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))

        {
            if (_objectsInRange.Contains(other.gameObject))
            {
                foreach (GameObject item in _objectsInRange)
                {
                    item.gameObject.GetComponent<Outline>().enabled = false;
                }

                _objectsInRange.Remove(other.gameObject);
                _closestItemInRange = null;
            }
        }
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isPickingUp = true;
            _objectsInRange.Remove(_closestItemInRange);
            Debug.Log(_closestItemInRange);
            PickUpItem(_closestItemInRange);
        }
        else
        {
            _isPickingUp = false;
        }
    }
}
