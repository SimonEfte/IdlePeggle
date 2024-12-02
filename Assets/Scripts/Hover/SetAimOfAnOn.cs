using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetAimOfAnOn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool isHoveringBoard;
    public GameObject aimObject;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHoveringBoard = true;
        aimObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHoveringBoard = false;
        aimObject.SetActive(false);
    }
}
