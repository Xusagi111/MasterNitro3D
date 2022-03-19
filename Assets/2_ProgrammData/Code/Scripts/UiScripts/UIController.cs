using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField]GameObject rotateMenu;
    [SerializeField]GameObject finishMenu;
    [SerializeField]GameObject scrollerMenu;
    [SerializeField]GameObject deadMenu;
    [SerializeField] private GameObject PopupCompletePanel;


    private void Start()
    {
        instance = this;
        IAPurchase.PurchaseComplete.AddListener(OpenPopupPurchase);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Garage_Main_Menu");
    }    
    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenRotateMenu()
    {
        rotateMenu.SetActive(true);
    }    
    public void OpenDeadMenu()
    {
        deadMenu.SetActive(true);
    }

    public void OpenRotateScroller()
    {
        scrollerMenu.SetActive(true);
    }

    public void OpenPopupPurchase()
    {
        if (!PlayerPrefs.HasKey(StringValue.flagFirstPackBuy))
        {
            PopupCompletePanel.SetActive(true);
        }
    }

    public void DisactivPanel(GameObject gameObject)
    {
        if(gameObject == PopupCompletePanel)
            IAPurchase.PurchaseComplete.RemoveListener(OpenPopupPurchase);
        gameObject.SetActive(false);

    }
    public void FinishLevel()
    {
        finishMenu.SetActive(true);
    }
}
