using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateCarExel : MonoBehaviour //Load Class
{
    public static List<CarS_Player> ListClassCarState; // Лист стат машин получаемый с таблицы эксель
    private int indexCar;
    
    void Awake()
    {
        GoogleSheetLoader.OnProcessData += DataMachin;
        //ListClassCarState = ExelStateMachin.CarStatsRead(); //старая логика 
       
    }
    public void DataMachin(CarStateToList carStateToList)
    {
        foreach (var item in carStateToList.CubeOptionsList) //работает с перечислениями выводит с таблицы на консоль 
        {
            Debug.Log(item.Power);
            if (indexCar != item.IndexMachin)
            {
                this.indexCar = item.IndexMachin;
                index.indices.Add(item.IndexMachin);
                Debug.Log(item.IndexMachin);
            }
        }
    }
}
[System.Serializable]
public class CarS_Player
{
    public int IndexMachin;
    public string NameCar;
    public int Power;
    public int Speed;
    public int Control;

}
public class index { public static List<int> indices = new List<int>(); }

