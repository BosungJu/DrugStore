using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParsingRequest : MonoBehaviour
{
    public TextAsset name_txt;
    public TextAsset request_txt;

    [HideInInspector] public List<string> NameSet;
    public static List<Request> Requests { get; private set; }

    public void ParseName()
    {
        foreach (string name in name_txt.text.Split('\n'))
        {
            //Debug.Log(name);
            NameSet.Add(name);
        }
    }
    
    public void Parse()
    {
        string[] requests = request_txt.text.Split('\n');
        
        /*
         *type color request cost
         */
        
        foreach (string request in requests)
        {
            string[] req = request.Split(' ');
            Request rq = new Request();

            rq.Name = NameSet[Random.Range(0, NameSet.Count)];
            rq.Type = (Customer.CustomerType)int.Parse(req[0]);
            rq.Color = (Customer.CostumeColor)int.Parse(req[1]);
            rq.Text = req[2];
            rq.Cost = int.Parse(req[3]);
        }
    }
    
}
