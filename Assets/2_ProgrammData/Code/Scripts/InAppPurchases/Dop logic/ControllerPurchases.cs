using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPurchases : MonoBehaviour
{
    private ManagerShopping _managerShopping;
    private TestScriptTablieBuy _testScriptTablieBuy;

    private void Start()
    {
        _managerShopping = FindObjectOfType<ManagerShopping>();
        _testScriptTablieBuy = FindObjectOfType<TestScriptTablieBuy>();
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
            _managerShopping.ListDataOffersMoney[i].QuantityPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexDiamons)[i].NameOffer.ToString();
            _managerShopping.ListDataOffersMoney[i].PrisePurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexDiamons)[i].CountCurrency.ToString();
        }
        for (int i = 0; i < CountMoney; i++)
        {
            _managerShopping.ListDataOffersDiamons[i].QuantityPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexMoney)[i].NameOffer.ToString();
            _managerShopping.ListDataOffersDiamons[i].PrisePurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexMoney)[i].CountCurrency.ToString();
        }
    }
}
