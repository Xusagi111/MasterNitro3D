using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckTrigger : MonoBehaviour
{
    EventManager EventManager;
    private void Start()
    {
        EventManager = GameObject.Find("UIController").gameObject.GetComponent<EventManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<RoadBlockedScript>(out RoadBlockedScript Road))
        {
            Road.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if(other.gameObject.GetComponent<MoneyGameObject>())
        {
            SetActiveMoney(other.gameObject);
        }
    }
    public void SetActiveMoney(GameObject gameObject)
    {
        gameObject.SetActive(false);
        EventManager.StateMoneyUpdateDisplayUi();
    }
}
