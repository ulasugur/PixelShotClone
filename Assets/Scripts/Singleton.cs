using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton _instance;

    public static Singleton Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = FindObjectOfType<Singleton>();
                if (_instance==null)
                {
                    _instance = new GameObject("Game Manager").AddComponent<Singleton>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance!=null) Destroy(this);
        DontDestroyOnLoad(this);
    }
}
