using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorManager : MonoBehaviour
{
    private readonly string NodePath = @"Prefabs\";
    
    //private static MonitorManager instance 
    
    private void Awake()
    {
        CustomerManager.AddCustomers();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
