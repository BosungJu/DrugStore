using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTV : MonoBehaviour
{
    public GameObject CameraScene;
    public GameObject talk_UI;
    public GameObject name_UI;
    public GameObject parsing;

    List<string> talklist;


    [TextArea]
    public string talk_txt = "";

    int txt_p;  //텍스트포인터
    int txt_n;  //텍스트순서

    float txt_time = 0;

    public void OnClick(int a)
    {
        if (CameraScene.activeSelf) return;
            CameraScene.SetActive(true);

        txt_p = 0;
        txt_n = 0;

        GameObject emp = Instantiate(parsing);
        ParsingComment ps = emp.GetComponent<ParsingComment>();
        ps.Parse();
        talklist = ps.Commnents[Random.Range(0, ps.Commnents.Count)];

        ParsingRequest pr = emp.GetComponent<ParsingRequest>();
        pr.ParseName();
        pr.Parse();

        name_UI.GetComponent<Text>().text = ParsingRequest.Requests[Random.Range(0, ParsingRequest.Requests.Count)].Name;


        talk_txt = talklist[txt_n];

        Destroy(emp);

    }

    public void Update()
    {
        if(CameraScene.activeSelf)
            print_txt();
        
    }

    void print_txt()
    {
        txt_time += Time.deltaTime;
        if (talk_txt.Length > txt_p)
        {
            if (txt_time > 0.1f)
            {
                txt_time = 0;
                txt_p++;
                talk_UI.GetComponent<Text>().text = talk_txt.Substring(0, talk_txt.Length < txt_p ? talk_txt.Length : txt_p);
            }
        }
        else
        {
            if (txt_time > 1f && talklist.Count - 1> txt_n)
            {
                txt_time = 0;
                txt_p = 0;
                txt_n++;
                talk_txt = talklist[txt_n];
            }
        }
    }
}
