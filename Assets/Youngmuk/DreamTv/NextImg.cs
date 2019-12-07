using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextImg : MonoBehaviour
{
    public GameObject[] now_img;
    public GameObject[] next_img;

    public void nextimg()
    {
        foreach (GameObject emp in next_img)
            emp.SetActive(true);
        foreach (GameObject emp in now_img)
            emp.SetActive(false);
    }


    public void getItem(string s)
    {
        if(NoticeBoard.FindGetItem(s))
        {
            DreamTv.showtext(s + "를 획득했다.");
            DreamTv.showItem();
        }
    }
}
