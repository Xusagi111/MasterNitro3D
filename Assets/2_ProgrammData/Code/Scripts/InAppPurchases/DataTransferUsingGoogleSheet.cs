using System;
using UnityEngine;


public class DataTransferUsingGoogleSheet : MonoBehaviour
{
    public static event Action<BuyStateToList, int[]> EventData;

    public static event Action<CarStateToList, int[]> OnProcessData;
    public static event Action LoadingCar;

    [SerializeField] private string _sheetId;
    public BuyStateToList _dataBuy;
    public CarStateToList _dataCar;
    private int[] IndexProduct;

    private UrlSheetLoading _urlSheetLoading;
    private ReadingGoogleSheet _readingGoogleSheet = new ReadingGoogleSheet();

    private void Start()
    {
        _urlSheetLoading = GetComponent<UrlSheetLoading>();
        DownloadTable();
    }

    private void DownloadTable()
    {
        _urlSheetLoading.DownloadTable(_sheetId, null, OnRawCVSLoaded);
    }

    private void OnRawCVSLoaded(string rawCVSText)
    {
        (_dataBuy, IndexProduct) = (_readingGoogleSheet.ProcessDataOffers(rawCVSText));
        (_dataCar, IndexProduct) = _readingGoogleSheet.ProcessDataCar(rawCVSText);
        EventData?.Invoke(_dataBuy, IndexProduct); //вернул отсортированный список с покупками 
        OnProcessData?.Invoke(_dataCar, IndexProduct); //вернул отсортированный список со статами машин
        LoadingCar?.Invoke();
    }

}
