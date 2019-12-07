using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpChange : MonoBehaviour
{
    public GameObject NightPopUp;
    public GameObject RequestPopUp;
    
    public void OpenNight()
    {
        NightPopUp.SetActive(true);
    }

    public void OpenRequest()
    {
        RequestPopUp.SetActive(true);
    }

    public void ClosePopUp()
    {
        NightPopUp.SetActive(false);
        RequestPopUp.SetActive(false);
    }
    
}
