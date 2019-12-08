using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class HoldonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [HideInInspector] public bool follow_mouse = false;
    [HideInInspector] public bool set = false;

    public string data;
    public Text text;

    private void Start()
    {
        text.text = data;
       // GetComponent<BoxCollider2D>().offset = new Vector2(text.text.Length * 8, 0);
        GetComponent<BoxCollider2D>().size = new Vector2(text.text.Length * 16, 50);
        GetComponent<RectTransform>().sizeDelta = new Vector2(text.text.Length * 16, 50);
    }

    public void Update()
    {
        if(follow_mouse)
            GetComponent<RectTransform>().localPosition = Input.mousePosition - new Vector3(960,540,0);
    }


    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!set)
        {
            follow_mouse = true;
            GameManager.Instance.playclicksound();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!set)
        {
            RaycastHit2D[] hit = Physics2D.BoxCastAll((Vector2)transform.position + GetComponent<BoxCollider2D>().offset, new Vector2(0.1f, 0.1f), 0, Vector2.zero);
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].transform.name.Equals(data))
                {
                    GameManager.Instance.playclicksound();
                    transform.position = hit[i].transform.position;
                    NoticeBoard.solve_n--;
                    GetComponent<HoldonEvent>().set = true;
                    hit[i].transform.gameObject.SetActive(false);
                    text.color = Color.green;
                    GetComponent<Image>().raycastTarget = false;
                    break;
                }
            }

            if(data.Equals("아기"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent< HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("귀신"))
                    {
                        data = "아기귀신";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("귀신"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("아기"))
                    {
                        data = "아기귀신";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("양초"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("태양"))
                    {
                        data = "밀랍";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("태양"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("양초"))
                    {
                        data = "밀랍";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("깃털"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("밀랍"))
                    {
                        data = "날개";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("밀랍"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("깃털"))
                    {
                        data = "날개";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("무지개"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("뿔"))
                    {
                        data = "유니콘";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("뿔"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("무지개"))
                    {
                        data = "유니콘";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("피"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("목각인형"))
                    {
                        data = "저주";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("목각인형"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("피"))
                    {
                        data = "저주";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("저주"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("인형"))
                    {
                        data = "저주인형";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("인형"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("저주"))
                    {
                        data = "저주인형";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("저주인형"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("뿔"))
                    {
                        data = "부두술";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            else if (data.Equals("뿔"))
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.gameObject.GetComponent<HoldonEvent>() && hit[i].transform.gameObject.GetComponent<HoldonEvent>().data.Equals("저주인형"))
                    {
                        data = "부두술";
                        text.text = data;
                        hit[i].transform.gameObject.SetActive(false);
                        GameManager.Instance.playclicksound();
                        break;
                    }
                }
            }
            follow_mouse = false;
        }

    }
}