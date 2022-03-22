using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ResumeObj;
    private GameObject PlayerLink;
    [SerializeField] private DriftCount—ontrollerScene _DriftCount—ontrollerScene;

    private void Start()
    {
        
    }
    public void StopGame()
    {
        PlayerLink = GameObject.Find("Player");
        ResumeObj.SetActive(true);
        _DriftCount—ontrollerScene.enabled = false;
        PlayerLink.GetComponent<Rigidbody>().isKinematic = true;
        PlayerLink.GetComponent<CarController>().enabled = false;
    }

    public void ResumeGame()
    {
        ResumeObj.SetActive(false);
        _DriftCount—ontrollerScene.enabled = true;
        PlayerLink.GetComponent<Rigidbody>().isKinematic = false;
        PlayerLink.GetComponent<CarController>().enabled = true;
    }

    public void QuitGame() => Application.Quit();

    public void ReloadActivScene()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        
        
}
