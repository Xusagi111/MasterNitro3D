using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassObj : MonoBehaviour
{
    [SerializeField] GameObject[] CarDes = new GameObject[6];
    [SerializeField] GameObject[] gameObjects = new GameObject[6];
    [SerializeField] GameObject inite;
    [SerializeField] GameObject CarSevDesc;
    bool f = false;
    bool t = true;
    int count = 0;

    private void Start()
    {
        inite = gameObjects[count];
        CarDes[count] = inite;
        inite.SetActive(t);
    }
    public void LeftSwitchbutton()
    {
        if (count != 0)
        {
            if (count == 0)
            {
                inite = gameObjects[count];
                CarDes[count] = inite;
                CarSevDesc = CarDes[count+1];
                CarSevDesc.SetActive(f);
                inite.SetActive(t);
            }
            if (count > 0)
            {
                inite = gameObjects[count - 1];
                CarDes[count - 1] = inite;
                CarSevDesc = CarDes[count];
                CarSevDesc.SetActive(f);
                inite.SetActive(t);
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
            CarSevDesc.SetActive(f);
            inite.SetActive(t);
        }
    }  
}