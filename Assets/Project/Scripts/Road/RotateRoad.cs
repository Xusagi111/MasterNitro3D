using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateRoad : MonoBehaviour
{
    public int Count;
    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * Count, Color.yellow);
        if (Physics.Raycast(ray, out hit, 100))
        {
            
            Debug.DrawRay(transform.position, transform.forward * Count, Color.yellow);
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.Log(hit.collider.name);
            Debug.DrawRay(transform.position, transform.forward * Count, Color.yellow);
        }
    }

}
