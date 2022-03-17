using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyData : IInitializationPurchasescs<Buy>
{
    private List<Buy> buys = new List<Buy>(6);
    private int _enumIdToBuy = (int)EnumIdToBuy.indexMoney;

    public bool Getinizialization(int indexIdCurrentPurchases)
    {
        if (_enumIdToBuy == indexIdCurrentPurchases)
        {
            return true;
        }
        return false;
    }

    public List<Buy> GetList()
    {
        return buys;
    }
    public void TransferCurrentProduct<T>(T product)
    {
        if (product is Buy buy)
        {
            buys.Add(buy);
        }
    }

}
