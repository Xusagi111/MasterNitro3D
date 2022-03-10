using System;
using UnityEngine;

[RequireComponent(typeof(loaderDataToGoogleSheets), typeof(ReadingDataFromSheet))]
public class GoogleSheetLoader : MonoBehaviour
{
    public static event Action<CarStateToList> OnProcessData;
    public static event Action LoadingCar;
    
    [SerializeField] private string _sheetId;
    [SerializeField] private CarStateToList _data;
    
    private loaderDataToGoogleSheets _loaderDataToGoogleSheets;
    private ReadingDataFromSheet _sheetProcessor;

    private void Awake()
    {
        _loaderDataToGoogleSheets = GetComponent<loaderDataToGoogleSheets>();
        _sheetProcessor = GetComponent<ReadingDataFromSheet>();
        DownloadTable();
    }

    private void DownloadTable()
    {
        _loaderDataToGoogleSheets.DownloadTable(_sheetId, OnRawCVSLoaded);
    }

    private void OnRawCVSLoaded(string rawCVSText)
    {
        _data = _sheetProcessor.ProcessData(rawCVSText);
        OnProcessData?.Invoke(_data); //вернул отсортированный список со статами машин
        LoadingCar?.Invoke();
    }
}
