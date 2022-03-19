using System;
using System.Collections.Generic;
using UnityEngine;

public class SortedDataController : MonoBehaviour
{
    public static event Action LoadingData;
    public static event Action LoadingDataGift;

    private  List<IInitializationPurchasescs<Buy>> _initializationPurchases = new List<IInitializationPurchasescs<Buy>>(3);
    private List<IInitializationPurchasescs<Gifts>> _initializationPresent = new List<IInitializationPurchasescs<Gifts>>(1);
    private void Awake()
    {

        DataTransferUsingGoogleSheet.EventDataBuy += DistributionData;
        DataTransferUsingGoogleSheet.EventDataGift += DistributionData;
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
            LoadingDataGift?.Invoke();
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
       
        Debug.LogError("Oøèáêà òàêîãî ëèñòà íå ñóùåñâóåò!");
        return null;
    }
    public List<Gifts> GetListProcessingDataGiftsData(EnumIdToBuy enumIdToBuy, DataName dataName)
    {
        if (DataName.GiftsState == dataName)
        {
            return GetSelectedListData(enumIdToBuy, dataName, _initializationPresent);
        }
        Debug.LogError("Oøèáêà òàêîãî ëèñòà íå ñóùåñâóåò!");
        return null;
    }
  

    private List<T> GetSelectedListData<T>(EnumIdToBuy enumIdToBuy, DataName dataName, List<IInitializationPurchasescs<T>> initializationPurchasesås)
    {
        for (int i = 0; i < initializationPurchasesås.Count; i++)
        {
            if (initializationPurchasesås[i].Getinizialization((int)enumIdToBuy))
            {
                return initializationPurchasesås[i].GetList();
            }
        }
        return null;
    }
    #endregion
    private void OnDestroy()
    {
        DataTransferUsingGoogleSheet.EventDataBuy -= DistributionData;
    }
}
