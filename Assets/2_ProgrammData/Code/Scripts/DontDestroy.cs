using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static bool loaded;
    [SerializeField] private GameObject _dontDestroy;
    public static int CountLoad;


    void Awake()
    {
        if (!loaded)
        {
            DontDestroyOnLoad(_dontDestroy);
        }
        else { Destroy(_dontDestroy);}
        loaded = true;
    }
}
