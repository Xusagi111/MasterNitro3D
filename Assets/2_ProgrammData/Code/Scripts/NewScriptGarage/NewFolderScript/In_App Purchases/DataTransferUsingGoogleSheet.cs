using System;
using UnityEngine;

public class DataTransferUsingGoogleSheet : MonoBehaviour
{
    public static event Action<BuyStateToList> EventData;


    [SerializeField] private string _sheetId;
    public BuyStateToList _data;

    private UrlSheetLoading _urlSheetLoading;
    private ReadingGoogleSheet _readingGoogleSheet;

    private void Awake()
    {
        _urlSheetLoading = GetComponent<UrlSheetLoading>();
        _readingGoogleSheet = GetComponent<ReadingGoogleSheet>();
        DownloadTable();
    }

    private void DownloadTable()
    {
        _urlSheetLoading.DownloadTable(_sheetId, OnRawCVSLoaded);
    }

    private void OnRawCVSLoaded(string rawCVSText)
    {
        _data = _readingGoogleSheet.ProcessData(rawCVSText);
        EventData?.Invoke(_data); //вернул отсортированный список 
    }
}
