using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StringValue;

public class Timer : MonoBehaviour //Скрыть объект и больше его не показывать
{
    [SerializeField] private Text _timer;
    [SerializeField] private Text _timerMainMenu;

    private int hoursTimer;
    private int minutesTimer;
    private int secondsTimer;

    private int timeInSec;

    private int hoursRealTimeOrigin;
    private int minutesRealTimeOrigin;
    private int secondsRealTimeOrigin;

    private SortedDataController _testScriptTablieBuy;
    // При каждомм старте проверка на флаг запущенного таймера.
    // Запуск происходит бесконечное кол-во раз.
    
    void Start() 
    {
       FirstPack.TimerInfoEvent += SetTimerOrigin;

        if (PlayerPrefs.HasKey("flagFirstPack"))
            SetTimer();
        else { _timerMainMenu.text = "Click On Coin"; }    
    }

    private void SetTimer()
    {
        if (!PlayerPrefs.HasKey(StringValue.flagFirstPackBuy))
        {
            hoursTimer = PlayerPrefs.GetInt("hours");
            minutesTimer = PlayerPrefs.GetInt("minutes");
            secondsTimer = PlayerPrefs.GetInt("sec");

            Debug.Log("HoursReal" + DateTime.Now.Hour);
            Debug.Log("MinutesReal" + DateTime.Now.Minute);

            hoursRealTimeOrigin = PlayerPrefs.GetInt("hoursRealTime");
            minutesRealTimeOrigin = PlayerPrefs.GetInt("minutesRealTime");
            secondsRealTimeOrigin = PlayerPrefs.GetInt("secondsRealTime");


            Debug.Log("timeeeer" + hoursTimer);
            timeInSec = hoursTimer * 3600;
            _timer.text = "TIME LEFT: " + hoursTimer.ToString("D2") + ":" + minutesTimer.ToString("D2") + ":" + secondsTimer.ToString("D2");

            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hoursRealTimeOrigin, minutesRealTimeOrigin, secondsRealTimeOrigin);
            TimeSpan timeSpan = DateTime.Now.Subtract(dateTime);

            hoursTimer -= timeSpan.Hours;
            minutesTimer -= timeSpan.Minutes;
            secondsTimer -= timeSpan.Seconds;

            StartCoroutine(TimerCor());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    public void SetTimerOrigin(int hours)
    {
        if (!PlayerPrefs.HasKey("hours"))
        {
            PlayerPrefs.SetInt("flagFirstPack", 1);
            PlayerPrefs.SetInt("hours", hours);
            PlayerPrefs.SetInt("minutes", minutesTimer);
            PlayerPrefs.SetInt("sec", secondsTimer);
            PlayerPrefs.SetInt("hoursRealTime", DateTime.Now.Hour);
            PlayerPrefs.SetInt("minutesRealTime", DateTime.Now.Minute);
            PlayerPrefs.SetInt("secondsRealTime", DateTime.Now.Second);

            SetTimer();
        }
    }

    private IEnumerator TimerCor()
    {
        for (int i = timeInSec; i >= 0; i--)
        {
            if (hoursTimer <= 0 && minutesTimer <= 0)
                DelTimer();

            if (secondsTimer <= 0)
            {
                minutesTimer--;
                secondsTimer = 59;
            }
            if (minutesTimer <= 0)
            {
                hoursTimer--;
                minutesTimer = 59;
            }
            yield return new WaitForSeconds(1f);

            _timer.text = "TIME LEFT: " + hoursTimer.ToString("D2") + ":" + minutesTimer.ToString("D2") + ":" + secondsTimer.ToString("D2");
            _timerMainMenu.text = hoursTimer.ToString("D2") + ":" + minutesTimer.ToString("D2") + ":" + secondsTimer.ToString("D2");
            secondsTimer--;
        }
    }

    public void DelTimer()
    {
        PlayerPrefs.DeleteKey(flagFirstPack);
        PlayerPrefs.DeleteKey(hours);
        PlayerPrefs.DeleteKey(minutes);
        PlayerPrefs.DeleteKey(sec);
        PlayerPrefs.DeleteKey(hoursRealTime);
        PlayerPrefs.DeleteKey(minutesRealTime);
        PlayerPrefs.DeleteKey(secondsRealTime);
    }

    private void OnDestroy()
    {
        FirstPack.TimerInfoEvent -= SetTimerOrigin;
        SaveTimer();
    }
    private void SaveTimer()
    {
        if (PlayerPrefs.HasKey("flagFirstPack"))
        {
            PlayerPrefs.SetInt("hours", hoursTimer);
            PlayerPrefs.SetInt("minutes", minutesTimer);
            PlayerPrefs.SetInt("sec", secondsTimer);
            PlayerPrefs.SetInt("hoursRealTime", DateTime.Now.Hour);
            PlayerPrefs.SetInt("minutesRealTime", DateTime.Now.Minute);
            PlayerPrefs.SetInt("secondsRealTime", DateTime.Now.Second);
        }
    }

}
