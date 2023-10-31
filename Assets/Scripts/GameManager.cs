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

    [Space]
    [Header("Variables")]
    [SerializeField] private bool _isGamePaused = false;

    [SerializeField] private GameObject _lumberjack;
    [SerializeField] private GameObject _shaman;
    [SerializeField] private GameObject _engineer;
    [SerializeField] private GameObject _scout;
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    public List<GameObject> _playerGameObjectList = new List<GameObject>();

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
        _playerGameObjectList.Add(_shaman);
        _playerGameObjectList.Add(_engineer);
        _playerGameObjectList.Add(_scout);
    }

    private void Start()
    {
        //Instantiate(_lumberjack, _spawnPoints[0].transform.position, Quaternion.identity);
        //Instantiate(_scout, _spawnPoints[1].transform.position, Quaternion.identity);
        //Instantiate(_engineer, _spawnPoints[2].transform.position, Quaternion.identity);
        //Instantiate(_shaman, _spawnPoints[3].transform.position, Quaternion.identity);
    }


    public void SpawnPlayer()
    {

    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        //_playersList.Add(playerInput);

    }

    public void PauseGame()
    {
        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
        {
            Time.timeScale = 0f;
            Debug.Log("Game paused");
        }
        else if (!_isGamePaused)
        {
            Time.timeScale = 1f;
            Debug.Log("Game unpaused");
        }
    }
}
