using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllStats : MonoBehaviour, IDataPersistence
{
    public void Start()
    {
        StartCoroutine(wait());
        totalPegsUnlocked = 3;
        levelsUnlocked = 1;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        DisplayAllStats();
    }

    public void Update()
    {
        if(SettingsOptions.isInStats == true)
        {
            DisplayTotalGold();
            DisplayPrestigePointStats();
            DisplayPegHitsStats();
            DisplayGeneralStats();
            DisplayPitStats();
            NewStats();
        }
    }

    public void DisplayAllStats()
    {
        DisplayPegStats();
        DisplayPegscensionStats();
    }

    #region GeneralStats
    public static double totalGold, totalGoldSpent;
    public static int totalBallsShot, totalBallsDropped, totalPegsHit, totalBoardsCleared;
    public TextMeshProUGUI totalGoldText, totalGoldSpentText, totalBallsShotText, totalBallsDroppedText, totalPegsHitText, totalBoardsClearedText;
    public Achievements achScript;

    public void DisplayGeneralStats()
    {
        totalGoldSpentText.text = SetHighNumbers.FormatCoinsGoldShort(totalGoldSpent);
        totalBallsShotText.text = SetHighNumbers.FormatCoinsGoldShort(totalBallsShot);
        totalBallsDroppedText.text = SetHighNumbers.FormatCoinsGoldShort(totalBallsDropped);
        totalBoardsClearedText.text = totalBoardsCleared.ToString("F0");
    }

    //1.163T
    //11

    public void DisplayTotalGold()
    {
        totalGoldText.text = SetHighNumbers.FormatCoinsGoldShort(totalGold);
        totalPegGoldText.text = SetHighNumbers.FormatCoinsGoldShort(totalPegGold); 
        totalPitGoldText.text = SetHighNumbers.FormatCoinsGoldShort(totalPitGold);

        if (Prestige.G_Upgrade12Purchased == false) { goldFromClearLeft.text = "??????????????"; goldFromClearText.text = "???"; }
        else
        {
            goldFromClearLeft.text = LocalizationStrings.totalGoldFromClear; goldFromClearText.text = SetHighNumbers.FormatCoinsGoldShort(goldFromClear);
        }

        if (Prestige.A_Upgrade22Purchased == false) { goldFromShootingLeft.text = "??????????????";  goldFromShootingText.text = "???"; }
        else
        {
            goldFromShootingLeft.text = LocalizationStrings.totalGoldFromShooting; goldFromShootingText.text =  SetHighNumbers.FormatCoinsGoldShort(goldFromShooting); ;
        }
    }
    #endregion

    #region Prestige point stats
    public static int totalPrestigePointSpent, totalPRestigePoints;
    public static float totalPrestigePointOverflow;
    public TextMeshProUGUI totalPrestigePointText, totalPrestigePointSpentText, totalPRestigePointLEft, totalPrestigeSpentLeft;

    public void DisplayPrestigePointStats()
    {
        totalPRestigePointLEft.text = LocalizationStrings.totalPrestigePointsGained;
        totalPrestigeSpentLeft.text = LocalizationStrings.totalRestigePointsSpent;

        totalPrestigePointSpentText.text = SetHighNumbers.FormatCoinsGoldShort(totalPrestigePointSpent);

        if (Prestige.ppOverflow == false)
        {
            totalPrestigePointText.text = SetHighNumbers.FormatCoinsGoldShort(totalPRestigePoints);
        }
        else
        {
            totalPrestigePointText.text = SetHighNumbers.FormatCoinsGoldShort(totalPrestigePointOverflow + totalPRestigePoints);
        }
         

        if (Prestige.PU_Upgrade12Purchased == false) { prestigePointFromClearLeft.text = "??????????????"; prestigePointsFromClearText.text = "???"; }
        else
        {
            prestigePointFromClearLeft.text = LocalizationStrings.totalPrestigePointFromClear; prestigePointsFromClearText.text = SetHighNumbers.FormatCoinsGoldShort(prestigePointFromClear);
        }

        if (Prestige.PU_Upgrade17Purchased == false && Prestige.NP_Upgrade8Purchased == false) { prestigePointFromBucketLeft.text = "??????????????"; prestigePointsFromBucketText.text = "???"; }
        else
        {
            prestigePointFromBucketLeft.text = LocalizationStrings.totalPrestigePointFromBucket; prestigePointsFromBucketText.text = SetHighNumbers.FormatCoinsGoldShort(prestigePointsFromBucket);
        }
    }
    #endregion


    #region Peg Stats
    public static float greenPegChance;
    public static int greenPegsHit, goldenPegsHit, prestigePegsHit, redPegsHit, rainbowPegsHit, bombPegsHit, purplePegHit;
    public static double totalPegGold;

    public TextMeshProUGUI greenPegChanceText, goldenPegChanceText, prestigePegChanceText, redPegChanceText, totalPegGoldText, rainbowPegChanceText, bombPegChanceText, purplePegChanceText;
    public TextMeshProUGUI greenPegsHitText, goldenPegsHitText, prestigePegsHitText, redPegsHitText, rainbowPegsHitText, bombPegsHitText, purplePegsHitText;

    public TextMeshProUGUI redPegChanceLeftText, redPegsHitLeftText, rainbowPegChanceLeft, rainbowPegHitLeft, bombPegChanceLEft, bombPEgHitLeft, purplePegChanceLeft, purplePegHitLeft;

    public void DisplayPegStats()
    {
        greenPegChance = 100 - (Prestige.goldenPegChance + Prestige.prestigePegChance + Prestige.redPegChance + Prestige.rainbowPegChance + Prestige.bombPegChance + Prestige.purplePegChance);
     

        if (greenPegChance % 1 == 0) { greenPegChanceText.text = "" + greenPegChance.ToString("F0") + "%"; }
        else { greenPegChanceText.text = "" + greenPegChance.ToString("F1") + "%"; }

        if (Prestige.goldenPegChance % 1 == 0) { goldenPegChanceText.text = "" + Prestige.goldenPegChance.ToString("F0") + "%"; }
        else { goldenPegChanceText.text = "" + Prestige.goldenPegChance.ToString("F1") + "%"; }

        if (Prestige.prestigePegChance % 1 == 0) { prestigePegChanceText.text = "" + Prestige.prestigePegChance.ToString("F0") + "%"; }
        else { prestigePegChanceText.text = "" + Prestige.prestigePegChance.ToString("F1") + "%"; }

        if(Prestige.isRedPegUnlocked == false)
        { 
            redPegChanceText.text = "???";
            redPegChanceLeftText.text = "??????????????";
            redPegsHitLeftText.text = "??????????????";
        }
        else 
        {
            if (Prestige.redPegChance % 1 == 0) { redPegChanceText.text = "" + Prestige.redPegChance.ToString("F0") + "%"; }
            else { redPegChanceText.text = "" + Prestige.redPegChance.ToString("F1") + "%"; }

            redPegChanceLeftText.text = LocalizationStrings.redPegSpawnChanceString;
            redPegsHitLeftText.text = LocalizationStrings.redPegsHitString;
        }

        //Rainbow peg
        if (Prestige.NP_Upgrade8Purchased == false)
        {
            rainbowPegChanceText.text = "???";
            rainbowPegChanceLeft.text = "??????????????";
            rainbowPegHitLeft.text = "??????????????";
        }
        else
        {
            if (Prestige.rainbowPegChance % 1 == 0) { rainbowPegChanceText.text = "" + Prestige.rainbowPegChance.ToString("F0") + "%"; }
            else { rainbowPegChanceText.text = "" + Prestige.rainbowPegChance.ToString("F1") + "%"; }

            rainbowPegChanceLeft.text = LocalizationStrings.rainbowPegSpawnChance;
            rainbowPegHitLeft.text = LocalizationStrings.rainbowPegsHit;
        }

        //Bomb peg
        if (Prestige.NP_Upgrade17Purchased == false)
        {
            bombPegChanceText.text = "???";
            bombPegChanceLEft.text = "??????????????";
            bombPEgHitLeft.text = "??????????????";
        }
        else
        {
            if (Prestige.bombPegChance % 1 == 0) { bombPegChanceText.text = "" + Prestige.bombPegChance.ToString("F0") + "%"; }
            else { bombPegChanceText.text = "" + Prestige.bombPegChance.ToString("F1") + "%"; }

            bombPegChanceLEft.text = LocalizationStrings.bombPegsSpawnChance;
            bombPEgHitLeft.text = LocalizationStrings.bombPegsHit;
        }

        //Purple peg
        if (Prestige.NP_Upgrade26Purchased == false)
        {
            purplePegChanceText.text = "???";
            purplePegChanceLeft.text = "??????????????";
            purplePegHitLeft.text = "??????????????";
        }
        else
        {
            if (Prestige.purplePegChance % 1 == 0) { purplePegChanceText.text = "" + Prestige.purplePegChance.ToString("F0") + "%"; }
            else { purplePegChanceText.text = "" + Prestige.purplePegChance.ToString("F1") + "%"; }

            purplePegChanceLeft.text = LocalizationStrings.purplePegsSpawnChance;
            purplePegHitLeft.text = LocalizationStrings.purplePegsHit;
        }
    }

    public Challenges challScript;
    public void DisplayPegHitsStats()
    {
        totalPegsHitText.text = SetHighNumbers.FormatCoinsGoldShort(totalPegsHit);
        greenPegsHitText.text = SetHighNumbers.FormatCoinsGoldShort(greenPegsHit);
        goldenPegsHitText.text = SetHighNumbers.FormatCoinsGoldShort(goldenPegsHit);
        prestigePegsHitText.text = SetHighNumbers.FormatCoinsGoldShort(prestigePegsHit);

        if (Prestige.isRedPegUnlocked == true) { redPegsHitText.text = redPegsHit.ToString("F0"); }
        else { redPegsHitText.text = "???"; }
        if (Prestige.NP_Upgrade8Purchased == true) { rainbowPegsHitText.text = rainbowPegsHit.ToString("F0"); }
        else { rainbowPegsHitText.text = "???"; }
        if (Prestige.NP_Upgrade17Purchased == true) { bombPegsHitText.text = bombPegsHit.ToString("F0"); }
        else { bombPegsHitText.text = "???"; }
        if (Prestige.NP_Upgrade26Purchased == true) { purplePegsHitText.text = purplePegHit.ToString("F0"); }
        else { purplePegsHitText.text = "???"; }
    }
    #endregion

    #region Pit Stats
    public static int totalBallsPit;
    public static double totalPitGold;
    public TextMeshProUGUI totalBallsPitText, totalPitGoldText;

    public void DisplayPitStats()
    {
        totalBallsPitText.text = SetHighNumbers.FormatCoinsGoldShort(totalBallsPit);
    }
    #endregion

    #region PrestigeStats
    public static int prestigeUpgradesPurchased, levelsUnlocked, totalPegsUnlocked;
    public TextMeshProUGUI prestigeUpgradesPurchasedText, levelsUnlockedText, totalGOldIncreaseText, ballsShotGoldIncreaseText, prestigePegPointsText, totalPegsUnlockedText;

    public void DisplayPegscensionStats()
    {
        prestigeUpgradesPurchasedText.text = prestigeUpgradesPurchased + "/176";
        levelsUnlockedText.text = levelsUnlocked + "/10";
        totalPegsUnlockedText.text = totalPegsUnlocked + "/7";

        totalGOldIncreaseText.text = (Prestige.prestigeGoldIncrease * 100).ToString("F0") + "%";
        ballsShotGoldIncreaseText.text = (Prestige.activeGoldIncrease * 100).ToString("F0") + "%";

        prestigePegPointsText.text = Prestige.prestigePointsIncrease.ToString("F0");
    }
    #endregion

    #region Full game new stats
    //New stats
    public static int timesFullyCharge, timesGoldRush, timesPrestigeRush;
    public static double goldFromClear, goldFromShooting;
    public static int prestigePointFromClear, prestigePointsFromBucket;
    public TextMeshProUGUI fullyChargeText, timesGoldRushTextLeft, timesGoldRushText, timesPrestigeRushLeft, timesPrestigeRushText, goldFromClearLeft, goldFromClearText, goldFromShootingLeft, goldFromShootingText, prestigePointFromClearLeft, prestigePointsFromClearText, prestigePointFromBucketLeft, prestigePointsFromBucketText;

    public void NewStats()
    {
        fullyChargeText.text = timesFullyCharge.ToString("F0");

        //Gold stats
        if(Prestige.G_Upgrade51Purchased == false) { timesGoldRushTextLeft.text = "??????????????"; timesGoldRushText.text = "???"; }
        else
        {
            timesGoldRushTextLeft.text = LocalizationStrings.totalGoldRush; timesGoldRushText.text = timesGoldRush.ToString("F0"); ;
        }

        //Prestige stats
        if (Prestige.PU_Upgrade44Purchased == false) { timesPrestigeRushLeft.text = "??????????????"; timesPrestigeRushText.text = "???"; }
        else
        {
            timesPrestigeRushLeft.text = LocalizationStrings.totalPRestigeRush; timesPrestigeRushText.text = timesPrestigeRush.ToString("F0"); ;
        }

    }
    #endregion


    #region Load Data
    public void LoadData(GameData data)
    {
        totalGold = data.totalGold;
        totalGoldSpent = data.totalGoldSpent;
        totalBallsShot = data.totalBallsShot;
        totalBallsDropped = data.totalBallsDropped;
        totalPegsHit = data.totalPegsHit;
        totalBoardsCleared = data.totalBoardsCleared;
        greenPegChance = data.greenPegChance;
        greenPegsHit = data.greenPegsHit;
        goldenPegsHit = data.goldenPegsHit;
        prestigePegsHit = data.prestigePegsHit;
        redPegsHit = data.redPegsHit;
        totalPegGold = data.totalPegGold;
        totalBallsPit = data.totalBallsPit;
        totalPitGold = data.totalPitGold;
        prestigeUpgradesPurchased = data.prestigeUpgradesPurchased;
        levelsUnlocked = data.levelsUnlocked;
        totalPegsUnlocked = data.totalPegsUnlocked;

        totalPrestigePointSpent = data.totalPrestigePointSpent;
        totalPRestigePoints = data.totalPRestigePoints;

        rainbowPegsHit = data.rainbowPegsHit;
        bombPegsHit = data.bombPegsHit;
        purplePegHit = data.purplePegHit;

        timesFullyCharge = data.timesFullyCharge;
        timesGoldRush = data.timesGoldRush;
        timesPrestigeRush = data.timesPrestigeRush;
        goldFromClear = data.goldFromClear;
        goldFromShooting = data.goldFromShootingStat;
        prestigePointFromClear = data.prestigePointFromClear;
        prestigePointsFromBucket = data.prestigePointsFromBucket;

        totalPrestigePointOverflow = data.totalPrestigePointOverflow;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.totalGold = totalGold;
        data.totalGoldSpent = totalGoldSpent;
        data.totalBallsShot = totalBallsShot;
        data.totalBallsDropped = totalBallsDropped;
        data.totalPegsHit = totalPegsHit;
        data.totalBoardsCleared = totalBoardsCleared;
        data.greenPegChance = greenPegChance;
        data.greenPegsHit = greenPegsHit;
        data.goldenPegsHit = goldenPegsHit;
        data.prestigePegsHit = prestigePegsHit;
        data.redPegsHit = redPegsHit;
        data.totalPegGold = totalPegGold;
        data.totalBallsPit = totalBallsPit;
        data.totalPitGold = totalPitGold;
        data.prestigeUpgradesPurchased = prestigeUpgradesPurchased;
        data.levelsUnlocked = levelsUnlocked;
        data.totalPegsUnlocked = totalPegsUnlocked;

        data.totalPrestigePointSpent = totalPrestigePointSpent;
        data.totalPRestigePoints = totalPRestigePoints;

        data.rainbowPegsHit = rainbowPegsHit;
        data.bombPegsHit = bombPegsHit;
        data.purplePegHit = purplePegHit;

        data.timesFullyCharge = timesFullyCharge;
        data.timesGoldRush = timesGoldRush;
        data.timesPrestigeRush = timesPrestigeRush;
        data.goldFromClear = goldFromClear;
        data.goldFromShootingStat = goldFromShooting;
        data.prestigePointFromClear = prestigePointFromClear;
        data.prestigePointsFromBucket = prestigePointsFromBucket;

        data.totalPrestigePointOverflow = totalPrestigePointOverflow;
    }
    #endregion
}
