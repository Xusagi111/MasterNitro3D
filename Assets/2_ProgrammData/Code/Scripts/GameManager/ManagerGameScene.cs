using System;
using UnityEngine;

public class ManagerGameScene : MonoBehaviour
{
    public static Action<int> Indexid;
    public static Action eventTrue;
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
        new FactoryPlayer(_arrayDataCar.PropCarData, _indexCar);
        eventTrue?.Invoke();
    }
    private void SetIndexCar(EventIndexCar evt)
    {
        this._indexCar = evt.indexCarMachin;
    }
   
}
