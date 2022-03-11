using System;
using UnityEngine;

public class DataTransferUsingGoogleSheet : MonoBehaviour
{
    public static event Action<BuyStateToList, int[]> EventData;
    [SerializeField] private string _sheetId;
    public BuyStateToList _data;
    private int[] IndexProduct;

    private UrlSheetLoading _urlSheetLoading;
    private ReadingGoogleSheet _readingGoogleSheet;

    private void Start()
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
        (_data, IndexProduct) = (_readingGoogleSheet.ProcessData(rawCVSText));
        Debug.Log(EventData);
        EventData?.Invoke(_data, IndexProduct); //вернул отсортированный список 
    }

}
