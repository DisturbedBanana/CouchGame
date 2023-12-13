using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventIcon : MonoBehaviour
{
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = FindAnyObjectByType<EventManager>();
    }

    public void DeactivateIcon()
    {
        _eventManager.DeactivateIcon(gameObject);
    }
}
