using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosChunk : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Chunk>()) 
        {
            if (gameObject.GetComponent<MeshRenderer>() != false)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Chunk>())
        {
            if (gameObject.GetComponent<MeshRenderer>().enabled == false)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;  
            }
        }
    }
}
