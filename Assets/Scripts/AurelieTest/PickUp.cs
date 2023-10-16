using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsInRange = new List<GameObject>();
    [SerializeField] private bool _canPickUp = true;
    [SerializeField] private bool _isPickingUp = false;
    [SerializeField] private float _pickUpCooldown;
    [SerializeField] private Vector3 _closestDistance = new Vector3(1000,1000,1000);
    [SerializeField] private GameObject _closestItemInRange;

    [SerializeField] private GameObject _player;

    private float _pickUpCooldownTimer;
    [SerializeField] private float _pickUpTime;
    [SerializeField] private float _pickUpTimer;

    private void Start()
    {
        _pickUpCooldownTimer = _pickUpCooldown;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        FindNearestItem();
        GlowNearestObject();
    }

    private void PickUpItem(GameObject item)
    {
        GetComponent<Inventory>().Additem("red", Color.red);
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

                if (Vector3.Distance(_player.transform.position, _closestItemInRange.transform.position) > Vector3.Distance(_player.transform.position, _objectsInRange[i].transform.position))
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
            Debug.Log("Lucas");
            _objectsInRange.Add(other.gameObject);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))

        {
            Debug.Log("Pas Lucas");
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
            PickUpItem(_closestItemInRange);
        }
        else
        {
            _isPickingUp = false;
        }
    }

    private void PickUpObject(GameObject gameObject)
    {
        // add item inventaire
        _canPickUp = false;
        _pickUpTimer = 0f;
        //Debug.Log("picked up");
    }
}
