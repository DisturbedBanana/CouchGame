using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeTeleportable : MonoBehaviour
{
    //TP de haut en bas par tout le monde si la corde est posée
    //Scout peut se TP de bas en haut meme sans la corde
    //Corde posable par Ingenieur idéalement sinon par tout le monde si sur le rocher du haut

    private bool _canActivateRope = false;
    private Rope _currentRope = null;

    public bool CanActivateRope
    {
        get { return _canActivateRope; }
        set { _canActivateRope = value; }
    }

    public Rope CurrentRope
    {
        get { return _currentRope; }
        set { _currentRope = value; }
    }

    public void OnRope(InputAction.CallbackContext context)
    {
        if (_currentRope != null)
        {
            _currentRope.ActivateRope();
            Debug.Log("activating rope");
        }
    }
}