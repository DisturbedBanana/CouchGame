using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    bool hasRed = false;
    bool hasBlue = false;
    [SerializeField] bool isInCauldron = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 3);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 3);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedCube"))
        {
            hasRed = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BlueCube"))
        {
            hasBlue = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Cauldron"))
        {
            isInCauldron = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cauldron"))
        {
            isInCauldron = false;
        }
    }
}
