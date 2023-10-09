using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEditor.Rendering;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public static GameManager instance;

    [Space]
    [Header("Variables")]
    [SerializeField] private bool _isGamePaused = false;

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
