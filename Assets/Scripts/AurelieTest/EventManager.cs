using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _events;

    [Space]
    [Header("Event Settings")]
    [Range(60f, 600f)]
    [SerializeField] private float _minInterval;
    [Range(60f, 600f)]
    [SerializeField] private float _maxInterval;
    [Range(60f, 600f)]
    [SerializeField] private float _minDuration;
    [Range(60f, 600f)]
    [SerializeField] private float _maxDuration;

    private Event _currentEvent;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void NextEvent()
    {

    }
}
