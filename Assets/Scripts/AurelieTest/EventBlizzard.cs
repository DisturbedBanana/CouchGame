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

    private void Start()
    {
        FindObjectOfType<ExpandingFlame>().ShrinkSpeed /= 2;
    }

    public override void EventEnd()
    {
        
    }
}
