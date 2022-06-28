using System;
using UnityEngine;
using UnityEngine.UI;

public class ControllerToStateGameScene : MonoBehaviour //Наработки
{
    public static Action EventGetStateToManagerMenu { get; set; }
    [SerializeField] private StarterToLevel _starterToLevel;
    private Transform ViewPlayer;
    private int DriftCount;
    private int _PointDriftCount = 50;
    private int SumMoneyPassagePoint = 1;
    private int CountValue = 10;
    private int MoneyToScene;
    [field: SerializeField] private UiStateToScene _uiStateToScene { get; set; } = new UiStateToScene();
    private GameManagerToScenes _gameManagerToScene;

    private void Awake()
    {
        EventManagerGame.AddListener<EventMoney>(UpdateMoneyDisplay);
        EventGetStateToManagerMenu += SetToStatePlayer;
    }
    private void OnDestroy()
    {
        EventManagerGame.RemoveListener<EventMoney>(UpdateMoneyDisplay);
        EventGetStateToManagerMenu -= SetToStatePlayer;   
    }
    private void Start()
    {
        ViewPlayer = _starterToLevel.PLayerCar.GetComponentInChildren<WellPlayerData>().gameObject.transform;
    }
    private void FixedUpdate()
    {
        if (ViewPlayer.rotation.eulerAngles.z > 3f && ViewPlayer.rotation.eulerAngles.z < 357f) //Начисление очков
        {
            DriftCount += CountValue;
            _uiStateToScene.CurrentDriftGlasses.text = DriftCount.ToString();
            if (DriftCount >= _PointDriftCount)
            {
                EventMoney evt = EventManager.OptionsMenuEvent;
                evt.value = SumMoneyPassagePoint;
                EventManagerGame.Broadcast(evt);
                _PointDriftCount += 50;
            }
            return;
        }
    }
    public void UpdateMoneyDisplay(EventMoney evt)
    {
        MoneyToScene += evt.value;
        _uiStateToScene.MoneyToSceneT.text = MoneyToScene.ToString();
    }
    private void SetToStatePlayer()
    {
        _gameManagerToScene = FindObjectOfType<GameManagerToScenes>();
        _gameManagerToScene.CurrentGlassesToTravel = DriftCount;
        _gameManagerToScene.CurrentMoneyToTravel = MoneyToScene;
    }
}
[System.Serializable]
public class UiStateToScene 
{
    [field: SerializeField] public Text CurrentDriftGlasses { get; set; }
    [field: SerializeField] public Text MoneyToSceneT { get; set; }
}


