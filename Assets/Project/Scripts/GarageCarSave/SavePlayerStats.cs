using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SavePlayerStats
{
    public string NameCar = "Name";
    public int Money = 10;
    public int Idt = 10;
}
[System.Serializable]
public class AllCarTheGarage
{
    public AllCarTheGarage(string Name)
    {
        Name = this.Name;
    }
    public int Price;
    public string Name;
    public int Power;
    public int Speed;
    public int Fuel;
}
