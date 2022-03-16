using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InizializationDataAboutMachinesObtainedFromTable : MonoBehaviour //текущий индекс хранени€ машины 
{
    private int Power = 10;
    private int IndexCar;
    private int indexCar1;
    private AllGarageCarsThePlayer allGarageCarsThePlayer = new AllGarageCarsThePlayer();
    private List<int> intermediateIndex = new List<int>();
    private List<CarS_Player> ItemsListMachin = new List<CarS_Player>();
    public static List<CarS_Player> ListClassCarState; // Ћист стат машин получаемый с таблицы эксель

    private void Start() 
    {
        allGarageCarsThePlayer = ButtonClassSave.LoadFromPlayerPrefs<AllGarageCarsThePlayer>(allGarageCarsThePlayer, "AllGarageCarsThePlayer");
        EventManagerGame.AddListener<EventPushList>(GetIndexMachin);
       // DataTransferUsingGoogleSheet.OnProcessData += LoadingCarExcel;
    }
    public void OnDestroy()
    {
        DataTransferUsingGoogleSheet.OnProcessDataCar -= LoadingCarExcel;
    }
    // »ницизаци€ полученного списка машин с гугл таблицы.
    //—делать меньши ответственности.
    public void LoadingCarExcel(CarStateToList carStateToList, int[] test) 
    {
        ListClassCarState = carStateToList.CarsPlayersList;
        foreach (var item in carStateToList.CarsPlayersList)
        {
            if (indexCar1 != item.IndexMachin)
            {
                this.indexCar1 = item.IndexMachin;
                index.indices.Add(item.IndexMachin);
            }
        }
        jogIndex();
        LoadingStatsPoIndex();
        CarS_Player evt = EventManager.EventAllGarageCarsThePlayer;
        evt = AllGarageCarsThePlayer.AllCarState[0];
        EventManagerGame.Broadcast(evt);
    }
    public void UpgradeStatePower()
    {
        if (true)//деньги нужное кол-во то отн€ть
        {

        }
        EventClassDisplayToUi evt = EventManager.EventDisplayUi;
        evt.Power = Power;
        EventManagerGame.Broadcast(evt);
        LoadingStatsPoIndex();

    }
    public void UpgradeStateSpeed()
    {
        EventClassDisplayToUi evt = EventManager.EventDisplayUi;
        evt.Speed = Power;
        EventManagerGame.Broadcast(evt);
    }
    public void UpgradeStateControl()
    {
        EventClassDisplayToUi evt = EventManager.EventDisplayUi;
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
        foreach (var item in intermediateIndex) // если нет теущей машины, то добавл€ем ее с дефолтными статами.
        {
            foreach (var it in ListClassCarState)
            {
                if (item == it.IndexMachin)
                {
                    CarS_Player CarS_Player = new CarS_Player();
                    CarS_Player.IndexMachin = it.IndexMachin;
                    CarS_Player.Power = it.Power;
                    CarS_Player.Speed = it.Speed;
                    CarS_Player.Control = it.Control;
                    CarS_Player.NameCar = it.NameCar;
                    AllGarageCarsThePlayer.AllCarState.Add(CarS_Player);
                    break;
                }

            }
        }
    }
    public void LoadingStatsPoIndex()
    {
        for (int i = 0; i < ItemsListMachin.Count; i++)
        {
            if(ItemsListMachin.Count == 0)
            {
                break;
            }
            ItemsListMachin.Clear() ;
        }
        foreach (var item in ListClassCarState) //текуща€ машина, используема€ под прокачку 
        {
            if (SetActiveCarSceneGarage.IndexMachinInList == item.IndexMachin)
            {
                ItemsListMachin.Add(item);
            }
        }
    }
    public void GetIndexMachin(EventPushList evt)
    {
        this.IndexCar = evt.indexCarMachin;
    }
}
[System.Serializable]
public class index { public static List<int> indices = new List<int>(); }
