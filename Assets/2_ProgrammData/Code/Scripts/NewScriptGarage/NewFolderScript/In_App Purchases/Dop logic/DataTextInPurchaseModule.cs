using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataTextInPurchaseModule : MonoBehaviour
{
    [SerializeField] Text _quantityPurchasedProduct;
    [SerializeField] Text _prisePurchasedProduct;
    public Text QuantityPurchasedProduct 
    {
        get { return _quantityPurchasedProduct; }
        set { _quantityPurchasedProduct =  value; } 
    }
    public Text PrisePurchasedProduct
    {
        get { return _prisePurchasedProduct; }
        set { _prisePurchasedProduct = value; }
    }
}
