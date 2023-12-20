using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BridgeInteractable : MonoBehaviour
{
    private bool _canActivateBridge;
    private Character character;
    [SerializeField] private Bridge _currentBridge = null;

    private void Start() 
    {
        TryGetComponent<Character>(out character);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.B)) TellBridgeToActivate();
    }

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
        _currentBridge.ActivateBridge(character);
    }
}
