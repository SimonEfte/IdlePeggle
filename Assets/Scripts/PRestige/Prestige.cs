using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Prestige : MonoBehaviour, IDataPersistence
{
    public static int prestigePoints;
    public static float prestigePointsOverFlow;
    public TextMeshProUGUI totalPrestigePointsText, prestigePointsPrestigeFrame, prestiPointsInPrestigeScreen;
    public GameObject PrestigeScreen;
    public static bool isOnlyViewing;
    public static bool isInPrestigeScreen, isPrestiged;
    public GameObject prestigeScreenContent, prestigeScreenZoom;
    public GameObject prestigeTab, ball1Tab, ballAllFramesTab, ballEquippedFrame;
    public GameObject levelSelectScreen;

    public Button level1Frame, level2Frame, level3Frame, level4Frame, level5Frame, level6Frame, level7Frame, level8Frame, level9Frame, level10Frame;
    public GameObject level2Locked, level3Locked, level4Locked, level5Locked, level6Locked, level7Locked, level8Locked, level9Locked, level10Locked;
    public GameObject level2UnlockedFrame, level3UnlockedFrame, level4UnlockedFrame, level5UnlockedFrame, level6UnlockedFrame, level7UnlockedFrame, level8UnlockedFrame, level9UnlockedFrame, level10UnlockedFrame;
    public GameObject levelSelect;

    public GameObject[] levels;

    public TextMeshProUGUI levelSelectText;

    public GameObject onlyViweingBar;

    public AudioManager audioManager;

    public float alpha1, alpha2, alpha3;
    public BallUpgrades ballUpgradeScript;

    public void Awake()
    {
        alpha1 = 0.2f;
        alpha2 = 0.3f;
        alpha3 = 0.62f;

        SetStatIncreases();
    }
    public void Start()
    {
        StartCoroutine(SetStatsIncreases());
    }

    public static bool isLoaded;
    IEnumerator SetStatsIncreases()
    {
        yield return new WaitForSeconds(0.1f);
        isLoaded = true;

        if(goldenPegChance > 72) { goldenPegChance = 72; }

        //GameObject[] demoLocked = GameObject.FindGameObjectsWithTag("DemoLocked");
        //foreach (GameObject demo in demoLocked)
        //{
        //   if(GameData.isDemo == false) { demo.SetActive(false); }
        //   if (GameData.isDemo == true) { demo.SetActive(true); }
        //}

        SetBuckets();

        LoadAllPrestigeUpgrades();

        if(prestigePoints < 0)
        {
            prestigePoints *= -1;
        }

        if(AllStats.totalPRestigePoints < 0)
        {
            AllStats.totalPRestigePoints *= -1;
        }
    }

    public bool firstTimeOpen;
    public Achievements achScript;

    #region Load All Prestige Upgrades
    public void LoadAllPrestigeUpgrades()
    {
        if(purchasedFirstUpgrade == true) { FirstPrestigeUpgrade(false); }
        else { firstUpgradeButton.interactable = true; }

        #region Levels
        if (purchasedLevel2 == true) { SetNewLevel(2); }
        if(GameData.isDemo == false)
        {
            if (purchasedLevel3 == true) { SetNewLevel(3); }
            if (purchasedLevel4 == true) { SetNewLevel(4); }
            if (purchasedLevel5 == true) { SetNewLevel(5); }
            if (purchasedLevel6 == true) { SetNewLevel(6); }
            if (purchasedLevel7 == true) { SetNewLevel(7); }
            if (purchasedLevel8 == true) { SetNewLevel(8); }
            if (purchasedLevel9 == true) { SetNewLevel(9); }
            if (purchasedLevel10 == true) { SetNewLevel(10); }
        }
        #endregion

        #region New pegs
        if (NP_Upgrade1Purchased == true) { SetNewPegs(1); }
        if (NP_Upgrade2Purchased == true) { SetNewPegs(2); }
        if (NP_Upgrade3Purchased == true) { SetNewPegs(3); }
        if (NP_Upgrade4Purchased == true) { SetNewPegs(4); }
        if (NP_Upgrade5Purchased == true) { SetNewPegs(5); }
        if (NP_Upgrade6Purchased == true) { SetNewPegs(6); }
        if (NP_Upgrade7Purchased == true) { SetNewPegs(7); }
        if (NP_Upgrade8Purchased == true) { SetNewPegs(8); }
        if (NP_Upgrade9Purchased == true) { SetNewPegs(9); }
        if (NP_Upgrade10Purchased == true) { SetNewPegs(10); }
        if (NP_Upgrade11Purchased == true) { SetNewPegs(11); }
        if (NP_Upgrade12Purchased == true) { SetNewPegs(12); }
        if (NP_Upgrade13Purchased == true) { SetNewPegs(13); }
        if (NP_Upgrade14Purchased == true) { SetNewPegs(14); }
        if (NP_Upgrade15Purchased == true) { SetNewPegs(15); }
        if (NP_Upgrade16Purchased == true) { SetNewPegs(16); }
        if (NP_Upgrade17Purchased == true) { SetNewPegs(17); }
        if (NP_Upgrade18Purchased == true) { SetNewPegs(18); }
        if (NP_Upgrade19Purchased == true) { SetNewPegs(19); }
        if (NP_Upgrade20Purchased == true) { SetNewPegs(20); }
        if (NP_Upgrade21Purchased == true) { SetNewPegs(21); }
        if (NP_Upgrade22Purchased == true) { SetNewPegs(22); }
        if (NP_Upgrade23Purchased == true) { SetNewPegs(23); }
        if (NP_Upgrade24Purchased == true) { SetNewPegs(24); }
        if (NP_Upgrade25Purchased == true) { SetNewPegs(25); }
        if (NP_Upgrade26Purchased == true) { SetNewPegs(26); }
        if (NP_Upgrade27Purchased == true) { SetNewPegs(27); }
        if (NP_Upgrade28Purchased == true) { SetNewPegs(28); }
        if (NP_Upgrade29Purchased == true) { SetNewPegs(29); }
        if (NP_Upgrade30Purchased == true) { SetNewPegs(30); }
        if (NP_Upgrade31Purchased == true) { SetNewPegs(31); }
        if (NP_Upgrade32Purchased == true) { SetNewPegs(32); }
        if (NP_Upgrade33Purchased == true) { SetNewPegs(33); }
        if (NP_Upgrade34Purchased == true) { SetNewPegs(34); }
        if (NP_Upgrade35Purchased == true) { SetNewPegs(35); }
        #endregion

        #region Gold
        if (G_Upgrade1Purchased == true) { SetGold(1); }
        if (G_Upgrade2Purchased == true) { SetGold(2); }
        if (G_Upgrade3Purchased == true) { SetGold(3); }
        if (G_Upgrade4Purchased == true) { SetGold(4); }
        if (G_Upgrade5Purchased == true) { SetGold(5); }
        if (G_Upgrade6Purchased == true) { SetGold(6); }
        if (G_Upgrade7Purchased == true) { SetGold(7); }
        if (G_Upgrade8Purchased == true) { SetGold(8); }
        if (G_Upgrade9Purchased == true) { SetGold(9); }
        if (G_Upgrade10Purchased == true) { SetGold(10); }
        if (G_Upgrade11Purchased == true) { SetGold(11); }
        if (G_Upgrade12Purchased == true) { SetGold(12); }
        if (G_Upgrade13Purchased == true) { SetGold(13); }
        if (G_Upgrade14Purchased == true) { SetGold(14); }
        if (G_Upgrade15Purchased == true) { SetGold(15); }
        if (G_Upgrade16Purchased == true) { SetGold(16); }
        if (G_Upgrade17Purchased == true) { SetGold(17); }
        if (G_Upgrade18Purchased == true) { SetGold(18); }
        if (G_Upgrade19Purchased == true) { SetGold(19); }
        if (G_Upgrade20Purchased == true) { SetGold(20); }
        if (G_Upgrade21Purchased == true) { SetGold(21); }
        if (G_Upgrade22Purchased == true) { SetGold(22); }
        if (G_Upgrade23Purchased == true) { SetGold(23); }
        if (G_Upgrade24Purchased == true) { SetGold(24); }
        if (G_Upgrade25Purchased == true) { SetGold(25); }
        if (G_Upgrade26Purchased == true) { SetGold(26); }
        if (G_Upgrade27Purchased == true) { SetGold(27); }
        if (G_Upgrade28Purchased == true) { SetGold(28); }
        if (G_Upgrade29Purchased == true) { SetGold(29); }
        if (G_Upgrade30Purchased == true) { SetGold(30); }
        if (G_Upgrade31Purchased == true) { SetGold(31); }
        if (G_Upgrade32Purchased == true) { SetGold(32); }
        if (G_Upgrade33Purchased == true) { SetGold(33); }
        if (G_Upgrade34Purchased == true) { SetGold(34); }
        if (G_Upgrade35Purchased == true) { SetGold(35); }
        if (G_Upgrade36Purchased == true) { SetGold(36); }
        if (G_Upgrade37Purchased == true) { SetGold(37); }
        if (G_Upgrade38Purchased == true) { SetGold(38); }
        if (G_Upgrade39Purchased == true) { SetGold(39); }
        if (G_Upgrade40Purchased == true) { SetGold(40); }
        if (G_Upgrade41Purchased == true) { SetGold(41); }
        if (G_Upgrade42Purchased == true) { SetGold(42); }
        if (G_Upgrade43Purchased == true) { SetGold(43); }
        if (G_Upgrade44Purchased == true) { SetGold(44); }
        if (G_Upgrade45Purchased == true) { SetGold(45); }
        if (G_Upgrade46Purchased == true) { SetGold(46); }
        if (G_Upgrade47Purchased == true) { SetGold(47); }
        if (G_Upgrade48Purchased == true) { SetGold(48); }
        if (G_Upgrade49Purchased == true) { SetGold(49); }
        if (G_Upgrade50Purchased == true) { SetGold(50); }
        if (G_Upgrade51Purchased == true) { SetGold(51); }
        #endregion

        #region Prestige peg
        if (PU_Upgrade1Purchased == true) { SetPresitgeUpgrade(1); }
        if (PU_Upgrade2Purchased == true) { SetPresitgeUpgrade(2); }
        if (PU_Upgrade3Purchased == true) { SetPresitgeUpgrade(3); }
        if (PU_Upgrade4Purchased == true) { SetPresitgeUpgrade(4); }
        if (PU_Upgrade5Purchased == true) { SetPresitgeUpgrade(5); }
        if (PU_Upgrade6Purchased == true) { SetPresitgeUpgrade(6); }
        if (PU_Upgrade7Purchased == true) { SetPresitgeUpgrade(7); }
        if (PU_Upgrade8Purchased == true) { SetPresitgeUpgrade(8); }
        if (PU_Upgrade9Purchased == true) { SetPresitgeUpgrade(9); }
        if (PU_Upgrade10Purchased == true) { SetPresitgeUpgrade(10); }
        if (PU_Upgrade11Purchased == true) { SetPresitgeUpgrade(11); }
        if (PU_Upgrade12Purchased == true) { SetPresitgeUpgrade(12); }
        if (PU_Upgrade13Purchased == true) { SetPresitgeUpgrade(13); }
        if (PU_Upgrade14Purchased == true) { SetPresitgeUpgrade(14); }
        if (PU_Upgrade15Purchased == true) { SetPresitgeUpgrade(15); }
        if (PU_Upgrade16Purchased == true) { SetPresitgeUpgrade(16); }
        if (PU_Upgrade17Purchased == true) { SetPresitgeUpgrade(17); }
        if (PU_Upgrade18Purchased == true) { SetPresitgeUpgrade(18); }
        if (PU_Upgrade19Purchased == true) { SetPresitgeUpgrade(19); }
        if (PU_Upgrade20Purchased == true) { SetPresitgeUpgrade(20); }
        if (PU_Upgrade21Purchased == true) { SetPresitgeUpgrade(21); }
        if (PU_Upgrade22Purchased == true) { SetPresitgeUpgrade(22); }
        if (PU_Upgrade23Purchased == true) { SetPresitgeUpgrade(23); }
        if (PU_Upgrade24Purchased == true) { SetPresitgeUpgrade(24); }
        if (PU_Upgrade25Purchased == true) { SetPresitgeUpgrade(25); }
        if (PU_Upgrade26Purchased == true) { SetPresitgeUpgrade(26); }
        if (PU_Upgrade27Purchased == true) { SetPresitgeUpgrade(27); }
        if (PU_Upgrade28Purchased == true) { SetPresitgeUpgrade(28); }
        if (PU_Upgrade29Purchased == true) { SetPresitgeUpgrade(29); }
        if (PU_Upgrade30Purchased == true) { SetPresitgeUpgrade(30); }
        if (PU_Upgrade31Purchased == true) { SetPresitgeUpgrade(31); }
        if (PU_Upgrade32Purchased == true) { SetPresitgeUpgrade(32); }
        if (PU_Upgrade33Purchased == true) { SetPresitgeUpgrade(33); }
        if (PU_Upgrade34Purchased == true) { SetPresitgeUpgrade(34); }
        if (PU_Upgrade35Purchased == true) { SetPresitgeUpgrade(35); }
        if (PU_Upgrade36Purchased == true) { SetPresitgeUpgrade(36); }
        if (PU_Upgrade37Purchased == true) { SetPresitgeUpgrade(37); }
        if (PU_Upgrade38Purchased == true) { SetPresitgeUpgrade(38); }
        if (PU_Upgrade39Purchased == true) { SetPresitgeUpgrade(39); }
        if (PU_Upgrade40Purchased == true) { SetPresitgeUpgrade(40); }
        if (PU_Upgrade41Purchased == true) { SetPresitgeUpgrade(41); }
        if (PU_Upgrade42Purchased == true) { SetPresitgeUpgrade(42); }
        if (PU_Upgrade43Purchased == true) { SetPresitgeUpgrade(43); }
        if (PU_Upgrade44Purchased == true) { SetPresitgeUpgrade(44); }
        #endregion

        #region Active
        if (A_Upgrade1Purchased == true) { SetActiveUpgrades(1); }
        if (A_Upgrade2Purchased == true) { SetActiveUpgrades(2); }
        if (A_Upgrade3Purchased == true) { SetActiveUpgrades(3); }
        if (A_Upgrade4Purchased == true) { SetActiveUpgrades(4); }
        if (A_Upgrade5Purchased == true) { SetActiveUpgrades(5); }
        if (A_Upgrade6Purchased == true) { SetActiveUpgrades(6); }
        if (A_Upgrade7Purchased == true) { SetActiveUpgrades(7); }
        if (A_Upgrade8Purchased == true) { SetActiveUpgrades(8); }
        if (A_Upgrade9Purchased == true) { SetActiveUpgrades(9); }
        if (A_Upgrade10Purchased == true) { SetActiveUpgrades(10); }
        if (A_Upgrade11Purchased == true) { SetActiveUpgrades(11); }
        if (A_Upgrade12Purchased == true) { SetActiveUpgrades(12); }
        if (A_Upgrade13Purchased == true) { SetActiveUpgrades(13); }
        if (A_Upgrade14Purchased == true) { SetActiveUpgrades(14); }
        if (A_Upgrade15Purchased == true) { SetActiveUpgrades(15); }
        if (A_Upgrade16Purchased == true) { SetActiveUpgrades(16); }
        if (A_Upgrade17Purchased == true) { SetActiveUpgrades(17); }
        if (A_Upgrade18Purchased == true) { SetActiveUpgrades(18); }
        if (A_Upgrade19Purchased == true) { SetActiveUpgrades(19); }
        if (A_Upgrade20Purchased == true) { SetActiveUpgrades(20); }
        if (A_Upgrade21Purchased == true) { SetActiveUpgrades(21); }
        if (A_Upgrade22Purchased == true) { SetActiveUpgrades(22); }
        if (A_Upgrade23Purchased == true) { SetActiveUpgrades(23); }
        if (A_Upgrade24Purchased == true) { SetActiveUpgrades(24); }
        if (A_Upgrade25Purchased == true) { SetActiveUpgrades(25); }
        if (A_Upgrade26Purchased == true) { SetActiveUpgrades(26); }
        if (A_Upgrade27Purchased == true) { SetActiveUpgrades(27); }
        if (A_Upgrade28Purchased == true) { SetActiveUpgrades(28); }
        if (A_Upgrade29Purchased == true) { SetActiveUpgrades(29); }
        if (A_Upgrade30Purchased == true) { SetActiveUpgrades(30); }
        if (A_Upgrade31Purchased == true) { SetActiveUpgrades(31); }
        if (A_Upgrade32Purchased == true) { SetActiveUpgrades(32); }
        if (A_Upgrade33Purchased == true) { SetActiveUpgrades(33); }
        #endregion

        if(moreShots1Purchased == true) { SetMoreShots(1); }
        if (moreShots2Purchased == true) { SetMoreShots(2); }
        if (moreShots3Purchased == true) { SetMoreShots(3); }
        if (moreShots4Purchased == true) { SetMoreShots(4); }

        //try and use a for loop for all locks, buttons and image alphas.
        //and then use a if statement for each upgrade purchased that will set the next upgrade's aviable.
    }
    #endregion


    #region Gold stat increases
    public static float goldenPegChanceIncrease1, goldenPegChanceIncrease2, goldenPegChanceIncrease3, goldenPegChanceIncrease4, goldenPegChanceIncrease5, goldenPegChanceIncrease6, goldenPegChanceIncrease7, goldenPegChanceIncrease8, goldenPegChanceIncrease9, goldenPegChanceIncrease10, goldenPegChanceIncrease11;
    public static float goldIncrease1, goldIncrease2, goldIncrease3, goldIncrease4, goldIncrease5, goldIncrease6, goldIncrease7, goldIncrease8, goldIncrease9, goldIncrease10, goldIncrease11, goldIncrease12, goldIncrease13, goldIncrease14, goldIncrease15, goldIncrease16;
    public static float clearBonus1, clearBonus2, clearBonus3, clearBonus4, clearBonus5, clearBonus6, clearBonus7, goldClearBonusFromBucket;
    public static float goldRushChance;
    public static int goldClearTimerSeconds, goldRushIncrease, goldRushTimer;
    public static float goldClearTimer1, goldClearTimer2, goldClearTimer3, goldClearTimer4, goldClearTimer5, goldClearTimer6, goldClearTimer7;
    public static float X2goldChance, X3goldChance, X5goldChance, X10goldChance;
    public static float X2bucketGoldChance, X3bucketGoldChance, X5bucketGoldChance, X8bucketGoldChance, X10bucketGoldChance;
    #endregion

    #region Prestige stat increases
    public static float prestigePegChanceIncrease1, prestigePegChanceIncrease2, prestigePegChanceIncrease3, prestigePegChanceIncrease4, prestigePegChanceIncrease5, prestigePegChanceIncrease6, prestigePegChanceIncrease7, prestigePegChanceIncrease8, prestigePegChanceIncrease9, prestigePegChanceIncrease10, prestigePegChanceIncrease11, prestigePegChanceIncrease12, prestigePegChanceIncrease13, prestigePegChanceIncrease14, prestigePegChanceIncrease15, prestigePegChanceIncrease16, prestigePegChanceIncrease17, prestigePegChanceIncrease18, prestigePegChanceIncrease19, prestigePegChanceIncrease20, prestigePegChanceIncrease21, prestigePegChanceIncrease22;

    public static float newPrestigeIncrease1, newPrestigeIncrease2, newPrestigeIncrease3, newPrestigeIncrease4;

    public static int prestigeClearBonus1, prestigeClearBonus2, prestigeClearBonus3, prestigeClearBonus4, prestigeClearBonus5;
    public static float bucketPrestigePointChance1, bucketPrestigePointChance2, bucketPrestigePointChance3, bucketPrestigePointChance4;
    public static float prestigeRushChance, X2prestigePointChance, X3prestigePointChance, X5prestigePointChance, X10prestigePointChance;
    public static int prestigeRushIncrease, prestigeRushTimer;
    #endregion

    #region Shot balls stat increases
    public static float ballShotGoldIncrease1, ballShotGoldIncrease2, ballShotGoldIncrease3, ballShotGoldIncrease4, ballShotGoldIncrease5, ballShotGoldIncrease6, ballShotGoldIncrease7, ballShotGoldIncrease8, ballShotGoldIncrease9, ballShotGoldIncrease10, ballShotGoldIncrease11, ballShotGoldIncrease12, ballShotGoldIncrease13, ballShotGoldIncrease14, ballShotGoldIncrease15;
    public static double goldStart1, goldStart2, goldStart3, goldStart4, goldStart5, goldStart6, goldStart7, goldStart8;
    public static float goldFromShot1, goldFromShot2, goldFromShot3, goldFromShot4, goldFromShot5, goldFromShot6, goldFromShot7;
    public static float prestigePointFromShotChance;
    public static int shotPrestigePointIncrease1, shotPrestigePointIncrease2, shotPrestigePointIncrease3, shotPrestigePointIncrease4;
    #endregion

    #region New pegs stat increases
    public static float redPegChance1, redPegChance2, redPegChance3, redPegChance4, redPegChance5;
    public static float rainbowPegChance1, rainbowPegChance2, rainbowPegChance3, rainbowPegChance4, rainbowPegChance5, rainbowPegChance6, rainbowPegChance7;
    public static float bombPegChance1, bombPegChance2, bombPegChance3, bombPegChance4, bombPegChance5, bombPegChance6, bombPegChance7;
    public static float purplePegChance1, purplePegChance2, purplePegChance3, purplePegChance4;
    public static float purplePegEnchanceIncrease1, purplePegEnchanceIncrease2, purplePegEnchanceIncrease3, purplePegEnchanceIncrease4;
    public static int rainbowPegTimer;
    public static int rainbowPegPrestigePointChance;
    public static int rainbowPegIncrease;
    #endregion

    #region New levels stat increases

    public static int level1Boards, level2Boards, level3Boards, level4Boards, level5Boards, level6Boards, level7Boards, level8Boards, level9Boards, level10Boards;
    public static int level1MinPegs, level2MinPegs, level3MinPegs, level4MinPegs, level5MinPegs, level6MinPegs, level7MinPegs, level8MinPegs, level9MinPegs, level10MinPegs;
    public static int level1MaxPegs, level2MaxPegs, level3MaxPegs, level4MaxPegs, level5MaxPegs, level6MaxPegs, level7MaxPegs, level8MaxPegs, level9MaxPegs, level10MaxPegs;

    #endregion

    public void SetStatIncreases()
    {
        //Gold peg chance starts at 9%
        //Prestige peg chance start at 1%
        //Everything else at 0%

        //Gold peg max chance = 72
        //Prestige peg max chance = 16
        //4 other pegs = 12

        #region All gold stats increases
        goldRushChance = 0.05f;
        goldRushIncrease = 3;
        goldClearTimerSeconds = 20;
        goldRushTimer = 12;

        goldenPegChanceIncrease1 = 1;
        goldenPegChanceIncrease2 = 2;
        goldenPegChanceIncrease3 = 2;
        goldenPegChanceIncrease4 = 4;
        goldenPegChanceIncrease5 = 4;
        goldenPegChanceIncrease6 = 6;
        goldenPegChanceIncrease7 = 6;
        goldenPegChanceIncrease8 = 8;
        goldenPegChanceIncrease9 = 8;
        goldenPegChanceIncrease10 = 10;
        goldenPegChanceIncrease11 = 11;

        goldIncrease1 = 0.1f;
        goldIncrease2 = 0.25f;
        goldIncrease3 = 0.75f;
        goldIncrease4 = 1.6f;
        goldIncrease5 = 3.5f;
        goldIncrease6 = 5.5f;
        goldIncrease7 = 7f;
        goldIncrease8 = 8f;
        goldIncrease9 = 11f;
        goldIncrease10 = 12f;
        goldIncrease11 = 28f;
        goldIncrease12 = 31f;
        goldIncrease13 = 80f;
        goldIncrease14 = 88f;
        goldIncrease15 = 185f;
        goldIncrease16 = 220f;

        clearBonus1 = 0.005f;
        clearBonus2 = 0.01f;
        clearBonus3 = 0.015f;
        clearBonus4 = 0.025f;
        clearBonus5 = 0.03f;
        clearBonus6 = 0.07f;
        clearBonus7 = 0.12f;
        goldClearBonusFromBucket = 0.05f;

        goldClearTimer1 = 0.04f;
        goldClearTimer2 = 0.08f;
        goldClearTimer3 = 0.12f;
        goldClearTimer4 = 0.16f;
        goldClearTimer5 = 0.2f;
        goldClearTimer6 = 0.25f;
        goldClearTimer7 = 0.35f;

        X2goldChance = 3f;
        X3goldChance = 2f;
        X5goldChance = 1f;
        X10goldChance = 0.75f;

        X2bucketGoldChance = 3f;
        X3bucketGoldChance = 2f;
        X5bucketGoldChance = 1f;
        X8bucketGoldChance = 0.7f;
        X10bucketGoldChance = 0.5f;
        #endregion

        #region All prestige stat increases
        prestigeRushChance = 0.15f;
        prestigeRushTimer = 12;

        prestigePegChanceIncrease1 = 0.1f;
        prestigePegChanceIncrease2 = 0.1f;
        prestigePegChanceIncrease3 = 0.1f;
        prestigePegChanceIncrease4 = 0.15f;
        prestigePegChanceIncrease5 = 0.15f;
        prestigePegChanceIncrease6 = 0.25f;
        prestigePegChanceIncrease7 = 0.25f;
        prestigePegChanceIncrease8 = 0.35f;
        prestigePegChanceIncrease9 = 0.35f;
        prestigePegChanceIncrease10 = 0.45f;
        prestigePegChanceIncrease11 = 0.45f;
        newPrestigeIncrease1 = 0.4f;
        prestigePegChanceIncrease12 = 0.55f;
        prestigePegChanceIncrease13 = 0.6f;
        prestigePegChanceIncrease14 = 0.85f;
        prestigePegChanceIncrease15 = 0.85f;
        prestigePegChanceIncrease16 = 0.85f;
        newPrestigeIncrease2 = 0.9f;
        newPrestigeIncrease3 = 0.9f;
        newPrestigeIncrease4 = 0.9f;
        prestigePegChanceIncrease17 = 1f;
        prestigePegChanceIncrease18 = 1f;
        prestigePegChanceIncrease19 = 1f;
        prestigePegChanceIncrease20 = 1.5f;
        prestigePegChanceIncrease21 = 1.5f;
        prestigePegChanceIncrease22 = 1.5f;

        prestigeClearBonus1 = 6;
        prestigeClearBonus2 = 4;
        prestigeClearBonus3 = 2;
        prestigeClearBonus4 = 1;
        prestigeClearBonus5 = 1;

        bucketPrestigePointChance1 = 0.6f;
        bucketPrestigePointChance2 = 1.2f;
        bucketPrestigePointChance3 = 2.8f;
        bucketPrestigePointChance4 = 6.5f;

        X2prestigePointChance = 5;
        X3prestigePointChance = 4;
        X5prestigePointChance = 3;
        X10prestigePointChance = 2f;

        prestigeRushIncrease = 3;
        #endregion

        #region All active shots stat increases
        ballShotGoldIncrease1 = 0.1f;
        ballShotGoldIncrease2 = 0.25f;
        ballShotGoldIncrease3 = 0.7f;
        ballShotGoldIncrease4 = 1.5f;
        ballShotGoldIncrease5 = 2f;
        ballShotGoldIncrease6 = 3.5f;
        ballShotGoldIncrease7 = 6f;
        ballShotGoldIncrease8 = 67f;
        ballShotGoldIncrease9 = 2f;
        ballShotGoldIncrease10 = 3.5f;
        ballShotGoldIncrease11 = 6f;
        ballShotGoldIncrease12 = 15f;
        ballShotGoldIncrease13 = 25f;
        ballShotGoldIncrease14 = 30f;
        ballShotGoldIncrease15 = 78f;

        goldStart1 = 100;
        goldStart2 = 500;
        goldStart3 = 2000;
        goldStart4 = 7500;
        goldStart5 = 25000;
        goldStart6 = 100000;
        goldStart7 = 500000;
        goldStart8 = 1000000;

        goldFromShot1 = 0.01f;
        goldFromShot2 = 0.03f;
        goldFromShot3 = 0.04f;
        goldFromShot4 = 0.06f;
        goldFromShot5 = 0.07f;
        goldFromShot6 = 0.11f;
        goldFromShot7 = 0.2f;
        prestigePointFromShotChance = 25f;

        shotPrestigePointIncrease1 = 1;
        shotPrestigePointIncrease2 = 2;
        shotPrestigePointIncrease3 = 3;
        shotPrestigePointIncrease4 = 5;
        #endregion

        #region All new pegs stat increases
        rainbowPegTimer = 5;
        rainbowPegPrestigePointChance = 7;

        redPegChance1 = 0.2f;
        redPegChance2 = 0.3f;
        redPegChance3 = 0.2f;
        redPegChance4 = 0.6f;
        redPegChance5 = 0.6f;
        //2.6%

        rainbowPegChance1 = 0.1f;
        rainbowPegChance2 = 0.2f;
        rainbowPegChance3 = 0.2f;
        rainbowPegChance4 = 0.3f;
        rainbowPegChance5 = 0.3f;
        rainbowPegChance6 = 0.6f;
        rainbowPegChance7 = 0.6f;
        //2.5%

        bombPegChance1 = 0.2f;
        bombPegChance2 = 0.35f;
        bombPegChance3 = 0.35f;
        bombPegChance4 = 0.6f;
        bombPegChance5 = 0.6f;
        bombPegChance6 = 0.7f;
        bombPegChance7 = 0.7f;
        //3.55%

        purplePegChance1 = 0.2f;
        purplePegChance2 = 0.4f;
        purplePegChance3 = 0.7f;
        purplePegChance4 = 0.8f;
        //3.35%

        purplePegEnchanceIncrease1 = 2;
        purplePegEnchanceIncrease2 = 2.25f;
        purplePegEnchanceIncrease3 = 2.5f;
        purplePegEnchanceIncrease4 = 3;
        #endregion

        #region All new levels stat increase
        level1Boards = 15; level1MinPegs = 76; level1MaxPegs = 125;
        level2Boards = 15; level2MinPegs = 120; level2MaxPegs = 160;
        level3Boards = 16; level3MinPegs = 158; level3MaxPegs = 184;
        level4Boards = 16; level4MinPegs = 176; level4MaxPegs = 200;
        level5Boards = 17; level5MinPegs = 197; level5MaxPegs = 224;
        level6Boards = 17; level6MinPegs = 218; level6MaxPegs = 240;
        level7Boards = 18; level7MinPegs = 240; level7MaxPegs = 264;
        level8Boards = 18; level8MinPegs = 264; level8MaxPegs = 282;
        level9Boards = 19; level9MinPegs = 280; level9MaxPegs = 308;
        level10Boards = 20; level10MinPegs = 306; level10MaxPegs = 351;
        #endregion
    }

    #region update
    public static bool reachedOver500;
    public static bool ppOverflow;

    public void Update()
    {
        if(GameData.isDemo == true)
        {
            if(prestigePoints > 500) 
            {
                prestigePoints = 500;
                //Debug.Log(prestigePoints);

                reachedOver500 = true;
            }
        }

        if(reachedOver500 == true)
        {
            prestigePoints = 500;
            //Debug.Log(prestigePoints);

            totalPrestigePointsText.text = SetHighNumbers.FormatCoinsGoldShort(prestigePoints) + LocalizationStrings.maxString;
        }
        else
        {
            if (prestigePoints < 1100000000)
            {
                totalPrestigePointsText.text = SetHighNumbers.FormatCoinsGoldShort(prestigePoints);
            }
        }

        if(prestigePoints > 1100000000)
        {
            //Debug.Log(prestigePointsOverFlow);

            ppOverflow = true;
            prestigePointsPrestigeFrame.text = SetHighNumbers.FormatCoinsGoldShort(prestigePoints + prestigePointsOverFlow);
            prestiPointsInPrestigeScreen.text = SetHighNumbers.FormatCoinsGoldShort(prestigePoints + prestigePointsOverFlow);
            totalPrestigePointsText.text = SetHighNumbers.FormatCoinsGoldShort(prestigePoints + prestigePointsOverFlow);
        }
        else
        {
            ppOverflow = false;
            prestigePointsPrestigeFrame.text = SetHighNumbers.FormatCoinsGoldShort(prestigePoints);
            prestiPointsInPrestigeScreen.text = SetHighNumbers.FormatCoinsGoldShort(prestigePoints);
        }
    }
    #endregion

    #region View Prestige Screen
    public static bool isInChooseLevelScreen;

    public GameObject canvasBackgrounds, canvasLevels, canvasAnimations, canvasBalls, canvasGame, canvasSetActive, canvasToolTip;

    public void OpenPrestigeScreen()
    {
        canvasToolTip.SetActive(false);
        canvasSetActive.SetActive(false);
        canvasBackgrounds.SetActive(false);

        ClickSound();

        isInPrestigeScreen = true;
        isOnlyViewing = true;
        PrestigeScreen.SetActive(true);
        isInChooseLevelScreen = false;
        onlyViweingBar.SetActive(true);

        if(MobileScript.isMobile == false) { SetAllButtonFalse(); }
        else { LoadAllPrestigeUpgrades(); }
    }
    #endregion

    #region Exit prestige screen
    public void ExitPrestigeScreenOnlyViewing()
    {
        ClickSound();

        if (isOnlyViewing == false)
        {
            levelSelectScreen.SetActive(true);

            if (purchasedLevel2 == true) { level2Locked.SetActive(false); level2Frame.interactable = true; level2UnlockedFrame.SetActive(true); }
            if (purchasedLevel2 == false) { level2Locked.SetActive(true); level2Frame.interactable = false; level2UnlockedFrame.SetActive(false); }

            if(GameData.isDemo == false)
            {
                if (purchasedLevel3 == true) { level3Locked.SetActive(false); level3Frame.interactable = true; level3UnlockedFrame.SetActive(true); }
                if (purchasedLevel3 == false) { level3Locked.SetActive(true); level3Frame.interactable = false; level3UnlockedFrame.SetActive(false); }

                if (purchasedLevel4 == true) { level4Locked.SetActive(false); level4Frame.interactable = true; level4UnlockedFrame.SetActive(true); }
                if (purchasedLevel4 == false) { level4Locked.SetActive(true); level4Frame.interactable = false; level4UnlockedFrame.SetActive(false); }

                if (purchasedLevel5 == true) { level5Locked.SetActive(false); level5Frame.interactable = true; level5UnlockedFrame.SetActive(true); }
                if (purchasedLevel5 == false) { level5Locked.SetActive(true); level5Frame.interactable = false; level5UnlockedFrame.SetActive(false); }

                if (purchasedLevel6 == true) { level6Locked.SetActive(false); level6Frame.interactable = true; level6UnlockedFrame.SetActive(true); }
                if (purchasedLevel6 == false) { level6Locked.SetActive(true); level6Frame.interactable = false; level6UnlockedFrame.SetActive(false); }

                if (purchasedLevel7 == true) { level7Locked.SetActive(false); level7Frame.interactable = true; level7UnlockedFrame.SetActive(true); }
                if (purchasedLevel7 == false) { level7Locked.SetActive(true); level7Frame.interactable = false; level7UnlockedFrame.SetActive(false); }

                if (purchasedLevel8 == true) { level8Locked.SetActive(false); level8Frame.interactable = true; level8UnlockedFrame.SetActive(true); }
                if (purchasedLevel8 == false) { level8Locked.SetActive(true); level8Frame.interactable = false; level8UnlockedFrame.SetActive(false); }

                if (purchasedLevel9 == true) { level9Locked.SetActive(false); level9Frame.interactable = true; level9UnlockedFrame.SetActive(true); }
                if (purchasedLevel9 == false) { level9Locked.SetActive(true); level9Frame.interactable = false; level9UnlockedFrame.SetActive(false); }

                if (purchasedLevel10 == true) { level10Locked.SetActive(false); level10Frame.interactable = true; level10UnlockedFrame.SetActive(true); }
                if (purchasedLevel10 == false) { level10Locked.SetActive(true); level10Frame.interactable = false; level10UnlockedFrame.SetActive(false); }
            }
           
            if (purchasedLevel2 == false) { levelSelect.transform.position = level1Frame.gameObject.transform.position; locScript.LevelSelected(1); levelSelected = 1; }
            if (purchasedLevel2 == true) { levelSelect.transform.position = level2Frame.gameObject.transform.position; locScript.LevelSelected(2); levelSelected = 2; }

            if(GameData.isDemo == false)
            {
                if (purchasedLevel3 == true) { levelSelect.transform.position = level3Frame.gameObject.transform.position; locScript.LevelSelected(3); levelSelected = 3; }
                if (purchasedLevel4 == true) { levelSelect.transform.position = level4Frame.gameObject.transform.position; locScript.LevelSelected(4); levelSelected = 4; }
                if (purchasedLevel5 == true) { levelSelect.transform.position = level5Frame.gameObject.transform.position; locScript.LevelSelected(5); levelSelected = 5; }
                if (purchasedLevel6 == true) { levelSelect.transform.position = level6Frame.gameObject.transform.position; locScript.LevelSelected(6); levelSelected = 6; }
                if (purchasedLevel7 == true) { levelSelect.transform.position = level7Frame.gameObject.transform.position; locScript.LevelSelected(7); levelSelected = 7; }
                if (purchasedLevel8 == true) { levelSelect.transform.position = level8Frame.gameObject.transform.position; locScript.LevelSelected(8); levelSelected = 8; }
                if (purchasedLevel9 == true) { levelSelect.transform.position = level9Frame.gameObject.transform.position; locScript.LevelSelected(9); levelSelected = 9; }
                if (purchasedLevel10 == true) { levelSelect.transform.position = level10Frame.gameObject.transform.position; locScript.LevelSelected(10); levelSelected = 10; }
            }

            levelSelectedText.text = LocalizationStrings.levelSelectedString;

            isInChooseLevelScreen = true;
        }

        if (isOnlyViewing == true)
        {
            canvasToolTip.SetActive(true);
            canvasSetActive.SetActive(true);
            canvasBackgrounds.SetActive(true);

            isInPrestigeScreen = false;
            PrestigeScreen.SetActive(false);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        isOnlyViewing = false;
    }

    public Button exitPrestigeScreenYesButton;

    public void ExitPrestigeScreenLevelSelect(bool exit)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        ClickSound();
        if (exit == true)
        {
            StartCoroutine(PegscendTransitionClose()); isInChooseLevelScreen = false;
            exitPrestigeScreenYesButton.interactable = false;
        }
        else { levelSelectScreen.SetActive(false); isInChooseLevelScreen = false; }
    }

    public TabsAndFrames tabsScript;
    public GameObject shooter1, shooters2, shooters3, shooters4, shooters5;
    public TextMeshProUGUI goldText;

    IEnumerator PegscendTransitionClose()
    {
        BallUpgrades.isInBallScreen1 = true;
        BallUpgrades.isInBallScreen2 = false;
        BallUpgrades.isInBallScreen3 = false;
        BallUpgrades.points = startWithGold;
        mainShooterScript.SetBallPoints();
        SetBuckets();

        canvasBalls.SetActive(true);

        isPrestiged = false;
        isInPrestigeScreen = false;
        audioManager.Play("PrestigeTran");
        prestigeButton.interactable = true;
        transitionAnim.SetTrigger("Reveal");
        yield return new WaitForSeconds(1.1f);
        levelSelectScreen.SetActive(false);
        PrestigeScreen.SetActive(false);
        transitionAnim.SetTrigger("Hide");
        MainShooter.totalPegs = 0;
        MainShooter.totalPegsHit = 0;

        canvasToolTip.SetActive(true);
        canvasSetActive.SetActive(true);
        canvasBackgrounds.SetActive(true);
        canvasLevels.SetActive(true);
        canvasAnimations.SetActive(true);
        canvasGame.SetActive(true);

        levelScript.SetLevel();
        prestigeTab.SetActive(false);
        ball1Tab.SetActive(true);
        ballEquippedFrame.SetActive(true);
        ballAllFramesTab.SetActive(true);

        goldText.text = "1";
        tabsScript.SetFRameBTNS();
    }

    public static int levelSelected;
    public LocalizationStrings locScript;
    public TextMeshProUGUI levelSelectedText;

    public void SelectLevel(int level)
    {
        ClickSound();
        if (level == 1) { levelSelect.transform.position = level1Frame.gameObject.transform.position; locScript.LevelSelected(1); }
        else if (level == 2) { levelSelect.transform.position = level2Frame.gameObject.transform.position; locScript.LevelSelected(2); }

        if(GameData.isDemo == false)
        {
            if (level == 3) { levelSelect.transform.position = level3Frame.gameObject.transform.position; locScript.LevelSelected(3); }
            else if (level == 4) { levelSelect.transform.position = level4Frame.gameObject.transform.position; locScript.LevelSelected(4); }
            else if (level == 5) { levelSelect.transform.position = level5Frame.gameObject.transform.position; locScript.LevelSelected(5); }
            else if (level == 6) { levelSelect.transform.position = level6Frame.gameObject.transform.position; locScript.LevelSelected(6); }
            else if (level == 7) { levelSelect.transform.position = level7Frame.gameObject.transform.position; locScript.LevelSelected(7); }
            else if (level == 8) { levelSelect.transform.position = level8Frame.gameObject.transform.position; locScript.LevelSelected(8); }
            else if (level == 9) { levelSelect.transform.position = level9Frame.gameObject.transform.position; locScript.LevelSelected(9); }
            else if (level == 10) { levelSelect.transform.position = level10Frame.gameObject.transform.position; locScript.LevelSelected(10); }
        }

        levelSelectedText.text = LocalizationStrings.levelSelectedString;

        levelSelected = level;
    }
    #endregion

    //22

    #region Actually Prestige
    public Animator transitionAnim;
    public Levels levelScript;

    public Button prestigeButton;

    public void ActuallyPrestige()
    {
        exitPrestigeScreenYesButton.interactable = true;

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        isPrestiged = true;
        isInPrestigeScreen = true;
        prestigeButton.interactable = false;
        isOnlyViewing = false;
        StartCoroutine(PegscendTransitionOpen());
    }

    IEnumerator PegscendTransitionOpen()
    {
        LoadAllPrestigeUpgrades();
        audioManager.Play("PrestigeTran");
        onlyViweingBar.SetActive(false);
        transitionAnim.SetTrigger("Reveal");
        yield return new WaitForSeconds(1.1f);
        transitionAnim.SetTrigger("Hide");
        levelScript.CancelBoardAnim();
        MainShooter.totalPegsHit = 0;
        MainShooter.totalPegs = 0;
        BasicPeg.boardClearPrestigeHit = 0;
        //levelScript.SetLevel();
        chooseToPegScendScreen.SetActive(false);
        PrestigeScreen.SetActive(true);
        prestigeScreenContent.transform.localPosition = new Vector2(-315f, 350f);
        prestigeScreenZoom.transform.localScale = new Vector3(1.04f, 1.04f, 1.04f);

        BallUpgrades.isRegularBallAutoPurchased = false;
        SetStuffInactiveOrFalse();
        CheckLevelSetInactive();

        canvasToolTip.SetActive(false);
        canvasSetActive.SetActive(false);
        canvasBackgrounds.SetActive(false);
        canvasLevels.SetActive(false);
        canvasAnimations.SetActive(false);
        canvasBalls.SetActive(false);
        canvasGame.SetActive(false);
        ballUpgradeScript.SetNormalColor();
    }

    #region Set A lot of stuff inactive or false
    public MainShooter mainShooterScript;
    public SettingsOptions settingScript;

    public void SetStuffInactiveOrFalse()
    {
        settingScript.BackToPool();
    }
    #endregion

    #region Check levels active and set inactive
    public void CheckLevelSetInactive()
    {
        MainShooter.totalPegs = 0;
        MainShooter.totalPegsHit = 0;
        if (levelSelected == 1) { DeactivateAllChildren(levels[0]); }
        if (levelSelected == 2) { DeactivateAllChildren(levels[1]); }
        if (levelSelected == 3) { DeactivateAllChildren(levels[2]); }
        if (levelSelected == 4) { DeactivateAllChildren(levels[3]); }
        if (levelSelected == 5) { DeactivateAllChildren(levels[4]); }
        if (levelSelected == 6) { DeactivateAllChildren(levels[5]); }
        if (levelSelected == 7) { DeactivateAllChildren(levels[6]); }
        if (levelSelected == 8) { DeactivateAllChildren(levels[7]); }
        if (levelSelected == 9) { DeactivateAllChildren(levels[8]); }
        if (levelSelected == 10) { DeactivateAllChildren(levels[9]); }
    }

    void DeactivateAllChildren(GameObject parent)
    {
        // Iterate through all children of the specified GameObject
        foreach (Transform child in parent.transform)
        {
            // Deactivate the child's GameObject
            child.gameObject.SetActive(false);
        }
    }
    #endregion

    public GameObject chooseToPegScendScreen;
    public void OpenPegscensionChoose()
    {
        ClickSound();
        chooseToPegScendScreen.SetActive(true);
    }

    public void DontPrestige()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        ClickSound();
        chooseToPegScendScreen.SetActive(false);
    }
    #endregion

    #region Set Buckets
    public GameObject smallBucket1, smallBucket2, midBucket1, midBucket2, bucketLarge, bucketLarge2; 

    public void SetBuckets()
    {
        smallBucket1.SetActive(false); smallBucket2.SetActive(false); 
        midBucket1.SetActive(false); midBucket2.SetActive(false); 
        bucketLarge.SetActive(false); bucketLarge2.SetActive(false); 

        if (levelSelected == 1) { midBucket1.SetActive(true); }
        if (levelSelected == 2) { midBucket1.SetActive(true); }
        if (levelSelected == 3) { bucketLarge.SetActive(true); }
        if (levelSelected == 4) { bucketLarge.SetActive(true); smallBucket1.SetActive(true); }
        if (levelSelected == 5) { bucketLarge.SetActive(true); midBucket1.SetActive(true); }
        if (levelSelected == 6) { bucketLarge.SetActive(true); midBucket1.SetActive(true); smallBucket1.SetActive(true); }
        if (levelSelected == 7) { bucketLarge.SetActive(true); bucketLarge2.SetActive(true); }
        if (levelSelected == 8) { bucketLarge.SetActive(true); bucketLarge2.SetActive(true); midBucket1.SetActive(true); }
        if (levelSelected == 9) 
        { 
            bucketLarge.SetActive(true); bucketLarge2.SetActive(true);
            midBucket1.SetActive(true); midBucket2.SetActive(true);
        }
        if (levelSelected == 10) 
        { 
            bucketLarge.SetActive(true); bucketLarge2.SetActive(true); midBucket1.SetActive(true); midBucket2.SetActive(true); smallBucket1.SetActive(true); smallBucket2.SetActive(true); 
        }
    }
    #endregion

    //All branches
    #region First upgrade
    public GameObject firstGreenOutLine;
    public Button firstUpgradeButton;
    public Image firstUpgradeImage;
    public static bool purchasedFirstUpgrade;

    public void FirstPrestigeUpgrade(bool firstPurchase)
    {
        if (MobileScript.isMobile == true) { ClickSound(); }

        if (firstPurchase == false) { SetFirstUpgrade(); }
        else
        {
           
            if (PrestigeToolTip.isMobilePrestigeOpen == false && MobileScript.isMobile == true) { return; }
            if (isOnlyViewing == false && prestigePoints >= PrestigeToolTip.prestigePointPrice)
            {
                if (reachedOver500 == true) { reachedOver500 = false; }
                AllStats.totalPrestigePointSpent += PrestigeToolTip.prestigePointPrice;
                purchasedFirstUpgrade = true;
                if (ppOverflow == false) { prestigePoints -= PrestigeToolTip.prestigePointPrice; }
                else { prestigePointsOverFlow -= PrestigeToolTip.prestigePointPrice; }
                goldenPegChance += goldenPegChanceIncrease1;
                UpgradeSound();
                SetFirstUpgrade();
            }
            else { audioManager.Play("CantAfford");  }
        }
    }

    public void SetFirstUpgrade()
    {
        firstGreenOutLine.gameObject.SetActive(true);
        SetImageAlphaRecursive(firstUpgradeImage, 1f);
        ButtonDisableOrEnable(false, firstUpgradeButton);

        SetActive(true, newLevelGreenLines[0]);
        SetActive(true, goldGreenLines[0]);
        SetActive(true, prestigeGreenLines[0]);
        SetActive(true, newPegsGreenLines[0]);
        SetActive(true, activePlayGreenLines[0]);

        SetImageAlphaRecursive(newLevelImage[0], alpha1);
        SetImageAlphaRecursive(goldImage[0], alpha3);
        SetImageAlphaRecursive(prestigeImage[0], alpha3);
        SetImageAlphaRecursive(newPegsImage[0], alpha3);
        SetImageAlphaRecursive(activePlayImage[0], alpha3);

        SetActive(false, newLevelLocks[0]);
        SetActive(false, goldLocks[0]);
        SetActive(false, prestigeLocks[0]);
        SetActive(false, newPegsLocks[0]);
        SetActive(false, activePlayLocks[0]);

        ButtonDisableOrEnable(true, newLevelUpgrades[0]);
        ButtonDisableOrEnable(true, goldUpgrades[0]);
        ButtonDisableOrEnable(true, prestigeUpgrades[0]);
        ButtonDisableOrEnable(true, newPegsUpgrades[0]);
        ButtonDisableOrEnable(true, activePlayUpgrades[0]);

        if(GameData.isDemo == false)
        {
            SetActive(true, moreShotsLines[0]);
            SetImageAlphaRecursive(moreShotsImage[0], alpha3);
            SetActive(false, moreShotsLocks[0]);
            ButtonDisableOrEnable(true, moreShotsUpgrades[0]);
        }
    }
    #endregion

    #region New Level Branch
    public GameObject[] newLevelGreenLines;
    public GameObject[] newLevelLocks;
    public Button[] newLevelUpgrades;
    public Image[] newLevelImage;
    public GameObject[] newLevelGreenOutlines;

    public static bool purchasedLevel2, purchasedLevel3, purchasedLevel4, purchasedLevel5, purchasedLevel6, purchasedLevel7, purchasedLevel8, purchasedLevel9, purchasedLevel10;

    public void NewLevelUpgrade(int upgradeNumber)
    {
        if (MobileScript.isMobile == true) { ClickSound(); }
        if (PrestigeToolTip.isMobilePrestigeOpen == false && MobileScript.isMobile == true) { return; }
        if (isOnlyViewing == false)
        {
            if (prestigePoints >= PrestigeToolTip.prestigePointPrice)
            {
                if (reachedOver500 == true) { reachedOver500 = false; }
                AllStats.totalPrestigePointSpent += PrestigeToolTip.prestigePointPrice;
                prestigePoints -= PrestigeToolTip.prestigePointPrice;
                UpgradeSound();
                SetNewLevel(upgradeNumber);
                AllStats.levelsUnlocked += 1;

                if (upgradeNumber == 2)
                {
                    purchasedLevel2 = true;
                }
                if (upgradeNumber == 3)
                {
                    purchasedLevel3 = true;
                }
                if (upgradeNumber == 4)
                {
                    purchasedLevel4 = true;
                }
                if (upgradeNumber == 5)
                {
                    purchasedLevel5 = true;
                }
                if (upgradeNumber == 6)
                {
                    purchasedLevel6 = true;
                }
                if (upgradeNumber == 7)
                {
                    purchasedLevel7 = true;
                }
                if (upgradeNumber == 8)
                {
                    purchasedLevel8 = true;
                }
                if (upgradeNumber == 9)
                {
                    purchasedLevel9 = true;
                }
                if (upgradeNumber == 10)
                {
                    purchasedLevel10 = true;
                }

                if (achScript != null) { if (achScript != null) { achScript.CheckNewLevelACH(); } }
            }
            else { audioManager.Play("CantAfford"); }
        }
    }

    public void SetNewLevel(int upgradeNumber)
    {
        if(upgradeNumber == 2)
        {
            newLevelGreenOutlines[0].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[0], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[0]);

            if(GameData.isDemo == false)
            {
                SetActive(true, newLevelGreenLines[1]);
                SetImageAlphaRecursive(newLevelImage[1], alpha1);
                SetActive(false, newLevelLocks[1]);
                ButtonDisableOrEnable(true, newLevelUpgrades[1]);
            }
        }
        else if (upgradeNumber == 3)
        {
            newLevelGreenOutlines[1].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[1], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[1]);

            SetActive(true, newLevelGreenLines[2]);
            SetImageAlphaRecursive(newLevelImage[2], alpha1);
            SetActive(false, newLevelLocks[2]);
            ButtonDisableOrEnable(true, newLevelUpgrades[2]);
        }
        else if(upgradeNumber == 4)
        {
            newLevelGreenOutlines[2].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[2], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[2]);

            SetActive(true, newLevelGreenLines[3]);
            SetImageAlphaRecursive(newLevelImage[3], alpha1);
            SetActive(false, newLevelLocks[3]);
            ButtonDisableOrEnable(true, newLevelUpgrades[3]);
        }
        else if(upgradeNumber == 5)
        {
            newLevelGreenOutlines[3].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[3], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[3]);

            SetActive(true, newLevelGreenLines[4]);
            SetImageAlphaRecursive(newLevelImage[4], alpha1);
            SetActive(false, newLevelLocks[4]);
            ButtonDisableOrEnable(true, newLevelUpgrades[4]);
        }
        else if (upgradeNumber == 6)
        {
            newLevelGreenOutlines[4].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[4], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[4]);

            SetActive(true, newLevelGreenLines[5]);
            SetImageAlphaRecursive(newLevelImage[5], alpha1);
            SetActive(false, newLevelLocks[5]);
            ButtonDisableOrEnable(true, newLevelUpgrades[5]);
        }
        else if (upgradeNumber == 7)
        {
            newLevelGreenOutlines[5].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[5], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[5]);

            SetActive(true, newLevelGreenLines[6]);
            SetImageAlphaRecursive(newLevelImage[6], alpha1);
            SetActive(false, newLevelLocks[6]);
            ButtonDisableOrEnable(true, newLevelUpgrades[6]);
        }
        else if (upgradeNumber == 8)
        {
            newLevelGreenOutlines[6].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[6], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[6]);

            SetActive(true, newLevelGreenLines[7]);
            SetImageAlphaRecursive(newLevelImage[7], alpha1);
            SetActive(false, newLevelLocks[7]);
            ButtonDisableOrEnable(true, newLevelUpgrades[7]);
        }
        else if (upgradeNumber == 9)
        {
            newLevelGreenOutlines[7].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[7], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[7]);

            SetActive(true, newLevelGreenLines[8]);
            SetImageAlphaRecursive(newLevelImage[8], alpha1);
            SetActive(false, newLevelLocks[8]);
            ButtonDisableOrEnable(true, newLevelUpgrades[8]);
        }
        else if (upgradeNumber == 10)
        {
            newLevelGreenOutlines[8].SetActive(true);
            SetImageAlphaRecursive(newLevelImage[8], 1f);
            ButtonDisableOrEnable(false, newLevelUpgrades[8]);
        }
    }

    #endregion

    #region Gold Branch
    public GameObject[] goldGreenLines;
    public GameObject[] goldLocks;
    public Button[] goldUpgrades;
    public Image[] goldImage;
    public GameObject[] goldGreenOutlines;

    public static float prestigeGoldIncrease;
    public static float goldenPegChance;
    public static float totalGoldClearBonus, totalTimerGoldClearBonus;

    #region Active Booleans
    public static bool G_Upgrade1Purchased;
    public static bool G_Upgrade2Purchased;
    public static bool G_Upgrade3Purchased;
    public static bool G_Upgrade4Purchased;
    public static bool G_Upgrade5Purchased;
    public static bool G_Upgrade6Purchased;
    public static bool G_Upgrade7Purchased;
    public static bool G_Upgrade8Purchased;
    public static bool G_Upgrade9Purchased;
    public static bool G_Upgrade10Purchased;
    public static bool G_Upgrade11Purchased;
    public static bool G_Upgrade12Purchased;
    public static bool G_Upgrade13Purchased;
    public static bool G_Upgrade14Purchased;
    public static bool G_Upgrade15Purchased;
    public static bool G_Upgrade16Purchased;
    public static bool G_Upgrade17Purchased;
    public static bool G_Upgrade18Purchased;
    public static bool G_Upgrade19Purchased;
    public static bool G_Upgrade20Purchased;
    public static bool G_Upgrade21Purchased;
    public static bool G_Upgrade22Purchased;
    public static bool G_Upgrade23Purchased;
    public static bool G_Upgrade24Purchased;
    public static bool G_Upgrade25Purchased;
    public static bool G_Upgrade26Purchased;
    public static bool G_Upgrade27Purchased;
    public static bool G_Upgrade28Purchased;
    public static bool G_Upgrade29Purchased;
    public static bool G_Upgrade30Purchased;
    public static bool G_Upgrade31Purchased;
    public static bool G_Upgrade32Purchased;
    public static bool G_Upgrade33Purchased;
    public static bool G_Upgrade34Purchased;
    public static bool G_Upgrade35Purchased;
    public static bool G_Upgrade36Purchased;
    public static bool G_Upgrade37Purchased;
    public static bool G_Upgrade38Purchased;
    public static bool G_Upgrade39Purchased;
    public static bool G_Upgrade40Purchased;
    public static bool G_Upgrade41Purchased;
    public static bool G_Upgrade42Purchased;
    public static bool G_Upgrade43Purchased;
    public static bool G_Upgrade44Purchased;
    public static bool G_Upgrade45Purchased;
    public static bool G_Upgrade46Purchased;
    public static bool G_Upgrade47Purchased;
    public static bool G_Upgrade48Purchased;
    public static bool G_Upgrade49Purchased;
    public static bool G_Upgrade50Purchased;
    public static bool G_Upgrade51Purchased;
    #endregion

    public void GoldBranchUpgrade(int upgradeNumber)
    {
        if (MobileScript.isMobile == true) { ClickSound(); }
        if (PrestigeToolTip.isMobilePrestigeOpen == false && MobileScript.isMobile == true) { return; }

        if (isOnlyViewing == false)
        {
            if (prestigePoints >= PrestigeToolTip.prestigePointPrice)
            {
                if(reachedOver500 == true) { reachedOver500 = false; }
                AllStats.totalPrestigePointSpent += PrestigeToolTip.prestigePointPrice;
                if (ppOverflow == false) { prestigePoints -= PrestigeToolTip.prestigePointPrice; }
                else { prestigePointsOverFlow -= PrestigeToolTip.prestigePointPrice; }
                UpgradeSound();
                SetGold(upgradeNumber);

                #region Upgrade 1 BIG
                if (upgradeNumber == 1)
                {
                    G_Upgrade1Purchased = true;
                    prestigeGoldIncrease += goldIncrease1;
                }
                #endregion

                #region Upgrade 2
                else if (upgradeNumber == 2)
                {
                    G_Upgrade2Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease2;
                }
                #endregion

                #region Upgrade 3
                else if (upgradeNumber == 3)
                {
                    G_Upgrade3Purchased = true;
                    prestigeGoldIncrease += goldIncrease2;
                }
                #endregion

                #region Upgrade 4
                else if (upgradeNumber == 4)
                {
                    G_Upgrade4Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease3;
                }
                #endregion

                #region Upgrade 5
                else if (upgradeNumber == 5)
                {
                    G_Upgrade5Purchased = true;
                    prestigeGoldIncrease += goldIncrease3;
                }
                #endregion

                #region Upgrade 6
                else if (upgradeNumber == 6)
                {
                    G_Upgrade6Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease4;
                }
                #endregion

                #region Upgrade 7
                else if (upgradeNumber == 7)
                {
                    G_Upgrade7Purchased = true;
                    prestigeGoldIncrease += goldIncrease4;
                }
                #endregion

                #region Upgrade 8
                else if (upgradeNumber == 8)
                {
                    G_Upgrade8Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease5;
                }
                #endregion

                #region Upgrade 9
                else if (upgradeNumber == 9)
                {
                    G_Upgrade9Purchased = true;
                    prestigeGoldIncrease += goldIncrease5;
                }
                #endregion

                #region Upgrade 10
                else if (upgradeNumber == 10)
                {
                    G_Upgrade10Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease6;
                }
                #endregion

                #region Upgrade 11
                else if (upgradeNumber == 11)
                {
                    G_Upgrade11Purchased = true;
                    prestigeGoldIncrease += goldIncrease6;
                }
                #endregion

                #region Upgrade 12 BIG
                else if (upgradeNumber == 12)
                {
                    G_Upgrade12Purchased = true;
                    totalGoldClearBonus = clearBonus1;
                }
                #endregion

                #region Upgrade 13
                else if (upgradeNumber == 13)
                {
                    G_Upgrade13Purchased = true;
                    totalGoldClearBonus = clearBonus2;
                }
                #endregion

                #region Upgrade 14
                else if (upgradeNumber == 14)
                {
                    G_Upgrade14Purchased = true;
                    totalGoldClearBonus = clearBonus3;
                }
                #endregion

                #region Upgrade 15
                else if (upgradeNumber == 15)
                {
                    G_Upgrade15Purchased = true;
                    totalGoldClearBonus = clearBonus4;
                }
                #endregion

                #region Upgrade 16
                else if (upgradeNumber == 16)
                {
                    G_Upgrade16Purchased = true;
                    totalGoldClearBonus = clearBonus5;
                }
                #endregion

                #region Upgrade 17
                else if (upgradeNumber == 17)
                {
                    G_Upgrade17Purchased = true;
                    totalGoldClearBonus = clearBonus6;
                }
                #endregion

                #region Upgrade 18
                else if (upgradeNumber == 18)
                {
                    G_Upgrade18Purchased = true;
                    totalGoldClearBonus = clearBonus7;
                }
                #endregion

                #region Upgrade 19 BIG
                else if (upgradeNumber == 19)
                {
                    G_Upgrade19Purchased = true;
                }
                #endregion

                #region Upgrade 20
                else if (upgradeNumber == 20)
                {
                    G_Upgrade20Purchased = true;
                    totalTimerGoldClearBonus = goldClearTimer1;
                }
                #endregion

                #region Upgrade 21
                else if (upgradeNumber == 21)
                {
                    G_Upgrade21Purchased = true;
                    totalTimerGoldClearBonus = goldClearTimer2;
                }
                #endregion

                #region Upgrade 22
                else if (upgradeNumber == 22)
                {
                    G_Upgrade22Purchased = true;
                    totalTimerGoldClearBonus = goldClearTimer3;
                }
                #endregion

                #region Upgrade 23
                else if (upgradeNumber == 23)
                {
                    G_Upgrade23Purchased = true;
                    totalTimerGoldClearBonus = goldClearTimer4;
                }
                #endregion

                #region Upgrade 24
                else if (upgradeNumber == 24)
                {
                    G_Upgrade24Purchased = true;
                    totalTimerGoldClearBonus = goldClearTimer5;
                }
                #endregion

                #region Upgrade 25
                else if (upgradeNumber == 25)
                {
                    G_Upgrade25Purchased = true;
                    totalTimerGoldClearBonus = goldClearTimer6;
                }
                #endregion

                #region Upgrade 26 BIG
                else if (upgradeNumber == 26)
                {
                    G_Upgrade26Purchased = true;
                    totalTimerGoldClearBonus = goldClearTimer7;
                }
                #endregion

                #region Upgrade 27
                else if (upgradeNumber == 27)
                {
                    G_Upgrade27Purchased = true;
                }
                #endregion

                #region Upgrade 28
                else if (upgradeNumber == 28)
                {
                    G_Upgrade28Purchased = true;
                }
                #endregion

                #region Upgrade 29
                else if (upgradeNumber == 29)
                {
                    G_Upgrade29Purchased = true;
                }
                #endregion

                #region Upgrade 30 BIG
                else if (upgradeNumber == 30)
                {
                    G_Upgrade30Purchased = true;
                }
                #endregion

                #region Upgrade 31
                else if (upgradeNumber == 31)
                {
                    G_Upgrade31Purchased = true;
                }
                #endregion

                #region Upgrade 32
                else if (upgradeNumber == 32)
                {
                    G_Upgrade32Purchased = true;
                }
                #endregion

                #region Upgrade 33
                else if (upgradeNumber == 33)
                {
                    G_Upgrade33Purchased = true;
                }
                #endregion

                #region Upgrade 34
                else if (upgradeNumber == 34)
                {
                    G_Upgrade34Purchased = true;
                }
                #endregion

                #region Upgrade 35 BIG
                else if (upgradeNumber == 35)
                {
                    G_Upgrade35Purchased = true;
                }
                #endregion

                #region Upgrade 36
                else if (upgradeNumber == 36)
                {
                    G_Upgrade36Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease7;
                }
                #endregion

                #region Upgrade 37
                else if (upgradeNumber == 37)
                {
                    G_Upgrade37Purchased = true;
                    prestigeGoldIncrease += goldIncrease7;
                }
                #endregion

                #region Upgrade 38
                else if (upgradeNumber == 38)
                {
                    G_Upgrade38Purchased = true;
                    prestigeGoldIncrease += goldIncrease8;
                }
                #endregion

                #region Upgrade 39
                else if (upgradeNumber == 39)
                {
                    G_Upgrade39Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease8;
                }
                #endregion

                #region Upgrade 40
                else if (upgradeNumber == 40)
                {
                    G_Upgrade40Purchased = true;
                    prestigeGoldIncrease += goldIncrease9;
                }
                #endregion

                #region Upgrade 41
                else if (upgradeNumber == 41)
                {
                    G_Upgrade41Purchased = true;
                    prestigeGoldIncrease += goldIncrease10;
                }
                #endregion

                #region Upgrade 42
                else if (upgradeNumber == 42)
                {
                    G_Upgrade42Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease9;
                }
                #endregion

                #region Upgrade 43
                else if (upgradeNumber == 43)
                {
                    G_Upgrade43Purchased = true;
                    prestigeGoldIncrease += goldIncrease11;
                }
                #endregion

                #region Upgrade 44
                else if (upgradeNumber == 44)
                {
                    G_Upgrade44Purchased = true;
                    prestigeGoldIncrease += goldIncrease12;
                }
                #endregion

                #region Upgrade 45
                else if (upgradeNumber == 45)
                {
                    G_Upgrade45Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease10;
                }
                #endregion

                #region Upgrade 46
                else if (upgradeNumber == 46)
                {
                    G_Upgrade46Purchased = true;
                    prestigeGoldIncrease += goldIncrease13;
                }
                #endregion

                #region Upgrade 47
                else if (upgradeNumber == 47)
                {
                    G_Upgrade47Purchased = true;
                    prestigeGoldIncrease += goldIncrease14;
                }
                #endregion

                #region Upgrade 48
                else if (upgradeNumber == 48)
                {
                    G_Upgrade48Purchased = true;
                    goldenPegChance += goldenPegChanceIncrease11;
                }
                #endregion

                #region Upgrade 49
                else if (upgradeNumber == 49)
                {
                    G_Upgrade49Purchased = true;
                    prestigeGoldIncrease += goldIncrease15;
                }
                #endregion

                #region Upgrade 50
                else if (upgradeNumber == 50)
                {
                    G_Upgrade50Purchased = true;
                    prestigeGoldIncrease += goldIncrease16;
                }
                #endregion

                #region Upgrade 51 BIG
                else if (upgradeNumber == 51)
                {
                    G_Upgrade51Purchased = true;
                }
                #endregion
            }
            else { audioManager.Play("CantAfford"); }
        }
    }

    public void SetGold(int upgradeNumber)
    {
        #region Upgrade 1
        if (upgradeNumber == 1)
        {
            goldGreenOutlines[0].SetActive(true);
            SetImageAlphaRecursive(goldImage[0], 1f);
            ButtonDisableOrEnable(false, goldUpgrades[0]);
            if(GameData.isDemo == false) 
            {
                SetActive(true, goldGreenLines[1]);
                SetActive(true, goldGreenLines[2]);
                SetImageAlphaRecursive(goldImage[1], alpha3);
                SetImageAlphaRecursive(goldImage[2], alpha3);
                SetActive(false, goldLocks[1]);
                SetActive(false, goldLocks[2]);
                ButtonDisableOrEnable(true, goldUpgrades[1]);
                ButtonDisableOrEnable(true, goldUpgrades[2]);
            }
        }
        #endregion

        if (GameData.isDemo == false)
        {
            #region Upgrade 2
            if (upgradeNumber == 2)
            {
                goldGreenOutlines[1].SetActive(true);
                SetImageAlphaRecursive(goldImage[1], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[1]);

                SetActive(true, goldGreenLines[3]);
                SetImageAlphaRecursive(goldImage[3], alpha3);
                SetActive(false, goldLocks[3]);
                ButtonDisableOrEnable(true, goldUpgrades[3]);
            }
            #endregion

            #region Upgrade 3
            if (upgradeNumber == 3)
            {
                goldGreenOutlines[2].SetActive(true);
                SetImageAlphaRecursive(goldImage[2], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[2]);

                SetActive(true, goldGreenLines[4]);
                SetImageAlphaRecursive(goldImage[4], alpha3);
                SetActive(false, goldLocks[4]);
                ButtonDisableOrEnable(true, goldUpgrades[4]);
            }
            #endregion

            #region Upgrade 4
            if (upgradeNumber == 4)
            {
                goldGreenOutlines[3].SetActive(true);
                SetImageAlphaRecursive(goldImage[3], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[3]);

                SetActive(true, goldGreenLines[5]);
                SetImageAlphaRecursive(goldImage[5], alpha3);
                SetActive(false, goldLocks[5]);
                ButtonDisableOrEnable(true, goldUpgrades[5]);
            }
            #endregion

            #region Upgrade 5
            if (upgradeNumber == 5)
            {
                goldGreenOutlines[4].SetActive(true);
                SetImageAlphaRecursive(goldImage[4], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[4]);

                SetActive(true, goldGreenLines[6]);
                SetImageAlphaRecursive(goldImage[6], alpha3);
                SetActive(false, goldLocks[6]);
                ButtonDisableOrEnable(true, goldUpgrades[6]);
            }
            #endregion

            #region Upgrade 6
            if (upgradeNumber == 6)
            {
                goldGreenOutlines[5].SetActive(true);
                SetImageAlphaRecursive(goldImage[5], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[5]);

                SetActive(true, goldGreenLines[7]);
                SetImageAlphaRecursive(goldImage[7], alpha3);
                SetActive(false, goldLocks[7]);
                ButtonDisableOrEnable(true, goldUpgrades[7]);
            }
            #endregion

            #region Upgrade 7
            if (upgradeNumber == 7)
            {
                goldGreenOutlines[6].SetActive(true);
                SetImageAlphaRecursive(goldImage[6], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[6]);

                SetActive(true, goldGreenLines[8]);
                SetImageAlphaRecursive(goldImage[8], alpha3);
                SetActive(false, goldLocks[8]);
                ButtonDisableOrEnable(true, goldUpgrades[8]);
            }
            #endregion

            #region Upgrade 8
            if (upgradeNumber == 8)
            {
                goldGreenOutlines[7].SetActive(true);
                SetImageAlphaRecursive(goldImage[7], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[7]);

                SetActive(true, goldGreenLines[9]);
                SetImageAlphaRecursive(goldImage[9], alpha3);
                SetActive(false, goldLocks[9]);
                ButtonDisableOrEnable(true, goldUpgrades[9]);
            }
            #endregion

            #region Upgrade 9
            if (upgradeNumber == 9)
            {
                goldGreenOutlines[8].SetActive(true);
                SetImageAlphaRecursive(goldImage[8], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[8]);

                SetActive(true, goldGreenLines[10]);
                SetImageAlphaRecursive(goldImage[10], alpha3);
                SetActive(false, goldLocks[10]);
                ButtonDisableOrEnable(true, goldUpgrades[10]);
            }
            #endregion

            #region Upgrade 10 
            if (upgradeNumber == 10)
            {
                goldGreenOutlines[9].SetActive(true);
                SetImageAlphaRecursive(goldImage[9], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[9]);

                SetActive(true, goldGreenLines[11]);
                SetActive(false, goldLocks[11]);

                if (G_Upgrade12Purchased == false)
                {
                    SetImageAlphaRecursive(goldImage[11], alpha3);
                    ButtonDisableOrEnable(true, goldUpgrades[11]);
                }
            }
            #endregion

            #region Upgrade 11 
            if (upgradeNumber == 11)
            {
                goldGreenOutlines[10].SetActive(true);
                SetImageAlphaRecursive(goldImage[10], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[10]);

                SetActive(true, goldGreenLines[12]);
                SetActive(false, goldLocks[11]);

                if (G_Upgrade12Purchased == false)
                {
                    SetImageAlphaRecursive(goldImage[11], alpha3);
                    ButtonDisableOrEnable(true, goldUpgrades[11]);
                }
            }
            #endregion

            #region Upgrade 12 BIG
            if (upgradeNumber == 12)
            {
                goldGreenOutlines[11].SetActive(true);
                SetImageAlphaRecursive(goldImage[11], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[11]);
                if(MobileScript.isMobile == true) { ButtonDisableOrEnable(true, goldUpgrades[11]); }

                SetActive(true, goldGreenLines[13]);
                SetActive(true, goldGreenLines[27]);
                SetActive(true, goldGreenLines[31]);
                SetActive(true, goldGreenLines[36]);
                SetActive(true, goldGreenLines[37]);
                SetActive(true, goldGreenLines[38]);

                SetImageAlphaRecursive(goldImage[12], alpha3);
                SetImageAlphaRecursive(goldImage[26], alpha3);
                SetImageAlphaRecursive(goldImage[30], alpha3);
                SetImageAlphaRecursive(goldImage[35], alpha3);
                SetImageAlphaRecursive(goldImage[36], alpha3);
                SetImageAlphaRecursive(goldImage[37], alpha3);

                SetActive(false, goldLocks[12]);
                SetActive(false, goldLocks[26]);
                SetActive(false, goldLocks[30]);
                SetActive(false, goldLocks[35]);
                SetActive(false, goldLocks[36]);
                SetActive(false, goldLocks[37]);

                ButtonDisableOrEnable(true, goldUpgrades[12]);
                ButtonDisableOrEnable(true, goldUpgrades[26]);
                ButtonDisableOrEnable(true, goldUpgrades[30]);
                ButtonDisableOrEnable(true, goldUpgrades[35]);
                ButtonDisableOrEnable(true, goldUpgrades[36]);
                ButtonDisableOrEnable(true, goldUpgrades[37]);
            }
            #endregion

            #region Upgrade 13
            if (upgradeNumber == 13)
            {
                goldGreenOutlines[12].SetActive(true);
                SetImageAlphaRecursive(goldImage[12], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[12]);

                SetActive(true, goldGreenLines[14]);
                SetActive(true, goldGreenLines[20]);
                SetImageAlphaRecursive(goldImage[13], alpha3);
                SetImageAlphaRecursive(goldImage[19], alpha3);
                SetActive(false, goldLocks[13]);
                SetActive(false, goldLocks[19]);
                ButtonDisableOrEnable(true, goldUpgrades[13]);
                ButtonDisableOrEnable(true, goldUpgrades[19]);
            }
            #endregion

            #region Upgrade 14
            if (upgradeNumber == 14)
            {
                goldGreenOutlines[13].SetActive(true);
                SetImageAlphaRecursive(goldImage[13], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[13]);

                SetActive(true, goldGreenLines[15]);
                SetImageAlphaRecursive(goldImage[14], alpha3);
                SetActive(false, goldLocks[14]);
                ButtonDisableOrEnable(true, goldUpgrades[14]);
            }
            #endregion

            #region Upgrade 15
            if (upgradeNumber == 15)
            {
                goldGreenOutlines[14].SetActive(true);
                SetImageAlphaRecursive(goldImage[14], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[14]);

                SetActive(true, goldGreenLines[16]);
                SetImageAlphaRecursive(goldImage[15], alpha3);
                SetActive(false, goldLocks[15]);
                ButtonDisableOrEnable(true, goldUpgrades[15]);
            }
            #endregion

            #region Upgrade 16
            if (upgradeNumber == 16)
            {
                goldGreenOutlines[15].SetActive(true);
                SetImageAlphaRecursive(goldImage[15], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[15]);

                SetActive(true, goldGreenLines[17]);
                SetImageAlphaRecursive(goldImage[16], alpha3);
                SetActive(false, goldLocks[16]);
                ButtonDisableOrEnable(true, goldUpgrades[16]);
            }
            #endregion

            #region Upgrade 17
            if (upgradeNumber == 17)
            {
                goldGreenOutlines[16].SetActive(true);
                SetImageAlphaRecursive(goldImage[16], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[16]);

                SetActive(true, goldGreenLines[18]);
                SetImageAlphaRecursive(goldImage[17], alpha3);
                SetActive(false, goldLocks[17]);
                ButtonDisableOrEnable(true, goldUpgrades[17]);
            }
            #endregion

            #region Upgrade 18
            if (upgradeNumber == 18)
            {
                goldGreenOutlines[17].SetActive(true);
                SetImageAlphaRecursive(goldImage[17], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[17]);

                SetActive(true, goldGreenLines[19]);
                SetImageAlphaRecursive(goldImage[18], alpha3);
                SetActive(false, goldLocks[18]);
                ButtonDisableOrEnable(true, goldUpgrades[18]);
            }
            #endregion

            #region Upgrade 19 BIG
            if (upgradeNumber == 19)
            {
                goldGreenOutlines[18].SetActive(true);
                SetImageAlphaRecursive(goldImage[18], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[18]);
            }
            #endregion

            #region Upgrade 20
            if (upgradeNumber == 20)
            {
                goldGreenOutlines[19].SetActive(true);
                SetImageAlphaRecursive(goldImage[19], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[19]);

                SetActive(true, goldGreenLines[21]);
                SetImageAlphaRecursive(goldImage[20], alpha3);
                SetActive(false, goldLocks[20]);
                ButtonDisableOrEnable(true, goldUpgrades[20]);
            }
            #endregion

            #region Upgrade 21
            if (upgradeNumber == 21)
            {
                goldGreenOutlines[20].SetActive(true);
                SetImageAlphaRecursive(goldImage[20], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[20]);

                SetActive(true, goldGreenLines[22]);
                SetImageAlphaRecursive(goldImage[21], alpha3);
                SetActive(false, goldLocks[21]);
                ButtonDisableOrEnable(true, goldUpgrades[21]);
            }
            #endregion

            #region Upgrade 22
            if (upgradeNumber == 22)
            {
                goldGreenOutlines[21].SetActive(true);
                SetImageAlphaRecursive(goldImage[21], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[21]);

                SetActive(true, goldGreenLines[23]);
                SetImageAlphaRecursive(goldImage[22], alpha3);
                SetActive(false, goldLocks[22]);
                ButtonDisableOrEnable(true, goldUpgrades[22]);
            }
            #endregion

            #region Upgrade 23
            if (upgradeNumber == 23)
            {
                goldGreenOutlines[22].SetActive(true);
                SetImageAlphaRecursive(goldImage[22], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[22]);

                SetActive(true, goldGreenLines[24]);
                SetImageAlphaRecursive(goldImage[23], alpha3);
                SetActive(false, goldLocks[23]);
                ButtonDisableOrEnable(true, goldUpgrades[23]);
            }
            #endregion

            #region Upgrade 24
            if (upgradeNumber == 24)
            {
                goldGreenOutlines[23].SetActive(true);
                SetImageAlphaRecursive(goldImage[23], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[23]);

                SetActive(true, goldGreenLines[25]);
                SetImageAlphaRecursive(goldImage[24], alpha3);
                SetActive(false, goldLocks[24]);
                ButtonDisableOrEnable(true, goldUpgrades[24]);
            }
            #endregion

            #region Upgrade 25
            if (upgradeNumber == 25)
            {
                goldGreenOutlines[24].SetActive(true);
                SetImageAlphaRecursive(goldImage[24], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[24]);

                SetActive(true, goldGreenLines[26]);
                SetImageAlphaRecursive(goldImage[25], alpha3);
                SetActive(false, goldLocks[25]);
                ButtonDisableOrEnable(true, goldUpgrades[25]);
            }
            #endregion

            #region Upgrade 26 BIG
            if (upgradeNumber == 26)
            {
                goldGreenOutlines[25].SetActive(true);
                SetImageAlphaRecursive(goldImage[25], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[25]);
            }
            #endregion

            #region Upgrade 27
            if (upgradeNumber == 27)
            {
                goldGreenOutlines[26].SetActive(true);
                SetImageAlphaRecursive(goldImage[26], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[26]);

                SetActive(true, goldGreenLines[28]);
                SetImageAlphaRecursive(goldImage[27], alpha3);
                SetActive(false, goldLocks[27]);
                ButtonDisableOrEnable(true, goldUpgrades[27]);
            }
            #endregion

            #region Upgrade 28
            if (upgradeNumber == 28)
            {
                goldGreenOutlines[27].SetActive(true);
                SetImageAlphaRecursive(goldImage[27], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[27]);

                SetActive(true, goldGreenLines[29]);
                SetImageAlphaRecursive(goldImage[28], alpha3);
                SetActive(false, goldLocks[28]);
                ButtonDisableOrEnable(true, goldUpgrades[28]);
            }
            #endregion

            #region Upgrade 29
            if (upgradeNumber == 29)
            {
                goldGreenOutlines[28].SetActive(true);
                SetImageAlphaRecursive(goldImage[28], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[28]);

                SetActive(true, goldGreenLines[30]);
                SetImageAlphaRecursive(goldImage[29], alpha3);
                SetActive(false, goldLocks[29]);
                ButtonDisableOrEnable(true, goldUpgrades[29]);
            }
            #endregion

            #region Upgrade 30 BIG
            if (upgradeNumber == 30)
            {
                goldGreenOutlines[29].SetActive(true);
                SetImageAlphaRecursive(goldImage[29], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[29]);
            }
            #endregion

            #region Upgrade 31
            if (upgradeNumber == 31)
            {
                goldGreenOutlines[30].SetActive(true);
                SetImageAlphaRecursive(goldImage[30], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[30]);

                SetActive(true, goldGreenLines[32]);
                SetImageAlphaRecursive(goldImage[31], alpha3);
                SetActive(false, goldLocks[31]);
                ButtonDisableOrEnable(true, goldUpgrades[31]);
            }
            #endregion

            #region Upgrade 32
            if (upgradeNumber == 32)
            {
                goldGreenOutlines[31].SetActive(true);
                SetImageAlphaRecursive(goldImage[31], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[31]);

                SetActive(true, goldGreenLines[33]);
                SetImageAlphaRecursive(goldImage[32], alpha3);
                SetActive(false, goldLocks[32]);
                ButtonDisableOrEnable(true, goldUpgrades[32]);
            }
            #endregion

            #region Upgrade 33
            if (upgradeNumber == 33)
            {
                goldGreenOutlines[32].SetActive(true);
                SetImageAlphaRecursive(goldImage[32], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[32]);

                SetActive(true, goldGreenLines[34]);
                SetImageAlphaRecursive(goldImage[33], alpha3);
                SetActive(false, goldLocks[33]);
                ButtonDisableOrEnable(true, goldUpgrades[33]);
            }
            #endregion

            #region Upgrade 34
            if (upgradeNumber == 34)
            {
                goldGreenOutlines[33].SetActive(true);
                SetImageAlphaRecursive(goldImage[33], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[33]);

                SetActive(true, goldGreenLines[35]);
                SetImageAlphaRecursive(goldImage[34], alpha3);
                SetActive(false, goldLocks[34]);
                ButtonDisableOrEnable(true, goldUpgrades[34]);
            }
            #endregion

            #region Upgrade 35 BIG
            if (upgradeNumber == 35)
            {
                goldGreenOutlines[34].SetActive(true);
                SetImageAlphaRecursive(goldImage[34], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[34]);
            }
            #endregion

            #region Upgrade 36
            if (upgradeNumber == 36)
            {
                goldGreenOutlines[35].SetActive(true);
                SetImageAlphaRecursive(goldImage[35], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[35]);

                SetActive(true, goldGreenLines[39]);
                SetImageAlphaRecursive(goldImage[38], alpha3);
                SetActive(false, goldLocks[38]);
                ButtonDisableOrEnable(true, goldUpgrades[38]);
            }
            #endregion

            #region Upgrade 37
            if (upgradeNumber == 37)
            {
                goldGreenOutlines[36].SetActive(true);
                SetImageAlphaRecursive(goldImage[36], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[36]);

                SetActive(true, goldGreenLines[40]);
                SetImageAlphaRecursive(goldImage[39], alpha3);
                SetActive(false, goldLocks[39]);
                ButtonDisableOrEnable(true, goldUpgrades[39]);
            }
            #endregion

            #region Upgrade 38
            if (upgradeNumber == 38)
            {
                goldGreenOutlines[37].SetActive(true);
                SetImageAlphaRecursive(goldImage[37], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[37]);

                SetActive(true, goldGreenLines[41]);
                SetImageAlphaRecursive(goldImage[40], alpha3);
                SetActive(false, goldLocks[40]);
                ButtonDisableOrEnable(true, goldUpgrades[40]);
            }
            #endregion

            #region Upgrade 39
            if (upgradeNumber == 39)
            {
                goldGreenOutlines[38].SetActive(true);
                SetImageAlphaRecursive(goldImage[38], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[38]);

                SetActive(true, goldGreenLines[42]);
                SetImageAlphaRecursive(goldImage[41], alpha3);
                SetActive(false, goldLocks[41]);
                ButtonDisableOrEnable(true, goldUpgrades[41]);
            }
            #endregion

            #region Upgrade 40
            if (upgradeNumber == 40)
            {
                goldGreenOutlines[39].SetActive(true);
                SetImageAlphaRecursive(goldImage[39], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[39]);

                SetActive(true, goldGreenLines[43]);
                SetImageAlphaRecursive(goldImage[42], alpha3);
                SetActive(false, goldLocks[42]);
                ButtonDisableOrEnable(true, goldUpgrades[42]);
            }
            #endregion

            #region Upgrade 41
            if (upgradeNumber == 41)
            {
                goldGreenOutlines[40].SetActive(true);
                SetImageAlphaRecursive(goldImage[40], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[40]);

                SetActive(true, goldGreenLines[44]);
                SetImageAlphaRecursive(goldImage[43], alpha3);
                SetActive(false, goldLocks[43]);
                ButtonDisableOrEnable(true, goldUpgrades[43]);
            }
            #endregion

            #region Upgrade 42
            if (upgradeNumber == 42)
            {
                goldGreenOutlines[41].SetActive(true);
                SetImageAlphaRecursive(goldImage[41], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[41]);

                SetActive(true, goldGreenLines[45]);
                SetImageAlphaRecursive(goldImage[44], alpha3);
                SetActive(false, goldLocks[44]);
                ButtonDisableOrEnable(true, goldUpgrades[44]);
            }
            #endregion

            #region Upgrade 43
            if (upgradeNumber == 43)
            {
                goldGreenOutlines[42].SetActive(true);
                SetImageAlphaRecursive(goldImage[42], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[42]);

                SetActive(true, goldGreenLines[46]);
                SetImageAlphaRecursive(goldImage[45], alpha3);
                SetActive(false, goldLocks[45]);
                ButtonDisableOrEnable(true, goldUpgrades[45]);
            }
            #endregion

            #region Upgrade 44
            if (upgradeNumber == 44)
            {
                goldGreenOutlines[43].SetActive(true);
                SetImageAlphaRecursive(goldImage[43], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[43]);

                SetActive(true, goldGreenLines[47]);
                SetImageAlphaRecursive(goldImage[46], alpha3);
                SetActive(false, goldLocks[46]);
                ButtonDisableOrEnable(true, goldUpgrades[46]);
            }
            #endregion

            #region Upgrade 45
            if (upgradeNumber == 45)
            {
                goldGreenOutlines[44].SetActive(true);
                SetImageAlphaRecursive(goldImage[44], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[44]);

                SetActive(true, goldGreenLines[48]);
                SetImageAlphaRecursive(goldImage[47], alpha3);
                SetActive(false, goldLocks[47]);
                ButtonDisableOrEnable(true, goldUpgrades[47]);
            }
            #endregion

            #region Upgrade 46
            if (upgradeNumber == 46)
            {
                goldGreenOutlines[45].SetActive(true);
                SetImageAlphaRecursive(goldImage[45], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[45]);

                SetActive(true, goldGreenLines[49]);
                SetImageAlphaRecursive(goldImage[48], alpha3);
                SetActive(false, goldLocks[48]);
                ButtonDisableOrEnable(true, goldUpgrades[48]);
            }
            #endregion

            #region Upgrade 47
            if (upgradeNumber == 47)
            {
                goldGreenOutlines[46].SetActive(true);
                SetImageAlphaRecursive(goldImage[46], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[46]);

                SetActive(true, goldGreenLines[50]);
                SetImageAlphaRecursive(goldImage[49], alpha3);
                SetActive(false, goldLocks[49]);
                ButtonDisableOrEnable(true, goldUpgrades[49]);
            }
            #endregion

            #region Upgrade 48
            if (upgradeNumber == 48)
            {
                goldGreenOutlines[47].SetActive(true);
                SetImageAlphaRecursive(goldImage[47], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[47]);

                SetActive(true, goldGreenLines[51]);
                SetActive(false, goldLocks[50]);

                if (G_Upgrade51Purchased == false)
                {
                    SetImageAlphaRecursive(goldImage[50], alpha3);
                    ButtonDisableOrEnable(true, goldUpgrades[50]);
                }
            }
            #endregion

            #region Upgrade 49
            if (upgradeNumber == 49)
            {
                goldGreenOutlines[48].SetActive(true);
                SetImageAlphaRecursive(goldImage[48], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[48]);

                SetActive(true, goldGreenLines[52]);
                SetActive(false, goldLocks[50]);

                if (G_Upgrade51Purchased == false)
                {
                    SetImageAlphaRecursive(goldImage[50], alpha3);
                    ButtonDisableOrEnable(true, goldUpgrades[50]);
                }
            }
            #endregion

            #region Upgrade 50
            if (upgradeNumber == 50)
            {
                goldGreenOutlines[49].SetActive(true);
                SetImageAlphaRecursive(goldImage[49], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[49]);
                SetActive(false, goldLocks[50]);

                SetActive(true, goldGreenLines[53]);

                if (G_Upgrade51Purchased == false)
                {
                    SetImageAlphaRecursive(goldImage[50], alpha3);
                    ButtonDisableOrEnable(true, goldUpgrades[50]);
                }
            }
            #endregion

            #region Upgrade 51 BIG
            if (upgradeNumber == 51)
            {
                goldGreenOutlines[50].SetActive(true);
                SetImageAlphaRecursive(goldImage[50], 1f);
                ButtonDisableOrEnable(false, goldUpgrades[50]);

                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, goldUpgrades[50]); }
            }
            #endregion
        }
    }
    #endregion

    #region Prestige Pegs Branch
    public GameObject[] prestigeGreenLines;
    public GameObject[] prestigeLocks;
    public Button[] prestigeUpgrades;
    public Image[] prestigeImage;
    public GameObject[] prestigeGreenOutLines;

    public static int prestigePointsIncrease;
    public static float prestigePegChance;
    public static int prestigeClearHitsNeeded;
    public static float prestigeBucketChance;

    #region Perstige Upgrades booleans
    public static bool PU_Upgrade1Purchased;
    public static bool PU_Upgrade2Purchased;
    public static bool PU_Upgrade3Purchased;
    public static bool PU_Upgrade4Purchased;
    public static bool PU_Upgrade5Purchased;
    public static bool PU_Upgrade6Purchased;
    public static bool PU_Upgrade7Purchased;
    public static bool PU_Upgrade8Purchased;
    public static bool PU_Upgrade9Purchased;
    public static bool PU_Upgrade10Purchased;
    public static bool PU_Upgrade11Purchased;
    public static bool PU_Upgrade12Purchased;
    public static bool PU_Upgrade13Purchased;
    public static bool PU_Upgrade14Purchased;
    public static bool PU_Upgrade15Purchased;
    public static bool PU_Upgrade16Purchased;
    public static bool PU_Upgrade17Purchased;
    public static bool PU_Upgrade18Purchased;
    public static bool PU_Upgrade19Purchased;
    public static bool PU_Upgrade20Purchased;
    public static bool PU_Upgrade21Purchased;
    public static bool PU_Upgrade22Purchased;
    public static bool PU_Upgrade23Purchased;
    public static bool PU_Upgrade24Purchased;
    public static bool PU_Upgrade25Purchased;
    public static bool PU_Upgrade26Purchased;
    public static bool PU_Upgrade27Purchased;
    public static bool PU_Upgrade28Purchased;
    public static bool PU_Upgrade29Purchased;
    public static bool PU_Upgrade30Purchased;
    public static bool PU_Upgrade31Purchased;
    public static bool PU_Upgrade32Purchased;
    public static bool PU_Upgrade33Purchased;
    public static bool PU_Upgrade34Purchased;
    public static bool PU_Upgrade35Purchased;
    public static bool PU_Upgrade36Purchased;
    public static bool PU_Upgrade37Purchased;
    public static bool PU_Upgrade38Purchased;
    public static bool PU_Upgrade39Purchased;
    public static bool PU_Upgrade40Purchased;
    public static bool PU_Upgrade41Purchased;
    public static bool PU_Upgrade42Purchased;
    public static bool PU_Upgrade43Purchased;
    public static bool PU_Upgrade44Purchased;
    #endregion

    public void PrestigePegsUpgrade(int upgradeNumber )
    {
        if (MobileScript.isMobile == true) { ClickSound(); }
        if (PrestigeToolTip.isMobilePrestigeOpen == false && MobileScript.isMobile == true) { return; }
        if (isOnlyViewing == false)
        {
            if (prestigePoints >= PrestigeToolTip.prestigePointPrice)
            {
                if (reachedOver500 == true) { reachedOver500 = false; }
                AllStats.totalPrestigePointSpent += PrestigeToolTip.prestigePointPrice;
                if (ppOverflow == false) { prestigePoints -= PrestigeToolTip.prestigePointPrice; }
                else { prestigePointsOverFlow -= PrestigeToolTip.prestigePointPrice; }
                UpgradeSound();
                SetPresitgeUpgrade(upgradeNumber);

                #region Upgrade 1 BIG
                if (upgradeNumber == 1)
                {
                    PU_Upgrade1Purchased = true;

                    prestigePointsIncrease += 1;
                    prestigePegChance += prestigePegChanceIncrease1;
                }
                #endregion

                #region Upgrade 2
                if (upgradeNumber == 2)
                {
                    PU_Upgrade2Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease2;
                }
                #endregion

                #region Upgrade 3
                if (upgradeNumber == 3)
                {
                    PU_Upgrade3Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease3;
                }
                #endregion

                #region Upgrade 4
                if (upgradeNumber == 4)
                {
                    PU_Upgrade4Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease4;
                }
                #endregion

                #region Upgrade 5
                if (upgradeNumber == 5)
                {
                    PU_Upgrade5Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease5;
                }
                #endregion

                #region Upgrade 6
                if (upgradeNumber == 6)
                {
                    PU_Upgrade6Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease6;
                }
                #endregion

                #region Upgrade 7
                if (upgradeNumber == 7)
                {
                    PU_Upgrade7Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease7;
                }
                #endregion

                #region Upgrade 8
                if (upgradeNumber == 8)
                {
                    PU_Upgrade8Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease8;
                }
                #endregion

                #region Upgrade 9
                if (upgradeNumber == 9)
                {
                    PU_Upgrade9Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease9;
                }
                #endregion

                #region Upgrade 10
                if (upgradeNumber == 10)
                {
                    PU_Upgrade10Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease10;
                }
                #endregion

                #region Upgrade 11
                if (upgradeNumber == 11)
                {
                    PU_Upgrade11Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease11;
                }
                #endregion

                #region Upgrade 12 BIG
                if (upgradeNumber == 12)
                {
                    PU_Upgrade12Purchased = true;
                    prestigePointsIncrease += 1;
                    prestigeClearHitsNeeded = prestigeClearBonus1;
                }
                #endregion

                #region Upgrade 13
                if (upgradeNumber == 13)
                {
                    PU_Upgrade13Purchased = true;
                    prestigeClearHitsNeeded = prestigeClearBonus2;
                }
                #endregion

                #region Upgrade 14
                if (upgradeNumber == 14)
                {
                    PU_Upgrade14Purchased = true;
                    prestigeClearHitsNeeded = prestigeClearBonus3;
                }
                #endregion
                
                #region Upgrade 15
                if (upgradeNumber == 15)
                {
                    PU_Upgrade15Purchased = true;
                    prestigeClearHitsNeeded = prestigeClearBonus4;
                }
                #endregion

                #region Upgrade 16 BIG
                if (upgradeNumber == 16)
                {
                    PU_Upgrade16Purchased = true;
                    prestigePointsIncrease += 1;
                    prestigeClearHitsNeeded = prestigeClearBonus5;
                }
                #endregion

                #region Upgrade 17
                if (upgradeNumber == 17)
                {
                    PU_Upgrade17Purchased = true;
                    prestigeBucketChance = bucketPrestigePointChance1;
                }
                #endregion

                #region Upgrade 18
                if (upgradeNumber == 18)
                {
                    PU_Upgrade18Purchased = true;
                    prestigeBucketChance = bucketPrestigePointChance2;
                }
                #endregion

                #region Upgrade 19
                if (upgradeNumber == 19)
                {
                    PU_Upgrade19Purchased = true;
                    prestigeBucketChance = bucketPrestigePointChance3;
                }
                #endregion

                #region Upgrade 20 BIG
                if (upgradeNumber == 20)
                {
                    PU_Upgrade20Purchased = true;
                    prestigeBucketChance = bucketPrestigePointChance4;
                }
                #endregion

                #region Upgrade 21
                if (upgradeNumber == 21)
                {
                    PU_Upgrade21Purchased = true;
                }
                #endregion

                #region Upgrade 22
                if (upgradeNumber == 22)
                {
                    PU_Upgrade22Purchased = true;
                }
                #endregion

                #region Upgrade 23
                if (upgradeNumber == 23)
                {
                    PU_Upgrade23Purchased = true;
                }
                #endregion

                #region Upgrade 24 BIG
                if (upgradeNumber == 24)
                {
                    PU_Upgrade24Purchased = true;
                }
                #endregion

                #region Upgrade 25
                if (upgradeNumber == 25)
                {
                    PU_Upgrade25Purchased = true;
                    prestigePegChance += newPrestigeIncrease1;
                }
                #endregion

                #region Upgrade 26
                if (upgradeNumber == 26)
                {
                    PU_Upgrade26Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease12;
                }
                #endregion

                #region Upgrade 27
                if (upgradeNumber == 27)
                {
                    PU_Upgrade27Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease13;
                }
                #endregion

                #region Upgrade 28 BIG
                if (upgradeNumber == 28)
                {
                    PU_Upgrade28Purchased = true;
                    prestigePointsIncrease += 1;
                }
                #endregion

                #region Upgrade 29
                if (upgradeNumber == 29)
                {
                    PU_Upgrade29Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease14;
                }
                #endregion

                #region Upgrade 30
                if (upgradeNumber == 30)
                {
                    PU_Upgrade30Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease15;
                }
                #endregion

                #region Upgrade 31
                if (upgradeNumber == 31)
                {
                    PU_Upgrade31Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease16;
                }
                #endregion

                #region Upgrade 32
                if (upgradeNumber == 32)
                {
                    PU_Upgrade32Purchased = true;
                    prestigePegChance += newPrestigeIncrease2;
                   
                }
                #endregion

                #region Upgrade 33
                if (upgradeNumber == 33)
                {
                    PU_Upgrade33Purchased = true;
                    prestigePegChance += newPrestigeIncrease2;
                }
                #endregion

                #region Upgrade 34
                if (upgradeNumber == 34)
                {
                    PU_Upgrade34Purchased = true;
                    prestigePegChance += newPrestigeIncrease3;
                }
                #endregion

                #region Upgrade 35
                if (upgradeNumber == 35)
                {
                    PU_Upgrade35Purchased = true;
                    prestigePointsIncrease += 1;
                }
                #endregion

                #region Upgrade 36
                if (upgradeNumber == 36)
                {
                    PU_Upgrade36Purchased = true;
                    prestigePointsIncrease += 1;
                }
                #endregion

                #region Upgrade 37
                if (upgradeNumber == 37)
                {
                    PU_Upgrade37Purchased = true;
                    prestigePointsIncrease += 1;
                }
                #endregion

                #region Upgrade 38
                if (upgradeNumber == 38)
                {
                    PU_Upgrade38Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease17;
                }
                #endregion

                #region Upgrade 39
                if (upgradeNumber == 39)
                {
                    PU_Upgrade39Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease18;
                }
                #endregion

                #region Upgrade 40
                if (upgradeNumber == 40)
                {
                    PU_Upgrade40Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease19;
                }
                #endregion

                #region Upgrade 41
                if (upgradeNumber == 41)
                {
                    PU_Upgrade41Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease20;
                }
                #endregion

                #region Upgrade 42
                if (upgradeNumber == 42)
                {
                    PU_Upgrade42Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease21;
                }
                #endregion

                #region Upgrade 43
                if (upgradeNumber == 43)
                {
                    PU_Upgrade43Purchased = true;
                    prestigePegChance += prestigePegChanceIncrease22;
                }
                #endregion

                #region Upgrade 44 BIG
                if (upgradeNumber == 44)
                {
                    PU_Upgrade44Purchased = true;
                }
                #endregion
            }
            else { audioManager.Play("CantAfford"); }
        }
    }

    public void SetPresitgeUpgrade(int upgradeNumber)
    {
        #region Upgrade 1
        if (upgradeNumber == 1)
        {
            prestigeGreenOutLines[0].SetActive(true);
            SetImageAlphaRecursive(prestigeImage[0], 1f);
            ButtonDisableOrEnable(false, prestigeUpgrades[0]);

            if(GameData.isDemo == false)
            {
                SetActive(true, prestigeGreenLines[1]);
                SetActive(true, prestigeGreenLines[2]);
                SetImageAlphaRecursive(prestigeImage[1], alpha3);
                SetImageAlphaRecursive(prestigeImage[2], alpha3);
                SetActive(false, prestigeLocks[1]);
                SetActive(false, prestigeLocks[2]);
                ButtonDisableOrEnable(true, prestigeUpgrades[1]);
                ButtonDisableOrEnable(true, prestigeUpgrades[2]);
            }
        }
        #endregion

        if(GameData.isDemo == false)
        {
            #region Upgrade 2
            if (upgradeNumber == 2)
            {
                prestigeGreenOutLines[1].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[1], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[1]);

                SetActive(true, prestigeGreenLines[3]);
                SetImageAlphaRecursive(prestigeImage[3], alpha3);
                SetActive(false, prestigeLocks[3]);
                ButtonDisableOrEnable(true, prestigeUpgrades[3]);
            }
            #endregion

            #region Upgrade 3
            if (upgradeNumber == 3)
            {
                prestigeGreenOutLines[2].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[2], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[2]);

                SetActive(true, prestigeGreenLines[4]);
                SetImageAlphaRecursive(prestigeImage[4], alpha3);
                SetActive(false, prestigeLocks[4]);
                ButtonDisableOrEnable(true, prestigeUpgrades[4]);
            }
            #endregion

            #region Upgrade 4
            if (upgradeNumber == 4)
            {
                prestigeGreenOutLines[3].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[3], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[3]);

                SetActive(true, prestigeGreenLines[5]);
                SetImageAlphaRecursive(prestigeImage[5], alpha3);
                SetActive(false, prestigeLocks[5]);
                ButtonDisableOrEnable(true, prestigeUpgrades[5]);
            }
            #endregion

            #region Upgrade 5
            if (upgradeNumber == 5)
            {
                prestigeGreenOutLines[4].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[4], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[4]);

                SetActive(true, prestigeGreenLines[6]);
                SetImageAlphaRecursive(prestigeImage[6], alpha3);
                SetActive(false, prestigeLocks[6]);
                ButtonDisableOrEnable(true, prestigeUpgrades[6]);
            }
            #endregion

            #region Upgrade 6
            if (upgradeNumber == 6)
            {
                prestigeGreenOutLines[5].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[5], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[5]);

                SetActive(true, prestigeGreenLines[7]);
                SetImageAlphaRecursive(prestigeImage[7], alpha3);
                SetActive(false, prestigeLocks[7]);
                ButtonDisableOrEnable(true, prestigeUpgrades[7]);
            }
            #endregion

            #region Upgrade 7
            if (upgradeNumber == 7)
            {
                prestigeGreenOutLines[6].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[6], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[6]);

                SetActive(true, prestigeGreenLines[8]);
                SetImageAlphaRecursive(prestigeImage[8], alpha3);
                SetActive(false, prestigeLocks[8]);
                ButtonDisableOrEnable(true, prestigeUpgrades[8]);
            }
            #endregion

            #region Upgrade 8
            if (upgradeNumber == 8)
            {
                prestigeGreenOutLines[7].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[7], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[7]);

                SetActive(true, prestigeGreenLines[9]);
                SetImageAlphaRecursive(prestigeImage[9], alpha3);
                SetActive(false, prestigeLocks[9]);
                ButtonDisableOrEnable(true, prestigeUpgrades[9]);
            }
            #endregion

            #region Upgrade 9
            if (upgradeNumber == 9)
            {
                prestigeGreenOutLines[8].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[8], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[8]);

                SetActive(true, prestigeGreenLines[10]);
                SetImageAlphaRecursive(prestigeImage[10], alpha3);
                SetActive(false, prestigeLocks[10]);
                ButtonDisableOrEnable(true, prestigeUpgrades[10]);
            }
            #endregion

            #region Upgrade 10
            if (upgradeNumber == 10)
            {
                prestigeGreenOutLines[9].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[9], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[9]);

                SetActive(true, prestigeGreenLines[11]);
                SetActive(false, prestigeLocks[11]);

                if (PU_Upgrade12Purchased == false)
                {
                    SetImageAlphaRecursive(prestigeImage[11], alpha3);
                    ButtonDisableOrEnable(true, prestigeUpgrades[11]);
                }
            }
            #endregion

            #region Upgrade 11
            if (upgradeNumber == 11)
            {
                prestigeGreenOutLines[10].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[10], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[10]);

                SetActive(true, prestigeGreenLines[12]);
                SetActive(false, prestigeLocks[11]);

                if (PU_Upgrade12Purchased == false)
                {
                    SetImageAlphaRecursive(prestigeImage[11], alpha3);
                    ButtonDisableOrEnable(true, prestigeUpgrades[11]);
                }
            }
            #endregion

            #region Upgrade 12 BIG
            if (upgradeNumber == 12)
            {
                prestigeGreenOutLines[11].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[11], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[11]);
                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, prestigeUpgrades[11]); }

                SetActive(true, prestigeGreenLines[13]);
                SetActive(true, prestigeGreenLines[21]);
                SetActive(true, prestigeGreenLines[29]);
                SetActive(true, prestigeGreenLines[30]);
                SetActive(true, prestigeGreenLines[31]);

                SetImageAlphaRecursive(prestigeImage[12], alpha3);
                SetImageAlphaRecursive(prestigeImage[20], alpha3);
                SetImageAlphaRecursive(prestigeImage[28], alpha3);
                SetImageAlphaRecursive(prestigeImage[29], alpha3);
                SetImageAlphaRecursive(prestigeImage[30], alpha3);

                SetActive(false, prestigeLocks[12]);
                SetActive(false, prestigeLocks[20]);
                SetActive(false, prestigeLocks[28]);
                SetActive(false, prestigeLocks[29]);
                SetActive(false, prestigeLocks[30]);

                ButtonDisableOrEnable(true, prestigeUpgrades[12]);
                ButtonDisableOrEnable(true, prestigeUpgrades[20]);
                ButtonDisableOrEnable(true, prestigeUpgrades[28]);
                ButtonDisableOrEnable(true, prestigeUpgrades[29]);
                ButtonDisableOrEnable(true, prestigeUpgrades[30]);
            }
            #endregion

            #region Upgrade 13
            if (upgradeNumber == 13)
            {
                prestigeGreenOutLines[12].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[12], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[12]);

                SetActive(true, prestigeGreenLines[14]);
                SetActive(true, prestigeGreenLines[17]);

                SetImageAlphaRecursive(prestigeImage[13], alpha3);
                SetImageAlphaRecursive(prestigeImage[16], alpha3);

                SetActive(false, prestigeLocks[13]);
                SetActive(false, prestigeLocks[16]);

                ButtonDisableOrEnable(true, prestigeUpgrades[13]);
                ButtonDisableOrEnable(true, prestigeUpgrades[16]);
            }
            #endregion

            #region Upgrade 14
            if (upgradeNumber == 14)
            {
                prestigeGreenOutLines[13].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[13], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[13]);

                SetActive(true, prestigeGreenLines[15]);
                SetImageAlphaRecursive(prestigeImage[14], alpha3);
                SetActive(false, prestigeLocks[14]);
                ButtonDisableOrEnable(true, prestigeUpgrades[14]);
            }
            #endregion

            #region Upgrade 15
            if (upgradeNumber == 15)
            {
                prestigeGreenOutLines[14].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[14], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[14]);

                SetActive(true, prestigeGreenLines[16]);
                SetImageAlphaRecursive(prestigeImage[15], alpha3);
                SetActive(false, prestigeLocks[15]);
                ButtonDisableOrEnable(true, prestigeUpgrades[15]);
            }
            #endregion

            #region Upgrade 16 BIG
            if (upgradeNumber == 16)
            {
                prestigeGreenOutLines[15].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[15], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[15]);
            }
            #endregion

            #region Upgrade 17
            if (upgradeNumber == 17)
            {
                prestigeGreenOutLines[16].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[16], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[16]);

                SetActive(true, prestigeGreenLines[18]);
                SetImageAlphaRecursive(prestigeImage[17], alpha3);
                SetActive(false, prestigeLocks[17]);
                ButtonDisableOrEnable(true, prestigeUpgrades[17]);
            }
            #endregion

            #region Upgrade 18
            if (upgradeNumber == 18)
            {
                prestigeGreenOutLines[17].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[17], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[17]);

                SetActive(true, prestigeGreenLines[19]);
                SetImageAlphaRecursive(prestigeImage[18], alpha3);
                SetActive(false, prestigeLocks[18]);
                ButtonDisableOrEnable(true, prestigeUpgrades[18]);
            }
            #endregion

            #region Upgrade 19
            if (upgradeNumber == 19)
            {
                prestigeGreenOutLines[18].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[18], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[18]);

                SetActive(true, prestigeGreenLines[20]);
                SetImageAlphaRecursive(prestigeImage[19], alpha3);
                SetActive(false, prestigeLocks[19]);
                ButtonDisableOrEnable(true, prestigeUpgrades[19]);
            }
            #endregion

            #region Upgrade 20 BIG
            if (upgradeNumber == 20)
            {
                prestigeGreenOutLines[19].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[19], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[19]);
                prestigeBucketChance = bucketPrestigePointChance4;
            }
            #endregion

            #region Upgrade 21
            if (upgradeNumber == 21)
            {
                prestigeGreenOutLines[20].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[20], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[20]);

                SetActive(true, prestigeGreenLines[22]);
                SetImageAlphaRecursive(prestigeImage[21], alpha3);
                SetActive(false, prestigeLocks[21]);
                ButtonDisableOrEnable(true, prestigeUpgrades[21]);
            }
            #endregion

            #region Upgrade 22
            if (upgradeNumber == 22)
            {
                prestigeGreenOutLines[21].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[21], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[21]);

                SetActive(true, prestigeGreenLines[23]);
                SetActive(true, prestigeGreenLines[25]);
                SetImageAlphaRecursive(prestigeImage[22], alpha3);
                SetImageAlphaRecursive(prestigeImage[24], alpha3);
                SetActive(false, prestigeLocks[22]);
                SetActive(false, prestigeLocks[24]);
                ButtonDisableOrEnable(true, prestigeUpgrades[22]);
                ButtonDisableOrEnable(true, prestigeUpgrades[24]);
            }
            #endregion

            #region Upgrade 23
            if (upgradeNumber == 23)
            {
                prestigeGreenOutLines[22].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[22], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[22]);

                SetActive(true, prestigeGreenLines[24]);
                SetImageAlphaRecursive(prestigeImage[23], alpha3);
                SetActive(false, prestigeLocks[23]);
                ButtonDisableOrEnable(true, prestigeUpgrades[23]);
            }
            #endregion

            #region Upgrade 24 BIG
            if (upgradeNumber == 24)
            {
                prestigeGreenOutLines[23].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[23], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[23]);
            }
            #endregion

            #region Upgrade 25
            if (upgradeNumber == 25)
            {
                prestigeGreenOutLines[24].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[24], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[24]);

                SetActive(true, prestigeGreenLines[26]);
                SetImageAlphaRecursive(prestigeImage[25], alpha3);
                SetActive(false, prestigeLocks[25]);
                ButtonDisableOrEnable(true, prestigeUpgrades[25]);
            }
            #endregion

            #region Upgrade 26
            if (upgradeNumber == 26)
            {
                prestigeGreenOutLines[25].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[25], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[25]);

                SetActive(true, prestigeGreenLines[27]);
                SetImageAlphaRecursive(prestigeImage[26], alpha3);
                SetActive(false, prestigeLocks[26]);
                ButtonDisableOrEnable(true, prestigeUpgrades[26]);
            }
            #endregion

            #region Upgrade 27
            if (upgradeNumber == 27)
            {
                prestigeGreenOutLines[26].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[26], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[26]);

                SetActive(true, prestigeGreenLines[28]);
                SetImageAlphaRecursive(prestigeImage[27], alpha3);
                SetActive(false, prestigeLocks[27]);
                ButtonDisableOrEnable(true, prestigeUpgrades[27]);
            }
            #endregion

            #region Upgrade 28 BIG
            if (upgradeNumber == 28)
            {
                prestigeGreenOutLines[27].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[27], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[27]);
            }
            #endregion

            #region Upgrade 29
            if (upgradeNumber == 29)
            {
                prestigeGreenOutLines[28].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[28], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[28]);

                SetActive(true, prestigeGreenLines[32]);
                SetImageAlphaRecursive(prestigeImage[31], alpha3);
                SetActive(false, prestigeLocks[31]);
                ButtonDisableOrEnable(true, prestigeUpgrades[31]);
            }
            #endregion

            #region Upgrade 30
            if (upgradeNumber == 30)
            {
                prestigeGreenOutLines[29].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[29], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[29]);

                SetActive(true, prestigeGreenLines[33]);
                SetImageAlphaRecursive(prestigeImage[32], alpha3);
                SetActive(false, prestigeLocks[32]);
                ButtonDisableOrEnable(true, prestigeUpgrades[32]);
            }
            #endregion

            #region Upgrade 31
            if (upgradeNumber == 31)
            {
                prestigeGreenOutLines[30].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[30], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[30]);

                SetActive(true, prestigeGreenLines[34]);
                SetImageAlphaRecursive(prestigeImage[33], alpha3);
                SetActive(false, prestigeLocks[33]);
                ButtonDisableOrEnable(true, prestigeUpgrades[33]);
            }
            #endregion

            #region Upgrade 32
            if (upgradeNumber == 32)
            {
                prestigeGreenOutLines[31].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[31], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[31]);

                SetActive(true, prestigeGreenLines[35]);
                SetImageAlphaRecursive(prestigeImage[34], alpha3);
                SetActive(false, prestigeLocks[34]);
                ButtonDisableOrEnable(true, prestigeUpgrades[34]);
            }
            #endregion

            #region Upgrade 33
            if (upgradeNumber == 33)
            {
                prestigeGreenOutLines[32].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[32], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[32]);

                SetActive(true, prestigeGreenLines[36]);
                SetImageAlphaRecursive(prestigeImage[35], alpha3);
                SetActive(false, prestigeLocks[35]);
                ButtonDisableOrEnable(true, prestigeUpgrades[35]);
            }
            #endregion

            #region Upgrade 34
            if (upgradeNumber == 34)
            {
                prestigeGreenOutLines[33].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[33], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[33]);

                SetActive(true, prestigeGreenLines[37]);
                SetImageAlphaRecursive(prestigeImage[36], alpha3);
                SetActive(false, prestigeLocks[36]);
                ButtonDisableOrEnable(true, prestigeUpgrades[36]);
            }
            #endregion

            #region Upgrade 35
            if (upgradeNumber == 35)
            {
                prestigeGreenOutLines[34].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[34], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[34]);

                SetActive(true, prestigeGreenLines[38]);
                SetImageAlphaRecursive(prestigeImage[37], alpha3);
                SetActive(false, prestigeLocks[37]);
                ButtonDisableOrEnable(true, prestigeUpgrades[37]);
            }
            #endregion

            #region Upgrade 36
            if (upgradeNumber == 36)
            {
                prestigeGreenOutLines[35].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[35], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[35]);

                SetActive(true, prestigeGreenLines[39]);
                SetImageAlphaRecursive(prestigeImage[38], alpha3);
                SetActive(false, prestigeLocks[38]);
                ButtonDisableOrEnable(true, prestigeUpgrades[38]);
            }
            #endregion

            #region Upgrade 37
            if (upgradeNumber == 37)
            {
                prestigeGreenOutLines[36].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[36], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[36]);

                SetActive(true, prestigeGreenLines[40]);
                SetImageAlphaRecursive(prestigeImage[39], alpha3);
                SetActive(false, prestigeLocks[39]);
                ButtonDisableOrEnable(true, prestigeUpgrades[39]);
            }
            #endregion

            #region Upgrade 38
            if (upgradeNumber == 38)
            {
                prestigeGreenOutLines[37].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[37], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[37]);

                SetActive(true, prestigeGreenLines[41]);
                SetImageAlphaRecursive(prestigeImage[40], alpha3);
                SetActive(false, prestigeLocks[40]);
                ButtonDisableOrEnable(true, prestigeUpgrades[40]);
            }
            #endregion

            #region Upgrade 39
            if (upgradeNumber == 39)
            {
                prestigeGreenOutLines[38].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[38], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[38]);

                SetActive(true, prestigeGreenLines[42]);
                SetImageAlphaRecursive(prestigeImage[41], alpha3);
                SetActive(false, prestigeLocks[41]);
                ButtonDisableOrEnable(true, prestigeUpgrades[41]);
            }
            #endregion

            #region Upgrade 40
            if (upgradeNumber == 40)
            {
                prestigeGreenOutLines[39].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[39], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[39]);

                SetActive(true, prestigeGreenLines[43]);
                SetImageAlphaRecursive(prestigeImage[42], alpha3);
                SetActive(false, prestigeLocks[42]);
                ButtonDisableOrEnable(true, prestigeUpgrades[42]);
            }
            #endregion

            #region Upgrade 41
            if (upgradeNumber == 41)
            {
                prestigeGreenOutLines[40].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[40], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[40]);

                SetActive(true, prestigeGreenLines[44]);
                SetActive(false, prestigeLocks[43]);

                if (PU_Upgrade44Purchased == false)
                {
                    SetImageAlphaRecursive(prestigeImage[43], alpha3);
                    ButtonDisableOrEnable(true, prestigeUpgrades[43]);
                }
            }
            #endregion

            #region Upgrade 42
            if (upgradeNumber == 42)
            {
                prestigeGreenOutLines[41].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[41], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[41]);

                SetActive(true, prestigeGreenLines[45]);
                SetActive(false, prestigeLocks[43]);

                if (PU_Upgrade44Purchased == false)
                {
                    SetImageAlphaRecursive(prestigeImage[43], alpha3);
                    ButtonDisableOrEnable(true, prestigeUpgrades[43]);
                }
            }
            #endregion

            #region Upgrade 43
            if (upgradeNumber == 43)
            {
                prestigeGreenOutLines[42].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[42], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[42]);

                SetActive(true, prestigeGreenLines[46]);
                SetActive(false, prestigeLocks[43]);

                if (PU_Upgrade44Purchased == false)
                {
                    SetImageAlphaRecursive(prestigeImage[43], alpha3);
                    ButtonDisableOrEnable(true, prestigeUpgrades[43]);
                }
            }
            #endregion

            #region Upgrade 44 BIG
            if (upgradeNumber == 44)
            {
                prestigeGreenOutLines[43].SetActive(true);
                SetImageAlphaRecursive(prestigeImage[43], 1f);
                ButtonDisableOrEnable(false, prestigeUpgrades[43]);

                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, prestigeUpgrades[43]); }
            }
            #endregion
        }
    }
    #endregion

    #region New Pegs Branch
    public GameObject[] newPegsGreenLines;
    public GameObject[] newPegsLocks;
    public Button[] newPegsUpgrades;
    public Image[] newPegsImage;
    public GameObject[] newPegGreenOutlines;

    public static float redPegChance, rainbowPegChance, bombPegChance, purplePegChance;
    public static bool isRedPegUnlocked;
    public static float purplePegIncrease;
    public static int bombBallBalls1, bombBallBalls2;

    #region New Pegs Booleans
    public static bool NP_Upgrade1Purchased;
    public static bool NP_Upgrade2Purchased;
    public static bool NP_Upgrade3Purchased;
    public static bool NP_Upgrade4Purchased;
    public static bool NP_Upgrade5Purchased;
    public static bool NP_Upgrade6Purchased;
    public static bool NP_Upgrade7Purchased;
    public static bool NP_Upgrade8Purchased;
    public static bool NP_Upgrade9Purchased;
    public static bool NP_Upgrade10Purchased;
    public static bool NP_Upgrade11Purchased;
    public static bool NP_Upgrade12Purchased;
    public static bool NP_Upgrade13Purchased;
    public static bool NP_Upgrade14Purchased;
    public static bool NP_Upgrade15Purchased;
    public static bool NP_Upgrade16Purchased;
    public static bool NP_Upgrade17Purchased;
    public static bool NP_Upgrade18Purchased;
    public static bool NP_Upgrade19Purchased;
    public static bool NP_Upgrade20Purchased;
    public static bool NP_Upgrade21Purchased;
    public static bool NP_Upgrade22Purchased;
    public static bool NP_Upgrade23Purchased;
    public static bool NP_Upgrade24Purchased;
    public static bool NP_Upgrade25Purchased;
    public static bool NP_Upgrade26Purchased;
    public static bool NP_Upgrade27Purchased;
    public static bool NP_Upgrade28Purchased;
    public static bool NP_Upgrade29Purchased;
    public static bool NP_Upgrade30Purchased;
    public static bool NP_Upgrade31Purchased;
    public static bool NP_Upgrade32Purchased;
    public static bool NP_Upgrade33Purchased;
    public static bool NP_Upgrade34Purchased;
    public static bool NP_Upgrade35Purchased;
    #endregion

    public void NewPegsUpgades(int upgradeNumber)
    {
        if (MobileScript.isMobile == true) { ClickSound(); }
        if (PrestigeToolTip.isMobilePrestigeOpen == false && MobileScript.isMobile == true) { return; }
        if (isOnlyViewing == false)
        {
            if (prestigePoints >= PrestigeToolTip.prestigePointPrice)
            {
                if (reachedOver500 == true) { reachedOver500 = false; }
                AllStats.totalPrestigePointSpent += PrestigeToolTip.prestigePointPrice;
                UpgradeSound();
                SetNewPegs(upgradeNumber);
                if (ppOverflow == false) { prestigePoints -= PrestigeToolTip.prestigePointPrice; }
                else { prestigePointsOverFlow -= PrestigeToolTip.prestigePointPrice; }

                #region Upgrade 1 BIG
                if (upgradeNumber == 1)
                {
                    NP_Upgrade1Purchased = true;
                    isRedPegUnlocked = true;

                    AllStats.totalPegsUnlocked += 1;
                    redPegChance += redPegChance1;
                }
                #endregion

                #region Upgrade 2
                if (upgradeNumber == 2)
                {
                    NP_Upgrade2Purchased = true;
                    redPegChance += redPegChance2;
                }
                #endregion

                #region Upgrade 3
                if (upgradeNumber == 3)
                {
                    NP_Upgrade3Purchased = true;
                    redPegChance += redPegChance3;
                }
                #endregion

                #region Upgrade 4
                if (upgradeNumber == 4)
                {
                    NP_Upgrade4Purchased = true;
                    redPegChance += redPegChance4;
                }
                #endregion

                #region Upgrade 5
                if (upgradeNumber == 5)
                {
                    NP_Upgrade5Purchased = true;
                    redPegChance += redPegChance5;
                }
                #endregion

                #region Upgrade 6
                if (upgradeNumber == 6)
                {
                    NP_Upgrade6Purchased = true;
                }
                #endregion

                #region Upgrade 7
                if (upgradeNumber == 7)
                {
                    NP_Upgrade7Purchased = true;
                }
                #endregion

                #region Upgrade 8 BIG
                if (upgradeNumber == 8)
                {
                    NP_Upgrade8Purchased = true;
                    rainbowPegChance += rainbowPegChance1;
                    AllStats.totalPegsUnlocked += 1;
                }
                #endregion

                #region Upgrade 9
                if (upgradeNumber == 9)
                {
                    NP_Upgrade9Purchased = true;
                    rainbowPegChance += rainbowPegChance2;
                }
                #endregion

                #region Upgrade 10
                if (upgradeNumber == 10)
                {
                    NP_Upgrade10Purchased = true;
                    rainbowPegChance += rainbowPegChance3;
                }
                #endregion

                #region Upgrade 11
                if (upgradeNumber == 11)
                {
                    NP_Upgrade11Purchased = true;
                    rainbowPegChance += rainbowPegChance4;
                }
                #endregion

                #region Upgrade 12
                if (upgradeNumber == 12)
                {
                    NP_Upgrade12Purchased = true;
                    rainbowPegChance += rainbowPegChance5;
                }
                #endregion

                #region Upgrade 13
                if (upgradeNumber == 13)
                {
                    NP_Upgrade13Purchased = true;
                    rainbowPegChance += rainbowPegChance6;
                }
                #endregion

                #region Upgrade 14
                if (upgradeNumber == 14)
                {
                    NP_Upgrade14Purchased = true;
                    rainbowPegChance += rainbowPegChance7;
                }
                #endregion

                #region Upgrade 15 BIG
                if (upgradeNumber == 15)
                {
                    NP_Upgrade15Purchased = true;
                }
                #endregion

                #region Upgrade 16 BIG
                if (upgradeNumber == 16)
                {
                    NP_Upgrade16Purchased = true;
                }
                #endregion

                #region Upgrade 17 BIG
                if (upgradeNumber == 17)
                {
                    NP_Upgrade17Purchased = true;
                    bombPegChance += bombPegChance1;
                    AllStats.totalPegsUnlocked += 1;
                }
                #endregion

                #region Upgrade 18
                if (upgradeNumber == 18)
                {
                    NP_Upgrade18Purchased = true;
                    bombPegChance += bombPegChance2;
                }
                #endregion

                #region Upgrade 19
                if (upgradeNumber == 19)
                {
                    NP_Upgrade19Purchased = true;
                    bombPegChance += bombPegChance3;
                }
                #endregion

                #region Upgrade 20
                if (upgradeNumber == 20)
                {
                    NP_Upgrade20Purchased = true;
                    bombPegChance += bombPegChance4;
                }
                #endregion

                #region Upgrade 21
                if (upgradeNumber == 21)
                {
                    NP_Upgrade21Purchased = true;
                    bombPegChance += bombPegChance5;
                }
                #endregion

                #region Upgrade 22
                if (upgradeNumber == 22)
                {
                    NP_Upgrade22Purchased = true;
                    bombPegChance += bombPegChance6;
                }
                #endregion

                #region Upgrade 23
                if (upgradeNumber == 23)
                {
                    NP_Upgrade23Purchased = true;
                    bombPegChance += bombPegChance7;
                }
                #endregion

                #region Upgrade 24 BIG
                if (upgradeNumber == 24)
                {
                    NP_Upgrade24Purchased = true;
                }
                #endregion

                #region Upgrade 25 BIG
                if (upgradeNumber == 25)
                {
                    NP_Upgrade25Purchased = true;
                }
                #endregion

                #region Upgrade 26 BIG
                if (upgradeNumber == 26)
                {
                    NP_Upgrade26Purchased = true;
                    purplePegChance += purplePegChance1;
                    purplePegIncrease = purplePegEnchanceIncrease1;
                    AllStats.totalPegsUnlocked += 1;
                }
                #endregion

                #region Upgrade 27
                if (upgradeNumber == 27)
                {
                    NP_Upgrade27Purchased = true;
                    purplePegChance += purplePegChance2;
                }
                #endregion

                #region Upgrade 28
                if (upgradeNumber == 28)
                {
                    NP_Upgrade28Purchased = true;
                    purplePegIncrease = purplePegEnchanceIncrease2;
                }
                #endregion

                #region Upgrade 29
                if (upgradeNumber == 29)
                {
                    NP_Upgrade29Purchased = true;
                    purplePegChance += purplePegChance3;
                }
                #endregion

                #region Upgrade 30
                if (upgradeNumber == 30)
                {
                    NP_Upgrade30Purchased = true;
                    purplePegIncrease = purplePegEnchanceIncrease3;
                }
                #endregion

                #region Upgrade 31
                if (upgradeNumber == 31)
                {
                    NP_Upgrade31Purchased = true;
                    purplePegChance += purplePegChance4;
                }
                #endregion

                #region Upgrade 32
                if (upgradeNumber == 32)
                {
                    NP_Upgrade32Purchased = true;
                    purplePegIncrease = purplePegEnchanceIncrease4;
                }
                #endregion

                #region Upgrade 33 BIG
                if (upgradeNumber == 33)
                {
                    NP_Upgrade33Purchased = true;
                }
                #endregion

                #region Upgrade 34 BIG
                if (upgradeNumber == 34)
                {
                    NP_Upgrade34Purchased = true;
                }
                #endregion
            }
            else { audioManager.Play("CantAfford"); }
        }
    }

    public void SetNewPegs(int upgradeNumber)
    {
        #region Upgrade 1 BIG
        if (upgradeNumber == 1)
        {
            newPegGreenOutlines[0].SetActive(true);
            SetImageAlphaRecursive(newPegsImage[0], 1f);
            ButtonDisableOrEnable(false, newPegsUpgrades[0]);

            if (GameData.isDemo == false)
            {
                SetActive(true, newPegsGreenLines[1]);
                SetActive(true, newPegsGreenLines[2]);
                SetImageAlphaRecursive(newPegsImage[1], alpha3);
                SetImageAlphaRecursive(newPegsImage[2], alpha3);
                SetActive(false, newPegsLocks[1]);
                SetActive(false, newPegsLocks[2]);
                ButtonDisableOrEnable(true, newPegsUpgrades[1]);
                ButtonDisableOrEnable(true, newPegsUpgrades[2]);
            }
        }
        #endregion

        if (GameData.isDemo == false)
        {
            #region Upgrade 2
            if (upgradeNumber == 2)
            {
                newPegGreenOutlines[1].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[1], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[1]);

                SetActive(true, newPegsGreenLines[3]);
                SetImageAlphaRecursive(newPegsImage[3], alpha3);
                SetActive(false, newPegsLocks[3]);
                ButtonDisableOrEnable(true, newPegsUpgrades[3]);
            }
            #endregion

            #region Upgrade 3
            if (upgradeNumber == 3)
            {
                newPegGreenOutlines[2].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[2], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[2]);

                SetActive(true, newPegsGreenLines[4]);
                SetImageAlphaRecursive(newPegsImage[4], alpha3);
                SetActive(false, newPegsLocks[4]);
                ButtonDisableOrEnable(true, newPegsUpgrades[4]);
            }
            #endregion

            #region Upgrade 4
            if (upgradeNumber == 4)
            {
                newPegGreenOutlines[3].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[3], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[3]);

                SetActive(true, newPegsGreenLines[5]);
                SetImageAlphaRecursive(newPegsImage[5], alpha3);
                SetActive(false, newPegsLocks[5]);
                ButtonDisableOrEnable(true, newPegsUpgrades[5]);
            }
            #endregion

            #region Upgrade 5
            if (upgradeNumber == 5)
            {
                newPegGreenOutlines[4].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[4], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[4]);

                SetActive(true, newPegsGreenLines[6]);
                SetImageAlphaRecursive(newPegsImage[6], alpha3);
                SetActive(false, newPegsLocks[6]);
                ButtonDisableOrEnable(true, newPegsUpgrades[6]);
            }
            #endregion

            #region Upgrade 6
            if (upgradeNumber == 6)
            {
                newPegGreenOutlines[5].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[5], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[5]);

                SetActive(false, newPegsLocks[16]);

                if (NP_Upgrade17Purchased == false)
                {
                    SetImageAlphaRecursive(newPegsImage[16], alpha3);
                    ButtonDisableOrEnable(true, newPegsUpgrades[16]);
                }

                SetActive(true, newPegsGreenLines[7]);
                SetActive(true, newPegsGreenLines[8]);

                SetImageAlphaRecursive(newPegsImage[7], alpha3);
                SetActive(false, newPegsLocks[7]);
                ButtonDisableOrEnable(true, newPegsUpgrades[7]);
            }
            #endregion

            #region Upgrade 7
            if (upgradeNumber == 7)
            {
                newPegGreenOutlines[6].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[6], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[6]);

                SetActive(true, newPegsGreenLines[9]);
                SetActive(true, newPegsGreenLines[10]);
                SetActive(false, newPegsLocks[16]);

                if (NP_Upgrade17Purchased == false)
                {
                    SetImageAlphaRecursive(newPegsImage[16], alpha3);
                    ButtonDisableOrEnable(true, newPegsUpgrades[16]);
                }

                SetImageAlphaRecursive(newPegsImage[25], alpha3);
                SetActive(false, newPegsLocks[25]);
                ButtonDisableOrEnable(true, newPegsUpgrades[25]);
            }
            #endregion

            #region Upgrade 8 BIG
            if (upgradeNumber == 8)
            {
                newPegGreenOutlines[7].SetActive(true);
                rainbowPegIncrease = 2;

                SetImageAlphaRecursive(newPegsImage[7], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[7]);

                SetActive(true, newPegsGreenLines[11]);
                SetActive(true, newPegsGreenLines[12]);
                SetImageAlphaRecursive(newPegsImage[8], alpha3);
                SetImageAlphaRecursive(newPegsImage[9], alpha3);
                SetActive(false, newPegsLocks[8]);
                SetActive(false, newPegsLocks[9]);
                ButtonDisableOrEnable(true, newPegsUpgrades[8]);
                ButtonDisableOrEnable(true, newPegsUpgrades[9]);
            }
            #endregion

            #region Upgrade 9
            if (upgradeNumber == 9)
            {
                newPegGreenOutlines[8].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[8], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[8]);

                SetActive(true, newPegsGreenLines[13]);
                SetImageAlphaRecursive(newPegsImage[10], alpha3);
                SetActive(false, newPegsLocks[10]);
                ButtonDisableOrEnable(true, newPegsUpgrades[10]);
            }
            #endregion

            #region Upgrade 10
            if (upgradeNumber == 10)
            {
                newPegGreenOutlines[9].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[9], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[9]);

                SetActive(true, newPegsGreenLines[14]);
                SetImageAlphaRecursive(newPegsImage[11], alpha3);
                SetActive(false, newPegsLocks[11]);
                ButtonDisableOrEnable(true, newPegsUpgrades[11]);
            }
            #endregion

            #region Upgrade 11
            if (upgradeNumber == 11)
            {
                newPegGreenOutlines[10].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[10], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[10]);

                SetActive(true, newPegsGreenLines[15]);
                SetImageAlphaRecursive(newPegsImage[12], alpha3);
                SetActive(false, newPegsLocks[12]);
                ButtonDisableOrEnable(true, newPegsUpgrades[12]);
            }
            #endregion

            #region Upgrade 12
            if (upgradeNumber == 12)
            {
                newPegGreenOutlines[11].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[11], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[11]);

                SetActive(true, newPegsGreenLines[16]);
                SetImageAlphaRecursive(newPegsImage[13], alpha3);
                SetActive(false, newPegsLocks[13]);
                ButtonDisableOrEnable(true, newPegsUpgrades[13]);
            }
            #endregion

            #region Upgrade 13
            if (upgradeNumber == 13)
            {
                newPegGreenOutlines[12].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[12], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[12]);

                SetActive(true, newPegsGreenLines[17]);
                SetActive(false, newPegsLocks[14]);

                if (NP_Upgrade15Purchased == false)
                {
                    SetImageAlphaRecursive(newPegsImage[14], alpha3);
                    ButtonDisableOrEnable(true, newPegsUpgrades[14]);
                }
            }
            #endregion

            #region Upgrade 14
            if (upgradeNumber == 14)
            {
                newPegGreenOutlines[13].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[13], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[13]);

                SetActive(true, newPegsGreenLines[18]);
                SetActive(false, newPegsLocks[14]);

                if (NP_Upgrade15Purchased == false)
                {
                    SetImageAlphaRecursive(newPegsImage[14], alpha3);
                    ButtonDisableOrEnable(true, newPegsUpgrades[14]);
                }
            }
            #endregion

            #region Upgrade 15 BIG
            if (upgradeNumber == 15)
            {
                newPegGreenOutlines[14].SetActive(true);
                rainbowPegIncrease = 3;

                SetImageAlphaRecursive(newPegsImage[14], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[14]);
                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, newPegsUpgrades[14]); }

                SetActive(true, newPegsGreenLines[19]);
                SetImageAlphaRecursive(newPegsImage[15], alpha3);
                SetActive(false, newPegsLocks[15]);
                ButtonDisableOrEnable(true, newPegsUpgrades[15]);
            }
            #endregion

            #region Upgrade 16 BIG
            if (upgradeNumber == 16)
            {
                newPegGreenOutlines[15].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[15], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[15]);
            }
            #endregion

            #region Upgrade 17 BIG
            if (upgradeNumber == 17)
            {
                newPegGreenOutlines[16].SetActive(true);
                bombBallBalls1 = 2;
                bombBallBalls2 = 2;
                SetImageAlphaRecursive(newPegsImage[16], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[16]);
                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, newPegsUpgrades[16]); }

                SetActive(true, newPegsGreenLines[20]);
                SetActive(true, newPegsGreenLines[21]);

                SetImageAlphaRecursive(newPegsImage[17], alpha3);
                SetImageAlphaRecursive(newPegsImage[18], alpha3);
                SetActive(false, newPegsLocks[17]);
                SetActive(false, newPegsLocks[18]);
                ButtonDisableOrEnable(true, newPegsUpgrades[17]);
                ButtonDisableOrEnable(true, newPegsUpgrades[18]);
            }
            #endregion

            #region Upgrade 18
            if (upgradeNumber == 18)
            {
                newPegGreenOutlines[17].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[17], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[17]);

                SetActive(true, newPegsGreenLines[22]);
                SetImageAlphaRecursive(newPegsImage[19], alpha3);
                SetActive(false, newPegsLocks[19]);
                ButtonDisableOrEnable(true, newPegsUpgrades[19]);
            }
            #endregion

            #region Upgrade 19
            if (upgradeNumber == 19)
            {
                newPegGreenOutlines[18].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[18], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[18]);

                SetActive(true, newPegsGreenLines[23]);
                SetImageAlphaRecursive(newPegsImage[20], alpha3);
                SetActive(false, newPegsLocks[20]);
                ButtonDisableOrEnable(true, newPegsUpgrades[20]);
            }
            #endregion

            #region Upgrade 20
            if (upgradeNumber == 20)
            {
                newPegGreenOutlines[19].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[19], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[19]);

                SetActive(true, newPegsGreenLines[24]);
                SetImageAlphaRecursive(newPegsImage[21], alpha3);
                SetActive(false, newPegsLocks[21]);
                ButtonDisableOrEnable(true, newPegsUpgrades[21]);
            }
            #endregion

            #region Upgrade 21
            if (upgradeNumber == 21)
            {
                newPegGreenOutlines[20].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[20], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[20]);

                SetActive(true, newPegsGreenLines[25]);
                SetImageAlphaRecursive(newPegsImage[22], alpha3);
                SetActive(false, newPegsLocks[22]);
                ButtonDisableOrEnable(true, newPegsUpgrades[22]);
            }
            #endregion

            #region Upgrade 22
            if (upgradeNumber == 22)
            {
                newPegGreenOutlines[21].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[21], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[21]);

                SetActive(true, newPegsGreenLines[26]);
                SetActive(false, newPegsLocks[23]);

                if (NP_Upgrade24Purchased == false)
                {
                    SetImageAlphaRecursive(newPegsImage[23], alpha3);
                    ButtonDisableOrEnable(true, newPegsUpgrades[23]);
                }
            }
            #endregion

            #region Upgrade 23
            if (upgradeNumber == 23)
            {
                newPegGreenOutlines[22].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[22], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[22]);

                SetActive(true, newPegsGreenLines[27]);
                SetActive(false, newPegsLocks[23]);

                if (NP_Upgrade24Purchased == false)
                {
                    SetImageAlphaRecursive(newPegsImage[23], alpha3);
                    ButtonDisableOrEnable(true, newPegsUpgrades[23]);
                }
            }
            #endregion

            #region Upgrade 24 BIG
            if (upgradeNumber == 24)
            {
                newPegGreenOutlines[23].SetActive(true);
                bombBallBalls1 = 3;
                bombBallBalls2 = 3;
                SetImageAlphaRecursive(newPegsImage[23], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[23]);
                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, newPegsUpgrades[23]); }

                SetActive(true, newPegsGreenLines[28]);
                SetImageAlphaRecursive(newPegsImage[24], alpha3);
                SetActive(false, newPegsLocks[24]);
                ButtonDisableOrEnable(true, newPegsUpgrades[24]);
            }
            #endregion

            #region Upgrade 25 BIG
            if (upgradeNumber == 25)
            {
                newPegGreenOutlines[24].SetActive(true);
                bombBallBalls1 = 3;
                bombBallBalls2 = 5;
                SetImageAlphaRecursive(newPegsImage[24], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[24]);
            }
            #endregion

            #region Upgrade 26 BIG
            if (upgradeNumber == 26)
            {
                newPegGreenOutlines[25].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[25], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[25]);
                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, newPegsUpgrades[25]); }

                SetActive(true, newPegsGreenLines[29]);
                SetActive(true, newPegsGreenLines[30]);
                SetImageAlphaRecursive(newPegsImage[26], alpha3);
                SetImageAlphaRecursive(newPegsImage[27], alpha3);
                SetActive(false, newPegsLocks[26]);
                SetActive(false, newPegsLocks[27]);
                ButtonDisableOrEnable(true, newPegsUpgrades[26]);
                ButtonDisableOrEnable(true, newPegsUpgrades[27]);
            }
            #endregion

            #region Upgrade 27
            if (upgradeNumber == 27)
            {
                newPegGreenOutlines[26].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[26], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[26]);

                SetActive(true, newPegsGreenLines[31]);
                SetImageAlphaRecursive(newPegsImage[28], alpha3);
                SetActive(false, newPegsLocks[28]);
                ButtonDisableOrEnable(true, newPegsUpgrades[28]);
            }
            #endregion

            #region Upgrade 28
            if (upgradeNumber == 28)
            {
                newPegGreenOutlines[27].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[27], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[27]);

                SetActive(true, newPegsGreenLines[32]);
                SetImageAlphaRecursive(newPegsImage[29], alpha3);
                SetActive(false, newPegsLocks[29]);
                ButtonDisableOrEnable(true, newPegsUpgrades[29]);
            }
            #endregion

            #region Upgrade 29
            if (upgradeNumber == 29)
            {
                newPegGreenOutlines[28].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[28], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[28]);

                SetActive(true, newPegsGreenLines[33]);
                SetImageAlphaRecursive(newPegsImage[30], alpha3);
                SetActive(false, newPegsLocks[30]);
                ButtonDisableOrEnable(true, newPegsUpgrades[30]);
            }
            #endregion

            #region Upgrade 30
            if (upgradeNumber == 30)
            {
                newPegGreenOutlines[29].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[29], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[29]);

                SetActive(true, newPegsGreenLines[34]);
                SetImageAlphaRecursive(newPegsImage[31], alpha3);
                SetActive(false, newPegsLocks[31]);
                ButtonDisableOrEnable(true, newPegsUpgrades[31]);
            }
            #endregion

            #region Upgrade 31
            if (upgradeNumber == 31)
            {
                newPegGreenOutlines[30].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[30], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[30]);

                SetActive(true, newPegsGreenLines[35]);
                SetActive(false, newPegsLocks[32]);

                if (NP_Upgrade33Purchased == false)
                {
                    SetImageAlphaRecursive(newPegsImage[32], alpha3);
                    ButtonDisableOrEnable(true, newPegsUpgrades[32]);
                }
            }
            #endregion

            #region Upgrade 32
            if (upgradeNumber == 32)
            {
                newPegGreenOutlines[31].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[31], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[31]);

                SetActive(true, newPegsGreenLines[36]);
                SetActive(false, newPegsLocks[32]);

                if (NP_Upgrade33Purchased == false)
                {
                    SetImageAlphaRecursive(newPegsImage[32], alpha3);
                    ButtonDisableOrEnable(true, newPegsUpgrades[32]);
                }
            }
            #endregion

            #region Upgrade 33 BIG
            if (upgradeNumber == 33)
            {
                newPegGreenOutlines[32].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[32], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[32]);
                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, newPegsUpgrades[32]); }

                SetActive(true, newPegsGreenLines[37]);
                SetImageAlphaRecursive(newPegsImage[33], alpha3);
                SetActive(false, newPegsLocks[33]);
                ButtonDisableOrEnable(true, newPegsUpgrades[33]);
            }
            #endregion

            #region Upgrade 34 BIG
            if (upgradeNumber == 34)
            {
                newPegGreenOutlines[33].SetActive(true);
                SetImageAlphaRecursive(newPegsImage[33], 1f);
                ButtonDisableOrEnable(false, newPegsUpgrades[33]);
            }
            #endregion
        }
    }

    #endregion

    #region Active Play Branch
    public GameObject[] activePlayGreenLines;
    public GameObject[] activePlayLocks;
    public Button[] activePlayUpgrades;
    public Image[] activePlayImage;
    public GameObject[] activeGreenOutLines;

    public static float activeGoldIncrease;
    public static double startWithGold;
    public static int extraPrestigePoints;
    public static float goldFromShooting;

    #region Active Booleans
    public static bool A_Upgrade1Purchased;
    public static bool A_Upgrade2Purchased;
    public static bool A_Upgrade3Purchased;
    public static bool A_Upgrade4Purchased;
    public static bool A_Upgrade5Purchased;
    public static bool A_Upgrade6Purchased;
    public static bool A_Upgrade7Purchased;
    public static bool A_Upgrade8Purchased;
    public static bool A_Upgrade9Purchased;
    public static bool A_Upgrade10Purchased;
    public static bool A_Upgrade11Purchased;
    public static bool A_Upgrade12Purchased;
    public static bool A_Upgrade13Purchased;
    public static bool A_Upgrade14Purchased;
    public static bool A_Upgrade15Purchased;
    public static bool A_Upgrade16Purchased;
    public static bool A_Upgrade17Purchased;
    public static bool A_Upgrade18Purchased;
    public static bool A_Upgrade19Purchased;
    public static bool A_Upgrade20Purchased;
    public static bool A_Upgrade21Purchased;
    public static bool A_Upgrade22Purchased;
    public static bool A_Upgrade23Purchased;
    public static bool A_Upgrade24Purchased;
    public static bool A_Upgrade25Purchased;
    public static bool A_Upgrade26Purchased;
    public static bool A_Upgrade27Purchased;
    public static bool A_Upgrade28Purchased;
    public static bool A_Upgrade29Purchased;
    public static bool A_Upgrade30Purchased;
    public static bool A_Upgrade31Purchased;
    public static bool A_Upgrade32Purchased;
    public static bool A_Upgrade33Purchased;
    #endregion

    public void ActivePlayUpgrades(int upgradeNumber)
    {
        if (MobileScript.isMobile == true) { ClickSound(); }
        if (PrestigeToolTip.isMobilePrestigeOpen == false && MobileScript.isMobile == true) { return; }

        if (isOnlyViewing == false)
        {
            if (prestigePoints >= PrestigeToolTip.prestigePointPrice)
            {
                if (reachedOver500 == true) { reachedOver500 = false; }
                AllStats.totalPrestigePointSpent += PrestigeToolTip.prestigePointPrice;
                UpgradeSound();
                if (ppOverflow == false) { prestigePoints -= PrestigeToolTip.prestigePointPrice; }
                else { prestigePointsOverFlow -= PrestigeToolTip.prestigePointPrice; }
                SetActiveUpgrades(upgradeNumber);

                #region Upgrade 1 BIG
                if (upgradeNumber == 1)
                {
                    A_Upgrade1Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease1;
                }
                #endregion

                #region Upgrade 2
                if (upgradeNumber == 2)
                {
                    A_Upgrade2Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease2;
                }
                #endregion

                #region Upgrade 3
                if (upgradeNumber == 3)
                {
                    A_Upgrade3Purchased = true;
                    if(startWithGold < goldStart1) { startWithGold = goldStart1; }
                }
                #endregion

                #region Upgrade 4
                if (upgradeNumber == 4)
                {
                    A_Upgrade4Purchased = true;

                    activeGoldIncrease += ballShotGoldIncrease3;
                }
                #endregion

                #region Upgrade 5
                if (upgradeNumber == 5)
                {
                    A_Upgrade5Purchased = true;
                    if (startWithGold < goldStart2) { startWithGold = goldStart2; }
                }
                #endregion

                #region Upgrade 6 BIG
                if (upgradeNumber == 6)
                {
                    A_Upgrade6Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease4;
                    startWithGold = goldStart3;
                }
                #endregion

                #region Upgrade 7
                if (upgradeNumber == 7)
                {
                    A_Upgrade7Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease5;
                }
                #endregion

                #region Upgrade 8
                if (upgradeNumber == 8)
                {
                    A_Upgrade8Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease6;
                }
                #endregion

                #region Upgrade 9
                if (upgradeNumber == 9)
                {
                    A_Upgrade9Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease7;
                }
                #endregion

                #region Upgrade 10 BIG
                if (upgradeNumber == 10)
                {
                    A_Upgrade10Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease8;
                }
                #endregion

                #region Upgrade 11
                if (upgradeNumber == 11)
                {
                    A_Upgrade11Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease9;
                }
                #endregion

                #region Upgrade 12
                if (upgradeNumber == 12)
                {
                    A_Upgrade12Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease10;
                }
                #endregion

                #region Upgrade 13
                if (upgradeNumber == 13)
                {
                    A_Upgrade13Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease11;
                }
                #endregion

                #region Upgrade 14
                if (upgradeNumber == 14)
                {
                    A_Upgrade14Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease12;
                }
                #endregion

                #region Upgrade 15
                if (upgradeNumber == 15)
                {
                    A_Upgrade15Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease13;
                }
                #endregion

                #region Upgrade 16
                if (upgradeNumber == 16)
                {
                    A_Upgrade16Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease14;
                }
                #endregion

                #region Upgrade 17 BIG
                if (upgradeNumber == 17)
                {
                    A_Upgrade17Purchased = true;
                    activeGoldIncrease += ballShotGoldIncrease15;
                }
                #endregion

                #region Upgrade 18
                if (upgradeNumber == 18)
                {
                    A_Upgrade18Purchased = true;
                    extraPrestigePoints = shotPrestigePointIncrease1;
                }
                #endregion

                #region Upgrade 19
                if (upgradeNumber == 19)
                {
                    A_Upgrade19Purchased = true;
                    extraPrestigePoints = shotPrestigePointIncrease2;
                }
                #endregion

                #region Upgrade 20
                if (upgradeNumber == 20)
                {
                    A_Upgrade20Purchased = true;
                    extraPrestigePoints = shotPrestigePointIncrease3;
                }
                #endregion

                #region Upgrade 21 BIG
                if (upgradeNumber == 21)
                {
                    A_Upgrade21Purchased = true;
                    extraPrestigePoints = shotPrestigePointIncrease4;
                }
                #endregion

                #region Upgrade 22
                if (upgradeNumber == 22)
                {
                    A_Upgrade22Purchased = true;
                    goldFromShooting = goldFromShot1;
                }
                #endregion

                #region Upgrade 23
                if (upgradeNumber == 23)
                {
                    A_Upgrade23Purchased = true;
                    goldFromShooting = goldFromShot2;
                }
                #endregion

                #region Upgrade 24
                if (upgradeNumber == 24)
                {
                    A_Upgrade24Purchased = true;
                    goldFromShooting = goldFromShot3;
                }
                #endregion

                #region Upgrade 25
                if (upgradeNumber == 25)
                {
                    A_Upgrade25Purchased = true;
                    goldFromShooting = goldFromShot4;
                }
                #endregion

                #region Upgrade 26
                if (upgradeNumber == 26)
                {
                    A_Upgrade26Purchased = true;
                    goldFromShooting = goldFromShot5;
                }
                #endregion

                #region Upgrade 27
                if (upgradeNumber == 27)
                {
                    A_Upgrade27Purchased = true;
                    goldFromShooting = goldFromShot6;
                }
                #endregion

                #region Upgrade 28 BIG
                if (upgradeNumber == 28)
                {
                    A_Upgrade28Purchased = true;
                    goldFromShooting = goldFromShot7;
                }
                #endregion

                #region Upgrade 29
                if (upgradeNumber == 29)
                {
                    A_Upgrade29Purchased = true;
                    startWithGold = goldStart4;
                }
                #endregion

                #region Upgrade 30
                if (upgradeNumber == 30)
                {
                    A_Upgrade30Purchased = true;
                    startWithGold = goldStart5;
                }
                #endregion

                #region Upgrade 31
                if (upgradeNumber == 31)
                {
                    A_Upgrade31Purchased = true;
                    startWithGold = goldStart6;
                }
                #endregion

                #region Upgrade 32
                if (upgradeNumber == 32)
                {
                    A_Upgrade32Purchased = true;
                    startWithGold = goldStart7;
                }
                #endregion

                #region Upgrade 33 BIG
                if (upgradeNumber == 33)
                {
                    A_Upgrade33Purchased = true;
                    startWithGold = goldStart8;
                }
                #endregion
            }
            else { audioManager.Play("CantAfford"); }
        }
    }

    public void SetActiveUpgrades(int upgradeNumber)
    {
        #region Upgrade 1
        if (upgradeNumber == 1)
        {
            activeGreenOutLines[0].SetActive(true);
            SetImageAlphaRecursive(activePlayImage[0], 1f);
            ButtonDisableOrEnable(false, activePlayUpgrades[0]);

            if(GameData.isDemo == false)
            {
                SetActive(true, activePlayGreenLines[1]);
                SetActive(true, activePlayGreenLines[2]);
                SetImageAlphaRecursive(activePlayImage[1], alpha3);
                SetImageAlphaRecursive(activePlayImage[2], alpha3);
                SetActive(false, activePlayLocks[1]);
                SetActive(false, activePlayLocks[2]);
                ButtonDisableOrEnable(true, activePlayUpgrades[1]);
                ButtonDisableOrEnable(true, activePlayUpgrades[2]);
            }
        }
        #endregion

        if (GameData.isDemo == false)
        {
            #region Upgrade 2
            if (upgradeNumber == 2)
            {
                activeGreenOutLines[1].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[1], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[1]);

                SetActive(true, activePlayGreenLines[3]);
                SetImageAlphaRecursive(activePlayImage[3], alpha3);
                SetActive(false, activePlayLocks[3]);
                ButtonDisableOrEnable(true, activePlayUpgrades[3]);
            }
            #endregion

            #region Upgrade 3
            if (upgradeNumber == 3)
            {
                activeGreenOutLines[2].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[2], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[2]);

                SetActive(true, activePlayGreenLines[4]);
                SetImageAlphaRecursive(activePlayImage[4], alpha3);
                SetActive(false, activePlayLocks[4]);
                ButtonDisableOrEnable(true, activePlayUpgrades[4]);
            }
            #endregion

            #region Upgrade 4
            if (upgradeNumber == 4)
            {
                activeGreenOutLines[3].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[3], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[3]);

                SetActive(true, activePlayGreenLines[5]);
                SetActive(false, activePlayLocks[5]);

                if (A_Upgrade6Purchased == false)
                {
                    SetImageAlphaRecursive(activePlayImage[5], alpha3);
                    ButtonDisableOrEnable(true, activePlayUpgrades[5]);
                }
            }
            #endregion

            #region Upgrade 5
            if (upgradeNumber == 5)
            {
                activeGreenOutLines[4].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[4], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[4]);

                SetActive(true, activePlayGreenLines[6]);
                SetActive(false, activePlayLocks[5]);

                if (A_Upgrade6Purchased == false)
                {
                    SetImageAlphaRecursive(activePlayImage[5], alpha3);
                    ButtonDisableOrEnable(true, activePlayUpgrades[5]);
                }
            }
            #endregion

            #region Upgrade 6 BIG
            if (upgradeNumber == 6)
            {
                activeGreenOutLines[5].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[5], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[5]);
                if (MobileScript.isMobile == true) { ButtonDisableOrEnable(true, activePlayUpgrades[5]); }

                SetActive(true, activePlayGreenLines[7]);
                SetActive(true, activePlayGreenLines[11]);
                SetActive(true, activePlayGreenLines[18]);
                SetActive(true, activePlayGreenLines[22]);
                SetActive(true, activePlayGreenLines[29]);

                SetImageAlphaRecursive(activePlayImage[6], alpha3);
                SetImageAlphaRecursive(activePlayImage[10], alpha3);
                SetImageAlphaRecursive(activePlayImage[17], alpha3);
                SetImageAlphaRecursive(activePlayImage[21], alpha3);
                SetImageAlphaRecursive(activePlayImage[28], alpha3);
                SetActive(false, activePlayLocks[6]);
                SetActive(false, activePlayLocks[10]);
                SetActive(false, activePlayLocks[17]);
                SetActive(false, activePlayLocks[21]);
                SetActive(false, activePlayLocks[28]);
                ButtonDisableOrEnable(true, activePlayUpgrades[6]);
                ButtonDisableOrEnable(true, activePlayUpgrades[10]);
                ButtonDisableOrEnable(true, activePlayUpgrades[17]);
                ButtonDisableOrEnable(true, activePlayUpgrades[21]);
                ButtonDisableOrEnable(true, activePlayUpgrades[28]);
            }
            #endregion

            #region Upgrade 7
            if (upgradeNumber == 7)
            {
                activeGreenOutLines[6].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[6], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[6]);

                SetActive(true, activePlayGreenLines[8]);
                SetImageAlphaRecursive(activePlayImage[7], alpha3);
                SetActive(false, activePlayLocks[7]);
                ButtonDisableOrEnable(true, activePlayUpgrades[7]);
            }
            #endregion

            #region Upgrade 8
            if (upgradeNumber == 8)
            {
                activeGreenOutLines[7].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[7], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[7]);

                SetActive(true, activePlayGreenLines[9]);
                SetImageAlphaRecursive(activePlayImage[8], alpha3);
                SetActive(false, activePlayLocks[8]);
                ButtonDisableOrEnable(true, activePlayUpgrades[8]);
            }
            #endregion

            #region Upgrade 9
            if (upgradeNumber == 9)
            {
                activeGreenOutLines[8].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[8], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[8]);

                SetActive(true, activePlayGreenLines[10]);
                SetImageAlphaRecursive(activePlayImage[9], alpha3);
                SetActive(false, activePlayLocks[9]);
                ButtonDisableOrEnable(true, activePlayUpgrades[9]);
            }
            #endregion

            #region Upgrade 10 BIG
            if (upgradeNumber == 10)
            {
                activeGreenOutLines[9].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[9], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[9]);
            }
            #endregion

            #region Upgrade 11
            if (upgradeNumber == 11)
            {
                activeGreenOutLines[10].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[10], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[10]);

                SetActive(true, activePlayGreenLines[12]);
                SetImageAlphaRecursive(activePlayImage[11], alpha3);
                SetActive(false, activePlayLocks[11]);
                ButtonDisableOrEnable(true, activePlayUpgrades[11]);
            }
            #endregion

            #region Upgrade 12
            if (upgradeNumber == 12)
            {
                activeGreenOutLines[11].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[11], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[11]);

                SetActive(true, activePlayGreenLines[13]);
                SetImageAlphaRecursive(activePlayImage[12], alpha3);
                SetActive(false, activePlayLocks[12]);
                ButtonDisableOrEnable(true, activePlayUpgrades[12]);
            }
            #endregion

            #region Upgrade 13
            if (upgradeNumber == 13)
            {
                activeGreenOutLines[12].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[12], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[12]);

                SetActive(true, activePlayGreenLines[14]);
                SetImageAlphaRecursive(activePlayImage[13], alpha3);
                SetActive(false, activePlayLocks[13]);
                ButtonDisableOrEnable(true, activePlayUpgrades[13]);
            }
            #endregion

            #region Upgrade 14
            if (upgradeNumber == 14)
            {
                activeGreenOutLines[13].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[13], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[13]);

                SetActive(true, activePlayGreenLines[15]);
                SetImageAlphaRecursive(activePlayImage[14], alpha3);
                SetActive(false, activePlayLocks[14]);
                ButtonDisableOrEnable(true, activePlayUpgrades[14]);
            }
            #endregion

            #region Upgrade 15
            if (upgradeNumber == 15)
            {
                activeGreenOutLines[14].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[14], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[14]);

                SetActive(true, activePlayGreenLines[16]);
                SetImageAlphaRecursive(activePlayImage[15], alpha3);
                SetActive(false, activePlayLocks[15]);
                ButtonDisableOrEnable(true, activePlayUpgrades[15]);
            }
            #endregion

            #region Upgrade 16
            if (upgradeNumber == 16)
            {
                activeGreenOutLines[15].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[15], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[15]);

                SetActive(true, activePlayGreenLines[17]);
                SetImageAlphaRecursive(activePlayImage[16], alpha3);
                SetActive(false, activePlayLocks[16]);
                ButtonDisableOrEnable(true, activePlayUpgrades[16]);
            }
            #endregion

            #region Upgrade 17 BIG
            if (upgradeNumber == 17)
            {
                activeGreenOutLines[16].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[16], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[16]);
            }
            #endregion

            #region Upgrade 18
            if (upgradeNumber == 18)
            {
                activeGreenOutLines[17].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[17], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[17]);

                SetActive(true, activePlayGreenLines[19]);
                SetImageAlphaRecursive(activePlayImage[18], alpha3);
                SetActive(false, activePlayLocks[18]);
                ButtonDisableOrEnable(true, activePlayUpgrades[18]);
            }
            #endregion

            #region Upgrade 19
            if (upgradeNumber == 19)
            {
                activeGreenOutLines[18].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[18], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[18]);

                SetActive(true, activePlayGreenLines[20]);
                SetImageAlphaRecursive(activePlayImage[19], alpha3);
                SetActive(false, activePlayLocks[19]);
                ButtonDisableOrEnable(true, activePlayUpgrades[19]);
            }
            #endregion

            #region Upgrade 20
            if (upgradeNumber == 20)
            {
                activeGreenOutLines[19].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[19], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[19]);

                SetActive(true, activePlayGreenLines[21]);
                SetImageAlphaRecursive(activePlayImage[20], alpha3);
                SetActive(false, activePlayLocks[20]);
                ButtonDisableOrEnable(true, activePlayUpgrades[20]);
            }
            #endregion

            #region Upgrade 21 BIG
            if (upgradeNumber == 21)
            {
                activeGreenOutLines[20].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[20], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[20]);
            }
            #endregion

            #region Upgrade 22
            if (upgradeNumber == 22)
            {
                activeGreenOutLines[21].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[21], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[21]);

                SetActive(true, activePlayGreenLines[23]);
                SetImageAlphaRecursive(activePlayImage[22], alpha3);
                SetActive(false, activePlayLocks[22]);
                ButtonDisableOrEnable(true, activePlayUpgrades[22]);
            }
            #endregion

            #region Upgrade 23
            if (upgradeNumber == 23)
            {
                activeGreenOutLines[22].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[22], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[22]);

                SetActive(true, activePlayGreenLines[24]);
                SetImageAlphaRecursive(activePlayImage[23], alpha3);
                SetActive(false, activePlayLocks[23]);
                ButtonDisableOrEnable(true, activePlayUpgrades[23]);
            }
            #endregion

            #region Upgrade 24
            if (upgradeNumber == 24)
            {
                activeGreenOutLines[23].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[23], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[23]);

                SetActive(true, activePlayGreenLines[25]);
                SetImageAlphaRecursive(activePlayImage[24], alpha3);
                SetActive(false, activePlayLocks[24]);
                ButtonDisableOrEnable(true, activePlayUpgrades[24]);
            }
            #endregion

            #region Upgrade 25
            if (upgradeNumber == 25)
            {
                activeGreenOutLines[24].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[24], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[24]);

                SetActive(true, activePlayGreenLines[26]);
                SetImageAlphaRecursive(activePlayImage[25], alpha3);
                SetActive(false, activePlayLocks[25]);
                ButtonDisableOrEnable(true, activePlayUpgrades[25]);
            }
            #endregion

            #region Upgrade 26
            if (upgradeNumber == 26)
            {
                activeGreenOutLines[25].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[25], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[25]);

                SetActive(true, activePlayGreenLines[27]);
                SetImageAlphaRecursive(activePlayImage[26], alpha3);
                SetActive(false, activePlayLocks[26]);
                ButtonDisableOrEnable(true, activePlayUpgrades[26]);
            }
            #endregion

            #region Upgrade 27
            if (upgradeNumber == 27)
            {
                activeGreenOutLines[26].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[26], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[26]);

                SetActive(true, activePlayGreenLines[28]);
                SetImageAlphaRecursive(activePlayImage[27], alpha3);
                SetActive(false, activePlayLocks[27]);
                ButtonDisableOrEnable(true, activePlayUpgrades[27]);
            }
            #endregion

            #region Upgrade 28 BIG
            if (upgradeNumber == 28)
            {
                activeGreenOutLines[27].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[27], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[27]);
            }
            #endregion

            #region Upgrade 29
            if (upgradeNumber == 29)
            {
                activeGreenOutLines[28].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[28], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[28]);

                SetActive(true, activePlayGreenLines[30]);
                SetImageAlphaRecursive(activePlayImage[29], alpha3);
                SetActive(false, activePlayLocks[29]);
                ButtonDisableOrEnable(true, activePlayUpgrades[29]);
            }
            #endregion

            #region Upgrade 30
            if (upgradeNumber == 30)
            {
                activeGreenOutLines[29].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[29], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[29]);

                SetActive(true, activePlayGreenLines[31]);
                SetImageAlphaRecursive(activePlayImage[30], alpha3);
                SetActive(false, activePlayLocks[30]);
                ButtonDisableOrEnable(true, activePlayUpgrades[30]);
            }
            #endregion

            #region Upgrade 31
            if (upgradeNumber == 31)
            {
                activeGreenOutLines[30].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[30], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[30]);

                SetActive(true, activePlayGreenLines[32]);
                SetImageAlphaRecursive(activePlayImage[31], alpha3);
                SetActive(false, activePlayLocks[31]);
                ButtonDisableOrEnable(true, activePlayUpgrades[31]);
            }
            #endregion

            #region Upgrade 32
            if (upgradeNumber == 32)
            {
                activeGreenOutLines[31].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[31], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[31]);

                SetActive(true, activePlayGreenLines[33]);
                SetImageAlphaRecursive(activePlayImage[32], alpha3);
                SetActive(false, activePlayLocks[32]);
                ButtonDisableOrEnable(true, activePlayUpgrades[32]);
            }
            #endregion

            #region Upgrade 33 BIG
            if (upgradeNumber == 33)
            {
                activeGreenOutLines[32].SetActive(true);
                SetImageAlphaRecursive(activePlayImage[32], 1f);
                ButtonDisableOrEnable(false, activePlayUpgrades[32]);
            }
            #endregion
        }
    }

    #endregion

    #region More Shots BRanch
    public GameObject[] moreShotsLines;
    public GameObject[] moreShotsLocks;
    public Button[] moreShotsUpgrades;
    public Image[] moreShotsImage;
    public GameObject[] moreShotsGreenOutlines;

    public static int totalBallShots;
    public static int ball1MS, ball2MS, ball3MS, ball4MS, ball5MS, ball6MS, ball7MS, ball8MS, ball9MS, ball10MS, ball11MS, ball12MS, ball13MS, ball14MS, ball15MS, ball16MS, ball17MS, ball18MS, ball19MS, ball20MS, ball21MS, ball22MS;

    #region Active Booleans
    public static bool moreShots1Purchased;
    public static bool moreShots2Purchased;
    public static bool moreShots3Purchased;
    public static bool moreShots4Purchased;
    #endregion

    public void MoreShotsUpgrades(int upgradeNumber)
    {
        if (MobileScript.isMobile == true) { ClickSound(); }
        if (PrestigeToolTip.isMobilePrestigeOpen == false && MobileScript.isMobile == true) { return; }
        if (isOnlyViewing == false)
        {
            if (prestigePoints >= PrestigeToolTip.prestigePointPrice)
            {
                AllStats.totalPrestigePointSpent += PrestigeToolTip.prestigePointPrice;
                UpgradeSound();
                if (ppOverflow == false) { prestigePoints -= PrestigeToolTip.prestigePointPrice; }
                else { prestigePointsOverFlow -= PrestigeToolTip.prestigePointPrice; }
                SetMoreShots(upgradeNumber);

                if (upgradeNumber == 1)
                {
                    totalBallShots = 2;
                    moreShots1Purchased = true;
                }
                if (upgradeNumber == 2)
                {
                    totalBallShots = 3;
                    moreShots2Purchased = true;
                }
                if (upgradeNumber == 3)
                {
                    totalBallShots = 4;
                    moreShots3Purchased = true;
                }
                if (upgradeNumber == 4)
                {
                    totalBallShots = 5;
                    moreShots4Purchased = true;
                }


                if (achScript != null) { achScript.Check2XorMoreShots(); }
            }
            else { audioManager.Play("CantAfford"); }
        }
    }

    public void SetMoreShots(int upgradeNumber)
    {
        #region Upgrade 1
        if (upgradeNumber == 1)
        {
            moreShotsGreenOutlines[0].SetActive(true);
            SetImageAlphaRecursive(moreShotsImage[0], 1);
            ButtonDisableOrEnable(false, moreShotsUpgrades[0]);

            SetActive(true, moreShotsLines[1]);
            SetImageAlphaRecursive(moreShotsImage[1], alpha3);
            ButtonDisableOrEnable(true, moreShotsUpgrades[1]);
            SetActive(false, moreShotsLocks[1]);
        }
        #endregion

        #region Upgrade 2
        if (upgradeNumber == 2)
        {
            moreShotsGreenOutlines[1].SetActive(true);
            SetImageAlphaRecursive(moreShotsImage[1], 1);
            ButtonDisableOrEnable(false, moreShotsUpgrades[1]);

            SetActive(true, moreShotsLines[2]);
            SetImageAlphaRecursive(moreShotsImage[2], alpha3);
            ButtonDisableOrEnable(true, moreShotsUpgrades[2]);
            SetActive(false, moreShotsLocks[2]);
        }
        #endregion

        #region Upgrade 3
        if (upgradeNumber == 3)
        {
            moreShotsGreenOutlines[2].SetActive(true);
            SetImageAlphaRecursive(moreShotsImage[2], 1);
            ButtonDisableOrEnable(false, moreShotsUpgrades[2]);

            SetActive(true, moreShotsLines[3]);
            SetImageAlphaRecursive(moreShotsImage[3], alpha3);
            ButtonDisableOrEnable(true, moreShotsUpgrades[3]);
            SetActive(false, moreShotsLocks[3]);
        }
        #endregion

        #region Upgrade 4
        if (upgradeNumber == 4)
        {
            moreShotsGreenOutlines[3].SetActive(true);
            SetImageAlphaRecursive(moreShotsImage[3], 1);
            ButtonDisableOrEnable(false, moreShotsUpgrades[3]);
        }
        #endregion
    }

    #endregion


    //Mobile
    #region Mobile purchase button
    public GameObject buffTooltip, buffClose, buffDark, prestigePurchase;

    public void MobilePurchaseBTN()
    {
        if(PrestigeToolTip.isMobilePrestigeOpen == true)
        {
            if (PrestigeToolTip.upgradeNumberTooltip == 0) { FirstPrestigeUpgrade(true); }

            #region Gold
            if(PrestigeToolTip.isGoldUpgradeMobile == true)
            {
                if (PrestigeToolTip.upgradeNumberTooltip == 1) { GoldBranchUpgrade(1); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 2) { GoldBranchUpgrade(2); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 3) { GoldBranchUpgrade(3); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 4) { GoldBranchUpgrade(4); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 5) { GoldBranchUpgrade(5); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 6) { GoldBranchUpgrade(6); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 7) { GoldBranchUpgrade(7); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 8) { GoldBranchUpgrade(8); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 9) { GoldBranchUpgrade(9); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 10) { GoldBranchUpgrade(10); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 11) { GoldBranchUpgrade(11); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 12) { GoldBranchUpgrade(12); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 13) { GoldBranchUpgrade(13); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 14) { GoldBranchUpgrade(14); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 15) { GoldBranchUpgrade(15); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 16) { GoldBranchUpgrade(16); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 17) { GoldBranchUpgrade(17); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 18) { GoldBranchUpgrade(18); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 19) { GoldBranchUpgrade(19); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 20) { GoldBranchUpgrade(20); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 21) { GoldBranchUpgrade(21); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 22) { GoldBranchUpgrade(22); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 23) { GoldBranchUpgrade(23); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 24) { GoldBranchUpgrade(24); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 25) { GoldBranchUpgrade(25); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 26) { GoldBranchUpgrade(26); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 27) { GoldBranchUpgrade(27); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 28) { GoldBranchUpgrade(28); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 29) { GoldBranchUpgrade(29); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 30) { GoldBranchUpgrade(30); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 31) { GoldBranchUpgrade(31); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 32) { GoldBranchUpgrade(32); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 33) { GoldBranchUpgrade(33); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 34) { GoldBranchUpgrade(34); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 35) { GoldBranchUpgrade(35); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 36) { GoldBranchUpgrade(36); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 37) { GoldBranchUpgrade(37); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 38) { GoldBranchUpgrade(38); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 39) { GoldBranchUpgrade(39); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 40) { GoldBranchUpgrade(40); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 41) { GoldBranchUpgrade(41); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 42) { GoldBranchUpgrade(42); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 43) { GoldBranchUpgrade(43); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 44) { GoldBranchUpgrade(44); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 45) { GoldBranchUpgrade(45); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 46) { GoldBranchUpgrade(46); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 47) { GoldBranchUpgrade(47); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 48) { GoldBranchUpgrade(48); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 49) { GoldBranchUpgrade(49); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 50) { GoldBranchUpgrade(50); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 51) { GoldBranchUpgrade(51); }
            }

            #endregion

            #region Level
            if (PrestigeToolTip.isNewLevelUpgradeMobile == true)
            {
                if (PrestigeToolTip.upgradeNumberTooltip == 2) { NewLevelUpgrade(2); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 3) { NewLevelUpgrade(3); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 4) { NewLevelUpgrade(4); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 5) { NewLevelUpgrade(5); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 6) { NewLevelUpgrade(6); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 7) { NewLevelUpgrade(7); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 8) { NewLevelUpgrade(8); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 9) { NewLevelUpgrade(9); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 10) { NewLevelUpgrade(10); }
            }
            #endregion

            #region Prestige
            if (PrestigeToolTip.isPrestigeUpgradeMobile == true)
            {
                if (PrestigeToolTip.upgradeNumberTooltip == 1) { PrestigePegsUpgrade(1); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 2) { PrestigePegsUpgrade(2); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 3) { PrestigePegsUpgrade(3); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 4) { PrestigePegsUpgrade(4); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 5) { PrestigePegsUpgrade(5); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 6) { PrestigePegsUpgrade(6); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 7) { PrestigePegsUpgrade(7); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 8) { PrestigePegsUpgrade(8); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 9) { PrestigePegsUpgrade(9); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 10) { PrestigePegsUpgrade(10); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 11) { PrestigePegsUpgrade(11); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 12) { PrestigePegsUpgrade(12); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 13) { PrestigePegsUpgrade(13); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 14) { PrestigePegsUpgrade(14); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 15) { PrestigePegsUpgrade(15); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 16) { PrestigePegsUpgrade(16); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 17) { PrestigePegsUpgrade(17); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 18) { PrestigePegsUpgrade(18); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 19) { PrestigePegsUpgrade(19); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 20) { PrestigePegsUpgrade(20); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 21) { PrestigePegsUpgrade(21); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 22) { PrestigePegsUpgrade(22); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 23) { PrestigePegsUpgrade(23); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 24) { PrestigePegsUpgrade(24); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 25) { PrestigePegsUpgrade(25); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 26) { PrestigePegsUpgrade(26); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 27) { PrestigePegsUpgrade(27); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 28) { PrestigePegsUpgrade(28); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 29) { PrestigePegsUpgrade(29); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 30) { PrestigePegsUpgrade(30); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 31) { PrestigePegsUpgrade(31); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 32) { PrestigePegsUpgrade(32); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 33) { PrestigePegsUpgrade(33); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 34) { PrestigePegsUpgrade(34); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 35) { PrestigePegsUpgrade(35); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 36) { PrestigePegsUpgrade(36); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 37) { PrestigePegsUpgrade(37); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 38) { PrestigePegsUpgrade(38); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 39) { PrestigePegsUpgrade(39); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 40) { PrestigePegsUpgrade(40); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 41) { PrestigePegsUpgrade(41); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 42) { PrestigePegsUpgrade(42); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 43) { PrestigePegsUpgrade(43); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 44) { PrestigePegsUpgrade(44); }
            }
            #endregion

            #region New pegs
            if (PrestigeToolTip.isNewPegUpgradeMobile == true)
            {
                if (PrestigeToolTip.upgradeNumberTooltip == 1) { NewPegsUpgades(1); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 2) { NewPegsUpgades(2); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 3) { NewPegsUpgades(3); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 4) { NewPegsUpgades(4); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 5) { NewPegsUpgades(5); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 6) { NewPegsUpgades(6); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 7) { NewPegsUpgades(7); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 8) { NewPegsUpgades(8); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 9) { NewPegsUpgades(9); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 10) { NewPegsUpgades(10); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 11) { NewPegsUpgades(11); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 12) { NewPegsUpgades(12); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 13) { NewPegsUpgades(13); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 14) { NewPegsUpgades(14); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 15) { NewPegsUpgades(15); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 16) { NewPegsUpgades(16); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 17) { NewPegsUpgades(17); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 18) { NewPegsUpgades(18); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 19) { NewPegsUpgades(19); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 20) { NewPegsUpgades(20); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 21) { NewPegsUpgades(21); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 22) { NewPegsUpgades(22); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 23) { NewPegsUpgades(23); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 24) { NewPegsUpgades(24); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 25) { NewPegsUpgades(25); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 26) { NewPegsUpgades(26); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 27) { NewPegsUpgades(27); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 28) { NewPegsUpgades(28); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 29) { NewPegsUpgades(29); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 30) { NewPegsUpgades(30); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 31) { NewPegsUpgades(31); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 32) { NewPegsUpgades(32); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 33) { NewPegsUpgades(33); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 34) { NewPegsUpgades(34); }
            }
            #endregion

            #region Active
            if (PrestigeToolTip.isActiveUpgradeMobile == true)
            {
                if (PrestigeToolTip.upgradeNumberTooltip == 1) { ActivePlayUpgrades(1); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 2) { ActivePlayUpgrades(2); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 3) { ActivePlayUpgrades(3); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 4) { ActivePlayUpgrades(4); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 5) { ActivePlayUpgrades(5); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 6) { ActivePlayUpgrades(6); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 7) { ActivePlayUpgrades(7); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 8) { ActivePlayUpgrades(8); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 9) { ActivePlayUpgrades(9); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 10) { ActivePlayUpgrades(10); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 11) { ActivePlayUpgrades(11); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 12) { ActivePlayUpgrades(12); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 13) { ActivePlayUpgrades(13); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 14) { ActivePlayUpgrades(14); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 15) { ActivePlayUpgrades(15); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 16) { ActivePlayUpgrades(16); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 17) { ActivePlayUpgrades(17); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 18) { ActivePlayUpgrades(18); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 19) { ActivePlayUpgrades(19); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 20) { ActivePlayUpgrades(20); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 21) { ActivePlayUpgrades(21); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 22) { ActivePlayUpgrades(22); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 23) { ActivePlayUpgrades(23); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 24) { ActivePlayUpgrades(24); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 25) { ActivePlayUpgrades(25); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 26) { ActivePlayUpgrades(26); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 27) { ActivePlayUpgrades(27); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 28) { ActivePlayUpgrades(28); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 29) { ActivePlayUpgrades(29); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 30) { ActivePlayUpgrades(30); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 31) { ActivePlayUpgrades(31); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 32) { ActivePlayUpgrades(32); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 33) { ActivePlayUpgrades(33); }
            }
            #endregion

            #region More shots
            if (PrestigeToolTip.isMoreShotsUpgradeMobile == true)
            {
                if (PrestigeToolTip.upgradeNumberTooltip == 1) { MoreShotsUpgrades(1); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 2) { MoreShotsUpgrades(2); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 3) { MoreShotsUpgrades(3); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 4) { MoreShotsUpgrades(4); }
                else if (PrestigeToolTip.upgradeNumberTooltip == 5) { MoreShotsUpgrades(5); }
            }
            #endregion

            buffTooltip.SetActive(false);
            buffClose.SetActive(false);
            buffDark.SetActive(false);
            prestigePurchase.SetActive(false);
            BuffsToolTip.buffCurrentlyHovering = 0;
            PrestigeToolTip.isMobilePrestigeOpen = false;
        }
    }
    #endregion


    #region Set gameobject active or inactive
    public void SetActive(bool active, GameObject prestigeObject) 
    { 
        if(active == true) 
        { 
            prestigeObject.SetActive(true);
            StartCoroutine(GreenGlowAnim(prestigeObject));
        }
        else
        {
            prestigeObject.SetActive(false);
        }
    }
    #endregion

    #region Set Button Enabled or Disabled
    public void ButtonDisableOrEnable(bool enable, Button button)
    {
        if(enable == true)
        {
            button.interactable = true;
        }
        else
        {
            if (MobileScript.isMobile == true) { return; }

            button.interactable = false;
        }
    }
    #endregion

    #region Set Alpha
    public void SetImageAlphaRecursive(Image image, float alpha)
    {
        // Set the alpha value of the current image
        SetAlpha(image, alpha);

        // Set the alpha value for all child images recursively
        SetChildrenAlphaRecursive(image.transform, alpha);
    }

    // Recursive method to set alpha for all child images
    private void SetChildrenAlphaRecursive(Transform parent, float alpha)
    {
        foreach (Transform child in parent)
        {
            // Check if the child has an Image component
            Image childImage = child.GetComponent<Image>();
            if (childImage != null)
            {
                // Set the alpha value of the child image
                SetAlpha(childImage, alpha);
            }

            // Recursively set alpha for child's children
            SetChildrenAlphaRecursive(child, alpha);
        }
    }

    // Helper method to set alpha for an Image component
    private void SetAlpha(Image image, float alpha)
    {
        Color currentColor = image.color;
        currentColor.a = alpha;
        image.color = currentColor;
    }
    #endregion

    #region Green line anim
    IEnumerator GreenGlowAnim(GameObject line)
    {
        line.GetComponent<Image>().fillAmount = 0f;

        float greenLineAnimTime = 0f;
        float greenLineMaxTime = 1f;

        while (greenLineAnimTime < greenLineMaxTime)
        {
            greenLineAnimTime += 0.11f;
            line.GetComponent<Image>().fillAmount = greenLineAnimTime;
            yield return new WaitForSeconds(0.03f);
        }

        line.GetComponent<Image>().fillAmount = 1;
    }
    #endregion

    #region Set buttons false
    public void SetAllButtonFalse()
    {
        firstUpgradeButton.interactable = false;
        for (int i = 0; i < goldUpgrades.Length; i++)
        {
            goldUpgrades[i].interactable = false;
        }

        for (int i = 0; i < newLevelUpgrades.Length; i++)
        {
            newLevelUpgrades[i].interactable = false;
        }

        for (int i = 0; i < prestigeUpgrades.Length; i++)
        {
            prestigeUpgrades[i].interactable = false;
        }

        for (int i = 0; i < newPegsUpgrades.Length; i++)
        {
            newPegsUpgrades[i].interactable = false;
        }

        for (int i = 0; i < activePlayUpgrades.Length; i++)
        {
            activePlayUpgrades[i].interactable = false;
        }

        for (int i = 0; i < moreShotsUpgrades.Length; i++)
        {
            moreShotsUpgrades[i].interactable = false;
        }
    }
    #endregion

    #region Reset all
    public void ResetPrestige()
    {
        isRedPegUnlocked = false;
        purchasedFirstUpgrade = false;

        G_Upgrade1Purchased = false;
        G_Upgrade2Purchased = false;
        G_Upgrade3Purchased = false;
        G_Upgrade4Purchased = false;
        G_Upgrade5Purchased = false;
        G_Upgrade6Purchased = false;
        G_Upgrade7Purchased = false;
        G_Upgrade8Purchased = false;
        G_Upgrade9Purchased = false;
        G_Upgrade10Purchased = false;
        G_Upgrade11Purchased = false;
        G_Upgrade12Purchased = false;
        G_Upgrade13Purchased = false;
        G_Upgrade14Purchased = false;
        G_Upgrade15Purchased = false;
        G_Upgrade16Purchased = false;
        G_Upgrade17Purchased = false;
        G_Upgrade18Purchased = false;
        G_Upgrade19Purchased = false;
        G_Upgrade20Purchased = false;
        G_Upgrade21Purchased = false;
        G_Upgrade22Purchased = false;
        G_Upgrade23Purchased = false;
        G_Upgrade24Purchased = false;
        G_Upgrade25Purchased = false;
        G_Upgrade26Purchased = false;
        G_Upgrade27Purchased = false;
        G_Upgrade28Purchased = false;
        G_Upgrade29Purchased = false;
        G_Upgrade30Purchased = false;
        G_Upgrade31Purchased = false;
        G_Upgrade32Purchased = false;
        G_Upgrade33Purchased = false;
        G_Upgrade34Purchased = false;
        G_Upgrade35Purchased = false;
        G_Upgrade36Purchased = false;
        G_Upgrade37Purchased = false;
        G_Upgrade38Purchased = false;
        G_Upgrade39Purchased = false;
        G_Upgrade40Purchased = false;
        G_Upgrade41Purchased = false;
        G_Upgrade42Purchased = false;
        G_Upgrade43Purchased = false;
        G_Upgrade44Purchased = false;
        G_Upgrade45Purchased = false;
        G_Upgrade46Purchased = false;
        G_Upgrade47Purchased = false;
        G_Upgrade48Purchased = false;
        G_Upgrade49Purchased = false;
        G_Upgrade50Purchased = false;
        G_Upgrade51Purchased = false;

        NP_Upgrade1Purchased = false;
        NP_Upgrade2Purchased = false;
        NP_Upgrade3Purchased = false;
        NP_Upgrade4Purchased = false;
        NP_Upgrade5Purchased = false;
        NP_Upgrade6Purchased = false;
        NP_Upgrade7Purchased = false;
        NP_Upgrade8Purchased = false;
        NP_Upgrade9Purchased = false;
        NP_Upgrade10Purchased = false;
        NP_Upgrade11Purchased = false;
        NP_Upgrade12Purchased = false;
        NP_Upgrade13Purchased = false;
        NP_Upgrade14Purchased = false;
        NP_Upgrade15Purchased = false;
        NP_Upgrade16Purchased = false;
        NP_Upgrade17Purchased = false;
        NP_Upgrade18Purchased = false;
        NP_Upgrade19Purchased = false;
        NP_Upgrade20Purchased = false;
        NP_Upgrade21Purchased = false;
        NP_Upgrade22Purchased = false;
        NP_Upgrade23Purchased = false;
        NP_Upgrade24Purchased = false;
        NP_Upgrade25Purchased = false;
        NP_Upgrade26Purchased = false;
        NP_Upgrade27Purchased = false;
        NP_Upgrade28Purchased = false;
        NP_Upgrade29Purchased = false;
        NP_Upgrade30Purchased = false;
        NP_Upgrade31Purchased = false;
        NP_Upgrade32Purchased = false;
        NP_Upgrade33Purchased = false;
        NP_Upgrade34Purchased = false;
        NP_Upgrade35Purchased = false;

        PU_Upgrade1Purchased = false;
        PU_Upgrade1Purchased = false;
        PU_Upgrade2Purchased = false;
        PU_Upgrade3Purchased = false;
        PU_Upgrade4Purchased = false;
        PU_Upgrade5Purchased = false;
        PU_Upgrade6Purchased = false;
        PU_Upgrade7Purchased = false;
        PU_Upgrade8Purchased = false;
        PU_Upgrade9Purchased = false;
        PU_Upgrade10Purchased = false;
        PU_Upgrade11Purchased = false;
        PU_Upgrade12Purchased = false;
        PU_Upgrade13Purchased = false;
        PU_Upgrade14Purchased = false;
        PU_Upgrade15Purchased = false;
        PU_Upgrade16Purchased = false;
        PU_Upgrade17Purchased = false;
        PU_Upgrade18Purchased = false;
        PU_Upgrade19Purchased = false;
        PU_Upgrade20Purchased = false;
        PU_Upgrade21Purchased = false;
        PU_Upgrade22Purchased = false;
        PU_Upgrade23Purchased = false;
        PU_Upgrade24Purchased = false;
        PU_Upgrade25Purchased = false;
        PU_Upgrade26Purchased = false;
        PU_Upgrade27Purchased = false;
        PU_Upgrade28Purchased = false;
        PU_Upgrade29Purchased = false;
        PU_Upgrade30Purchased = false;
        PU_Upgrade31Purchased = false;
        PU_Upgrade32Purchased = false;
        PU_Upgrade33Purchased = false;
        PU_Upgrade34Purchased = false;
        PU_Upgrade35Purchased = false;
        PU_Upgrade36Purchased = false;
        PU_Upgrade37Purchased = false;
        PU_Upgrade38Purchased = false;
        PU_Upgrade39Purchased = false;
        PU_Upgrade40Purchased = false;
        PU_Upgrade41Purchased = false;
        PU_Upgrade42Purchased = false;
        PU_Upgrade43Purchased = false;
        PU_Upgrade44Purchased = false;

        A_Upgrade1Purchased = false;
        A_Upgrade1Purchased = false;
        A_Upgrade2Purchased = false;
        A_Upgrade3Purchased = false;
        A_Upgrade4Purchased = false;
        A_Upgrade5Purchased = false;
        A_Upgrade6Purchased = false;
        A_Upgrade7Purchased = false;
        A_Upgrade8Purchased = false;
        A_Upgrade9Purchased = false;
        A_Upgrade10Purchased = false;
        A_Upgrade11Purchased = false;
        A_Upgrade12Purchased = false;
        A_Upgrade13Purchased = false;
        A_Upgrade14Purchased = false;
        A_Upgrade15Purchased = false;
        A_Upgrade16Purchased = false;
        A_Upgrade17Purchased = false;
        A_Upgrade18Purchased = false;
        A_Upgrade19Purchased = false;
        A_Upgrade20Purchased = false;
        A_Upgrade21Purchased = false;
        A_Upgrade22Purchased = false;
        A_Upgrade23Purchased = false;
        A_Upgrade24Purchased = false;
        A_Upgrade25Purchased = false;
        A_Upgrade26Purchased = false;
        A_Upgrade27Purchased = false;
        A_Upgrade28Purchased = false;
        A_Upgrade29Purchased = false;
        A_Upgrade30Purchased = false;
        A_Upgrade31Purchased = false;
        A_Upgrade32Purchased = false;
        A_Upgrade33Purchased = false;

        purchasedLevel2 = false;
        purchasedLevel3 = false;
        purchasedLevel4 = false;
        purchasedLevel5 = false;
        purchasedLevel6 = false;
        purchasedLevel7 = false;
        purchasedLevel8 = false;
        purchasedLevel9 = false;
        purchasedLevel10 = false;

        moreShots1Purchased = false;
        moreShots2Purchased = false;
        moreShots3Purchased = false;
        moreShots4Purchased = false;

        //All green lines
        foreach (GameObject obj in newLevelGreenLines)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in goldGreenLines)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in prestigeGreenLines)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in newPegsGreenLines)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in activePlayGreenLines)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in moreShotsLines)
        {
            obj.SetActive(false);
        }

        //Demo reset
        newLevelLocks[0].SetActive(true);
        SetImageAlphaRecursive(newLevelLocks[0].GetComponent<Image>(), 1);
        goldLocks[0].SetActive(true);
        SetImageAlphaRecursive(goldLocks[0].GetComponent<Image>(), 1);
        prestigeLocks[0].SetActive(true);
        SetImageAlphaRecursive(prestigeLocks[0].GetComponent<Image>(), 1);
        newPegsLocks[0].SetActive(true);
        SetImageAlphaRecursive(newPegsLocks[0].GetComponent<Image>(), 1);
        activePlayLocks[0].SetActive(true);
        SetImageAlphaRecursive(activePlayLocks[0].GetComponent<Image>(), 1);
        goldGreenOutlines[0].SetActive(false);
        prestigeGreenOutLines[0].SetActive(false);
        newLevelGreenOutlines[0].SetActive(false);
        newPegGreenOutlines[0].SetActive(false);
        activeGreenOutLines[0].SetActive(false);

        if (GameData.isDemo == false)
        {
            foreach (GameObject obj in newLevelLocks)
            {
                obj.SetActive(true);
                SetImageAlphaRecursive(obj.GetComponent<Image>(), 1);
            }
            foreach (GameObject obj in goldLocks)
            {
                obj.SetActive(true);
                SetImageAlphaRecursive(obj.GetComponent<Image>(), 1);
            }
            foreach (GameObject obj in prestigeLocks)
            {
                obj.SetActive(true);
                SetImageAlphaRecursive(obj.GetComponent<Image>(), 1);
            }
            foreach (GameObject obj in newPegsLocks)
            {
                obj.SetActive(true);
                SetImageAlphaRecursive(obj.GetComponent<Image>(), 1);
            }
            foreach (GameObject obj in activePlayLocks)
            {
                obj.SetActive(true);
                SetImageAlphaRecursive(obj.GetComponent<Image>(), 1);
            }
            foreach (GameObject obj in moreShotsLocks)
            {
                obj.SetActive(true);
                SetImageAlphaRecursive(obj.GetComponent<Image>(), 1);
            }
        }

        if (GameData.isDemo == false)
        {
            //All green outlines
            foreach (GameObject obj in goldGreenOutlines)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in prestigeGreenOutLines)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in newLevelGreenOutlines)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in moreShotsGreenOutlines)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in newPegGreenOutlines)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in activeGreenOutLines)
            {
                obj.SetActive(false);
            }
        }

        firstGreenOutLine.SetActive(false);
        firstUpgradeButton.interactable = true;
        SetImageAlphaRecursive(firstUpgradeImage, alpha3);

        SetBuckets();
    }
    #endregion


    #region Load Data
    public void LoadData(GameData data)
    {
        totalBallShots = data.totalBallShots;
        goldFromShooting = data.goldFromShooting;
        extraPrestigePoints = data.extraPrestigePoints;
        startWithGold = data.startWithGold;
        purplePegIncrease = data.purplePegIncrease;
        purplePegChance = data.purplePegChance;
        bombPegChance = data.bombPegChance;
        rainbowPegChance = data.rainbowPegChance;
        prestigeClearHitsNeeded = data.prestigeClearHitsNeeded;
        prestigeBucketChance = data.prestigeBucketChance;
        totalGoldClearBonus = data.totalGoldClearBonus;
        totalTimerGoldClearBonus = data.totalTimerGoldClearBonus;

        prestigePoints = data.prestigePoints;
        levelSelected = data.levelSelected;
        purchasedFirstUpgrade = data.purchasedFirstUpgrade;

        purchasedLevel2 = data.purchasedLevel2;
        purchasedLevel3 = data.purchasedLevel3;
        purchasedLevel4 = data.purchasedLevel4;
        purchasedLevel5 = data.purchasedLevel5;
        purchasedLevel6 = data.purchasedLevel6;
        purchasedLevel7 = data.purchasedLevel7;
        purchasedLevel8 = data.purchasedLevel8;
        purchasedLevel9 = data.purchasedLevel9;
        purchasedLevel10 = data.purchasedLevel10;

        prestigeGoldIncrease = data.prestigeGoldIncrease;
        goldenPegChance = data.goldenPegChance;
        prestigePointsIncrease = data.prestigePointsIncrease;
        prestigePegChance = data.prestigePegChance;

        redPegChance = data.redPegChance;
        isRedPegUnlocked = data.isRedPegUnlocked;
        activeGoldIncrease = data.activeGoldIncrease;

        prestigePointsOverFlow = data.prestigePointsOverFlow;

        G_Upgrade1Purchased = data.G_Upgrade1Purchased;
        G_Upgrade2Purchased = data.G_Upgrade2Purchased;
        G_Upgrade3Purchased = data.G_Upgrade3Purchased;
        G_Upgrade4Purchased = data.G_Upgrade4Purchased;
        G_Upgrade5Purchased = data.G_Upgrade5Purchased;
        G_Upgrade6Purchased = data.G_Upgrade6Purchased;
        G_Upgrade7Purchased = data.G_Upgrade7Purchased;
        G_Upgrade8Purchased = data.G_Upgrade8Purchased;
        G_Upgrade9Purchased = data.G_Upgrade9Purchased;
        G_Upgrade10Purchased = data.G_Upgrade10Purchased;
        G_Upgrade11Purchased = data.G_Upgrade11Purchased;
        G_Upgrade12Purchased = data.G_Upgrade12Purchased;
        G_Upgrade13Purchased = data.G_Upgrade13Purchased;
        G_Upgrade14Purchased = data.G_Upgrade14Purchased;
        G_Upgrade15Purchased = data.G_Upgrade15Purchased;
        G_Upgrade16Purchased = data.G_Upgrade16Purchased;
        G_Upgrade17Purchased = data.G_Upgrade17Purchased;
        G_Upgrade18Purchased = data.G_Upgrade18Purchased;
        G_Upgrade19Purchased = data.G_Upgrade19Purchased;
        G_Upgrade20Purchased = data.G_Upgrade20Purchased;
        G_Upgrade21Purchased = data.G_Upgrade21Purchased;
        G_Upgrade22Purchased = data.G_Upgrade22Purchased;
        G_Upgrade23Purchased = data.G_Upgrade23Purchased;
        G_Upgrade24Purchased = data.G_Upgrade24Purchased;
        G_Upgrade25Purchased = data.G_Upgrade25Purchased;
        G_Upgrade26Purchased = data.G_Upgrade26Purchased;
        G_Upgrade27Purchased = data.G_Upgrade27Purchased;
        G_Upgrade28Purchased = data.G_Upgrade28Purchased;
        G_Upgrade29Purchased = data.G_Upgrade29Purchased;
        G_Upgrade30Purchased = data.G_Upgrade30Purchased;
        G_Upgrade31Purchased = data.G_Upgrade31Purchased;
        G_Upgrade32Purchased = data.G_Upgrade32Purchased;
        G_Upgrade33Purchased = data.G_Upgrade33Purchased;
        G_Upgrade34Purchased = data.G_Upgrade34Purchased;
        G_Upgrade35Purchased = data.G_Upgrade35Purchased;
        G_Upgrade36Purchased = data.G_Upgrade36Purchased;
        G_Upgrade37Purchased = data.G_Upgrade37Purchased;
        G_Upgrade38Purchased = data.G_Upgrade38Purchased;
        G_Upgrade39Purchased = data.G_Upgrade39Purchased;
        G_Upgrade40Purchased = data.G_Upgrade40Purchased;
        G_Upgrade41Purchased = data.G_Upgrade41Purchased;
        G_Upgrade42Purchased = data.G_Upgrade42Purchased;
        G_Upgrade43Purchased = data.G_Upgrade43Purchased;
        G_Upgrade44Purchased = data.G_Upgrade44Purchased;
        G_Upgrade45Purchased = data.G_Upgrade45Purchased;
        G_Upgrade46Purchased = data.G_Upgrade46Purchased;
        G_Upgrade47Purchased = data.G_Upgrade47Purchased;
        G_Upgrade48Purchased = data.G_Upgrade48Purchased;
        G_Upgrade49Purchased = data.G_Upgrade49Purchased;
        G_Upgrade50Purchased = data.G_Upgrade50Purchased;
        G_Upgrade51Purchased = data.G_Upgrade51Purchased;

        PU_Upgrade1Purchased = data.PU_Upgrade1Purchased;
        PU_Upgrade2Purchased = data.PU_Upgrade2Purchased;
        PU_Upgrade3Purchased = data.PU_Upgrade3Purchased;
        PU_Upgrade4Purchased = data.PU_Upgrade4Purchased;
        PU_Upgrade5Purchased = data.PU_Upgrade5Purchased;
        PU_Upgrade6Purchased = data.PU_Upgrade6Purchased;
        PU_Upgrade7Purchased = data.PU_Upgrade7Purchased;
        PU_Upgrade8Purchased = data.PU_Upgrade8Purchased;
        PU_Upgrade9Purchased = data.PU_Upgrade9Purchased;
        PU_Upgrade10Purchased = data.PU_Upgrade10Purchased;
        PU_Upgrade11Purchased = data.PU_Upgrade11Purchased;
        PU_Upgrade12Purchased = data.PU_Upgrade12Purchased;
        PU_Upgrade13Purchased = data.PU_Upgrade13Purchased;
        PU_Upgrade14Purchased = data.PU_Upgrade14Purchased;
        PU_Upgrade15Purchased = data.PU_Upgrade15Purchased;
        PU_Upgrade16Purchased = data.PU_Upgrade16Purchased;
        PU_Upgrade17Purchased = data.PU_Upgrade17Purchased;
        PU_Upgrade18Purchased = data.PU_Upgrade18Purchased;
        PU_Upgrade19Purchased = data.PU_Upgrade19Purchased;
        PU_Upgrade20Purchased = data.PU_Upgrade20Purchased;
        PU_Upgrade21Purchased = data.PU_Upgrade21Purchased;
        PU_Upgrade22Purchased = data.PU_Upgrade22Purchased;
        PU_Upgrade23Purchased = data.PU_Upgrade23Purchased;
        PU_Upgrade24Purchased = data.PU_Upgrade24Purchased;
        PU_Upgrade25Purchased = data.PU_Upgrade25Purchased;
        PU_Upgrade26Purchased = data.PU_Upgrade26Purchased;
        PU_Upgrade27Purchased = data.PU_Upgrade27Purchased;
        PU_Upgrade28Purchased = data.PU_Upgrade28Purchased;
        PU_Upgrade29Purchased = data.PU_Upgrade29Purchased;
        PU_Upgrade30Purchased = data.PU_Upgrade30Purchased;
        PU_Upgrade31Purchased = data.PU_Upgrade31Purchased;
        PU_Upgrade32Purchased = data.PU_Upgrade32Purchased;
        PU_Upgrade33Purchased = data.PU_Upgrade33Purchased;
        PU_Upgrade34Purchased = data.PU_Upgrade34Purchased;
        PU_Upgrade35Purchased = data.PU_Upgrade35Purchased;
        PU_Upgrade36Purchased = data.PU_Upgrade36Purchased;
        PU_Upgrade37Purchased = data.PU_Upgrade37Purchased;
        PU_Upgrade38Purchased = data.PU_Upgrade38Purchased;
        PU_Upgrade39Purchased = data.PU_Upgrade39Purchased;
        PU_Upgrade40Purchased = data.PU_Upgrade40Purchased;
        PU_Upgrade41Purchased = data.PU_Upgrade41Purchased;
        PU_Upgrade42Purchased = data.PU_Upgrade42Purchased;
        PU_Upgrade43Purchased = data.PU_Upgrade43Purchased;
        PU_Upgrade44Purchased = data.PU_Upgrade44Purchased;

        NP_Upgrade1Purchased = data.NP_Upgrade1Purchased;
        NP_Upgrade2Purchased = data.NP_Upgrade2Purchased;
        NP_Upgrade3Purchased = data.NP_Upgrade3Purchased;
        NP_Upgrade4Purchased = data.NP_Upgrade4Purchased;
        NP_Upgrade5Purchased = data.NP_Upgrade5Purchased;
        NP_Upgrade6Purchased = data.NP_Upgrade6Purchased;
        NP_Upgrade7Purchased = data.NP_Upgrade7Purchased;
        NP_Upgrade8Purchased = data.NP_Upgrade8Purchased;
        NP_Upgrade9Purchased = data.NP_Upgrade9Purchased;
        NP_Upgrade10Purchased = data.NP_Upgrade10Purchased;
        NP_Upgrade11Purchased = data.NP_Upgrade11Purchased;
        NP_Upgrade12Purchased = data.NP_Upgrade12Purchased;
        NP_Upgrade13Purchased = data.NP_Upgrade13Purchased;
        NP_Upgrade14Purchased = data.NP_Upgrade14Purchased;
        NP_Upgrade15Purchased = data.NP_Upgrade15Purchased;
        NP_Upgrade16Purchased = data.NP_Upgrade16Purchased;
        NP_Upgrade17Purchased = data.NP_Upgrade17Purchased;
        NP_Upgrade18Purchased = data.NP_Upgrade18Purchased;
        NP_Upgrade19Purchased = data.NP_Upgrade19Purchased;
        NP_Upgrade20Purchased = data.NP_Upgrade20Purchased;
        NP_Upgrade21Purchased = data.NP_Upgrade21Purchased;
        NP_Upgrade22Purchased = data.NP_Upgrade22Purchased;
        NP_Upgrade23Purchased = data.NP_Upgrade23Purchased;
        NP_Upgrade24Purchased = data.NP_Upgrade24Purchased;
        NP_Upgrade25Purchased = data.NP_Upgrade25Purchased;
        NP_Upgrade26Purchased = data.NP_Upgrade26Purchased;
        NP_Upgrade27Purchased = data.NP_Upgrade27Purchased;
        NP_Upgrade28Purchased = data.NP_Upgrade28Purchased;
        NP_Upgrade29Purchased = data.NP_Upgrade29Purchased;
        NP_Upgrade30Purchased = data.NP_Upgrade30Purchased;
        NP_Upgrade31Purchased = data.NP_Upgrade31Purchased;
        NP_Upgrade32Purchased = data.NP_Upgrade32Purchased;
        NP_Upgrade33Purchased = data.NP_Upgrade33Purchased;
        NP_Upgrade34Purchased = data.NP_Upgrade34Purchased;
        NP_Upgrade35Purchased = data.NP_Upgrade35Purchased;

        A_Upgrade1Purchased = data.A_Upgrade1Purchased;
        A_Upgrade2Purchased = data.A_Upgrade2Purchased;
        A_Upgrade3Purchased = data.A_Upgrade3Purchased;
        A_Upgrade4Purchased = data.A_Upgrade4Purchased;
        A_Upgrade5Purchased = data.A_Upgrade5Purchased;
        A_Upgrade6Purchased = data.A_Upgrade6Purchased;
        A_Upgrade7Purchased = data.A_Upgrade7Purchased;
        A_Upgrade8Purchased = data.A_Upgrade8Purchased;
        A_Upgrade9Purchased = data.A_Upgrade9Purchased;
        A_Upgrade10Purchased = data.A_Upgrade10Purchased;
        A_Upgrade11Purchased = data.A_Upgrade11Purchased;
        A_Upgrade12Purchased = data.A_Upgrade12Purchased;
        A_Upgrade13Purchased = data.A_Upgrade13Purchased;
        A_Upgrade14Purchased = data.A_Upgrade14Purchased;
        A_Upgrade15Purchased = data.A_Upgrade15Purchased;
        A_Upgrade16Purchased = data.A_Upgrade16Purchased;
        A_Upgrade17Purchased = data.A_Upgrade17Purchased;
        A_Upgrade18Purchased = data.A_Upgrade18Purchased;
        A_Upgrade19Purchased = data.A_Upgrade19Purchased;
        A_Upgrade20Purchased = data.A_Upgrade20Purchased;
        A_Upgrade21Purchased = data.A_Upgrade21Purchased;
        A_Upgrade22Purchased = data.A_Upgrade22Purchased;
        A_Upgrade23Purchased = data.A_Upgrade23Purchased;
        A_Upgrade24Purchased = data.A_Upgrade24Purchased;
        A_Upgrade25Purchased = data.A_Upgrade25Purchased;
        A_Upgrade26Purchased = data.A_Upgrade26Purchased;
        A_Upgrade27Purchased = data.A_Upgrade27Purchased;
        A_Upgrade28Purchased = data.A_Upgrade28Purchased;
        A_Upgrade29Purchased = data.A_Upgrade29Purchased;
        A_Upgrade30Purchased = data.A_Upgrade30Purchased;
        A_Upgrade31Purchased = data.A_Upgrade31Purchased;
        A_Upgrade32Purchased = data.A_Upgrade32Purchased;
        A_Upgrade33Purchased = data.A_Upgrade33Purchased;

        moreShots1Purchased = data.moreShots1Purchased;
        moreShots2Purchased = data.moreShots2Purchased;
        moreShots3Purchased = data.moreShots3Purchased;
        moreShots4Purchased = data.moreShots4Purchased;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.totalBallShots = totalBallShots;
        data.goldFromShooting = goldFromShooting;
        data.extraPrestigePoints = extraPrestigePoints;
        data.startWithGold = startWithGold;
        data.purplePegIncrease = purplePegIncrease;
        data.purplePegChance = purplePegChance;
        data.bombPegChance = bombPegChance;
        data.rainbowPegChance = rainbowPegChance;
        data.prestigeClearHitsNeeded = prestigeClearHitsNeeded;
        data.prestigeBucketChance = prestigeBucketChance;
        data.totalGoldClearBonus = totalGoldClearBonus;
        data.totalTimerGoldClearBonus = totalTimerGoldClearBonus;

        data.prestigePoints = prestigePoints;
        data.levelSelected = levelSelected;
        data.purchasedFirstUpgrade = purchasedFirstUpgrade;

        data.prestigePointsOverFlow = prestigePointsOverFlow;

        data.purchasedLevel2 = purchasedLevel2;
        data.purchasedLevel3 = purchasedLevel3;
        data.purchasedLevel4 = purchasedLevel4;
        data.purchasedLevel5 = purchasedLevel5;
        data.purchasedLevel6 = purchasedLevel6;
        data.purchasedLevel7 = purchasedLevel7;
        data.purchasedLevel8 = purchasedLevel8;
        data.purchasedLevel9 = purchasedLevel9;
        data.purchasedLevel10 = purchasedLevel10;

        data.prestigeGoldIncrease = prestigeGoldIncrease;
        data.goldenPegChance = goldenPegChance;
        data.prestigePointsIncrease = prestigePointsIncrease;
        data.prestigePegChance = prestigePegChance;

        data.redPegChance = redPegChance;
        data.isRedPegUnlocked = isRedPegUnlocked;
        data.activeGoldIncrease = activeGoldIncrease;

        data.G_Upgrade1Purchased = G_Upgrade1Purchased;
        data.G_Upgrade2Purchased = G_Upgrade2Purchased;
        data.G_Upgrade3Purchased = G_Upgrade3Purchased;
        data.G_Upgrade4Purchased = G_Upgrade4Purchased;
        data.G_Upgrade5Purchased = G_Upgrade5Purchased;
        data.G_Upgrade6Purchased = G_Upgrade6Purchased;
        data.G_Upgrade7Purchased = G_Upgrade7Purchased;
        data.G_Upgrade8Purchased = G_Upgrade8Purchased;
        data.G_Upgrade9Purchased = G_Upgrade9Purchased;
        data.G_Upgrade10Purchased = G_Upgrade10Purchased;
        data.G_Upgrade11Purchased = G_Upgrade11Purchased;
        data.G_Upgrade12Purchased = G_Upgrade12Purchased;
        data.G_Upgrade13Purchased = G_Upgrade13Purchased;
        data.G_Upgrade14Purchased = G_Upgrade14Purchased;
        data.G_Upgrade15Purchased = G_Upgrade15Purchased;
        data.G_Upgrade16Purchased = G_Upgrade16Purchased;
        data.G_Upgrade17Purchased = G_Upgrade17Purchased;
        data.G_Upgrade18Purchased = G_Upgrade18Purchased;
        data.G_Upgrade19Purchased = G_Upgrade19Purchased;
        data.G_Upgrade20Purchased = G_Upgrade20Purchased;
        data.G_Upgrade21Purchased = G_Upgrade21Purchased;
        data.G_Upgrade22Purchased = G_Upgrade22Purchased;
        data.G_Upgrade23Purchased = G_Upgrade23Purchased;
        data.G_Upgrade24Purchased = G_Upgrade24Purchased;
        data.G_Upgrade25Purchased = G_Upgrade25Purchased;
        data.G_Upgrade26Purchased = G_Upgrade26Purchased;
        data.G_Upgrade27Purchased = G_Upgrade27Purchased;
        data.G_Upgrade28Purchased = G_Upgrade28Purchased;
        data.G_Upgrade29Purchased = G_Upgrade29Purchased;
        data.G_Upgrade30Purchased = G_Upgrade30Purchased;
        data.G_Upgrade31Purchased = G_Upgrade31Purchased;
        data.G_Upgrade32Purchased = G_Upgrade32Purchased;
        data.G_Upgrade33Purchased = G_Upgrade33Purchased;
        data.G_Upgrade34Purchased = G_Upgrade34Purchased;
        data.G_Upgrade35Purchased = G_Upgrade35Purchased;
        data.G_Upgrade36Purchased = G_Upgrade36Purchased;
        data.G_Upgrade37Purchased = G_Upgrade37Purchased;
        data.G_Upgrade38Purchased = G_Upgrade38Purchased;
        data.G_Upgrade39Purchased = G_Upgrade39Purchased;
        data.G_Upgrade40Purchased = G_Upgrade40Purchased;
        data.G_Upgrade41Purchased = G_Upgrade41Purchased;
        data.G_Upgrade42Purchased = G_Upgrade42Purchased;
        data.G_Upgrade43Purchased = G_Upgrade43Purchased;
        data.G_Upgrade44Purchased = G_Upgrade44Purchased;
        data.G_Upgrade45Purchased = G_Upgrade45Purchased;
        data.G_Upgrade46Purchased = G_Upgrade46Purchased;
        data.G_Upgrade47Purchased = G_Upgrade47Purchased;
        data.G_Upgrade48Purchased = G_Upgrade48Purchased;
        data.G_Upgrade49Purchased = G_Upgrade49Purchased;
        data.G_Upgrade50Purchased = G_Upgrade50Purchased;
        data.G_Upgrade51Purchased = G_Upgrade51Purchased;

        data.PU_Upgrade1Purchased = PU_Upgrade1Purchased;
        data.PU_Upgrade2Purchased = PU_Upgrade2Purchased;
        data.PU_Upgrade3Purchased = PU_Upgrade3Purchased;
        data.PU_Upgrade4Purchased = PU_Upgrade4Purchased;
        data.PU_Upgrade5Purchased = PU_Upgrade5Purchased;
        data.PU_Upgrade6Purchased = PU_Upgrade6Purchased;
        data.PU_Upgrade7Purchased = PU_Upgrade7Purchased;
        data.PU_Upgrade8Purchased = PU_Upgrade8Purchased;
        data.PU_Upgrade9Purchased = PU_Upgrade9Purchased;
        data.PU_Upgrade10Purchased = PU_Upgrade10Purchased;
        data.PU_Upgrade11Purchased = PU_Upgrade11Purchased;
        data.PU_Upgrade12Purchased = PU_Upgrade12Purchased;
        data.PU_Upgrade13Purchased = PU_Upgrade13Purchased;
        data.PU_Upgrade14Purchased = PU_Upgrade14Purchased;
        data.PU_Upgrade15Purchased = PU_Upgrade15Purchased;
        data.PU_Upgrade16Purchased = PU_Upgrade16Purchased;
        data.PU_Upgrade17Purchased = PU_Upgrade17Purchased;
        data.PU_Upgrade18Purchased = PU_Upgrade18Purchased;
        data.PU_Upgrade19Purchased = PU_Upgrade19Purchased;
        data.PU_Upgrade20Purchased = PU_Upgrade20Purchased;
        data.PU_Upgrade21Purchased = PU_Upgrade21Purchased;
        data.PU_Upgrade22Purchased = PU_Upgrade22Purchased;
        data.PU_Upgrade23Purchased = PU_Upgrade23Purchased;
        data.PU_Upgrade24Purchased = PU_Upgrade24Purchased;
        data.PU_Upgrade25Purchased = PU_Upgrade25Purchased;
        data.PU_Upgrade26Purchased = PU_Upgrade26Purchased;
        data.PU_Upgrade27Purchased = PU_Upgrade27Purchased;
        data.PU_Upgrade28Purchased = PU_Upgrade28Purchased;
        data.PU_Upgrade29Purchased = PU_Upgrade29Purchased;
        data.PU_Upgrade30Purchased = PU_Upgrade30Purchased;
        data.PU_Upgrade31Purchased = PU_Upgrade31Purchased;
        data.PU_Upgrade32Purchased = PU_Upgrade32Purchased;
        data.PU_Upgrade33Purchased = PU_Upgrade33Purchased;
        data.PU_Upgrade34Purchased = PU_Upgrade34Purchased;
        data.PU_Upgrade35Purchased = PU_Upgrade35Purchased;
        data.PU_Upgrade36Purchased = PU_Upgrade36Purchased;
        data.PU_Upgrade37Purchased = PU_Upgrade37Purchased;
        data.PU_Upgrade38Purchased = PU_Upgrade38Purchased;
        data.PU_Upgrade39Purchased = PU_Upgrade39Purchased;
        data.PU_Upgrade40Purchased = PU_Upgrade40Purchased;
        data.PU_Upgrade41Purchased = PU_Upgrade41Purchased;
        data.PU_Upgrade42Purchased = PU_Upgrade42Purchased;
        data.PU_Upgrade43Purchased = PU_Upgrade43Purchased;
        data.PU_Upgrade44Purchased = PU_Upgrade44Purchased;

        data.NP_Upgrade1Purchased = NP_Upgrade1Purchased;
        data.NP_Upgrade2Purchased = NP_Upgrade2Purchased;
        data.NP_Upgrade3Purchased = NP_Upgrade3Purchased;
        data.NP_Upgrade4Purchased = NP_Upgrade4Purchased;
        data.NP_Upgrade5Purchased = NP_Upgrade5Purchased;
        data.NP_Upgrade6Purchased = NP_Upgrade6Purchased;
        data.NP_Upgrade7Purchased = NP_Upgrade7Purchased;
        data.NP_Upgrade8Purchased = NP_Upgrade8Purchased;
        data.NP_Upgrade9Purchased = NP_Upgrade9Purchased;
        data.NP_Upgrade10Purchased = NP_Upgrade10Purchased;
        data.NP_Upgrade11Purchased = NP_Upgrade11Purchased;
        data.NP_Upgrade12Purchased = NP_Upgrade12Purchased;
        data.NP_Upgrade13Purchased = NP_Upgrade13Purchased;
        data.NP_Upgrade14Purchased = NP_Upgrade14Purchased;
        data.NP_Upgrade15Purchased = NP_Upgrade15Purchased;
        data.NP_Upgrade16Purchased = NP_Upgrade16Purchased;
        data.NP_Upgrade17Purchased = NP_Upgrade17Purchased;
        data.NP_Upgrade18Purchased = NP_Upgrade18Purchased;
        data.NP_Upgrade19Purchased = NP_Upgrade19Purchased;
        data.NP_Upgrade20Purchased = NP_Upgrade20Purchased;
        data.NP_Upgrade21Purchased = NP_Upgrade21Purchased;
        data.NP_Upgrade22Purchased = NP_Upgrade22Purchased;
        data.NP_Upgrade23Purchased = NP_Upgrade23Purchased;
        data.NP_Upgrade24Purchased = NP_Upgrade24Purchased;
        data.NP_Upgrade25Purchased = NP_Upgrade25Purchased;
        data.NP_Upgrade26Purchased = NP_Upgrade26Purchased;
        data.NP_Upgrade27Purchased = NP_Upgrade27Purchased;
        data.NP_Upgrade28Purchased = NP_Upgrade28Purchased;
        data.NP_Upgrade29Purchased = NP_Upgrade29Purchased;
        data.NP_Upgrade30Purchased = NP_Upgrade30Purchased;
        data.NP_Upgrade31Purchased = NP_Upgrade31Purchased;
        data.NP_Upgrade32Purchased = NP_Upgrade32Purchased;
        data.NP_Upgrade33Purchased = NP_Upgrade33Purchased;
        data.NP_Upgrade34Purchased = NP_Upgrade34Purchased;
        data.NP_Upgrade35Purchased = NP_Upgrade35Purchased;

        data.A_Upgrade1Purchased = A_Upgrade1Purchased;
        data.A_Upgrade2Purchased = A_Upgrade2Purchased;
        data.A_Upgrade3Purchased = A_Upgrade3Purchased;
        data.A_Upgrade4Purchased = A_Upgrade4Purchased;
        data.A_Upgrade5Purchased = A_Upgrade5Purchased;
        data.A_Upgrade6Purchased = A_Upgrade6Purchased;
        data.A_Upgrade7Purchased = A_Upgrade7Purchased;
        data.A_Upgrade8Purchased = A_Upgrade8Purchased;
        data.A_Upgrade9Purchased = A_Upgrade9Purchased;
        data.A_Upgrade10Purchased = A_Upgrade10Purchased;
        data.A_Upgrade11Purchased = A_Upgrade11Purchased;
        data.A_Upgrade12Purchased = A_Upgrade12Purchased;
        data.A_Upgrade13Purchased = A_Upgrade13Purchased;
        data.A_Upgrade14Purchased = A_Upgrade14Purchased;
        data.A_Upgrade15Purchased = A_Upgrade15Purchased;
        data.A_Upgrade16Purchased = A_Upgrade16Purchased;
        data.A_Upgrade17Purchased = A_Upgrade17Purchased;
        data.A_Upgrade18Purchased = A_Upgrade18Purchased;
        data.A_Upgrade19Purchased = A_Upgrade19Purchased;
        data.A_Upgrade20Purchased = A_Upgrade20Purchased;
        data.A_Upgrade21Purchased = A_Upgrade21Purchased;
        data.A_Upgrade22Purchased = A_Upgrade22Purchased;
        data.A_Upgrade23Purchased = A_Upgrade23Purchased;
        data.A_Upgrade24Purchased = A_Upgrade24Purchased;
        data.A_Upgrade25Purchased = A_Upgrade25Purchased;
        data.A_Upgrade26Purchased = A_Upgrade26Purchased;
        data.A_Upgrade27Purchased = A_Upgrade27Purchased;
        data.A_Upgrade28Purchased = A_Upgrade28Purchased;
        data.A_Upgrade29Purchased = A_Upgrade29Purchased;
        data.A_Upgrade30Purchased = A_Upgrade30Purchased;
        data.A_Upgrade31Purchased = A_Upgrade31Purchased;
        data.A_Upgrade32Purchased = A_Upgrade32Purchased;
        data.A_Upgrade33Purchased = A_Upgrade33Purchased;

        data.moreShots1Purchased = moreShots1Purchased;
        data.moreShots2Purchased = moreShots2Purchased;
        data.moreShots3Purchased = moreShots3Purchased;
        data.moreShots4Purchased = moreShots4Purchased;
    }
    #endregion


    #region Cant affors and upgrade sound
    public void CheckCanAfford()
    {

    }

    public AllStats statsScript;
    public void UpgradeSound()
    {
        AllStats.prestigeUpgradesPurchased += 1;

        if (achScript != null) { achScript.CheckPrestigeUpgradesACH(); }

        if (SettingsOptions.isInStats == true) { statsScript.DisplayPegscensionStats(); }

        int random = Random.Range(1,3);
        if(random == 1) { audioManager.Play("PrestigeUpgrade1"); }
        if (random == 2) { audioManager.Play("PrestigeUpgrade2"); }
    }
    #endregion

    public void ClickSound()
    {
        int random = Random.Range(1, 3);
        if (random == 1) { audioManager.Play("UIClick1"); }
        if (random == 2) { audioManager.Play("UIClick2"); }
    }
}
