using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextData : MonoBehaviour
{
    public string data;
    public Text text;
    private void Start()
    {
        text.text = data;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}
