using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptShec : MonoBehaviour
{
    
    void Start()
    {
       
    }


    private void OnCollisionStay(Collision collision)
    {
        var a = GetComponent<House>();
        if (a != null)
        {
            gameObject.SetActive(false);
            Debug.Log(collision.gameObject.name);
        }
    }
}
