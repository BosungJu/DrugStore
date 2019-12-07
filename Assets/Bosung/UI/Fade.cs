using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image image;
    public GameObject CancleButton;

    private static readonly Color DownColor = new Color(0, 0, 0, 220f/255);
    private static readonly Color UpColor = new Color(0, 0, 0, 0);

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

    /*private IEnumerable WaitForSec(float sec, delegate void func)
    {
        yield return new WaitForSeconds(sec);
        func();
    }*/
    
    public void DoFadeInOut()
    {
        
    }
}
