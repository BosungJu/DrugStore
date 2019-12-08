using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomerManager
{
    public static List<Customer> Customers { get; private set; }
    private static readonly int[] MaxRequestCount = {1, 2, 2};
    private static bool isParse = false;

    public static void AddCustomers()
    {
        Customer customer;
        
        Customers = new List<Customer>();

        if (!isParse) ParsingRequest.Parse();
        isParse = true;
        List<Request> requests = new List<Request>(ParsingRequest.Requests);
        List<Request> onRequests = new List<Request>();
        
        Debug.Log(requests.Count);
        
        for (int i = 0; i < MaxRequestCount[GameManager.Instance.Day - 1]; ++i)
        {
            int index = GameManager.Instance.Day + i - 1; // 1(1) 2(2) 2(2)

            onRequests.Add(requests[index]);
            requests.RemoveAt(index);
        }

        for (int i = 0; i < onRequests.Count; ++i)
        {
            customer = new Customer();
            customer.Costumes = new Customer.CostumeColor[3]{(Customer.CostumeColor)Random.Range(0,6), (Customer.CostumeColor)Random.Range(1,6), (Customer.CostumeColor)Random.Range(1,6)};
            customer.Request = onRequests[i];
            customer.Type = onRequests[i].Type;
            
            Debug.Log(customer.Request.Text);
            Debug.Log(customer.Request.Title);

            Customers.Add(customer);
        }
        
    }
}
