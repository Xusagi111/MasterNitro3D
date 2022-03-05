using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum RotateType
{
    Left, Right, ForwardType
}
public class Chunk : MonoBehaviour
{
    public Transform End;
    public Transform Start;
    public Transform ChecBlockLevel;
    public RotateType rotateType;
}
