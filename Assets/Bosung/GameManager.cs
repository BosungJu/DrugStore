using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isNight;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
