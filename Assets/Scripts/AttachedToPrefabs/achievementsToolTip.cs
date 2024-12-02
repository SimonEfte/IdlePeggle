using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class achievementsToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int achNumber, achRQ;
    public double gold;
    public static bool isHoveringACH;
    public LocalizationStrings locScript;
    public TextMeshProUGUI text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(MobileScript.isMobile == true) { return; }

        isHoveringACH = true;

        SetAch();
    }

    public void SetAch()
    {
        if (achNumber == 0) { text.text = LocalizationStrings.chall1String; }
        else if (achNumber == 26) { text.text = LocalizationStrings.purchase1Ballstring; }
        else if (achNumber == 68) { text.text = LocalizationStrings.clearBoardString; }
        else if (achNumber == 71) { text.text = LocalizationStrings.fullyChargeACHstring; }
        else if (achNumber == 74) { text.text = LocalizationStrings.goldRushACH; }
        else if (achNumber == 75) { text.text = LocalizationStrings.goldRushACH2; }
        else if (achNumber == 76) { text.text = LocalizationStrings.prestigeRushACH; }
        else if (achNumber == 77) { text.text = LocalizationStrings.prestigeRushACH2; }
        else if (achNumber == 78) { text.text = LocalizationStrings.allBufsString; }
        else
        {
            locScript.ChangeACHText(achNumber, achRQ, gold);
            text.text = LocalizationStrings.achString;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHoveringACH = false;
    }

}
