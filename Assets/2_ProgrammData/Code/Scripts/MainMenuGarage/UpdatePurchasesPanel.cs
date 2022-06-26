using UnityEngine;
using UnityEngine.UI;

namespace Code.MainMenuGarage
{
    public class UpdatePurchasesPanel : MonoBehaviour
    {
        [field: SerializeField] private GameObject[] MoneyPanel { get; set; }
        [field: SerializeField] private GameObject[] DiamondPanel { get; set; }
        [field: SerializeField] private Button SwitchingMoney { get; set; }
        [field: SerializeField] private Button SwitchingDiamond { get; set; }

        private void Awake()
        {
            SwitchingMoney.onClick.AddListener(() => SetActivePanel(true, false));
            SwitchingDiamond.onClick.AddListener(() => SetActivePanel(false, true));
        }
        public void StartPanel(bool isMoney)
        {
            if (isMoney)
                SetActivePanel(true, false);
            else

                SetActivePanel(false, true);
        }
        private void SetActivePanel(bool isMoneyPanel, bool isDiamondPanel)
        {
            foreach (var item in MoneyPanel)
            {
                item.SetActive(isMoneyPanel);
            }
            foreach (var item in DiamondPanel)
            {
                item.SetActive(isDiamondPanel);
            }
        }
    }
}