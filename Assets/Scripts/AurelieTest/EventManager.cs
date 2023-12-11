using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _events;

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
    private int _idEvent;
    private float _duration;

    [Header("UI Setup")]
    [SerializeField] private GameObject _BlizzardIcon;
    [SerializeField] private GameObject _ClearSkyIcon;
    [SerializeField] private Animator _BlizzardAnimator;
    [SerializeField] private Animator _ClearSkyAnimator;

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
        _idEvent = Random.Range(0, _events.Length);
        return _events[_idEvent];
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
                _idEvent = 0;
                break;
            case 2:
                _currentEvent = _events[1];
                _idEvent = 1;
                break;
            default:
                _currentEvent = RandomEvent();
                break;
        }
        _duration = RandomDuration();
        string eventName = _currentEvent.GetComponent<Event>().Name;
        Debug.Log($"{eventName} starting in 10s");
        if (_idEvent == 0)
        {
            _BlizzardIcon.SetActive(true);
            _BlizzardAnimator.SetBool("IsBlizzardStarting", true);
        }
        if (_idEvent == 1)
        {
            _ClearSkyIcon.SetActive(true);
            _ClearSkyAnimator.SetBool("IsClearSkyStarting", true);
        }
    }

    private void StartEvent()
    {
        if (_currentEvent != null)
        {
            string eventName = _currentEvent.GetComponent<Event>().Name;
            Debug.Log($"{eventName} started. Duration: {_duration}");
            _currentEvent = Instantiate(_currentEvent, transform.position, Quaternion.identity);
            if (_idEvent == 0)
            {
                _BlizzardAnimator.SetBool("IsBlizzardStarting", false);
                _BlizzardAnimator.SetBool("IsBlizzardActive", true);
                Shader.SetGlobalFloat("isBlizzardActive", 1);
            }
            else if (_idEvent == 1)
            {
                _ClearSkyAnimator.SetBool("IsClearSkyStarting", false);
                _ClearSkyAnimator.SetBool("IsClearSkyActive", true);
            }
        }
    }

    private void EndEvent()
    {
        if (_idEvent == 0)
        {
            _BlizzardAnimator.SetBool("IsBlizzardActive", false);
            _BlizzardIcon.SetActive(false);
            Shader.SetGlobalFloat("isBlizzardActive", 0);
        }
        if (_idEvent == 1)
        {
            _ClearSkyAnimator.SetBool("IsClearSkyActive", false);
            _ClearSkyIcon.SetActive(false);
        }
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
