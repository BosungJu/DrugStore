using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorManager : MonoBehaviour
{
    private readonly float TopPos = 110f;
    [SerializeField] private RectTransform Prefab;
    
    [SerializeField] private Canvas canvas;
    //private static MonitorManager instance 
    
    private void Awake()
    {
        
    }

    void Start()
    {
        CustomerManager.AddCustomers();
        
        float pos = TopPos;
        
        for (int i = 5; i > 0; --i)
        {
            RectTransform rectTransform = Instantiate(Prefab, canvas.GetComponent<RectTransform>());
            rectTransform.anchoredPosition = new Vector2(3, pos);
            pos -= 80;
            rectTransform.GetChild(0).GetComponent<Text>().text = i + " " + CustomerManager.Customers[i - 1].Request.Title;
            rectTransform.GetChild(1).GetComponent<Text>().text = CustomerManager.Customers[i - 1].Request.Name;
        }
    }

    void Update()
    {
        
    }
}
