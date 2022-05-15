using System;
using UnityEngine;

public class GameManagerToScenesd : MonoBehaviour
{
    public Action<int> EventTransferCar;
    public int IndexCar { get; set; }

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
