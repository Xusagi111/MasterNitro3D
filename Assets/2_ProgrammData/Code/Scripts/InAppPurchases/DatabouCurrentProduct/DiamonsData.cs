using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamonsData : IInitializationPurchasescs, IGetDataToIistPurchases
{
    private List<Buy> _diamons;
    private List<Buy> _money;
    private List<Buy> _offersPurchases;
    private int[] Index = new int[3];
    private int _enumIdToBuy = (int)EnumIdToBuy.indexDiamons;
    public List<Buy> Diamons { get { return _diamons; } set { _diamons = value; } }
    public List<Buy> Money { get { return _money; } set { _money = value; } }
    public List<Buy> OffersPurchases { get { return _offersPurchases; } set { _offersPurchases = value; } }
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
        _diamons.Add(buyDiamons);
    }
    public List<Buy> GetList()
    {
        return _diamons;
    }

}
