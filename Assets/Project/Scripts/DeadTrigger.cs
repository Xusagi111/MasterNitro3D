using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        UIController.instance.OpenDeadMenu();
        UIController.instance.camera.enabled = false;
    }
}
