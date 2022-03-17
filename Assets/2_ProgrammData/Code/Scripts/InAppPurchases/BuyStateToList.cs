using System.Collections.Generic;

[System.Serializable]
public class BuyStateToList
{
    public List<Buy> ListBuy;
}
[System.Serializable]
public class Buy
{
    public int IndexKey;
    public string NameOffer;
    public int CountCurrency;
    public int Level;
    public int PersentBust;
    public int Timer;
}

[System.Serializable]
public class GiftsStatsToList
{
    public List<Gifts> ListCifts;
}
[System.Serializable]
public class Gifts
{
    public int IndexKey;
    public string NameOffer;
    public int CountMoney;
    public int CountDiamons;
}
