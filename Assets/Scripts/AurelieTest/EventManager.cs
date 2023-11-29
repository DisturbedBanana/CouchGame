using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _events;

    [Space]
    [Header("Event Settings")]
    [Range(1f, 600f)]
    [SerializeField] private float _minInterval;
    [Range(1f, 600f)]
    [SerializeField] private float _maxInterval;
    [Range(1f, 600f)]
    [SerializeField] private float _minDuration;
    [Range(1f, 600f)]
    [SerializeField] private float _maxDuration;

    private GameObject _currentEvent;
    private float _duration;

    private void Start()
    {
        StartCoroutine(SpawnEvent());
    }

    private IEnumerator SpawnEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(RandomInterval());

            if (_currentEvent == null)
                StartCoroutine(StartEventRoutine());

            yield return new WaitForSeconds(10f);
            yield return new WaitForSeconds(_duration);

            if (_currentEvent != null)
                EndEvent();
        }
    }

    private float RandomInterval()
    {
        return Random.Range(_minInterval, _maxInterval);
    }

    private GameObject RandomEvent()
    {
        return _events[Random.Range(0, _events.Length)];
    }
    
    private float RandomDuration()
    {
        return Random.Range(_minDuration, _maxDuration);
    }

    private IEnumerator StartEventRoutine(int idEvent = 0)
    {
        PrestartEvent(idEvent);
        yield return new WaitForSeconds(10f);
        StartEvent();
    }

    private void PrestartEvent(int idEvent = 0)
    {
        switch (idEvent)
        {
            case 0:
                _currentEvent = RandomEvent();
                break;
            case 1:
                _currentEvent = _events[0];
                break;
            case 2:
                _currentEvent = _events[1];
                break;
            default:
                _currentEvent = RandomEvent();
                break;
        }
        _duration = RandomDuration();
        string eventName = _currentEvent.GetComponent<Event>().Name;
        Debug.Log($"{eventName} starting in 10s");
    }

    private void StartEvent()
    {
        if (_currentEvent != null)
        {
            string eventName = _currentEvent.GetComponent<Event>().Name;
            Debug.Log($"{eventName} started. Duration: {_duration}");
            _currentEvent = Instantiate(_currentEvent, transform.position, Quaternion.identity);
        }
    }

    private void EndEvent()
    {
        string eventName = _currentEvent.GetComponent<Event>().Name;
        Debug.Log($"{eventName} ended.");
        _currentEvent.GetComponent<Event>().EventEnd();
        Destroy(_currentEvent);
        _currentEvent = null;
    }

    public void DebugSpawnRandomEvent()
    {
        if (_currentEvent != null)
        {
            Debug.Log("There's already an event currently in progress");
            return;
        }

        StartCoroutine(StartEventRoutine());
    }

    public void DebugSpawnBlizzardEvent()
    {
        if (_currentEvent != null)
        {
            Debug.Log("There's already an event currently in progress");
            return;
        }

        StartCoroutine(StartEventRoutine(1));
    }
    
    public void DebugSpawnClearSkyEvent()
    {
        if (_currentEvent != null)
        {
            Debug.Log("There's already an event currently in progress");
            return;
        }

        StartCoroutine(StartEventRoutine(2));
    }

    public void DebugStopEvent()
    {
        if (_currentEvent == null)
        {
            Debug.Log("There's no event currently in progress.");
            return;
        }
        
        EndEvent();
    }
}
