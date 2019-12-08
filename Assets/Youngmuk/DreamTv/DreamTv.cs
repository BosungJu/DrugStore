using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamTv : MonoBehaviour
{
    public GameObject[] CameraScene;

    public bool[] TvOnOff;

    public GameObject[] Tv;

    public GameObject text;
    public static GameObject stext;

    public Text[] Hasitems;
    public static Text[] sHasitems = new Text[12];
    private void Awake()
    {
        for (int i = 0; i < 9; i++)
            Tv[i].SetActive(TvOnOff[i]);
        stext = text;
        for (int i = 0; i < Hasitems.Length; i++)
            sHasitems[i] = Hasitems[i];
    }

    private void OnEnable()
    {
        for (int i = 0; i < 9; i++)
            TvOnOff[i] = false;
        if (GameManager.Instance.Day == 1)
        {
            TvOnOff[1] = true;
            TvOnOff[3] = true;
        }
        else if (GameManager.Instance.Day == 2)
        {
            TvOnOff[0] = true;
            TvOnOff[2] = true;
        }
        else if (GameManager.Instance.Day == 3)
        {
            TvOnOff[4] = true;
            TvOnOff[6] = true;
            TvOnOff[8] = true;
        }
        for (int i = 0; i < 9; i++)
            Tv[i].SetActive(TvOnOff[i]);
        showtext("");
        showItem();
    }

    public static void showItem()
    {
        for (int i = 0; i < 12; i++)
        {
            if (NoticeBoard.itemsday[GameManager.Instance.Day - 1, i])
                sHasitems[i].text = NoticeBoard.itemname[GameManager.Instance.Day - 1, i];
            else if(sHasitems[i])
                sHasitems[i].text = "";
        }
    }

    public void OnClick(int a)
    {
        GameManager.Instance.playclicksound();
        if (CameraScene[a - 1].activeSelf) return;
        CameraScene[a - 1].SetActive(true);

    }

    public static void showtext(string s)
    {
        stext.GetComponent<Animator>().Rebind();
        stext.GetComponent<Text>().text = s;
    }

}
