using UnityEngine.UI;
using UnityEngine;

public class RotatorController : MonoBehaviour
{
    public Slider neededSlider;
    public Slider playerSlider;

    public Image joystickHandle;

    public Color inRadiusColor;
    public Color notInRadiusColor;

    Joystick joystick;

    float neededValue = 0f;

    bool plusing;

    public static RotatorController instance;

    private void Start()
    {
        plusing = true;
        joystick = GetComponent<Joystick>();
        instance = this;
       
    }
    private void Update()
    {
        if (neededValue < 1 && plusing)
        {
            neededValue += 0.5f;// 0.003f;
        }
        else if (neededValue >= 1 && plusing)
        {
            plusing = false;
        }
        if (neededValue > -1 && !plusing)
        {
            neededValue -= 0.003f;
        }
        else if (neededValue <= -1 && !plusing)
        {
            plusing = true;
        }

        neededSlider.value = neededValue;
        playerSlider.value = joystick.Horizontal;

        if (Mathf.Abs(neededValue - joystick.Horizontal) < 0.1)
        {
            joystickHandle.color = inRadiusColor;
            PlayerMovement.instnce.RotateDirection();
        }
        else
        {
            joystickHandle.color = notInRadiusColor;
        }
    }
}
