using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public bool isNight;
    
    public int Day { get; private set; }
    public int ViewDay = 8;

    public GameObject Afternoon;
    public GameObject Night;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Day = 0;
            ChangeAfternoon();
        }
    }

    public void ChangeNight()
    {
        isNight = true;
        Night.SetActive(true);
        Afternoon.SetActive(false);
        
    }

    public void ChangeAfternoon()
    {
        isNight = false;
        Night.SetActive(false);
        Night.SetActive(false);
        Day++;
    }

}
