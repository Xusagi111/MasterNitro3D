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

//private void OnTriggerEnter(Collider other)
//{
//    Debug.Log(other.tag + " тег");
//    if (other.tag == "ChunkTag")
//    {
//        Debug.Log(other.tag + " тег");
//        if (gameObject.GetComponent<MeshRenderer>() != false)
//        {
//            Debug.Log("вход " + name);
//            gameObject.GetComponent<MeshRenderer>().enabled = false;
//            if (GetComponent<BoxCollider>() != null)
//            {
//                gameObject.GetComponent<BoxCollider>().enabled = false;
//            }
//            else
//            {
//                gameObject.GetComponent<MeshCollider>().enabled = false;

//            }
//        }
//    }
//}
//private void OnTriggerExit(Collider other)
//{
//    if (other.tag == "ChunkTag")
//    {
//        Debug.Log(" Вышел" + other.tag);
//        if (gameObject.GetComponent<MeshRenderer>().enabled == false)
//        {
//            gameObject.GetComponent<MeshRenderer>().enabled = true;
//        }
//        Debug.Log("Должен появиться " + gameObject);
//    }

//}
