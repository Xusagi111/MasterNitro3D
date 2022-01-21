using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScript1 : MonoBehaviour
{
    public static GetScript1 Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        
    }
}
