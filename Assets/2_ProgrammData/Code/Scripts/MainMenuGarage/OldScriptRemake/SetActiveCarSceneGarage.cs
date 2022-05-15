using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveCarSceneGarage : MonoBehaviour
{
    public static int IndexMachinInList { get; set; }
    [SerializeField] private GameObject[] AllCarToScene = new GameObject[6];
    private GameObject inite;
    private GameObject[] CarDestroy = new GameObject[6];
    private int[] IndexCar = new int[6] { 123, 256, 324, 478, 555, 681 };
    private GameObject CarSevDesc;
    private int count = 0;
    private UpdateCheckToBuyMachin _updateCheckToBuyMachin;
    private GameManagerToScenesd _gameManagerToScenesd;
    private void Awake()
    {
        IndexMachinInList = IndexCar[0];
        inite = AllCarToScene[count];
        CarDestroy[count] = inite;
        inite.SetActive(true);
        _updateCheckToBuyMachin = GetComponent<UpdateCheckToBuyMachin>();
        _gameManagerToScenesd = FindObjectOfType<GameManagerToScenesd>();
    }
    private void Start()
    {
        _gameManagerToScenesd.EventTransferCar?.Invoke(IndexMachinInList);

    }
    public void LeftSwitchbutton()
    {
        if (count != 0)
        {
            if (count > 0)
            {
                IndexMachinInList = IndexCar[count - 1];
                Debug.Log(IndexMachinInList);
                inite = AllCarToScene[count - 1];
                CarDestroy[count - 1] = inite;
                CarSevDesc = CarDestroy[count];
                CarSevDesc.SetActive(false);
                inite.SetActive(true);
                //Event
                _updateCheckToBuyMachin.EventUpdateCar?.Invoke(IndexMachinInList);
                _gameManagerToScenesd.EventTransferCar?.Invoke(IndexMachinInList);
            }
            count--;
            
        }
    }  
    public void RightSwitchbutton()
    {
        int ArrayCarLength = AllCarToScene.Length;
        if (count != ArrayCarLength - 1)
            count++;
        IndexMachinInList = IndexCar[count];
        Debug.Log(IndexMachinInList);
        if (count < AllCarToScene.Length)
        {
            inite = AllCarToScene[count];
            CarDestroy[count] = inite;
            CarSevDesc = CarDestroy[count-1];
            CarSevDesc.SetActive(false);
            inite.SetActive(true);
            //Event
            _updateCheckToBuyMachin.EventUpdateCar.Invoke(IndexMachinInList);
            _gameManagerToScenesd.EventTransferCar?.Invoke(IndexMachinInList);
        }
    }  
}