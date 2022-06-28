using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Code.LevelToPlayer
{
    public class UpdatePlayerLevelMainMenu : MonoBehaviour
    {
        [SerializeField] private Text CurrentExpPlayer;
        //[SerializeField] private Text CurrentLevelPlayer;
        [SerializeField] private Image BarPlayerMainMenu;
        [SerializeField] private GarageController _garageController; //TODO 1: Прокинуть руками.
        private void Start()
        {
            StartCoroutine(StartReward());
        }
        IEnumerator StartReward()
        {
            yield return new WaitForSeconds(3f);
            var a = _garageController.instanseSavePlayerState;
            UpdateDisplay(a.ExpPlayer, a.ExpToNewLevel, a.LevelPlayer, a.Money);
        }
        private void UpdateDisplay(int CurrentExpLevel, int ExpToNewLevel, int CurrentLevel, int Money)
        {
            var a = ((float)CurrentExpLevel / (float)ExpToNewLevel);
            BarPlayerMainMenu.fillAmount = a;

            CurrentExpPlayer.text = CurrentExpLevel.ToString() + "/" + ExpToNewLevel;
           // CurrentLevelPlayer.text = $"LEVEL {_garageController.instanseSavePlayerState.LevelPlayer}";
        }
    }
}