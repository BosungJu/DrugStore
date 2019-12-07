using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParsingRequest : MonoBehaviour
{

    public TextAsset RequestTxt;
    static TextAsset RequestStatic;
    public static List<Request> Requests { get; private set; }

    private void Awake()
    {
        Requests = new List<Request>();
        RequestStatic = RequestTxt;
    }

    public static void Parse()
    {
        string[] requests = RequestStatic.text.Split('\n');
        
        /* 제목 이름 내용
         * 
         */
        
        foreach (string request in requests)
        {
            string[] req = request.Split('|');
            Request rq = new Request();

            rq.Title = req[0];
            rq.Name = req[1];
            rq.Text = req[2];
            
            rq.Type = rq.Name == "Mafia" ? Customer.CustomerType.Mafia : rq.Name == "Government" ? Customer.CustomerType.Government : Customer.CustomerType.Normal;
            
            Requests.Add(rq);
        }


    }
    
}
