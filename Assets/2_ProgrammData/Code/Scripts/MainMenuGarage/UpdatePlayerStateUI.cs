using UnityEngine;
using UnityEngine.UI;

class UpdatePlayerStateUI : MonoBehaviour
{
    [field: SerializeField] private Text MoneyUI { get; set; }
    [field: SerializeField] private Text DiamondsUI { get; set; }
    [field: SerializeField] private  Text Level { get; set; }
    private void Awake()
    {
        EventManagerGame.AddListener<EventSaveStatePlyer>(DisplayUiStatsR);
    }
    public void DisplayUiStatsR(EventSaveStatePlyer evt)
    {
        MoneyUI.text = evt.Money.ToString();
        DiamondsUI.text = evt.Diamons.ToString();
        Level.text = "LEVEL " + evt.Level.ToString();
    }
    private void OnDisable()
    {
        EventManagerGame.RemoveListener<EventSaveStatePlyer>(DisplayUiStatsR);
    }
}

