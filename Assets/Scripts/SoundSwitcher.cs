using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSwitcher : MonoBehaviour
{
    [SerializeField] private string currentLevelState;
    [SerializeField] private string oldLevelState;

    void Start()
    {
        CheckCurrentLevelState();
    }

    public void CheckCurrentLevelState()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentLevelState = "menu";
            Debug.Log("Current scene is a menu");
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            currentLevelState = "level";
            Debug.Log("Current scene is a level");
        }
        /*else if (SceneManager.GetActiveScene().buildIndex >= 14)
        {
            currentLevelState = "cutscene";
            Debug.Log("Current scene is a cinematic");
        }
        */

        if (AudioManager.instance.oldLevelStateStorage != currentLevelState)
        {
            if (currentLevelState == "menu")
            {
                AudioManager.instance.MusicAudioSource.clip = AudioManager.instance.DebugMusic;
                PlayMusic();
            }
            else if (currentLevelState == "level")
            {
                AudioManager.instance.MusicAudioSource.clip = AudioManager.instance.DebugMusic2;
                PlayMusic();
            }
            /*else if (currentLevelState == "cutscene")
            {
                AudioManager.instance.MusicAudioSource.clip = AudioManager.instance._backgroundCinematicMusic;
                PlayMusic();
            }*/
        }
        AudioManager.instance.oldLevelStateStorage = currentLevelState;
    }

    public void PlayMusic()
    {
        AudioManager.instance.MusicAudioSource.loop = true;
        AudioManager.instance.MusicAudioSource.Play();
    }
}
