using System;
using System.Collections.Generic;
using UnityEngine;

public class SortedDataController : MonoBehaviour
{
    public static event Action LoadingData;

    private List<IInitializationPurchasescs<Buy>> _initializationPurchases = new List<IInitializationPurchasescs<Buy>>(3);
    private List<IInitializationPurchasescs<Gifts>> _initializationPresent = new List<IInitializationPurchasescs<Gifts>>(1);

    public static SortedDataController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        DataTransferUsingGoogleSheet.EventDataBuy += DistributionData;

        _initializationPurchases.Add(new DiamonsData());
        _initializationPurchases.Add(new MoneyData());
        _initializationPurchases.Add(new OffersData());


        _initializationPresent.Add(new GiftsData());

    }
    #region DistributionData
    private void DistributionData<T>(T buyStateToList, int[] Indexid)
    {
        if (buyStateToList is BuyStateToList buy)
        {
            for (int i = 0; i < buy.ListBuy.Count; i++)
            {
                for (int h = 0; h < Indexid.Length; h++)
                {
                    if (_initializationPurchases[h].Getinizialization((buy.ListBuy[i].IndexKey)))
                    {
                        _initializationPurchases[h].TransferCurrentProduct(buy.ListBuy[i]);
                        break;
                    }
                }
            }
            LoadingData?.Invoke();
        }

        if (buyStateToList is GiftsStatsToList gifts)
        {
            for (int i = 0; i < gifts.ListCifts.Count; i++)
            {
                for (int h = 0; h < Indexid.Length; h++)
                {
                    if (_initializationPresent[h].Getinizialization((gifts.ListCifts[i].IndexKey)))
                    {
                        _initializationPresent[h].TransferCurrentProduct(gifts.ListCifts[i]);
                        break;
                    }
                }
            }
        }

    }
    #endregion

    #region Getlist
    public List<Buy> GetListProcessingDataBuy(EnumIdToBuy enumIdToBuy, DataName dataName)
    {
        if (DataName.BuyState == dataName)
        {
            return GetSelectedListData(enumIdToBuy, dataName, _initializationPurchases);
        }
       
        Debug.LogError("Oшибка такого листа не сущесвует!");
        return null;
    }
    public List<Gifts> GetListProcessingDataGiftsData(EnumIdToBuy enumIdToBuy, DataName dataName)
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
    #endregion
}
