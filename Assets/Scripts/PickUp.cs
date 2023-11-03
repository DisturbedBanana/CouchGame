using FFO.Inventory.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    [Header("Refenrences")]
    [SerializeField] private GameObject _closestItemInRange;
    [SerializeField] private Animator _anim;
    private PlayerInventory _playerInventory;
    private PlayerMovTest _playerMovement;

    [Space]
    [Header("Variables")]
    [SerializeField] private Vector3 _closestDistance = new Vector3(1000,1000,1000);
    [SerializeField] private float _pickUpCooldown;
    [SerializeField] private Transform _playerTransform;

    [Space]
    [Header("Lists")]
    [SerializeField] private List<GameObject> _objectsInRange = new List<GameObject>();

    [Space]
    [Header("Booleans")]
    [SerializeField] private bool _isPickingUp = false;

    private void Start()
    {
        _playerInventory = this.GetComponent<PlayerInventory>();
        _anim = this.GetComponentInParent<Animator>();
        _playerTransform = transform.root.GetComponent<Transform>();
        _playerMovement = this.GetComponentInParent<PlayerMovTest>();
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

    private IEnumerator PickUpItem(GameObject item)
    {
        //ADD ITEM TO INVENTORY VIA REFERENCE TO PLAYER HERE
        _playerInventory.AddItemToInventory(item.GetComponent<WorldItem>().itemData.ID);
        _playerMovement.CanMove = false;

        _playerTransform.LookAt(item.transform.position);
        //_playerTransform.LookAt(new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z));

        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            if (player.GetComponentInChildren<PickUp>()._objectsInRange.Contains(item))
            {
                
                player.GetComponentInChildren<PickUp>()._objectsInRange.Remove(item);
            }
        }

        Debug.Log("Start Wait");
        yield return new WaitForSecondsRealtime(0.6f);
        Debug.Log("Finished. Destroyed item");
        Destroy(item);
        _playerMovement.CanMove = true;
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
                item.gameObject.GetComponentInChildren<Animator>().SetBool("isClosest", false);
            }
            else
            {
                item.gameObject.GetComponent<Outline>().enabled = true;
                item.gameObject.GetComponentInChildren<Animator>().SetBool("isClosest", true);
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

                other.GetComponentInChildren<Animator>().SetBool("isClosest", false);
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
            if (_closestItemInRange != null)
            {
                _anim.SetTrigger("isPickingUp");
                _objectsInRange.Remove(_closestItemInRange);
                StartCoroutine(PickUpItem(_closestItemInRange));
            }
        }
        else
        {
            _isPickingUp = false;
        }
    }
}
