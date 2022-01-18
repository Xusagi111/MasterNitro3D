using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<int>Unity =new UnityEvent<int>();
    public static void SetActiveUI(int r) 
    {
        if(Unity != null) Unity.Invoke(r);
    }
}
