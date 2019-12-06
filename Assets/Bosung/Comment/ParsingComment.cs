using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ParsingComment : MonoBehaviour
{
    public TextAsset txt;

    public List<List<string>> Commnents { get; private set; }
    
    public void Parse()
    {
        Commnents = new List<List<string>>();
        string[] comments = txt.text.Split('\n');
        
        /*
         * 띄어쓰기로 문장 구분
         */
        
        foreach (string comment in comments)
        {
            Commnents.Add(comment.Split(' ').ToList());
        }
    }
}
