using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomerManager
{
    public static List<Customer> Customers { get; private set; }
    private static readonly int[] MaxRequestCount = {3, 1, 2};
    
    public static void AddCustomers()
    {
        Customers = new List<Customer>();
        
        ParsingRequest.Parse();
        List<Request> requests = new List<Request>(ParsingRequest.Requests);
        List<Request> onRequests = new List<Request>();

        for (int i = 0; i < MaxRequestCount[GameManager.Instance.Day - 1]; ++i)
        {
            int random = Random.Range(0, requests.Count);
            
            onRequests.Add(requests[random]);
            requests.RemoveAt(random);
        }

        for (int i = 0; i < onRequests.Count; ++i)
        {
            Customer customer = new Customer();
            customer.Costumes = new Customer.CostumeColor[3]{(Customer.CostumeColor)Random.Range(0,6), (Customer.CostumeColor)Random.Range(1,6), (Customer.CostumeColor)Random.Range(1,6)};
            customer.Request = onRequests[i];
            customer.Type = onRequests[i].Type;
            Debug.Log(customer.Request.Text);
            Customers.Add(customer);
        }
        
    }
}
