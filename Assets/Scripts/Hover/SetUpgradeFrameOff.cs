using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetUpgradeFrameOff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool isHovering;

    public bool isMaxFrame;
    public Animation anim;
    public static bool clickedAnim;
    public GameObject arrow;

    private void Awake()
    {
        if(gameObject.name == "maxFrame")
        {
            isMaxFrame = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    private void Update()
    {
        if(isMaxFrame == true && clickedAnim == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && isHovering == false)
            {
                clickedAnim = false;
                BallUpgrades.isIn = false;
                anim.Play("maxTabOut");
                arrow.transform.localScale = new Vector3(-0.3717124f, 0.3717124f, 0.3717124f);
            }
        }
    }

}
