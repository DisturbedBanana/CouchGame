using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private bool _isPickingUp;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _pickUpTime;
    private float _pickUpTimer;

    private GameObject _object;

    private void Update()
    {
        if (_isPickingUp)
        {
            _pickUpTimer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && !_isPickingUp)
        {
            _isPickingUp = true;
            _pickUpTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("RedCube"))
        {
            _object = collision.gameObject;
            HighlightObject(_object);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("RedCube"))
        {
            UnhighlightObject(_object);
            _object = null;
        }
    }

    private void HighlightObject(GameObject gameObject)
    {
        gameObject.GetComponent<Outline>().enabled = true;
    }
    
    private void UnhighlightObject(GameObject gameObject)
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }
}
