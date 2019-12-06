using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParsingRequest
{
    public void Parse()
    {
        Text text = Resources.Load<Text>("Requests.txt");

        string[] requests = text.text.Split('\n');
        
        /*
         *type color request 
         */
        
        foreach (string request in requests)
        {
            string[] req = request.Split(' ');

            switch ((Customer.CustomerType)int.Parse(req[0]))
            {
                case Customer.CustomerType.Normal:
                    
                    break;
                case Customer.CustomerType.Mafia:
                    break;
                case Customer.CustomerType.Government:
                    break;
            }
        }

    }
    
}
