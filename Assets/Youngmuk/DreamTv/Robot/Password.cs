using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public string s;
    public Text text;

    string answer = "1210";

    public GameObject[] now_img;
    public GameObject[] next_img;
    public GameObject[] next_img2;
    public AudioSource error_sound;
    public void nextimg(GameObject[] a, GameObject[] b)
    {
        GameManager.Instance.playclicksound();
        foreach (GameObject emp in a)
            emp.SetActive(true);
        foreach (GameObject emp in b)
            emp.SetActive(false);
    }

    private void OnEnable()
    {
        Cancle();
    }

    public void OK()
    {
        GameManager.Instance.playclicksound();
        if (s.Equals(answer))
        {
            if(!NoticeBoard.itemsday[1,6])
                nextimg(next_img, now_img);
            else
                nextimg(next_img2, now_img);
        }
        else
        {
            s = "ERROR";
            text.text = s;
            error_sound.Play();
        }
    }

    public void Cancle()
    {
        GameManager.Instance.playclicksound();
        s = "";
        text.text = s;
    }

    public void inputnum(string n)
    {
        GameManager.Instance.playclicksound();
        if (s.Length < 4)
            s += n;
        else if(s.Length > 4)
            s = n;
        text.text = s;
    }
}
