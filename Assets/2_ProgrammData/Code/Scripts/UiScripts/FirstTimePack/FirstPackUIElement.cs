using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPackUIElement : MonoBehaviour
{
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

    public Text PrisePurchasedProduct
    {
        get { return _prisePurchasedProduct; }
        set { _prisePurchasedProduct = value; }
    }

    public Text Timer
    {
        get { return _timer; }
        set { _timer = value; }
    }
}
