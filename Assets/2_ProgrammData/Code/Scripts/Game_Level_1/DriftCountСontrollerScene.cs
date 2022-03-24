using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftCountСontrollerScene : MonoBehaviour //Наработки
{
    [SerializeField] private Text ConclusionUi;
    private GameObject ViewPlayer;
    private int DriftCount;
    private int _PointDriftCount = 5000;
    private int SumMoneyPassagePoint = 1000;
    private int CountMoney = 10;
    
    EventManager EventManager;
    private void Awake()
    {
        ManagerGameScene.CurrentCarPlayer += GetPlayer;
    }
    private void OnDestroy()
    {
        ManagerGameScene.CurrentCarPlayer -= GetPlayer;
    }
    private void Start()
    {
        EventManager = FindObjectOfType<EventManager>();
    }
    private void GetPlayer(GameObject Player)
    {
        ViewPlayer = Player.GetComponentInChildren<WellPlayerData>().gameObject;
    }
    private void FixedUpdate()
    {
        if (ViewPlayer.gameObject.transform.rotation.eulerAngles.z > 3f && ViewPlayer.gameObject.transform.rotation.eulerAngles.z < 357f)
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
        }
    }
}
