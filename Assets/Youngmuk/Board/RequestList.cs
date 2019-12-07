using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestList : MonoBehaviour
{
    public GameObject menu;
    public GameObject main;
    public GameObject[] line = new GameObject[5];
    List<GameObject> list = new List<GameObject>();
    Vector3 start = new Vector3(0,-130,0);

    public void OnDisable()
    {
        for (int i = 0; i < line.Length; i++)
            line[i].SetActive(false);
    }

    public void OnEnable()
    {
        list.Clear();
        for (int i = 0; i < line.Length; i++)
            line[i].SetActive(false);


        for (int i = 0; i < 5; i++)
        {
            if (GameManager.Instance.Day == 1 && i == 0 && !NoticeBoard.solveList[i])
                list.Add(line[i]);
            else if (GameManager.Instance.Day == 2 && i == 1 && !NoticeBoard.solveList[i])
                list.Add(line[i]);
            else if (GameManager.Instance.Day == 2 && i == 2 && !NoticeBoard.solveList[i])
                list.Add(line[i]);
            else if (GameManager.Instance.Day == 3 && i == 3 && !NoticeBoard.solveList[i])
                list.Add(line[i]);
            else if (GameManager.Instance.Day == 3 && i == 4 && !NoticeBoard.solveList[i])
                list.Add(line[i]);
        }

        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<RectTransform>().localPosition = start - new Vector3(0,i * 40,0);
            list[i].transform.parent = transform;
            list[i].SetActive(true);
        }
    }

    public void GoProblem(int n)
    {
        NoticeBoard.request_n = n;
        main.SetActive(true);
        gameObject.SetActive(false);

    }
}
