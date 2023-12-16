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

    private ExpandingFlame _flame;
    private HeatManager _heatManager;
    private EventManager _eventManager;

    private float _shrinkSpeedBase;
    private float _lumDecBase;
    private float _scoDecBase;
    private float _shaDecBase;
    private float _engDecBase;

    private void Awake()
    {
        _flame = FindAnyObjectByType<ExpandingFlame>();
        _heatManager = FindAnyObjectByType<HeatManager>();
        _eventManager = FindAnyObjectByType<EventManager>();
    }

    private void Start()
    {
        _shrinkSpeedBase = _flame.ShrinkSpeed;
        _flame.ShrinkSpeed /= 2;

        _lumDecBase = _heatManager._lumberjackDecreaser;
        _scoDecBase = _heatManager._scoutDecreaser;
        _shaDecBase = _heatManager._shamanDecreaser;
        _engDecBase = _heatManager._engineerDecreaser;

        _heatManager._lumberjackDecreaser *= 1.5f;
        _heatManager._scoutDecreaser *= 1.5f;
        _heatManager._shamanDecreaser *= 1.5f;
        _heatManager._engineerDecreaser *= 1.5f;
    }

    public override void EventEnd()
    {
        _flame.ShrinkSpeed = _shrinkSpeedBase;

        _heatManager._lumberjackDecreaser = _lumDecBase;
        _heatManager._scoutDecreaser = _scoDecBase;
        _heatManager._shamanDecreaser = _shaDecBase;
        _heatManager._engineerDecreaser = _engDecBase;
    }
}
