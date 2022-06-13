using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLevelToPlayer : MonoBehaviour
{
    [field: SerializeField] private DataConstLevel _dataConstLevel { get; set; }
    [field: SerializeField] private SavePlayerStats PlayerData { get; set; }
    [field: SerializeField] private GarageController _garageController { get; set; }
    public static Action<int> EventCalculationGlasses { get; set; }

    private void Awake()
    {
        DataTransferUsingGoogleSheet.EventDatalevel += ControllerLevel;
        EventCalculationGlasses += CalculationToTravelGlasses;
    }
    private void OnDestroy()
    {
        DataTransferUsingGoogleSheet.EventDatalevel -= ControllerLevel;
        EventCalculationGlasses -= CalculationToTravelGlasses;
    }
    private void ControllerLevel(DataConstLevel dataConstLevel)
    {
        this._dataConstLevel = dataConstLevel;
    }
    private IEnumerator CalculationGlasses(int Glasses)
    {
        yield return new WaitForSeconds(0.1f);
        var a = CalculationExpForGlassesTravel(Glasses); //Возращает exp игрока
        if (a != null)
        {
            _garageController.instanseSavePlayerState.ExpPlayer += (int)a;
            ControllerDataTravel();
        }
    }
    private void CalculationToTravelGlasses(int Glasses)
    {
        StartCoroutine(CalculationGlasses(Glasses));
    }

    private (int?,int?,int?, List<int>) CalculationExpPlayer()
    {
        PlayerData = _garageController.instanseSavePlayerState;

        if (_dataConstLevel == null)
          _dataConstLevel = _garageController.instanseSavePlayerState.DataConstLevel;
        
        if (PlayerData.DataConstLevel.LevelConsts.Count == 0 || PlayerData.DataConstLevel.LevelConsts[0].Coefficient != _dataConstLevel.LevelConsts[0].Coefficient)
            PlayerData.DataConstLevel = _dataConstLevel;
        
        float CurrentExpPlayerToNewLevel = 0;
        float DefoltExp = _dataConstLevel.LevelConsts[0].DefoltExp;
        int LEVEL = 0;
        List<int> Reward = new List<int>();

        //Cравнение по Exp
        for (int i = 0; i < _dataConstLevel.LevelConsts.Count; i++)
        {
            var CurrentDifferenceLevel = _dataConstLevel.LevelConsts[i].level[1] - _dataConstLevel.LevelConsts[i].level[0];
            for (int b = 0; b < CurrentDifferenceLevel; b++)
            {
                DefoltExp = _dataConstLevel.LevelConsts[i].Coefficient * DefoltExp;
                CurrentExpPlayerToNewLevel += DefoltExp;
                if (PlayerData.ExpPlayer < CurrentExpPlayerToNewLevel)
                {
                    return (LEVEL, (int)CurrentExpPlayerToNewLevel, (int)DefoltExp, Reward);
                }
                LEVEL++;
                if (LEVEL > _garageController.instanseSavePlayerState.LevelPlayer)
                {
                    Reward.Add((int)DefoltExp);
                }
            }
        }
        return (null, null, null,null);
    }
    private int? CalculationExpForGlassesTravel(int Glasses) //Передать через ивент
    {
        for (int i = 0; i < _dataConstLevel.LevelConsts.Count; i++)
        {
            if (_garageController.instanseSavePlayerState.LevelPlayer < _dataConstLevel.LevelConsts[i].level[1])
            {
                var Exp =  Glasses / _dataConstLevel.LevelConsts[i].Conversion;
                return Exp;
            }
        }
        return null;
    }
    private void ControllerDataTravel()
    {
        var a = CalculationExpPlayer();
        if (_garageController.instanseSavePlayerState.LevelPlayer < a.Item1)
            UpdateDisplayToCountReward.EventAddRewardPlayer?.Invoke(a.Item4); //Текущая не расспределенная награда. 

        SaveToStateTravelPlayer((int)a.Item1, (int)a.Item2, (int)a.Item3);

        Debug.Log($"LEVEL {a.Item1} ExpPlayer {_garageController.instanseSavePlayerState.ExpPlayer}  (int)ExpToNewLevel {a.Item2} (int)DefoltExp) {a.Item3} ");
    }
    private void SaveToStateTravelPlayer(int CurrentLevel, int ExpToNewLevel, int CountReward)
    {
        _garageController.instanseSavePlayerState.LevelPlayer = CurrentLevel;
        _garageController.instanseSavePlayerState.ExpToNewLevel = ExpToNewLevel;
        _garageController.instanseSavePlayerState.CountReward = CountReward;
        _garageController.SavePlayerState();
        _garageController.StartUpdateDisplayValue();
    }
}