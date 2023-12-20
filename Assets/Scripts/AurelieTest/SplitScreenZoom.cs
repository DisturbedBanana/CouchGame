using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenZoom : MonoBehaviour
{
    [SerializeField] private Transform[] _players;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minCamSize;
    [SerializeField] private float _maxCamSize;
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _distanceZoom;
    private Camera _cam;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        _maxDistance = MaxDistanceBetweenPlayers();

        float zoomFactor = 1f - Mathf.Clamp01(_maxDistance / _distanceZoom);
        float targetSize = Mathf.Lerp(_maxCamSize, _minCamSize, zoomFactor);

        _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, targetSize, Time.deltaTime * _zoomSpeed);
    }

    private float MaxDistanceBetweenPlayers()
    {
        float maxDistance = 0;

        for (int i = 0; i < _players.Length; i++)
        {
            for (int j = 0; j < _players.Length; j++)
            {
                float distance = Vector3.Distance(_players[i].position, _players[j].position);

                if (distance > maxDistance)
                    maxDistance = distance;
            }
        }

        return maxDistance;
    }

}
