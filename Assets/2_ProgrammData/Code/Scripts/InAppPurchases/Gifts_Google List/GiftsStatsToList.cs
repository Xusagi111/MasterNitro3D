using System.Collections.Generic;

[System.Serializable]
public class GiftsStatsToList
{
    public List<Cifts> ListCifts;
}
[System.Serializable]
public class Cifts
{
    public int IndexKey;
    public string NameOffer;
    public int CountMoney;
    public int CountDiamons;
}


