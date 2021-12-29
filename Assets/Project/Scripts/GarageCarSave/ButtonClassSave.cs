using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClassSave : MonoBehaviour
{
    public static void SaveToPlayerPrefs<T>(T data, string key)
    {
        PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
        var a = JsonUtility.ToJson(data);
        Debug.Log(a);
    }

    public static T LoadFromPlayerPrefs<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            Debug.Log(key);
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }
        else
        { 
            return default(T);
        }
    }
}



