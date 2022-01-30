using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoadBlockedScript : MonoBehaviour
{
    MainMenuController mainMenuController;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerCheckBlockingRoad>(out PlayerCheckBlockingRoad player))
        {
            StartCoroutine(BoxColliderOnActive());
        }
    }
    IEnumerator BoxColliderOnActive()
    {
        yield return new WaitForSeconds(5f);
        if (gameObject.GetComponent<BoxCollider>().enabled != true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(MessageActiveUI());
        }
    }
    IEnumerator MessageActiveUI()
    {
        var a = GameObject.Find("UIController");
        mainMenuController = a.GetComponent<MainMenuController>();
        mainMenuController.PanelAlertsTrafficNotSide.SetActive(true);
        yield return new WaitForSeconds(1f);
        mainMenuController.PanelAlertsTrafficNotSide.SetActive(false);
    }
}
