using System.Collections.Generic;

public abstract class Data
{
    private List<Buy> _diamons = new List<Buy>(6);
    private List<Buy> _money = new List<Buy>(6);
    private List<Buy> _offersPurchases = new List<Buy>(6);
    private int[] Index = new int[3];
    private int _enumIdToBuy;
    protected List<Buy> Diamons { get { return _diamons; } set { _diamons = value; } }
    protected List<Buy> Money { get { return _money; } set { _money = value; } }
    protected List<Buy> OffersPurchases { get { return _offersPurchases; } set { _offersPurchases = value; } }
}


