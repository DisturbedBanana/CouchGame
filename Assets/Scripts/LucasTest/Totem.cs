using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    //TP au dernier activé depuis n'importe ou dans la map
    //Accède au script "teleportable" dans le player
    
    private bool _isTotemActivated = false;
    private Teleportable _playerTPComponent = null;

    public void ActivateTotem()
    {
        if (!_isTotemActivated)
        {
            _isTotemActivated = true;
            if (_playerTPComponent.CurrentTotem != null)
            {
                _playerTPComponent.CurrentTotem.DeactivateTotem();
            }
            _playerTPComponent.CanActivateTP = false;
        }
    }

    public void DeactivateTotem()
    {
        if (_isTotemActivated)
        {
            _isTotemActivated = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerTPComponent = other.GetComponent<Teleportable>();
            if (_playerTPComponent != null)
            {
                _playerTPComponent.CanActivateTP = true;
                _playerTPComponent.CurrentTotem = this;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Teleportable tempTPComponent = other.GetComponent<Teleportable>();
            if (tempTPComponent == _playerTPComponent)
            {
                _playerTPComponent.CanActivateTP = false;
            }
        }
    }
}
