using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateCarExel : MonoBehaviour
{
    public  List<CarS_Player> ListClassCarState;
    private int indexCar;
    private index indexClass = new index();

    void Start()
    {
        //if(indexClass.indices[0].ToString() != null) indexCar = (int)indexClass.indices[0];
        CarS_Player[] CarS_Player = new CarS_Player[] { };
        ListClassCarState = ExelStateMachin.CarStatsRead();
        foreach (var item in ListClassCarState) //работает с перечислениями выводит с таблицы на консоль 
        {
            Debug.Log(item.Power);
            if (indexCar != item.IndexMachin)
            {
                indexCar = item.IndexMachin;
                indexClass.indices.Add(item.IndexMachin);
                Debug.Log(item.IndexMachin);
            }
        }
        //indexClass.indices.Remove(0);
    }

}
