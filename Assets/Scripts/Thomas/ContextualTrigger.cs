using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualTrigger : MonoBehaviour
{
    [SerializeField] private ContextualPopup popup;
    private readonly float fadeOutDelay = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popup.gameObject.SetActive(true);
            popup.FadeIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popup.FadeOut();
            StartCoroutine(FadeOutCo());
        }
    }

    private IEnumerator FadeOutCo()
    {
        yield return new WaitForSeconds(fadeOutDelay);
        popup.gameObject.SetActive(false);
    }
}
