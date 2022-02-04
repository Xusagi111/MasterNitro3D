using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class ExelStateMachin : MonoBehaviour
{
    
    public static string Excel = "TableCar1";

    // Запрос таблицы меню

    public static List<CarS_Player> CarStatsRead()
    {
        
        string excelName = Excel + ".xlsx";
        int indexMachin = 0;

    string sheetName = "Cars";
        DataRowCollection collect = ExelStateMachin.ReadExcel(excelName, sheetName);
        // Debug.Log(collect.Count);

        List<CarS_Player> menuArray = new List<CarS_Player>();

        for (int i = 1; i < collect.Count; i++)
        {
            if (collect[i][0].ToString() == "-") { i += 2; Debug.Log("new"); }
            if (collect[i][0].ToString() != "") { indexMachin = int.Parse(collect[i][0].ToString());  }

            if (collect[i][2].ToString() != "" && collect[i][3].ToString() != "")
            {
                CarS_Player menu = new CarS_Player
                {
                    NameCar = collect[i][2].ToString(),
                    Power = int.Parse(collect[i][3].ToString()),
                    IndexMachin = indexMachin
                };
                menuArray.Add(menu);
            }
        }
        return menuArray;
    }


    /// <summary>

    /// Чтение Excel; необходимо добавить Excel.dll; System.Data.dll;

    /// </summary>

    /// <param name = "excelName"> имя файла excel </ param>

    /// <param name = "sheetName"> имя листа </ param>

    /// <Return> DataRow Collection </ Return>

    static DataRowCollection ReadExcel(string excelName, string sheetName)
    {

        string path = Application.dataPath + "/" + excelName;


        FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);


        DataSet result = excelReader.AsDataSet();
        //int columns = result.Tables[0].Columns.Count;

        //int rows = result.Tables[0].Rows.Count;


        // таблицы могут быть получены по имени листа или по индексу листа

        //return result.Tables[0].Rows;

        return result.Tables[sheetName].Rows;

    }
}
[System.Serializable]
public class CarS_Player
{
    public int IndexMachin;
    public string NameCar;
    public int Power;
    //public int Speed;
    //public int Control;  
}
public class index { public ArrayList indices = new ArrayList(); }

