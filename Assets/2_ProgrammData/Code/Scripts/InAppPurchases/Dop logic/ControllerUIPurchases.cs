using System;
using UnityEngine;
using UnityEngine.Events;

public class ControllerUIPurchases : MonoBehaviour
{
    private ManagerDataPurchase _managerShopping;
    private SortedDataController _sortedDataController;
    public FirstPack FirstPack;

    public static UnityEvent StartTimer = new UnityEvent();

    public static UnityEvent InitializationPurchase = new UnityEvent();
    public static Action<bool> isPlayTimePurchases;

    private void Start()
    {
        _managerShopping = ManagerDataPurchase.Instance;
        _sortedDataController = FindObjectOfType<SortedDataController>();
        SortedDataController.LoadingData += InitializationPurchases;
    }

    private void OnDestroy()
    {
        SortedDataController.LoadingData -= InitializationPurchases;
    }

    private void InitializationPurchases() 
    {
        int CountDiamons = _sortedDataController.GetListProcessingDataBuy(EnumIdToBuy.indexDiamons, DataName.Offers).Count;
        int CountMoney = _sortedDataController.GetListProcessingDataBuy(EnumIdToBuy.indexMoney, DataName.Offers).Count;
        for (int i = 0; i < CountDiamons; i++)
        {
            _managerShopping.ListDataOffersDiamons[i].QuantityPurchasedProduct.text = _sortedDataController.GetListProcessingDataBuy(EnumIdToBuy.indexDiamons, DataName.Offers)[i].NameOffer;
            _managerShopping.ListDataOffersDiamons[i].PrisePurchasedProduct.text = _sortedDataController.GetListProcessingDataBuy(EnumIdToBuy.indexDiamons, DataName.Offers)[i].CountCurrency.ToString();
            Debug.Log(_sortedDataController.GetListProcessingDataBuy(EnumIdToBuy.indexDiamons, DataName.Offers)[i].CountCurrency.ToString());
        }
        for (int i = 0; i < CountMoney; i++)
        {
            _managerShopping.ListDataOffersMoney[i].QuantityPurchasedProduct.text = _sortedDataController.GetListProcessingDataBuy(EnumIdToBuy.indexMoney, DataName.Offers)[i].NameOffer;
            _managerShopping.ListDataOffersMoney[i].PrisePurchasedProduct.text = _sortedDataController.GetListProcessingDataBuy(EnumIdToBuy.indexMoney, DataName.Offers)[i].CountCurrency.ToString();
        }
        //if (!PlayerPrefs.HasKey(StringValue.flagFirstPackBuy))
        //{
        //    LoadingFirstPackPurchases();
        //}
    }

    // Осуществляется проверка на был ли запущен таймер.
    // Если таймер не запущен то мы прокидываем событие в котором передаем текущие часы.
    // Так же запускаем Текст в таймере.
    //private void LoadingFirstPackPurchases()
    //{
    //    if (!PlayerPrefs.HasKey("flagFirstPack"))
    //    {
    //        _managerShopping.firstPack.Timer.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexOffers, DataName.BuyState)[0].Timer.ToString();
    //    }
    //    this.FirstPack.gameObject.SetActive(true);
    //    UpdateUiFirstPackPurchases();
    //}
    //private void UpdateUiFirstPackPurchases() //Передача Данных с сервера на UI.
    //{
    //    _managerShopping.firstPack.CoinPurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexOffers, DataName.BuyState)[0].NameOffer.ToString();
    //    _managerShopping.firstPack.DiamondPurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexOffers, DataName.BuyState)[0].CountCurrency.ToString();
    //    _managerShopping.firstPack.PricePurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexOffers, DataName.BuyState)[0].Level.ToString();
    //}
}
