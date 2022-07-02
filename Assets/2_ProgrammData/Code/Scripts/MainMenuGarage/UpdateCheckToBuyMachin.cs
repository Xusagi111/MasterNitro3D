﻿using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCheckToBuyMachin : MonoBehaviour
{
    public Action<int> EventUpdateCar;
    [SerializeField] private TextMeshProUGUI[] CountpriceText;
    [SerializeField] private GameObject BuyPanel;
    [SerializeField] private Button ButtonPurchaseVerification;
    [SerializeField] private GameObject AcrivePanelPurchaces;
    [SerializeField] private GameObject ErrorText;
    private GarageController _garageController;
    private SortedDataController _sortedDataController;

    private void Awake()
    {
        EventUpdateCar += UpdateCar;
        ButtonPurchaseVerification.onClick.AddListener(() => BuyMachin());
        _garageController = GetComponent<GarageController>();
        _sortedDataController = FindObjectOfType<SortedDataController>();
        
    }
    private void Start()
    {
        if (_garageController.instanseCurrentCarPlayer.CarPlayer.Count == 0)
        {
            _garageController.instanseCurrentCarPlayer.CarPlayer.Add(SetActiveCarSceneGarage.IndexMachinInList);

        }
        UpdateCar(SetActiveCarSceneGarage.IndexMachinInList);
    }
    private void OnDestroy()
    {
        EventUpdateCar -= UpdateCar;
        ButtonPurchaseVerification.onClick.RemoveAllListeners();

    }
    private void UpdateCar(int IndexCar) // Осуществить проверку на то есть ли машина в сетапе или нет.
    {
        for (int i = 0; i < _garageController.instanseCurrentCarPlayer.CarPlayer.Count; i++)
        {
            if (_garageController.instanseCurrentCarPlayer.CarPlayer[i] == IndexCar)
            {
                BuyPanel.SetActive(false);
                    return;
            }
            else
            {
                var indexMAchin = SetActiveCarSceneGarage.IndexMachinInList;
                BuyPanel.SetActive(true);
                for (int b = 0; b < _sortedDataController.carPrices.Count; b++)
                {
                    if (indexMAchin == _sortedDataController.carPrices[b].IndexMachin)
                    {
                        if (_sortedDataController.carPrices[b].PriceMoney != 999999)
                            UpdateUiPriceCar(_sortedDataController.carPrices[b].PriceMoney,true);

                        else
                            UpdateUiPriceCar(_sortedDataController.carPrices[b].PriceDiamons,false);

                        //_garageController.SavePlayerState();
                        //_garageController.StartUpdateDisplayValue();
                    }
                }
            }
        }
    }
    private void UpdateUiPriceCar(int CurrentPrice, bool isMoney) 
    {
        string CurrentSprite = "";
        if (isMoney)
        {
            CurrentSprite = "  <sprite=1>";
        }
        else
        {
            CurrentSprite = "  <sprite=0>";
        }
        for (int i = 0; i < CountpriceText.Length; i++)
        {
            CountpriceText[i].text = CurrentPrice.ToString() + CurrentSprite;
        }
      
    }
    private void BuyMachin()
    {
      var indexMAchin =  SetActiveCarSceneGarage.IndexMachinInList;
        for (int i = 0; i < _sortedDataController.carPrices.Count; i++)
        {
            if (_sortedDataController.carPrices[i].IndexMachin == indexMAchin)
            {
                if (_sortedDataController.carPrices[i].PriceMoney == 999999)
                {
                    if (_garageController.instanseSavePlayerState.Diamons >= _sortedDataController.carPrices[i].PriceDiamons)
                        CheckMoneyToPlayer(0,_sortedDataController.carPrices[i].PriceDiamons);

                    else
                        StartCoroutine(ErrorPanelToText());
                }
                else
                {
                    if (_garageController.instanseSavePlayerState.Money >= _sortedDataController.carPrices[i].PriceMoney)
                        CheckMoneyToPlayer(_sortedDataController.carPrices[i].PriceMoney);

                    else
                        StartCoroutine(ErrorPanelToText());
                    
                }
            }
        }
       
       
    }
    private void CheckMoneyToPlayer(int Money = 0, int Diamond = 0)
    {
        var indexMachin = SetActiveCarSceneGarage.IndexMachinInList;
        BuyPanel.SetActive(false);

        if (Money!=0)
            _garageController.instanseSavePlayerState.Money -= Money;

        else
            _garageController.instanseSavePlayerState.Diamons -= Diamond;

        BuyPanel.SetActive(false);
        _garageController.instanseCurrentCarPlayer.CarPlayer.Add(indexMachin);
        AcrivePanelPurchaces.SetActive(false);
        _garageController.SavePlayerState();
        _garageController.StartUpdateDisplayValue();
    }
    private IEnumerator ErrorPanelToText()
    {
        ErrorText.SetActive(true);
        Debug.LogError("Не хватает денег");
        yield return new WaitForSeconds(0.5f);
        ErrorText.SetActive(false);
    }
}
