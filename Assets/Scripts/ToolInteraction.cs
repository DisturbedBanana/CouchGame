using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolInteraction : MonoBehaviour
{
    PlayerInventory _playerInv;
    [SerializeField] private List<GameObject> _breakableObjectsInRange = new List<GameObject>();
    Animator _anim;


    private void Awake()
    {
        _playerInv = GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            _breakableObjectsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            _breakableObjectsInRange.Remove(other.gameObject);
        }
    }

    public void OnTool(InputAction.CallbackContext context)
    {
        Debug.Log("veut taper");
        if (_breakableObjectsInRange.Count != 0)
        {
            Debug.Log("est en train de taper");
            _anim = _breakableObjectsInRange[0].GetComponent<Animator>();
            StartCoroutine(CuttingAnim());
            _playerInv.AddItemToInventory(_breakableObjectsInRange[0].GetComponent<WorldItem>().itemData.ID);
        }
    }

    IEnumerator CuttingAnim()
    {
        _anim.SetBool("isCut", true);
        yield return new WaitForSecondsRealtime(3f);
        GameObject objToDestroy = _breakableObjectsInRange[0];
        _breakableObjectsInRange.Remove(_breakableObjectsInRange[0]);
        Destroy(objToDestroy);
    }
}
