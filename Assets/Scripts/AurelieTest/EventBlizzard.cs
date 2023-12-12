using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBlizzard : Event
{
    public EventBlizzard()
    {
        Id = 1;
        Name = "Blizzard";
    }

    private float _shrinkSpeedBase;

    private void Start()
    {
        _shrinkSpeedBase = FindObjectOfType<ExpandingFlame>().ShrinkSpeed;
        FindObjectOfType<ExpandingFlame>().ShrinkSpeed /= 2;
    }

    public override void EventEnd()
    {
        FindObjectOfType<ExpandingFlame>().ShrinkSpeed = _shrinkSpeedBase;
    }
}
