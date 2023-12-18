using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinMenu : Menu
{
    [SerializeField] private PlayerInputs _playerInputs;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        UIManager.instance.SetSelectedButton(UIManager.instance._winCanvas, UIManager.instance._winMenuFirstSelectedButton);
    }
}