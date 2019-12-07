using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugRoom : MonoBehaviour
{
    public GameObject[] syringe;

    void OnEnable()
    {
        for(int i = 0; i < syringe.Length; i++)
        {
            if (i < NoticeBoard.posion)
                syringe[i].SetActive(true);
            else
                syringe[i].SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
