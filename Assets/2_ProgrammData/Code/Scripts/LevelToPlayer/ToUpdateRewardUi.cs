using UnityEngine;
using UnityEngine.UI;

public class ToUpdateRewardUi : MonoBehaviour
{
    [field: SerializeField] private UpdateDisplayToCountReward _updateDisplayToCountReward; //Прокидывается руками.
    [field: SerializeField] private GarageController _garageController; //Прокидывается руками.
    [field: SerializeField] private GameObject UIReward;
    [field: SerializeField] private Text TextCurrentReward;
    [field: SerializeField] private Text TextDisplayExperience;
    [field: SerializeField] private Text TextDisplayLevel;
    [field: SerializeField] private Text TextDisplayToNewLevel;
    [field: SerializeField] private Text TextToMoneyMainMenu;
    [field: SerializeField] private Text CurrentLevelToMainMenu;

    [field: SerializeField] private Image BarExp { get; set; }
    [field: SerializeField] private Button ButtonGetReward;
    private bool isClickPlayer { get; set; }
    private void Awake()
    {
        ButtonGetReward.onClick.AddListener(() => CloseRewardPanel());  
    }
    private void OnEnable()
    {
        if (_updateDisplayToCountReward.RewardToPlayer.Count > 0)
            isClickPlayer = true;
        else
            isClickPlayer = false;

        UpdateDisplayMainMenu();
        OpenPanelExp();

    }
    private void UpdateDisplay(int CurrentExpLevel, int ExpToNewLevel, int CurrentLevel, int Money) 
    {
        
        var a =  ((float)CurrentExpLevel / (float)ExpToNewLevel);
        BarExp.fillAmount = a;

        TextDisplayExperience.text = CurrentExpLevel.ToString() + "/" + ExpToNewLevel;
        TextDisplayLevel.text = CurrentLevel.ToString();
        TextDisplayToNewLevel.text = (CurrentLevel + 1).ToString();
        TextToMoneyMainMenu.text = Money.ToString();
        CurrentLevelToMainMenu.text = $"LEVEL {_garageController.instanseSavePlayerState.LevelPlayer}"; 
    }
    private void OpenPanelExp()
    {
        while (isClickPlayer)
        {
            for (int i = 0; i < 3; i++) //Проверка на награду. 
            {
                if (_updateDisplayToCountReward.RewardToPlayer.Count == 0)
                    return;

                if (_updateDisplayToCountReward.RewardToPlayer[0].Count == 0)
                    _updateDisplayToCountReward.RewardToPlayer.RemoveAt(0);
            }

            UIReward.gameObject.SetActive(true);
            TextCurrentReward.text = _updateDisplayToCountReward.RewardToPlayer[0][0].ToString();
            _garageController.instanseSavePlayerState.Money += _updateDisplayToCountReward.RewardToPlayer[0][0];
            

            UpdateDisplayMainMenu();
            _updateDisplayToCountReward.RewardToPlayer[0].RemoveAt(0);

            isClickPlayer = false;
        }
    }
    private void UpdateDisplayMainMenu()
    {
        var a = _garageController.instanseSavePlayerState;
        UpdateDisplay(a.ExpPlayer, a.ExpToNewLevel, a.LevelPlayer, a.Money);
    }
    private void CloseRewardPanel()
    {
        UIReward.SetActive(false);
        isClickPlayer = true;
        OpenPanelExp();
    }
}