using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableObjects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D handIcon;
    public Button btn;
    public Transform prestigeLocked, demoLocked;
    public bool notPresticLocked, notDemoLocked;

    public void Awake()
    {
        prestigeLocked = transform.Find("PrestigeLocked");
        demoLocked = transform.Find("DemoLocked");
        if (demoLocked == null) { notPresticLocked = true; }
        if (prestigeLocked == null) { notDemoLocked = true; }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(notPresticLocked == true && notDemoLocked == true)
        {
            Cursor.SetCursor(handIcon, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            if(notPresticLocked == true)
            {
                if (prestigeLocked.gameObject.activeInHierarchy == true)
                {
                    return;
                }
            }
            if(notDemoLocked == true)
            {
                if (demoLocked.gameObject.activeInHierarchy == true)
                {
                    return;
                }
            }

            Cursor.SetCursor(handIcon, Vector2.zero, CursorMode.Auto);
        }
      

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
