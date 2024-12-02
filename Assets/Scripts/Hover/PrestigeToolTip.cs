using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PrestigeToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[HideInInspector]
    public GameObject prestigeToolTip, presiteCircle, prestigePurchase, prestigeClose;

    [HideInInspector]
    public GameObject text1, text2, text3;

    [HideInInspector]
    public GameObject upgradeInfoToolTipSize, priceText;

    [HideInInspector]
    public GameObject loc;
    [HideInInspector]
    public LocalizationStrings locScript;

    [HideInInspector]
    public Transform prestigeLocked;
    //--------------------------------

    public bool noLocked;
    public bool isHoveringPrestige;
    public static bool isHoveringPrestigeUpgrade;

    public bool isRound, isSquare, isLevel;

    public int numberOfLines;
    public int sizeDeltaHeight, toolTipPos;
    public int extraSize;

    public bool isGoldUpgrade, isPrestigeUpgrade, isNewLevelUpgrade, isNewPegUpgrade, isActiveUpgrade, isMoreShotsUpgrade;
    public static bool isGoldUpgradeMobile, isPrestigeUpgradeMobile, isNewLevelUpgradeMobile, isNewPegUpgradeMobile, isActiveUpgradeMobile, isMoreShotsUpgradeMobile;
    public int upgradeNumber;
    public static int upgradeNumberTooltip;

    public int prestigePrice;
    public static int prestigePointPrice;

    public int mobileSize;

    public void Awake()
    {
        loc = GameObject.Find("LocStringsScript");
        locScript = loc.GetComponent<LocalizationStrings>();

        prestigeLocked = transform.Find("PrestigeLocked");
        if(prestigeLocked == null) { noLocked = true; }
        else { noLocked = false; }

        if(isRound == true) { extraSize = 0; }
        if(isSquare == true) { extraSize = -10; }
        if(isLevel == true) { extraSize = 19; }
        if(isMoreShotsUpgrade == true) { extraSize = 25; }

        if(numberOfLines == 2) { toolTipPos = 62 + extraSize; sizeDeltaHeight = 48; mobileSize = 75; }
        if (numberOfLines == 3) { toolTipPos = 83 + extraSize; sizeDeltaHeight = 71; mobileSize = 114; }
        if (numberOfLines == 4) { toolTipPos = 94 + extraSize; sizeDeltaHeight = 90; mobileSize = 160; }
        if (numberOfLines == 5) { toolTipPos = 110 + extraSize; sizeDeltaHeight = 106; mobileSize = 190; }
        if (numberOfLines == 6) { toolTipPos = 108 + extraSize; sizeDeltaHeight = 117; mobileSize = 207; }
        if (numberOfLines == 8) { toolTipPos = 136 + extraSize; sizeDeltaHeight = 158; mobileSize = 295; }

        prestigeToolTip = GameObject.Find("PrestigeToolTip");
        presiteCircle = GameObject.Find("PrestigeCircle");

        priceText = GameObject.Find("PriceText");

        text1 = GameObject.Find("text1ToolTip");
        text2 = GameObject.Find("text2ToolTip");
        text3 = GameObject.Find("text3ToolTip");

        upgradeInfoToolTipSize = GameObject.Find("PegscensionToolTip");
    }

    private void Start()
    {
        if (MobileScript.isMobile == true)
        {
            prestigePurchase = GameObject.Find("PrestigeTooltipUpgradeMobile");
            prestigeClose = GameObject.Find("PrestigeTooltipCloseMobile");
        }
    }

    public void Update()
    {
        if(isHoveringPrestige == true)
        {
            if(MobileScript.isMobile == false) { prestigeToolTip.transform.position = gameObject.transform.position; }
        }
    }

    public static bool openPrestigeTooltip;

    public float targetY;
    public Vector2 currentPositition;
    public int currentPrestigePrice;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(noLocked == true)
        {

        }
        else
        {
            if (prestigeLocked.gameObject.activeInHierarchy == true)
            {
                return;
            }
        }

        if (MobileScript.isMobile == true) { return; }
        OpenPrestigeToolTip();
    }

    public static bool isMobilePrestigeOpen;

    public void OpenPrestigeToolTip()
    {
        isGoldUpgradeMobile = false;
        isNewLevelUpgradeMobile = false;
        isPrestigeUpgradeMobile = false;
        isNewPegUpgradeMobile = false;
        isActiveUpgradeMobile = false;
        isMoreShotsUpgradeMobile = false;

        upgradeNumberTooltip = upgradeNumber;

        //Debug.Log(upgradeNumber);

        isMobilePrestigeOpen = true;

        isHoveringPrestige = true;
        isHoveringPrestigeUpgrade = true;

        //if (MobileScript.isMobile == true) { return; }

        prestigePointPrice = prestigePrice;

        //Sets the size based on how many lines of text there i
        if (MobileScript.isMobile == false)
        {
            upgradeInfoToolTipSize.transform.localPosition = new Vector2(0, toolTipPos);
        }
        else
        {
           
            openPrestigeTooltip = true;
            upgradeInfoToolTipSize.transform.localPosition = new Vector2(0, 0);
            upgradeInfoToolTipSize.transform.localScale = new Vector2(2.78f, 2.78f);
            prestigeToolTip.transform.localPosition = new Vector2(0, 75);

            if (Prestige.isOnlyViewing == true)
            {
                prestigePurchase.SetActive(false); prestigeClose.SetActive(true);
                prestigeClose.transform.localPosition = new Vector2(0, -sizeDeltaHeight - mobileSize);
            }
            else
            {
                prestigePurchase.SetActive(true); prestigeClose.SetActive(true);
                int size = 0;
                if(upgradeNumber == 0 && Prestige.purchasedFirstUpgrade == true) { prestigePurchase.SetActive(false); size = 0; }
                else { size = 308; }

                #region Gold Check
                if (isGoldUpgrade == true)
                {
                    if (upgradeNumber == 1 && Prestige.G_Upgrade1Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 2 && Prestige.G_Upgrade2Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 3 && Prestige.G_Upgrade3Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 4 && Prestige.G_Upgrade4Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 5 && Prestige.G_Upgrade5Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 6 && Prestige.G_Upgrade6Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 7 && Prestige.G_Upgrade7Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 8 && Prestige.G_Upgrade8Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 9 && Prestige.G_Upgrade9Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 10 && Prestige.G_Upgrade10Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 11 && Prestige.G_Upgrade11Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 12 && Prestige.G_Upgrade12Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 13 && Prestige.G_Upgrade13Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 14 && Prestige.G_Upgrade14Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 15 && Prestige.G_Upgrade15Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 16 && Prestige.G_Upgrade16Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 17 && Prestige.G_Upgrade17Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 18 && Prestige.G_Upgrade18Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 19 && Prestige.G_Upgrade19Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 20 && Prestige.G_Upgrade20Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 21 && Prestige.G_Upgrade21Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 22 && Prestige.G_Upgrade22Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 23 && Prestige.G_Upgrade23Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 24 && Prestige.G_Upgrade24Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 25 && Prestige.G_Upgrade25Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 26 && Prestige.G_Upgrade26Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 27 && Prestige.G_Upgrade27Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 28 && Prestige.G_Upgrade28Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 29 && Prestige.G_Upgrade29Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 30 && Prestige.G_Upgrade30Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 31 && Prestige.G_Upgrade31Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 32 && Prestige.G_Upgrade32Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 33 && Prestige.G_Upgrade33Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 34 && Prestige.G_Upgrade34Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 35 && Prestige.G_Upgrade35Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 36 && Prestige.G_Upgrade36Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 37 && Prestige.G_Upgrade37Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 38 && Prestige.G_Upgrade38Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 39 && Prestige.G_Upgrade39Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 40 && Prestige.G_Upgrade40Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 41 && Prestige.G_Upgrade41Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 42 && Prestige.G_Upgrade42Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 43 && Prestige.G_Upgrade43Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 44 && Prestige.G_Upgrade44Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 45 && Prestige.G_Upgrade45Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 46 && Prestige.G_Upgrade46Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 47 && Prestige.G_Upgrade47Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 48 && Prestige.G_Upgrade48Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 49 && Prestige.G_Upgrade49Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 50 && Prestige.G_Upgrade50Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 51 && Prestige.G_Upgrade51Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else { size = 308; }
                }
                #endregion

                #region Prestige Check
                else if (isPrestigeUpgrade)
                {
                    if (upgradeNumber == 1 && Prestige.PU_Upgrade1Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 2 && Prestige.PU_Upgrade2Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 3 && Prestige.PU_Upgrade3Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 4 && Prestige.PU_Upgrade4Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 5 && Prestige.PU_Upgrade5Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 6 && Prestige.PU_Upgrade6Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 7 && Prestige.PU_Upgrade7Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 8 && Prestige.PU_Upgrade8Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 9 && Prestige.PU_Upgrade9Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 10 && Prestige.PU_Upgrade10Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 11 && Prestige.PU_Upgrade11Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 12 && Prestige.PU_Upgrade12Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 13 && Prestige.PU_Upgrade13Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 14 && Prestige.PU_Upgrade14Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 15 && Prestige.PU_Upgrade15Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 16 && Prestige.PU_Upgrade16Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 17 && Prestige.PU_Upgrade17Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 18 && Prestige.PU_Upgrade18Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 19 && Prestige.PU_Upgrade19Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 20 && Prestige.PU_Upgrade20Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 21 && Prestige.PU_Upgrade21Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 22 && Prestige.PU_Upgrade22Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 23 && Prestige.PU_Upgrade23Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 24 && Prestige.PU_Upgrade24Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 25 && Prestige.PU_Upgrade25Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 26 && Prestige.PU_Upgrade26Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 27 && Prestige.PU_Upgrade27Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 28 && Prestige.PU_Upgrade28Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 29 && Prestige.PU_Upgrade29Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 30 && Prestige.PU_Upgrade30Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 31 && Prestige.PU_Upgrade31Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 32 && Prestige.PU_Upgrade32Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 33 && Prestige.PU_Upgrade33Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 34 && Prestige.PU_Upgrade34Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 35 && Prestige.PU_Upgrade35Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 36 && Prestige.PU_Upgrade36Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 37 && Prestige.PU_Upgrade37Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 38 && Prestige.PU_Upgrade38Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 39 && Prestige.PU_Upgrade39Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 40 && Prestige.PU_Upgrade40Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 41 && Prestige.PU_Upgrade41Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 42 && Prestige.PU_Upgrade42Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 43 && Prestige.PU_Upgrade43Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 44 && Prestige.PU_Upgrade44Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else { size = 308; }
                }
                #endregion

                #region New Peg Check
                else if (isNewPegUpgrade)
                {
                    if (upgradeNumber == 1 && Prestige.NP_Upgrade1Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 2 && Prestige.NP_Upgrade2Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 3 && Prestige.NP_Upgrade3Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 4 && Prestige.NP_Upgrade4Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 5 && Prestige.NP_Upgrade5Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 6 && Prestige.NP_Upgrade6Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 7 && Prestige.NP_Upgrade7Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 8 && Prestige.NP_Upgrade8Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 9 && Prestige.NP_Upgrade9Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 10 && Prestige.NP_Upgrade10Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 11 && Prestige.NP_Upgrade11Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 12 && Prestige.NP_Upgrade12Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 13 && Prestige.NP_Upgrade13Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 14 && Prestige.NP_Upgrade14Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 15 && Prestige.NP_Upgrade15Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 16 && Prestige.NP_Upgrade16Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 17 && Prestige.NP_Upgrade17Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 18 && Prestige.NP_Upgrade18Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 19 && Prestige.NP_Upgrade19Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 20 && Prestige.NP_Upgrade20Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 21 && Prestige.NP_Upgrade21Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 22 && Prestige.NP_Upgrade22Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 23 && Prestige.NP_Upgrade23Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 24 && Prestige.NP_Upgrade24Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 25 && Prestige.NP_Upgrade25Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 26 && Prestige.NP_Upgrade26Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 27 && Prestige.NP_Upgrade27Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 28 && Prestige.NP_Upgrade28Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 29 && Prestige.NP_Upgrade29Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 30 && Prestige.NP_Upgrade30Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 31 && Prestige.NP_Upgrade31Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 32 && Prestige.NP_Upgrade32Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 33 && Prestige.NP_Upgrade33Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 34 && Prestige.NP_Upgrade34Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else { size = 308; }
                }
                #endregion

                #region Active Check
                else if (isActiveUpgrade)
                {
                    if (upgradeNumber == 1 && Prestige.A_Upgrade1Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 2 && Prestige.A_Upgrade2Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 3 && Prestige.A_Upgrade3Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 4 && Prestige.A_Upgrade4Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 5 && Prestige.A_Upgrade5Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 6 && Prestige.A_Upgrade6Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 7 && Prestige.A_Upgrade7Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 8 && Prestige.A_Upgrade8Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 9 && Prestige.A_Upgrade9Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 10 && Prestige.A_Upgrade10Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 11 && Prestige.A_Upgrade11Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 12 && Prestige.A_Upgrade12Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 13 && Prestige.A_Upgrade13Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 14 && Prestige.A_Upgrade14Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 15 && Prestige.A_Upgrade15Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 16 && Prestige.A_Upgrade16Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 17 && Prestige.A_Upgrade17Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 18 && Prestige.A_Upgrade18Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 19 && Prestige.A_Upgrade19Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 20 && Prestige.A_Upgrade20Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 21 && Prestige.A_Upgrade21Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 22 && Prestige.A_Upgrade22Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 23 && Prestige.A_Upgrade23Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 24 && Prestige.A_Upgrade24Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 25 && Prestige.A_Upgrade25Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 26 && Prestige.A_Upgrade26Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 27 && Prestige.A_Upgrade27Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 28 && Prestige.A_Upgrade28Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 29 && Prestige.A_Upgrade29Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 30 && Prestige.A_Upgrade30Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 31 && Prestige.A_Upgrade31Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 32 && Prestige.A_Upgrade32Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 33 && Prestige.A_Upgrade33Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else { size = 308; }
                }
                #endregion

                #region New level Check
                else if (isNewLevelUpgrade)
                {
                    if (upgradeNumber == 2 && Prestige.purchasedLevel2 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 3 && Prestige.purchasedLevel3 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 4 && Prestige.purchasedLevel4 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 5 && Prestige.purchasedLevel5 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 6 && Prestige.purchasedLevel6 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 7 && Prestige.purchasedLevel7 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 8 && Prestige.purchasedLevel8 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 9 && Prestige.purchasedLevel9 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 10 && Prestige.purchasedLevel10 == true) { prestigePurchase.SetActive(false); size = 0; }
                    else { size = 308; }
                }
                #endregion

                #region More Shots Check
                else if (isMoreShotsUpgrade)
                {
                    if (upgradeNumber == 1 && Prestige.moreShots1Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 2 && Prestige.moreShots2Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 3 && Prestige.moreShots3Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else if (upgradeNumber == 4 && Prestige.moreShots4Purchased == true) { prestigePurchase.SetActive(false); size = 0; }
                    else { size = 308; }
                }
                #endregion

                prestigePurchase.transform.localPosition = new Vector2(-308, -sizeDeltaHeight - mobileSize);
                prestigeClose.transform.localPosition = new Vector2(size, -sizeDeltaHeight - mobileSize);
            }
        }

        upgradeInfoToolTipSize.GetComponent<RectTransform>().sizeDelta = new Vector2(212, sizeDeltaHeight);

    

        //Sets tool tip objects active
        if (MobileScript.isMobile == false)
        {
            presiteCircle.SetActive(true);
            presiteCircle.transform.position = gameObject.transform.position;
            presiteCircle.transform.SetParent(gameObject.transform);

            if (isRound == true)
            {
                presiteCircle.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
            }
            else if (isLevel == true)
            {
                presiteCircle.transform.localScale = new Vector3(1.31f, 1.31f, 1.31f);
            }
            else if (isSquare == true)
            {
                presiteCircle.transform.localScale = new Vector3(1.17f, 1.17f, 1.17f);
            }
            else if (isMoreShotsUpgrade == true)
            {
                presiteCircle.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            }
        }

        prestigeToolTip.SetActive(true);

        if (upgradeNumber == 0)
        {
            locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease1);
            text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldenPegChanceString;
            text2.GetComponent<TextMeshProUGUI>().text = "";
        }

        #region All gold upgrades
        else if (isGoldUpgrade == true)
        {
            isGoldUpgradeMobile = isGoldUpgrade;

            //Gold Rush
            #region Upgrade 51
            if (upgradeNumber == 51)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldRushString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldRushString2;
            }
            #endregion

            //Gold Increase
            #region Upgrade 1
            else if (upgradeNumber == 1)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease1);
            }
            #endregion

            #region Upgrade 3
            else if (upgradeNumber == 3)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease2);
            }
            #endregion

            #region Upgrade 5
            else if (upgradeNumber == 5)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease3);
            }
            #endregion

            #region Upgrade 7
            else if (upgradeNumber == 7)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease4);
            }
            #endregion

            #region Upgrade 9
            else if (upgradeNumber == 9)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease5);
            }
            #endregion

            #region Upgrade 11
            else if (upgradeNumber == 11)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease6);
            }
            #endregion

            #region Upgrade 37
            else if (upgradeNumber == 37)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease7);
            }
            #endregion

            #region Upgrade 38
            else if (upgradeNumber == 38)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease8);
            }
            #endregion

            #region Upgrade 40
            else if (upgradeNumber == 40)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease9);
            }
            #endregion

            #region Upgrade 41
            else if (upgradeNumber == 41)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease10);
            }
            #endregion

            #region Upgrade 43
            else if (upgradeNumber == 43)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease11);
            }
            #endregion

            #region Upgrade 44
            else if (upgradeNumber == 44)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease12);
            }
            #endregion

            #region Upgrade 46
            else if (upgradeNumber == 46)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease13);
            }
            #endregion

            #region Upgrade 47
            else if (upgradeNumber == 47)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease14);
            }
            #endregion

            #region Upgrade 49
            else if (upgradeNumber == 49)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease15);
            }
            #endregion

            #region Upgrade 50
            else if (upgradeNumber == 50)
            {
                locScript.ChangeGoldGainIncrease(Prestige.goldIncrease16);
            }
            #endregion

            //Gold peg chance increase
            #region Upgrade 2
            else if (upgradeNumber == 2)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease2);
            }
            #endregion

            #region Upgrade 4
            else if (upgradeNumber == 4)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease3);
            }
            #endregion

            #region Upgrade 6
            else if (upgradeNumber == 6)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease4);
            }
            #endregion

            #region Upgrade 8
            else if (upgradeNumber == 8)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease5);
            }
            #endregion

            #region Upgrade 10
            else if (upgradeNumber == 10)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease6);
            }
            #endregion

            #region Upgrade 36
            else if (upgradeNumber == 36)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease7);
            }
            #endregion

            #region Upgrade 39
            else if (upgradeNumber == 39)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease8);
            }
            #endregion

            #region Upgrade 42
            else if (upgradeNumber == 42)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease9);
            }
            #endregion

            #region Upgrade 45
            else if (upgradeNumber == 45)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease10);
            }
            #endregion

            #region Upgrade 48
            else if (upgradeNumber == 48)
            {
                locScript.ChangeGoldPegChanceIncrease(Prestige.goldenPegChanceIncrease11);
            }
            #endregion

            //Clear bonus from pegs
            #region Upgrade 12
            else if (upgradeNumber == 12)
            {
                locScript.ChangeGoldClearAmount(Prestige.clearBonus1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearBonusString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearBonusAmountString;
            }
            #endregion

            #region Upgrade 13
            else if (upgradeNumber == 13)
            {
                locScript.ChangeGoldClearAmount(Prestige.clearBonus2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearBonusAmountString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 14
            else if (upgradeNumber == 14)
            {
                locScript.ChangeGoldClearAmount(Prestige.clearBonus3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearBonusAmountString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 15
            else if (upgradeNumber == 15)
            {
                locScript.ChangeGoldClearAmount(Prestige.clearBonus4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearBonusAmountString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 16
            else if (upgradeNumber == 16)
            {
                locScript.ChangeGoldClearAmount(Prestige.clearBonus5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearBonusAmountString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 17
            else if (upgradeNumber == 17)
            {
                locScript.ChangeGoldClearAmount(Prestige.clearBonus6);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearBonusAmountString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 18
            else if (upgradeNumber == 18)
            {
                locScript.ChangeGoldClearAmount(Prestige.clearBonus7);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearBonusAmountString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //Clear bonus from bucket
            #region Upgrade 19
            else if (upgradeNumber == 19)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketGoldClear;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketGoldClear2;
            }
            #endregion

            //Clear bonus from timer
            #region Upgrade 20
            else if (upgradeNumber == 20)
            {
                locScript.ChangeGoldTimeBonusAmont(Prestige.goldClearTimer1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearTimerString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearTimerAmount;
            }
            #endregion

            #region Upgrade 21
            else if (upgradeNumber == 21)
            {
                locScript.ChangeGoldTimeBonusAmont(Prestige.goldClearTimer2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearTimerAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 22
            else if (upgradeNumber == 22)
            {
                locScript.ChangeGoldTimeBonusAmont(Prestige.goldClearTimer3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearTimerAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 23
            else if (upgradeNumber == 23)
            {
                locScript.ChangeGoldTimeBonusAmont(Prestige.goldClearTimer4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearTimerAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 24
            else if (upgradeNumber == 24)
            {
                locScript.ChangeGoldTimeBonusAmont(Prestige.goldClearTimer5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearTimerAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 25
            else if (upgradeNumber == 25)
            {
                locScript.ChangeGoldTimeBonusAmont(Prestige.goldClearTimer6);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearTimerAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 26
            else if (upgradeNumber == 26)
            {
                locScript.ChangeGoldTimeBonusAmont(Prestige.goldClearTimer7);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.clearTimerAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //2X or more from golden pegs
            #region Upgrade 27
            else if (upgradeNumber == 27)
            {
                locScript.ChangeDoubleOrMoreGold(Prestige.X2goldChance, 2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 28
            else if (upgradeNumber == 28)
            {
                locScript.ChangeDoubleOrMoreGold(Prestige.X3goldChance, 3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 29
            else if (upgradeNumber == 29)
            {
                locScript.ChangeDoubleOrMoreGold(Prestige.X5goldChance, 5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 30
            else if (upgradeNumber == 30)
            {
                locScript.ChangeDoubleOrMoreGold(Prestige.X10goldChance, 10);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //2X or more from golden buckets
            #region Upgrade 31
            else if (upgradeNumber == 31)
            {
                locScript.ChangeDoubleBucketOrMoreGold(Prestige.X2bucketGoldChance, 2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldBucketDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 32
            else if (upgradeNumber == 32)
            {
                locScript.ChangeDoubleBucketOrMoreGold(Prestige.X3bucketGoldChance, 3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldBucketDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 33
            else if (upgradeNumber == 33)
            {
                locScript.ChangeDoubleBucketOrMoreGold(Prestige.X5bucketGoldChance, 5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldBucketDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 34
            else if (upgradeNumber == 34)
            {
                locScript.ChangeDoubleBucketOrMoreGold(Prestige.X8bucketGoldChance, 8);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldBucketDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 35
            else if (upgradeNumber == 35)
            {
                locScript.ChangeDoubleBucketOrMoreGold(Prestige.X10bucketGoldChance, 10);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldBucketDoubleOrMoreChances;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion



            #region Set golden peg chance increase text
            if (upgradeNumber == 2 || upgradeNumber == 4 || upgradeNumber == 6 || upgradeNumber == 8 || upgradeNumber == 10 || upgradeNumber == 36 || upgradeNumber == 39 || upgradeNumber == 42 || upgradeNumber == 45 || upgradeNumber == 48)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldenPegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Set gold increase text
            if (upgradeNumber == 1 || upgradeNumber == 3 || upgradeNumber == 5 || upgradeNumber == 7 || upgradeNumber == 9 || upgradeNumber == 11 || upgradeNumber == 37 || upgradeNumber == 38 || upgradeNumber == 40 || upgradeNumber == 41 || upgradeNumber == 43 || upgradeNumber == 44 || upgradeNumber == 46 || upgradeNumber == 47 || upgradeNumber == 49 || upgradeNumber == 50)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldGainIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion
        }
        #endregion

        #region All prestige upgrades
        else if (isPrestigeUpgrade == true)
        {
            isPrestigeUpgradeMobile = isPrestigeUpgrade;
            //Prestige rush
            #region Upgrade 44
            if (upgradeNumber == 44)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigeRush;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigeRush2;
            }
            #endregion

            //Prestige points increase
            #region Upgrade 1 
            if (upgradeNumber == 1)
            {
                locScript.ChangePrestigePointGain(1);
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointsString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
            }
            #endregion

            #region Upgrade 12 
            if (upgradeNumber == 12)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigeClearBonus;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigeClearBonus2;
            }
            #endregion

            #region Upgrade 28 
            if (upgradeNumber == 28)
            {
                locScript.ChangePrestigePointGain(1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointsString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 32 
            if (upgradeNumber == 32)
            {
                locScript.ChangePrestigePegChance(Prestige.newPrestigeIncrease2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 33 
            if (upgradeNumber == 33)
            {
                locScript.ChangePrestigePegChance(Prestige.newPrestigeIncrease3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 34 
            if (upgradeNumber == 34)
            {
                //locScript.ChangePrestigePointGain(1);
                locScript.ChangePrestigePegChance(Prestige.newPrestigeIncrease4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 38 
            if (upgradeNumber == 38)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease17);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 39
            if (upgradeNumber == 39)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease18);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 40
            if (upgradeNumber == 40)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease19);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //Prestige peg inncrease
            #region Upgrade 2 
            if (upgradeNumber == 2)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease2);
            }
            #endregion

            #region Upgrade 3 
            if (upgradeNumber == 3)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease3);
            }
            #endregion

            #region Upgrade 4 
            if (upgradeNumber == 4)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease4);
            }
            #endregion

            #region Upgrade 5 
            if (upgradeNumber == 5)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease5);
            }
            #endregion

            #region Upgrade 6 
            if (upgradeNumber == 6)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease6);
            }
            #endregion

            #region Upgrade 7 
            if (upgradeNumber == 7)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease7);
            }
            #endregion

            #region Upgrade 8 
            if (upgradeNumber == 8)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease8);
            }
            #endregion

            #region Upgrade 9 
            if (upgradeNumber == 9)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease9);
            }
            #endregion

            #region Upgrade 10 
            if (upgradeNumber == 10)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease10);
            }
            #endregion

            #region Upgrade 11 
            if (upgradeNumber == 11)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease11);
            }
            #endregion

            #region Upgrade 25 
            if (upgradeNumber == 25)
            {
                locScript.ChangePrestigePegChance(Prestige.newPrestigeIncrease1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 26 
            if (upgradeNumber == 26)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease12);
            }
            #endregion

            #region Upgrade 27 
            if (upgradeNumber == 27)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease13);
            }
            #endregion

            #region Upgrade 29 
            if (upgradeNumber == 29)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease14);
            }
            #endregion

            #region Upgrade 30 
            if (upgradeNumber == 30)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease15);
            }
            #endregion

            #region Upgrade 31 
            if (upgradeNumber == 31)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease16);
            }
            #endregion

            #region Upgrade 35 
            if (upgradeNumber == 35)
            {
                locScript.ChangePrestigePointGain(1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointsString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 36 
            if (upgradeNumber == 36)
            {
                locScript.ChangePrestigePointGain(1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointsString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 37
            if (upgradeNumber == 37)
            {
                locScript.ChangePrestigePointGain(1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointsString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 41
            if (upgradeNumber == 41)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease20);
            }
            #endregion

            #region Upgrade 42
            if (upgradeNumber == 42)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease21);
            }
            #endregion

            #region Upgrade 43
            if (upgradeNumber == 43)
            {
                locScript.ChangePrestigePegChance(Prestige.prestigePegChanceIncrease22);
            }
            #endregion

            //Bonus clear 
            #region Upgrade 13 
            if (upgradeNumber == 13)
            {
                locScript.ChangePrestigePointClearBonusAmount(Prestige.prestigeClearBonus2, 1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigeClearBonusAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 14 
            if (upgradeNumber == 14)
            {
                locScript.ChangePrestigePointClearBonusAmount(Prestige.prestigeClearBonus3, 1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigeClearBonusAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 15 
            if (upgradeNumber == 15)
            {
                locScript.ChangePrestigePointClearBonusAmount(Prestige.prestigeClearBonus4, 1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigeClearBonusAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 16 
            if (upgradeNumber == 16)
            {
                locScript.ChangePrestigePointGain(1);
                locScript.ChangePrestigePointClearBonusAmount(Prestige.prestigeClearBonus5, 2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigeClearBonusAmount;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointsString;
            }
            #endregion

            //Prestige point bucket
            #region Upgrade 17 
            if (upgradeNumber == 17)
            {
                locScript.ChangePrestigePointBucketChance(Prestige.bucketPrestigePointChance1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointBucket;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointBucketAmount;
            }
            #endregion

            #region Upgrade 18 
            if (upgradeNumber == 18)
            {
                locScript.ChangePrestigePointBucketChance(Prestige.bucketPrestigePointChance2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointBucketAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 19 
            if (upgradeNumber == 19)
            {
                locScript.ChangePrestigePointBucketChance(Prestige.bucketPrestigePointChance3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointBucketAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 20 
            if (upgradeNumber == 20)
            {
                locScript.ChangePrestigePointBucketChance(Prestige.bucketPrestigePointChance4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointBucketAmount;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //2X or more
            #region Upgrade 21 
            if (upgradeNumber == 21)
            {
                locScript.Change2XorMorePrestigeChance(Prestige.X2prestigePointChance, 2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestige2XorMore;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 22 
            if (upgradeNumber == 22)
            {
                locScript.Change2XorMorePrestigeChance(Prestige.X3prestigePointChance, 3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestige2XorMore;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 23 
            if (upgradeNumber == 23)
            {
                locScript.Change2XorMorePrestigeChance(Prestige.X5prestigePointChance, 5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestige2XorMore;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 24 
            if (upgradeNumber == 24)
            {
                locScript.Change2XorMorePrestigeChance(Prestige.X10prestigePointChance, 10);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestige2XorMore;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //All prestige chances upgrades
            #region prestige peg chances
            if (upgradeNumber == 2 || upgradeNumber == 3 || upgradeNumber == 4 || upgradeNumber == 5 || upgradeNumber == 6 || upgradeNumber == 7 || upgradeNumber == 8 || upgradeNumber == 9 || upgradeNumber == 10 || upgradeNumber == 11 || upgradeNumber == 26 || upgradeNumber == 27 || upgradeNumber == 29 || upgradeNumber == 30 || upgradeNumber == 31 || upgradeNumber == 41 || upgradeNumber == 42 || upgradeNumber == 43 || upgradeNumber == 25 || upgradeNumber == 32 || upgradeNumber == 33 || upgradeNumber == 34 || upgradeNumber == 38 || upgradeNumber == 39 || upgradeNumber == 40)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePegChanceString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion
        }
        #endregion

        #region All new peg upgrades
        else if (isNewPegUpgrade == true)
        {
            isNewPegUpgradeMobile = isNewPegUpgrade;
            //Red peg
            #region Upgrade 1 
            if (upgradeNumber == 1)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.firstRedPegString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.firstRedPegString2;
            }
            #endregion

            #region Upgrade 2 
            if (upgradeNumber == 2)
            {
                locScript.ChangeRedPegChance(Prestige.redPegChance2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.redPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 3
            if (upgradeNumber == 3)
            {
                locScript.ChangeRedPegChance(Prestige.redPegChance3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.redPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 4
            if (upgradeNumber == 4)
            {
                locScript.ChangeRedPegChance(Prestige.redPegChance4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.redPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 5
            if (upgradeNumber == 5)
            {
                locScript.ChangeRedPegChance(Prestige.redPegChance5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.redPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 6
            if (upgradeNumber == 6)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.redPegGoldDouble;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 7
            if (upgradeNumber == 7)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.redPegPrestigeDouble;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //Rainbow Peg
            #region Upgrade 8
            if (upgradeNumber == 8)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPeg1;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPeg2;
            }
            #endregion

            #region Upgrade 9
            if (upgradeNumber == 9)
            {
                locScript.ChangeRainbowPegChance(Prestige.rainbowPegChance2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 10
            if (upgradeNumber == 10)
            {
                locScript.ChangeRainbowPegChance(Prestige.rainbowPegChance3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 11
            if (upgradeNumber == 11)
            {
                locScript.ChangeRainbowPegChance(Prestige.rainbowPegChance4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 12
            if (upgradeNumber == 12)
            {
                locScript.ChangeRainbowPegChance(Prestige.rainbowPegChance5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion   

            #region Upgrade 13
            if (upgradeNumber == 13)
            {
                locScript.ChangeRainbowPegChance(Prestige.rainbowPegChance6);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 14
            if (upgradeNumber == 14)
            {
                locScript.ChangeRainbowPegChance(Prestige.rainbowPegChance7);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion   

            #region Upgrade 15
            if (upgradeNumber == 15)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPegIncreaseBuffs;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 16
            if (upgradeNumber == 16)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.rainbowPegReceiveAllBuffs;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //Bomb pegs
            #region Upgrade 17
            if (upgradeNumber == 17)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPeg1;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPeg2;
            }
            #endregion

            #region Upgrade 18
            if (upgradeNumber == 18)
            {
                locScript.ChangeBombPegChance(Prestige.bombPegChance2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 19
            if (upgradeNumber == 19)
            {
                locScript.ChangeBombPegChance(Prestige.bombPegChance3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 20
            if (upgradeNumber == 20)
            {
                locScript.ChangeBombPegChance(Prestige.bombPegChance4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 21
            if (upgradeNumber == 21)
            {
                locScript.ChangeBombPegChance(Prestige.bombPegChance5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 22
            if (upgradeNumber == 22)
            {
                locScript.ChangeBombPegChance(Prestige.bombPegChance6);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 23
            if (upgradeNumber == 23)
            {
                locScript.ChangeBombPegChance(Prestige.bombPegChance7);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 24
            if (upgradeNumber == 24)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPeg3Balls;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion  

            #region Upgrade 25
            if (upgradeNumber == 25)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bombPeg3to5Balls;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //Purple peg
            #region Upgrade 26
            if (upgradeNumber == 26)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePeg1;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePeg2;
            }
            #endregion

            #region Upgrade 27
            if (upgradeNumber == 27)
            {
                locScript.ChangePurplePegChance(Prestige.purplePegChance2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 29
            if (upgradeNumber == 29)
            {
                locScript.ChangePurplePegChance(Prestige.purplePegChance3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 31
            if (upgradeNumber == 31)
            {
                locScript.ChangePurplePegChance(Prestige.purplePegChance4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePegChance;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 28
            if (upgradeNumber == 28)
            {
                locScript.ChangePurplePegIncrease(Prestige.purplePegEnchanceIncrease2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePegIncrease;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 30
            if (upgradeNumber == 30)
            {
                locScript.ChangePurplePegIncrease(Prestige.purplePegEnchanceIncrease3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePegIncrease;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 32
            if (upgradeNumber == 32)
            {
                locScript.ChangePurplePegIncrease(Prestige.purplePegEnchanceIncrease4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePegIncrease;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 33
            if (upgradeNumber == 33)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePegPrestigePoint;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 34
            if (upgradeNumber == 34)
            {
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.purplePegNextBall;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion
        }
        #endregion

        #region All active upgrades
        else if (isActiveUpgrade == true)
        {
            isActiveUpgradeMobile = isActiveUpgrade;
            //Active shot gold increase
            #region Upgrade 1 
            if (upgradeNumber == 1)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 2 
            if (upgradeNumber == 2)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 4 
            if (upgradeNumber == 4)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 6 
            if (upgradeNumber == 6)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease4);
                locScript.ChangeStartWithGold(Prestige.goldStart3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.startWithGold;
            }
            #endregion

            #region Upgrade 7
            if (upgradeNumber == 7)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 8
            if (upgradeNumber == 8)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease6);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 9
            if (upgradeNumber == 9)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease7);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 10
            if (upgradeNumber == 10)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease8);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 11
            if (upgradeNumber == 11)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease9);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 12
            if (upgradeNumber == 12)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease10);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 13
            if (upgradeNumber == 13)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease11);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 14
            if (upgradeNumber == 14)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease12);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 15
            if (upgradeNumber == 15)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease13);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 16
            if (upgradeNumber == 16)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease14);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 17
            if (upgradeNumber == 17)
            {
                locScript.ChangeBallShotGoldIncrease(Prestige.ballShotGoldIncrease15);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.ballsShotGoldIncreaseString;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //Start with gold
            #region Upgrade 3
            if (upgradeNumber == 3)
            {
                locScript.ChangeStartWithGold(Prestige.goldStart1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.startWithGold;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 5
            if (upgradeNumber == 5)
            {
                locScript.ChangeStartWithGold(Prestige.goldStart2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.startWithGold;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 29
            if (upgradeNumber == 29)
            {
                locScript.ChangeStartWithGold(Prestige.goldStart4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.startWithGold;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 30
            if (upgradeNumber == 30)
            {
                locScript.ChangeStartWithGold(Prestige.goldStart5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.startWithGold;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 31
            if (upgradeNumber == 31)
            {
                locScript.ChangeStartWithGold(Prestige.goldStart6);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.startWithGold;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 32
            if (upgradeNumber == 32)
            {
                locScript.ChangeStartWithGold(Prestige.goldStart7);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.startWithGold;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 33
            if (upgradeNumber == 33)
            {
                locScript.ChangeStartWithGold(Prestige.goldStart8);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.startWithGold;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            //Gold from shooting
            #region Upgrade 22
            if (upgradeNumber == 22)
            {
                locScript.ChangeGoldFromShooting(Prestige.goldFromShot1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 23
            if (upgradeNumber == 23)
            {
                locScript.ChangeGoldFromShooting(Prestige.goldFromShot2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 24
            if (upgradeNumber == 24)
            {
                locScript.ChangeGoldFromShooting(Prestige.goldFromShot3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 25
            if (upgradeNumber == 25)
            {
                locScript.ChangeGoldFromShooting(Prestige.goldFromShot4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 26
            if (upgradeNumber == 26)
            {
                locScript.ChangeGoldFromShooting(Prestige.goldFromShot5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 27
            if (upgradeNumber == 27)
            {
                locScript.ChangeGoldFromShooting(Prestige.goldFromShot6);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 28
            if (upgradeNumber == 28)
            {
                locScript.ChangeGoldFromShooting(Prestige.goldFromShot7);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.goldFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.prestigePointFromShooting;
            }
            #endregion

            //More prestige points from shooting
            #region Upgrade 18
            if (upgradeNumber == 18)
            {
                locScript.ChangeShotsPrestigePoints(Prestige.shotPrestigePointIncrease1);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.morePrestigePointFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 19
            if (upgradeNumber == 19)
            {
                locScript.ChangeShotsPrestigePoints(Prestige.shotPrestigePointIncrease2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.morePrestigePointFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 20
            if (upgradeNumber == 20)
            {
                locScript.ChangeShotsPrestigePoints(Prestige.shotPrestigePointIncrease3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.morePrestigePointFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 21
            if (upgradeNumber == 21)
            {
                locScript.ChangeShotsPrestigePoints(Prestige.shotPrestigePointIncrease4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.morePrestigePointFromShooting;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

        }
        #endregion

        #region All new levels upgrades
        else if (isNewLevelUpgrade == true)
        {
            isNewLevelUpgradeMobile = isNewLevelUpgrade;
            #region Upgrade 1 
            if (upgradeNumber == 2)
            {
                locScript.LevelUnlocked(2);
                locScript.LevelPegsAndBoards(2, Prestige.level2Boards, Prestige.level2MinPegs, Prestige.level2MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucket1MidString;
            }
            #endregion

            #region Upgrade 2 
            if (upgradeNumber == 3)
            {
                locScript.LevelUnlocked(3);
                locScript.LevelPegsAndBoards(3, Prestige.level3Boards, Prestige.level3MinPegs, Prestige.level3MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketsLevel3;
            }
            #endregion

            #region Upgrade 3 
            if (upgradeNumber == 4)
            {
                locScript.LevelUnlocked(4);
                locScript.LevelPegsAndBoards(4, Prestige.level4Boards, Prestige.level4MinPegs, Prestige.level4MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketsLevel4;
            }
            #endregion

            #region Upgrade 4 
            if (upgradeNumber == 5)
            {
                locScript.LevelUnlocked(5);
                locScript.LevelPegsAndBoards(5, Prestige.level5Boards, Prestige.level5MinPegs, Prestige.level5MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketsLevel5;
            }
            #endregion

            #region Upgrade 5 
            if (upgradeNumber == 6)
            {
                locScript.LevelUnlocked(6);
                locScript.LevelPegsAndBoards(6, Prestige.level6Boards, Prestige.level6MinPegs, Prestige.level6MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketsLevel6;
            }
            #endregion

            #region Upgrade 6 
            if (upgradeNumber == 7)
            {
                locScript.LevelUnlocked(7);
                locScript.LevelPegsAndBoards(7, Prestige.level7Boards, Prestige.level7MinPegs, Prestige.level7MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketsLevel7;
            }
            #endregion

            #region Upgrade 7 
            if (upgradeNumber == 8)
            {
                locScript.LevelUnlocked(8);
                locScript.LevelPegsAndBoards(8, Prestige.level8Boards, Prestige.level8MinPegs, Prestige.level8MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketsLevel8;
            }
            #endregion

            #region Upgrade 8
            if (upgradeNumber == 9)
            {
                locScript.LevelUnlocked(9);
                locScript.LevelPegsAndBoards(9, Prestige.level9Boards, Prestige.level9MinPegs, Prestige.level9MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketsLevel9;
            }
            #endregion

            #region Upgrade 9
            if (upgradeNumber == 10)
            {
                locScript.LevelUnlocked(10);
                locScript.LevelPegsAndBoards(10, Prestige.level10Boards, Prestige.level10MinPegs, Prestige.level10MaxPegs);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelUnlockedString;
                text2.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.levelBoardsAndPegsString;
                text3.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.bucketsLevel10;
            }
            #endregion

        }
        #endregion

        #region All more shots upgrades
        else if (isMoreShotsUpgrade == true)
        {
            isMoreShotsUpgradeMobile = isMoreShotsUpgrade;

            #region Upgrade 1 
            if (upgradeNumber == 1)
            {
                locScript.ChangeMoreShots(2);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.moreShots;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 2 
            if (upgradeNumber == 2)
            {
                locScript.ChangeMoreShots(3);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.moreShots;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 3 
            if (upgradeNumber == 3)
            {
                locScript.ChangeMoreShots(4);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.moreShots;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion

            #region Upgrade 4 
            if (upgradeNumber == 4)
            {
                locScript.ChangeMoreShots(5);
                text1.GetComponent<TextMeshProUGUI>().text = LocalizationStrings.moreShots;
                text2.GetComponent<TextMeshProUGUI>().text = "";
            }
            #endregion
        }
        #endregion

        if (isNewLevelUpgrade == false) { text3.GetComponent<TextMeshProUGUI>().text = ""; }

        SetHighNumbers.FormatCoinsGoldShort(prestigePrice);

        priceText.GetComponent<TextMeshProUGUI>().text = SetHighNumbers.FormatCoinsGoldShort(prestigePrice);
        if (prestigePrice > Prestige.prestigePoints) 
        { 
            priceText.GetComponent<TextMeshProUGUI>().color = Color.red; 
            if(MobileScript.isMobile == true) { prestigePurchase.GetComponent<Button>().interactable = false;  }
        }
        if (prestigePrice <= Prestige.prestigePoints) 
        { 
            priceText.GetComponent<TextMeshProUGUI>().color = Color.green;
            if (MobileScript.isMobile == true) { prestigePurchase.GetComponent<Button>().interactable = true; }
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if (MobileScript.isMobile == false)
        {
            prestigeToolTip.SetActive(false);
            presiteCircle.SetActive(false);
        }

        isHoveringPrestige = false;
    }
}
