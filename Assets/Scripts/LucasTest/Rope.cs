using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Rope _targetRope;
    private RopeTeleportable _currentPlayer;
    private bool _isRopeActivated = false;

    public bool IsRopeActivated
    {
        get { return _isRopeActivated; }
        set { _isRopeActivated = value; }
    }
    protected RopeTeleportable CurrentPlayer
    {
        get { return _currentPlayer; }
        set { _currentPlayer = value; }
    }
    public Rope TargetRope
    {
        get { return _targetRope; }
        set { _targetRope = value; }
    }

    public virtual void ActivateRope()
    {
        if (!_isRopeActivated)
        {
            _isRopeActivated = true;
        }
        else
        {
            _currentPlayer.gameObject.transform.position = _targetRope.transform.position;
        }
    }
    


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RopeTeleportable>() == _currentPlayer)
        {
            _currentPlayer.CanActivateRope = false;
            _currentPlayer.CurrentRope = null;
        }
    }
}
