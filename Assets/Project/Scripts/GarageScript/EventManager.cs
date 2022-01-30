using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] Text MoneDisplayUi;
    int Money; //Прикрутить текущие кол-во денег
    public static UnityEvent<int> Unity = new UnityEvent<int>();
    public static UnityEvent MoneyDisplay = new UnityEvent();
    public static void SetActiveUI(int r)
    {
        if (Unity != null) Unity.Invoke(r);
    }
    public void StateMoneyUpdateDisplayUi()
    {
        if (Unity != null)
        {
            MoneyDisplay.Invoke();
            Money += 10;
            MoneDisplayUi.text = Money.ToString();
            Debug.Log("вызов");
        }
    }
}

