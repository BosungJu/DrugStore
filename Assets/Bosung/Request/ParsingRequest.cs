using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParsingRequest : MonoBehaviour
{
    public TextAsset NameTxt;
    static TextAsset NameStatic;

    public TextAsset RequestTxt;
    static TextAsset RequestStatic;

    public static List<string> NameSet;
    public static List<Request> Requests { get; private set; }

    private void Awake()
    {
        NameStatic = NameTxt;
        RequestStatic = RequestTxt;
    }

    public static void ParseName()
    {
        NameSet = new List<string>();
        foreach (string name in NameStatic.text.Split('\n'))
        {
            NameSet.Add(name);
        }
    }
    
    public static void Parse()
    {
        string[] requests = RequestStatic.text.Split('\n');
        
        /*
         * type color title data
         */
        
        foreach (string request in requests)
        {
            string[] req = request.Split(' ');
            Request rq = new Request();

            rq.Name = NameSet[Random.Range(0, NameSet.Count)];
            rq.Type = (Customer.CustomerType)int.Parse(req[0]);
            rq.Color = (Customer.CostumeColor)int.Parse(req[1]);
            rq.Title = req[2];
            rq.Text = req[3];
        }
    }
    
}
