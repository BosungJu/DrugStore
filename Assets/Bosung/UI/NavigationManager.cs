using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public enum SceneType : int
    {
        BulletinBoard = 0, CCTV = 1, Extraction = 2
    }

    private string Time = "2019-12-";
    public SceneType NowScene;
    
    [SerializeField] private List<GameObject> prefabs;

    public void OnClick(int num)
    {
        NowScene = (SceneType)num;

        for (int i = 0; i < prefabs.Count; ++i)
        {
            if (i != (int)NowScene)
            {
                if (i == 0)
                {
                    Debug.Log(MonitorManager.Instance.Nodes);
                    MonitorManager.Instance.Nodes.ForEach(x => x.gameObject.SetActive(false));
                }
                prefabs[i].SetActive(false);
            }
            else
            {
                prefabs[i].SetActive(true);
                if (i == 0) MonitorManager.Instance.Nodes.ForEach(x => x.gameObject.SetActive(true));
            }
        }
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        MonitorManager.Instance.AddList();
        NowScene = SceneType.BulletinBoard;
        for (int i = 0; i < prefabs.Count; ++i)
        {
            if (i != (int)NowScene)
            {
                prefabs[i].SetActive(false);
            }
        }
    }
}
