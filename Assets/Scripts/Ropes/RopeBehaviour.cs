using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeBehaviour : MonoBehaviour
{
    Character _player;
    [SerializeField] private bool _isInRopeZone;
    [SerializeField] private GameObject _brokenRope;
    [SerializeField] private GameObject _repairedRope;
    [SerializeField] private GameObject _ropeModel;

    void Start()
    {
        _player = GetComponent<Character>();
        _repairedRope.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BridgeZone"))
        {
            _isInRopeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BridgeZone"))
        {
            _isInRopeZone = false;
        }
    }

    public void OnBridgeRepair(InputAction.CallbackContext context)
    {
        if (context.performed && _player.NbWoods >= 2 && _player.NbIrons >= 1 && _isInRopeZone)
        {
            Debug.Log("peut repair rope");

            string woodValue;
            string ironValue;

            woodValue = UIManager.instance._engineerWoodValue.text;
            ironValue = UIManager.instance._engineerIronValue.text;

            int intWoodValue = int.Parse(woodValue);
            int intIronValue = int.Parse(ironValue);


            if (intWoodValue >= 2 && intIronValue >= 2)
            {
                intWoodValue -= 2;
                intIronValue -= 1;
                UIManager.instance._engineerWoodValue.text = intWoodValue.ToString();
                UIManager.instance._engineerIronValue.text = intIronValue.ToString();
                _player.NbWoods -= 2;
                _player.NbIrons -= 1;

                Debug.Log("repair");

                _brokenRope.SetActive(false);
                _repairedRope.SetActive(true);
                _ropeModel.SetActive(true);
            }
        }
    }
}
