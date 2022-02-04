using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject UpdatePanel;
    [SerializeField] GameObject FpsPanel;
    public GameObject PanelAlertsTrafficNotSide;
    public void OpenSatingsPanel(bool state)
    {
        SettingsPanel.SetActive(state);
    }

    public void OpenUpdatePanel()
    {
        if (!UpdatePanel.activeSelf )
        {
            UpdatePanel.SetActive(true);
        }
        else
        {
            UpdatePanel.SetActive(false);
        }

    }
    public void OpenFpsPanel()
    {
        if (!FpsPanel.activeSelf)
        {
            FpsPanel.SetActive(true);
        }
        else
        {
            FpsPanel.SetActive(false);
        }

    }
    public void OpenGame()
    {
        SceneManager.LoadScene("Game_Level1_G");
    }    
}
