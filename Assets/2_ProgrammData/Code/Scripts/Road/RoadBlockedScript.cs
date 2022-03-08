using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoadBlockedScript : MonoBehaviour
{
    MainMenuController mainMenuController;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerCheckTrigger>(out PlayerCheckTrigger player))
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
}
