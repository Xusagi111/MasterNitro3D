using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptShec : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "ChunkTag")
        {
            if(GetComponent<MeshRenderer>() != false)
            {
                Debug.Log("вход " + name);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                if(GetComponent<BoxCollider>() != null)
                gameObject.GetComponent<BoxCollider>().enabled = false;
                else
                {
                    gameObject.GetComponent<MeshCollider>().enabled = false;
                    Debug.Log("0");
                }
            }

        }
        Debug.Log("НЕ смог войти " + name);
    }

    //public void OnTriggerExit(Collider other)
    //{
       
    //        Debug.Log("вход " + name);
    //        gameObject.GetComponent<MeshRenderer>().enabled = true;
    //        if (GetComponent<BoxCollider>() != null)
    //        gameObject.GetComponent<BoxCollider>().enabled = true;
        
    //    Debug.Log("НЕ смог выйти " + name);
    //}
}

