using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject transitionCanvas;

    void Start()
    {
        transitionCanvas = GameObject.FindGameObjectWithTag("TransitionCanvas");
        if (transitionCanvas != null)
        {
            animator = transitionCanvas.GetComponent<Animator>();
        }
    }

    IEnumerator CLoadLevel(string sceneToLoad)
    {
        //Debug.Log("Loaded level: " + sceneToLoad);
        animator?.SetTrigger("Start");
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadLevel(string levelToLoad)
    {
        StartCoroutine(CLoadLevel(levelToLoad));
    }
}
