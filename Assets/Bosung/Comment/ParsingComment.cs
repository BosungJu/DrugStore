using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ParsingComment : MonoBehaviour
{
    public TextAsset Text;
    static TextAsset TextStatic;
    public static List<List<string>> Commnents { get; private set; }

    private void Awake()
    {
        TextStatic = Text;
    }

    public static void Parse()
    {
        Commnents = new List<List<string>>();
        string[] comments = TextStatic.text.Split('\n');
        
        /*
         * 띄어쓰기로 문장 구분
         */
        
        foreach (string comment in comments)
        {
            Commnents.Add(comment.Split('|').ToList());
        }
    }
}
