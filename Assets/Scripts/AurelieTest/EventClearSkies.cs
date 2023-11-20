using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventClearSkies : Event
{
    public EventClearSkies()
    {
        Id = 2;
        Name = "Clear Skies";
    }

    private float _shrinkSpeedBase;

    private void Start()
    {
        _shrinkSpeedBase = FindObjectOfType<ExpandingFlame>().ShrinkSpeed;
        FindObjectOfType<ExpandingFlame>().ShrinkSpeed *= 2;
        // + résistance au froid +20%
        // + visibility improved in cold zone
    }

    public override void EventEnd()
    {
        FindObjectOfType<ExpandingFlame>().ShrinkSpeed = _shrinkSpeedBase;
    }
}
