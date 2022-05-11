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
}
public class SaveMusicStats
{
    public float Music;
    public float Effects;
}
[System.Serializable]
public class AllCarTheGarage //ToDo ��������� � ���� ������
{
    public string[] CarYellow = { "Name", "CarYellow", "Price", "1000", "Power", "Lvl", "0", "State", "11", "Speed", "Lvl", "0", "State", "12", "Fuel", "Lvl", "0", "State", "13" };
    public string[] Chev = { "Name", "Chev", "Price", "2000", "Power", "Lvl", "0", "State", "21", "Speed", "Lvl", "0", "State", "22", "Fuel", "Lvl", "0", "State", "23" };
    public string[] Vehicle = { "Name", "Vehicle", "Price", "3000", "Power", "Lvl", "0", "State", "31", "Speed", "Lvl", "0", "State", "32", "Fuel", "Lvl", "0", "State", "33" };
    public string[] CarCarbon = { "Name", "CarCarbon", "Price", "4000", "Power", "Lvl", "0", "State", "41", "Speed", "Lvl", "0", "State", "42", "Fuel", "Lvl", "0", "State", "43" };
    public string[] FocE = { "Name", "FocE", "Price", "5000", "Power", "Lvl", "0", "State", "51", "Speed", "Lvl", "0", "State", "52", "Fuel", "Lvl", "0", "State", "53" };
    public string[] upgradeAllLvl = { "1000", "2000", "3000", "4000", "5000", "6000", "7000"};
}
[System.Serializable]
public class AllGarageCarsThePlayer //������� ������ ������
{
    public static List<CarS_Player> AllCarState = new List<CarS_Player>();
}
//��������� ���� ����� ��� ����� ������������ ���� �������
[System.Serializable]
public class CurrentCarPlayer { public List<int> CarPlayer = new List<int>() { 123}; }

