using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public bool isNight;
    public int Day { get; private set; }
    public int ViewDay = 8;

    private void Awake()
    {
        if (Instance)
        {
            isNight = false;
            Instance = this;
            Day = 0;
        }
        else
        {
            Instance = this;
        }

        if (!isNight)
        {
            Day++;
        }
    }

    public void ChangeNight()
    {
        isNight = true;
    }
    
}
