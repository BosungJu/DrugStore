using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextImg : MonoBehaviour
{
    public GameObject[] now_img;
    public GameObject[] next_img;

    public void nextimg()
    {
        GameManager.Instance.playclicksound();
        foreach (GameObject emp in next_img)
            emp.SetActive(true);
        foreach (GameObject emp in now_img)
            emp.SetActive(false);
    }


    public void getItem(string s)
    {
        if(NoticeBoard.FindGetItem(s))
        {
            GameManager.Instance.playclicksound();
            DreamTv.showtext(s + "를 획득했다.");
            DreamTv.showItem();
        }
    }
}
