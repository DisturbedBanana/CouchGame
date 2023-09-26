using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //[Header("References")]


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator CLoadLevel(string sceneToLoad)
    {
        Debug.Log("Loaded level: " + sceneToLoad);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadLevel(string levelToLoad)
    {
        StartCoroutine(CLoadLevel(levelToLoad));
    }
}
