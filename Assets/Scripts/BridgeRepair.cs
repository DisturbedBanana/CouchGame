using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BridgeRepair : MonoBehaviour
{
    Character _player;
    [SerializeField] private bool _isInBridgeZone1;
    [SerializeField] private GameObject _brokenBridge1;
    [SerializeField] private GameObject _repairedBridge1;
    [SerializeField] private GameObject _groundHitbox1;

    [SerializeField] private bool _isInBridgeZone2;
    [SerializeField] private GameObject _brokenBridge2;
    [SerializeField] private GameObject _repairedBridge2;
    [SerializeField] private GameObject _groundHitbox2;

    void Start()
    {
        _player = GetComponent<Character>();
        _repairedBridge1.SetActive(false);
        _repairedBridge2.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BridgeZone1"))
        {
            _isInBridgeZone1 = true;
        }
        else if (other.CompareTag("BridgeZone2"))
        {
            _isInBridgeZone2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BridgeZone1"))
        {
            _isInBridgeZone1 = false;
        }
        else if (other.CompareTag("BridgeZone2"))
        {
            _isInBridgeZone2 = false;
        }
    }

    public void OnBridgeRepair(InputAction.CallbackContext context)
    {
        if (context.performed && _player.NbWoods >= 2 && _player.NbIrons >= 2 && _isInBridgeZone1 || context.performed && _player.NbWoods >= 2 && _player.NbIrons >= 2 && _isInBridgeZone2)
        {
            Debug.Log("peut repair");

            string woodValue;
            string ironValue;

            woodValue = UIManager.instance._engineerWoodValue.text;
            ironValue = UIManager.instance._engineerIronValue.text;

            int intWoodValue = int.Parse(woodValue);
            int intIronValue = int.Parse(ironValue);

            if (intWoodValue >= 2 && intIronValue >= 2)
            {
                intWoodValue -= 2;
                intIronValue -= 2;
                UIManager.instance._engineerWoodValue.text = intWoodValue.ToString();
                UIManager.instance._engineerIronValue.text = intIronValue.ToString();
                _player.NbWoods -= 2;
                _player.NbIrons -= 2;

                Debug.Log("repair");

                if (_isInBridgeZone1)
                {
                    _brokenBridge1.SetActive(false);
                    _repairedBridge1.SetActive(true);
                    _groundHitbox1.SetActive(true);
                }
                else if (_isInBridgeZone2)
                {
                    _brokenBridge2.SetActive(false);
                    _repairedBridge2.SetActive(true);
                    _groundHitbox2.SetActive(true);
                }
            }
        }
    }
}
