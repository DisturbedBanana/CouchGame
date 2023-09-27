using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementLucas : MonoBehaviour
{
    [SerializeField] float _baseMovementSpeed = 5f;
    [SerializeField] float _slowedMovementSpeed = 3.8f;
    float _movementSpeed;
    bool _hasWood = false;

    private void Start()
    {
        _movementSpeed = _baseMovementSpeed;
    }

    public bool HasWood
    {
        get { return _hasWood; }
        set { _hasWood = value; }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * _movementSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * _movementSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _movementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * _movementSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            _hasWood = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Snow"))
        {
            _movementSpeed = _slowedMovementSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Snow"))
        {
            _movementSpeed = _baseMovementSpeed;
        }
    }
}
