using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUIPurchases : MonoBehaviour
{
    private ManagerDataPurchase _managerShopping;
    private TestScriptTablieBuy _testScriptTablieBuy;

    private void Start()
    {
        _managerShopping = ManagerDataPurchase.Instance;
        _testScriptTablieBuy = TestScriptTablieBuy.Instance;
        TestScriptTablieBuy.LoadingData += InitializationPurchases;
    }

    private void OnDestroy()
    {
        TestScriptTablieBuy.LoadingData -= InitializationPurchases;
    }

    //Узнать на сколько долго будет выполняться данная операция.

    private void InitializationPurchases() 
    {
        int CountDiamons = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexDiamons).Count;
        int CountMoney = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexMoney).Count;
        for (int i = 0; i < CountDiamons; i++)
        {
            _managerShopping.ListDataOffersDiamons[i].QuantityPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexDiamons)[i].NameOffer.ToString();
            _managerShopping.ListDataOffersDiamons[i].PrisePurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexDiamons)[i].CountCurrency.ToString();
            Debug.Log(_testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexDiamons)[i].CountCurrency.ToString());
        }
        for (int i = 0; i < CountMoney; i++)
        {
            _managerShopping.ListDataOffersMoney[i].QuantityPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexMoney)[i].NameOffer.ToString();
            _managerShopping.ListDataOffersMoney[i].PrisePurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexMoney)[i].CountCurrency.ToString();
        }

        //НАдо прокинуть ссылки, я хз где они находились раньше 

        //_managerShopping.DataOffersFirstPack.CoinPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].NameOffer.ToString();
        //_managerShopping.DataOffersFirstPack.DiamondPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].CountCurrency.ToString();
        //_managerShopping.DataOffersFirstPack.PrisePurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].Level.ToString();
        //_managerShopping.DataOffersFirstPack.Timer.text = $"TIME LEFT: {_testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].Timer}:00:00";

    }
}
