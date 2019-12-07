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
        None = 0, Color1 = 1, Color2 = 2, Color3 = 3, Color4 = 4, Color5 = 5
    }
    #endregion
    
    public CostumeColor[] Costumes = new CostumeColor[3];
    public Request Request;
    public CustomerType Type;
}
