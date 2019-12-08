using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTV : MonoBehaviour
{
    public GameObject CameraScene;
    public GameObject TalkUI;
    public GameObject NameUI;
    public GameObject Delnoise;
    public AudioSource text_s;

    public Image cctvimg;
    public Sprite[] spr;

    List<string> TalkList;

    string TalkText = "";

    private void OnEnable()
    {
        Delnoise.SetActive(GameManager.Instance.Day != 3);
    }

    public void OnClick(int a)
    {
        if (CameraScene.activeSelf) return;
            CameraScene.SetActive(true);
        StopCoroutine("printtalk");

        ParsingComment.Parse();

        int r = 0;
        if (GameManager.Instance.Day == 1)
        {
            if (a == 2)
                r = 0;
            else if (a == 4)
                r = 1;
        }
        else if (GameManager.Instance.Day == 2)
        {
            if (a == 2)
                r = 2;
            else if (a == 4)
                r = 3;
        }
        else if (GameManager.Instance.Day == 3)
        {
            if (a == 2)
                r = 4;
            else if (a == 4)
                r = 5;
            else if (a == 8)
                r = 6;
        }

        TalkList = ParsingComment.Commnents[r];
        
        ParsingRequest.Parse();

        NameUI.GetComponent<Text>().text = ParsingRequest.Requests[Random.Range(0, ParsingRequest.Requests.Count)].Name;

        TalkText = TalkList[0];

        StartCoroutine("printtalk");
        GameManager.Instance.playclicksound();
        int pr = 0;
        if (a == 2)
            pr = 0;
        else if (a == 4)
            pr = 1;
        else if (a == 8)
            pr = 2;
        cctvimg.sprite = spr[pr];


    }

    public void GoBack()
    {
        GameManager.Instance.playclicksound();
        if (CameraScene.activeSelf)
        {
            StopCoroutine("printtalk");
            CameraScene.SetActive(false);
        }
    }

    public void GoNext()
    {
        GameManager.Instance.isNight = !GameManager.Instance.isNight;
    }

    IEnumerator printtalk()
    {
        while (true)
        {
            for (int j = 0; j < TalkList.Count; j++)
            {
                TalkText = TalkList[j];
                for (int i = 0; i <= TalkText.Length; i++)
                {
                    TalkUI.GetComponent<Text>().text = TalkText.Substring(0, i);
                    text_s.Play();
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(2f);
        }
    }

 
}
