using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Revive : MonoBehaviour
{
    [Header("References")]
    public static Revive instance;
    [SerializeField] private GameObject _closestTombstoneInRange;
    [SerializeField] private Animator _anim;
    private PlayerMovTest _playerMovement;

    [Space]
    [Header("Variables")]
    [SerializeField] private Transform _playerTransform;
    private Transform tombstoneTarget;
    [SerializeField] private float _shamanReviveTime;

    [Space]
    [Header("Lists")]
    [SerializeField] private List<GameObject> _tombstonesInRange = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _anim = this.GetComponentInParent<Animator>();
        _playerMovement = GetComponent<PlayerMovTest>();
    }

    private void Update()
    {
        if (_closestTombstoneInRange == null)
        {
            _tombstonesInRange.Remove(_closestTombstoneInRange);
        }

        FindNearestItem();
        GlowNearestObject();

        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            for (int i = 0; i < _tombstonesInRange.Count; i++)
            {
                if (_tombstonesInRange[i] == null)
                {
                    _tombstonesInRange.Remove(_tombstonesInRange[i]);
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

    private IEnumerator RevivePlayer(GameObject tombstone)
    {
        _playerMovement.CanMove = false;

        //Temporary int for isAlive reattribution (set to 10 so it doesn't default to a certain player, going from 0 to 3)
        int playerIdTarget = 10; 

        tombstoneTarget = tombstone.transform;
        StartCoroutine(RotateToTarget(tombstoneTarget, 2f));
        _anim.SetTrigger("isReviving");

        Debug.Log("Is Reviving " + tombstone.name);

        yield return new WaitForSecondsRealtime(6f);

        switch(tombstone.GetComponent<Tombstone>().TombstoneId)
        {
            case 1:
                GameManager.instance._playerGameObjectList[tombstone.GetComponent<Tombstone>().TombstoneId - 1].GetComponentInChildren<SkinnedMeshRenderer>().materials = HeatManager.instance._lumberjackMats;
                playerIdTarget = 1;
                Debug.Log("Lumberjack has been revived");
                break;
            case 2:
                GameManager.instance._playerGameObjectList[tombstone.GetComponent<Tombstone>().TombstoneId - 1].GetComponentInChildren<SkinnedMeshRenderer>().material = HeatManager.instance._scoutMat;
                playerIdTarget = 2;
                Debug.Log("Scout has been revived");
                break;
            case 3:
                
                playerIdTarget = 3;
                Debug.Log("Shaman has been revived");
                break;
            case 4:
                GameManager.instance._playerGameObjectList[tombstone.GetComponent<Tombstone>().TombstoneId - 1].GetComponentInChildren<SkinnedMeshRenderer>().material = HeatManager.instance._engineerMat;
                playerIdTarget = 4;
                Debug.Log("Engineer has been revived");
                break;
        }

        GameManager.instance._playerGameObjectList[playerIdTarget - 1].GetComponent<PlayerMovTest>().SwitchActionMap("Controller");
        GameManager.instance._playerGameObjectList[playerIdTarget - 1].GetComponent<Character>().IsAlive = true;
        GameManager.instance._playerGameObjectList[playerIdTarget - 1].GetComponent<Transform>().transform.position = new Vector3(2f, 1f, 2f);
        GameManager.instance._playerGameObjectList[playerIdTarget - 1].GetComponent<Character>().Heat = 100f;
        GameManager.instance._playerGameObjectList[playerIdTarget - 1].GetComponent<Character>().MoveSpeed = 7f;

        Destroy(tombstone);
        _playerMovement.CanMove = true;

        HeatManager.instance._deadPlayers -= 1;
    }

    public IEnumerator ReviveShaman()
    {
        Debug.Log("est entré dans la coroutine");
        yield return new WaitForSecondsRealtime(_shamanReviveTime);
        GameManager.instance._playerGameObjectList[2].GetComponentInChildren<SkinnedMeshRenderer>().materials = HeatManager.instance._shamanMats;

        GameManager.instance._playerGameObjectList[2].GetComponent<PlayerMovTest>().SwitchActionMap("Controller");
        GameManager.instance._playerGameObjectList[2].GetComponent<Character>().IsAlive = true;
        GameManager.instance._playerGameObjectList[2].GetComponent<Transform>().transform.position = new Vector3(2f, 1f, 2f);
        GameManager.instance._playerGameObjectList[2].GetComponent<Character>().Heat = 100f;
        GameManager.instance._playerGameObjectList[2].GetComponent<Character>().MoveSpeed = 7f;

        GameObject shamanTombstone = GameObject.FindGameObjectWithTag("ShamanTombstone");
        Destroy(shamanTombstone);

        HeatManager.instance._shamanIsDead = false;
    }

    private void FindNearestItem()
    {
        if (_tombstonesInRange.Count == 0)
        {
            _closestTombstoneInRange = null;
        }
        else
        {
            for (int i = 0; i < _tombstonesInRange.Count; i++)
            {
                if (_closestTombstoneInRange == null)
                {
                    _closestTombstoneInRange = _tombstonesInRange[i];
                }

                if (Vector3.Distance(transform.position, _closestTombstoneInRange.transform.position) > Vector3.Distance(transform.position, _tombstonesInRange[i].transform.position))
                {
                    _closestTombstoneInRange = _tombstonesInRange[i];
                }
            }
        }
    }

    private void GlowNearestObject()
    {
        if (GetComponent<Character>().IsAlive == false)
        {
            return;
        }

        foreach (GameObject item in _tombstonesInRange)
        {
            if (item != _closestTombstoneInRange)
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
        if (other.CompareTag("Tombstone"))
        {
            _tombstonesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tombstone"))

        {
            if (_tombstonesInRange.Contains(other.gameObject))
            {
                foreach (GameObject item in _tombstonesInRange)
                {
                    item.gameObject.GetComponent<Outline>().enabled = false;
                }

                //VARIABLE A CHANGER SI ON FAIT UNE ANIM POP UP AU DESSUS POUR DIRE "REVIVE"
                //other.GetComponentInChildren<Animator>().SetBool("isClosest", false);
                _tombstonesInRange.Remove(other.gameObject);
                _closestTombstoneInRange = null;
            }
        }
    }

    public void OnRevive(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_closestTombstoneInRange != null)
            {
                _anim.SetTrigger("isReviving");
                _tombstonesInRange.Remove(_closestTombstoneInRange);
                StartCoroutine(RevivePlayer(_closestTombstoneInRange));
            }
        }
    }
}
