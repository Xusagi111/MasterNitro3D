using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ResumeObj;
    private IEnumerator StopGameCor()
    {
        yield return new WaitForSeconds(1f);
        ResumeObj.SetActive(true);
        Time.timeScale = 0;
    }

    public void StopGame() => StartCoroutine(StopGameCor());

    public void ResumeGame()
    {
        Time.timeScale = 1;
        ResumeObj.SetActive(false);
    }

    public void QuitGame() => Application.Quit();

    public void ReloadActivScene()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        
        
}
