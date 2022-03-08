using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public void OpenGame()
    {
        SceneManager.LoadScene("Garage_Main_Menu");
    }
}
