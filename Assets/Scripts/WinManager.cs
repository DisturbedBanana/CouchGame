using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _players = new List<GameObject>();

    void Start()
    {
        
    }

    private void CheckVictory()
    {
        if (_players.Count == 2)
        {
            GameManager.instance.Win();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _players.Add(other.gameObject);
            CheckVictory();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _players.Remove(other.gameObject);
        }
    }
}
