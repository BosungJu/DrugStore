using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUpChange : MonoBehaviour
{
    public static PopUpChange Instance { get; private set; }
    
    public GameObject NightPopUp;
    public GameObject RequestPopUp;
    public GameObject DoorPopUp;
    public GameObject[] Result;

    private void Awake()
    {
        Instance = this;
    }
    
    public void OpenNight()
    {
        NightPopUp.SetActive(true);
    }

    public void OpenRequest()
    {
        RequestPopUp.SetActive(true);
        RequestPopUp.transform.parent.GetComponent<Button>().interactable = false;
    }

    public void OpenDoorPopUp()
    {
        DoorPopUp.SetActive(true);
    }

    public void OpenResult()
    {
        Result[GameManager.Instance.Day - 1].SetActive(true);
    }
    
    public void ClosePopUp()
    {
        if(GameManager.Instance.Day == 3)
            SceneManager.LoadScene("End");
        NightPopUp.SetActive(false);
        RequestPopUp.SetActive(false);
        DoorPopUp.SetActive(false);
        foreach (GameObject obj in Result)
        {
            obj.SetActive(false);
        }
    }
    
}
