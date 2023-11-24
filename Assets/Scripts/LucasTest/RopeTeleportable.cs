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
    private RopeUp _currentRope = null;

    public bool CanActivateRope
    {
        get { return _canActivateRope; }
        set { _canActivateRope = value; }
    }

    public RopeUp CurrentRope
    {
        get { return _currentRope; }
        set { _currentRope = value; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_currentRope != null)
            {
                _currentRope.ActivateRope();
            }
        }
    }

    public void OnTeleportRope(InputAction.CallbackContext context)
    {
        _currentRope.ActivateRope();
    }
}
