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

    public Camera camera;

    private void Start()
    {
        text.text = data;
        GetComponent<BoxCollider2D>().size = new Vector2(text.text.Length * 30, 50);
        GetComponent<BoxCollider2D>().offset = new Vector2(text.text.Length * 15, 0);
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
            follow_mouse = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!set)
        {
            RaycastHit2D[] hit = Physics2D.BoxCastAll((Vector2)transform.position + GetComponent<BoxCollider2D>().offset, GetComponent<BoxCollider2D>().size, 0, Vector2.zero);
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].transform.name.Equals(data))
                {
                    //Debug.Log(collider.name);
                    transform.position = hit[i].transform.position + new Vector3(-0.5f,0,0);
                    GetComponent<HoldonEvent>().set = true;
                    hit[i].transform.gameObject.SetActive(false);
                    text.color = Color.green;
                    GetComponent<Image>().raycastTarget = false;
                    break;
                }
            }
            follow_mouse = false;
        }

    }
}