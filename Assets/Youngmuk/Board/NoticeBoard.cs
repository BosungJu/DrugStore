using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeBoard : MonoBehaviour
{
    public GameObject TitleText;
    public GameObject Text;
    public GameObject BlankObject;
    public GameObject Pointer;
    float pointerx;
    void Start()
    {
        ParsingComment.Parse();
        ParsingRequest.ParseName();
        ParsingRequest.Parse();
        int random = Random.Range(0, ParsingRequest.Requests.Count);
        TitleText.GetComponent<Text>().text = ParsingRequest.Requests[random].Name;
        pointerx = Pointer.GetComponent<RectTransform>().position.x;

        Text.GetComponent<Text>().text = "";
        bool blank = false;
        string RequestText = ParsingRequest.Requests[random].Text;
        string check_Text = "";
        for (int i = 0; i < RequestText.Length; i++)
        {
            char emp = RequestText[i];

            if (emp == '`')
            {
                Text.GetComponent<Text>().text += '\n';
                Pointer.GetComponent<RectTransform>().position += new Vector3(0, -29, 0);
                Pointer.GetComponent<RectTransform>().position = new Vector3(pointerx, Pointer.GetComponent<RectTransform>().position.y, Pointer.GetComponent<RectTransform>().position.z);
            }
            else if (emp == '(')
            {
                check_Text = "";
                for (int j = i + 1; j < RequestText.Length; j++)
                {
                    if (RequestText[j] == ')')
                        break;
                    check_Text += RequestText[j];
                }
                GameObject BlankObj = Instantiate(BlankObject, Pointer.transform.position, Quaternion.identity);
                BlankObj.transform.parent = transform;
                BlankObj.transform.name = check_Text;
                Text.GetComponent<Text>().text += "_";
                blank = true;
                Pointer.GetComponent<RectTransform>().position += new Vector3(15, 0, 0);
            }
            else if (emp == ')')
            {
                Text.GetComponent<Text>().text += "_";
                blank = false;
                Pointer.GetComponent<RectTransform>().position += new Vector3(15, 0, 0);
            }
            else if (!blank)
            {
                Text.GetComponent<Text>().text += emp;
                if ((int)emp > 126)
                    Pointer.GetComponent<RectTransform>().position += new Vector3(30, 0, 0);
                else
                    Pointer.GetComponent<RectTransform>().position += new Vector3(15, 0, 0);
            }
            else
            {
                Text.GetComponent<Text>().text += "_";
                Pointer.GetComponent<RectTransform>().position += new Vector3(15, 0, 0);
            }


        }
    }

}
