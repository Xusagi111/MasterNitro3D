using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UrlSheetLoading : MonoBehaviour // Можно переиспользовать. //Добавить подгрузку с помощью изменения листа.
{
    [SerializeField] private Text text;
    private bool _debug = true;
    private const string url = "https://docs.google.com/spreadsheets/d/*/export?format=csv"; // &gid=2056821665 смена листа
    public static event Action<bool> NotConnectToServer;

    public void DownloadTable(string sheetId, Action<string> onSheetLoadedAction)
    {
        string actualUrl = url.Replace("*", sheetId);
        StartCoroutine(DownloadRawCvsTable(actualUrl, onSheetLoadedAction));
    }

    private IEnumerator DownloadRawCvsTable(string actualUrl, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(actualUrl))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError ||
                request.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError(request.error);
                NotConnectToServer?.Invoke(false);
            }
            else
            {
                if (_debug)
                {
                    Debug.Log(request.downloadHandler.text);
                    text.text = request.downloadHandler.text;
                }
                NotConnectToServer.Invoke(true);
                callback(request.downloadHandler.text);
            }
        }
        yield return null;
    }
}
