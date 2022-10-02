using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlPanel : MonoBehaviour
{
    private static MusicControlPanel _instance = null;
    public static MusicControlPanel Instance => _instance;


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }
        
        DontDestroyOnLoad(this);
        _instance = this;
    }
}
