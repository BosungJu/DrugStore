using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTV : MonoBehaviour
{
    public GameObject CameraScene;
    public GameObject TalkUI;
    public GameObject NameUI;

    List<string> TalkList;

    string TalkText = "";

    public void OnClick(int a)
    {
        if (CameraScene.activeSelf) return;
            CameraScene.SetActive(true);

        ParsingComment.Parse();

        TalkList = ParsingComment.Commnents[Random.Range(0, ParsingComment.Commnents.Count)];

        //ParsingRequest.ParseName();
       // ParsingRequest.Parse();

        NameUI.GetComponent<Text>().text = "철수";

        TalkText = TalkList[0];

        StartCoroutine(printtalk());

    }

    IEnumerator printtalk()
    {
        for(int j = 0; j < TalkList.Count; j++)
        {
            TalkText = TalkList[j];
            for (int i = 0; i <= TalkText.Length; i++)
            {
                TalkUI.GetComponent<Text>().text = TalkText.Substring(0, i);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

 
}
