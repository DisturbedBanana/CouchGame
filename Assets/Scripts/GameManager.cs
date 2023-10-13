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

    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private List<PlayerInput> _playersList = new List<PlayerInput>();

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

        _spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
    }

    private void Start()
    {
        //PlayerInputManager.instance.JoinPlayer(0, -1, null);
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
