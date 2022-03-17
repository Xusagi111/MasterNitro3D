using UnityEngine;
using UnityEngine.Events;

public class ControllerUIPurchases : MonoBehaviour
{
    private ManagerDataPurchase _managerShopping;
    private SortedDataController _testScriptTablieBuy;
    public FirstPack FirstPack;

    public static UnityEvent StartTimer = new UnityEvent();

    public static UnityEvent InitializationPurchase = new UnityEvent();

    private void Start()
    {
        _managerShopping = ManagerDataPurchase.Instance;
        _testScriptTablieBuy = SortedDataController.Instance;
        SortedDataController.LoadingData += InitializationPurchases;
    }

    private void OnDestroy()
    {
        SortedDataController.LoadingData -= InitializationPurchases;
    }

    private void InitializationPurchases() 
    {
        int CountDiamons = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexDiamons, DataName.BuyState).Count;
        int CountMoney = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexMoney, DataName.BuyState).Count;
        for (int i = 0; i < CountDiamons; i++)
        {
            _managerShopping.ListDataOffersDiamons[i].QuantityPurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexDiamons, DataName.BuyState)[i].NameOffer.ToString();
            _managerShopping.ListDataOffersDiamons[i].PrisePurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexDiamons, DataName.BuyState)[i].CountCurrency.ToString();
            Debug.Log(_testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexDiamons, DataName.BuyState)[i].CountCurrency.ToString());
        }
        for (int i = 0; i < CountMoney; i++)
        {
            _managerShopping.ListDataOffersMoney[i].QuantityPurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexMoney, DataName.BuyState)[i].NameOffer.ToString();
            _managerShopping.ListDataOffersMoney[i].PrisePurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexMoney, DataName.BuyState)[i].CountCurrency.ToString();
        }

        if (!PlayerPrefs.HasKey("flagFirstPack"))
        {
            this.FirstPack.gameObject.SetActive(true);
            _managerShopping.firstPack.Timer.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexOffers, DataName.BuyState)[0].Timer.ToString();
            FirstPackPurchases();
        }
        else {
            this.FirstPack.gameObject.SetActive(true);
            FirstPackPurchases();
        }
        
    }

    private void FirstPackPurchases()
    {
        _managerShopping.firstPack.CoinPurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexOffers, DataName.BuyState)[0].NameOffer.ToString();
        _managerShopping.firstPack.DiamondPurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexOffers, DataName.BuyState)[0].CountCurrency.ToString();
        _managerShopping.firstPack.PricePurchasedProduct.text = _testScriptTablieBuy.GetListProcessingDataBuy(EnumIdToBuy.indexOffers, DataName.BuyState)[0].Level.ToString();
        
    }
}
