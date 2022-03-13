using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadUrlGoogleList : MonoBehaviour
{
#if UNITY_EDITOR
    bool _debug = true;
#endif
    private const string url = "https://docs.google.com/spreadsheets/d/*/export?format=csv&gid=2127756539";

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
