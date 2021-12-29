using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GarageController : MonoBehaviour
{
    [SerializeField] SavePlayerStats savePlayerStats = new SavePlayerStats(); //статистика игрока
    [SerializeField] AllCarTheGarage Machin1 = new AllCarTheGarage("Machin");
    [SerializeField] AllCarTheGarage Machin2 = new AllCarTheGarage("Machin");
    [SerializeField] AllCarTheGarage Machin3 = new AllCarTheGarage("Machin");
    [SerializeField] AllCarTheGarage Machin4 = new AllCarTheGarage("Machin");
    [SerializeField] AllCarTheGarage Machin5 = new AllCarTheGarage("Machin");
    [SerializeField] AllCarTheGarage Machin6 = new AllCarTheGarage("Machin");
    [SerializeField] Text conclusionOnMoneyUI;
    [SerializeField] Text conclusionOnDiamondsUI;
    private void Start()
    {
        loaging(); // Загрузка денег.
    }
    public void minusOne()
    {
        ButtonClassSave.SaveToPlayerPrefs<SavePlayerStats>(savePlayerStats, "SavePlayerStats");
        conclusionOnMoneyUI.text = savePlayerStats.Money.ToString(); // вывод на ui
        Debug.Log(savePlayerStats.Money);
    }
    public void loaging()
    {
        savePlayerStats = ButtonClassSave.LoadFromPlayerPrefs<SavePlayerStats>("SavePlayerStats");
        Debug.Log(savePlayerStats.Money.ToString());
        conclusionOnMoneyUI.text = savePlayerStats.Money.ToString(); // вывод на ui
    }
}
