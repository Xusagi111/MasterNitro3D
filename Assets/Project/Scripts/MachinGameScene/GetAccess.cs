using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAccess : MonoBehaviour // тестовый класс дл€ харакеристик, TODO позже убрать 
{
    int ConvertingStateChar = 100;
    
    public static GetAccess Instance { get; private set; }
    CarController Config;
    private void Start()
    {
        Config = GetComponent<CarController>();
        Instance = this;
        ConvertingStateMachin();
        //Config.MachinMaxRPM(20000);
    }
    public void ConvertingStateMachin()
    { 
        var a = NewCarTheGarage.stateMachin.Speed;
        if(a == 10)
        {
            var g = Config.GetMinRPM;
            Config.MachinMaxRPM((g / 2));
            //var b = a * 100;
        }
        if (a == 20)
        {
            var g = Config.GetMinRPM;
            Config.MachinMaxRPM(((g +350) / 2));
            //var b = a * 100;
        }

    }
}
