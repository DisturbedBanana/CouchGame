using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Event _currentEvent;
    private float _duration;

    private void Start()
    {
        StartCoroutine(SpawnEvent());
    }

    private IEnumerator SpawnEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minInterval, _maxInterval));

            if (_currentEvent == null)
            {
                _currentEvent = _events[Random.Range(0, _events.Length)].GetComponent<Event>();
                _duration = Random.Range(_minDuration, _maxDuration);
                Debug.Log($"Starting {_currentEvent.Name} in 10 seconds.");
                yield return new WaitForSeconds(10f);
                Debug.Log($"{_currentEvent.Name} started. Duration: {_duration}");
                Instantiate(_currentEvent, transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(_duration);

            if (_currentEvent != null)
            {
                Destroy(_currentEvent);
                _currentEvent = null;
            }
        }
    }
}
