using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventMoney OptionsMenuEvent = new EventMoney();
    [SerializeField] Text MoneDisplayUi;
    int Money; //Прикрутить текущие кол-во денег
    private void Start()
    {
        EventManagerGame.AddListener<EventMoney>(UpdateMoneyDisplay);
    }
    public void UpdateMoneyDisplay(EventMoney evt)
    {
        Money += evt.value;
        MoneDisplayUi.text = Money.ToString();
    }

}
public class EventMoney : GameEvent
{
    public int value;
}