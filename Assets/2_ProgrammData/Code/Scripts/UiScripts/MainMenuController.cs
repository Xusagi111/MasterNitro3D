using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject UpdatePanel;
    [SerializeField] private GameObject FpsPanel;
    [SerializeField] private GameObject LoadingPanel;
    [SerializeField] private GameObject PlayGameButton;

    private void Start()
    {
        if (DontDestroy.CountLoad == 0)
        {
            DontDestroy.CountLoad++;
            LoadingPanel.SetActive(true);
            StartCoroutine(ActivationPlayButton());
        }
    }
    public void OpenSettingsPanel(bool state)
    {
        SettingsPanel.SetActive(state);
    }
    public void OpenGame()
    {
        SceneManager.LoadScene("Game_Level1_Suburb");
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
    IEnumerator ActivationPlayButton()
    {
        yield return new WaitForSeconds(3f);
        PlayGameButton.SetActive(true);
    }
    public void ActivationMainMenuScene()
    {
        LoadingPanel.SetActive(false);
        PlayGameButton.SetActive(false);
    }
}
