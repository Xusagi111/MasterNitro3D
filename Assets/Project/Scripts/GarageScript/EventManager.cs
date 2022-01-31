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
    private void Start()
    {
        EventManagerGame.AddListener<UpdateDisplayToUi>(UpdateDisplayToUiMethod);
    }
    void UpdateDisplayToUiMethod(UpdateDisplayToUi evt)
    {
        Money += 10;
        MoneDisplayUi.text = Money.ToString();
    }

}
public static class Events
{
    public static UpdateDisplayToUi  updateDisplayToUi= new UpdateDisplayToUi();
}
public class UpdateDisplayToUi : GameEvent
{
    public int Value;
}
