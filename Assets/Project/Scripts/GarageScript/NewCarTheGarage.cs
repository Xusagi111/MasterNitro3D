using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NewCarTheGarage : MonoBehaviour
{
    [SerializeField] GarageController garageController;
    [SerializeField] SetActiveCarSceneGarage classObj;
    [SerializeField] Text conclusionNameCarOnUI;
    [SerializeField] Text conclusionOnPowerUI;
    [SerializeField] Text conclusionOnSpeedUI;
    [SerializeField] Text conclusionOnFuelUI;
    [SerializeField] Text UpgrageToUIPanelPowerLvl;
    [SerializeField] Text UpgrageToUIPanelSpeedLvl;
    [SerializeField] Text UpgrageToUIPanelTowerLvl;
    [SerializeField] string[] initeNameCar;
    [SerializeField] string[] NameCarArray = { "Мустанг", "Красная666", "Лада", "Черный плащ", "Вспышка8" }; //Названия машины
    [SerializeField] AllCarTheGarage allCarTheGarage = new AllCarTheGarage();

    int PowerLvl = 6;
    int SpeedLvl = 11;
    int FuelLvl = 16;
    int PowerState = 8;
    int SpeedState = 13;
    int FuelState = 18;
    int indexMachin;
    private void Start()
    {
        garageController = GetComponent<GarageController>();
        classObj = GetComponent<SetActiveCarSceneGarage>();
        //Debug.Log("allCarTheGarage " + allCarTheGarage);
        allCarTheGarage = ButtonClassSave.LoadFromPlayerPrefs<AllCarTheGarage>(allCarTheGarage, "AllCarTheGarage");
        DisplayToNameCar();
    }
    public void MethodWrappingMoney()
    {
        garageController.savePlayerStats.Money += 10000;
        garageController.SaveAndConclusionMetod();

    }
    public void UpgradePower() //снимает деньги от основной валюты и прибавляет характеристики к текущей машине.
    {
        string[][] AllStateMachin = { allCarTheGarage.CarYellow, allCarTheGarage.Chev, allCarTheGarage.Vehicle, allCarTheGarage.CarCarbon, allCarTheGarage.FocE };
        int IndexPowerLvl1 = int.Parse(AllStateMachin[indexMachin][PowerLvl]); //получаем лвл машины
        if (IndexPowerLvl1 < allCarTheGarage.upgradeAllLvl.Length - 1 ) 
        {
            int LvlThecurrentCar = int.Parse(allCarTheGarage.upgradeAllLvl[IndexPowerLvl1]);
            if (garageController.savePlayerStats.Money >= LvlThecurrentCar)
            {
                garageController.savePlayerStats.Money -= LvlThecurrentCar; //отнимает текущую сумму
                IndexPowerLvl1 += 1;
                AllStateMachin[indexMachin][PowerLvl] = IndexPowerLvl1.ToString();
                int state = int.Parse(AllStateMachin[indexMachin][PowerState]);
                state += 5;
                conclusionOnPowerUI.text = AllStateMachin[indexMachin][PowerState] = state.ToString();
                //сохранения 
                garageController.SaveAndConclusionMetod();
                ButtonClassSave.SaveToPlayerPrefs<AllCarTheGarage>(allCarTheGarage, "AllCarTheGarage");
            }
            else
            {
                Debug.Log("Нет денег");
            }
        }
        else
        {
            Debug.Log("Достугнут Максимальный лвл");
        }
    }
    public int ConclusionUpgrageToUIPanel(string[][] AllStateMachin, int indexMachin)
    {
        //считывания лвл 
        int IndexPowerLvl = int.Parse(AllStateMachin[indexMachin][PowerLvl]);
        //Debug.Log("индекс машины" + indexMachin + "lvl Power" + IndexPowerLvl);
        int IndexSpeedLvl = int.Parse(AllStateMachin[indexMachin][SpeedLvl]);
        int IndexFuelLvl = int.Parse(AllStateMachin[indexMachin][FuelLvl]);

        //выводит стоимость на текущий лвл
        if(IndexPowerLvl < allCarTheGarage.upgradeAllLvl.Length)
        {
            UpgrageToUIPanelPowerLvl.text = allCarTheGarage.upgradeAllLvl[IndexPowerLvl];
        }
        UpgrageToUIPanelSpeedLvl.text = allCarTheGarage.upgradeAllLvl[IndexSpeedLvl];
        UpgrageToUIPanelTowerLvl.text = allCarTheGarage.upgradeAllLvl[IndexFuelLvl];
        return this.indexMachin  = indexMachin;
    }

    public void DisplayToNameCar()
    {
        string[][] AllStateMachin = { allCarTheGarage.CarYellow, allCarTheGarage.Chev, allCarTheGarage.Vehicle, allCarTheGarage.CarCarbon, allCarTheGarage.FocE };

        for (int i = 0; i < NameCarArray.Length; i++)
        {
            if (classObj.gameObjects[i] == classObj.inite)
            {
                conclusionNameCarOnUI.text = NameCarArray[i];
                conclusionOnPowerUI.text = AllStateMachin[i][PowerState]; 
                conclusionOnSpeedUI.text = AllStateMachin[i][SpeedState];
                conclusionOnFuelUI.text = AllStateMachin[i][FuelState];
                ConclusionUpgrageToUIPanel(AllStateMachin, i);
                EventManager.SetActiveUI(i);
            }
        }
    }
}



