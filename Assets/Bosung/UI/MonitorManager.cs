using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MonitorManager : MonoBehaviour
{
    public static MonitorManager Instance { get; private set; }
    
    private readonly float TopPos = -40f;
    [SerializeField] private RectTransform Prefab;
    public List<RectTransform> Nodes;
    [SerializeField] private RectTransform parent;
    
    private void Awake()
    {
        Instance = this;
    }

    public void AddList()
    {
        CustomerManager.AddCustomers();
        
        float pos = TopPos;
        Debug.Log(CustomerManager.Customers.Count);
        for (int i = CustomerManager.Customers.Count; i > 0; --i)
        {
            RectTransform rectTransform = Instantiate(Prefab, parent);
            rectTransform.anchoredPosition = new Vector2(3, pos);
            rectTransform.GetChild(0).GetComponent<Text>().text = i.ToString();
            rectTransform.GetChild(1).GetComponent<Text>().text = CustomerManager.Customers[i - 1].Request.Title;
            rectTransform.GetChild(2).GetComponent<Text>().text = CustomerManager.Customers[i - 1].Request.Name;
            
            Button button = rectTransform.GetComponent<Button>();
            int a = i - 1;
            button.onClick.AddListener(() => BulletinBoard.Instance.OnClick(a));
            
            pos -= 40;
            
            Nodes.Add(rectTransform);
        }
    }
}
