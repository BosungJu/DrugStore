using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestPaper : MonoBehaviour
{
    public static RequestPaper Instance { get; private set; }
    public List<Request> requests;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
