using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingGoogleSheet : MonoBehaviour
{
    #region Const
    private const int _id = 0;
    private const int _nameOffer = 1;
    private const int _countCurrency = 2;
    private const int _levelBust= 3;
    private const int _persentBust = 4;
    private const char _cellSeporator = ',';
    private const char _inCellSeporator = ';';
    #endregion
    private int _idCar;
    private int dataStartRawIndex = 1;

    public BuyStateToList ProcessData(string cvsRawData) //logic filling in existing machine statistics
    {
        char lineEnding = GetPlatformSpecificLineEnd();
        string[] rows = cvsRawData.Split(lineEnding);
        BuyStateToList data = new BuyStateToList();
        data.ListBuy = new List<Buy>();

        for (int i = dataStartRawIndex; i < rows.Length; i++)
        {
            string[] cells = rows[i].Split(_cellSeporator);
            int id = ParseInt(cells[_id]);
            int NameOffer = ParseInt(cells[_nameOffer]);
            int CountCurrency = ParseInt(cells[_countCurrency]);
            int LevelBust = ParseInt(cells[_levelBust]);
            int PersentBust = ParseInt(cells[_persentBust]);
            if (id != 0 && _idCar != ParseInt(cells[_id]))
            {
                _idCar = id;
            }
            else
            {
                id = _idCar;
            }
            if (NameOffer.ToString() != "" && CountCurrency != 0)
            {
                data.ListBuy.Add(new Buy()
                {
                    IndexKey = id,
                    NameOffer = NameOffer,
                    CountCurrency = CountCurrency,
                    LevelBust = LevelBust,
                    PersentBust = PersentBust
                });
            }
        }
        //Debug.Log(data.ListBuy.ToString());
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
