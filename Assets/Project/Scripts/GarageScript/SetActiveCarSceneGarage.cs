using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveCarSceneGarage : MonoBehaviour
{
    [SerializeField] GameObject[] CarDes = new GameObject[6];
    [SerializeField] public GameObject[] gameObjects = new GameObject[6];
    [SerializeField] public GameObject inite;
    [SerializeField] GameObject CarSevDesc;
    [SerializeField] Text CarName;
    int count = 0;

    private void Start()
    {
        inite = gameObjects[count];
        CarDes[count] = inite;
        inite.SetActive(true);
    }
    public void LeftSwitchbutton()
    {
        if (count != 0)
        {
            if (count > 0)
            {
                inite = gameObjects[count - 1];
                CarDes[count - 1] = inite;
                CarSevDesc = CarDes[count];
                CarSevDesc.SetActive(false);
                inite.SetActive(true);
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
            CarSevDesc.SetActive(false);
            inite.SetActive(true);
        }
    }  
}