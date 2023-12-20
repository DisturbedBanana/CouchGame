using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualTrigger : MonoBehaviour
{
    [SerializeField] private ContextualPopup popup;
    // 0 pour n'importe quelle classe
    [SerializeField] private int requiredClassId;
    private readonly float fadeOutDelay = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popup.gameObject.SetActive(true);
            if (requiredClassId == 0 || other.GetComponent<Character>().PlayerId == requiredClassId) popup.FadeIn();
            else popup.FadeInWrongClass();
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
