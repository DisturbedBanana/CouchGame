using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeBehaviour : MonoBehaviour
{
    [Header("References")]
    public GameObject _ropeDown;
    public GameObject _ropeUp;
    public GameObject _rope;
    private Character _player;

    [Header("Checks")]
    public bool _ropeIsActivated;
    public bool _playerIsInZone;

    void Start()
    {
        _ropeIsActivated = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.GetComponent<Character>();

            if (_player.PlayerId == 4)
            {

            }
        }
    }
}
