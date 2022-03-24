using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPlayer
{
    public GameObject Player;
    public  FactoryPlayer(CarData[] carDatas, int indexCar)
    {
        for (int i = 0; i < carDatas.Length; i++)
        {
            if (indexCar == (int)carDatas[i].Cartype)
            {
                var Player = GameObject.Instantiate(carDatas[i].CarPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                var SellMachin = GameObject.FindObjectOfType<CarController>().gameObject;
                Player.transform.SetParent(SellMachin.transform);
                this.Player = SellMachin;
            }
        }
    } 
}
