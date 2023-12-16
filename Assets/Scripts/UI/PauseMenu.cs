using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : Menu
{
    [SerializeField] private PlayerInputs _playerInputs;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        UIManager.instance.SetSelectedButton(UIManager.instance._pauseMenuCanvas, UIManager.instance._pauseMenuFirstSelectedButton);
    }
}
