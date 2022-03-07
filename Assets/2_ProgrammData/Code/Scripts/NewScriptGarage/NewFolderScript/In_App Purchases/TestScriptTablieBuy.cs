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
    public List<Buy> Diamons { get { return _diamons; } set { _diamons = value; } }
    public List<Buy> Money { get { return _money; } set { _money = value; } }
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
    public void DataDistrebution()
    {
        int CurrentIndex = _buyStateToLists[0].IndexKey;
        for (int i = 0; i < _buyStateToLists.Count; i++)
        {
            if (_buyStateToLists[i].IndexKey == CurrentIndex)
            {
                _diamons.Add(_buyStateToLists[i]);
            }
            else
            {
                _money.Add(_buyStateToLists[i]);
            }
        }
        LoadingData?.Invoke();
    }
}
