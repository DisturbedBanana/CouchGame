using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovTest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInputs _playerInput;
    [SerializeField] private InputAction _moveInputAction;
    [SerializeField] private Rigidbody _rigidbody;

    [Space]
    [Header("Variables")]
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _speedCap = 5f;
    [SerializeField] private Vector3 _forceDir = Vector3.zero;
    [SerializeField] private Camera _playerCamera;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _playerInput = new PlayerInputs();
    }

    private void OnEnable()
    {
        _playerInput.Controller.Jump.started += DoJump;
        _moveInputAction = _playerInput.Controller.Movement;
        _playerInput.Controller.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Controller.Jump.started -= DoJump;
        _playerInput.Controller.Disable();
    }

    private void FixedUpdate()
    {
        _forceDir += _moveInputAction.ReadValue<Vector2>().x * GetCameraRight(_playerCamera) * _movementSpeed;
        _forceDir += _moveInputAction.ReadValue<Vector2>().y * GetCameraForward(_playerCamera) * _movementSpeed;

        _rigidbody.AddForce(_forceDir, ForceMode.Impulse);
        _forceDir = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
        {
            _rigidbody.velocity += Vector3.down * Physics.gravity.y * Time.deltaTime;
        }

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0f;

        if (horizontalVelocity.sqrMagnitude > _speedCap * _speedCap)
        {
            _rigidbody.velocity = horizontalVelocity.normalized * _speedCap + Vector3.up * _rigidbody.velocity.y;
        }
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext context)
    {
        if (isGrounded())
        {
            _forceDir += Vector3.up * _jumpForce;
        }
    }

    private bool isGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
