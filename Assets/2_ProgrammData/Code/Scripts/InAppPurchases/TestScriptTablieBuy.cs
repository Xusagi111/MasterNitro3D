using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptTablieBuy : MonoBehaviour
{
    [SerializeField] private BuyStateToList BuyStateToList;
    [SerializeField] private List<Buy> _buyStateToLists;
    [SerializeField] private List<Buy> _diamons;
    [SerializeField] private List<Buy> _money;
    [SerializeField] private List<Buy> _offersPurchases;
    [SerializeField] private int[] Index = new int[3];
    public List<Buy> Diamons { get { return _diamons; } set { _diamons = value; } }
    public List<Buy> Money { get { return _money; } set { _money = value; } }
    public List<Buy> OffersPurchases { get { return _offersPurchases; } set { _offersPurchases = value; } }

    public static event Action LoadingData;
    private void Start()
    {
        DataTransferUsingGoogleSheet.EventData += GetList;
    }
    public void GetList(BuyStateToList buyStateToList)
    {
        _buyStateToLists = buyStateToList.ListBuy;
        DataDistrebution();
    }
    public void DataDistrebution() //получение индексов
    {
        Index[0] = _buyStateToLists[0].IndexKey;
        int ItemIndex = Index[0];
        for (int i = 0; i < _buyStateToLists.Count; i++)
        {
            if (ItemIndex != _buyStateToLists[i].IndexKey)
            {
                for (int h = 0; h < Index.Length; h++)
                {
                    if (Index[h]  != 0)
                    {
                        Index[h] = _buyStateToLists[i].IndexKey;
                        ItemIndex = _buyStateToLists[i].IndexKey;
                        break;
                    }
                }
            }
        }
        
        for (int i = 0; i < _buyStateToLists.Count; i++)
        {
            //int ItemInt;
            //if (_buyStateToLists[i].IndexKey == CurrentIndex)
            //{
            //    _diamons.Add(_buyStateToLists[i]);
            //}
            //if
            //{
            //    _money.Add(_buyStateToLists[i]);
            //}
        }
        LoadingData?.Invoke();
    }
}
