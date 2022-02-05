using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventMoney OptionsMenuEvent = new EventMoney();
    public static Test1 Test1 = new Test1();
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
public class Test1 : GameEvent 
{
    public int Power;
    public int Speed;
    public int Control;
}