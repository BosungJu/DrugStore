using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class ParseRequests : MonoBehaviour
{
    public class Request
    {
        public int Number;
        public string Name;
        public string Title;
        public List<string> Text;

        public Request()
        {
            Number = 0;
            Name = "";
            Title = null;
            Text = null;
        }
    }

    public static ParseRequests Instance { get; private set; }
    public List<Request> Requests { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Parse(int day)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(@"Requests\Request" + day);
        
        // 한줄당 한 의뢰 의뢰내용 enter는 |로 처리 띄어쓰기는 _로 처리
        // Name Title Text
        
        string[] requests = textAsset.text.Split('\n');

        if (Requests == null) Requests = new List<Request>();
        else Requests.Clear();
        
        foreach (string request in requests)
        {
            string[] requestData = request.Split(' ');
            Request _request = new Request();
            
            _request.Name = requestData[0];
            _request.Title = requestData[1];
            _request.Text = new List<string>(requestData[2].Split('|'));
            
            Requests.Add(_request);
        }
    }
    
}
