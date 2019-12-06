using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ParsingRequest
{
    private static List<string> NameSet;
    public static List<Request> Requests { get; private set; }

    public static void ParseName()
    {
        Text text = Resources.Load<Text>(@"names.txt");
        foreach (string name in text.text.Split('\n'))
        {
            NameSet.Add(name);
        }
    }
    
    public static void Parse()
    {
        TextAsset text = Resources.Load<TextAsset>(@"Requests\Requests_" + GameManager.Instance.Day);

        string[] requests = text.text.Split('\n');
        
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
