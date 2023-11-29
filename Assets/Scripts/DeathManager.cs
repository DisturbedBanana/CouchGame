using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        foreach (GameObject player in GameManager.instance._playerGameObjectList)
        {
            if (!player.GetComponent<Character>().IsAlive)
            {
                switch (player.gameObject.GetComponent<Character>().PlayerId)
                {
                    case 1:
                        //player.gameObject.GetComponent<Character>().Heat = _lumberjackHeatSlider.value;
                        break;
                    case 2:
                        //player.gameObject.GetComponent<Character>().Heat = _scoutHeatSlider.value;
                        break;
                    case 3:
                        //player.gameObject.GetComponent<Character>().Heat = _shamanjackHeatSlider.value;
                        break;
                    case 4:
                        //player.gameObject.GetComponent<Character>().Heat = _engineerjackHeatSlider.value;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
