using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIToGarage : MonoBehaviour //GetUpdateUIToGarage
{
    [SerializeField] Text conclusionNameCarOnUI;
    [SerializeField] Text conclusionOnPowerUI;
    [SerializeField] Text conclusionOnSpeedUI;
    [SerializeField] Text conclusionOnControlUI;
    [SerializeField] Text UpgrageToUIPanelPowerLvl;
    [SerializeField] Text UpgrageToUIPanelSpeedLvl;
    [SerializeField] Text UpgrageToUIPanelControlLvl;
    private void Start()
    {
        EventManagerGame.AddListener<EventClassDisplayToUi>(DisplayUiStatsR);
        EventManagerGame.AddListener<CarS_Player>(DisplayUistateRS); 
    }
    public void DisplayUiStatsR(EventClassDisplayToUi evt)
    {
        conclusionOnPowerUI.text = evt.Power.ToString();
        conclusionOnSpeedUI.text = evt.Speed.ToString();
        conclusionOnControlUI.text = evt.Control.ToString();
    }
    public void DisplayUistateRS(CarS_Player evt)
    {
        conclusionOnPowerUI.text = evt.Power.ToString();
        conclusionOnSpeedUI.text = evt.Speed.ToString();
        conclusionOnControlUI.text = evt.Control.ToString();
        conclusionNameCarOnUI.text = evt.NameCar;
    }

}
