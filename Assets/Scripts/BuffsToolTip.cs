using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BuffsToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buff;
    public GameObject frame;
    public TextMeshProUGUI timerText, buffText;
    public static int buffCurrentlyHovering;
    public Transform pos;
    public LocalizationStrings locScript;
    public AudioManager audioManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MobileScript.isMobile == true) { return; }
        SetBuffTooltip();
    }

    public void SetBuffTooltip()
    {
        if (buff == 1)
        {
            locScript.ChangeBuffHover(Prestige.rainbowPegIncrease, 1);
            buffText.text = LocalizationStrings.goldFromPegsBUFF; timerText.text = Levels.rainbowTimer1.ToString("F0");
        }
        if (buff == 2)
        {
            locScript.ChangeBuffHover(Prestige.rainbowPegIncrease, 2);
            buffText.text = LocalizationStrings.goldFromBucketsBUFF; timerText.text = Levels.rainbowTimer2.ToString("F0");
        }
        if (buff == 3)
        {
            locScript.ChangeBuffHover(Prestige.rainbowPegIncrease, 3);
            buffText.text = LocalizationStrings.prestigePointsBUFF; timerText.text = Levels.rainbowTimer3.ToString("F0");
        }
        if (buff == 4) { buffText.text = LocalizationStrings.chancePrestigePointBucketBUFF; timerText.text = Levels.rainbowTimer4.ToString("F0"); }
        if (buff == 5) { buffText.text = LocalizationStrings.goldFromAllSourcesBUFF; timerText.text = Levels.goldTimer.ToString("F0"); }
        if (buff == 6) { buffText.text = LocalizationStrings.prestigePointAllSourcesBuff; timerText.text = Levels.prestigeTimer.ToString("F0"); }

        buffCurrentlyHovering = buff;

        if(MobileScript.isMobile == false) { frame.transform.position = pos.transform.position; }
        else
        {
            int random = Random.Range(1, 3);
            if (random == 1) { audioManager.Play("UIClick1"); }
            if (random == 2) { audioManager.Play("UIClick2"); }

            frame.transform.localPosition = new Vector2(0,106);
            frame.transform.localScale = new Vector2(4.75f, 4.75f);
            dark.SetActive(true);
            close.SetActive(true);
        }
       
        frame.SetActive(true);
    }

    public GameObject dark, close;

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MobileScript.isMobile == true) { return; }
        buffCurrentlyHovering = 0;
        frame.SetActive(false);
    }
}
