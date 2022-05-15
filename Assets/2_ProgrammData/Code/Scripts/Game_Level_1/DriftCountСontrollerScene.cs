using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftCountСontrollerScene : MonoBehaviour //Наработки
{
    [SerializeField] private Text ConclusionUi;
    [SerializeField] private StarterToLevel _starterToLevel;
    private Transform ViewPlayer;
    private int DriftCount;
    private int _PointDriftCount = 5000;
    private int SumMoneyPassagePoint = 1000;
    private int CountMoney = 10;
    private Text TextTest;
    private int TestCountToAndroid;
   
    private void Start()
    {
        ViewPlayer = _starterToLevel.PLayerCar.GetComponentInChildren<WellPlayerData>().gameObject.transform;
    }
    private void FixedUpdate()
    {
        if (ViewPlayer.rotation.eulerAngles.z > 3f && ViewPlayer.rotation.eulerAngles.z < 357f)
        {
            DriftCount += CountMoney;
            ConclusionUi.text = DriftCount.ToString();
            if (DriftCount >= _PointDriftCount)
            {
                EventMoney evt = EventManager.OptionsMenuEvent;
                evt.value = SumMoneyPassagePoint;
                EventManagerGame.Broadcast(evt);
                _PointDriftCount += 5000;
            }
            return;
        }
    }
    //if (SpeedCar.SpeedInHour > 50)
    //{
    //    if (SpeedCar.SpeedInHour > 50 && SpeedCar.SpeedInHour > ProgressCounterDinamic + 10)
    //    {
    //        ProgressCounterDinamic += 1;
    //        a = ((ProgressCounterDinamic - 50) / 10) * 5; //текущий бонус 
    //                                                      // money +5
    //    }
    //    if (SpeedCar.SpeedInHour > 50 && SpeedCar.SpeedInHour < ProgressCounterDinamic)
    //    {
    //        ProgressCounterDinamic -= 10;

    //        if (a == 0)
    //        {
    //            a = ((ProgressCounterDinamic - 50) / 10) * 5; //текущий бонус 
    //        }
    //    }
    //    EventManager.StateMoneyUpdateDisplayUi(CountMoney + a);
    //    a = 0;
    //}

}

