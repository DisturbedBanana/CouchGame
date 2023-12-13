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

    private ExpandingFlame _flame;
    private HeatManager _heatManager;

    private float _shrinkSpeedBase;
    private float _lumDecBase;
    private float _scoDecBase;
    private float _shaDecBase;
    private float _engDecBase;

    private void Awake()
    {
        _flame = FindAnyObjectByType<ExpandingFlame>();
        _heatManager = FindAnyObjectByType<HeatManager>();
    }

    private void Start()
    {
        _shrinkSpeedBase = _flame.ShrinkSpeed;
        _flame.ShrinkSpeed *= 2;

        _lumDecBase = _heatManager._lumberjackDecreaser;
        _scoDecBase = _heatManager._scoutDecreaser;
        _shaDecBase = _heatManager._shamanDecreaser;
        _engDecBase = _heatManager._engineerDecreaser;

        _heatManager._lumberjackDecreaser *= 0.5f;
        _heatManager._scoutDecreaser *= 0.5f;
        _heatManager._shamanDecreaser *= 0.5f;
        _heatManager._engineerDecreaser *= 0.5f;
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
