using System;
using UnityEngine;

public class GameManagerToScenesd : MonoBehaviour
{
    public Action<int> EventIndexCar;
    public int CurrentIndexCar { get; set; }

    public StartLevel startLevel;
    void Start()
    {
        EventIndexCar += UpdateIndexCar;
    }
    private void UpdateIndexCar(int indexCar)
    {
        CurrentIndexCar = indexCar;
    } 
}
