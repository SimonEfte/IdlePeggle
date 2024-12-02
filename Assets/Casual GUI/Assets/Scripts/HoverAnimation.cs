using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Increase Scale")]
    public float maxScale = 1.2f;

    [Header("Initial  Scale")]
    public float defaultScale = 1f;
    [Header("Animation speed")]
    public float animationSpeed = 2;

    [Header("Enable clickAnimation")]
    public bool animateOnClick = false;

    [Header("Enable Hover Animation")]
    public bool animateOnHover = true;

    // used for click effect
    bool isRunningI = false;
    bool isRunningD = false;

    private void Awake()
    {
        defaultScale = transform.localScale.x; 
        if(gameObject.tag == "Flagh") { maxScale = 0.15f; }
        else { maxScale = defaultScale + 0.15f; }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(maxScale, maxScale, maxScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (SettingsOptions.flagSelected == false)
        {
            transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);
        }

        if (SettingsOptions.flagSelected == true)
        {
            SettingsOptions.flagSelected = false;
        }
    }
  

}
