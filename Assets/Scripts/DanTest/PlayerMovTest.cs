using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovTest : MonoBehaviour
{
    [Header("Refenrences")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerInputs _playerInputs;

    [Space]
    [Header("Variables")]
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private Vector2 _moveVector; 

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _playerInputs = new PlayerInputs();

        _playerInputs.Controller.Movement.performed += ctx => _moveVector = ctx.ReadValue<Vector2>();
        _playerInputs.Controller.Movement.canceled += ctx => _moveVector = Vector2.zero;
    }

    private void OnEnable()
    {
        _playerInputs.Controller.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Controller.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.velocity += Vector3.up * 5f;
    }

    private void Update()
    {
        Vector3 move = new Vector3(_moveVector.x, 0f, _moveVector.y) * Time.deltaTime * 5f;
        transform.Translate(move, Space.World);
    }
}
