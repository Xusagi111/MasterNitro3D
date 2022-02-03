using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChecLevelBlock : MonoBehaviour
{
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            hit.collider.gameObject.GetComponent<SceneObjectTexture>().SetActive(false);
            Debug.Log("");
        }
    }
}
