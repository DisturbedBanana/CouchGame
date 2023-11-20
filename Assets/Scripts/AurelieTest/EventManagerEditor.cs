using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventManager))]
public class EventManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EventManager eventManager = (EventManager)target;

        GUILayout.Space(10);

        EditorGUILayout.LabelField("Debug Tool");

        if (GUILayout.Button("Stop Current Event"))
            eventManager.DebugStopEvent();
    }
}
