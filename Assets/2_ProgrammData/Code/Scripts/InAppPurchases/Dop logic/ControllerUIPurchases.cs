using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControllerUIPurchases : MonoBehaviour
{
    private ManagerDataPurchase _managerShopping;
    private TestScriptTablieBuy _testScriptTablieBuy;
    public FirstPack FirstPack;

    public static UnityEvent StartTimer = new UnityEvent();

    public static UnityEvent InitializationPurchase = new UnityEvent();

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

        if (!PlayerPrefs.HasKey("flagFirstPack"))
        {
            this.FirstPack.gameObject.SetActive(true);
            _managerShopping.firstPack.Timer.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].Timer.ToString();
            FirstPackPurchases();
        }
        else {
            this.FirstPack.gameObject.SetActive(true);
            FirstPackPurchases();
        }
        
    }

    private void FirstPackPurchases()
    {
        _managerShopping.firstPack.CoinPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].NameOffer.ToString();
        _managerShopping.firstPack.DiamondPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].CountCurrency.ToString();
        _managerShopping.firstPack.PricePurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].Level.ToString();
        
    }
}
