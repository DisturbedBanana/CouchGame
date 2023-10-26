using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolInteraction : MonoBehaviour
{
    PlayerInventory _playerInv;
    bool _isInRange = false;
    GameObject _treeInRange;


    private void Awake()
    {
        _playerInv = GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            Debug.Log("tree detected");
            _isInRange = true;
            _treeInRange = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            _isInRange = false;
            _treeInRange = null;
        }
    }

    public void OnTool(InputAction.CallbackContext context)
    {
        Debug.Log("attack");
        if (_isInRange)
        {
            _isInRange = false;
            Debug.Log("is in range");
            Destroy(_treeInRange.gameObject);
            _playerInv.AddItemToInventory("Woo_NONE");
        }
    }
}
