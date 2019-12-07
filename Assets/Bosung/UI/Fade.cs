using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image image;
    public GameObject CancleButton;
    public static Fade Instance { get; private set; }

    private static readonly Color DownColor = new Color(0, 0, 0, 220f/255);
    private static readonly Color UpColor = new Color(0, 0, 0, 0);

    delegate void Func();

    private void Awake()
    {
        Instance = this;
    }

    public void DoFadeDown()
    {
        image.color = DownColor;

        CancleButton.SetActive(true);
    }

    public void DoFadeUp()
    {
        image.color = UpColor;
        
        CancleButton.SetActive(false);
    }

    public void DoFadeInOut()
    {
        
    }
}
