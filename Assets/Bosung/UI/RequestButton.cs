using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestButton : MonoBehaviour
{
    public static RequestButton Instance { get; private set; }
    public Sprite[] spr;
    public Image img;
    public Text txt;
    public bool inDoorRoom { get; private set; }
    private void OnEnable()
    {
        GameManager.Instance.playclicksound();
        Debug.Log(RequestPaper.Instance.Requests.Count);
        if (RequestPaper.Instance.Requests.Count > 0) { Debug.Log(RequestPaper.Instance.Requests[0].Name); }
        RequestPaper.Instance.SetRequest();
        Debug.Log((RequestPaper.Instance != null).ToString());
    }

    public void InDoorRoom()
    {
        inDoorRoom = true;
        transform.parent.gameObject.SetActive(false);
    }

    public void OutDoorRoom()
    {
        inDoorRoom = false;
        transform.parent.gameObject.SetActive(true);
    }

    private void Awake()
    {
        Instance = this;
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
