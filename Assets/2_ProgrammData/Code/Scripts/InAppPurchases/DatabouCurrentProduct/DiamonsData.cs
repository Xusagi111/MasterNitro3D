using System.Collections.Generic;

public class DiamonsData : IInitializationPurchasescs<Buy>
{
    private List<Buy> buys = new List<Buy>(6);
    private int _enumIdToBuy = (int)EnumIdToBuy.indexDiamons;

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
