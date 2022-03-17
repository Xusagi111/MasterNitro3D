using System;
using System.Collections.Generic;
using UnityEngine;

public class SortedDataController : MonoBehaviour
{
    public static event Action LoadingData;
    private List<IInitializationPurchasescs<Buy>> _initializationPurchases = new List<IInitializationPurchasescs<Buy>>(3);
    private List<IInitializationPurchasescs<Cifts>> _initializationPresent = new List<IInitializationPurchasescs<Cifts>>(1);
    [SerializeField] private BuyStateToList _buyStateToList;

    public static SortedDataController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

       // test.Add(new DiamonsData());

        DataTransferUsingGoogleSheet.EventDataBuy += RunRequiredHandler;
        _initializationPurchases.Add(new DiamonsData());
        _initializationPurchases.Add(new MoneyData());
        _initializationPurchases.Add(new OffersData());


        //_initializationPurchases.Add(new DiamonsData());
        //_initializationPurchases.Add(new MoneyData());
        //_initializationPurchases.Add(new OffersData());

        //_initializationPurchases.Add(new Cifts());
    }
    public void RunRequiredHandler(BuyStateToList buyStateToList, int[] Indexid, DataName dataName)
    {
        if (DataName.BuyState == dataName)
        {
            DistributionData(buyStateToList, Indexid, _initializationPurchases);
            LoadingData?.Invoke();
        }
        if (DataName.GiftsState == dataName)
        {
            DistributionData(buyStateToList, Indexid, _initializationPresent);
            
        }
    }

    public List<Buy> GetListProcessingDataBuy(EnumIdToBuy enumIdToBuy, DataName dataName)
    {
        if (DataName.BuyState == dataName)
        {
            return GetSelectedListData(enumIdToBuy, dataName, _initializationPurchases);
        }
       
        Debug.LogError("Oшибка такого листа не сущесвует!");
        return null;
    }
    public List<Cifts> GetListProcessingDataGiftsData(EnumIdToBuy enumIdToBuy, DataName dataName)
    {
        if (DataName.GiftsState == dataName)
        {
            return GetSelectedListData(enumIdToBuy, dataName, _initializationPresent);
        }
        Debug.LogError("Oшибка такого листа не сущесвует!");
        return null;
    }


    private List<T> GetSelectedListData<T>(EnumIdToBuy enumIdToBuy, DataName dataName, List<IInitializationPurchasescs<T>> initializationPurchasescs)
    {
        for (int i = 0; i < _initializationPurchases.Count; i++)
        {
            if (initializationPurchasescs[i].Getinizialization((int)enumIdToBuy))
            {
                return initializationPurchasescs[i].GetList();
            }
        }
        return null;
    }
    private void DistributionData<T>(BuyStateToList buyStateToList, int[] Indexid, List<IInitializationPurchasescs<T>> initializationPurchasescs)
    {
        _buyStateToList = buyStateToList;
        int[] Index = new int[3];
        for (int i = 0; i < buyStateToList.ListBuy.Count; i++)
        {
            for (int h = 0; h < Index.Length; h++)
            {
                if (initializationPurchasescs[h].Getinizialization((buyStateToList.ListBuy[i].IndexKey)))
                {
                    initializationPurchasescs[h].TransferCurrentProduct(buyStateToList.ListBuy[i]);
                    break;
                }
            }
        }

    }

    //public void DataDistrebution(BuyStateToList buyStateToList, int[] Indexid, DataName dataName)
    //{
    //    _buyStateToList = buyStateToList;
    //    int[] Index = new int[3];
    //    for (int i = 0; i < buyStateToList.ListBuy.Count; i++)
    //    {
    //        for (int h = 0; h < Index.Length; h++)
    //        {
    //            if (_initializationPurchases[h].Getinizialization(buyStateToList.ListBuy[i].IndexKey))
    //            {
    //                _initializationPurchases[h].TransferCurrentProduct(buyStateToList.ListBuy[i]);
    //                break;
    //            }
    //        }
    //    }
    //    LoadingData?.Invoke();
    //}
    //public List<Buy> GetListIndexed(EnumIdToBuy enumIdToBuy)
    //{
    //    for (int i = 0; i < _initializationPurchases.Count; i++)
    //    {
    //        if (_initializationPurchases[i].Getinizialization((int)enumIdToBuy))
    //        {
    //            return _initializationPurchases[i].GetList();
    //        }
    //    }
    //    return null;
    //}
}
