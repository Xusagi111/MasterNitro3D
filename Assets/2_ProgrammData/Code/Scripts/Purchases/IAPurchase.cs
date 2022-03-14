using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Events;

public class IAPurchase : IStoreListener
{
    //public const string _removeADS = "remove_ads";
    public const string _testPurch = "4141411";
    #region ConstIdPurchases
    public const string diamonsbuy1 = "diamonsbuy1";
    public const string diamonsbuy2 = "diamonsbuy2";
    public const string diamonsbuy3 = "diamonsbuy3";
    public const string diamonsbuy4 = "diamonsbuy4";
    public const string diamonsbuy5 = "diamonsbuy5";
    public const string diamonsbuy6 = "diamonsbuy6";

    public const string buycoin1 = "buycoin1";
    public const string buycoin2 = "buycoin2";
    public const string buycoin3 = "buycoin3";
    public const string buycoin4 = "buycoin4";
    public const string buycoin5 = "buycoin5";
    public const string buycoin6 = "buycoin6";

    #endregion
    string[] ArrayConstValueId = { diamonsbuy1, diamonsbuy2, diamonsbuy3, diamonsbuy4, diamonsbuy5, diamonsbuy6, buycoin1, buycoin2, buycoin3, buycoin4, buycoin5, buycoin6 };

    public static IStoreController _storeController;
    private static IExtensionProvider _storeExtensionProvider;

    public static UnityEvent PurchaseComplete = new UnityEvent();


    public List<ConfigurationBuilder> IapInitializate()
    {
        List<ConfigurationBuilder> test = new List<ConfigurationBuilder>(12);
        if (IsIapInitialized())
            return test;
        //Пример продажи товара
        //var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        //builder.AddProduct(_removeADS, ProductType.NonConsumable);
        //UnityPurchasing.Initialize(this, builder);

        var NewBilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        NewBilder.AddProduct(_testPurch, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, NewBilder);

        for (int i = 0; i < ArrayConstValueId.Length; i++)
        {
            var a = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            a.AddProduct(ArrayConstValueId[i], ProductType.NonConsumable);
            UnityPurchasing.Initialize(this, a);
            test.Add(a);
        }
        return test;

    }
    public static bool IsIapInitialized()
    {
        return _storeController != null && _storeExtensionProvider != null;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {

    }
    //public static IEnumerator CheckSubscription()
    //{
    //    while (!IsIapInitialized())
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //    if (_storeController != null || _storeController.products != null)
    //    {
    //        foreach (var product in _storeController.products.all)
    //        {
    //            if (product.hasReceipt)
    //            {
    //                AdsAndIAP.isRemoveADS = true;
    //                AdsAndIAP.instance.HideAds();
    //                break;
    //            }
    //            AdsAndIAP.isRemoveADS = false;
    //        }
    //    }
    //}

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)// вызывается после покупки.
    {
        switch (purchaseEvent.purchasedProduct.definition.id)
        {
            //case _removeADS:
            //    break;
            case _testPurch:
                break;
           /* case _subscribtionIdWeek:
                break;
            case _subscribtionIdYear:
                break;*/
        }
        AdsAndIAP.isRemoveADS = true;
        AdsAndIAP.instance.HideAds(); Debug.Log("buy: " + (purchaseEvent.purchasedProduct.definition.id));
        PurchaseComplete?.Invoke();
        return PurchaseProcessingResult.Complete;
        
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {

    }

    /// <summary>
    /// Проверить, куплен ли товар.
    /// </summary>
    /// <param name="id">Индекс товара в списке.</param>
    /// <returns></returns>
    public static bool CheckBuyState(string id)
    {
        Product product = _storeController.products.WithID(id);
        if (product.hasReceipt) { Debug.Log("Test True Buy"); return true;  }
        else { Debug.Log("Test false Buy"); return false;  }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;
        _storeExtensionProvider = extensions;
    }

    public static void BuyProductID(string productId)
    {
        Debug.Log("Try to buy: " + productId);
        if (IsIapInitialized())
        {
            Product product = _storeController.products.WithID(productId);
            Debug.Log("Product: " + product);
            Debug.Log("availableToPurchase: " + product.availableToPurchase);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log("Start buy: " + productId);
                _storeController.InitiatePurchase(product);
                CheckBuyState(productId);
            }
        }
    }
}
