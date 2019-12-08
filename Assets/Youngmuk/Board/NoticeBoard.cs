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
    public GameObject sub;
    public GameObject btn;
    public static bool[] solveList = { false, false, false, false, false };

    public static int request_n = 0;
    public static int solve_n = 0;

    public static int posion = 0;

    public static bool[,] itemsday = 
    {
        { false, false, false, false, false, false, false, false , false, false, false, false },
        { false, false, false, false, false, false, false, false , false, false, false, false },
        { false, false, false, false, false, false, false, false, false, false, false, false  }
    };

    public static string[,] itemname =
    {
        { "건전지", "귀신", "중절모", "손전등", "빛", "가족사진", "아기", "아기귀신", "ㅁ", "ㅁ", "ㅁ", "ㅁ"},
        { "저울", "항아리", "양초", "깃털", "말", "태양", "PLX-360", "밀랍", "날개", "ㅁ", "ㅁ", "ㅁ"},
        { "거울", "나무", "피", "null", "눈", "무지개", "뿔", "인형", "목각인형", "ㅁ", "ㅁ", "ㅁ"}
    };

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

        sub.SetActive(true);
        gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        Init();
    }

    public void goback()
    {
        GameManager.Instance.playclicksound();
        sub.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Extraction()
    {
        for(int i = 0; i < 5; i++)
        {
            if (request_n == i && solve_n == 0 && !solveList[i])
            {
                solveList[i] = true;
                posion += 1;
                Text.GetComponent<Text>().text = "추출이 완료 되었습니다.";
                btn.SetActive(false);
                for (int j = 0; j < Item.Count; j++)
                {
                    Item[j].SetActive(false);
                    Item[j].GetComponent<HoldonEvent>().data = "";
                    Item[j].GetComponent<HoldonEvent>().text.text = "";
                }
            }
        }
    }

    public static bool FindGetItem(string s)
    {
        for (int i = 0; i < 12; i++)
        {
            if (s.Equals(itemname[GameManager.Instance.Day - 1, i]))
            {
                if (itemsday[GameManager.Instance.Day - 1, i])
                    return false;
                else
                {
                    itemsday[GameManager.Instance.Day - 1, i] = true;
                    return true;
                }
            }
        }
        return false;
    }

    void Init()
    {
        solve_n = 0;
        btn.SetActive(true);
        Debug.Log(ParsingRequest.Requests.Count + " " + request_n);

        TitleText.GetComponent<Text>().text = ParsingRequest.Requests[request_n].Name;
        Text.GetComponent<Text>().text = "";

        bool blank = false;
        string RequestText = ParsingRequest.Requests[request_n].Text;
        string Name = ParsingRequest.Requests[request_n].Name;
        string check_Text = "";

        int count = 0;

        for (int i = 0; i < Item.Count; i++)
        {
            Item[i].SetActive(false);
            Item[i].GetComponent<HoldonEvent>().data = "";
            Item[i].GetComponent<HoldonEvent>().text.text = "";
        }

        for (int i = 0; i < 12; i++)
        {
            if (itemsday[GameManager.Instance.Day - 1, i])
                count++;
        }

        for(int i = 0; i < count; i++)
        {
            int r = 0;
            do
            {
                r = Random.Range(0, Item.Count);
            } while (Item[r].activeSelf);
            Item[r].SetActive(true);
            Item[r].transform.position = ItemPos[i];

            Item[r].GetComponent<HoldonEvent>().text.color = Color.black;
            Item[r].GetComponent<HoldonEvent>().follow_mouse = false;
            Item[r].GetComponent<HoldonEvent>().set = false;
            Item[r].GetComponent<Image>().raycastTarget = true;
        }

        for (int i = 0; i < 12; i++)
        {
            if(itemsday[GameManager.Instance.Day - 1,i])
            {
                for (int j = 0; j < Item.Count; j++)
                {
                    if(Item[j].GetComponent<HoldonEvent>().data.Equals("") && Item[j].activeSelf)
                    {
                        Item[j].GetComponent<HoldonEvent>().data = itemname[GameManager.Instance.Day - 1, i];
                        Item[j].GetComponent<HoldonEvent>().text.text = itemname[GameManager.Instance.Day - 1, i];
                        break;
                    }
                }
            }
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
                solve_n++;

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
