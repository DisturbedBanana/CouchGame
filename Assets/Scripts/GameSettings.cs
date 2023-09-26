using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioMixer gameMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Space]
    [Header("Values")]
    [SerializeField] private float masterVolume;
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;
    
    void Start()
    {

    }

    public void SetMasterVolume()
    {
        masterVolume = masterSlider.value;
        gameMixer.SetFloat("MasterParam", Mathf.Log10(masterVolume) * 20);
    }

    public void SetMusicVolume()
    {
        musicVolume = musicSlider.value;
        gameMixer.SetFloat("MusicParam", Mathf.Log10(musicVolume) * 20);
    }

    public void SetSfxVolume()
    {
        sfxVolume = sfxSlider.value;
        gameMixer.SetFloat("SfxParam", Mathf.Log10(sfxVolume) * 20);
    }
}
