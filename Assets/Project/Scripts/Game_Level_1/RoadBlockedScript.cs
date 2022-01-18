using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockedScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
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
}
