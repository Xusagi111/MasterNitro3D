using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPlayer
{
    public FactoryPlayer(CarData[] carDatas, int indexCar)
    {
        for (int i = 0; i < carDatas.Length; i++)
        {
            if (indexCar == (int)carDatas[i].Cartype)
            {
                var fff = GameObject.Instantiate(carDatas[i].CarPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                var a = GameObject.FindObjectOfType<CarController>().gameObject.transform;
                fff.transform.SetParent(a.transform);
            }
        }
    } 
}
