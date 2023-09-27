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

    #region Audio Sources Properties
    public AudioSource MusicAudioSource
    {
        get { return musicAudioSource; }
    }

    public AudioSource SfxAudioSource
    {
        get { return SfxAudioSource; }
    }
    #endregion

    [Space]
    [Header("References")]
    public static AudioManager instance;
    public string oldLevelStateStorage;
    [SerializeField] private GameObject musicSourceObj;
    [SerializeField] private GameObject sfxSourceObj;

    [Space]
    [Header("Music Audio Clips")]
    [SerializeField] private AudioClip debugMusic;
    [SerializeField] private AudioClip debugMusic2;

    #region Debug Music Property
    public AudioClip DebugMusic
    {
        get { return debugMusic; }
    }
    #endregion

    #region Debug Music Property
    public AudioClip DebugMusic2
    {
        get { return debugMusic2; }
    }
    #endregion

    [Space]
    [Header("Sfx Audio Clips")]
    [SerializeField] private AudioClip debugSfx;

    #region Debug Sfx Property
    public AudioClip DebugSfx
    {
        get { return debugSfx; }
    }
    #endregion

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
