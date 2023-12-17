using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering;
using UnityEditor;
using UnityEngine.Rendering.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Space]
    [Header("Component References")]
    [SerializeField] private EventSystem _eventSys;
    public string _menuState;
    public GameObject _currentlyDisplayedMenu;

    [Space]
    [Header("Canvas References")]
    public GameObject _pauseMenuCanvas;
    public GameObject _optionsMenuCanvas;
    public GameObject _returnToMainMenuCanvas;
    public GameObject _winCanvas;
    public GameObject _loseCanvas;
    public GameObject _backgroundCanvas;


    [Space]
    [Header("Selected Items References")]
    public GameObject _pauseMenuFirstSelectedButton;
    public GameObject _optionsMenuFirstSelectedButton;
    public GameObject _returnToMainMenuFirstSelectedButton;
    public GameObject _winMenuFirstSelectedButton;
    public GameObject _loseMenuFirstSelectedButton;

    [Space]
    [Header("Booleans")]
    [SerializeField] private bool _canCloseMenu = true;

    [Space]
    [Header("Wood values")]
    public TextMeshProUGUI _lumberjackWoodValue;
    public TextMeshProUGUI _scoutWoodValue;
    public TextMeshProUGUI _shamanWoodValue;
    public TextMeshProUGUI _engineerWoodValue;

    [Space]
    [Header("Iron values")]
    public TextMeshProUGUI _lumberjackIronValue;
    public TextMeshProUGUI _scoutIronValue;
    public TextMeshProUGUI _shamanIronValue;
    public TextMeshProUGUI _engineerIronValue;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _pauseMenuCanvas = GameObject.FindGameObjectWithTag("PauseCanvas");
        _optionsMenuCanvas = GameObject.FindGameObjectWithTag("OptionsCanvas");
        //_returnToMainMenuCanvas = GameObject.FindGameObjectWithTag("ReturnCanvas");
        _winCanvas = GameObject.FindGameObjectWithTag("WinCanvas");
        _loseCanvas = GameObject.FindGameObjectWithTag("LoseCanvas");
    }

    private void Start()
    {
        _pauseMenuCanvas.SetActive(false);
        _optionsMenuCanvas.SetActive(false);
        //_returnToMainMenuCanvas.SetActive(false);
        _winCanvas.SetActive(false);
        _loseCanvas.SetActive(false);
        _backgroundCanvas.SetActive(false);
    }

    public void OnUIBack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_menuState != "WinCanvas" || _menuState != "LoseCanvas")
            {
                return;
            }

            if (_menuState != "PauseMenu" && _canCloseMenu)
            {
                _canCloseMenu = false;
                StartCoroutine(GoBackMenu());
            }
            else if (_menuState == "PauseMenu")
            {
                _currentlyDisplayedMenu.SetActive(false);
                _backgroundCanvas.SetActive(false);
                GameManager.instance.PauseGame();
            }
        }
    }

    private IEnumerator GoBackMenu()
    {
        _currentlyDisplayedMenu.SetActive(false);

        yield return new WaitForSecondsRealtime(0.001f);

        _pauseMenuCanvas.SetActive(true);
        _canCloseMenu = true;
        
    }

    private void SetUIInfo(GameObject currentMenu, string menuState)
    {
        _currentlyDisplayedMenu = currentMenu;
        _menuState = menuState;
    }

    public void SetSelectedButton(GameObject canvas, GameObject button)
    {
        if (canvas == _pauseMenuCanvas)
        {
            SetUIInfo(_pauseMenuCanvas, "PauseMenu");
            _eventSys.SetSelectedGameObject(_pauseMenuFirstSelectedButton);
        }
        else if (canvas == _optionsMenuCanvas)
        {
            SetUIInfo(_optionsMenuCanvas, "OptionsMenu");
            _eventSys.SetSelectedGameObject(_optionsMenuFirstSelectedButton);
        }
        else if (canvas == _returnToMainMenuCanvas)
        {
            SetUIInfo(_returnToMainMenuCanvas, "ReturnToMainMenu");
            _eventSys.SetSelectedGameObject(_returnToMainMenuFirstSelectedButton);
        }
        else if (canvas == _winCanvas)
        {
            SetUIInfo(_winCanvas, "WinMenu");
            _eventSys.SetSelectedGameObject(_winMenuFirstSelectedButton);
        }
        else if (canvas == _loseCanvas)
        {
            SetUIInfo(_loseCanvas, "LoseMenu");
            _eventSys.SetSelectedGameObject(_loseMenuFirstSelectedButton);
        }
    }
}
