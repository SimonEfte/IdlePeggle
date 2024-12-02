using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup pitsTextsCanvasGroup;
    public float fadeDuration;
    public GameObject goldenPegsUpgradeBar, bucketUpgradeBar;

    public bool isHoveringUpgradeInfo;
    public TextMeshProUGUI ballInfoText;
    public GameObject upgradeInfoTooltip;
    public RectTransform upgradeInfoToolTipSize;

    public static bool isHoveringDemoLocked;

    public GameObject levelSelectFrame;

    public GameObject loc;
    public LocalizationStrings locScript;

    public TextMeshProUGUI levelNameText, levelBoardCountText, levelPegsCountText, levelBucketsText;

    public void Awake()
    {
        loc = GameObject.Find("LocStringsScript");
        locScript = loc.GetComponent<LocalizationStrings>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(MobileScript.isMobile == true) { return; }

        #region Level select
        if (gameObject.tag == "LevelSelect")
        {
            if(gameObject.name == "Level1Frame")
            {
                levelSelectFrame.transform.localPosition = new Vector2(-512, 346);
                levelNameText.text = LocalizationStrings.level1NameString;
                locScript.LevelStats(Prestige.level1Boards, Prestige.level1MinPegs, Prestige.level1MaxPegs);
                levelBucketsText.text = LocalizationStrings.bucket1MidString;
            }
            if (gameObject.name == "Level2Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(-250, 346);
                levelNameText.text = LocalizationStrings.level2NameString;
                locScript.LevelStats(Prestige.level2Boards, Prestige.level2MinPegs, Prestige.level2MaxPegs);
                levelBucketsText.text = LocalizationStrings.bucket1MidString;
            }
            if (gameObject.name == "Level3Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(0, 346);
                levelNameText.text = LocalizationStrings.level3NameString;
                locScript.LevelStats(Prestige.level3Boards, Prestige.level3MinPegs, Prestige.level3MaxPegs);
                levelBucketsText.text = LocalizationStrings.bucketsLevel3;
            }
            if (gameObject.name == "Level4Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(261, 346);
                levelNameText.text = LocalizationStrings.level4NameString;
                locScript.LevelStats(Prestige.level3Boards, Prestige.level4MinPegs, Prestige.level4MaxPegs);
                levelBucketsText.text = LocalizationStrings.bucketsLevel4;
            }
            if (gameObject.name == "Level5Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(495, 346);
                levelNameText.text = LocalizationStrings.level5NameString;
                locScript.LevelStats(Prestige.level5Boards, Prestige.level5MinPegs, Prestige.level5MaxPegs);
                levelBucketsText.text = LocalizationStrings.bucketsLevel5;
            }
            if (gameObject.name == "Level6Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(-495, 186);
                levelNameText.text = LocalizationStrings.level6NameString;
                locScript.LevelStats(Prestige.level6Boards, Prestige.level6MinPegs, Prestige.level6MaxPegs);
                levelBucketsText.text = "<size=15.8>" + LocalizationStrings.bucketsLevel6;
            }
            if (gameObject.name == "Level7Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(-260, 186);
                levelNameText.text = LocalizationStrings.level7NameString;
                locScript.LevelStats(Prestige.level7Boards, Prestige.level7MinPegs, Prestige.level7MaxPegs);
                levelBucketsText.text = LocalizationStrings.bucketsLevel7;
            }
            if (gameObject.name == "Level8Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(0, 186);
                levelNameText.text = LocalizationStrings.level8NameString;
                locScript.LevelStats(Prestige.level8Boards, Prestige.level8MinPegs, Prestige.level8MaxPegs);
                levelBucketsText.text = LocalizationStrings.bucketsLevel8;
            }
            if (gameObject.name == "Level9Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(250, 186);
                levelNameText.text = LocalizationStrings.level9NameString;
                locScript.LevelStats(Prestige.level9Boards, Prestige.level9MinPegs, Prestige.level9MaxPegs);
                levelBucketsText.text = LocalizationStrings.bucketsLevel9;
            }
            if (gameObject.name == "Level10Unlcoked")
            {
                levelSelectFrame.transform.localPosition = new Vector2(500, 186);
                levelNameText.text = LocalizationStrings.level10NameString;
                locScript.LevelStats(Prestige.level10Boards, Prestige.level10MinPegs, Prestige.level10MaxPegs);
                levelBucketsText.text = "<size=15.8>" + LocalizationStrings.bucketsLevel10;
            }

            levelBoardCountText.text = LocalizationStrings.levelBoardCountString;
            levelPegsCountText.text = LocalizationStrings.levelPegsCountString;

            levelSelectFrame.SetActive(true);
        }
        #endregion

        #region Demo Tooltips
        if(GameData.isDemo == true)
        {
            if (gameObject.tag == "DemoLocked")
            {
                if(MobileScript.isMobile == false) { isHoveringDemoLocked = true; }
                return;
            }
        }
        #endregion

        #region Upgrade Pegs
        if (gameObject.name == "UpgradePegs")
        {
            goldenPegsUpgradeBar.SetActive(true);

            return;
        }
        #endregion

        #region Upgrade Bucket
        if (gameObject.name == "UpgradeBucket")
        {
            bucketUpgradeBar.SetActive(true);
        }
        #endregion

        #region Ball Info Hover
        if (gameObject.name == "InfoIcon")
        {
            SetInfoTexts();
        }
        #endregion
    }

    #region info texts
    public void SetInfoTexts()
    {
        upgradeInfoTooltip.SetActive(true);
        isHoveringUpgradeInfo = true;
        if (BallUpgrades.currentBallFrame == 1)
        {
            ballInfoText.text = LocalizationStrings.regularBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 45);
        }
        else if (BallUpgrades.currentBallFrame == 2)
        {
            ballInfoText.text = LocalizationStrings.bouncyBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 45);
        }
        else if (BallUpgrades.currentBallFrame == 3)
        {
            ballInfoText.text = LocalizationStrings.rockBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 45);
        }
        else if (BallUpgrades.currentBallFrame == 4)
        {
            ballInfoText.text = LocalizationStrings.bombBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 100);
        }
        else if (BallUpgrades.currentBallFrame == 5)
        {
            ballInfoText.text = LocalizationStrings.aquaBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 38);
        }
        else if (BallUpgrades.currentBallFrame == 6)
        {
            ballInfoText.text = LocalizationStrings.mudBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 38);
        }
        else if (BallUpgrades.currentBallFrame == 7)
        {
            ballInfoText.text = LocalizationStrings.basketBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 70);
        }
        else if (BallUpgrades.currentBallFrame == 8)
        {
            ballInfoText.text = LocalizationStrings.plumBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 38);
        }
        else if (BallUpgrades.currentBallFrame == 9)
        {
            ballInfoText.text = LocalizationStrings.stickyBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 38);
        }
        else if (BallUpgrades.currentBallFrame == 10)
        {
            ballInfoText.text = LocalizationStrings.candyBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 38);
        }
        else if (BallUpgrades.currentBallFrame == 11)
        {
            ballInfoText.text = LocalizationStrings.cookieBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 48);
        }
        else if (BallUpgrades.currentBallFrame == 12)
        {
            ballInfoText.text = LocalizationStrings.limeBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 38);
        }
        else if (BallUpgrades.currentBallFrame == 13)
        {
            ballInfoText.text = LocalizationStrings.goldBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 100);
        }
        else if (BallUpgrades.currentBallFrame == 14)
        {
            ballInfoText.text = LocalizationStrings.footBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 38);
        }
        else if (BallUpgrades.currentBallFrame == 15)
        {
            ballInfoText.text = LocalizationStrings.sharpnelBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 85);
        }
        else if (BallUpgrades.currentBallFrame == 16)
        {
            ballInfoText.text = LocalizationStrings.ringBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 71);
        }
        else if (BallUpgrades.currentBallFrame == 17)
        {
            ballInfoText.text = LocalizationStrings.apricotBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 38);
        }
        else if (BallUpgrades.currentBallFrame == 18)
        {
            ballInfoText.text = LocalizationStrings.peggoBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 60);
        }
        else if (BallUpgrades.currentBallFrame == 19)
        {
            ballInfoText.text = LocalizationStrings.ghostBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 86);
        }
        else if (BallUpgrades.currentBallFrame == 20)
        {
            ballInfoText.text = LocalizationStrings.starBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 61);
        }
        else if (BallUpgrades.currentBallFrame == 21)
        {
            ballInfoText.text = LocalizationStrings.rainbowBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 103);
        }
        else if (BallUpgrades.currentBallFrame == 22)
        {
            ballInfoText.text = LocalizationStrings.glitchyBallDesString;
            upgradeInfoToolTipSize.sizeDelta = new Vector2(166, 37);
        }
    }
    #endregion


    public void OpenInfoMOBILE()
    {
        if(MobileScript.isMobile == false) { return; }
        SetInfoTexts();
        upgradeInfoTooltip.transform.localScale = new Vector2(0.4f, 0.4f);
        upgradeInfoTooltip.transform.localPosition = new Vector2(32, 0);
    }

    public void CloseInfoMOBILE()
    {
        upgradeInfoTooltip.SetActive(false);
        isHoveringUpgradeInfo = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(MobileScript.isMobile == true) { return; }

        #region Level select
        if (gameObject.tag == "LevelSelect")
        {
            levelSelectFrame.SetActive(false);
        }
        #endregion

        if (gameObject.name == "UpgradeBucket")
        {
            bucketUpgradeBar.SetActive(false);
        }
        if (gameObject.name == "UpgradePegs")
        {
            goldenPegsUpgradeBar.SetActive(false);
        }

        if(isHoveringUpgradeInfo == true)
        {
            isHoveringUpgradeInfo = false;
            upgradeInfoTooltip.SetActive(false);
        }

        if(isHoveringDemoLocked == true)
        {
            if (MobileScript.isMobile == false) { isHoveringDemoLocked = false; }
        }
    }
  
}
