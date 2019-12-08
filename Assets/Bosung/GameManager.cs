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
    public GameObject Street;
    public AudioSource click_sound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Day = 0;
            
        }
    }

    public void playclicksound()
    {
        click_sound.Play();
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
        Night.transform.GetChild(0).gameObject.SetActive(true);
        Night.transform.GetChild(1).gameObject.SetActive(false);
        Night.transform.GetChild(4).gameObject.SetActive(false);
        Night.transform.GetChild(5).gameObject.SetActive(false);
    }

    public void ChangeAfternoon()
    {
        isNight = false;
        PopUpChange.Instance.ClosePopUp();
        Street.SetActive(false);
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

    public void ShowStreet()
    {
        Night.transform.GetChild(0).gameObject.SetActive(false);
        Night.transform.GetChild(1).gameObject.SetActive(false);
        Night.transform.GetChild(5).gameObject.SetActive(false);
        Street.SetActive(true);
    }

}
