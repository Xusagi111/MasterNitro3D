using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassObj : MonoBehaviour
{
    [SerializeField] public GameObject[] gameObjects = new GameObject[6];
    ClassObj classObj;
    int count = 0;
    [SerializeField] GameObject inite;
    [SerializeField] GameObject[] CarDes = new GameObject[6];
    Vector3 vector3Car = new Vector3(4f, 4f, 4f);
    Quaternion quaternionCar = Quaternion.Euler(0, -53, 0);
    private void Start()
    {
        inite = Instantiate(gameObjects[count], gameObjects[count].transform.position, Quaternion.identity);
        inite.transform.localScale = vector3Car;
        inite.transform.rotation = quaternionCar;
        CarDes[count] = inite;
    }
    public void LeftSwitchbutton()
    {
        int a = gameObjects.Length;
        if(count != 0) 
            count--;

        if (count > 0)
        {
            inite = Instantiate(gameObjects[count-1], gameObjects[count-1].transform.position, Quaternion.identity);
            inite.transform.localScale = vector3Car;
            inite.transform.rotation = quaternionCar;
            CarDes[count-1] = inite;
            DestroyObject(CarDes[count]);
            Debug.Log(count  + "count > 0");
            
        }

    }
    public void RightSwitchbutton()
    {
        
        int a = gameObjects.Length;
        if(count !=a)
            count++;
        Debug.Log(a + "A после сложения ");
        Debug.Log(count + "коунт после сложения");

        if (count < gameObjects.Length)
        {

            inite = Instantiate(gameObjects[count], gameObjects[count].transform.position, Quaternion.identity);
            inite.transform.localScale = vector3Car;
            inite.transform.rotation = quaternionCar;
            CarDes[count] = inite;
           
            DestroyObject(CarDes[count - 1]);
            Debug.Log(count);
            
        }
    }
}