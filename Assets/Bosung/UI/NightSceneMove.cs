using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSceneMove : MonoBehaviour
{
    public GameObject DreamTv;
    public GameObject NoticeBoard;
    public GameObject NavigationBar;
    public GameObject DrugRoom;

    private void OnEnable()
    {
        DreamTv.SetActive(true);
        NoticeBoard.SetActive(false);
        DrugRoom.SetActive(false);
    }

    public void DoMoveDrugRoom()
    {
        DrugRoom.SetActive(true);
        
        DreamTv.SetActive(false);
        NoticeBoard.SetActive(false);
        NavigationBar.SetActive(false);
    }

    public void DoMoveMonitors()
    {
        DreamTv.SetActive(true);
        NoticeBoard.SetActive(false);
        NavigationBar.SetActive(true);
        DrugRoom.SetActive(false);
    }
}
