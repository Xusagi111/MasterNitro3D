using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptTablieBuy : MonoBehaviour
{
    [SerializeField] BuyStateToList BuyStateToList;
    [SerializeField] List<Buy> _buyStateToLists;
    private void Start()
    {
        DataTransferUsingGoogleSheet.EventData += GetList;
    }
    public void GetList(BuyStateToList buyStateToList)
    {
        _buyStateToLists = buyStateToList.ListBuy;
    }
}
