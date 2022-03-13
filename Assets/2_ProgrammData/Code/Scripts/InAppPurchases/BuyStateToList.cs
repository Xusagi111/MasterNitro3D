using System.Collections.Generic;

[System.Serializable]
public class BuyStateToList //переименовать
{
    public List<Buy> ListBuy;
}
[System.Serializable]
public class Buy
{
    public int IndexKey;
    public int NameOffer;
    public int CountCurrency;
    public int Level;
    public int PersentBust;
    public int Timer;
}

