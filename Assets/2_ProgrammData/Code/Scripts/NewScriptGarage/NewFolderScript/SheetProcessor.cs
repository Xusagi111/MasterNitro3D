using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SheetProcessor: MonoBehaviour
{
    #region Const
    private const int _id = 0;
    private const int _nameCar = 1;
    private const int _levelCar = 2;
    private const int _power = 3;
    private const int _speed = 4;
    private const int _control = 5;
    private const char _cellSeporator = ',';
    private const char _inCellSeporator = ';';
    #endregion
    private int _idCar;
    private int dataStartRawIndex = 1;

    public CarStateToList ProcessData(string cvsRawData) //logic filling in existing machine statistics
    {
        char lineEnding = GetPlatformSpecificLineEnd();
        string[] rows = cvsRawData.Split(lineEnding);
        CarStateToList data = new CarStateToList();
        data.CarsPlayersList = new List<CarS_Player>();

        for (int i = dataStartRawIndex; i < rows.Length; i++)
        {
            string[] cells = rows[i].Split(_cellSeporator);
            int id = ParseInt(cells[_id]);
            string NameCar = (cells[_nameCar]);
            string levelCar = (cells[_levelCar]);
            int Power = ParseInt(cells[_power]);
            int Speed = ParseInt(cells[_speed]);
            int Control = ParseInt(cells[_control]);
            if (id != 0 && _idCar != ParseInt(cells[_id]))
            {
                _idCar = id;
            }
            else
            {
                id = _idCar;
            }
            if (levelCar != "" && Power != 0)
            {
                data.CarsPlayersList.Add(new CarS_Player()
                {
                    IndexMachin = id,
                    NameCar = NameCar,
                    levelCar = levelCar,
                    Power = Power,
                    Speed = Speed,
                    Control = Control
                });
            }
        }
        Debug.Log(data.CarsPlayersList.ToString());
        return data;
    }
    #region DopLogic
    private int ParseInt(string s)
    {
        int result = -1;
        if (!int.TryParse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out result))
        {
            //Debug.Log("Can't parse int, wrong text");
        }

        return result;
    }
    
    private float ParseFloat(string s)
    {
        float result = -1;
        if (!float.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out result))
        {
            //Debug.Log("Can't pars float,wrong text ");
        }

        return result;
    }
    
    private char GetPlatformSpecificLineEnd()
    {
        char lineEnding = '\n';
#if UNITY_IOS
        lineEnding = '\r';
#endif
        return lineEnding;
    }
    #endregion
}
