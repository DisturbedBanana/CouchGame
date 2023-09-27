using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNDOL : MonoBehaviour
{
    public static DNDOL instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
