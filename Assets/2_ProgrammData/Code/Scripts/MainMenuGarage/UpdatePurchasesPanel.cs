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
        [field: SerializeField] private GameObject CurentPanelOffers { get; set; }
        
        private void Awake()
        {
            SwitchingMoney.onClick.AddListener(() => StartPanel(true));
            SwitchingDiamond.onClick.AddListener(() => StartPanel(false));
        }
        private void OnDestroy()
        {
            SwitchingMoney.onClick.RemoveListener(() => StartPanel(true));
            SwitchingDiamond.onClick.RemoveListener(() => StartPanel(false));
        }
        public void StartPanel(bool isMoney)
        {
            if (isMoney)
                SetActivePanel(true, false);
            else

                SetActivePanel(false, true);

            CurentPanelOffers.SetActive(true);
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