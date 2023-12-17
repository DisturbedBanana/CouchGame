using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using TMPro;

public class ToolInteraction : MonoBehaviour
{
    [Space]
    [Header("References")]
    PlayerInventory _playerInv;
    Animator _treeAnim;
    Animator _playerAnim;
    private PlayerMovTest _playerMovement;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Character _playerClass;

    [Space]
    [Header("Tree variables")]
    [SerializeField] private List<GameObject> _treesObjectsInRange = new List<GameObject>();
    [SerializeField] private GameObject _closestTreeInRange;
    [SerializeField] private bool _canUseAxe = true;
    [SerializeField] private bool _canChop = true;
    [SerializeField] private int _woodDropChance;


    [Space]
    [Header("Iron variables")]
    [SerializeField] private List<GameObject> _ironsObjectsInRange = new List<GameObject>();
    [SerializeField] private GameObject _closestIronInRange;
    [SerializeField] private bool _canUsePickaxe = true;
    [SerializeField] private bool _canMine = true;

    [Space]
    [Header("Charcoal variables")]
    [SerializeField] private List<GameObject> _charcoalsObjectsInRange = new List<GameObject>();
    [SerializeField] private GameObject _closestCharcoalInRange;

    [Space]
    [Header("Overall object variable")]
    [SerializeField] private List<GameObject> _allObjectsInRange = new List<GameObject>();
    [SerializeField] private GameObject _closestObjectInRange;

    [Space]
    [Header("Look at variables")]
    private bool _rotationFinished = true;
    [SerializeField] private float _time = 0f;

    [Space]
    [Header("Tools")]
    [SerializeField] private GameObject _axe;
    //[SerializeField] private GameObject _pickaxe;
    //[SerializeField] private GameObject _hammer;

    private void Awake()
    {
        _playerInv = GetComponent<PlayerInventory>();
        _playerAnim = GetComponentInParent<Animator>();
        _playerMovement = GetComponentInParent<PlayerMovTest>();

        _playerClass = GetComponentInParent<Character>();
    }

    private void Start()
    {
        _axe.SetActive(false);
        //_pickaxe.SetActive(false);
        //_hammer.SetActive(false);
    }

    private void Update()
    {
        FindNearestTree();
        FindNearestObject();

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

        if (_closestObjectInRange == null)
        {
            _allObjectsInRange.Remove(_closestObjectInRange);
        }

        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            for (int i = 0; i < _allObjectsInRange.Count; i++)
            {
                if (_allObjectsInRange[i] == null)
                {
                    _allObjectsInRange.Remove(_allObjectsInRange[i]);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger) return;

        if (other.CompareTag("Tree"))
        {
            _treesObjectsInRange.Add(other.gameObject);
            _allObjectsInRange.Add(other.gameObject);
        }
        else if (other.CompareTag("Iron"))
        {
            _ironsObjectsInRange.Add(other.gameObject);
            _allObjectsInRange.Add(other.gameObject);
        }
        else if (other.CompareTag("Charcoal"))
        {
            _charcoalsObjectsInRange.Add(other.gameObject);
            _allObjectsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger) return;

        if (other.CompareTag("Tree"))

        {
            if (_treesObjectsInRange.Contains(other.gameObject))
            {
                _treesObjectsInRange.Remove(other.gameObject);
                _closestTreeInRange = null;
                _allObjectsInRange.Remove(other.gameObject);
                _closestObjectInRange = null;
            }
        }
        else if (other.CompareTag("Iron"))
        {
            if (_ironsObjectsInRange.Contains(other.gameObject))
            {
                _ironsObjectsInRange.Remove(other.gameObject);
                _closestIronInRange = null;
                _allObjectsInRange.Remove(other.gameObject);
                _closestObjectInRange = null;
            }
        }
        else if (other.CompareTag("Charcoal"))
        {
            if (_charcoalsObjectsInRange.Contains(other.gameObject))
            {
                _charcoalsObjectsInRange.Remove(other.gameObject);
                _closestCharcoalInRange = null;
                _allObjectsInRange.Remove(other.gameObject);
                _closestObjectInRange = null;
            }
        }
    }

    public void OnToolInteraction(InputAction.CallbackContext context)
    {
        Debug.Log("Tool Intreaction");

        //TREE
        if (context.performed && _closestObjectInRange.CompareTag("Tree"))
        {
            Debug.Log("Tree");
            if (_playerClass.IsInSnow && _playerClass.PlayerId != 1)
            {
                Debug.Log("Player isn't the lumberjack, so can't cut trees in snow");
                return;
            }

            if (_treesObjectsInRange.Count != 0 && _canUseAxe && _canChop)
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
            }
        }
        //IRON
        else if (context.performed && _closestObjectInRange.CompareTag("Iron"))
        {
            Debug.Log("Iron");

        }
    }

