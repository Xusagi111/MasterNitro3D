using System.Collections.Generic;
using UnityEngine;

namespace Event
{
    public class SubscriptionStorage
    {
        //public SubscriptionProperty<GameState> CurrentState { get; }
        //public SubscriptionProperty<List<IFlyer>> TeamOne { get; }
        //public SubscriptionProperty<List<IFlyer>> TeamTwo { get; }
        //public SubscriptionProperty<RayCastManager> RayCast { get; }

        //public SubscriptionStorage() // Конструктор который осуществляет подписку.
        //{
        //    CurrentState = new SubscriptionProperty<GameState>();
        //    TeamOne = new SubscriptionProperty<List<IFlyer>>()
        //    {
        //        Value = new List<IFlyer>()
        //    };
        //    TeamTwo = new SubscriptionProperty<List<IFlyer>>()
        //    {
        //        Value = new List<IFlyer>()
        //    };
        //    CurrentState.Value = GameState.MainMenu;
            
        //    RayCast = new SubscriptionProperty<RayCastManager>()
        //    {
        //        Value = new RayCastManager()
        //    };

        //    RayCast.Value.SetHitInfo();
        //}
    }

    public enum GameState
    {
        None,
        MainMenu,
        ChangeTeam,
        Spawn,
        Battle
    }
}