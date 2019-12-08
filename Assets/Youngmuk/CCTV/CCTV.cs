using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTV : MonoBehaviour
{
    public GameObject CameraScene;
    public GameObject TalkUI;
    public GameObject NameUI;

    public AudioSource text_s;

    public Image cctvimg;
    public Sprite[] spr;

    List<string> TalkList;

    string TalkText = "";

    public void OnClick(int a)
    {
        if (CameraScene.activeSelf) return;
            CameraScene.SetActive(true);
        StopCoroutine("printtalk");

        ParsingComment.Parse();

        int r = 0;
        if (GameManager.Instance.Day == 1)
            r = Random.Range(0, 2);
        else if (GameManager.Instance.Day == 2)
            r = Random.Range(2, 4);
        else if (GameManager.Instance.Day == 3)
            r = Random.Range(4, 7);
        TalkList = ParsingComment.Commnents[r];
        
        ParsingRequest.Parse();

        NameUI.GetComponent<Text>().text = ParsingRequest.Requests[Random.Range(0, ParsingRequest.Requests.Count)].Name;

        TalkText = TalkList[0];

        StartCoroutine("printtalk");
        GameManager.Instance.playclicksound();
        cctvimg.sprite = spr[Random.Range(0, spr.Length)];


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
        for(int j = 0; j < TalkList.Count; j++)
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
        yield return new WaitForSeconds(1f);
        CameraScene.SetActive(false);
    }

 
}
