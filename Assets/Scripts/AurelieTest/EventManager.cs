using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool _isEventActive;
    private int _idEvent;
    private float _duration;
    private float _time;

    [Header("UI Setup")]
    [SerializeField] private GameObject _timer;
    [SerializeField] private Image _timerFill;
    [SerializeField] private GameObject _BlizzardIcon;
    [SerializeField] private GameObject _ClearSkyIcon;
    //[SerializeField] private GameObject _NoEventIcon;
    [SerializeField] private Animator _BlizzardAnimator;
    [SerializeField] private Animator _ClearSkyAnimator;
    //[SerializeField] private Animator _NoEventAnimator;

    private void Start()
    {
        StartCoroutine(SpawnEvent());
    }

    private void Update()
    {
        if (!_isEventActive)
            return;

        _time -= Time.deltaTime;
        _timerFill.fillAmount = _time / _duration;

        if (_time < 0)
            _time = 0;
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
        _time = _duration;
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
            _timer.SetActive(true);
            _isEventActive = true;
            if (_idEvent == 0)
            {
                _timerFill.color = new Color32(20, 113, 185, 190);
                _BlizzardAnimator.SetBool("IsBlizzardStarting", false);
                _BlizzardAnimator.SetBool("IsBlizzardActive", true);
                Shader.SetGlobalFloat("isBlizzardActive", 1);
            }
            else if (_idEvent == 1)
            {
                _timerFill.color = new Color32(255, 179, 0, 190);
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
            Shader.SetGlobalFloat("isBlizzardActive", 0);
        }
        if (_idEvent == 1)
        {
            _ClearSkyAnimator.SetBool("IsClearSkyActive", false);
        }
        string eventName = _currentEvent.GetComponent<Event>().Name;
        Debug.Log($"{eventName} ended.");
        _timer.SetActive(false);
        _isEventActive = false;
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

    public void DeactivateIcon(GameObject icon)
    {
        icon.SetActive(false);
        //_NoEventIcon.SetActive(true);
    }
    
    //public void ActivateIcon(GameObject icon)
    //{
    //    icon.SetActive(true);
    //}
}
