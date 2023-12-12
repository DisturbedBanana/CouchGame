using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolInteraction : MonoBehaviour
{
    PlayerInventory _playerInv;
    [SerializeField] private List<GameObject> _treesObjectsInRange = new List<GameObject>();
    [SerializeField] private GameObject _closestTreeInRange;
    Animator _treeAnim;
    Animator _playerAnim;
    [SerializeField] private bool _canUseAxe = true;
    [SerializeField] private bool _canChop = true;
    private PlayerMovTest _playerMovement;
    [SerializeField] private Transform _playerTransform;
    private bool _rotationFinished = true;
    [SerializeField] private float _time = 0f;

    [SerializeField] private Character _playerClass;


    private void Awake()
    {
        _playerInv = GetComponent<PlayerInventory>();
        _playerAnim = GetComponentInParent<Animator>();
        _playerMovement = GetComponentInParent<PlayerMovTest>();

        _playerClass = GetComponentInParent<Character>();
    }

    private void Update()
    {
        FindNearestTree();

        if (_closestTreeInRange == null)
        {
            _treesObjectsInRange.Remove(_closestTreeInRange);
        }

        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            for (int i = 0; i < _treesObjectsInRange.Count; i++)
            {
                if (_treesObjectsInRange[i] == null)
                {
                    _treesObjectsInRange.Remove(_treesObjectsInRange[i]);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            _treesObjectsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))

        {
            if (_treesObjectsInRange.Contains(other.gameObject))
            {
                _treesObjectsInRange.Remove(other.gameObject);
                _closestTreeInRange = null;
            }
        }
    }

    public void OnAxe(InputAction.CallbackContext context)
    {
        if (_playerClass.IsInSnow && _playerClass.PlayerId != 1)
        {
            Debug.Log("Player isn't the lumberjack, so can't cut trees in snow");
            return;
        }

        Debug.Log("entered chop");

        if (_treesObjectsInRange.Count != 0 && _canUseAxe && !GameManager._gamePaused && _canChop)
        {
            Debug.Log("chopping");
            _playerMovement.CanMove = false;
            _canUseAxe = false;
            _canChop = false;

            _treeAnim = _closestTreeInRange.GetComponent<Animator>();

            Transform treeTarget = _closestTreeInRange.transform;

            StartCoroutine(RotateToTarget(treeTarget, 2f));

            _playerAnim.SetTrigger("cutsTree");
            StartCoroutine(CuttingAnim());

            _playerInv.AddItemToInventory(_treesObjectsInRange[0].GetComponent<WorldItem>().Data.ID);
        }
    }

    private void FindNearestTree()
    {
        if (_treesObjectsInRange.Count == 0)
        {
            _closestTreeInRange = null;
        }
        else
        {
            for (int i = 0; i < _treesObjectsInRange.Count; i++)
            {
                if (_closestTreeInRange == null)
                {
                    _closestTreeInRange = _treesObjectsInRange[i];
                }

                if (Vector3.Distance(transform.position, _closestTreeInRange.transform.position) > Vector3.Distance(transform.position, _treesObjectsInRange[i].transform.position))
                {
                    _closestTreeInRange = _treesObjectsInRange[i];
                }
                else
                {
                    return;
                }
            }
        }
    }

    IEnumerator CuttingAnim()
    {
        GameObject objToDestroy = _treesObjectsInRange[0];
        yield return new WaitForSecondsRealtime(2f);

        _treeAnim.SetTrigger("isCut");
        yield return new WaitForSecondsRealtime(2.5f);

        _playerMovement.CanMove = true;
        _canUseAxe = true;

        yield return new WaitForSecondsRealtime(1f);

        Destroy(objToDestroy);
        _treesObjectsInRange.Remove(_closestTreeInRange);
        _canChop = true;
    }

    private IEnumerator RotateToTarget(Transform target, float speed)
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - _playerTransform.position);

        rotation = Quaternion.Euler(_playerTransform.rotation.eulerAngles.x, rotation.eulerAngles.y, _playerTransform.rotation.eulerAngles.z);

        _time = 0f;
        while (_time < 1f)
        {
            _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, rotation, _time);

            _time += Time.deltaTime * speed;
            yield return null;
        }
    }
}
