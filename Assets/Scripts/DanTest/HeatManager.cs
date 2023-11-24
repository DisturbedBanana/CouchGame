using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HeatManager : MonoBehaviour
{
    [SerializeField] private Slider _lumberjackHeatSlider;
    [SerializeField] private Slider _scoutHeatSlider;
    [SerializeField] private Slider _shamanjackHeatSlider;
    [SerializeField] private Slider _engineerjackHeatSlider;

    [SerializeField] private float _heatMultiplier;
    private Vector3 _playerDeathPosition;

    [SerializeField] private List<GameObject> _tombstones = new List<GameObject>();

    SkinnedMeshRenderer _playerRenderer;

    public static HeatManager instance;

    [Space]
    [Header("Player Materials")]
    public Material _lumberjackMat;
    public Material _scoutMat;
    public Material _shamanMat;
    public Material _engineerMat;
    public Material _deadMat;

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
            if (!player.GetComponent<Character>().IsInSnow && player.GetComponent<Character>().Heat != 100)
            {
                switch (player.gameObject.GetComponent<Character>().PlayerId)
                {
                    case 1:
                        player.gameObject.GetComponent<Character>().Heat += 1f;
                        _lumberjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 2:
                        player.gameObject.GetComponent<Character>().Heat += 1f;
                        _scoutHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 3:
                        player.gameObject.GetComponent<Character>().Heat += 1f;
                        _shamanjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 4:
                        player.gameObject.GetComponent<Character>().Heat += 1f;
                        _engineerjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    default:
                        break;
                }
            }

            if (player.GetComponent<Character>().IsInSnow && player.GetComponent<Character>().Heat != 0)
            {
                switch (player.gameObject.GetComponent<Character>().PlayerId)
                {
                    case 1:
                        player.gameObject.GetComponent<Character>().Heat -= 0.25f;
                        _lumberjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 2:
                        player.gameObject.GetComponent<Character>().Heat -= 1f;
                        _scoutHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 3:
                        player.gameObject.GetComponent<Character>().Heat -= 0.25f;
                        _shamanjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    case 4:
                        player.gameObject.GetComponent<Character>().Heat -= 0.25f;
                        _engineerjackHeatSlider.value = player.gameObject.GetComponent<Character>().Heat;
                        break;
                    default:
                        break;
                }
            }

            if (player.GetComponent<Character>().Heat == 0 && player.GetComponent<Character>().IsAlive)
            {
                Debug.Log("A player is dead");
                _playerDeathPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

                switch (player.gameObject.GetComponent<Character>().PlayerId)
                {
                    case 1:
                        player.GetComponent<Character>().IsAlive = false;
                        PlaceTombstone(1, _playerDeathPosition);
                        break;
                    case 2:
                        player.GetComponent<Character>().IsAlive = false;
                        PlaceTombstone(2, _playerDeathPosition);
                        break;
                    case 3:
                        player.GetComponent<Character>().IsAlive = false;
                        PlaceTombstone(3, _playerDeathPosition);
                        break;
                    case 4:
                        player.GetComponent<Character>().IsAlive = false;
                        PlaceTombstone(4, _playerDeathPosition);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void PlaceTombstone(int playerId, Vector3 tombstonePosition)
    {
        //Instantiates the player's tombstone where he died
        Instantiate(_tombstones[playerId - 1], tombstonePosition, Quaternion.AngleAxis(45f, Vector3.up));
        Debug.Log("A tombstone was placed for the " + GameManager.instance._playerGameObjectList[playerId - 1]);

        //Changes the action map to the dead one so the player can't interact anymore
        GameManager.instance._playerGameObjectList[playerId - 1].GetComponent<PlayerMovTest>().SwitchActionMap("Dead");

        //Changes the to the dead transparent material of the player
        GameManager.instance._playerGameObjectList[playerId - 1].GetComponentInChildren<SkinnedMeshRenderer>().material = _deadMat;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<Character>().PlayerId != 2)
            {
                other.gameObject.GetComponent<Character>().MoveSpeed = 4f;
            }
            
            other.gameObject.GetComponent<Character>().IsInSnow = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Character>().MoveSpeed = 7f;
            other.gameObject.GetComponent<Character>().IsInSnow = false;
        }
    }
}
