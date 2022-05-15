using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject UpdatePanel;
    [SerializeField] private GameObject FpsPanel;
    [SerializeField] private GameObject LoadingPanel;
    [SerializeField] private GameObject PlayGameButton;
    [SerializeField] private GameObject PlayerNoConnectToServerImage;

    [SerializeField] private DontDestroy _dontDestroy;
    [SerializeField] private GameManagerToScenesd _gameManagerToScene;


    private void Awake()
    {
        UrlSheetLoading.NotConnectToServer += ServerConnectionCheck;
        if (DontDestroy.CountLoad == 0) { LoadingPanel.SetActive(true); }    
    }

    private void OnDestroy()
    {
        UrlSheetLoading.NotConnectToServer -= ServerConnectionCheck;
    }
    public void OpenGame(int Level) 
    {
        _gameManagerToScene = FindObjectOfType<GameManagerToScenesd>();
        switch (Level)
        {
            case (int)StartLevel.DinamicCreateLevel:
                _gameManagerToScene.startLevel = StartLevel.DinamicCreateLevel;
                break;
            case (int)StartLevel.OneScene:
                _gameManagerToScene.startLevel = StartLevel.OneScene;
                break;
            case (int)StartLevel.TwoScene:
                _gameManagerToScene.startLevel = StartLevel.TwoScene;
                break;
            default:
                break;
        }
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
    public void RestartScene()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
