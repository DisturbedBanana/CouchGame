using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolInteraction : MonoBehaviour
{
    PlayerInventory _playerInv;
    bool _isInRange = false;
    private GameObject _closestBreakableObj;
    private List<GameObject> _breakableObjects = new List<GameObject>();
    [SerializeField] GameObject _treeInRange;
    Animator _anim;


    private void Awake()
    {
        _playerInv = GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            Debug.Log(other);
            _isInRange = true;
            _treeInRange = null;
            _treeInRange = other.gameObject;
            _anim = other.GetComponent<Animator>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            _isInRange = false;
            _treeInRange = null;
            _anim = null;
        }
    }

    public void OnTool(InputAction.CallbackContext context)
    {
        if (_isInRange)
        {
            _isInRange = false;
            StartCoroutine(CuttingAnim());
            _playerInv.AddItemToInventory("Woo_NONE");
        }
    }

    IEnumerator CuttingAnim()
    {
        _anim.SetBool("isCut", true);
        yield return new WaitForSecondsRealtime(3f);
        Destroy(_treeInRange.gameObject);
    }
}
