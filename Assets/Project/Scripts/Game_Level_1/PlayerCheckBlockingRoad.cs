using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckBlockingRoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<RoadBlockedScript>(out RoadBlockedScript Road))
        {
            Road.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
