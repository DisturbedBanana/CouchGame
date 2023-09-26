using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] KeyCode _up;
    [SerializeField] KeyCode _down;
    [SerializeField] KeyCode _left;
    [SerializeField] KeyCode _right;


    void Update()
    {
        if (Input.GetKey(_left))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 3);
        }

        if (Input.GetKey(_right))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }

        if (Input.GetKey(_up))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 3);
        }

        if (Input.GetKey(_down))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 3);
        }
    }
}
