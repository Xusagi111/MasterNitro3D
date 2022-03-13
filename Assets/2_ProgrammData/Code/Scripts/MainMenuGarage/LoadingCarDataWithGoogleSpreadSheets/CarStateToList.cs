using System.Collections.Generic;
[System.Serializable]
public class CarStateToList
{
    public List<CarS_Player> CarsPlayersList;
}
[System.Serializable]
public class CarS_Player : GameEvent
{
    public int IndexMachin;
    public string NameCar;
    public string levelCar;
    public int Power;
    public int Speed;
    public int Control;
    public int indexPowerLevel;
    public int indexSpeedLevel;
    public int indexControlLevel;
}