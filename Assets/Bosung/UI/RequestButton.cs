using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestButton : MonoBehaviour
{
    public Sprite[] spr;
    public Image img;
    public Text txt;
    private void OnEnable()
    {
        GameManager.Instance.playclicksound();
        Debug.Log(RequestPaper.Instance.Requests.Count);
        if (RequestPaper.Instance.Requests.Count > 0) { Debug.Log(RequestPaper.Instance.Requests[0].Name); }
        RequestPaper.Instance.SetRequest();
        Debug.Log((RequestPaper.Instance != null).ToString());
    }

    private void Update()
    {
        if (txt.text.Equals("horror_mania"))
            img.sprite = spr[1];
        else if (txt.text.Equals("ik4rus"))
            img.sprite = spr[0];
        else if (txt.text.Equals("Mafia"))
            img.sprite = spr[3];
        else if (txt.text.Equals("betrayer"))
            img.sprite = spr[4];
        else if (txt.text.Equals("dreamholic"))
            img.sprite = spr[3];
        else
            img.sprite = spr[1];
    }

    private void OnDisable()
    {
        transform.parent.GetComponent<Button>().interactable = true;
    }
}
