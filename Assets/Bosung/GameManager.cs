using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static bool isInit;
    public bool isNight { get; private set; }
    public int Day { get; private set; }

    private void Awake()
    {
        if (!isInit)
        {
            Instance = this;
            isInit = true;
            Day = 1;
        }
    }

}
