using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyData : Data, IInitializationPurchasescs
{
    private int _enumIdToBuy = (int)EnumIdToBuy.indexMoney;
    public bool Getinizialization(int indexIdCurrentPurchases)
    {
        if (_enumIdToBuy == indexIdCurrentPurchases)
        {
            return true;
        }
        return false;
    }
    public void TransferCurrentProduct(Buy buyMoney)
    {
        Money.Add(buyMoney);
    }
    public List<Buy> GetList()
    {
        return Money;
    }

}
