using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject UpdatePanel;
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
    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }    
}
