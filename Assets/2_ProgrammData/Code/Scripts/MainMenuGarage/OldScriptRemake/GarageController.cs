using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GarageController : MonoBehaviour //ToDo ?????? ??? ???????? ???? ?????
{
    [SerializeField] public static SavePlayerStats savePlayerStats = new SavePlayerStats(); //?????????? ??????
    [SerializeField] Text conclusionOnMoneyUI;
    [SerializeField] Text conclusionOnDiamondsUI;
    private void Start()
    {
        loaging(); // ???????? ??????? ?????????
    }
    public void SaveAndConclusionMetod()
    {
        ButtonClassSave.SaveToPlayerPrefs<SavePlayerStats>(savePlayerStats, "SavePlayerStats");
        conclusionOnMoneyUI.text = savePlayerStats.Money.ToString(); // ????? ?? ui
        Debug.Log(savePlayerStats.Money);
    }
    public void loaging()
    {
        savePlayerStats = ButtonClassSave.LoadFromPlayerPrefs<SavePlayerStats>(savePlayerStats, "SavePlayerStats");
        Debug.Log("???-?? ????? " + savePlayerStats.Money.ToString());
        conclusionOnMoneyUI.text = savePlayerStats.Money.ToString(); // ????? ?? ui
    }

}
