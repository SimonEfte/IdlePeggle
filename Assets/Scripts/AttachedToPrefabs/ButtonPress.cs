using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed;
    public float originalScale;
    public float scaleDownFactor;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
        scaleDownFactor = gameObject.transform.localScale.x;

        if (gameObject.name == "UpgradeBucket" || gameObject.name == "UpgradePegs")
        {
            scaleDownFactor -= 0.04f;
        }
        else
        {
            scaleDownFactor -= 0.01f;
        }

        if(gameObject.name == "SaveGame")
        {
            if(MobileScript.isMobile == true)
            {
                originalScale = 0.26f;
                scaleDownFactor = 0.235f;
            }
        }
        else if (gameObject.name == "ResetGame")
        {
            if (MobileScript.isMobile == true)
            {
                originalScale = 0.2f;
                scaleDownFactor = 0.18f;
            }
        }
      
    }

    void Update()
    {
        if (isPressed == true)
        {
            // Scale down the button
            gameObject.transform.localScale = new Vector3(scaleDownFactor, scaleDownFactor, 1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(originalScale, originalScale, 1f);
        }
    }
}
