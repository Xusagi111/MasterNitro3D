using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStateMachin : MonoBehaviour //тест скрипт
{
    [SerializeField] CarConfig OneCar = new CarConfig();
    [SerializeField] CarController OneCarController; //= new CarController();

    int Speed = 0;
    public void initializationsScript()
    {
        OneCar.MinRPM = 2000;
    }
}
