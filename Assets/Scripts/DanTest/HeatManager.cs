using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class HeatManager : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("il fait froid");
            //other.gameObject.GetComponent<Character>().MoveSpeed = 2f;
        }

        if (other.gameObject.GetComponent<Character>().PlayerId != 2)
        {
            Debug.Log("scout");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Character>().MoveSpeed = 5f;
    }
}
