using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerScene : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] GameObject[] ArrayGameObj;

    private void Awake()
    {
        var CreationPlayer  = Instantiate(ArrayGameObj[0]);
        player = CreationPlayer.gameObject;
    }
}
