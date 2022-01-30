using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAccess : MonoBehaviour // тестовый класс дл€ харакеристик, TODO позже убрать 
{
    AllCarTheGarage allCarTheGarage;
    CarController carController;
    private void Start()
    {
        allCarTheGarage = ButtonClassSave.LoadFromPlayerPrefs<AllCarTheGarage>(allCarTheGarage, "AllCarTheGarage");
        carController = GetComponent<CarController>();
        ConvertingStateMachin();
    }
    public void ConvertingStateMachin()
    { 
        var StatseOneMachinPower = int.Parse(allCarTheGarage.CarYellow[8]);
        Debug.Log(StatseOneMachinPower);
        carController.MachinRpmToNextGear(StatseOneMachinPower * 100);
    }
}
