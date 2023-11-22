using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerMovTest : MonoBehaviour
{
    [Header("Refenrences")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerInputs _playerInputs;
    [SerializeField] private GameObject _cam;
    [SerializeField] private Animator _anim;

    [Space]
    [Header("Variables")]
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _globalOffset = -45f;
    [SerializeField] private float _turnSpeed = 360f;
    [SerializeField] private Vector3 _move;
    [SerializeField] private Vector2 _movementVector;
    [SerializeField] private Vector2 _moveVector;
    [SerializeField] private Vector3 _playerVelocity;
    [SerializeField] private float _currentPlayerSpeed;

    [Space]
    [Header("Booleans")]
    [SerializeField] private bool _canMove = true;
    [SerializeField] private bool _canLook = true;

    public bool CanMove { get { return _canMove; } set { _canMove = value; } }
    public bool CanLook { get { return _canLook; } set { _canLook = value; } }

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _playerInputs = new PlayerInputs();
        _anim = GetComponent<Animator>();

        //_cam = GameObject.FindGameObjectWithTag("MainCamera");

        //Quaternion _camRotationOffset = Quaternion.Euler(new Vector3(10f, _globalOffset, 0f));

        //_cam.transform.position = new Vector3(10f, 4f, -10f);
        //_cam.transform.rotation = _camRotationOffset;
    }

    private void OnEnable()
    {
        _playerInputs.Controller.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Controller.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementVector = context.ReadValue<Vector2>();
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
            _move = new Vector3(_movementVector.x, 0f, _movementVector.y) * Time.deltaTime * GetComponent<Character>().MoveSpeed;

            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0f, _globalOffset, 0f));

            var skewedInput = matrix.MultiplyPoint3x4(_move);

            transform.Translate(skewedInput, Space.World);

            if (GetComponent<Character>().IsInSnow)
            {
                _anim.SetBool("isInSnow", true);
            }
            else
            {
                _anim.SetBool("isInSnow", false);
            }
            _anim.SetFloat("animMovSpeed", _move.magnitude * 100f);
        }
    }

    private void Look()
    {
        if (_move != Vector3.zero)
        {
            var relative = (transform.position + _move) - transform.position;
            var rotation = Quaternion.LookRotation(relative, Vector3.up);

            var offsetRotation = rotation * Quaternion.AngleAxis(-_globalOffset, Vector3.down);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, offsetRotation, _turnSpeed * Time.deltaTime);
        }

    }

    private void Update()
    {
        if (_canMove && _canLook)
        {
            Look();
            Move();
        }

        if (_movementVector == Vector2.zero)
        {
            _anim.SetFloat("animMovSpeed", 0);
        }
    }
}
