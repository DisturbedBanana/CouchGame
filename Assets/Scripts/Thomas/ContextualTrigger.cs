using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualTrigger : MonoBehaviour
{
    [SerializeField] private ContextualPopup popup;
    // 0 pour n'importe quelle classe
    [SerializeField] private int requiredClassId;
    [SerializeField] private bool heatDependent;
    private readonly float fadeOutDelay = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popup.gameObject.SetActive(true);
            Character player = other.GetComponent<Character>();
            bool classDep = requiredClassId != 0 && !(heatDependent && !player.IsInSnow);
            bool wrongClass = !(requiredClassId == 0 || player.PlayerId == requiredClassId || (heatDependent && !player.IsInSnow));
            bool frost = heatDependent && player.IsInSnow;
            popup.FadeIn(classDep, wrongClass, frost);
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
