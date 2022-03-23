using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveCarSceneGarage : MonoBehaviour
{
    [SerializeField] private GameObject[] CarDes = new GameObject[6];
    [SerializeField] private GameObject[] gameObjects = new GameObject[6];
    [SerializeField] private GameObject inite;
    [SerializeField] private GameObject CarSevDesc;
    private int count = 0;
    private int _indexCar = 123;
    private ArrayDataCar _arrayDataCar;
    private CarType[] IndexCars;


    private void Start()
    {
        GetElementIndexCar();

        inite = gameObjects[count];
        CarDes[count] = inite;
        inite.SetActive(true);
    }
    private void GetElementIndexCar()
    {
        _arrayDataCar= FindObjectOfType<ArrayDataCar>();
        IndexCars = new CarType[_arrayDataCar.PropCarData.Length];
        for (int i = 0; i < _arrayDataCar.PropCarData.Length; i++)
        {
            IndexCars[i] = _arrayDataCar.PropCarData[i].Cartype;
        }
    }
    public void LeftSwitchbutton()
    {
        if (count != 0)
        {
            if (count > 0)
            {
                //IndexMachinInList = index.indices[count - 1];

                _indexCar = (int)IndexCars[count];
                Debug.Log(_indexCar);
                inite = gameObjects[count - 1];
                CarDes[count - 1] = inite;
                CarSevDesc = CarDes[count];

                CarSevDesc.SetActive(false);
                inite.SetActive(true);
                //Event
                EventIndexCar evt = EventManager.EventIndexCar;
                evt.indexCarMachin = _indexCar;
                EventManagerGame.Broadcast(evt);
            }
            count--;
            
        }
    }  
    public void RightSwitchbutton()
    {
        int ArrayCarLength = gameObjects.Length;
        if (count != ArrayCarLength - 1)
            count++;


        if (count < gameObjects.Length)
        {
            inite = gameObjects[count];
            CarDes[count] = inite;
            CarSevDesc = CarDes[count-1];


            _indexCar = (int)IndexCars[count];
            Debug.Log(_indexCar);

            CarSevDesc.SetActive(false);
            inite.SetActive(true);
            //Event
            EventIndexCar evt = EventManager.EventIndexCar;
            evt.indexCarMachin = _indexCar;
            EventManagerGame.Broadcast(evt);
        }
    }  
}