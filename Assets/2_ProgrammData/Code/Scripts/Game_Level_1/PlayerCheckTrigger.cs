using UnityEngine;

public class PlayerCheckTrigger : MonoBehaviour
{
    int CountMoney = 10;
    EventManager EventManager;
    private void Start()
    {
        //EventManager = FindObjectOfType<EventManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<RoadBlockedScript>(out RoadBlockedScript Road))
        {
            Road.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.gameObject.GetComponent<MoneyGameObject>())
        {
            SetActiveMoney(other.gameObject);
        }
    }

    public void SetActiveMoney(GameObject gameObject)
    {
        gameObject.SetActive(false);
        EventMoney evt = EventManager.OptionsMenuEvent;
        evt.value = CountMoney;
        EventManagerGame.Broadcast(evt);
    }
}