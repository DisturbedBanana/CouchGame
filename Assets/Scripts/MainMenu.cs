using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }
}
