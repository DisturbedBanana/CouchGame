using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TotemTeleportable : MonoBehaviour
{
    [SerializeField] private Vector3 _activatedTotemPos = Vector3.zero;
    private bool _canActivateTP = false;
    private Totem _currentTotem = null;
    
    public Vector3 ActivatedTotemPos
    {
        get { return _activatedTotemPos; }
        set {_activatedTotemPos = value;}
    }
    
    public Totem CurrentTotem
    {
        get { return _currentTotem; }
        set {_currentTotem = value;}
    }
    
    public bool CanActivateTP
    {
        get { return _canActivateTP; }
        set {_canActivateTP = value;}
    }
    

    private void Teleport()
    {
        if (_activatedTotemPos != Vector3.zero)
        {
            transform.position = _activatedTotemPos;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Teleport();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (_canActivateTP)
            {
                _currentTotem.ActivateTotem();
                _activatedTotemPos = _currentTotem.transform.position;
            }
        }
    }
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     Totem totemEntered = other.GetComponent<Totem>();
    //
    //     if (totemEntered == _currentTotem)
    //     {
    //         _canActivateTP = false;
    //     }
    //     else if (totemEntered != null)
    //     {
    //         _currentTotem = totemEntered;
    //         _canActivateTP = true;
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     Totem totemExited = other.GetComponent<Totem>();
    //
    //     if (totemExited != null)
    //     {
    //         _canActivateTP = false;
    //     }
    // }
}
