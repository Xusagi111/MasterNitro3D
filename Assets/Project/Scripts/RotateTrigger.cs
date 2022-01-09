using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum RotateType
{
    Left, Right
}

public class RotateTrigger : MonoBehaviour
{
    public RotateType curType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.instance.OpenRotateMenu();

            PlayerMovement.instnce.type = curType;

            PlayerMovement.instnce.speed = 3f;
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement.instnce.speed = 10f;
    }
}
