using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _optionsMenuCanvas;

    private void Awake()
    {
        _anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Animator>();
        _mainMenuCanvas = GameObject.FindGameObjectWithTag("MainMenuCanvas");
        _optionsMenuCanvas = GameObject.FindGameObjectWithTag("OptionsMenuCanvas");
        _optionsMenuCanvas.SetActive(false);
    }

    public void GoToOptionsMenu()
    {
        StartCoroutine(C_GoToOptionsMenu());
    }

    public void GoToMainMenu()
    {
        StartCoroutine(C_GoToMainMenu());
    }

    private IEnumerator C_GoToOptionsMenu()
    {
        _mainMenuCanvas.SetActive(false);
        _anim.SetTrigger("GoToOptionsMenu");
        Debug.Log("Lance anim");
        yield return new WaitForSeconds(1.2f);
        Debug.Log("Affiche options");
        _optionsMenuCanvas.SetActive(true);
    }

    private IEnumerator C_GoToMainMenu()
    {
        _optionsMenuCanvas.SetActive(false);
        _anim.SetTrigger("GoToMainMenu");
        Debug.Log("Lance anim");
        yield return new WaitForSeconds(1.2f);
        Debug.Log("Affiche main menu");
        _mainMenuCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }
}
