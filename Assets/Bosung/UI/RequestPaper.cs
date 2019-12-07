using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestPaper : MonoBehaviour
{
    public static RequestPaper Instance { get; private set; }
    public GameObject Request;
    public int index;
    public List<Request> Requests;

    private void Awake()
    {
        Instance = this;
        Requests = new List<Request>();
        index = 0;
    }

    public void SetRequest()
    {
        Request.transform.GetChild(2).GetComponent<Text>().text = Requests[index].Name;
        //Request.transform.GetChild(3).GetComponent<Image>().sprite = null;
        Request.transform.GetChild(4).GetComponent<Text>().text = Requests[index].Text;
    }

    public void AddRequest()
    {
        Debug.Log(index);
        Requests.Add(CustomerManager.Customers[BulletinBoard.Instance.nowIndex].Request);
        DetailView.AllreadyInputIndexs.Add(BulletinBoard.Instance.nowIndex);
        DetailView.Instance.DisableButton();
    }
    
    public void GetNext()
    {
        if (index == 0 && Requests.Count == 1) { SetRequest(); }
        if (index + 1 >= Requests.Count) return;
        index++;
        SetRequest();
        Debug.Log(index);
    }

    public void GetPrev()
    {
        if (index == 0 && Requests.Count == 1) { SetRequest(); }
        if (index - 1 < 0) return;
        index--;
        SetRequest();
        Debug.Log(index);
    }
}
