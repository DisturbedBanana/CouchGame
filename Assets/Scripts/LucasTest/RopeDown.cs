using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeDown : Rope
{
    [SerializeField] private ContextualTrigger _scoutClimbPopupTrigger, _ropeClimbPopupTrigger;

    private void Awake()
    {
        _ropeClimbPopupTrigger.enabled = false;
    }

    public override void ActivateRope()
    {
        if (TargetRope.IsRopeActivated == true)
        {
            CurrentPlayer.gameObject.transform.position = TargetRope.transform.position;
        }
        else
        {
            if (CurrentPlayer.GetComponent<Character>().PlayerId == 2)
            {
                CurrentPlayer.gameObject.transform.position = TargetRope.transform.position;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CurrentPlayer = other.gameObject.GetComponent<RopeTeleportable>();
            if (IsRopeActivated)
            {
                _scoutClimbPopupTrigger.enabled = false;
                _ropeClimbPopupTrigger.enabled = true;
            }
            if (CurrentPlayer != null)
            {
                CurrentPlayer.CanActivateRope = true;
                CurrentPlayer.CurrentRope = this;
            }
        }
    }
}
