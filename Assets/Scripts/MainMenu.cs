using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Global References")]
    [SerializeField] private Animator _anim;

    [Space]
    [Header("Canvas References")]
    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _optionsMenuCanvas;
    [SerializeField] private GameObject _playerSelectionMenuCanvas;
    [SerializeField] private GameObject _currentlyDisplayedMenu;

    [Space]
    [Header("Selected Items References")]
    [SerializeField] private GameObject _mainMenuFirstSelectedButton;
    [SerializeField] private GameObject _optionsMenuFirstSelectedButton;
    [SerializeField] private GameObject _playerSelectionMenuFirstSelectedButton;

    [Space]
    [Header("Component References")]
    [SerializeField] private EventSystem _eventSys;
    [SerializeField] private PlayerInputs _playerInputs;
    [SerializeField] private string _menuState;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Animator>();
        _mainMenuCanvas = GameObject.FindGameObjectWithTag("MainMenuCanvas");
        _optionsMenuCanvas = GameObject.FindGameObjectWithTag("OptionsMenuCanvas");
        _optionsMenuCanvas.SetActive(false);
        _playerSelectionMenuCanvas = GameObject.FindGameObjectWithTag("PlayerSelectionCanvas");
        _playerSelectionMenuCanvas.SetActive(false);
        _playerInputs = new PlayerInputs();
    }

    private void Start()
    {
        _menuState = "MainMenu";
        _currentlyDisplayedMenu = _mainMenuCanvas;
        _eventSys.SetSelectedGameObject(_mainMenuFirstSelectedButton);
    }

    private void OnEnable()
    {
        _playerInputs.UI.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.UI.Disable();
    }

    public void OnUIBack(InputAction.CallbackContext context)
    {
        if (context.performed && _menuState != "MainMenu")
        {
            if (_currentCoroutine == null)
            {
                _currentCoroutine = StartCoroutine(C_GoToMainMenu());
            }
        }
    }

    public void GoToOptionsMenu()
    {
        if (_currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(C_GoToOptionsMenu());
        }
    }

    public void GoToMainMenu()
    {
        if (_currentCoroutine == null) 
        {
            _currentCoroutine = StartCoroutine(C_GoToMainMenu());
        }
    }

    public void GoToPlayerSelection()
    {
        if (_currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(C_GoToPlayerSelection());
        }
    }

    private IEnumerator C_GoToOptionsMenu()
    {
        _mainMenuCanvas.SetActive(false);
        _anim.SetTrigger("GoToOptionsMenu");
        yield return new WaitForSecondsRealtime(1.2f);
        _menuState = "OptionsMenu";
        _optionsMenuCanvas.SetActive(true);
        _eventSys.SetSelectedGameObject(_optionsMenuFirstSelectedButton);
        _currentlyDisplayedMenu = _optionsMenuCanvas;
        yield return new WaitForSecondsRealtime(0.5f);
        _currentCoroutine = null;
    }

    private IEnumerator C_GoToMainMenu()
    {
        _currentlyDisplayedMenu.SetActive(false);

        if (_menuState == "OptionsMenu")
        {
            _anim.SetTrigger("GoToMainMenuFromOptions");
            yield return new WaitForSecondsRealtime(1.2f);
        }
        else if (_menuState == "PlayerSelectionMenu")
        {
            _anim.SetTrigger("GoToMainMenuFromPlayerSelection");
            yield return new WaitForSecondsRealtime(2.2f);
        }
        
        _menuState = "MainMenu";
        _currentlyDisplayedMenu = _mainMenuCanvas;
        _mainMenuCanvas.SetActive(true);
        _eventSys.SetSelectedGameObject(_mainMenuFirstSelectedButton);
        _currentCoroutine = null;

    }

    private IEnumerator C_GoToPlayerSelection()
    {
        _mainMenuCanvas.SetActive(false);
        _anim.SetTrigger("GoToPlayerSelection");
        yield return new WaitForSecondsRealtime(2.2f);
        _menuState = "PlayerSelectionMenu";
        _playerSelectionMenuCanvas.SetActive(true);
        _eventSys.SetSelectedGameObject(_playerSelectionMenuFirstSelectedButton);
        _currentlyDisplayedMenu = _playerSelectionMenuCanvas;
        _currentCoroutine = null;

    }

    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }
}
