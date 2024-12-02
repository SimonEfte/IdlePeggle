using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiddleShooterToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject fullyChagredToolTip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(MobileScript.isMobile == true) { return; }
        OpenFrame();
    }
    public AudioManager audioManager;

    public GameObject closeBtn, dark;
    public void OpenFrame()
    {
        if (MobileScript.isMobile == false) { return; }

        int random = Random.Range(1, 3);
        if (random == 1) { audioManager.Play("UIClick1"); }
        if (random == 2) { audioManager.Play("UIClick2"); }

        dark.SetActive(true);
        closeBtn.SetActive(true);
        fullyChagredToolTip.SetActive(true);
        fullyChagredToolTip.transform.localPosition = new Vector2(0,72);
        fullyChagredToolTip.transform.localScale = new Vector2(1.95f, 1.95f);
    }

    public void CloseFrame()
    {
        int random = Random.Range(1, 3);
        if (random == 1) { audioManager.Play("UIClick1"); }
        if (random == 2) { audioManager.Play("UIClick2"); }

        dark.SetActive(false);
        closeBtn.SetActive(false);
        fullyChagredToolTip.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MobileScript.isMobile == true) { return; }
        fullyChagredToolTip.SetActive(false);
    }
}
