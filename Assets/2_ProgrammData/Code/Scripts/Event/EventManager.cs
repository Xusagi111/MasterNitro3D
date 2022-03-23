using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventMoney OptionsMenuEvent = new EventMoney();
    public static EventIndexCar EventIndexCar = new EventIndexCar();
    public static EventClassDisplayToUi EventDisplayUi = new EventClassDisplayToUi();
    public static CarS_Player EventAllGarageCarsThePlayer = new CarS_Player();
    public static EventSaveStatePlyer EventSaveStatePlyer = new EventSaveStatePlyer();
    [SerializeField] Text MoneDisplayUi; // убрать от сюда вывод на ui 
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
public class EventClassDisplayToUi : GameEvent 
{
    public int Power;
    public int Speed;
    public int Control;
}
public class EventIndexCar : GameEvent
{
    public int indexCarMachin;
}
public class EventSaveStatePlyer : GameEvent
{
    public int Money;
    public int Diamons;
}

