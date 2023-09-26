using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNDOL : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
