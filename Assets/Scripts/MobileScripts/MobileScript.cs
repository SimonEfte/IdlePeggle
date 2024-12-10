using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MobileScript : MonoBehaviour
{
    public static bool isMobile;
    public GameObject getItOnGooglePlay, settingsExclIcon;

    public void Awake()
    {
        isMobile = false;
        if(isMobile == true)
        {
            Application.targetFrameRate = 60;

            settingsExclIcon.transform.localPosition = new Vector2(53.5f, -5.7f);
            getItOnGooglePlay.SetActive(false);

            SetGameobjectsOff();
            SetSettings();

            if (GameData.isDemo == false) 
            {
                fullGameBtn.SetActive(false);
                settingsBtn.transform.localScale = new Vector2(1.03f, 1.03f);
                settingsBtn.transform.localPosition = new Vector2(-860, 470);
            }
            else
            {
                fullGameBtn.SetActive(true);
            
            }
        }
        else
        {
          
        
        }
    }

    private void Update()
    {
        if(PrestigeToolTip.openPrestigeTooltip == true) 
        {
            blackPrestigeBlock.SetActive(true);

            PrestigeToolTip.openPrestigeTooltip = false;
        }
    }

    public GameObject lockButton, exitBallUpgradeTopRight;
    public GameObject blackPrestigeBlock;
   
    public void SetGameobjectsOff()
    {
        lockButton.SetActive(false);
        exitBallUpgradeTopRight.SetActive(false);
    }

    #region Ball upgrade info
    public GameObject closeInfoBtn, infoBlack;
    public void ClickBallInfo()
    {
        if(isMobile == false) { return; }
        ClickSound();
        closeInfoBtn.SetActive(true);
        infoBlack.SetActive(true);

        float xpos = 13.9f;

        if(BallUpgrades.currentBallFrame == 1) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -14f);  }
        else if (BallUpgrades.currentBallFrame == 2) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -14f); }
        else if (BallUpgrades.currentBallFrame == 3) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -14f); }
        else if (BallUpgrades.currentBallFrame == 4) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -44f); }
        else if (BallUpgrades.currentBallFrame == 5) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9.6f); }
        else if (BallUpgrades.currentBallFrame == 6) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9.6f); }
        else if (BallUpgrades.currentBallFrame == 7) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -29f); }
        else if (BallUpgrades.currentBallFrame == 8) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9.6f); }
        else if (BallUpgrades.currentBallFrame == 9) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9.6f); }
        else if (BallUpgrades.currentBallFrame == 10) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9.6f); }
        else if (BallUpgrades.currentBallFrame == 11) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -15); }
        else if (BallUpgrades.currentBallFrame == 12) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9.6f); }
        else if (BallUpgrades.currentBallFrame == 13) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -46f); }
        else if (BallUpgrades.currentBallFrame == 14) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9.6f); }
        else if (BallUpgrades.currentBallFrame == 15) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -35f); }
        else if (BallUpgrades.currentBallFrame == 16) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -28); }
        else if (BallUpgrades.currentBallFrame == 17) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9.6f); }
        else if (BallUpgrades.currentBallFrame == 18) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -22f); }
        else if (BallUpgrades.currentBallFrame == 19) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -36f); }
        else if (BallUpgrades.currentBallFrame == 20) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -22.5f); }
        else if (BallUpgrades.currentBallFrame == 21) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -47f); }
        else if (BallUpgrades.currentBallFrame == 22) { closeInfoBtn.transform.localPosition = new Vector2(xpos, -9f); }
    }

    public void CloseBallInfo()
    {
        ClickSound();
        closeInfoBtn.SetActive(false);
        infoBlack.SetActive(false);
    }
    #endregion

    #region Prestige
    public GameObject prestigeUpgradeTooltip, closePrestigeTooltip, upgradePrestigetooltip, prestigeDark;

    public void ClosePrestigeUpgrade()
    {
        ClickSound();
        PrestigeToolTip.isHoveringPrestigeUpgrade = false;
        prestigeDark.SetActive(false);
        prestigeUpgradeTooltip.SetActive(false);
        closePrestigeTooltip.SetActive(false);
        upgradePrestigetooltip.SetActive(false);
        PrestigeToolTip.isMobilePrestigeOpen = false;
    }
    #endregion

    #region Ach
    public GameObject achTooltip, achBlack, achClose;

    public void OpenAch(bool close)
    {
        if(isMobile == false) { return; }
        ClickSound();
        if (close == false)
        {
            achTooltip.SetActive(true);
            achTooltip.transform.localScale = new Vector2(1.28f, 1.28f);
            achTooltip.transform.localPosition = new Vector2(38f, -144);
            achBlack.SetActive(true);
            achClose.SetActive(true);
        }
        if (close == true)
        {
            achTooltip.SetActive(false);
            achBlack.SetActive(false);
            achClose.SetActive(false);
        }
    }
    #endregion

    #region Set settings
    public GameObject flags, resolutionDropdown, fillscreenText, fullScreenToggle;
    public GameObject musicIcon, soundIcon, musicSlider, audioSlider, bucketSlider, pegsSlider, bottomLine, goldTextSlider, exitButton, saveButton, resetButton, youtubeBtn, discordBtn, twitterBtn, autoDrop, line;

    public GameObject x1Button, maxButton, hoverMaxFrame, settingsBtn;
    public Transform x1andMaxPArent;
    public GameObject fullGameBtn;

    public GameObject settingsFrame, generalTab, statsTab, achTab, challengesTab;

    public void SetSettings()
    {
        settingsFrame.transform.localScale = new Vector2(1.088f, 1.088f);
        settingsFrame.transform.localPosition = new Vector2(0f, -48f);

        generalTab.transform.localScale = new Vector2(1.34f, 1.34f);
        generalTab.transform.localPosition = new Vector2(-296f, 423f);

        statsTab.transform.localScale = new Vector2(1.34f, 1.34f);
        statsTab.transform.localPosition = new Vector2(-97, 423f);

        challengesTab.transform.localScale = new Vector2(1.34f, 1.34f);
        challengesTab.transform.localPosition = new Vector2(101f, 423f);

        achTab.transform.localScale = new Vector2(1.34f, 1.34f);
        achTab.transform.localPosition = new Vector2(300f, 423f);

        x1Button.transform.SetParent(x1andMaxPArent);
        x1Button.transform.localPosition = new Vector2(66.7f, 38.118f);
        x1Button.transform.localScale = new Vector2(1.59f, 1.59f);
        maxButton.transform.SetParent(x1andMaxPArent);
        maxButton.transform.localPosition = new Vector2(66.69f, -38f);
        maxButton.transform.localScale = new Vector2(1.59f, 1.59f);
        hoverMaxFrame.SetActive(false);

        line.SetActive(false);
        exitButton.SetActive(false);
        flags.SetActive(true);
        resolutionDropdown.SetActive(false);
        fillscreenText.SetActive(false);
        fullScreenToggle.SetActive(false);

        if (GameData.isDemo == false)
        {
            musicIcon.transform.localPosition = new Vector2(-64f, 20f);
            musicIcon.transform.localScale = new Vector2(0.06f, 0.06f);
            soundIcon.transform.localPosition = new Vector2(5f, 20f);
            soundIcon.transform.localScale = new Vector2(0.06f, 0.06f);

            audioSlider.transform.localPosition = new Vector2(40f, 20f);
            audioSlider.transform.localScale = new Vector2(0.157f, 0.157f);
            musicSlider.transform.localPosition = new Vector2(-30f, 20f);
            musicSlider.transform.localScale = new Vector2(0.157f, 0.157f);
        }
        else
        {
            musicIcon.transform.localPosition = new Vector2(-56f, 40f);
            musicIcon.transform.localScale = new Vector2(0.07f, 0.07f);
            soundIcon.transform.localPosition = new Vector2(-57f, 24f);
            soundIcon.transform.localScale = new Vector2(0.07f, 0.07f);

            audioSlider.transform.localPosition = new Vector2(-18f, 24f);
            audioSlider.transform.localScale = new Vector2(0.18f, 0.18f);
            musicSlider.transform.localPosition = new Vector2(-18f, 40f);
            musicSlider.transform.localScale = new Vector2(0.18f, 0.18f);
        }

        bucketSlider.transform.localPosition = new Vector2(-31f, 4.4f);
        bucketSlider.transform.localScale = new Vector2(0.14f, 0.14f);
        pegsSlider.transform.localPosition = new Vector2(25.3f, 4.4f);
        pegsSlider.transform.localScale = new Vector2(0.14f, 0.14f);

        bottomLine.transform.localPosition = new Vector2(0f, -1.5f);

        goldTextSlider.transform.localPosition = new Vector2(0f, -16f);

        saveButton.transform.localPosition = new Vector2(0f, -52.5f);
        resetButton.transform.localPosition = new Vector2(44f, -56f);

        youtubeBtn.transform.localPosition = new Vector2(-42.8f, -30f);
        discordBtn.transform.localPosition = new Vector2(0f, -30f);
        twitterBtn.transform.localPosition = new Vector2(42.8f, -30f);

        autoDrop.transform.localPosition = new Vector2(-43f, -44f);
        autoDrop.transform.localScale = new Vector2(0.368f, 0.368f);
    }

    #endregion

    public GameObject buffTooltip, buffClose, buffDark;
    public void CloseBuffTooltip()
    {
        ClickSound();
        blackPrestigeBlock.SetActive(false);
        buffTooltip.SetActive(false);
        buffClose.SetActive(false);
        buffDark.SetActive(false);
        BuffsToolTip.buffCurrentlyHovering = 0;
    }

    public AudioManager audioManager;
    public void ClickSound()
    {
        int random = Random.Range(1, 3);
        if (random == 1) { audioManager.Play("UIClick1"); }
        if (random == 2) { audioManager.Play("UIClick2"); }
    }

    public void GooglePlayLink()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.eagleeyegames.pegidle");
    }
    public void AppStoreLink()
    {
        Application.OpenURL("https://apps.apple.com/us/app/pegidle/id6739036408");
    }
}
