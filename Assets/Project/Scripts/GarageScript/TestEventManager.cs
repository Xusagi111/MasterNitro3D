using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventManager : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Unity.AddListener(ConclusionConsole);
    }

    private void ConclusionConsole(int a)
    {
         Debug.Log("Вызван ивент" + a);
    }
}
