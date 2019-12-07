using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpChange : MonoBehaviour
{
    public static PopUpChange Instance { get; private set; }
    
    public GameObject NightPopUp;
    public GameObject RequestPopUp;
    
    public void OpenNight()
    {
        NightPopUp.SetActive(true);
    }

    public void OpenRequest()
    {
        RequestPopUp.SetActive(true);
        RequestPopUp.transform.parent.GetComponent<Button>().interactable = false;
    }

    public void ClosePopUp()
    {
        NightPopUp.SetActive(false);
        RequestPopUp.SetActive(false);
    }
    
}
