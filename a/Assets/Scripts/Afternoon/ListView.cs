using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListView : MonoBehaviour
{
    [SerializeField] private GameObject Node;
    
    private List<GameObject> Nodes;
    [SerializeField] private GameObject Attribute;
    
    private void CreateNode(int Number, ParseRequests.Request request)
    {
        Nodes.Add(Instantiate(Node, Attribute.transform));
        Nodes[Nodes.Count - 1].GetComponent<Node>().SetData(request);
    }

    private void OnEnable()
    {
        ParseRequests.Instance.Parse(GameManager.Instance.Day);

        if (Nodes == null)
        {
            Nodes = new List<GameObject>();
        }
        else
        {
            while (Nodes.Count != 0)
            {
                Destroy(Nodes[0]);
                Nodes.RemoveAt(0);
            }
        }
        
        for (int i = ParseRequests.Instance.Requests.Count - 1; i >= 0 ; --i) 
        {
            CreateNode(i + 1, ParseRequests.Instance.Requests[i]);
        }
    }
}
