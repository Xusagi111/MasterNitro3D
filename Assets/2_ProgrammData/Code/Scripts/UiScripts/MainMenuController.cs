using System.Collections;
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

    [SerializeField] private GameObject PanelActiveLevel;
    [SerializeField] private GarageController _garageController;

    [SerializeField] private GameObject LoadingToMovmentScene;
    private GameManagerToScenes _gameManagerToScene;

    [SerializeField] private GameObject ActiveLoadingBar;
    [SerializeField] private Image ActiveLoadingBarImage;
    [SerializeField] private Text CurrentPercentLoading;

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
        StartCoroutine(StartLevelToActiveLoadingPanel());
    }
    public void StartPanelChoiuseLevel()
    {
        _gameManagerToScene = FindObjectOfType<GameManagerToScenes>();
        for (int i = 0; i < _garageController.instanseCurrentCarPlayer.CarPlayer.Count; i++)
        {
            if (_gameManagerToScene.IndexCar == _garageController.instanseCurrentCarPlayer.CarPlayer[i])
            {
                PanelActiveLevel.SetActive(true);
                return;
            }
        }
    }
   
    private IEnumerator StartLevelToActiveLoadingPanel()
    {

        var MovingToScene = SceneManager.LoadSceneAsync("Game");
        MovingToScene.allowSceneActivation = false;
        LoadingToMovmentScene.SetActive(true);

        yield return new WaitForSeconds(3f);
        MovingToScene.allowSceneActivation = true;
        
    }
    public void OpenUpdatePanel()
    {
        if (!UpdatePanel.activeSelf )
            UpdatePanel.SetActive(true);

        else
            UpdatePanel.SetActive(false);

    }
    public void OpenFpsPanel()
    {
        if (!FpsPanel.activeSelf)
            FpsPanel.SetActive(true);

        else
            FpsPanel.SetActive(false);
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
        ActiveLoadingBar.SetActive(true);
        StartCoroutine(StartMoveSlider(0));
        yield return new WaitForSeconds(3f);
        PlayGameButton.SetActive(true);
        CurrentPercentLoading.SetActive(false);
        ActiveLoadingBar.SetActive(false);

    }
    IEnumerator StartMoveSlider(float CurrentValueImage)
    {
        int currentPercent = 0;
        while (currentPercent < 97)
        {
            CurrentValueImage += 0.0016f;
            ActiveLoadingBarImage.fillAmount = CurrentValueImage;
            currentPercent = (int)(CurrentValueImage / 0.01f);
            CurrentPercentLoading.text = currentPercent + " %";
            if (currentPercent > 99)
            {
                StopCoroutine(StartMoveSlider(CurrentValueImage));
            }
            yield return new WaitForSeconds(0.003f);
        }
        if (currentPercent >= 97)
        {
            CurrentPercentLoading.text = "100 %";
        }
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
