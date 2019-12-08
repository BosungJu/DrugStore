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
    private List<Transform> persons;
    
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

    public IEnumerator CreateCustomer()
    {
        foreach (Customer customer in CustomerManager.Customers)
        {
            persons.Add(Instantiate(person, transform));
            person.GetComponent<Person>().target = Pivot.gameObject;
            person.position = new Vector3(Random.Range(0, 1) == 0 ? -810 : 810, Pivot.position.y);
            while (!customer.Request.End) { yield return new WaitForEndOfFrame();}
        }
        
    }
}
