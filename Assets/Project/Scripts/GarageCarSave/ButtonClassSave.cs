using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ButtonClassSave //: MonoBehaviour
{
    public static void SaveToPlayerPrefs<T>(T data, string key)
    {
        PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
        var a = JsonUtility.ToJson(data);
        Debug.Log(a);
    }
    public static T LoadFromPlayerPrefs<T>(T data, string key )
    {
        if (JsonUtility.FromJson<T>(PlayerPrefs.GetString(key)) == null)
        {
            //Debug.Log(key + "Key");
            //Debug.Log("Null чувак");
            PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
            var a = JsonUtility.ToJson(data);
            Debug.Log(a);
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }
        else
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }
    }
}
//public static T LoadFromPlayerPrefs<T>(string key)
//{
//    if (PlayerPrefs.HasKey(key))
//    {
//        Debug.Log(key + "Key");
//        if (JsonUtility.FromJson<T>(PlayerPrefs.GetString(key)) == null)
//        {
//            Debug.Log("Null чувак");

//        }
//        return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
//    }
//    else
//    {
//        return default(T);
//    }
//}


