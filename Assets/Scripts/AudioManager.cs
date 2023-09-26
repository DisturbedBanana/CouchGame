using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Button("Test Sfx")]
    private void TestSfxButton()
    {
        sfxAudioSource.clip = debugSfx;
        sfxAudioSource.Play();
    }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    [Space]
    [Header("References")]
    public static AudioManager instance;
    [SerializeField] private GameObject musicSourceObj;
    [SerializeField] private GameObject sfxSourceObj;

    [Space]
    [Header("Music Audio Clips")]
    [SerializeField] private AudioClip debugMusic;

    [Space]
    [Header("Sfx Audio Clips")]
    [SerializeField] private AudioClip debugSfx;

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

        musicSourceObj = GameObject.FindGameObjectWithTag("MusicSource");
        sfxSourceObj = GameObject.FindGameObjectWithTag("SfxSource");
        musicAudioSource = musicSourceObj.GetComponent<AudioSource>();
        sfxAudioSource = sfxSourceObj.GetComponent<AudioSource>();
    }

    void Start()
    {
        musicAudioSource.clip = debugMusic;
        musicAudioSource.Play();
    }

    void Update()
    {
        
    }
}
