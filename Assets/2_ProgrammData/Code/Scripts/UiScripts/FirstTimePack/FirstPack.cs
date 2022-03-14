using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPack : MonoBehaviour
{
    private ManagerDataPurchase _managerShopping;
    private TestScriptTablieBuy _testScriptTablieBuy;

    [SerializeField] private Text _coinPurchasedProduct;
    [SerializeField] private Text _diamondPurchasedProduct;
    [SerializeField] private Text _prisePurchasedProduct;

    [SerializeField] private Text _timer;
    private int timeInSec;
    private int hours;
    private int minutes = 59;
    private int seconds = 59;


    private void Awake()
    {
        _managerShopping = ManagerDataPurchase.Instance;
        _testScriptTablieBuy = TestScriptTablieBuy.Instance;

        _coinPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].NameOffer.ToString();
        _diamondPurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].CountCurrency.ToString();
        _prisePurchasedProduct.text = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].Level.ToString();

        hours = _testScriptTablieBuy.GetListIndexed(EnumIdToBuy.indexOffers)[0].Timer;

        Debug.Log("timeeeer" + hours);
        timeInSec = hours * 3600;
        _timer.text = $"TIME LEFT: {hours}:00:00";
        hours--;
    }

    private void OnEnable()
    {
        StartCoroutine(Timer());
    }
    void Update()
    {
        
    }

    private IEnumerator Timer()
    {
        for (int i = timeInSec; i >= 0; i--)
        {
            if(seconds == 0)
            {
                minutes--;
                seconds = 59;
            }
            if(minutes == 0)
            {
                hours--;
                minutes = 59;
            }
            yield return new WaitForSeconds(1f);
            
            _timer.text = "TIME LEFT: " + hours + ":" + minutes + ":" + seconds.ToString("D2");
            seconds--;
        }
    }
}
