using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailView : MonoBehaviour
{
    public static List<int> AllreadyInputIndexs = new List<int>();
    public static DetailView Instance { get; private set; }

    public static bool[] AllowRequest = { false, false, false, false, false }; 

    private void Awake()
    {
        Instance = this;
    }

    public void ReSet()
    {
        for (var i = 0; i < AllowRequest.Length; i++)
        {
            AllowRequest[i] = false;
        }
    }

    public void DisableButton(int n)
    {
        bool flag = AllowRequest[n];
        if (flag)
        {
            transform.GetChild(0).GetComponent<Image>().color = new Color(70f/255, 70f/255, 70f/255, 255f/255);
            transform.GetChild(0).GetComponent<Button>().interactable = false;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().color = new Color(255f/255, 255f/255, 255f/255, 255f/255);
            transform.GetChild(0).GetComponent<Button>().interactable = true;
        }
    }
}
