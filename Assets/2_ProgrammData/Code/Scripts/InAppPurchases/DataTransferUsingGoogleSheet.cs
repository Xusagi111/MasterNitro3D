using System;
using UnityEngine;


public class DataTransferUsingGoogleSheet : MonoBehaviour // Актуальный используемый ControllerGoogleSheet 
{
    public static event Action<BuyStateToList, int[]> EventData;

    public static event Action<CarStateToList, int[]> OnProcessData;
    public static event Action LoadingCar;

    [SerializeField] private string _sheetId;
    public BuyStateToList _dataBuy;
    public CarStateToList _dataCar;
    private int[] IndexProduct;
    private DataName _DataName;
    private UrlSheetLoading _urlSheetLoading;
    private ReadingGoogleSheet _readingGoogleSheet = new ReadingGoogleSheet(); // Один экземпляр обработчика 


    private void Start()
    {
        _urlSheetLoading = GetComponent<UrlSheetLoading>();
        DownloadTable();
    }

    private void DownloadTable()
    {
        _urlSheetLoading.DownloadTable(_sheetId, null, OnRawCVSLoaded,(int)DataName.BuyState);
    }

    private void OnRawCVSLoaded(string rawCVSText, int CurrentProcessedClass)
    {
       
        if (CurrentProcessedClass ==(int)DataName.BuyState)
        {
            (_dataBuy, IndexProduct) = (_readingGoogleSheet.ProcessDataOffers(rawCVSText));
            EventData?.Invoke(_dataBuy, IndexProduct); //вернул отсортированный список с покупками 
        }
        if (CurrentProcessedClass == (int)DataName.CarState)
        {
            (_dataCar, IndexProduct) = _readingGoogleSheet.ProcessDataCar(rawCVSText);
            OnProcessData?.Invoke(_dataCar, IndexProduct); //вернул отсортированный список со статами машин
            LoadingCar?.Invoke();
        }
        else
        {
            Debug.LogError("ОШИБКА РЕБЯТА!!! Присмотритесь к загрузке с таблицы");
        }
    }
}
