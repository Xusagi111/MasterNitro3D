using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventMoney OptionsMenuEvent = new EventMoney();
    public static EventPushList EventPushOn = new EventPushList();
    public static EventClassDisplayToUi EventDisplayUi = new EventClassDisplayToUi();
    public static CarS_Player EventAllGarageCarsThePlayer = new CarS_Player();
    [SerializeField] Text MoneDisplayUi; // ?????? ?? ???? ????? ?? ui 
    int Money; //?????????? ??????? ???-?? ?????
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
public class EventClassDisplayToUi : GameEvent 
{
    public int Power;
    public int Speed;
    public int Control;
}
public class EventPushList : GameEvent
{
    public int indexCarMachin;
}
