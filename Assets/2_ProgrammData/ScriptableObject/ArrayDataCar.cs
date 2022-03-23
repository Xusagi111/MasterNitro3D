using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayDataCar : MonoBehaviour
{
    [SerializeField] private CarData[] CarDatas;
    public CarData[] PropCarData
    {
        get { return CarDatas; }
        set { CarDatas = value; }
    }
}
