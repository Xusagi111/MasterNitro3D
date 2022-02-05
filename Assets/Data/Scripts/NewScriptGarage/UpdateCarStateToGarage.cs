using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCarStateToGarage : MonoBehaviour //EventConclusionTheDisplayUIStatsMachin //текущий индекс хранени€ машины 
{
    public int Power = 10;
    public int IndexCar;
    AllGarageCarsThePlayer allGarageCarsThePlayer = new AllGarageCarsThePlayer();
    private List<int> intermediateIndex = new List<int>();
    private void Start() //Load
    {
        allGarageCarsThePlayer = ButtonClassSave.LoadFromPlayerPrefs<AllGarageCarsThePlayer>(allGarageCarsThePlayer, "AllGarageCarsThePlayer");
        jogIndex();


    }
    public void UpgradeStatePower()
    {
        Test1 evt= EventManager.Test1;
        evt.Power = Power;
        EventManagerGame.Broadcast(evt);
    }

    public void UpgradeStateSpeed()
    {
        Test1 evt = EventManager.Test1;
        evt.Speed = Power;
        EventManagerGame.Broadcast(evt);
    }
    public void UpgradeStateControl()
    {
        Test1 evt = EventManager.Test1;
        evt.Control = Power;
        EventManagerGame.Broadcast(evt);
    }
    public void jogIndex()
    {
        foreach (var item in index.indices)
        {
            intermediateIndex.Add(item);
        }
        foreach (var item in AllGarageCarsThePlayer.AllCarState) //проверка на экземпл€ры класса после считывани€ с Json file.
        {
            foreach (var it in index.indices)
            {
                if (item.IndexMachin.ToString() == it.ToString())
                {
                    intermediateIndex.Remove(it);
                }
            }
 
        }

        foreach (var item in intermediateIndex) //ƒобавл€ет экземпл€ры с индексом, если их нету
        {
            CarS_Player CarS_Player = new CarS_Player();
            CarS_Player.IndexMachin = item;
            AllGarageCarsThePlayer.AllCarState.Add(CarS_Player);
        }
        
    }
    public void ChecState()
    {

    }
    public void LoadingStatsPoIndex()
    {

    }
}
