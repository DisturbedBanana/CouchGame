using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    [Button("Test Sfx")]
    private void TestSfxButton()
    {
        sfxAudioSource.clip = debugSfx;
        sfxAudioSource.PlayOneShot(sfxAudioSource.clip);
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
    public AudioClip _winSound;
    public AudioClip _loseSound;

    [Space]
    [Header("UI Audio Clips")]
    public List<AudioClip> _uiNavSounds = new List<AudioClip>();
    public List<AudioClip> _uiConfirmBackSounds = new List<AudioClip>();

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

    public void PlayRandomUiSfx()
    {
        AudioClip _clipToPlay = _uiNavSounds[Random.Range(0, _uiNavSounds.Count)];

        sfxAudioSource.PlayOneShot(_clipToPlay);
    }

    public void PlayRandomUiCBSfx()
    {
        AudioClip _clipToPlay = _uiConfirmBackSounds[Random.Range(0, _uiConfirmBackSounds.Count)];

        sfxAudioSource.PlayOneShot(_clipToPlay);
    }

    public void PlaySoundOneShot(AudioClip soundToPlay)
    {
        sfxAudioSource.PlayOneShot(soundToPlay);
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayRandomUiSfx();
        }
    }

    public void OnConfirmBack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayRandomUiCBSfx();
        }
    }

}
