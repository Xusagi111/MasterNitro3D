using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkidСontrollerScene : MonoBehaviour
{
    [SerializeField] Text ConclusionUi;
    [SerializeField] Transform View;
    int count;
    private void FixedUpdate()
    {
        if(View.rotation.eulerAngles.z > 3f  && View.rotation.eulerAngles.z < 357f)
        {
            count += 10;
            ConclusionUi.text = count.ToString();

        }
    }
}
