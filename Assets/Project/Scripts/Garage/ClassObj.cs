using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassObj : MonoBehaviour
{
    int count = 0;
    [SerializeField] GameObject inite;
    [SerializeField] GameObject CarSevDesc;
    [SerializeField] GameObject[] CarDes = new GameObject[6];
    [SerializeField] GameObject[] gameObjects = new GameObject[6];
    //Vector3 vector3Car = new Vector3(1f, 1f, 1f);
    //Quaternion quaternionCar = Quaternion.Euler(0, -53, 0);
    private void Start()
    {
        inite = gameObjects[count];
        CarDes[count] = inite;
        inite.SetActive(true);
    }
    public void LeftSwitchbutton()
    {
        int a = gameObjects.Length;
        //if (count != 0)
        //    count--;

        if (count != 0)
        {
            if (count == 0)
            {
                inite = gameObjects[count];
                CarDes[count] = inite;
                CarSevDesc = CarDes[count+1];
                CarSevDesc.SetActive(false);
                inite.SetActive(true);
                Debug.Log(count + "count == 0");
            }
            if (count > 0)
            {
                inite = gameObjects[count - 1];
                CarDes[count - 1] = inite;
                CarSevDesc = CarDes[count];
                CarSevDesc.SetActive(false);
                inite.SetActive(true);
                Debug.Log(count + "count > 0");
            }
            count--;
        }

    }
    bool b = false;
    public void RightSwitchbutton()
    {
        int a = gameObjects.Length;
        if (count != a-1)
            count++;
        //Debug.Log(a + "A после сложения ");
        //Debug.Log(count + "коунт после сложения");
        
        if (count < gameObjects.Length)
        {
            inite = gameObjects[count];
            CarDes[count] = inite;
            CarSevDesc = CarDes[count-1];
            CarSevDesc.SetActive(false);
            inite.SetActive(true);
            Debug.Log(count);
        }
    }
    //[SerializeField] public GameObject[] gameObjects = new GameObject[6];
    //ClassObj classObj;
    //int count = 0;
    //[SerializeField] GameObject inite;
    //[SerializeField] GameObject[] CarDes = new GameObject[6];
    //Vector3 vector3Car = new Vector3(1f, 1f, 1f);
    //Quaternion quaternionCar = Quaternion.Euler(0, -53, 0);
    //private void Start()
    //{
    //    inite = Instantiate(gameObjects[count], gameObjects[count].transform.position, Quaternion.identity);
    //    inite.transform.localScale = vector3Car;
    //    inite.transform.rotation = quaternionCar;
    //    CarDes[count] = inite;
    //}
    //public void LeftSwitchbutton()
    //{
    //    int a = gameObjects.Length;
    //    if(count != 0) 
    //        count--;

    //    if (count > 0)
    //    {
    //        inite = Instantiate(gameObjects[count-1], gameObjects[count-1].transform.position, Quaternion.identity);
    //        inite.transform.localScale = vector3Car;
    //        inite.transform.rotation = quaternionCar;
    //        CarDes[count-1] = inite;
    //        DestroyObject(CarDes[count]);
    //        Debug.Log(count  + "count > 0");

    //    }

    //}
    //public void RightSwitchbutton()
    //{

    //    int a = gameObjects.Length;
    //    if(count !=a)
    //        count++;
    //    Debug.Log(a + "A после сложения ");
    //    Debug.Log(count + "коунт после сложения");

    //    if (count < gameObjects.Length)
    //    {

    //        inite = Instantiate(gameObjects[count], gameObjects[count].transform.position, Quaternion.identity);
    //        inite.transform.localScale = vector3Car;
    //        inite.transform.rotation = quaternionCar;
    //        CarDes[count] = inite;

    //        DestroyObject(CarDes[count - 1]);
    //        Debug.Log(count);

    //    }
    //}
}