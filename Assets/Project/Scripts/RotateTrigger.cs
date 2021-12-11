using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        UIController.instance.OpenRotateMenu();

        PlayerMovement.instnce.speed = 3f;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement.instnce.speed = 10f;
    }
}
