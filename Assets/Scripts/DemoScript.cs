using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public GameObject demoToolTipMainGame, demoTooltipPrestige;


    void Update()
    {
        if(ToolTip.isHoveringDemoLocked == true)
        {
            demoToolTipMainGame.SetActive(true);
            demoTooltipPrestige.SetActive(true);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            demoToolTipMainGame.transform.position = mousePosition;
            demoTooltipPrestige.transform.position = mousePosition;
        }
        else
        {
            demoToolTipMainGame.SetActive(false);
            demoTooltipPrestige.SetActive(false);
        }
    }
}
