using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class HeatManager : MonoBehaviour
{
    public static HeatManager instance;

    [Space]
    [Header("Heat Sliders")]
    [SerializeField] private Slider _lumberjackHeatSlider;
    [SerializeField] private Slider _scoutHeatSlider;
    [SerializeField] private Slider _shamanjackHeatSlider;
    [SerializeField] private Slider _engineerjackHeatSlider;

    [Space]
    [Header("Tombstones variables")]
    [SerializeField] private List<GameObject> _tombstones = new List<GameObject>();
    private Vector3 _playerDeathPosition;

    [Space]
    [Header("Heat Decrease variables")]
    [Range(0.01f, 3.0f)]
    public float _lumberjackDecreaser;
    [Range(0.01f, 3.0f)]
    public float _scoutDecreaser;
    [Range(0.01f, 3.0f)]
    public float _shamanDecreaser;
    [Range(0.01f, 3.0f)]
    public float _engineerDecreaser;

    [Space]
    [Header("Heat Increase variables")]
    [Range(0.1f, 3.0f)]
    [SerializeField] private float _lumberjackIncreaser;
    [Range(0.1f, 3.0f)]
    [SerializeField] private float _scoutIncreaser;
    [Range(0.1f, 3.0f)]
    [SerializeField] private float _shamanIncreaser;
    [Range(0.1f, 3.0f)]
    [SerializeField] private float _engineerIncreaser;

    [Space]
    [Header("Player Materials")]
    public Material[] _lumberjackMats;
    public Material _scoutMat;
    public Material[] _shamanMats;
    public Material _engineerMat;

    [SerializeField] private Material[] _oneTextureDeadMats;
    [SerializeField] private Material[] _twoTexturesDeadMats;

    [Space]
    [Header("Player Variables")]
    [SerializeField] private float _deathSpeed;

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

    private void FixedUpdate()
    {
        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            if (!player.GetComponent<Character>().IsInSnow && player.GetComponent<Character>().Heat <= 100.0f && player.GetComponent<Character>().IsAlive)
            {
                switch (player.gameObject.GetComponent<Character>().PlayerId)
                {
                    case 1:
                        player.gameObject.GetComponent<Character>().Heat += _lumberjackIncreaser;
                        _lumberjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 2:
                        player.gameObject.GetComponent<Character>().Heat += _scoutIncreaser;
                        _scoutHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 3:
                        player.gameObject.GetComponent<Character>().Heat += _shamanIncreaser;
                        _shamanjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 4:
                        player.gameObject.GetComponent<Character>().Heat += _engineerIncreaser;
                        _engineerjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    default:
                        break;
                }
            }

            if (player.GetComponent<Character>().IsInSnow && player.GetComponent<Character>().Heat >= 0)
            {
                switch (player.gameObject.GetComponent<Character>().PlayerId)
                {
                    case 1:
                        player.gameObject.GetComponent<Character>().Heat -= _lumberjackDecreaser;
                        _lumberjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 2:
                        player.gameObject.GetComponent<Character>().Heat -= _scoutDecreaser;
                        _scoutHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 3:
                        player.gameObject.GetComponent<Character>().Heat -= _shamanDecreaser;
                        _shamanjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 4:
                        player.gameObject.GetComponent<Character>().Heat -= _engineerDecreaser;
                        _engineerjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    default:
                        break;
                }
            }

            if (player.GetComponent<Character>().Heat <= 0 && player.GetComponent<Character>().IsAlive)
            {
                _playerDeathPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

                switch (player.gameObject.GetComponent<Character>().PlayerId)
                {
                    case 1:
                        player.GetComponent<Character>().IsAlive = false;
                        StartCoroutine(PlaceTombstone(1, _playerDeathPosition));
                        break;
                    case 2:
                        player.GetComponent<Character>().IsAlive = false;
                        StartCoroutine(PlaceTombstone(2, _playerDeathPosition));
                        break;
                    case 3:
                        player.GetComponent<Character>().IsAlive = false;
                        StartCoroutine(PlaceTombstone(3, _playerDeathPosition));
                        break;
                    case 4:
                        player.GetComponent<Character>().IsAlive = false;
                        StartCoroutine(PlaceTombstone(4, _playerDeathPosition));
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void DeathAnimation(int playerId)
    {
        GameManager.instance._playerGameObjectList[playerId - 1].GetComponent<PlayerMovTest>().CanMove = false;
        GameManager.instance._playerGameObjectList[playerId - 1].GetComponent<Animator>().SetTrigger("isDead");
    }

    private IEnumerator PlaceTombstone(int playerId, Vector3 tombstonePosition)
    {
        DeathAnimation(playerId);

        yield return new WaitForSecondsRealtime(5f);

        //Instantiates the player's tombstone where he died
        Instantiate(_tombstones[playerId - 1], tombstonePosition, Quaternion.AngleAxis(45f, Vector3.up));
        Debug.Log("A tombstone was placed for the " + GameManager.instance._playerGameObjectList[playerId - 1]);

        //Changes the action map to the dead one so the player can't interact anymore
        GameManager.instance._playerGameObjectList[playerId - 1].GetComponent<PlayerMovTest>().SwitchActionMap("Dead");

        //Changes the to the dead transparent material of the player
        //GameManager.instance._playerGameObjectList[playerId - 1].GetComponentInChildren<SkinnedMeshRenderer>().material = _deadMat;

        if (playerId == 1 || playerId == 3)
        {
            GameManager.instance._playerGameObjectList[playerId - 1].GetComponentInChildren<SkinnedMeshRenderer>().materials = _twoTexturesDeadMats;
        }
        else if (playerId == 2 || playerId == 4)
        {
            GameManager.instance._playerGameObjectList[playerId - 1].GetComponentInChildren<SkinnedMeshRenderer>().materials = _oneTextureDeadMats;
        }

        GameManager.instance._playerGameObjectList[playerId - 1].GetComponent<PlayerMovTest>().CanMove = true;
        GameManager.instance._playerGameObjectList[playerId - 1].GetComponent<Character>().MoveSpeed = _deathSpeed;

        if (playerId == 3)
        {
            Debug.Log("ouais");
            Revive.instance.StartCoroutine(Revive.instance.ReviveShaman());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<Character>().PlayerId != 2)
            {
                other.gameObject.GetComponent<Character>().MoveSpeed = 6f;
            }
            
            other.gameObject.GetComponent<Character>().IsInSnow = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Character>().MoveSpeed = 8f;
            other.gameObject.GetComponent<Character>().IsInSnow = false;
        }
    }
}
