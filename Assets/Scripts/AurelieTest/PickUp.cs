using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private bool _canPickUp;
    [SerializeField] private float _pickUpCooldown;
    private float _pickUpCooldownTimer;
    [SerializeField] private float _pickUpTime;
    private float _pickUpTimer;
    [SerializeField][Range(1, 5)] private float _range;

    private GameObject _obj;

    private void Start()
    {
        _pickUpCooldownTimer = _pickUpCooldown;
    }

    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * _range, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, _range))
        {
            GameObject hitObj = hit.collider.gameObject;

            if (hitObj.CompareTag("RedCube"))
            {
                if (_obj != null)
                    UnhighlightObject(_obj);
                _obj = hitObj;
                HighlightObject(_obj);
            }

            if (Input.GetKeyDown(KeyCode.E) && _canPickUp)
            {
                //Debug.Log("start press");
                _pickUpTimer = 0f;
            }

            if (Input.GetKey(KeyCode.E) && _canPickUp)
            {
                _pickUpTimer += Time.deltaTime;

                if (_pickUpTimer >= _pickUpTime)
                {
                    //Debug.Log("end timer");
                    PickUpObject(hitObj);
                }
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                //Debug.Log("released");
                _pickUpTimer = 0f;
            }

            if (!_canPickUp)
                UnhighlightObject(_obj);
        }
        else
        {
            if (_obj != null)
                UnhighlightObject(_obj);
            _obj = null;
        }

        // Cooldown Pick Up
        if (!_canPickUp)
        {
            //Debug.Log("start cd");
            _pickUpCooldownTimer -= Time.deltaTime;

            if (_pickUpCooldownTimer <= 0)
            {
                _canPickUp = true;
                _pickUpCooldownTimer = _pickUpCooldown;
                //Debug.Log("end cd");
            }
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

    private void PickUpObject(GameObject gameObject)
    {
        // add item inventaire
        _canPickUp = false;
        _pickUpTimer = 0f;
        //Debug.Log("picked up");
    }
}
