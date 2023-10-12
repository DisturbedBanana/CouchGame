using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovTest : MonoBehaviour
{
    [Header("Refenrences")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerInputs _playerInputs;
    [SerializeField] private GameObject _cam;

    [Space]
    [Header("Variables")]
    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private Vector2 _moveVector;
    [SerializeField] private float _globalOffset = -45f;
    [SerializeField] private Vector3 _move;
    [SerializeField] private Vector2 _movementVector;
    [SerializeField] private float _turnSpeed = 360f;



    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _playerInputs = new PlayerInputs();
        _cam = GameObject.FindGameObjectWithTag("MainCamera");

        //_playerInputs.Controller.Movement.performed += ctx => _moveVector = ctx.ReadValue<Vector2>();
        //_playerInputs.Controller.Movement.canceled += ctx => _moveVector = Vector2.zero;

        Quaternion _camRotationOffset = Quaternion.Euler(new Vector3(10f, _globalOffset, 0f));

        _cam.transform.position = new Vector3(10f, 4f, -10f);
        _cam.transform.rotation = _camRotationOffset;
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

    private void Move()
    {
        if (_movementVector != Vector2.zero)
        {
            _move = new Vector3(_movementVector.x, 0f, _movementVector.y) * Time.deltaTime * 5f;

            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0f, _globalOffset, 0f));

            var skewedInput = matrix.MultiplyPoint3x4(_move);

            transform.Translate(skewedInput, Space.World);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementVector = context.ReadValue<Vector2>();
    }

    private void Look()
    {
        if (_move != Vector3.zero)
        {
            var relative = (transform.position + _move) - transform.position;
            var rotation = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _turnSpeed * Time.deltaTime);
        }

    }

    private void Update()
    {
        Look();
        Move();
    }
}
