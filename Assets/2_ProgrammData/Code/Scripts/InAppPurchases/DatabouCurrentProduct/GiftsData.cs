using System.Collections.Generic;

public class GiftsData :  IInitializationPurchasescs<Gifts>
{
    private List<Gifts> buys = new List<Gifts>(6);
    private int _enumIdToBuy = (int)EnumIdToBuy.GiftsData;

    public bool Getinizialization(int indexIdCurrentPurchases)
    {
        if (_enumIdToBuy == indexIdCurrentPurchases)
        {
            return true;
        }
        return false;
    }

    public List<Gifts> GetList()
    {
        return buys;
    }
    public void TransferCurrentProduct<T>(T product)
    {
        if (product is Gifts buy)
        {
            buys.Add(buy);
        }
    }
}

