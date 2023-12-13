using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEditor.Rendering;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public static GameManager instance;
    public static bool _gamePaused = false;

    [Space]
    [Header("Variables")]

    [SerializeField] private GameObject _lumberjack;
    [SerializeField] private GameObject _shaman;
    [SerializeField] private GameObject _engineer;
    [SerializeField] private GameObject _scout;
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    public List<GameObject> _playerGameObjectList = new List<GameObject>();

    [Space]
    [Header("Booleans")]
    public bool _canPauseGame = true;

    [Button("Win")]
    private void WinDebug()
    {
        UIManager.instance._winCanvas.SetActive(true);
    }

    [Button("Lose")]
    private void LoseDebug()
    {
        UIManager.instance._loseCanvas.SetActive(true);
    }

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

        _playerGameObjectList.Add(_lumberjack);
        _playerGameObjectList.Add(_scout);
        _playerGameObjectList.Add(_shaman);
        _playerGameObjectList.Add(_engineer);
    }

    private void Start()
    {
        //Instantiate(_lumberjack, _spawnPoints[0].transform.position, Quaternion.identity);
        //Instantiate(_scout, _spawnPoints[1].transform.position, Quaternion.identity);
        //Instantiate(_engineer, _spawnPoints[2].transform.position, Quaternion.identity);
        //Instantiate(_shaman, _spawnPoints[3].transform.position, Quaternion.identity);
    }

    public void OnPauseGame(InputAction.CallbackContext context)
    {
        if (context.performed && UIManager.instance._menuState == ("PauseMenu") && _canPauseGame)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _gamePaused = !_gamePaused;

        if (_gamePaused)
        {
            Time.timeScale = 0f;
            UIManager.instance._pauseMenuCanvas.SetActive(true);
            UIManager.instance._backgroundCanvas.SetActive(true);
            Debug.Log("Game paused");

            for (int i = 0; i < GameManager.instance._playerGameObjectList.Count; i++)
            {
                GameManager.instance._playerGameObjectList[i].GetComponent<PlayerMovTest>().SwitchActionMap("UI");
            }
        }
        else if (!_gamePaused)
        {
            Time.timeScale = 1f;
            UIManager.instance._pauseMenuCanvas.SetActive(false);
            UIManager.instance._backgroundCanvas.SetActive(false);
            Debug.Log("Game unpaused");

            for (int i = 0; i < GameManager.instance._playerGameObjectList.Count; i++)
            {
                GameManager.instance._playerGameObjectList[i].GetComponent<PlayerMovTest>().SwitchActionMap("Controller");
            }
        }
    }

    public void OnWin()
    {

    }

    public void OnLose()
    {

    }
}
