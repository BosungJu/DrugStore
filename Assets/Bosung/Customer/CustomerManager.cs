using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomerManager
{
    public static List<Customer> Customers { get; private set; }
    private static readonly int MaxRequestCount = 5;
    public static void AddCustomers()
    {
        Customer customer;
        List<Request> requests = ParsingRequest.Requests;
        List<Request> onRequests = new List<Request>();
        
        for (int i = 0; i < MaxRequestCount; ++i)
        {
            int random = Random.Range(0, requests.Count);
            onRequests.Add(requests[random]);
            requests.RemoveAt(random);
        }

        foreach (Request request in onRequests)
        {
            customer = new Customer();
            customer.Request = request;
            customer.Type = request.Type;
        }
        
    }
}
