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
    public static Text[] sHasitems;
    private void Awake()
    {
        for (int i = 0; i < 9; i++)
            Tv[i].SetActive(TvOnOff[i]);
        stext = text;
        sHasitems = new Text[Hasitems.Length];
        for (int i = 0; i < Hasitems.Length; i++)
            sHasitems[i] = Hasitems[i];
    }

    private void OnEnable()
    {
        showtext("");
        showItem();
    }

    public static void showItem()
    {
        for (int i = 0; i < 8; i++)
        {
            if (NoticeBoard.itemsday[GameManager.Instance.Day - 1, i])
                sHasitems[i].text = NoticeBoard.itemname[GameManager.Instance.Day - 1, i];
            else
                sHasitems[i].text = "";
        }
    }

    public void OnClick(int a)
    {
        if (CameraScene[a - 1].activeSelf) return;
        CameraScene[a - 1].SetActive(true);

    }

    public static void showtext(string s)
    {
        stext.GetComponent<Animator>().Rebind();
        stext.GetComponent<Text>().text = s;
    }

}
