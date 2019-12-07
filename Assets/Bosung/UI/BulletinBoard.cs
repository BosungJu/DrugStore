using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletinBoard : MonoBehaviour
{
    public static BulletinBoard Instance { get; private set; }

    public bool isOpenList { get; private set; }
    
    [SerializeField] private RectTransform ListView;
    [SerializeField] private RectTransform DetailView;
    public int nowIndex;
    
    private void Awake()
    {
        Instance = this;
        isOpenList = true;
        ListView.gameObject.SetActive(true);
        DetailView.gameObject.SetActive(false);
    }

    public void OnClick(int index)
    {
        Debug.Log(index);
        isOpenList = false;
        ListView.gameObject.SetActive(false);
        DetailView.gameObject.SetActive(true);
        DetailView.GetChild(2).GetComponent<Text>().text = CustomerManager.Customers[index].Request.Title;
        DetailView.GetChild(3).GetComponent<Text>().text = "이름: " + CustomerManager.Customers[index].Request.Name;
        DetailView.GetChild(4).GetComponent<Text>().text = CustomerManager.Customers[index].Request.Text;
        nowIndex = index;
    }

    public void BackOnClick()
    {
        isOpenList = true;
        ListView.gameObject.SetActive(true);
        DetailView.gameObject.SetActive(false);
    }
}
