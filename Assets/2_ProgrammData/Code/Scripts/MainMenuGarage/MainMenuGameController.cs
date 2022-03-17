using System.Collections.Generic;
using UnityEngine;

public class MainMenuGameController : MonoBehaviour
{
    private GiftsStatsToList DataGiftsStatsToList = new GiftsStatsToList(); //проверить будет ли работать без new
    public GiftsStatsToList PropDataGiftsStatsToList
    {
        get { return DataGiftsStatsToList; }
        private set { DataGiftsStatsToList = value; }
    }

    private void Start()
    {
        DataTransferUsingGoogleSheet.EventDataGift += DataPresents;
    }
    public void DataPresents(GiftsStatsToList giftsStatsToList, int[] indexPresent)
    {
        PropDataGiftsStatsToList.ListCifts = giftsStatsToList.ListCifts;
    }
}

