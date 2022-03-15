using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
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

    private TestScriptTablieBuy _testScriptTablieBuy;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Start()
    {

       FirstPack.TimerInfoEvent += SetTimerOrigin;

        if (PlayerPrefs.HasKey("flagFirstPack"))
            SetTimer();
        else _timerMainMenu.text = "Click On Coin";


    }

 

    private void SetTimer()
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


        if (DateTime.Now.Hour > hoursRealTimeOrigin)
        {
            int delta = DateTime.Now.Hour - hoursRealTimeOrigin;
            hoursTimer -= delta;
        }

        if (DateTime.Now.Minute > minutesRealTimeOrigin)
        {
            int delta = DateTime.Now.Minute - minutesRealTimeOrigin;
            minutesTimer -= delta;
        }

        if (DateTime.Now.Second > secondsRealTimeOrigin)
        {
            int delta = DateTime.Now.Second - secondsRealTimeOrigin;
            secondsTimer -= delta;
        }
        StartCoroutine(TimerCor());
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
            Debug.Log("MinutesReal" + DateTime.Now.Minute);
            SetTimer();
        }
    }

    private IEnumerator TimerCor()
    {
        for (int i = timeInSec; i >= 0; i--)
        {
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
            _timerMainMenu.text = "TIME LEFT: " + hoursTimer.ToString("D2") + ":" + minutesTimer.ToString("D2") + ":" + secondsTimer.ToString("D2");
            secondsTimer--;
        }
    }

    [ContextMenu("DelPrefs")]
    private void DelPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("hours", hoursTimer);
        PlayerPrefs.SetInt("minutes", minutesTimer);
        PlayerPrefs.SetInt("sec", secondsTimer);
        PlayerPrefs.SetInt("hoursRealTime", DateTime.Now.Hour);
        PlayerPrefs.SetInt("minutesRealTime", DateTime.Now.Minute);
        PlayerPrefs.SetInt("secondsRealTime", DateTime.Now.Second);

        Debug.Log("seeeec " + PlayerPrefs.GetInt("sec"));
        Debug.Log("minuuutes" + PlayerPrefs.GetInt("minutes"));

    }
}
