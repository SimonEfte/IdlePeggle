using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsOptions : MonoBehaviour
{
    public GameObject settingsFrame, achFrame, statsFrame, challengesFrame;
    private List<Resolution> resolutions = new List<Resolution>();
    public TMP_Dropdown resolutionDropdown;

    public Animation wishlistAnim;

    public static bool isInStats;

    public AllStats statsScript;

    public void Awake()
    {
        triggerResolution = true;

        if (!PlayerPrefs.HasKey("saveIndex"))
        {
            FindResolutionIndex();
        }
        else
        {
            resolutionIndexSave = PlayerPrefs.GetInt("saveIndex");
        }


        if (!PlayerPrefs.HasKey("SaveFullScreen"))
        {
            saveFullsScreen = 0;
        }
        else
        {
            saveFullsScreen = PlayerPrefs.GetInt("SaveFullScreen");
        }

        if (saveFullsScreen == 1)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            fullScreenToggleOn.SetActive(false);
            fullSreenToggleOff.SetActive(true);
        }
        else
        {
            fullScreenToggleOn.SetActive(true);
            fullSreenToggleOff.SetActive(false);
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }


        if (!PlayerPrefs.HasKey("ScreenWidth"))
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            saveWidth = PlayerPrefs.GetInt("ScreenWidth");
            saveHeight = PlayerPrefs.GetInt("ScreenHeight");
            Screen.SetResolution(saveWidth, saveHeight, Screen.fullScreenMode);
        }
    }

    public GameObject textPopUpSlider, autoBalls, discrodBtn, xBtn, ytBtn;

    public void Start()
    {
        #region Resolution
        // Define a list of supported resolutions
        resolutions = new List<Resolution>
        {
            new Resolution { width = 800, height = 600 },
            new Resolution { width = 1024, height = 768 },
            new Resolution { width = 1280, height = 720 },
            new Resolution { width = 1280, height = 800 },
            new Resolution { width = 1280, height = 1024 },
            new Resolution { width = 1366, height = 768 },
            new Resolution { width = 1600, height = 900 },
            new Resolution { width = 1920, height = 1080 },
            new Resolution { width = 1920, height = 1200 },
            new Resolution { width = 2560, height = 1440 },
            new Resolution { width = 2560, height = 1600 },
            new Resolution { width = 2560, height = 1080 },
            new Resolution { width = 3440, height = 1440 },
            new Resolution { width = 3840, height = 1440 },
            new Resolution { width = 3840, height = 2160 },
            new Resolution { width = 3840, height = 2400 }
            // Add any other resolutions you want to support here
        };

        // Add the supported resolutions to the dropdown
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.value = resolutionIndexSave;
        #endregion

        tabSize = 1.27f;
        if(MobileScript.isMobile == true) { tabSize = 1.8f; }
        isInSettings = false;
        isRegularTab = true;
        tabOriginalSize = generalSettingsTab.transform.localScale;
        StartCoroutine(SetFlag());

        if(GameData.isDemo == true) 
        {
            wishlistAnim.gameObject.SetActive(true);
            textPopUpSlider.SetActive(false);
            autoBalls.transform.localPosition = new Vector2(0,-26);

            discrodBtn.transform.localPosition = new Vector2(-51.8f, -29.6f);
            xBtn.transform.localPosition = new Vector2(-51.8f, -44f);
            ytBtn.transform.localPosition = new Vector2(-51.8f, -59f);
        }
    }

    public bool playSound;
    IEnumerator SetFlag()
    {
        yield return new WaitForSeconds(0.2f);
        triggerResolution = false;
        SelectLanguage(LocalizationStrings.language);
        playSound = true;
    }

    public static bool isInChallengeTab;
    public GameObject exIcon, exIcon2;
    public GameObject achTooltip;
    public GameObject ballUpgradeToolTip;

    public void Update()
    {
        if(isInSettings == true)
        {
            if (isRegularTab == true) { generalSettingsTab.gameObject.transform.localScale = new Vector3(tabSize, tabSize, tabSize); }
            if (isAchTab == true) { achTab.gameObject.transform.localScale = new Vector3(tabSize, tabSize, tabSize);  }
            if (isStatsTab == true) { statsTab.gameObject.transform.localScale = new Vector3(tabSize, tabSize, tabSize); }
            if (isChallengeTab == true) { challengesTab.gameObject.transform.localScale = new Vector3(tabSize, tabSize, tabSize);  }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Prestige.isInPrestigeScreen == false)
            {
                OpenSettings();
            }
        }
    }

    #region Language Select
    public Button chineseFlag, japaneseFlag, koreanFlag, englishFlag, frenchFlag, germanFlag, russianFlag, spanishFlag;
    public GameObject languageSelect;

    public float flagOriginalSize, flagSelectedSize;

    public static bool flagSelected;

    public void SelectLanguage(int language)
    {
        if(playSound == true) { ClickSound(); }
        flagSelected = true;

        flagOriginalSize = 0.125f;
        flagSelectedSize = 0.16f;

        chineseFlag.transform.localScale = new Vector3(flagOriginalSize, flagOriginalSize, flagOriginalSize);
        japaneseFlag.transform.localScale = new Vector3(flagOriginalSize, flagOriginalSize, flagOriginalSize);
        koreanFlag.transform.localScale = new Vector3(flagOriginalSize, flagOriginalSize, flagOriginalSize);
        englishFlag.transform.localScale = new Vector3(flagOriginalSize, flagOriginalSize, flagOriginalSize);
        frenchFlag.transform.localScale = new Vector3(flagOriginalSize, flagOriginalSize, flagOriginalSize);
        germanFlag.transform.localScale = new Vector3(flagOriginalSize, flagOriginalSize, flagOriginalSize);
        russianFlag.transform.localScale = new Vector3(flagOriginalSize, flagOriginalSize, flagOriginalSize);
        spanishFlag.transform.localScale = new Vector3(flagOriginalSize, flagOriginalSize, flagOriginalSize);

        chineseFlag.image.raycastTarget = true;
        japaneseFlag.image.raycastTarget = true;
        koreanFlag.image.raycastTarget = true;
        englishFlag.image.raycastTarget = true;
        frenchFlag.image.raycastTarget = true;
        germanFlag.image.raycastTarget = true;
        russianFlag.image.raycastTarget = true;
        spanishFlag.image.raycastTarget = true;

        if (language == 2) 
        {
            chineseFlag.image.raycastTarget = false;
            languageSelect.transform.position = chineseFlag.transform.position;
            chineseFlag.transform.localScale = new Vector3(flagSelectedSize, flagSelectedSize, flagSelectedSize);
        }

        if (language == 3)
        {
            japaneseFlag.image.raycastTarget = false;
            languageSelect.transform.position = japaneseFlag.transform.position;
            japaneseFlag.transform.localScale = new Vector3(flagSelectedSize, flagSelectedSize, flagSelectedSize);
        }

        if (language == 4)
        {
            koreanFlag.image.raycastTarget = false;
            languageSelect.transform.position = koreanFlag.transform.position;
            koreanFlag.transform.localScale = new Vector3(flagSelectedSize, flagSelectedSize, flagSelectedSize);
        }

        if (language == 1)
        {
            englishFlag.image.raycastTarget = false;
            languageSelect.transform.position = englishFlag.transform.position;
            englishFlag.transform.localScale = new Vector3(flagSelectedSize, flagSelectedSize, flagSelectedSize);
        }

        if (language == 7)
        {
            frenchFlag.image.raycastTarget = false;
            languageSelect.transform.position = frenchFlag.transform.position;
            frenchFlag.transform.localScale = new Vector3(flagSelectedSize, flagSelectedSize, flagSelectedSize);
        }

        if (language == 6)
        {
            germanFlag.image.raycastTarget = false;
            languageSelect.transform.position = germanFlag.transform.position;
            germanFlag.transform.localScale = new Vector3(flagSelectedSize, flagSelectedSize, flagSelectedSize);
        }

        if (language == 5)
        {
            russianFlag.image.raycastTarget = false;
            languageSelect.transform.position = russianFlag.transform.position;
            russianFlag.transform.localScale = new Vector3(flagSelectedSize, flagSelectedSize, flagSelectedSize);
        }

        if (language == 8)
        {
            spanishFlag.image.raycastTarget = false;
            languageSelect.transform.position = spanishFlag.transform.position;
            spanishFlag.transform.localScale = new Vector3(flagSelectedSize, flagSelectedSize, flagSelectedSize);
        }
    }
    #endregion

    #region resolution 

    public int resolutionIndexSave;
    public bool triggerResolution;
    public int saveHeight, saveWidth;
    public int saveFullsScreen;

    public void SetResolution(int resolutionIndex)
    {
        if (triggerResolution == false)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

            saveWidth = resolution.width;
            saveHeight = resolution.height;

            PlayerPrefs.SetInt("ScreenWidth", saveWidth);
            PlayerPrefs.SetInt("ScreenHeight", saveHeight);

            resolutionIndexSave = resolutionIndex;
            PlayerPrefs.SetInt("saveIndex", resolutionIndexSave);
        }
    }

    public GameObject fullSreenToggleOff, fullScreenToggleOn;

    public void SetFullSCreen()
    {
        if(saveFullsScreen == 0)
        {
            fullScreenToggleOn.SetActive(false);
            fullSreenToggleOff.SetActive(true);
            Screen.fullScreenMode = FullScreenMode.Windowed;

            saveFullsScreen = 1;
            PlayerPrefs.SetInt("SaveFullScreen", saveFullsScreen);

        }
        else
        {
            fullScreenToggleOn.SetActive(true);
            fullSreenToggleOff.SetActive(false);
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

            saveFullsScreen = 0;
            PlayerPrefs.SetInt("SaveFullScreen", saveFullsScreen);
        }
    }
  
    public void FindResolutionIndex()
    {
        if (Screen.width == 600 && Screen.height == 800) { resolutionIndexSave = 0; }
        if (Screen.width == 1024 && Screen.height == 768) { resolutionIndexSave = 1; }
        if (Screen.width == 1280 && Screen.height == 720) { resolutionIndexSave = 2; }
        if (Screen.width == 1280 && Screen.height == 800) { resolutionIndexSave = 3; }
        if (Screen.width == 1280 && Screen.height == 1024) { resolutionIndexSave = 4; }
        if (Screen.width == 1366 && Screen.height == 768) { resolutionIndexSave = 5; }
        if (Screen.width == 1600 && Screen.height == 900) { resolutionIndexSave = 6; }
        if (Screen.width == 1920 && Screen.height == 1080) { resolutionIndexSave = 7; }
        if (Screen.width == 1920 && Screen.height == 1200) { resolutionIndexSave = 8; }
        if (Screen.width == 2560 && Screen.height == 1440) { resolutionIndexSave = 9; }
        if (Screen.width == 2560 && Screen.height == 1600) { resolutionIndexSave = 10; }
        if (Screen.width == 2560 && Screen.height == 1080) { resolutionIndexSave = 11; }
        if (Screen.width == 3440 && Screen.height == 1440) { resolutionIndexSave = 12; }
        if (Screen.width == 3840 && Screen.height == 1440) { resolutionIndexSave = 13; }
        if (Screen.width == 3840 && Screen.height == 2160) { resolutionIndexSave = 14; }
        if (Screen.width == 3840 && Screen.height == 2400) { resolutionIndexSave = 15; }
    }
    #endregion

    public Challenges challSCript;

    #region Settings and tabs
    public void OpenSettings()
    {
        exIcon2.SetActive(false);
        ClickSound();
        if (settingsFrameObject.activeInHierarchy == false) 
        {
            //BallUpgrades.openedBallFrame = false;
            //ballUpgradeToolTip.SetActive(false);
            settingsFrameObject.SetActive(true); isInSettings = true; 
            if(wishlistAnim != null) { wishlistAnim.Play(); }
            if (isStatsTab == true) { isInStats = true; statsScript.DisplayAllStats(); }
            if(isChallengeTab == true) 
            { 
                exIcon.SetActive(false); isInChallengeTab = true;
                CheckChall();
            }
        }
        else 
        {
            achievementsToolTip.isHoveringACH = false;
            achTooltip.SetActive(false);
            isInChallengeTab = false; isInStats = false;
            settingsFrameObject.SetActive(false); isInSettings = false; resetScreen.SetActive(false);
        }
    }

    public void CheckChall()
    {
        //Board clears
        challSCript.ChallengeProgress(1, Levels.board1Clears);
        challSCript.ChallengeProgress(2, Levels.board2Clears);
        challSCript.ChallengeProgress(3, Levels.board3Clears);
        challSCript.ChallengeProgress(4, Levels.board4Clears);
        challSCript.ChallengeProgress(5, Levels.board5Clears);
        challSCript.ChallengeProgress(6, Levels.board6Clears);
        challSCript.ChallengeProgress(7, Levels.board7Clears);
        challSCript.ChallengeProgress(8, Levels.board8Clears);
        challSCript.ChallengeProgress(9, Levels.board9Clears);
        challSCript.ChallengeProgress(10, Levels.board10Clears);

        //Auto drop maxxed
        challSCript.ChallengeProgress(11, Challenges.ballsReachedMaxAuto);
        challSCript.ChallengeProgress(12, Challenges.ballsReachedMaxAuto);
        challSCript.ChallengeProgress(13, Challenges.ballsReachedMaxAuto);
        challSCript.ChallengeProgress(14, Challenges.ballsReachedMaxAuto);

        //Ball Level
        challSCript.ChallengeProgress(15, Challenges.ballUpgradeLevel);
        challSCript.ChallengeProgress(16, Challenges.ballUpgradeLevel);
        challSCript.ChallengeProgress(17, Challenges.ballUpgradeLevel);

        //Golden pegs hit
        challSCript.ChallengeProgress(18, AllStats.goldenPegsHit);
        challSCript.ChallengeProgress(19, AllStats.goldenPegsHit);
        challSCript.ChallengeProgress(20, AllStats.goldenPegsHit);

        //Buckets entered
        challSCript.ChallengeProgress(21, AllStats.totalBallsPit);
        challSCript.ChallengeProgress(22, AllStats.totalBallsPit);
        challSCript.ChallengeProgress(23, AllStats.totalBallsPit);

        challSCript.ChallengeProgress(24, Challenges.redBallBounceCount);
        challSCript.ChallengeProgress(25, Challenges.tinyBallsCount);
        challSCript.ChallengeProgress(26, Challenges.basketBallPegHitCount);
        challSCript.ChallengeProgress(27, Challenges.eggDoubleGoldCount);
        challSCript.ChallengeProgress(28, Challenges.cookieBallExtraCount);
        challSCript.ChallengeProgress(29, Challenges.goldenBallExtraCount);
        challSCript.ChallengeProgress(30, Challenges.footballBucketCount);
        challSCript.ChallengeProgress(31, Challenges.tinyRingBallsCount);
        challSCript.ChallengeProgress(32, Challenges.prestigeGemsHit);
        challSCript.ChallengeProgress(33, BasicBall.ghostBallsOnScreen);
        challSCript.ChallengeProgress(34, Challenges.starBallsSpawned);
        challSCript.ChallengeProgress(35, (int)(BallUpgrades.totalRainbowBallIncrease * 100));
        challSCript.ChallengeProgress(36, Challenges.tinyGlitchyBallsSpawned);
        challSCript.ChallengeProgress(37, Challenges.tinySharpnelCount);

        challSCript.CheckCompletedChall();
    }

    public GameObject settingsFrameObject;
    public Image generalSettingsTab, achTab, statsTab, challengesTab;
    public float tabSize;
    public Vector3 tabOriginalSize;

    public bool isRegularTab, isAchTab, isStatsTab, isChallengeTab;
    public static bool isInSettings;

    public void Tabs(int tab)
    {
        ClickSound();
        isRegularTab = false; isAchTab = false; isStatsTab = false; isChallengeTab = false;

        generalSettingsTab.gameObject.transform.localScale = tabOriginalSize;
        achTab.gameObject.transform.localScale = tabOriginalSize;
        statsTab.gameObject.transform.localScale = tabOriginalSize;
        challengesTab.gameObject.transform.localScale = tabOriginalSize;

        settingsFrame.gameObject.SetActive(false); generalSettingsTab.raycastTarget = true;
        achFrame.gameObject.SetActive(false); achTab.raycastTarget = true;
        statsFrame.gameObject.SetActive(false); statsTab.raycastTarget = true;
        challengesFrame.gameObject.SetActive(false); challengesTab.raycastTarget = true;

        if (tab == 1)
        {
            settingsFrame.SetActive(true); generalSettingsTab.raycastTarget = false;
            generalSettingsTab.gameObject.transform.localScale = new Vector3(tabSize, tabSize, tabSize);
            isRegularTab = true;
            if(wishlistAnim != null) { wishlistAnim.Play(); }
        }
        if (tab == 2) 
        {
            achFrame.SetActive(true); achTab.raycastTarget = false;
            achTab.gameObject.transform.localScale = new Vector3(tabSize, tabSize, tabSize);
            isAchTab = true;
        } 
        if (tab == 3) 
        { 
            statsFrame.SetActive(true); statsTab.raycastTarget = false;
            statsTab.gameObject.transform.localScale = new Vector3(tabSize, tabSize, tabSize);
            isStatsTab = true;
            isInStats = true;
            statsScript.DisplayAllStats();
        }
        if (tab == 4)
        {
            exIcon.SetActive(false);
            challengesFrame.SetActive(true); challengesTab.raycastTarget = false;
            challengesTab.gameObject.transform.localScale = new Vector3(tabSize, tabSize, tabSize);
            isChallengeTab = true;
            isInChallengeTab = true;
            CheckChall();
        }
    }
    #endregion

    #region Social Media
    public void Links(int link)
    {
        if(link == 1) { Application.OpenURL("https://www.youtube.com/@EagleEyeGames/featured"); }
        if (link == 2) { Application.OpenURL("https://twitter.com/Sniceman"); }
        if (link == 3) { Application.OpenURL("https://discord.gg/zkvwtU3mns"); }
        if (link == 4) { Application.OpenURL("https://store.steampowered.com/app/2821890/PegIdle/"); }
    }
    #endregion

    #region Reset Game
    public GameObject resetScreen;


    public void ResetButton()
    {
        ClickSound();
        resetScreen.SetActive(true);
    }

    public GameObject ballStatsFrame, ballEquippedFrame, ball1Frame;

    public void CompleteReset()
    {
        BallUpgrades.isBallEquippedScreen1 = true;
        BallUpgrades.isBallEquippedScreen2 = false;
        BallUpgrades.isBallEquippedScreen3 = false;

        ballStatsFrame.SetActive(true);
        ballEquippedFrame.SetActive(true);
        ballEquippedFrame.transform.localScale = new Vector3(0.7268971f, 0.7268971f, 0.7268971f);
        ballEquippedFrame.transform.position = ball1Frame.transform.position;

        prestigeScript.ResetPrestige();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        resetScript.ResetGame(false);
        resetScript.ResetGame(true);
        settingsFrameObject.SetActive(false);
        resetScreen.SetActive(false);
        BackToPool();
        Prestige.levelSelected = 1;
        MainShooter.totalPegsHit = 0;
        MainShooter.totalPegs = 0;
        prestigeScript.CheckLevelSetInactive();
        levelScript.CancelBoardAnim();
        levelScript.SetLevel();
    }

    public void NoReset()
    {
        ClickSound();
        resetScreen.SetActive(false);
    }
    #endregion

    #region Set OBjects on screen back to pool
    public MainShooter mainShooterScript;
    public Levels levelScript;
    public Prestige prestigeScript;
    public BallUpgrades ballUpgradesScript;
    public ResetVariables resetScript;

    public void BackToPool()
    {
        mainShooterScript.ResetAutoDrops();
        levelScript.ResetFullFill();
        ballUpgradesScript.ResetBalls();
        resetScript.ResetGame(false);

        #region Regular balls
        GameObject[] regularBalls = GameObject.FindGameObjectsWithTag("BasicBall");
        foreach (GameObject balls in regularBalls)
        {
            if (balls.activeSelf)
            {
                ObjectPool.instance.ReturnBasicBallFromPool(balls);
            }
        }
        #endregion

        #region Red balls
        GameObject[] RedBalls = GameObject.FindGameObjectsWithTag("RedBall");
        foreach (GameObject balls in RedBalls)
        {
            if (balls.activeSelf)
            {
                ObjectPool.instance.ReturnRedBallFromPool(balls);
            }
        }
      
        #endregion

        #region Rock balls
        GameObject[] RockBall = GameObject.FindGameObjectsWithTag("RockBall");
        foreach (GameObject balls in RockBall)
        {
            if (balls.activeSelf)
            {
                ObjectPool.instance.ReturnRockBallFromPool(balls);
            }
        }
       
        #endregion

        #region Bomb balls
        GameObject[] BombBall = GameObject.FindGameObjectsWithTag("BombBall");
        foreach (GameObject balls in BombBall)
        {
            if (balls.activeSelf)
            {
                ObjectPool.instance.ReturnBombBallFromPool(balls);
            }
        }
        #endregion

        #region Tiny balls
        GameObject[] TinyBall = GameObject.FindGameObjectsWithTag("TinyBall");
        foreach (GameObject balls in TinyBall)
        {
            if (balls.activeSelf)
            {
                ObjectPool.instance.ReturnTinyBallFromPool(balls);
            }
        }
        #endregion

        #region Aqua balls
        GameObject[] AquaBalls = GameObject.FindGameObjectsWithTag("AquaBall");
        foreach (GameObject balls in AquaBalls)
        {
            if (balls.activeSelf)
            {
                ObjectPool2.instance.ReturnAquaBallFromPool(balls);
            }
        }
        #endregion

        #region Mud balls
        GameObject[] MudBalls = GameObject.FindGameObjectsWithTag("MudBall");
        foreach (GameObject balls in MudBalls)
        {
            if (balls.activeSelf)
            {
                ObjectPool2.instance.ReturnMudBallFromPool(balls);
            }
        }
        #endregion

        #region Basket balls
        GameObject[] BasketBalls = GameObject.FindGameObjectsWithTag("BasketBall");
        foreach (GameObject balls in BasketBalls)
        {
            if (balls.activeSelf)
            {
                ObjectPool2.instance.ReturnBasketBallFromPool(balls);
            }
        }
        #endregion

        #region Plum balls
        GameObject[] PlumBalls = GameObject.FindGameObjectsWithTag("PlumBall");
        foreach (GameObject balls in PlumBalls)
        {
            if (balls.activeSelf)
            {
                ObjectPool2.instance.ReturnPlumBallFromPool(balls);
            }
        }
        #endregion

        #region Sticky balls
        GameObject[] StickyBalls = GameObject.FindGameObjectsWithTag("StickyBall");
        foreach (GameObject balls in StickyBalls)
        {
            if (balls.activeSelf)
            {
                ObjectPool2.instance.ReturnStickyBallFromPool(balls);
            }
        }
        #endregion

        #region Candy Balls
        GameObject[] candyBalls = GameObject.FindGameObjectsWithTag("CandyBall");
        foreach (GameObject ball in candyBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnCandyBallFromPool(ball);
            }
        }
        #endregion

        #region Cookie Balls
        GameObject[] cookieBalls = GameObject.FindGameObjectsWithTag("CookieBall");
        foreach (GameObject ball in cookieBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnCookieBallFromPool(ball);
            }
        }
        #endregion

        #region Lime Balls
        GameObject[] limeBalls = GameObject.FindGameObjectsWithTag("LimeBall");
        foreach (GameObject ball in limeBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnLimeBallFromPool(ball);
            }
        }
        #endregion

        #region Golden Balls
        GameObject[] goldenBalls = GameObject.FindGameObjectsWithTag("GoldenBall");
        foreach (GameObject ball in goldenBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnGoldenBallFromPool(ball);
            }
        }
        #endregion

        #region Football Balls
        GameObject[] footballBalls = GameObject.FindGameObjectsWithTag("FootBall");
        foreach (GameObject ball in footballBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnFootballBallFromPool(ball);
            }
        }
        #endregion

        #region Sharpnel Balls
        GameObject[] sharpnelBalls = GameObject.FindGameObjectsWithTag("SharpnelBall");
        foreach (GameObject ball in sharpnelBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnSharpnelBallFromPool(ball);
            }
        }
        #endregion

        #region Zonic Balls
        GameObject[] zonicBalls = GameObject.FindGameObjectsWithTag("ZonicBall");
        foreach (GameObject ball in zonicBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnZonicBallFromPool(ball);
            }
        }
        #endregion

        #region Apricot Balls
        GameObject[] apricotBalls = GameObject.FindGameObjectsWithTag("ApricotBall");
        foreach (GameObject ball in apricotBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnApricotBallFromPool(ball);
            }
        }
        #endregion

        #region Peggo Balls
        GameObject[] peggoBalls = GameObject.FindGameObjectsWithTag("PeggoBall");
        foreach (GameObject ball in peggoBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnPeggoBallFromPool(ball);
            }
        }
        #endregion

        #region Ghost Balls
        GameObject[] ghostBalls = GameObject.FindGameObjectsWithTag("GhostBall");
        foreach (GameObject ball in ghostBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnGhostBallFromPool(ball);
            }
        }
        #endregion

        #region Star Balls
        GameObject[] starBalls = GameObject.FindGameObjectsWithTag("StarBall");
        foreach (GameObject ball in starBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnStarBallFromPool(ball);
            }
        }
        #endregion

        #region Rainbow Balls
        GameObject[] rainbowBalls = GameObject.FindGameObjectsWithTag("RainbowBall");
        foreach (GameObject ball in rainbowBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnRainbowBallFromPool(ball);
            }
        }
        #endregion

        #region Glitchy Balls
        GameObject[] glitchyBalls = GameObject.FindGameObjectsWithTag("GlitchyBall");
        foreach (GameObject ball in glitchyBalls)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnGlitchyBallFromPool(ball);
            }
        }
        #endregion

        #region Tiny Sharpnel Balls
        GameObject[] tinySharpnel = GameObject.FindGameObjectsWithTag("TinySharpnel");
        foreach (GameObject ball in tinySharpnel)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnTinyShaprnelBallFromPool(ball);
            }
        }
        #endregion

        #region Tiny Ring Balls
        GameObject[] tinyRing = GameObject.FindGameObjectsWithTag("TinyRingBall");
        foreach (GameObject ball in tinyRing)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnTinyRingBallFromPool(ball);
            }
        }
        #endregion

        #region Tiny glithy Balls
        GameObject[] tinyGlitchy = GameObject.FindGameObjectsWithTag("TinyGlitchyBall");
        foreach (GameObject ball in tinyGlitchy)
        {
            if (ball.activeSelf)
            {
                ObjectPool2.instance.ReturnTinyGlitchyBallFromPool(ball);
            }
        }
        #endregion

        #region Coins
        GameObject[] coins = GameObject.FindGameObjectsWithTag("GoldCoin");
        foreach (GameObject coin in coins)
        {
            if (coin.activeSelf)
            {
                ObjectPool2.instance.ReturnGoldCoinFromPool(coin);
            }
        }
        #endregion

        #region Prestige gem
        GameObject[] prestigeGem = GameObject.FindGameObjectsWithTag("PrestigeGem");
        foreach (GameObject gem in prestigeGem)
        {
            if (gem.activeSelf)
            {
                ObjectPool2.instance.ReturnPrestigeGemFromPool(gem);
            }
        }
        #endregion

        #region Pegs
        GameObject[] pegs = GameObject.FindGameObjectsWithTag("BasicPeg");
        foreach (GameObject peg in pegs)
        {
            if (peg.activeSelf)
            {
                ObjectPool.instance.ReturnPegsFromPool(peg);
            }
        }
        #endregion

        #region Pegs hit
        GameObject[] pegsHit = GameObject.FindGameObjectsWithTag("PegHit");
        foreach (GameObject peg in pegsHit)
        {
            if (peg.activeSelf)
            {
                //ObjectPool.instance.ReturnPegHitFromPool(peg);
            }
        }
        #endregion
    }
    #endregion

    public void RemovePegs()
    {
        #region Pegs hit
        GameObject[] pegsHit = GameObject.FindGameObjectsWithTag("PegHit");
        foreach (GameObject peg in pegsHit)
        {
            if (peg.activeSelf)
            {
                // ObjectPool.instance.ReturnPegHitFromPool(peg);
            }
        }
        #endregion

        #region Pegs
        GameObject[] pegs = GameObject.FindGameObjectsWithTag("BasicPeg");
        foreach (GameObject peg in pegs)
        {
            if (peg.activeSelf)
            {
                ObjectPool.instance.ReturnPegsFromPool(peg);
            }
        }
        #endregion
    }

    public void CheckDebug()
    {
        Debug.Log(BasicBall.ghostBallsOnScreen + " Ghost balls on screen");
        Debug.Log(BasicBall.totalRainbowBallHitPegs + " Rainbow ball peg hits");
    }

    public AudioManager audioManager;
    public void ClickSound()
    {
        int random = Random.Range(1,3);
        if(random == 1) { audioManager.Play("UIClick1"); }
        if (random == 2) { audioManager.Play("UIClick2"); }
    }

    public void ExitSettings()
    {
        ClickSound();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        settingsFrameObject.SetActive(false);
    }

    public Animation saveGameAnim;
    public Coroutine saveGameCourinte;

    public void SaveGame()
    {
        if(saveGameCourinte == null) { saveGameCourinte = StartCoroutine(SaveGameTextAnim()); }
    }

    IEnumerator SaveGameTextAnim()
    {

        saveGameAnim.gameObject.SetActive(true);
        if(MobileScript.isMobile == false) { saveGameAnim.Play("GameSavedAnim"); }
        if (MobileScript.isMobile == true) { saveGameAnim.Play("GameSavedAnimMobile"); }
        yield return new WaitForSeconds(0.683f);
        saveGameAnim.gameObject.SetActive(false);

        saveGameCourinte = null;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ForceQuit()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
