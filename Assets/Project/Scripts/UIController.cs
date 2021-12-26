using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField]GameObject rotateMenu;
    [SerializeField]GameObject finishMenu;
    [SerializeField]GameObject scrollerMenu;
    [SerializeField]GameObject deadMenu;

    public CinemachineBrain camera = new CinemachineBrain();


    private void Start()
    {
        instance = this;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Garage");
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

    public void FinishLevel()
    {
        finishMenu.SetActive(true);
    }
}
