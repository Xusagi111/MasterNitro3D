using System;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGameScene : MonoBehaviour
{
    public static Action<int> Indexid;
    public static Action<GameObject> CurrentCarPlayer;
    private static bool _isLoading;
    private ArrayDataCar _arrayDataCar;
    private FactoryPlayer _factoryPlayer;
    private int _indexCar; 
    private void Awake()
    {
        if (!_isLoading)
        {
            DontDestroyOnLoad(this);
            _isLoading = true;
        }
    }
    private void Start()
    {
        _arrayDataCar = GetComponent<ArrayDataCar>();
        EventManagerGame.AddListener<EventIndexCar>(SetIndexCar);

    }
    public void instansePlayerToScene()
    {
        _factoryPlayer = new FactoryPlayer(_arrayDataCar.PropCarData, _indexCar);
        CurrentCarPlayer?.Invoke(_factoryPlayer.Player);
        if (CurrentCarPlayer != null)
        {
            var a = GetComponentInChildren<Text>();
            a.text = _factoryPlayer.Player +  " ";
        }

    }
    private void SetIndexCar(EventIndexCar evt)
    {
        this._indexCar = evt.indexCarMachin;
    }
}
