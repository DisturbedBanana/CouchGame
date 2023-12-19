using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextualPopup : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

    public void Press()
    {
        animator.SetTrigger("Press");
    }
}
