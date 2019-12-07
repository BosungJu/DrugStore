using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestButton : MonoBehaviour
{
    private void OnEnable()
    {
        if(RequestPaper.Instance != null)
            RequestPaper.Instance.SetRequest();
        Debug.Log((RequestPaper.Instance != null).ToString());
    }

    private void OnDisable()
    {
        transform.parent.GetComponent<Button>().interactable = true;
    }
}
