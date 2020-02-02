using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSingleton : MonoBehaviour
{
    public static CSingleton instance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
}
