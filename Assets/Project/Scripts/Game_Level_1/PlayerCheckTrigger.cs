using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckTrigger : MonoBehaviour
{
    EventManager EventManager;
    private void Start()
    {
        EventManager = FindObjectOfType<EventManager>();
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RoadBlockedScript>())
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.gameObject.GetComponent<MoneyGameObject>())
        {
            SetActiveMoney(other.gameObject);
        }
    }
    public void SetActiveMoney(GameObject gameObject)
    {
        gameObject.SetActive(false);
        
        UpdateDisplayToUi evt = Events.updateDisplayToUi;
        EventManagerGame.Broadcast(evt);

    }
}