using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NavigationBar : MonoBehaviour
{
    // 버튼에서 index get해옴
    [SerializeField] private List<GameObject> Properties;


    public void ShowView(int index)
    {
        for (int i = 0; i < Properties.Count; ++i)
        {
            Properties[i].SetActive(i == index);   
        }
    }
    
}
