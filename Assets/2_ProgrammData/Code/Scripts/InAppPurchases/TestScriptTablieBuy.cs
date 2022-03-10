using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptTablieBuy : MonoBehaviour
{
    //private BuyStateToList BuyStateToList;
    private List<Buy> _buyStateToLists;
    public static event Action LoadingData;
    private int[] Index = new int[3];
    private InizializationController _inizializationController;
    private  List<IInitializationPurchasescs> _initializationPurchases = new List<IInitializationPurchasescs>(3);
    private void Start()
    {
        DataTransferUsingGoogleSheet.EventData += GetList;
        DataTransferUsingGoogleSheet.EventIndexId += GetIndex;

        // No use
        //_inizializationController = new();

        //_initializationPurchases.Add(new DiamonsData());
    }
    public void GetList(BuyStateToList buyStateToList)
    {
        _buyStateToLists = buyStateToList.ListBuy;
    }
    public void GetIndex(int[] Indexid)
    {
        Index = Indexid;
        DataDistrebution();
    }
    public void DataDistrebution()
    {
        for (int i = 0; i < _buyStateToLists.Count; i++)
        {
            for (int h = 0; h < Index.Length; h++)
            {
                if (_initializationPurchases[h].Getinizialization(_buyStateToLists[i].IndexKey))
                {
                    TransferProduct(h,i);
                    //Cделать реализацию через интерфейсы,
                    //добавить выход из цикла если true;
                }
                else if (_initializationPurchases[h].Getinizialization(_buyStateToLists[i].IndexKey))
                {
                    TransferProduct(h, i);
                }
                else if (_initializationPurchases[h].Getinizialization(_buyStateToLists[i].IndexKey))
                {
                    TransferProduct(h, i);
                }
            }

        }
        
        LoadingData?.Invoke(); //вызов контроллера
    }
    public void TransferProduct(int indexInitPurch, int indexStatePurch )
    {
        _initializationPurchases[indexInitPurch].TransferCurrentProduct(_buyStateToLists[indexStatePurch]);
    }
}
