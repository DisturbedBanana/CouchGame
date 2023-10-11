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

    private void OnTriggerEnter(Collider collision)
    {
        var input = Input.GetButtonDown("jsp");
   
        if (collision.CompareTag("RedCube"))
        {

        }
    }
}
