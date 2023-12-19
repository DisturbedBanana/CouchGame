using FFO.Inventory.Storage;
using JetBrains.Annotations;
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
    [Header("References")]
    [SerializeField] private GameObject _closestItemInRange;
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerInventory _playerInventory;
    private PlayerMovTest _playerMovement;
    private Character _player;

    [Space]
    [Header("Variables")]
    [SerializeField] private float _pickUpCooldown;
    [SerializeField] private Transform _playerTransform;
    private Transform itemTarget;
    private float _rotateToTargetSpeed = 2f;

    [Space]
    [Header("Lists")]
    [SerializeField] private List<GameObject> _objectsInRange = new List<GameObject>();

    [Space]
    [Header("Booleans")]
    [SerializeField] private bool _isPickingUp = false;
    [SerializeField] private bool _itemWasPickedUp = false;

    [Space]
    [Header("Items References")]
    [SerializeField] private GameObject _woodItem;
    [SerializeField] private GameObject _ironItem;
    [SerializeField] private GameObject _coalItem;

    private void Start()
    {
        _playerInventory = this.GetComponentInChildren<PlayerInventory>();
        _anim = this.GetComponentInParent<Animator>();
        _playerTransform = GetComponent<Transform>();
        _playerMovement = this.GetComponentInParent<PlayerMovTest>();
        _player = this.GetComponent<Character>();
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

    private IEnumerator RotateToTarget(Transform target, float speed)
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

        rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        float time = 0f;
        while (time < 1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, time);

            time += Time.deltaTime * speed;
            yield return null;
        }
    }

    private IEnumerator PickUpItem(GameObject item)
    {
        //ADD ITEM TO INVENTORY VIA REFERENCE TO PLAYER HERE
        //_playerInventory.AddItemToInventory(item.GetComponent<WorldItem>().Data.ID);
        _playerMovement.CanMove = false;

        Debug.Log("Grab");

        itemTarget = item.transform;
        StartCoroutine(RotateToTarget(itemTarget, _rotateToTargetSpeed));

        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            if (player.GetComponentInChildren<PickUp>()._objectsInRange.Contains(item))
            {
                
                player.GetComponentInChildren<PickUp>()._objectsInRange.Remove(item);
            }
        }

        _itemWasPickedUp = false;

        if (item.CompareTag("WoodItem"))
        {
            AddOneWoodToInventory(_player);
        }
        else if (item.CompareTag("CoalItem"))
        {
            AddOneCharcoalToInventory(_player);
        }
        if (item.CompareTag("IronItem"))
        {
            AddOneIronToInventory(_player);
        }

        yield return new WaitForSecondsRealtime(0.6f);
        
        if (_itemWasPickedUp)
        {
            Destroy(item);
        }

        _itemWasPickedUp = false;
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

        if (GetComponent<Character>().IsAlive == false)
        {
            return;
        }

        foreach (GameObject item in _objectsInRange)
        {
            if (item != _closestItemInRange)
            {
                item.gameObject.GetComponent<Outline>().enabled = false;
                //item.gameObject.GetComponentInChildren<Animator>().SetBool("isClosest", false);
            }
            else
            {
                item.gameObject.GetComponent<Outline>().enabled = true;
                //item.gameObject.GetComponentInChildren<Animator>().SetBool("isClosest", true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WoodItem") || other.CompareTag("CoalItem") || other.CompareTag("IronItem"))
        {
            _objectsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WoodItem") || other.CompareTag("CoalItem") || other.CompareTag("IronItem"))

        {
            if (_objectsInRange.Contains(other.gameObject))
            {
                foreach (GameObject item in _objectsInRange)
                {
                    item.gameObject.GetComponent<Outline>().enabled = false;
                }

                //other.GetComponentInChildren<Animator>().SetBool("isClosest", false);
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

    public void AddOneWoodToInventory(Character player)
    {
        if (player.NbWoods + player.NbCharcoals + player.NbIrons == player.NbMaximumItems)
        {
            return;
            Debug.Log("Too much items in inventory!");
        }

        _itemWasPickedUp = true;
        string woodValue;

        if (player.PlayerId == 1)
        {
            woodValue = UIManager.instance._lumberjackWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue++;
            UIManager.instance._lumberjackWoodValue.text = intWoodValue.ToString();
            player.NbWoods++;
        }
        else if (player.PlayerId == 2)
        {
            woodValue = UIManager.instance._scoutWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue++;
            UIManager.instance._scoutWoodValue.text = intWoodValue.ToString();
            player.NbWoods++;
        }
        else if (player.PlayerId == 3)
        {
            woodValue = UIManager.instance._shamanWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue++;
            UIManager.instance._shamanWoodValue.text = intWoodValue.ToString();
            player.NbWoods++;
        }
        else if (player.PlayerId == 4)
        {
            woodValue = UIManager.instance._engineerWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue++;
            UIManager.instance._engineerWoodValue.text = intWoodValue.ToString();
            player.NbWoods++;
        }
    }

    public void AddOneCharcoalToInventory(Character player)
    {
        if (player.NbWoods + player.NbCharcoals + player.NbIrons == player.NbMaximumItems)
        {
            return;
            Debug.Log("Too much items in inventory!");
        }

        _itemWasPickedUp = true;
        string coalValue;

        if (player.PlayerId == 1)
        {
            coalValue = UIManager.instance._lumberjackCoalValue.text;
            int intCoalValue = int.Parse(coalValue);

            intCoalValue++;
            UIManager.instance._lumberjackCoalValue.text = intCoalValue.ToString();
            player.NbCharcoals++;
        }
        else if (player.PlayerId == 2)
        {
            coalValue = UIManager.instance._scoutCoalValue.text;
            int intCoalValue = int.Parse(coalValue);

            intCoalValue++;
            UIManager.instance._scoutCoalValue.text = intCoalValue.ToString();
            player.NbCharcoals++;
        }
        else if (player.PlayerId == 3)
        {
            coalValue = UIManager.instance._shamanCoalValue.text;
            int intCoalValue = int.Parse(coalValue);

            intCoalValue++;
            UIManager.instance._shamanCoalValue.text = intCoalValue.ToString();
            player.NbCharcoals++;
        }
        else if (player.PlayerId == 4)
        {
            coalValue = UIManager.instance._engineerCoalValue.text;
            int intCoalValue = int.Parse(coalValue);

            intCoalValue++;
            UIManager.instance._engineerCoalValue.text = intCoalValue.ToString();
            player.NbCharcoals++;
        }
    }

    public void AddOneIronToInventory(Character player)
    {
        if (player.NbWoods + player.NbCharcoals + player.NbIrons == player.NbMaximumItems)
        {
            return;
            Debug.Log("Too much items in inventory!");
        }

        _itemWasPickedUp = true;
        string ironValue;

        if (player.PlayerId == 1)
        {
            ironValue = UIManager.instance._lumberjackIronValue.text;
            int intIronValue = int.Parse(ironValue);

            intIronValue++;
            UIManager.instance._lumberjackIronValue.text = intIronValue.ToString();
            player.NbIrons++;
        }
        else if (player.PlayerId == 2)
        {
            ironValue = UIManager.instance._scoutIronValue.text;
            int intIronValue = int.Parse(ironValue);

            intIronValue++;
            UIManager.instance._scoutIronValue.text = intIronValue.ToString();
            player.NbIrons++;
        }
        else if (player.PlayerId == 3)
        {
            ironValue = UIManager.instance._shamanIronValue.text;
            int intIronValue = int.Parse(ironValue);

            intIronValue++;
            UIManager.instance._shamanIronValue.text = intIronValue.ToString();
            player.NbIrons++;
        }
        else if (player.PlayerId == 4)
        {
            ironValue = UIManager.instance._engineerIronValue.text;
            int intIronValue = int.Parse(ironValue);

            intIronValue++;
            UIManager.instance._engineerIronValue.text = intIronValue.ToString();
            player.NbIrons++;
        }
    }
}
