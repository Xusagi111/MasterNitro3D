using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject UpdatePanel;
    [SerializeField] private GameObject FpsPanel;
    [SerializeField] private GameObject LoadingPanel;
    [SerializeField] private GameObject PlayGameButton;
    [SerializeField] private GameObject PlayerNoConnectToServerImage;

    private void Start()
    {
        UrlSheetLoading.NotConnectToServer += ServerConnectionCheck;
        LoadingPanel.SetActive(true);
    }
    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
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
    public void ServerConnectionCheck(bool state)
    {
        if (state)
        {
            if (DontDestroy.CountLoad == 0)
            {
                DontDestroy.CountLoad++;
                StartCoroutine(ActivationPlayButton());
            }
            else
            {
                StartCoroutine(ActivationPlayButton());
            }
        }
        else if (state != true)
        {
            NoServerConnection();
        }
      
    }
    IEnumerator ActivationPlayButton()
    {
        yield return new WaitForSeconds(3f);
        PlayGameButton.SetActive(true);
    }
    public void NoServerConnection()
    {
        PlayerNoConnectToServerImage.SetActive(true);
    }
    public void ActivationMainMenuScene()
    {
        LoadingPanel.SetActive(false);
        PlayGameButton.SetActive(false);
    }
}
