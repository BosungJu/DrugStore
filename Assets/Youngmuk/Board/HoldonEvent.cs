using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class HoldonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    bool follow_mouse = false;

    public void Update()
    {
        if(follow_mouse)
            transform.position = Input.mousePosition;
    }


    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        follow_mouse = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        follow_mouse = false;
    }
}