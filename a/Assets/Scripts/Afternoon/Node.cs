using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Text Number;
    public Text Title;
    public Text Name;

    public void SetData(ParseRequests.Request request)
    {
        Number.text = request.Number.ToString();
        Title.text = request.Title;
        Name.text = request.Name;
    }
}
