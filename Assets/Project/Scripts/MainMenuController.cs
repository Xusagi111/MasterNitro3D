using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject SatingsPanel;
    public void OpenSatingsPanel(bool state)
    {
        SatingsPanel.SetActive(state);
    }
    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }    
}
