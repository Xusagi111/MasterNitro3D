using UnityEngine;
using UnityEngine.UI;

class UpdatePlayerStateUI : MonoBehaviour
{
    [SerializeField] Text conclusionOnMoneyUI;
    [SerializeField] Text conclusionOnDiamondsUI;
    private void Awake()
    {
        EventManagerGame.AddListener<EventSaveStatePlyer>(DisplayUiStatsR);
    }
    public void DisplayUiStatsR(EventSaveStatePlyer evt)
    {
        conclusionOnMoneyUI.text = evt.Money.ToString();
        conclusionOnDiamondsUI.text = evt.Diamons.ToString();
    }
    private void OnDisable()
    {
        EventManagerGame.RemoveListener<EventSaveStatePlyer>(DisplayUiStatsR);
    }
}

