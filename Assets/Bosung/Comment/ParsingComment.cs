using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class ParsingComment
{
    public static List<List<string>> Commnents { get; private set; }
    
    public static void Parse()
    {
        Commnents = new List<List<string>>();
        Text text = Resources.Load<Text>(@"Comments\Comment_" + GameManager.Instance.Day +".txt");

        string[] comments = text.text.Split('\n');
        
        /*
         * 띄어쓰기로 문장 구분
         */
        
        foreach (string comment in comments)
        {
            Commnents.Add(comment.Split(' ').ToList());
        }
    }
}
