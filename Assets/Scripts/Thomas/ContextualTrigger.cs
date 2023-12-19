using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualTrigger : MonoBehaviour
{
    [SerializeField] private ContextualPopup popup;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) popup.FadeIn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) popup.FadeOut();
    }
}
