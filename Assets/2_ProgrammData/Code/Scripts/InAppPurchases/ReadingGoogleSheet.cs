using System.Collections.Generic;

public class ReadingGoogleSheet ///999999 это прочерк
{
    private const int _id = 0;
    private const char _cellSeporator = ',';
    private const char _inCellSeporator = ';';
    
    #region Const
    private const int _const1 = 1;
    private const int _const2 = 2;
    private const int _const3 = 3;
    private const int _const4 = 4;
    private const int _const5 = 5;
    #endregion

    private int dataStartRawIndex = 1;

    private int _idCar;
    private int _indexIdProduct;

    private int[] indexId = new int[3];

    private void ParserTable<T>(string cvsRawData, int _index, T data)
    {
        if (indexId[0] != 0)
        {
            for (int i = 0; i < indexId.Length; i++)
                indexId[i] = 0;
        }
        char lineEnding = GetPlatformSpecificLineEnd();
        string[] rows = cvsRawData.Split(lineEnding);

        for (int i = dataStartRawIndex; i < rows.Length; i++)
        {
           
            string[] cells = rows[i].Split(_cellSeporator);
            int id = ParseInt(cells[_id]);
            string const1 = cells[_const1];
            int const2 = 0;
            if (cells[_const2] == "-")
            {
                 const2 = ParseInt(cells[_const2]);
                 const2 = 999999;
            }
            else
            {
                 const2 = ParseInt(cells[_const2]);
            }
           
            int const3 = ParseInt(cells[_const3]);
            int const4 = ParseInt(cells[_const4]);
            int const5 = ParseInt(cells[_const5]);

            if ( id != 0 && _index != ParseInt(cells[_id]))
            {
                _index = id;
                for (int b = 0; b < indexId.Length; b++)
                {
                    if (indexId[b] == 0)
                    {
                        indexId[b] = _index;

                        break;
                    }

                }
            }
            else
            {
                id = _index;

            }
            if (dataStartRawIndex == 0 || const1 != null && const2 != 0 || const2== 999999)
            {
                if(data is BuyStateToList listbuy)
                    listbuy.ListBuy.Add(new Buy()
                    {
                        IndexKey = id,
                        NameOffer = const1,
                        CountCurrency = const2,
                        Level = const3,
                        PersentBust = const4,
                        Timer = const5,
                    });
                else if (data is GiftsStatsToList giftsStatsToList)
                    giftsStatsToList.ListCifts.Add(new Gifts()
                    {
                        IndexKey = id,
                        NameOffer = const1,
                        CountMoney = const2,
                        CountDiamons = const3,

                    });
                else if (data is CarPriceToList carState)
                    carState.ListCarPrice.Add(new CarPrice()
                    {
                        IndexMachin = id,
                        NameCar = const1,
                        PriceMoney = const2,
                        PriceDiamons = const3,
                    });
            }
        }
    }

    public (BuyStateToList, int[] IndexId) ProcessDataOffers(string cvsRawData) //logic filling in existing machine statistics
    {
        BuyStateToList data = new BuyStateToList();
        data.ListBuy = new List<Buy>();
        ParserTable(cvsRawData, _indexIdProduct, data);
        return (data, indexId);
    }
 
    public (CarPriceToList, int[] IndexId) ProcessDataPriceCar(string cvsRawData) //logic filling in existing machine statistics
    {
        CarPriceToList data = new CarPriceToList();
        data.ListCarPrice = new List<CarPrice>();
        ParserTable(cvsRawData, _indexIdProduct, data);
        return (data, indexId);
    }
    public (GiftsStatsToList, int[] IndexId) ProcessDataGifts(string cvsRawData) //logic filling in existing machine statistics
    {
        GiftsStatsToList data = new GiftsStatsToList();
        data.ListCifts = new List<Gifts>();
        ParserTable(cvsRawData, _idCar, data);
        return (data, indexId);
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
