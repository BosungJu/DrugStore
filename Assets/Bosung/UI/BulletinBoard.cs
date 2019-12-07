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
    [SerializeField] private RectTransform detailView;
    public int nowIndex;
    
    private void Awake()
    {
        Instance = this;
        isOpenList = true;
        ListView.gameObject.SetActive(true);
        detailView.gameObject.SetActive(false);
    }

    public void OnClick(int index)
    {
        DetailView.Instance.DisableButton(index);
        RequestPaper.index = index;
        isOpenList = false;
        ListView.gameObject.SetActive(false);
        detailView.gameObject.SetActive(true);
        detailView.GetChild(2).GetComponent<Text>().text = CustomerManager.Customers[index].Request.Title;
        detailView.GetChild(3).GetComponent<Text>().text = "이름: " + CustomerManager.Customers[index].Request.Name;
        detailView.GetChild(4).GetComponent<Text>().text = CustomerManager.Customers[index].Request.Text;


        nowIndex = index;
    }

    public void BackOnClick()
    {
        isOpenList = true;
        ListView.gameObject.SetActive(true);
        detailView.gameObject.SetActive(false);
    }
}
