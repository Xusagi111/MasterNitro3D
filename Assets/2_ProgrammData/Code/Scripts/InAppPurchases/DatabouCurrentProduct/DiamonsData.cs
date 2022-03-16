using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamonsData : Data, IInitializationPurchasescs
{
    private int _enumIdToBuy = (int)EnumIdToBuy.indexDiamons;
    public bool Getinizialization(int indexIdCurrentPurchases)
    {
        if (_enumIdToBuy == indexIdCurrentPurchases)
        {
            return true;
        }
        return false;
    }
    public void TransferCurrentProduct(Buy buyDiamons)
    {
        Diamons.Add(buyDiamons);
    }
    public List<Buy> GetList()
    {
        return Diamons;
    }
}
