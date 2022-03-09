using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsAndIAP : MonoBehaviour
{
    public static bool isRemoveADS;
    
    public static AdsAndIAP instance;

    [SerializeField]
    GameObject[] hided;

    private void Awake()
    {
        instance = this;
       
    }

    private void Start()
    {
        IAPurchase iAPurchase = new IAPurchase();
        iAPurchase.IapInitializate();
        //StartCoroutine(IAPurchase.CheckSubscription());
    }

    public void HideAds()
    {
        foreach(var hide in hided)
        {
            hide.SetActive(false);
        }
    }

    //Пример
    public void BuyRemoveADS() //вешается на кнопку отключения рекламы
    {
        IAPurchase.BuyProductID(IAPurchase._removeADS);
    }
    //Buy Product.
    public void BuyProduct() //вешается на кнопку покупки продукта
    {
        IAPurchase.BuyProductID(IAPurchase._testPurch);
    }
}
