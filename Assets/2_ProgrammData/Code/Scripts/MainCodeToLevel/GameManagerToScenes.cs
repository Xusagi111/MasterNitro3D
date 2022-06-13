using System;
using UnityEngine;

public class GameManagerToScenes : MonoBehaviour
{
    public Action<int> EventTransferCar { get; set; }
    [field: SerializeField]  public int IndexCar { get; set; }
    [field: SerializeField] public int CurrentGlassesToTravel { get; set; }
    [field: SerializeField] public int CurrentMoneyToTravel { get; set; }

    public StartLevel startLevel;
    void Awake()
    {
        EventTransferCar += UpdateIndexCar;
    }
    private void UpdateIndexCar(int CurrentCar)
    {
        this.IndexCar = CurrentCar;
    } 
}
