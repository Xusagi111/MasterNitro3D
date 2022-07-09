using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePresentPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentPresentT;
    [SerializeField] private GameObject PresentPanel;
    private const int _currentValue = 0;
    private const int _probability = 4;
    private List<Gifts> _listDataGift;

    public int Money { get; private set; }
    public int Diamond { get; private set; }
    
    private void Awake()
    {
        SortedDataController.LoadingDataGift += GetList;
        YodoAnalitycs.OnReset += OnReset;
    }
    private void GetList()
    {
        _listDataGift = FindObjectOfType<SortedDataController>().GetListProcessingDataGiftsData(EnumIdToBuy.GiftsData, DataName.GiftsState);
    }
    public void UpdatePresent()
    {
        int CountMoney = _listDataGift[_currentValue].CountMoney;
        int CountDiamons = _listDataGift[_currentValue].CountDiamons;
        int RandomPercent = Random.Range(0, 100);
        if (_listDataGift[_probability].CountMoney > RandomPercent)
        {
            Money = CountMoney;
            YodoAnalitycs.instance.enumIdToBuy = EnumIdToBuy.indexMoney;
           CurrentPresentT.text = $"{Money}   <sprite=1>";
        }
        else
        {
            Diamond = CountDiamons;
            YodoAnalitycs.instance.enumIdToBuy = EnumIdToBuy.indexDiamons;
            CurrentPresentT.text = $"{Diamond}   <sprite=0>";
        }
       
    }
    public void OnReset()
    {
        PresentPanel.SetActive(false);
    }
    private void OnDisable()
    {
        SortedDataController.LoadingDataGift -= GetList;
        YodoAnalitycs.OnReset -= OnReset;
    }
}

