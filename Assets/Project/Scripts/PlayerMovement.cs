using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public static PlayerMovement instnce;

    [HideInInspector] public RotateType type;

    int rotating;
    bool canMoving;
    private void Start()
    {
        canMoving = false;
        rotating = 0;
        instnce = this;
    }
    void FixedUpdate() //test управление
    {
        float moveSide = Input.GetAxis("Horizontal");
        if (canMoving)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            if (moveSide > 0)
            {
                transform.position += (new Vector3(1, 0, 0) * Time.deltaTime  *2); 
                transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed * 2 );
            }
            if (moveSide < 0)
            {
                transform.position += (new Vector3(-1, 0, 0) * Time.deltaTime * 2); 
                transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed *2);
            }
        }
    }

    public void RotateDirection()
    {
        if (type == RotateType.Left)
        {
            if (rotating != 90)
            {
                var toAngle = Quaternion.Euler(transform.eulerAngles + Vector3.up * -1f);
                rotating++;
                transform.rotation = toAngle;
            }
            else
            {
                RotatorController.instance.gameObject.SetActive(false);
                rotating = 0;
            }
        }
        if (type == RotateType.Right)
        {
            if (rotating != 90)
            {
                var toAngle = Quaternion.Euler(transform.eulerAngles + Vector3.up * 1f);
                rotating++;
                transform.rotation = toAngle;
            }
            else
            {
                RotatorController.instance.gameObject.SetActive(false);
                rotating = 0;
            }
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
