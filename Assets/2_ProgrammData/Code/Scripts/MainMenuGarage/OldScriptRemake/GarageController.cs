using UnityEngine;

public class GarageController : MonoBehaviour 
{
    private SavePlayerStats _savePlayerStats = new SavePlayerStats();
    public SavePlayerStats instanseSavePlayerState { get => _savePlayerStats; private set => _savePlayerStats = value; }
    private void Start()
    {
        loagingPlayerState();
        StartUpdateDisplayValue();
    }
    public void SetValueSavePlayerStats(EnumIdToBuy enumIdToBuy, bool UpdateDisplay = true, int value = 0, int value2 = 0)
    {
        if (EnumIdToBuy.indexMoney == enumIdToBuy) { instanseSavePlayerState.Money += value; }
        if (EnumIdToBuy.indexDiamons == enumIdToBuy) { instanseSavePlayerState.Diamons += value; }
        if (EnumIdToBuy.indexOffers == enumIdToBuy) { instanseSavePlayerState.Money += value; instanseSavePlayerState.Diamons += value2; }
        SavePlayerState();
        if (UpdateDisplay)
        {
            StartUpdateDisplayValue();
        }
    }
    public void SavePlayerState()
    {
        ButtonClassSave.SaveToPlayerPrefs<SavePlayerStats>(instanseSavePlayerState, "instanseSavePlayerState");
    }
    public void loagingPlayerState()
    {
        instanseSavePlayerState = ButtonClassSave.LoadFromPlayerPrefs<SavePlayerStats>(instanseSavePlayerState, "instanseSavePlayerState");
    }
    public void StartUpdateDisplayValue()
    {
        EventSaveStatePlyer evt = EventManager.EventSaveStatePlyer;
        evt.Money = instanseSavePlayerState.Money;
        evt.Diamons = instanseSavePlayerState.Diamons;
        EventManagerGame.Broadcast(evt);
    }
}
