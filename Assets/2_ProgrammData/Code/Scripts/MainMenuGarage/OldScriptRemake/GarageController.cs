using UnityEngine;

public class GarageController : MonoBehaviour 
{
    public SavePlayerStats instanseSavePlayerState { get => _savePlayerStats; private set => _savePlayerStats = value; }
    public CurrentCarPlayer instanseCurrentCarPlayer { get => _currentCarPlayer; private set => _currentCarPlayer = value; }

    [SerializeField] private SavePlayerStats _savePlayerStats = new SavePlayerStats();
    [SerializeField] private CurrentCarPlayer _currentCarPlayer= new CurrentCarPlayer();
   
    private void Awake()
    {
        loagingPlayerState();
    }
    private void Start()
    {
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
        ButtonClassSave.SaveToPlayerPrefs<CurrentCarPlayer>(instanseCurrentCarPlayer, "instanseCurrentCarPlayer");

    }
    public void loagingPlayerState()
    {
        instanseSavePlayerState = ButtonClassSave.LoadFromPlayerPrefs<SavePlayerStats>(instanseSavePlayerState, "instanseSavePlayerState");
        instanseCurrentCarPlayer = ButtonClassSave.LoadFromPlayerPrefs<CurrentCarPlayer>(instanseCurrentCarPlayer, "instanseCurrentCarPlayer");
    }
    public void StartUpdateDisplayValue()
    {
        EventSaveStatePlyer evt = EventManager.EventSaveStatePlyer;
        evt.Money = instanseSavePlayerState.Money;
        evt.Diamons = instanseSavePlayerState.Diamons;
        EventManagerGame.Broadcast(evt);
    }
}
