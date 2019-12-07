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
    public float font_y = 30;

    Vector2 pointerxy;

    List<GameObject> list = new List<GameObject>();
    List<Vector2> ItemPos = new List<Vector2>();
    public List<GameObject> Item = new List<GameObject>();

    private void Awake()
    {
        pointerxy = Pointer.GetComponent<RectTransform>().localPosition;
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
        ParsingComment.Parse();
        ParsingRequest.Parse();

        int random = Random.Range(0, ParsingRequest.Requests.Count);
        Debug.Log(ParsingRequest.Requests.Count + " " +random);
        solve_pro = 0;
        TitleText.GetComponent<Text>().text = ParsingRequest.Requests[random].Name;
        Text.GetComponent<Text>().text = "";
        Pointer.GetComponent<RectTransform>().localPosition = pointerxy;
        bool blank = false;
        string RequestText = ParsingRequest.Requests[random].Text;
        string check_Text = "";
        bool set_pointer_x = false;
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
            if(!set_pointer_x)
            {
                int line_len = 0;
                for (int j = i; j < RequestText.Length; j++)
                {
                    if (RequestText[j] == '`')
                        break;
                    line_len++;
                }
                Pointer.GetComponent<RectTransform>().localPosition = new Vector3(pointerxy.x - font_x*line_len/2f, Pointer.GetComponent<RectTransform>().localPosition.y, 0);
                set_pointer_x = true;
            }
            if (emp == '`')
            {
                Text.GetComponent<Text>().text += '\n';
                Pointer.GetComponent<RectTransform>().localPosition -= new Vector3(0, font_y, 0);
               // Pointer.GetComponent<RectTransform>().localPosition = new Vector3(pointerxy.x, Pointer.GetComponent<RectTransform>().localPosition.y, Pointer.GetComponent<RectTransform>().localPosition.z);
                set_pointer_x = false;
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
                GameObject BlankObj = Instantiate(BlankObject);
                BlankObj.SetActive(true);
                BlankObj.transform.parent = transform;
                BlankObj.transform.name = check_Text;
                BlankObj.transform.localPosition = new Vector3(Pointer.transform.localPosition.x, Pointer.transform.localPosition.y, 0);
                list.Add(BlankObj);
                solve_pro++;
                Text.GetComponent<Text>().text += "_";
                blank = true;
                Pointer.GetComponent<RectTransform>().localPosition += new Vector3(font_x, 0, 0);
            }
            else if (emp == ')')
            {
                Text.GetComponent<Text>().text += "_";
                blank = false;
                Pointer.GetComponent<RectTransform>().localPosition += new Vector3(font_x, 0, 0);
            }
            else if (!blank)
            {
                Text.GetComponent<Text>().text += emp;
                if ((int)emp > 126)
                    Pointer.GetComponent<RectTransform>().localPosition += new Vector3(font_x*2, 0, 0);
                else
                    Pointer.GetComponent<RectTransform>().localPosition += new Vector3(font_x, 0, 0);
            }
            else
            {
                Text.GetComponent<Text>().text += "_";
                Pointer.GetComponent<RectTransform>().localPosition += new Vector3(font_x, 0, 0);
            }


        }
    }

}
