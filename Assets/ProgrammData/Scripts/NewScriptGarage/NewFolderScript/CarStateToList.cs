using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarStateToList
{
    public List<CarsState> CubeOptionsList;

    public override string ToString()
    {
        string result = "";
        CubeOptionsList.ForEach(o =>
        {
            result += o.ToString();
        });
        return result;
    }
}
[System.Serializable]
public class CarsState
{
    public int IndexMachin;
    public string NameCar;
    public string levelCar;
    public int Power;
    public int Speed;
    public int Control;
    public int indexPowerLevel;
    public int indexSpeedLevel;
    public int indexControlLevel;
}