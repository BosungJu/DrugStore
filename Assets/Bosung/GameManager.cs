using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public bool isNight;
    public Text DayText;
    
    public int Day { get; private set; }

    public GameObject Afternoon;
    public GameObject Night;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Day = 0;
            
        }
    }

    private void Start()
    {
        ChangeAfternoon();
    }

    public void ChangeNight()
    {
        isNight = true;
        Night.SetActive(true);
        MonitorManager.Instance.Nodes.ForEach(x => Destroy(x.gameObject));
        MonitorManager.Instance.Nodes.Clear();
        if (!BulletinBoard.Instance.isOpenList) BulletinBoard.Instance.BackOnClick();
        PopUpChange.Instance.ClosePopUp();
        Fade.Instance.DoFadeUp();
        Afternoon.SetActive(false);
        PopUpChange.Instance.NightPopUp.transform.parent.gameObject.SetActive(false);
    }

    public void ChangeAfternoon()
    {
        isNight = false;
        Night.SetActive(false);
        Day++;
        DayText.text = "2019-12-" + (7 + Day);
        PopUpChange.Instance.NightPopUp.transform.parent.gameObject.SetActive(true);
        DetailView.AllreadyInputIndexs.Clear();
        RequestPaper.Instance.RequestReset();
        //DetailView.Instance.DisableButton();
        NavigationManager.Instance.Init();
        Afternoon.SetActive(true);
        Debug.Log("Day = " + Day);
    }

}
