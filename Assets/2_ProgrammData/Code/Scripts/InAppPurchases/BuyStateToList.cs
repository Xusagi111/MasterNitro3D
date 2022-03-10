using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BuyStateToList: MonoBehaviour//переименовать
{
    public List<Buy> ListBuy;
}
[System.Serializable]
public class Buy
{
    public int IndexKey;
    public int NameOffer;
    public int CountCurrency;
    public int LevelBust;
    public int PersentBust;
}