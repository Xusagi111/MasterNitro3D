using System.Collections.Generic;
using UnityEngine;

public class ReadLevel : MonoBehaviour 
{
    private const int level = 0;
    private const char _cellSeporator = ',';
    private const char _inCellSeporator = ';';
    private const char _defis = '-';

    #region Const
    private const int _const1 = 1;
    private const int _const2 = 2;
    private const int _const3 = 3;
    private const int _const4 = 4;
    private const int _const5 = 5;
    #endregion

    private int dataStartRawIndex = 6;

    private int _idCar;
    private int _indexIdProduct;
    private string CurrentContLevel;
    private void ParserTable<T>(string cvsRawData, int _index, T data)
    {
        char lineEnding = GetPlatformSpecificLineEnd();
        string[] rows = cvsRawData.Split(lineEnding);

        for (int i = dataStartRawIndex; i < rows.Length; i++)
        {

            string[] cells = rows[i].Split(_cellSeporator);

            CurrentContLevel = "";
            bool flagSwitchingLevel = false;
            string[] CurrentLevel = new string[2];
          
            for (int b = 0; b < cells[level].Length; b++) //Преобразование level из String  в int
            {
                if (cells[level][b] != _defis)
                {
                    if (!flagSwitchingLevel)
                    {
                        CurrentLevel[0] += cells[level][b];
                    }
                    else
                    {
                        CurrentLevel[1] += cells[level][b];
                    }
                  
                }
                else
                    flagSwitchingLevel = true;
               
            }
            if (CurrentLevel[0] == null && CurrentLevel[1] == null) continue;
            int[] CurrentLevelToPush = new int[2];
            CurrentLevelToPush[0] = int.Parse(CurrentLevel[0]);

            CurrentLevelToPush[1] = int.Parse(CurrentLevel[1]);

            int const1 = ParseInt(cells[_const1]);
            int const2 = ParseInt(cells[_const1]);
            float const3 = ParseFloat(cells[_const3]);
            int const4 = ParseInt(cells[_const4]);

            if (const3 != 0 && const4 != 0)
            {
                if (data is DataConstLevel dataConstLevel)
                    dataConstLevel.LevelConsts.Add(new LevelConst()
                    {
                        level = CurrentLevelToPush,
                        DefoltExp = const1,
                        UpReward = const2,
                        Coefficient = const3,
                        Conversion = const4,
                    });

            }

        }
    }

    public DataConstLevel ProcessDataLevel(string cvsRawData) //logic filling in existing machine statistics
    {
        DataConstLevel data = new DataConstLevel();
        data.LevelConsts = new List<LevelConst>();
        ParserTable(cvsRawData, _indexIdProduct, data);
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
