using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecPosChunk : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Chunk>(out Chunk chunk))
        {
            if (gameObject.GetComponent<MeshRenderer>() != false)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                if(GetComponent<BoxCollider>() != null)
                {
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                else
                {
                    gameObject.GetComponent<MeshCollider>().enabled = false;
                }
            } 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Chunk>(out Chunk chunk))
        {
            if (gameObject.GetComponent<MeshRenderer>().enabled == false)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
            
    }
   
}