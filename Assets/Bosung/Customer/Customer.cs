using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    #region Enum
    public enum CustomerType : int
    {
        Normal = 0, Mafia = 1, Government = 2
    }
    
    public enum CostumeColor : int
    {
        None = -1, Color0 = 0, Color1 = 1, Color2 = 2
    }
    #endregion
    
    public string Request { get; set; }
}
