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
    private int count = 0;
    public static int IndexMachinInList { get; set; }

    private void Start()
    {
        IndexMachinInList = 123;
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
                //IndexMachinInList = index.indices[count - 1];
                Debug.Log(IndexMachinInList);
                inite = gameObjects[count - 1];
                CarDes[count - 1] = inite;
                CarSevDesc = CarDes[count];
                CarSevDesc.SetActive(false);
                inite.SetActive(true);
                //Event
                //CarS_Player evt = EventManager.EventAllGarageCarsThePlayer;
                //evt = AllGarageCarsThePlayer.AllCarState[count -1];
                //EventManagerGame.Broadcast(evt);
            }
            count--;
            
        }
    }  
    public void RightSwitchbutton()
    {
        int ArrayCarLength = gameObjects.Length;
        if (count != ArrayCarLength - 1)
            count++;
        //IndexMachinInList = index.indices[count];
        Debug.Log(IndexMachinInList);
        if (count < gameObjects.Length)
        {
            inite = gameObjects[count];
            CarDes[count] = inite;
            CarSevDesc = CarDes[count-1];
            CarSevDesc.SetActive(false);
            inite.SetActive(true);
            //Event
            //CarS_Player evt = EventManager.EventAllGarageCarsThePlayer;
            //evt = AllGarageCarsThePlayer.AllCarState[count];
            //EventManagerGame.Broadcast(evt);
        }
    }  
}