using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPurchases : MonoBehaviour
{
    private ManagerShopping _managerShopping;
    private TestScriptTablieBuy _testScriptTablieBuy;
    //private void Start()
    //{
    //    TestScriptTablieBuy.LoadingData += InitializationPurchases;
    //}
    //private void OnDestroy()
    //{
    //    TestScriptTablieBuy.LoadingData -= InitializationPurchases;
    //}
    //private void InitializationPurchases()
    //{
    //    _managerShopping = FindObjectOfType<ManagerShopping>();
    //    _testScriptTablieBuy = FindObjectOfType<TestScriptTablieBuy>();
    //    for (int i = 0; i < _testScriptTablieBuy.Money.Count ; i++)
    //    {
    //        _managerShopping.ListDataOffersMoney[i].QuantityPurchasedProduct.text = _testScriptTablieBuy.Money[i].NameOffer.ToString();
    //        _managerShopping.ListDataOffersMoney[i].PrisePurchasedProduct.text = _testScriptTablieBuy.Money[i].CountCurrency.ToString();
    //    }
    //    for (int i = 0; i < _testScriptTablieBuy.Diamons.Count; i++)
    //    {
    //        _managerShopping.ListDataOffersDiamons[i].QuantityPurchasedProduct.text = _testScriptTablieBuy.Diamons[i].NameOffer.ToString();
    //        _managerShopping.ListDataOffersDiamons[i].PrisePurchasedProduct.text = _testScriptTablieBuy.Diamons[i].CountCurrency.ToString();
    //    }
    //}
}
