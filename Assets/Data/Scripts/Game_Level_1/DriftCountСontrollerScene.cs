using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftCountСontrollerScene : MonoBehaviour //Наработки
{
    [SerializeField] Text ConclusionUi;
    [SerializeField] Transform View;
    [SerializeField] GameObject ViewPlayerTransform;
    int DriftCount;
    int _PointDriftCount = 5000;
    int SumMoneyPassagePoint = 1000;
    int CountMoney = 10;
    int ProgressCounterDefolt = 50;
    public int ProgressCounterDinamic = 50;
    public int a = 0;
    EventManager EventManager;
    CarController SpeedCar;

    private void Start()
    {
        ViewPlayerTransform = GameObject.Find("ViewPlayer");
        SpeedCar = FindObjectOfType<CarController>();
        View = ViewPlayerTransform.transform;
        EventManager = FindObjectOfType<EventManager>();
    }
    private void FixedUpdate()
    {
        if (View.rotation.eulerAngles.z > 3f && View.rotation.eulerAngles.z < 357f)
        {
            DriftCount += 10;
            ConclusionUi.text = DriftCount.ToString();
            if (DriftCount >= _PointDriftCount)
            {
                EventManager.StateMoneyUpdateDisplayUi(SumMoneyPassagePoint);
                _PointDriftCount += 5000;
            }
        }
        if (SpeedCar.SpeedInHour > 50)
        {
            if (SpeedCar.SpeedInHour > 50 && SpeedCar.SpeedInHour > ProgressCounterDinamic + 10)
            {
                ProgressCounterDinamic += 1;
                a = ((ProgressCounterDinamic - 50) / 10) * 5; //текущий бонус 
                                                              // money +5
            }
            if (SpeedCar.SpeedInHour > 50 && SpeedCar.SpeedInHour < ProgressCounterDinamic)
            {
                ProgressCounterDinamic -= 10;

                if (a == 0)
                {
                    a = ((ProgressCounterDinamic - 50) / 10) * 5; //текущий бонус 
                }
            }
            EventManager.StateMoneyUpdateDisplayUi(CountMoney + a);
            a = 0;
        }

    }

}
