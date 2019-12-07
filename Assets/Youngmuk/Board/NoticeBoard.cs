using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeBoard : MonoBehaviour
{
    public GameObject TitleText;
    public GameObject Text;
    public GameObject BlankObject;
    public GameObject BlackPos;

    int solve_pro = 0;

    List<GameObject> list = new List<GameObject>();
    List<Vector2> ItemPos = new List<Vector2>();
    public List<GameObject> Item = new List<GameObject>();

    private void Awake()
    {
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
        Debug.Log(ParsingRequest.Requests.Count + " " + random);
        solve_pro = 0;
        TitleText.GetComponent<Text>().text = ParsingRequest.Requests[random].Name;
        Text.GetComponent<Text>().text = "";

        bool blank = false;
        string RequestText = ParsingRequest.Requests[random].Text;
        string Name = ParsingRequest.Requests[random].Name;
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

                list.Add(BlankObj);
                solve_pro++;

                Text.GetComponent<Text>().text += "_";
                blank = true;
            }
            else if (emp == ')')
            {
                Text.GetComponent<Text>().text += "_";
                blank = false;
            }
            else if (!blank)
            {
                Text.GetComponent<Text>().text += emp;
            }
            else
            {
                Text.GetComponent<Text>().text += "_";
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.position = BlackPos.transform.Find(Name).GetChild(i).transform.position;
        }
    }

}
