using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public static PlayerMovement instnce;

    int rotating;
    bool canMoving;
    private void Start()
    {
        canMoving = false;
        rotating = 0;
        instnce = this;
    }
    void Update()
    {
        if (canMoving)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    public void RotateDirection()
    {
        if (rotating != 115)
        {
            var toAngle = Quaternion.Euler(transform.eulerAngles + Vector3.up * -0.8f);
            rotating++;
            transform.rotation = toAngle;
        }
        else
        {
            RotatorController.instance.gameObject.SetActive(false);
            rotating = 0;
        }
    }

    public void StartMovement()
    {
        canMoving = true;
    }

    public void StopMovement()
    {
        canMoving = false;
    }
}
