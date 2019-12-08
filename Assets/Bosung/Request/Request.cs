using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request
{
    public string Name { get; set; }
    public Customer.CustomerType Type { get; set; }
    public string Title { get; set; }
    public Customer.CostumeColor Color { get; set; }
    public string Text { get; set; }
    public bool IsComplete { get; set; }
    public bool End { get; set; }
}
