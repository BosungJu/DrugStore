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

    int solve_pro = 0;

    public float font_x = 30;

    Vector2 pointerxy;

    List<GameObject> list = new List<GameObject>();
    List<Vector2> ItemPos = new List<Vector2>();
    public List<GameObject> Item = new List<GameObject>();

    private void Awake()
    {
        ParsingComment.Parse();
        ParsingRequest.ParseName();
        ParsingRequest.Parse();

        pointerxy = Pointer.GetComponent<RectTransform>().position;
        for (int i = 0; i < Item.Count; i++)
            ItemPos.Add(Item[i].transform.position);
    }

    private void OnDisable()
    {
        for (int i = 0; i < list.Count; i++)
            Destroy(list[i]);
        list.Clear();
    }

    private void OnEnable()
    {
        Init();
    }

    public void Extraction()
    {
        if(solve_pro == 0)
        {

        }
    }

    void Init()
    {
        int random = Random.Range(0, ParsingRequest.Requests.Count);
        solve_pro = 0;
        TitleText.GetComponent<Text>().text = ParsingRequest.Requests[random].Name;
        Text.GetComponent<Text>().text = "";
        Pointer.GetComponent<RectTransform>().position = pointerxy;
        bool blank = false;
        string RequestText = ParsingRequest.Requests[random].Text;
        string check_Text = "";

        for (int i = 0; i < Item.Count; i++)
        {
            Item[i].transform.position = ItemPos[i];
            Item[i].GetComponent<HoldonEvent>().text.color = Color.black;
            Item[i].GetComponent<HoldonEvent>().follow_mouse = false;
            Item[i].GetComponent<HoldonEvent>().set = false;
            Item[i].GetComponent<Image>().raycastTarget = true;
        }

        for (int i = 0; i < RequestText.Length; i++)
        {
            char emp = RequestText[i];

            if (emp == '`')
            {
                Text.GetComponent<Text>().text += '\n';
                Pointer.GetComponent<RectTransform>().position += new Vector3(0, -29, 0);
                Pointer.GetComponent<RectTransform>().position = new Vector3(pointerxy.x, Pointer.GetComponent<RectTransform>().position.y, Pointer.GetComponent<RectTransform>().position.z);
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
                GameObject BlankObj = Instantiate(BlankObject, Camera.main.ScreenToWorldPoint(new Vector3(Pointer.transform.position.x + 710, Pointer.transform.position.y + 460, 0)), Quaternion.identity);
                BlankObj.transform.parent = transform;
                BlankObj.transform.name = check_Text;
                BlankObj.transform.position = new Vector3(BlankObj.transform.position.x, BlankObj.transform.position.y, 0);
                list.Add(BlankObj);
                solve_pro++;
                Text.GetComponent<Text>().text += "_";
                blank = true;
                Pointer.GetComponent<RectTransform>().position += new Vector3(font_x/2f, 0, 0);
            }
            else if (emp == ')')
            {
                Text.GetComponent<Text>().text += "_";
                blank = false;
                Pointer.GetComponent<RectTransform>().position += new Vector3(font_x / 2f, 0, 0);
            }
            else if (!blank)
            {
                Text.GetComponent<Text>().text += emp;
                if ((int)emp > 126)
                    Pointer.GetComponent<RectTransform>().position += new Vector3(font_x, 0, 0);
                else
                    Pointer.GetComponent<RectTransform>().position += new Vector3(font_x / 2f, 0, 0);
            }
            else
            {
                Text.GetComponent<Text>().text += "_";
                Pointer.GetComponent<RectTransform>().position += new Vector3(font_x / 2f, 0, 0);
            }


        }
    }

}
