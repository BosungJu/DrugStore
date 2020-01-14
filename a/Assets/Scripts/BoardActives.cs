using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardActives : MonoBehaviour
{
    [SerializeField] private GameObject ListView;
    [SerializeField] private GameObject DetailView;
    
    private void OnEnable()
    {
        ListView.SetActive(true);
        DetailView.SetActive(false);
    }
    
}
