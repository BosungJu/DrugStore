using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestButton : MonoBehaviour
{
    private void OnEnable()
    {
        if(RequestPaper.Instance != null)
            RequestPaper.Instance.SetRequest();
        Debug.Log((RequestPaper.Instance != null).ToString());
    }
    
}
