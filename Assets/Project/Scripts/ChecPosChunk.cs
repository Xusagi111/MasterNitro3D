using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecPosChunk : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ChunkTag")
        {
            Debug.Log("re");
            if(gameObject.GetComponent<MeshRenderer>() != false)
            {
                Debug.Log("вход " + name);
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
        Debug.Log("Вышел");
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}

//      if (other.gameObject.TryGetComponent<SceneObjectTexture>(out SceneObjectTexture sceneObjectTexture))
//{
//    Debug.Log("re");
//    if (gameObject.GetComponent<MeshRenderer>() != false)
//    {
//        Debug.Log("вход " + name);
//        gameObject.GetComponent<MeshRenderer>().enabled = false;
//        if (GetComponent<BoxCollider>() != null)
//        {
//            gameObject.GetComponent<BoxCollider>().enabled = false;
//        }
//        else
//        {
//            gameObject.GetComponent<MeshCollider>().enabled = false;

//        }
//    }
//}
