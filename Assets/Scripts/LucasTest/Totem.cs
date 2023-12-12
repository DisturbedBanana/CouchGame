using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    //TP au dernier activé depuis n'importe ou dans la map
    //Accède au script "teleportable" dans le player
    
    private bool _isTotemActivated = false;
    private TotemTeleportable _playerTPComponent = null;

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
            _playerTPComponent = other.GetComponent<TotemTeleportable>();
            if (_playerTPComponent != null)
            {
                _playerTPComponent.CanActivateTP = true;
                _playerTPComponent.CurrentTotem = this;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetComponent<Character>().PlayerId == 3)
        {
            TotemTeleportable tempTPComponent = other.GetComponent<TotemTeleportable>();
            if (tempTPComponent == _playerTPComponent)
            {
                _playerTPComponent.CanActivateTP = false;
            }
        }
    }
}
