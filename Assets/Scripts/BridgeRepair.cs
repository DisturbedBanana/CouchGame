using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BridgeRepair : MonoBehaviour
{
    Character _player;
    [SerializeField] private bool _isInBridgeZone;
    [SerializeField] private GameObject _brokenBridge;
    [SerializeField] private GameObject _repairedridge;
    [SerializeField] private GameObject _groundHitbox;

    void Start()
    {
        _player = GetComponent<Character>();
        _repairedridge.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BridgeZone"))
        {
            _isInBridgeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BridgeZone"))
        {
            _isInBridgeZone = false;
        }
    }

    public void OnBridgeRepair(InputAction.CallbackContext context)
    {
        if (context.performed && _player.NbWoods >= 2 && _player.NbIrons >= 2 && _isInBridgeZone)
        {
            Debug.Log("peut repair");

            string woodValue;
            string ironValue;

            woodValue = UIManager.instance._shamanWoodValue.text;
            ironValue = UIManager.instance._shamanIronValue.text;

            int intWoodValue = int.Parse(woodValue);
            int intIronValue = int.Parse(ironValue);

            intWoodValue = 5;
            intIronValue = 5;

            if (intWoodValue >= 2 && intIronValue >= 2)
            {
                intWoodValue -= 2;
                intIronValue -= 2;
                UIManager.instance._shamanWoodValue.text = intWoodValue.ToString();
                UIManager.instance._shamanIronValue.text = intIronValue.ToString();
                _player.NbWoods -= 2;
                _player.NbIrons -= 2;

                Debug.Log("repair");

                _brokenBridge.SetActive(false);
                _repairedridge.SetActive(true);
                _groundHitbox.SetActive(true);
            }
        }
    }
}
