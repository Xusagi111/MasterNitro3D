using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePresentPanel : MonoBehaviour
{
    [SerializeField] private Text CurrentPresentT;
    [SerializeField] private Image _moneyImage;
    [SerializeField] private Image _diamonsImage;
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
            CurrentPresentT.text = Money.ToString();
            _moneyImage.SetActive(true);
        }
        else
        {
            Diamond = CountDiamons;
            CurrentPresentT.text = Diamond.ToString();
            _diamonsImage.SetActive(true);
        }
    }
    public void OnReset()
    {
        _moneyImage.SetActive(false);
        _diamonsImage.SetActive(false);
        PresentPanel.SetActive(false);
    }
    private void OnDisable()
    {
        SortedDataController.LoadingDataGift -= GetList;
        YodoAnalitycs.OnReset -= OnReset;
    }
}

