using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BridgeInteractable : MonoBehaviour
{
    private bool _canActivateBridge;
    [SerializeField] private Bridge _currentBridge = null;

    public bool CanActivateBridge
    {
        get { return _canActivateBridge; }
        set { _canActivateBridge = value; }
    }
    
    public Bridge CurrentBridge
    {
        get { return _currentBridge; }
        set { _currentBridge = value; }
    }

    private void TellBridgeToActivate()
    {
        _currentBridge.ActivateBridge();
    }
}
