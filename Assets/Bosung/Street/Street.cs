using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Street : MonoBehaviour
{
    public Image image;
    public Sprite sprite1;
    public Sprite sprite2;
    public Transform Pivot;
    public Transform person;
    public GameObject requestPaper;
    private List<Transform> persons;

    public GameObject Left;
    public GameObject Right;

    private static int count = 0;
    private Customer NowCustomer;

    private Coroutine coro;
    
    private void OnEnable()
    {
        PopUpChange.Instance.ClosePopUp();
        // RequestButton.Instance.InDoorRoom();
        coro = StartCoroutine("NeonSighAnimation");
        persons = new List<Transform>();
        StartCoroutine("CreateCustomer");
    }

    private void OnDisable()
    {
        // RequestButton.Instance.OutDoorRoom();
        StopCoroutine(coro);
        persons.ForEach(x => Destroy(x.gameObject));
        persons.Clear();
    }

    private IEnumerator NeonSighAnimation()
    {
        while (true)
        {
            image.sprite = sprite1;
            yield return new WaitForSeconds(Random.Range(0.0f, 0.5f));
            image.sprite = sprite2;
            yield return new WaitForSeconds(Random.Range(0.0f, 0.5f));
        }
    }

    public void Give()
    {
        NowCustomer.Request.End = true;
        NowCustomer.Request.IsComplete = true;
        requestPaper.SetActive(false);
    }

    public void DoNotGive()
    {
        NowCustomer.Request.End = true;
        NowCustomer.Request.IsComplete = false;
        requestPaper.SetActive(false);
    }

    public IEnumerator CreateCustomer()
    {
        int count = -1;

        person.GetComponent<Person>().target = Pivot.gameObject;
        
        foreach (Customer customer in CustomerManager.Customers)
        {
            int direction = Random.Range(0, 2);
            NowCustomer = customer;
            requestPaper.SetActive(false);
            count++;
            persons.Add(Instantiate(person, new Vector3((direction == 0 ? -810f : 810f) / 100, Pivot.position.y, 0), Quaternion.identity, transform));
            Debug.Log(persons[count].position);
            while (!persons[count].GetComponent<Person>().arrive) { yield return new WaitForEndOfFrame();}

            if (NoticeBoard.solveList[count])
            {
                requestPaper.SetActive(true);
                requestPaper.transform.GetChild(0).GetComponent<Text>().text = customer.Request.Name;
                requestPaper.transform.GetChild(1).GetComponent<Text>().text = customer.Request.Text;
            }
            else
            {
                DoNotGive();
            }

            while (!customer.Request.End)  {  yield return  new WaitForEndOfFrame(); }

            persons[count].GetComponent<Person>().target = direction == 0 ? Right : Left;
            persons[count].GetComponent<Person>().arrive = false;
            
            count++;
        }

        yield return new WaitForSeconds(0.5f);
        
        PopUpChange.Instance.OpenResult();
        Fade.Instance.DoFadeDown();
        while (Fade.Instance.CancleButton.activeSelf)
        {
            yield return new WaitForEndOfFrame();
        }
        GameManager.Instance.ChangeAfternoon();
    }
}
