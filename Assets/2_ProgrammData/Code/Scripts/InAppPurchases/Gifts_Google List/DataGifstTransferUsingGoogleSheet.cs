using System;
using UnityEngine;
public class DataGifstTransferUsingGoogleSheet: MonoBehaviour 
{
    public static event Action<GiftsStatsToList, int[]> EventData;
    [SerializeField] private string _sheetId;
    public GiftsStatsToList _data;
    private int[] IndexProduct;

    private LoadUrlGoogleList _loadUrlGoogleList;
    private HeaderListGifts  _headerListGifts;

    private void Start()
    {
        _loadUrlGoogleList = GetComponent<LoadUrlGoogleList>();
        _headerListGifts = GetComponent<HeaderListGifts>();
        DownloadTable();
    }

    private void DownloadTable()
    {
        _loadUrlGoogleList.DownloadTable(_sheetId, OnRawCVSLoaded);
    }

    private void OnRawCVSLoaded(string rawCVSText)
    {
        (_data, IndexProduct) = (_headerListGifts.ProcessData(rawCVSText));
        Debug.Log(EventData);
        EventData?.Invoke(_data, IndexProduct); //вернул отсортированный список 
    }
}

