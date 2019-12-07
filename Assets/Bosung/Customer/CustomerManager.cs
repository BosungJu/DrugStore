using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomerManager
{
    public static List<Customer> Customers { get; private set; }
    private static readonly int[] MaxRequestCount = {5, 2, 3};
    
    public static void AddCustomers()
    {
        Customers = new List<Customer>();
        
        ParsingRequest.Parse();
        List<Request> requests = ParsingRequest.Requests;
        List<Request> onRequests = new List<Request>();

        for (int i = 0; i < MaxRequestCount[GameManager.Instance.Day - 1]; ++i)
        {
            int random = Random.Range(0, requests.Count);
            Debug.Log(requests.Count + " " + random);
            onRequests.Add(requests[random]);
            requests.RemoveAt(random);
        }

        foreach (Request request in onRequests)
        {
            Customer customer = new Customer();
            customer.Costumes = new Customer.CostumeColor[3]{(Customer.CostumeColor)Random.Range(0,6), (Customer.CostumeColor)Random.Range(1,6), (Customer.CostumeColor)Random.Range(1,6)};
            customer.Request = request;
            customer.Type = request.Type;
            Customers.Add(customer);
        }
        
    }
}
