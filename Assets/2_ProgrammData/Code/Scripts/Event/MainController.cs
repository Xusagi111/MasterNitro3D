using System.Collections.Generic;
using UnityEngine;

namespace Event
{
    public class MainController //: BaseController
    {
    //    private BattleInitialization _battleInitialization;
    //    private MainMenuController _mainMenuController;
    //    private ChangedMenuController _changedMenuController;
    //    private SpawnController _spawnController;
    //    private UpdateControllers _updateControllers;
    //    private MoveManager _moveManager;
    //    private MoveController _moveController;

    //    private GameObject _container = new GameObject("Container");
    //    private readonly Descriptions _descriptions;
    //    private readonly FlyerFactory _factoryFlyer;
    //    private readonly GameObject _canvas;    //??
    //    private readonly SubscriptionStorage _profilePlayer;
    //    private readonly Transform _placeForUi;  //??
        
        
    //    public MainController(SubscriptionStorage profilePlayer, Descriptions descriptions,
    //        UpdateControllers updateControllers, GameObject canvas)
    //    {
    //        _profilePlayer = profilePlayer;
    //        _placeForUi = canvas.transform;
    //        _descriptions = descriptions;
    //        _canvas = canvas;
    //        _updateControllers = updateControllers;
    //        var factory = _container.AddComponent<Factory>();
    //        _factoryFlyer = new FlyerFactory(factory, descriptions);
    //        _factoryFlyer.LoadView();
            
    //        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    //        OnChangeGameState(_profilePlayer.CurrentState.Value = GameState.Battle);
    //    }
        
    //    protected override void OnDispose()
    //    {
    //        _mainMenuController?.Dispose();
    //        _battleInitialization?.Dispose();
    //        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
    //        base.OnDispose();
    //    }
        
    //    private void OnChangeGameState(GameState state)
    //    {
    //        switch (state)
    //        {
    //            case GameState.None:
    //                break;
    //            case GameState.MainMenu:
    //                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
    //                _battleInitialization?.Dispose();
    //                break;
    //            case GameState.ChangeTeam:
    //                _changedMenuController = new ChangedMenuController(_profilePlayer, _factoryFlyer, _descriptions);
    //                _mainMenuController?.Dispose();
    //                break;
    //            case GameState.Spawn:
    //                _battleInitialization = new BattleInitialization(_profilePlayer, _descriptions, _factoryFlyer, _updateControllers, _placeForUi);
    //                //_moveManager = new MoveManager(_profilePlayer);
    //                //_moveController = new MoveController();
    //                //_spawnController = new SpawnController(_moveManager, _profilePlayer, _moveController, _descriptions);
    //                _mainMenuController?.Dispose();
    //                break;
    //            case GameState.Battle:
    //                //_battleInitialization = new BattleInitialization(_profilePlayer, _descriptions, _factoryFlyer, _updateControllers, _canvas);
    //                _mainMenuController?.Dispose();
    //                break;
    //            default:
    //                _mainMenuController?.Dispose();
    //                _battleInitialization?.Dispose();
    //                break;
    //        }
    //    }
    }
}