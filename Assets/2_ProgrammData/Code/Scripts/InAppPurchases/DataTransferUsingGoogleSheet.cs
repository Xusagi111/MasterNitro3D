using System;
using UnityEngine;

[RequireComponent(typeof(UrlSheetLoading))]
public class DataTransferUsingGoogleSheet : MonoBehaviour // ���������� ������������ ControllerGoogleSheet 
{
    public static event Action<BuyStateToList, int[]> EventDataBuy;

    public static event Action<CarPriceToList> EventDataCar;

    public static event Action<GiftsStatsToList, int[]> EventDataGift;

    public static event Action<DataConstLevel> EventDatalevel;

    [SerializeField] private  string _sheetIdBuyStateToList;
    [SerializeField] private  string _sheetIdCarStateToList; //No Used
    [SerializeField] private  string _sheetIdGift;
    [SerializeField] private string _sheetIdCarPrice;
    [SerializeField] private string _sheetLevelPlayer;


    [SerializeField] private BuyStateToList _dataBuy;
    [SerializeField] private CarPriceToList _dataCar;
    [SerializeField] private GiftsStatsToList _dataGifts;
    [SerializeField] private DataConstLevel _dataConstLevel;

    private int[] IndexProduct;
    private UrlSheetLoading _urlSheetLoading; // ���� ��������� �������� ���������� ����� � �������.
    private ReadingGoogleSheet _readingGoogleSheet = new ReadingGoogleSheet(); //O���������. 
    private ReadLevel _readLevel = new ReadLevel(); //O���������. 


    private void Start()
    {
        _urlSheetLoading = GetComponent<UrlSheetLoading>();
        DownloadTable(DataName.Offers, _sheetIdBuyStateToList, "&gid=0");
        DownloadTable(DataName.CarPrice, _sheetIdBuyStateToList, _sheetIdCarPrice);
        DownloadTable(DataName.GiftsState, _sheetIdBuyStateToList, _sheetIdGift);
        DownloadTable(DataName.LevelPlayer, _sheetIdBuyStateToList, _sheetLevelPlayer);
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
        else if(CurrentProcessedClass == (int)DataName.LevelPlayer)
        {
            _dataConstLevel = _readLevel.ProcessDataLevel(rawCVSText);
            EventDatalevel?.Invoke(_dataConstLevel); //������ ��������������� ������ �� ������� ��������.
        }
        else
        {
            Debug.LogError("������ ������!!! ������������� � �������� � �������");
        }
    }
}
