using System;
using UnityEngine;

[RequireComponent(typeof(UrlSheetLoading))]
public class GoogleSheetLoader : MonoBehaviour
{
    public static event Action<CarStateToList> OnProcessData;
    public static event Action LoadingCar;
    
    [SerializeField] private string _sheetId;
    public CarStateToList _data;
    
    private UrlSheetLoading _loaderDataToGoogleSheets;
    private ReadingGoogleSheet _sheetProcessor = new ReadingGoogleSheet();

    private void Awake()
    {
        _loaderDataToGoogleSheets = GetComponent<UrlSheetLoading>();
        DownloadTable();
    }

    private void DownloadTable()
    {
       // _loaderDataToGoogleSheets.DownloadTable(_sheetId, null,OnRawCVSLoaded);
    }

    private void OnRawCVSLoaded(string rawCVSText)
    {
       // _data = _sheetProcessor.ProcessDataCar(rawCVSText);
        OnProcessData?.Invoke(_data); //вернул отсортированный список со статами машин
        LoadingCar?.Invoke();
    }
}
