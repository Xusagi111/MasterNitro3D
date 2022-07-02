using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePlayerStats
{
    public string NamePlayer = "Name";
    public int Money = 1000;
    public int Diamons = 0;

    public int ExpToNewLevel;
    public int ExpPlayer;
    public int LevelPlayer;
    public int CountReward;
    [field: SerializeField] public DataConstLevel DataConstLevel { get; set; } = new DataConstLevel();
    [field: SerializeField] public List<List<int>> RewardToPlayer { get; set; } = new List<List<int>>();
}
public class SaveMusicStats
{
    public float Music = 0.35f;
    public float Effects = 0.5f;
}

[System.Serializable]
public class AllGarageCarsThePlayer //текущий индекс машины
{
    public static List<CarS_Player> AllCarState = new List<CarS_Player>();
}
//перенести этот класс где будет реализованна гугл таблица
[System.Serializable]
public class CurrentCarPlayer { public List<int> CarPlayer = new List<int>() { 123}; }