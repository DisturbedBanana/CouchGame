using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeUp : MonoBehaviour
{
    [SerializeField] private Transform _bottomRope;
    private RopeTeleportable _scout;
    private bool _isRopeActivated = false;

    public bool IsRopeActivated
    {
        get { return _isRopeActivated; }
        set { _isRopeActivated = value; }
    }

    public void ActivateRope()
    {
        if (!_isRopeActivated)
        {
            _isRopeActivated = true;
            Debug.Log("activated rope");
        }
        else
        {
            _scout.gameObject.transform.position = _bottomRope.position;
            Debug.Log("teleported");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _scout = other.gameObject.GetComponent<RopeTeleportable>();

            if (_scout != null)
            {
                _scout.CanActivateRope = true;
                _scout.CurrentRope = this;
                Debug.Log("can activate rope");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RopeTeleportable>() == _scout)
        {
            _scout.CanActivateRope = false;
            _scout.CurrentRope = null;
        }
    }
}
