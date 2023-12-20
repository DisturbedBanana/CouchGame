using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextualPopup : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool playerInZone;
    // Doit toujours être égal à la rotation de la Split Camera !
    private readonly Vector3 camRotation = new Vector3(40, -45); 

    private void Start()
    {
        transform.rotation = Quaternion.Euler(camRotation);
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
        playerInZone = true;
    }

    public void FadeOut()
    {
        playerInZone = false;
        animator.SetTrigger("FadeOut");
    }

    public void Press()
    {
        if(playerInZone) animator.SetTrigger("Press");
    }
}
