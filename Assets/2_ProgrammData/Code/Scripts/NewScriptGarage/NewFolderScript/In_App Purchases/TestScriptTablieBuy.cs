using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptTablieBuy : MonoBehaviour
{
    [SerializeField] private BuyStateToList BuyStateToList;
    [SerializeField] private List<Buy> _buyStateToLists;
    [SerializeField] private List<Buy> diamons;
    [SerializeField] private List<Buy> money;
    public List<Buy> Diamons { get; set; }
    public List<Buy> Money { get; set; }
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
                diamons.Add(_buyStateToLists[i]);
            }
            else
            {
                money.Add(_buyStateToLists[i]);
            }
        }
    }
}
