using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InitializationCamera : MonoBehaviour
{
    private void Start()
    {
        var PlayerTransform = FindObjectOfType<CarController>().gameObject.transform; 
        var a = GetComponent<CinemachineVirtualCamera>();
        a.Follow = PlayerTransform;
        a.LookAt = PlayerTransform;
    }
}
