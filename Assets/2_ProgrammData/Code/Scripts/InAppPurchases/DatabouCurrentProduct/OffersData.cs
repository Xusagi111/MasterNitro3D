using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffersData : Data, IInitializationPurchasescs
{
    private int _enumIdToBuy = (int)EnumIdToBuy.indexOffers;
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
        OffersPurchases.Add(buyMoney);
    }
    public List<Buy> GetList()
    {
        return OffersPurchases;
    }
}
