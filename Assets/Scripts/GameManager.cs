using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEditor.Rendering;

public class GameManager : MonoBehaviour
{
    [Button("TestButton")]
    private void TestButton()
    {
        Debug.Log("ouais");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
