using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request
{
    public Customer.CustomerType Type { get; set; }
    public string Name { get; set; }
    public Customer.CostumeColor Color { get; set; }
    public string Text { get; set; }
    public int Cost { get; set; }
}
