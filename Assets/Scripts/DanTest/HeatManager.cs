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

    [SerializeField] private bool _lumberjackIsInSnow;
    [SerializeField] private bool _scoutIsInSnow;
    [SerializeField] private bool _shamanIsInSnow;
    [SerializeField] private bool _engineerIsInSnow;

    [SerializeField] private float _heatMultiplier;
    private Character _playerClass;
    private Vector3 _playerDeathPosition;

    [SerializeField] private List<GameObject> _tombstones = new List<GameObject>();

    private void Update()
    {
        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            if (!player.GetComponent<Character>().IsInSnow && player.GetComponent<Character>().Heat != 100)
            {
                switch (player.gameObject.GetComponent<Character>().PlayerId)
                {
                    case 1:
                        _lumberjackHeatSlider.value += 1f;
                        player.gameObject.GetComponent<Character>().Heat = _lumberjackHeatSlider.value;
                        break;
                    case 2:
                        _scoutHeatSlider.value += 1f;
                        player.gameObject.GetComponent<Character>().Heat = _scoutHeatSlider.value;
                        break;
                    case 3:
                        _shamanjackHeatSlider.value += 1f;
                        player.gameObject.GetComponent<Character>().Heat = _shamanjackHeatSlider.value;
                        break;
                    case 4:
                        _engineerjackHeatSlider.value += 1f;
                        player.gameObject.GetComponent<Character>().Heat = _engineerjackHeatSlider.value;
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
                        _lumberjackHeatSlider.value -= 0.2f;
                        player.gameObject.GetComponent<Character>().Heat = _lumberjackHeatSlider.value;
                        break;
                    case 2:
                        _scoutHeatSlider.value -= 0.2f;
                        player.gameObject.GetComponent<Character>().Heat = _scoutHeatSlider.value;
                        break;
                    case 3:
                        _shamanjackHeatSlider.value -= 0.2f;
                        player.gameObject.GetComponent<Character>().Heat = _shamanjackHeatSlider.value;
                        break;
                    case 4:
                        _engineerjackHeatSlider.value -= 0.2f;
                        player.gameObject.GetComponent<Character>().Heat = _engineerjackHeatSlider.value;
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
        Instantiate(_tombstones[playerId - 1], tombstonePosition, Quaternion.AngleAxis(45f, Vector3.up));
        PlayerMovTest.instance.SwitchActionMap("Dead");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (other.gameObject.GetComponent<Character>().PlayerId)
            {
                case 1:
                    other.gameObject.GetComponent<Character>().IsInSnow = true;
                    break;
                case 2:
                    other.gameObject.GetComponent<Character>().IsInSnow = true;
                    break;
                case 3:
                    other.gameObject.GetComponent<Character>().IsInSnow = true;
                    break;
                case 4:
                    other.gameObject.GetComponent<Character>().IsInSnow = true;
                    break;
                default:
                    break;
            }

            if (other.gameObject.GetComponent<Character>().PlayerId != 2)
            {
                other.gameObject.GetComponent<Character>().MoveSpeed = 2.5f;
            }
            
            other.gameObject.GetComponent<Character>().IsInSnow = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (other.gameObject.GetComponent<Character>().PlayerId)
            {
                case 1:
                    _lumberjackIsInSnow = false;
                    break;
                case 2:
                    _scoutIsInSnow = false;
                    break;
                case 3:
                    _shamanIsInSnow = false;
                    break;
                case 4:
                    _engineerIsInSnow = false;
                    break;
                default:
                    break;
            }

            other.gameObject.GetComponent<Character>().MoveSpeed = 5f;
            other.gameObject.GetComponent<Character>().IsInSnow = false;
        }
    }
}
