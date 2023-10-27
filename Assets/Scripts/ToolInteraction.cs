using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolInteraction : MonoBehaviour
{
    PlayerInventory _playerInv;
    [SerializeField] private List<GameObject> _breakableObjects = new List<GameObject>();
    Animator _anim;


    private void Awake()
    {
        _playerInv = GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            _breakableObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            _breakableObjects.Remove(other.gameObject);
        }
    }

    public void OnTool(InputAction.CallbackContext context)
    {
        if (_breakableObjects.Count != 0)
        {
            _anim = _breakableObjects[0].GetComponent<Animator>();
            StartCoroutine(CuttingAnim());
            _playerInv.AddItemToInventory(_breakableObjects[0].GetComponent<WorldItem>().itemData.ID);
        }
    }

    IEnumerator CuttingAnim()
    {
        _anim.SetBool("isCut", true);
        yield return new WaitForSecondsRealtime(3f);
        GameObject objToDestroy = _breakableObjects[0];
        _breakableObjects.Remove(_breakableObjects[0]);
        Destroy(objToDestroy);
    }
}
