using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecPosChunk : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "ChunkTag")
        {
            if(GetComponent<MeshRenderer>() != false)
            {
                //Debug.Log("вход " + name);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                if(GetComponent<BoxCollider>() != null)
                gameObject.GetComponent<BoxCollider>().enabled = false;

                else
                {
                    gameObject.GetComponent<MeshCollider>().enabled = false;
                 
                }
            }
        }
    }
}

