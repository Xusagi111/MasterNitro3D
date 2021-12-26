using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptShec : MonoBehaviour
{
    
    void Start()
    {

    }

    private void OnCollisionEntry(Collision collision) {
        Debug.Log("ChunkEntry");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("ChunkStay");
    }
    private void OnCollisionExity(Collision collision)
    {
        
            Debug.Log("ChunkExity");
    }
}