    private void FindNearestObject()
    {
        if (_allObjectsInRange.Count == 0)
        {
            _closestObjectInRange = null;
        }
        else
        {
            for (int i = 0; i < _allObjectsInRange.Count; i++)
            {
                if (_closestObjectInRange == null)
                {
                    _closestObjectInRange = _allObjectsInRange[i];
                }

                if (Vector3.Distance(transform.position, _closestObjectInRange.transform.position) > Vector3.Distance(transform.position, _allObjectsInRange[i].transform.position))
                {
                    _closestObjectInRange = _allObjectsInRange[i];
                }
                else
                {
                    return;
                }
            }
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

        _axe.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);

        _treeAnim.SetTrigger("isCut");

        if (_playerClass.PlayerId == 1 || _playerClass.PlayerId == 2)
        {
            yield return new WaitForSecondsRealtime(2.6f);
        }
        else if (_playerClass.PlayerId == 3 || _playerClass.PlayerId == 4)
        {
            yield return new WaitForSecondsRealtime(3.7f);
        }

        _axe.SetActive(false);

        #region Adding wood to player inventory
        //GIVE ITEM TO PLAYER
        string woodValue;

        if (_playerClass.PlayerId == 1)
        {
            woodValue = UIManager.instance._lumberjackWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            if (intWoodValue < _playerClass.NbMaximumItems)
            {
                int dropChance = UnityEngine.Random.Range(0, 100);
                Debug.Log(dropChance);
                if (dropChance <= _woodDropChance)
                {
                    intWoodValue++;
                    UIManager.instance._lumberjackWoodValue.text = intWoodValue.ToString();
                    _playerClass.NbWoods++;
                }
            }
        }
        else if (_playerClass.PlayerId == 2)
        {
            woodValue = UIManager.instance._scoutWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            if (intWoodValue < _playerClass.NbMaximumItems)
            {
                int dropChance = UnityEngine.Random.Range(0, 100);
                Debug.Log(dropChance);
                if (dropChance <= _woodDropChance)
                {
                    intWoodValue++;
                    UIManager.instance._scoutWoodValue.text = intWoodValue.ToString();
                    _playerClass.NbWoods++;
                }
            }
        }
        else if (_playerClass.PlayerId == 3)
        {
            woodValue = UIManager.instance._shamanWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            if (intWoodValue < _playerClass.NbMaximumItems)
            {
                int dropChance = UnityEngine.Random.Range(0, 100);
                Debug.Log(dropChance);
                if (dropChance <= _woodDropChance)
                {
                    intWoodValue++;
                    UIManager.instance._shamanWoodValue.text = intWoodValue.ToString();
                    _playerClass.NbWoods++;
                }
            }
        }
        else if (_playerClass.PlayerId == 4)
        {
            woodValue = UIManager.instance._engineerWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            if (intWoodValue < _playerClass.NbMaximumItems)
            {
                int dropChance = UnityEngine.Random.Range(0, 100);
                Debug.Log(dropChance);
                if (dropChance <= _woodDropChance)
                {
                    intWoodValue++;
                    UIManager.instance._engineerWoodValue.text = intWoodValue.ToString();
                    _playerClass.NbWoods++;
                }
            }
        }
        #endregion

        _playerMovement.CanMove = true;
        _canUseAxe = true;

        yield return new WaitForSecondsRealtime(1f);

        Destroy(objToDestroy);
        _allObjectsInRange.Remove(_closestTreeInRange);
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
