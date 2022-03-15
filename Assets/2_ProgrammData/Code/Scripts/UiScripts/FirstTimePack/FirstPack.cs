using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FirstPack : MonoBehaviour
{
    public delegate void TimerInfo(int _timer);
    public static event TimerInfo TimerInfoEvent;

    [SerializeField] private Text _coinPurchasedProduct;
    [SerializeField] private Text _diamondPurchasedProduct;
    [SerializeField] private Text _prisePurchasedProduct;
    [SerializeField] private Text _timer;

    public Text CoinPurchasedProduct
    {
        get { return _coinPurchasedProduct; }
        set { _coinPurchasedProduct = value; }
    }
    public Text DiamondPurchasedProduct
    {
        get { return _diamondPurchasedProduct; }
        set { _diamondPurchasedProduct = value; }
    }
    public Text PricePurchasedProduct
    {
        get { return _prisePurchasedProduct; }
        set { _prisePurchasedProduct = value; }
    }
    public Text Timer
    {
        get { return _timer; }
        set { _timer = value; }
    }

    public void SentTimerInfo()
    {
        if (!PlayerPrefs.HasKey("flagFirstPack"))
            TimerInfoEvent?.Invoke(int.Parse(_timer.text));
    }
}
