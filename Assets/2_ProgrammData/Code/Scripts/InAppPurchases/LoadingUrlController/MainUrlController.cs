using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainUrlController : MonoBehaviour 
{
    #region Event






    #endregion

#if UNITY_EDITOR
    bool _debug = true;
#endif

    private const string urlOffers = "https://docs.google.com/spreadsheets/d/*/export?format=csv";
    private const string urlGifts = "https://docs.google.com/spreadsheets/d/*/export?format=csv&gid=2127756539";
    private void Start()
    {
        
    }
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
            }
            else
            {
                if (_debug)
                {
                    Debug.Log(request.downloadHandler.text);
                    Debug.Log("===============================================================================================");
                }

                callback(request.downloadHandler.text);
            }
        }
        yield return null;
    }
}
