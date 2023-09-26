using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    [Space]
    [Header("References")]
    public static AudioManager instance;
    [SerializeField] private GameObject musicSourceObj;
    [SerializeField] private GameObject sfxSourceObj;

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
        
    }

    void Update()
    {
        
    }
}
