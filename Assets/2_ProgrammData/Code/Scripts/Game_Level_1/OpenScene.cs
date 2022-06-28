using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public void OpenGame()
    {
        Time.timeScale = 1f;
        ControllerToStateGameScene.EventGetStateToManagerMenu?.Invoke();
        StartCoroutine(StartScene());
    }
    private IEnumerator StartScene()
    {
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene("Garage_Main_Menu");
    }
}
