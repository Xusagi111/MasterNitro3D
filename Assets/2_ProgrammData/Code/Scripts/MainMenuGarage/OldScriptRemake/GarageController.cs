using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GarageController : MonoBehaviour 
{
    private SavePlayerStats _savePlayerStats = new SavePlayerStats();
    [SerializeField] Text conclusionOnMoneyUI;
    [SerializeField] Text conclusionOnDiamondsUI; // Убрать текст от сюда. 2) Возможно реализовать через скрипы с ивентами.
    public SavePlayerStats instanseSavePlayerState { get => _savePlayerStats; private set => _savePlayerStats = value; }
    private void Start()
    {
        loagingPlayerState(); // Загрузка профиля персонажа
        UpdateDisplayValue();
    }
    public void SetValueSavePlayerStats(int value, EnumIdToBuy enumIdToBuy, bool UpdateDisplay = true, int value2 = 0)
    {
        if (EnumIdToBuy.indexMoney == enumIdToBuy) { instanseSavePlayerState.Money += value; }
        if (EnumIdToBuy.indexDiamons == enumIdToBuy) { instanseSavePlayerState.Diamons += value; }
        if (EnumIdToBuy.indexOffers == enumIdToBuy) { instanseSavePlayerState.Money += value; instanseSavePlayerState.Diamons += value2; }
        SavePlayerState();
        if (UpdateDisplay)
        {
            UpdateDisplayValue();
        }
    }
    public void SavePlayerState()
    {
        ButtonClassSave.SaveToPlayerPrefs<SavePlayerStats>(instanseSavePlayerState, "instanseSavePlayerState");
    }
    public void loagingPlayerState()
    {
        instanseSavePlayerState = ButtonClassSave.LoadFromPlayerPrefs<SavePlayerStats>(instanseSavePlayerState, "instanseSavePlayerState");
    }
    public void UpdateDisplayValue()
    {
        conclusionOnDiamondsUI.text = instanseSavePlayerState.Diamons.ToString();
        conclusionOnMoneyUI.text = instanseSavePlayerState.Money.ToString();
    }

}
