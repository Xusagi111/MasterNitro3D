using System;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptTablieBuy : MonoBehaviour //сделать возиожность переипользовать
{
    public static event Action LoadingData;
    private List<IInitializationPurchasescs> _initializationPurchases = new List<IInitializationPurchasescs>(3);
    [SerializeField] private BuyStateToList _buyStateToList;

    public static TestScriptTablieBuy Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        DataTransferUsingGoogleSheet.EventDataBuy += DataDistrebution;

        _initializationPurchases.Add(new DiamonsData());
        _initializationPurchases.Add(new MoneyData());
        _initializationPurchases.Add(new OffersData());
    }
    public void DataDistrebution(BuyStateToList buyStateToList, int[] Indexid)
    {
        _buyStateToList = buyStateToList;
         int[] Index = new int[3];
        for (int i = 0; i < buyStateToList.ListBuy.Count; i++)
        {
            for (int h = 0; h < Index.Length; h++)
            {
                if (_initializationPurchases[h].Getinizialization(buyStateToList.ListBuy[i].IndexKey))
                {
                    _initializationPurchases[h].TransferCurrentProduct(buyStateToList.ListBuy[i]);
                    break;
                }
            }
        }
        LoadingData?.Invoke();
    }
    public List<Buy> GetListIndexed(EnumIdToBuy enumIdToBuy)
    {
        for (int i = 0; i < _initializationPurchases.Count; i++)
        {
            if (_initializationPurchases[i].Getinizialization((int)enumIdToBuy))
            {
                return _initializationPurchases[i].GetList();
            }
        }
        return null;
    }
}
