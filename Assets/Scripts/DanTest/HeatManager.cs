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

            if (player.GetComponent<Character>().Heat == 0)
            {
                Debug.Log("fin");
            }
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovTest>().PlayerSpeed = 2.5f;
            other.gameObject.GetComponent<Character>().IsInSnow = true;

            switch (other.gameObject.GetComponent<Character>().PlayerId)
            {
                case 1:
                    _lumberjackIsInSnow = true;
                    _lumberjackHeatSlider.value -= 0.2f;
                    other.gameObject.GetComponent<Character>().Heat = _lumberjackHeatSlider.value;
                    break;
                case 2:
                    _scoutIsInSnow = true;
                    _scoutHeatSlider.value -= 0.2f;
                    other.gameObject.GetComponent<Character>().Heat = _scoutHeatSlider.value;
                    break;
                case 3:
                    _shamanIsInSnow = true;
                    _shamanjackHeatSlider.value -= 0.2f;
                    other.gameObject.GetComponent<Character>().Heat = _shamanjackHeatSlider.value;
                    break;
                case 4:
                    _engineerIsInSnow = true;
                    _engineerjackHeatSlider.value -= 0.2f;
                    other.gameObject.GetComponent<Character>().Heat = _engineerjackHeatSlider.value;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
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

            other.gameObject.GetComponent<PlayerMovTest>().PlayerSpeed = 5f;
            other.gameObject.GetComponent<Character>().IsInSnow = false;
        }
    }
}
