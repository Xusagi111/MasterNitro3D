using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SavePlayerStats
{
    public string NamePlayer = "Name";
    public int Money = 1000;
    public int Diamons = 0;

    public int ExpPlayer;
    public int LevelPlayer;
    public int GetCurrentReward;
}
public class SaveMusicStats
{
    public float Music;
    public float Effects;
}

[System.Serializable]
public class AllGarageCarsThePlayer //������� ������ ������
{
    public static List<CarS_Player> AllCarState = new List<CarS_Player>();
}
//��������� ���� ����� ��� ����� ������������ ���� �������
[System.Serializable]
public class CurrentCarPlayer { public List<int> CarPlayer = new List<int>() { 123}; }

public class PlayerExp 
{ 

}
public class HeaderPlayerExp
{
    public int AnalizCurrentLevel() 
    {
        DataConstLevel dataConstLevel = new DataConstLevel(); //�������� ������� ������ � �������.
        int LevelPlayer = 6; //�������� �������� ������� ������.

        int ConvertationValue; 

        for (int i = 0; i < dataConstLevel.LevelConsts.Count; i++)
        {
            if (dataConstLevel.LevelConsts[i].level[1] <= LevelPlayer && dataConstLevel.LevelConsts[i].level[2] >= LevelPlayer)
            {
                ConvertationValue = dataConstLevel.LevelConsts[i].Conversion;
                return ConvertationValue;
            }
        }
        return 999999;
    }
    public int CountValueExp()
    {
        int currentCountDriftSpecs = 100;
        int GetExp;
        int ConvertationValue = 0;
       return GetExp = currentCountDriftSpecs / ConvertationValue;
    }
    public void CheckLevel()
    {
        SavePlayerStats _savePlayerStats =  new SavePlayerStats();
        _savePlayerStats.ExpPlayer += CountValueExp(); //Current Exp


        DataConstLevel dataConstLevel = new DataConstLevel(); //�������� ������� ������ � �������.
        for (int i = 0; i < dataConstLevel.LevelConsts.Count; i++)
        {
            int Current = 0;//������� ���� �� ������
            //if (dataConstLevel.LevelConsts[i].DefoltExp + > )
            //{

            //}
            //dataConstLevel.LevelConsts[i].�
        }
    }
}