using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Game_Level_1
{
    public class GameScenePanel : MonoBehaviour
    {
        [field: SerializeField] private GameObject PanelSettings { get; set; }
        [field: SerializeField] private Button ButtonOpenPanel { get; set; }
        [field: SerializeField] private Button ButtonFalsePanel { get; set; }


        private void Awake()
        {
            ButtonOpenPanel.onClick.AddListener(() => OpenPanel(true));
            ButtonFalsePanel.onClick.AddListener(() => OpenPanel(false));
        }
        private void OnDestroy()
        {
            ButtonOpenPanel.onClick.RemoveListener(() => OpenPanel(true));
            ButtonFalsePanel.onClick.RemoveListener(() => OpenPanel(false));

        }
        public void OpenPanel(bool isOpenPanel)
        {
            if (isOpenPanel)
                Time.timeScale = 0;

            else
                Time.timeScale = 1;

            PanelSettings.SetActive(isOpenPanel);
        }
        public void ResetLevel()
        {
            OpenPanel(false);
            SceneManager.LoadScene("Game");
        }
    }
}