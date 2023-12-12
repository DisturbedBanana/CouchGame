using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject _objectToActivate;
    private BridgeInteractable _currentBridgeInteractable;

    private void Start()
    {
        _objectToActivate.SetActive(false);
    }

    public void ActivateBridge()
    {
        _objectToActivate.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BridgeInteractable _currentBridgeInteractable = other.GetComponent<BridgeInteractable>();

            if (_currentBridgeInteractable != null)
            {
                _currentBridgeInteractable.CurrentBridge = this;
                _currentBridgeInteractable.CanActivateBridge = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BridgeInteractable bridgeInteractable = other.GetComponent<BridgeInteractable>();
        if (bridgeInteractable == _currentBridgeInteractable)
        {
            _currentBridgeInteractable.CurrentBridge = null;
            _currentBridgeInteractable.CanActivateBridge = false;
        }
    }
}
