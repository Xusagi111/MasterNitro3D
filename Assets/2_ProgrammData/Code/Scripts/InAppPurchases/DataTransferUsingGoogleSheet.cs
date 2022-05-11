using System;
using UnityEngine;

[RequireComponent(typeof(UrlSheetLoading))]
public class DataTransferUsingGoogleSheet : MonoBehaviour // ���������� ������������ ControllerGoogleSheet 
{
    public static event Action<BuyStateToList, int[]> EventDataBuy;

    public static event Action<CarPriceToList> EventDataCar;

    public static event Action<GiftsStatsToList, int[]> EventDataGift;

    [SerializeField] private  string _sheetIdBuyStateToList;
    [SerializeField] private  string _sheetIdCarStateToList; //No Used
    [SerializeField] private  string _sheetIdGift;
    [SerializeField] private string _sheetIdCarPrice;


    public BuyStateToList _dataBuy;
    public CarPriceToList _dataCar;
    public GiftsStatsToList _dataGifts;

    private int[] IndexProduct;
    private UrlSheetLoading _urlSheetLoading; // ���� ��������� �������� ���������� ����� � �������.
    private ReadingGoogleSheet _readingGoogleSheet = new ReadingGoogleSheet(); // ���� ��������� �����������. 


    private void Start()
    {
        _urlSheetLoading = GetComponent<UrlSheetLoading>();
        DownloadTable(DataName.Offers, _sheetIdBuyStateToList, "&gid=0");
        DownloadTable(DataName.CarPrice, _sheetIdBuyStateToList, _sheetIdCarPrice);
        DownloadTable(DataName.GiftsState, _sheetIdBuyStateToList, _sheetIdGift);
    }

    private void DownloadTable(DataName dataName, string sheetID, string Listid = null)
    {
        _urlSheetLoading.DownloadTable(sheetID, Listid, OnRawCVSLoaded, dataName);
    }

    private void OnRawCVSLoaded(string rawCVSText, int CurrentProcessedClass)
    {
       
        if (CurrentProcessedClass == (int)DataName.Offers)
        {
            (_dataBuy, IndexProduct) = (_readingGoogleSheet.ProcessDataOffers(rawCVSText));

            EventDataBuy?.Invoke(_dataBuy, IndexProduct); //������ ��������������� ������ � ���������. 
        }
        //else if (CurrentProcessedClass == (int)DataName.CarState)
        //{
        //    (_dataCar, IndexProduct) = _readingGoogleSheet.ProcessDataCar(rawCVSText);
        //    OnProcessDataCar?.Invoke(_dataCar, IndexProduct); //������ ��������������� ������ �� ������� �����.
        //    LoadingCar?.Invoke();
        //}
        else if (CurrentProcessedClass == (int)DataName.CarPrice)
        {
            (_dataCar, IndexProduct) = _readingGoogleSheet.ProcessDataPriceCar(rawCVSText);
            EventDataCar?.Invoke(_dataCar); //������ ��������������� ������ �� ������� �����.
        }
        else if (CurrentProcessedClass == (int)DataName.GiftsState)
        {
            (_dataGifts, IndexProduct) = _readingGoogleSheet.ProcessDataGifts(rawCVSText);
            EventDataGift?.Invoke(_dataGifts, IndexProduct); //������ ��������������� ������ �� ������� ��������.
        }
        else
        {
            Debug.LogError("������ ������!!! ������������� � �������� � �������");
        }
    }
}
