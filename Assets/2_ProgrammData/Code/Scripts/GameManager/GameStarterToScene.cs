using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarterToScene : MonoBehaviour
{
    private ManagerGameScene managerGameScene;
    private void Start()
    {
        managerGameScene = FindObjectOfType<ManagerGameScene>();
        managerGameScene.instansePlayerToScene();
    }
}
