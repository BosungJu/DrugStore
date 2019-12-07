using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestButton : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log(RequestPaper.Instance.Requests.Count);
        if (RequestPaper.Instance.Requests.Count > 0) { Debug.Log(RequestPaper.Instance.Requests[0].Name); }
        RequestPaper.Instance.SetRequest();
        Debug.Log((RequestPaper.Instance != null).ToString());
    }

    private void OnDisable()
    {
        transform.parent.GetComponent<Button>().interactable = true;
    }
}
