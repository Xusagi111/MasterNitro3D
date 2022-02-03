using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GarageController : MonoBehaviour
{
    [SerializeField] public static SavePlayerStats savePlayerStats = new SavePlayerStats(); //статистика игрока
    [SerializeField] Text conclusionOnMoneyUI;
    [SerializeField] Text conclusionOnDiamondsUI;
    private void Start()
    {
        loaging(); // Загрузка профиля персонажа
    }
    public void SaveAndConclusionMetod()
    {
        ButtonClassSave.SaveToPlayerPrefs<SavePlayerStats>(savePlayerStats, "SavePlayerStats");
        conclusionOnMoneyUI.text = savePlayerStats.Money.ToString(); // вывод на ui
        Debug.Log(savePlayerStats.Money);
    }
    public void loaging()
    {
        savePlayerStats = ButtonClassSave.LoadFromPlayerPrefs<SavePlayerStats>(savePlayerStats, "SavePlayerStats");
        Debug.Log("Кол-во денег " + savePlayerStats.Money.ToString());
        conclusionOnMoneyUI.text = savePlayerStats.Money.ToString(); // вывод на ui
    }

}
