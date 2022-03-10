using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerShopping : MonoBehaviour
{
    [SerializeField] private List<DataTextInPurchaseModule> _listDataOffersMoney;
    [SerializeField] private List<DataTextInPurchaseModule> _listDataOffersDiamons;
    public List<DataTextInPurchaseModule> ListDataOffersMoney
    {
        get { return _listDataOffersMoney; }
        set { _listDataOffersDiamons = value; }
    }
    public List<DataTextInPurchaseModule> ListDataOffersDiamons
    {
        get { return _listDataOffersDiamons; }
        set { _listDataOffersDiamons = value; }
    }
}
    
