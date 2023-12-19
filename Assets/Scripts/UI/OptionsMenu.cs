using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : Menu
{
    [SerializeField] private PlayerInputs _playerInputs;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        UIManager.instance.SetSelectedButton(UIManager.instance._optionsMenuCanvas, UIManager.instance._optionsMenuFirstSelectedButton);
    }
}
