using System.Collections.Generic;
using UnityEngine;

public class ManagerDataPurchase : MonoBehaviour
{
    [SerializeField] private List<InPurchaseModuleUIElements> _listDataOffersMoney;
    [SerializeField] private List<InPurchaseModuleUIElements> _listDataOffersDiamons;
    public FirstPack firstPack;

    public static ManagerDataPurchase Instance;

    private void Awake() 
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

    }
    public List<InPurchaseModuleUIElements> ListDataOffersMoney
    {
        get { return _listDataOffersMoney; }
        set { _listDataOffersDiamons = value; }
    }
    public List<InPurchaseModuleUIElements> ListDataOffersDiamons
    {
        get { return _listDataOffersDiamons; }
        set { _listDataOffersDiamons = value; }
    }

}
    
