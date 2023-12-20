using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextualPopup : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Color wrongClassTint;

    [Header("Icons")]
    [SerializeField] private Image actionIcon;
    [SerializeField] private Image buttonIcon;
    [SerializeField] private Image characterIcon;
    [SerializeField] private Image crossIcon;


    private bool playerInZone;
    // Doit toujours être égal à la rotation de la Split Camera !
    private readonly Vector3 camRotation = new Vector3(40, -45); 

    private void Start()
    {
        transform.rotation = Quaternion.Euler(camRotation);
    }

    public void FadeIn()
    {
        actionIcon.color = new Color(255, 255, 255, actionIcon.color.a);
        crossIcon.gameObject.SetActive(false);
        animator.SetTrigger("FadeIn");
        playerInZone = true;
    }

    public void FadeInWrongClass()
    {
        actionIcon.color = new Color(wrongClassTint.r, wrongClassTint.g, wrongClassTint.b, actionIcon.color.a);
        crossIcon.gameObject.SetActive(true);
        FadeIn();
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
