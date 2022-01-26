using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public GameObject tieTo;

    void Update()
    {
        transform.position = new Vector3(tieTo.transform.position.x + 2, tieTo.transform.position.y + 2, tieTo.transform.position.z + 2);
    }

    
}
