using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject BurgerMenu;
    [SerializeField] private GameObject StrelockaObj;
    [SerializeField] private CanvasGroup BlackScreen;
    [SerializeField] private GameObject trans;

    private float originPosBMenu;
    // Start is called before the first frame update
    void Start()
    {
        originPosBMenu = BurgerMenu.transform.position.x;
    }


    public void BurgerNenuActivate()
    {

        BlackScreen.GetComponent<Image>().raycastTarget = true;
        BlackScreenAnim(BlackScreen, 0.5f);
        SwapAnim(trans.transform.position.x);
        RotateAnim(0f);
    }

    public void BurgerMenuDisactiv()
    {
        BlackScreen.GetComponent<Image>().raycastTarget = false;
        BlackScreenAnim(BlackScreen, 0f);
        SwapAnim(originPosBMenu);
        RotateAnim(180f);
    }

    private void SwapAnim(float pos)
    {
        iTween.MoveTo(BurgerMenu, iTween.Hash(
            "x", pos,
            "time", 1f, "easytype", iTween.EaseType.easeInBack));
    }
    private void RotateAnim(float rotate)
    {
        iTween.RotateTo(StrelockaObj, iTween.Hash(
            "z", rotate,
            "time", 1f, "easytype", iTween.EaseType.easeInBack));
    }
    private void BlackScreenAnim(CanvasGroup canvasGroupBS, float aValue)
    {
        StartCoroutine(AlphaChanger.FadeTo(canvasGroupBS, aValue, 1f));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
