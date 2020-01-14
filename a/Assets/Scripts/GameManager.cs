using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Day;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Day = 0;
        }
    }

}
