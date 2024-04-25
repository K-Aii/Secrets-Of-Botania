using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCanvas : MonoBehaviour
{
    private static KeepCanvas instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
