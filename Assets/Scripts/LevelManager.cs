using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Space]
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject transitionCanvas;

    void Start()
    {
        transitionCanvas = GameObject.FindGameObjectWithTag("TransitionCanvas");
        animator = transitionCanvas.GetComponent<Animator>();
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
