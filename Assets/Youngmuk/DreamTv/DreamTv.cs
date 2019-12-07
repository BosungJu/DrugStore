using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamTv : MonoBehaviour
{
    public GameObject[] CameraScene;

    public bool[] TvOnOff;
    public GameObject[] Tv;

    private void Awake()
    {
        for (int i = 0; i < 9; i++)
            Tv[i].SetActive(TvOnOff[i]);
    }

    public void OnClick(int a)
    {
        if (CameraScene[a - 1].activeSelf) return;
        CameraScene[a - 1].SetActive(true);


    }

}
