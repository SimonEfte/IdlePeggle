using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievements : MonoBehaviour, IDataPersistence
{
    public GameObject achToolTip;
    public static bool[] achCompleted = new bool[79];
    public static bool[] newAchCompleted = new bool[5];
    public GameObject[] achLocked;
    public GameObject[] newAchLocked;
    public TextMeshProUGUI achAchievedText;
    public static int achCount, totalAchCount;

    public static int goldRushNeeded2, prestigeRushNeeded2;

    //!!!!!!!!!!!!!!!
    //When changing ach requirments.
    //Change inside steam, this script and LocalizationString tool tip which in on the ACH GAMEOBJECT SCRIPT COMPONENT.
    //!!!!!!!!!!!!!!!

    public void Awake()
    {
        goldRushNeeded2 = 25;
        prestigeRushNeeded2 = 25;
    }

    public void Start()
    {
        totalAchCount = 84;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.15f);

        int achAchieved = 0;

        for (int i = 0; i < 79; i++)
        {
            if(achCompleted[i] == true) { achAchieved += 1; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (newAchCompleted[i] == true) { achAchieved += 1; }
        }

        achCount = achAchieved;

        for (int i = 0; i < achCompleted.Length; i++)
        {
            if(achCompleted[i] == true) { achLocked[i].SetActive(false); }
        }

        for (int i = 0; i < newAchCompleted.Length; i++)
        {
            if (newAchCompleted[i] == true) { newAchLocked[i].SetActive(false); }
        }

        achAchievedText.text = achCount + "/" + totalAchCount;

        CheckChallAch();
        CheckGoldGainACH();
        CheckPegACH();
        CheckUnlockBalls();
        CheckNewLevelACH();
        CheckTotalPrestigeACH();
        CheckBallsShotACH();
        CheckBallsDroppedACH();
        CheckPrestigeUpgradesACH();
        Check2XorMoreShots();
        CheckBoardClears();
        CheckFullChargeACH();
        CheckBuffsACH();

        if(MobileScript.isMobile == false) { CheckACH(); }
    }

    public void Update()
    {
        if(achievementsToolTip.isHoveringACH == true) 
        {
            if (MobileScript.isMobile == true) { return; }
            achToolTip.transform.position = Input.mousePosition; achToolTip.SetActive(true);
        }
        else
        {
            if (MobileScript.isMobile == false) { achToolTip.SetActive(false); }
        }
    }

    #region Ach 1-5 (Challenge ACH)
    public void CheckChallAch()
    {
        if (!achCompleted[0]) { if (Challenges.challengesCompleted >= 1) { TriggerACH("challenge_1", 0); } }
        if (!achCompleted[1]) { if (Challenges.challengesCompleted >= 5) { TriggerACH("challenge_5", 1); } }
        if (!achCompleted[2]) { if (Challenges.challengesCompleted >= 10) { TriggerACH("challenge_10", 2); } }
        if (!achCompleted[3]) { if (Challenges.challengesCompleted >= 20) { TriggerACH("challenge_20", 3); } }
        if (!achCompleted[4]) { if (Challenges.challengesCompleted >= 37) { TriggerACH("challenge_all", 4); } }
    }
    #endregion

    #region Ach 6-15 (Gold gain ACH)
    public void CheckGoldGainACH()
    {
        if (!achCompleted[5]) { if (BallUpgrades.points >= 100) { TriggerACH("gold_100", 5); } }
        if (!achCompleted[6]) { if (BallUpgrades.points >= 1000000) { TriggerACH("gold_1million", 6); } }
        if (!achCompleted[7]) { if (BallUpgrades.points >= 1000000000) { TriggerACH("gold_1billion", 7); } }
        if (!achCompleted[8]) { if (BallUpgrades.points >= 1000000000000) { TriggerACH("gold_1trillion", 8); } }
        if (!achCompleted[9]) { if (BallUpgrades.points >= 1000000000000000) { TriggerACH("gold_quadrillion", 9); } }
        if (!achCompleted[10]) { if (BallUpgrades.points >= 1000000000000000000) { TriggerACH("gold_quintillion", 10); } }
        if (!achCompleted[11]) { if (BallUpgrades.points >= 1000000000000000000000f) { TriggerACH("gold_sextillion", 11); } }
        if (!achCompleted[12]) { if (BallUpgrades.points >= 1000000000000000000000000f) { TriggerACH("gold_septillion", 12); } }
        if (!achCompleted[13]) { if (BallUpgrades.points >= 1000000000000000000000000000f) { TriggerACH("gold_octillion", 13); } }
        if (!achCompleted[14]) { if (BallUpgrades.points >= 1000000000000000000000000000000f) { TriggerACH("gold_nonillion", 14); } }
        if (!newAchCompleted[0]) { if (BallUpgrades.points >= 1000000000000000000000000000000000f) { TriggerNewACH("gold_1Decillion", 0); } }
        if (!newAchCompleted[1]) { if (BallUpgrades.points >= 1000000000000000000000000000000000000f) { TriggerNewACH("gold_undecillion", 1); } }
        if (!newAchCompleted[2]) { if (BallUpgrades.points >= 1000000000000000000000000000000000000000d) { TriggerNewACH("gold_duodecillion", 2); } }
        if (!newAchCompleted[3]) { if (BallUpgrades.points >= 1000000000000000000000000000000000000000000d) { TriggerNewACH("gold_tredecillion", 3); } }
        if (!newAchCompleted[4]) { if (BallUpgrades.points >= 1000000000000000000000000000000000000000000000d) { TriggerNewACH("gold_quattuordecillion", 4); } }
    }
    #endregion

    #region Ach 16-26 (Peg ACH)
    public void CheckPegACH()
    {
        //Green pegs
        if (!achCompleted[15]) { if (AllStats.totalPegsHit >= 100) { TriggerACH("ach_100pegs", 15); } }
        if (!achCompleted[16]) { if (AllStats.totalPegsHit >= 10000) { TriggerACH("ach_10000pegs", 16); } }
        if (!achCompleted[17]) { if (AllStats.totalPegsHit >= 5000000) { TriggerACH("ach_1mpegs", 17); } }

        //Red pegs
        if (!achCompleted[18]) { if (AllStats.redPegsHit >= 5) { TriggerACH("ach_1redpeg", 18); } }
        if (!achCompleted[19]) { if (AllStats.redPegsHit >= 10000) { TriggerACH("ach_1000redpegs", 19); } }

        //Rainbow pegs
        if (!achCompleted[20]) { if (AllStats.rainbowPegsHit >= 5) { TriggerACH("ach_1rainbowpeg", 20); } }
        if (!achCompleted[21]) { if (AllStats.rainbowPegsHit >= 10000) { TriggerACH("ach_1000rainbowpegs", 21); } }

        if (!achCompleted[22]) { if (AllStats.bombPegsHit >= 5) { TriggerACH("ach_1bompeg", 22); } }
        if (!achCompleted[23]) { if (AllStats.bombPegsHit >= 10000) { TriggerACH("ach_1000bombpegs", 23); } }

        if (!achCompleted[24]) { if (AllStats.purplePegHit >= 5) { TriggerACH("ach_1purplepeg", 24); } }
        if (!achCompleted[25]) { if (AllStats.purplePegHit >= 10000) { TriggerACH("ach_1000purplepegs", 25); } }
    }
    #endregion

    #region Ach 27-33 (New ball ACH)
    public void CheckUnlockBalls()
    {
        if (!achCompleted[26]) { if (BallUpgrades.bouncyBallPurchased == true) { TriggerACH("unlock_newball", 26); } }
        if (!achCompleted[27]) { if (BallUpgrades.bombBallPurchased == true) { TriggerACH("unlock_3balls", 27); } }
        if (!achCompleted[28]) { if (BallUpgrades.basketBallPurchased == true) { TriggerACH("unlock_6balls", 28); } }
        if (!achCompleted[29]) { if (BallUpgrades.candyBallPurchased == true) { TriggerACH("unlock_9balls", 29); } }
        if (!achCompleted[30]) { if (BallUpgrades.footballBallPurchased == true) { TriggerACH("unlock_13balls", 30); } }
        if (!achCompleted[31]) { if (BallUpgrades.peggoBallPurchased == true) { TriggerACH("unlock_17balls", 31); } }
        if (!achCompleted[32]) { if (BallUpgrades.glitchyBallPurchased == true) { TriggerACH("unlock_allballs", 32); } }
    }
    #endregion

    #region Ach 34-42 (New level ACH)
    public void CheckNewLevelACH()
    {
        if (!achCompleted[33]) { if (Prestige.purchasedLevel2 == true) { TriggerACH("level2", 33); } }
        if (!achCompleted[34]) { if (Prestige.purchasedLevel3 == true) { TriggerACH("level3", 34); } }
        if (!achCompleted[35]) { if (Prestige.purchasedLevel4 == true) { TriggerACH("level4", 35); } }
        if (!achCompleted[36]) { if (Prestige.purchasedLevel5 == true) { TriggerACH("level5", 36); } }
        if (!achCompleted[37]) { if (Prestige.purchasedLevel6 == true) { TriggerACH("level6", 37); } }
        if (!achCompleted[38]) { if (Prestige.purchasedLevel7 == true) { TriggerACH("level7", 38); } }
        if (!achCompleted[39]) { if (Prestige.purchasedLevel8 == true) { TriggerACH("level8", 39); } }
        if (!achCompleted[40]) { if (Prestige.purchasedLevel9 == true) { TriggerACH("level9", 40); } }
        if (!achCompleted[41]) { if (Prestige.purchasedLevel10 == true) { TriggerACH("level10", 41); } }
    }
    #endregion

    #region Ach 43-47 (Total prestige points ach)
    public void CheckTotalPrestigeACH()
    {
        if (!achCompleted[42]) { if (Prestige.prestigePoints >= 100) { TriggerACH("prestigepoint_100", 42); } }
        if (!achCompleted[43]) { if (Prestige.prestigePoints >= 1000) { TriggerACH("prestigePoint_1000", 43); } }
        if (!achCompleted[44]) { if (Prestige.prestigePoints >= 10000) { TriggerACH("prestigePoint_10000", 44); } }
        if (!achCompleted[45]) { if (Prestige.prestigePoints >= 100000) { TriggerACH("prestigePoint_100000", 45); } }
        if (!achCompleted[46]) { if (Prestige.prestigePoints >= 10000000) { TriggerACH("prestigePoint_1million", 46); } }
    }
    #endregion

    #region Ach 48-50 (Balls shot ACH)
    public void CheckBallsShotACH()
    {
        if (!achCompleted[47]) { if (AllStats.totalBallsShot >= 100) { TriggerACH("shoot100balls", 47); } }
        if (!achCompleted[48]) { if (AllStats.totalBallsShot >= 5000) { TriggerACH("shoot5000balls", 48); } }
        if (!achCompleted[49]) { if (AllStats.totalBallsShot >= 20000) { TriggerACH("shoot100000balls", 49); } }
    }
    #endregion

    #region Ach 51-55 (Balls dropped ACH)
    public void CheckBallsDroppedACH()
    {
        if (!achCompleted[50]) { if (AllStats.totalBallsDropped >= 100) { TriggerACH("drop100balls", 50); } }
        if (!achCompleted[51]) { if (AllStats.totalBallsDropped >= 10000) { TriggerACH("drop10000balls", 51); } }
        if (!achCompleted[52]) { if (AllStats.totalBallsDropped >= 100000) { TriggerACH("drop100000balls", 52); } }
        if (!achCompleted[53]) { if (AllStats.totalBallsDropped >= 1000000) { TriggerACH("drop1millionballs", 53); } }
        if (!achCompleted[54]) { if (AllStats.totalBallsDropped >= 10000000) { TriggerACH("drop10millionballs", 54); } }
    }
    #endregion

    #region Ach 56-64 (Prestige upgrades purchased ACH)
    public void CheckPrestigeUpgradesACH()
    {
        if (!achCompleted[55]) { if (AllStats.prestigeUpgradesPurchased >= 5) { TriggerACH("prestigeUpgrade5", 55); } }
        if (!achCompleted[56]) { if (AllStats.prestigeUpgradesPurchased >= 10) { TriggerACH("prestigeUpgrade10", 56); } }
        if (!achCompleted[57]) { if (AllStats.prestigeUpgradesPurchased >= 25) { TriggerACH("prestigeUpgrade25", 57); } }
        if (!achCompleted[58]) { if (AllStats.prestigeUpgradesPurchased >= 50) { TriggerACH("prestigeUpgrade50", 58); } }
        if (!achCompleted[59]) { if (AllStats.prestigeUpgradesPurchased >= 80) { TriggerACH("prestigeUpgrade80", 59); } }
        if (!achCompleted[60]) { if (AllStats.prestigeUpgradesPurchased >= 100) { TriggerACH("prestigeUpgrade100", 60); } }
        if (!achCompleted[61]) { if (AllStats.prestigeUpgradesPurchased >= 130) { TriggerACH("prestigeUpgrade130", 61); } }
        if (!achCompleted[62]) { if (AllStats.prestigeUpgradesPurchased >= 150) { TriggerACH("prestigeUpgrade150", 62); } }
        if (!achCompleted[63]) { if (AllStats.prestigeUpgradesPurchased == 176) { TriggerACH("prestigeUpgradeALL", 63); } }
    }
    #endregion

    #region Ach 65-68 (2X shots or more ACH)
    public void Check2XorMoreShots()
    {
        if (!achCompleted[64]) { if (Prestige.totalBallShots == 2) { TriggerACH("shoot2balls", 64); } }
        if (!achCompleted[65]) { if (Prestige.totalBallShots == 3) { TriggerACH("shoot3balls", 65); } }
        if (!achCompleted[66]) { if (Prestige.totalBallShots == 4) { TriggerACH("shoot4balls", 66); } }
        if (!achCompleted[67]) { if (Prestige.totalBallShots == 5) { TriggerACH("shoot5balls", 67); } }
    }
    #endregion

    #region Ach 69-71 (Board clears ACH)
    public void CheckBoardClears()
    {
        if (!achCompleted[68]) { if (AllStats.totalBoardsCleared >= 1) { TriggerACH("clearBoard", 68); } }
        if (!achCompleted[69]) { if (AllStats.totalBoardsCleared >= 1000) { TriggerACH("clearBoard1000", 69); } }
        if (!achCompleted[70]) { if (AllStats.totalBoardsCleared >= 50000) { TriggerACH("clearBoard100000", 70); } }
    }
    #endregion

    #region Ach 72-74 (Fully charge ACH)
    public void CheckFullChargeACH()
    {
        if (!achCompleted[71]) { if (AllStats.timesFullyCharge >= 1) { TriggerACH("fullCharge", 71); } }
        if (!achCompleted[72]) { if (AllStats.timesFullyCharge >= 10) { TriggerACH("fullCharg10", 72); } }
        if (!achCompleted[73]) { if (AllStats.timesFullyCharge >= 1000) { TriggerACH("fullCharge1000", 73); } }
    }
    #endregion

    #region Ach 75-79 (Gold rush and buffs ACH)
    public void CheckBuffsACH()
    {
        if (!achCompleted[74]) { if (AllStats.timesGoldRush >= 1) { TriggerACH("goldRush", 74); } }
        if (!achCompleted[75]) { if (AllStats.timesGoldRush >= goldRushNeeded2) { TriggerACH("goldRush100", 75); } }

        if (!achCompleted[76]) { if (AllStats.timesPrestigeRush >= 1) { TriggerACH("prestigeRush", 76); } }
        if (!achCompleted[77]) { if (AllStats.timesPrestigeRush >= prestigeRushNeeded2) { TriggerACH("prestigeRush25", 77); } }

        if (!achCompleted[78]) { if (Levels.isGoldRush == true && Levels.isPRestigeRush == true && Levels.isRainbowGoldBucket == true && Levels.isRainbowGoldPeg == true && Levels.isRainbowPRestige == true && Levels.isRainbowPRestigeBucket == true) { TriggerACH("allBuffs", 78); } }
    }
    #endregion

    #region Trigger ACH
    public void TriggerACH(string achNAME, int achNumber)
    {
        if(SteamIntregation.noSteamInt == true) { return; }

        if(GameData.isDemo == false)
        {
            // var ach = new Steamworks.Data.Achievement(achNAME);
            // if (ach.State == false)
            // {
            // ach.Trigger();
            //  }

            achLocked[achNumber].SetActive(false);
            achCompleted[achNumber] = true;
            achCount += 1;
            achAchievedText.text = achCount + "/" + totalAchCount;
        }
    }

    public void TriggerNewACH(string achNAME, int achNumber)
    {
        if (SteamIntregation.noSteamInt == true) { return; }

        if (GameData.isDemo == false)
        {
            //  var ach = new Steamworks.Data.Achievement(achNAME);
            //  if (ach.State == false)
            //  {
            //   ach.Trigger();
            //  }

            newAchLocked[achNumber].SetActive(false);
            newAchCompleted[achNumber] = true;
            achCount += 1;
            achAchievedText.text = achCount + "/" + totalAchCount;
        }
    }
    #endregion

    #region Check and trigger ACH on startup
    public void CheckACH()
    {
        if (achCompleted[0] == true) { TriggerACHStartUp("challenge_1"); }
        if (achCompleted[1] == true) { TriggerACHStartUp("challenge_5"); }
        if (achCompleted[2] == true) { TriggerACHStartUp("challenge_10"); }
        if (achCompleted[3] == true) { TriggerACHStartUp("challenge_20"); }
        if (achCompleted[4] == true) { TriggerACHStartUp("challenge_all"); }
        if (achCompleted[5] == true) { TriggerACHStartUp("gold_100"); }
        if (achCompleted[6] == true) { TriggerACHStartUp("gold_1million"); }
        if (achCompleted[7] == true) { TriggerACHStartUp("gold_1billion"); }
        if (achCompleted[8] == true) { TriggerACHStartUp("gold_1trillion"); }
        if (achCompleted[9] == true) { TriggerACHStartUp("gold_quadrillion"); }
        if (achCompleted[10] == true) { TriggerACHStartUp("gold_quintillion"); }
        if (achCompleted[11] == true) { TriggerACHStartUp("gold_sextillion"); }
        if (achCompleted[12] == true) { TriggerACHStartUp("gold_septillion"); }
        if (achCompleted[13] == true) { TriggerACHStartUp("gold_octillion"); }
        if (achCompleted[14] == true) { TriggerACHStartUp("gold_nonillion"); }
        if (achCompleted[15] == true) { TriggerACHStartUp("ach_100pegs"); }
        if (achCompleted[16] == true) { TriggerACHStartUp("ach_10000pegs"); }
        if (achCompleted[17] == true) { TriggerACHStartUp("ach_1mpegs"); }
        if (achCompleted[18] == true) { TriggerACHStartUp("ach_1redpeg"); }
        if (achCompleted[19] == true) { TriggerACHStartUp("ach_1000redpegs"); }
        if (achCompleted[20] == true) { TriggerACHStartUp("ach_1rainbowpeg"); }
        if (achCompleted[21] == true) { TriggerACHStartUp("ach_1000rainbowpegs"); }
        if (achCompleted[22] == true) { TriggerACHStartUp("ach_1bompeg"); }
        if (achCompleted[23] == true) { TriggerACHStartUp("ach_1000bombpegs"); }
        if (achCompleted[24] == true) { TriggerACHStartUp("ach_1purplepeg"); }
        if (achCompleted[25] == true) { TriggerACHStartUp("ach_1000purplepegs"); }
        if (achCompleted[26] == true) { TriggerACHStartUp("unlock_newball"); }
        if (achCompleted[27] == true) { TriggerACHStartUp("unlock_3balls"); }
        if (achCompleted[28] == true) { TriggerACHStartUp("unlock_6balls"); }
        if (achCompleted[29] == true) { TriggerACHStartUp("unlock_9balls"); }
        if (achCompleted[30] == true) { TriggerACHStartUp("unlock_13balls"); }
        if (achCompleted[31] == true) { TriggerACHStartUp("unlock_17balls"); }
        if (achCompleted[32] == true) { TriggerACHStartUp("unlock_allballs"); }
        if (achCompleted[33] == true) { TriggerACHStartUp("level2"); }
        if (achCompleted[34] == true) { TriggerACHStartUp("level3"); }
        if (achCompleted[35] == true) { TriggerACHStartUp("level4"); }
        if (achCompleted[36] == true) { TriggerACHStartUp("level5"); }
        if (achCompleted[37] == true) { TriggerACHStartUp("level6"); }
        if (achCompleted[38] == true) { TriggerACHStartUp("level7"); }
        if (achCompleted[39] == true) { TriggerACHStartUp("level8"); }
        if (achCompleted[40] == true) { TriggerACHStartUp("level9"); }
        if (achCompleted[41] == true) { TriggerACHStartUp("level10"); }
        if (achCompleted[42] == true) { TriggerACHStartUp("prestigepoint_100"); }
        if (achCompleted[43] == true) { TriggerACHStartUp("prestigePoint_1000"); }
        if (achCompleted[44] == true) { TriggerACHStartUp("prestigePoint_10000"); }
        if (achCompleted[45] == true) { TriggerACHStartUp("prestigePoint_100000"); }
        if (achCompleted[46] == true) { TriggerACHStartUp("prestigePoint_1million"); }
        if (achCompleted[47] == true) { TriggerACHStartUp("shoot100balls"); }
        if (achCompleted[48] == true) { TriggerACHStartUp("shoot5000balls"); }
        if (achCompleted[49] == true) { TriggerACHStartUp("shoot100000balls"); }
        if (achCompleted[50] == true) { TriggerACHStartUp("drop100balls"); }
        if (achCompleted[51] == true) { TriggerACHStartUp("drop10000balls"); }
        if (achCompleted[52] == true) { TriggerACHStartUp("drop100000balls"); }
        if (achCompleted[53] == true) { TriggerACHStartUp("drop1millionballs"); }
        if (achCompleted[54] == true) { TriggerACHStartUp("drop10millionballs"); }
        if (achCompleted[55] == true) { TriggerACHStartUp("prestigeUpgrade5"); }
        if (achCompleted[56] == true) { TriggerACHStartUp("prestigeUpgrade10"); }
        if (achCompleted[57] == true) { TriggerACHStartUp("prestigeUpgrade25"); }
        if (achCompleted[58] == true) { TriggerACHStartUp("prestigeUpgrade50"); }
        if (achCompleted[59] == true) { TriggerACHStartUp("prestigeUpgrade80"); }
        if (achCompleted[60] == true) { TriggerACHStartUp("prestigeUpgrade100"); }
        if (achCompleted[61] == true) { TriggerACHStartUp("prestigeUpgrade130"); }
        if (achCompleted[62] == true) { TriggerACHStartUp("prestigeUpgrade150"); }
        if (achCompleted[63] == true) { TriggerACHStartUp("prestigeUpgradeALL"); }
        if (achCompleted[64] == true) { TriggerACHStartUp("shoot2balls"); }
        if (achCompleted[65] == true) { TriggerACHStartUp("shoot3balls"); }
        if (achCompleted[66] == true) { TriggerACHStartUp("shoot4balls"); }
        if (achCompleted[67] == true) { TriggerACHStartUp("shoot5balls"); }
        if (achCompleted[68] == true) { TriggerACHStartUp("clearBoard"); }
        if (achCompleted[69] == true) { TriggerACHStartUp("clearBoard1000"); }
        if (achCompleted[70] == true) { TriggerACHStartUp("clearBoard100000"); }
        if (achCompleted[71] == true) { TriggerACHStartUp("fullCharge"); }
        if (achCompleted[72] == true) { TriggerACHStartUp("fullCharg10"); }
        if (achCompleted[73] == true) { TriggerACHStartUp("fullCharge1000"); }
        if (achCompleted[74] == true) { TriggerACHStartUp("goldRush"); }
        if (achCompleted[75] == true) { TriggerACHStartUp("goldRush100"); }
        if (achCompleted[76] == true) { TriggerACHStartUp("prestigeRush"); }
        if (achCompleted[77] == true) { TriggerACHStartUp("prestigeRush25"); }
        if (achCompleted[78] == true) { TriggerACHStartUp("allBuffs"); }

        if (newAchCompleted[0] == true) { TriggerACHStartUp("gold_1Decillion"); }
        if (newAchCompleted[1] == true) { TriggerACHStartUp("gold_undecillion"); }
        if (newAchCompleted[2] == true) { TriggerACHStartUp("gold_duodecillion"); }
        if (newAchCompleted[3] == true) { TriggerACHStartUp("gold_tredecillion"); }
        if (newAchCompleted[4] == true) { TriggerACHStartUp("gold_quattuordecillion"); }
    }


    public void TriggerACHStartUp(string achNAME)
    {
        if (SteamIntregation.noSteamInt == true) { return; }

        if (GameData.isDemo == false)
        {
           // var ach = new Steamworks.Data.Achievement(achNAME);
            //if (ach.State == false)
            //{
            //    ach.Trigger();
            //}
        }
    }
    #endregion

    #region Clear ACH
    public void AchClear(string achNAME)
    {
        //var ach = new Steamworks.Data.Achievement(achNAME);
        //ach.Clear();
    }

    public void ClearACH()
    {
        AchClear("gold_100");
        AchClear("gold_1million");
        AchClear("gold_1billion");
        AchClear("gold_1trillion");
        AchClear("gold_quadrillion");
        AchClear("gold_quintillion");
        AchClear("gold_sextillion");
        AchClear("gold_septillion");
        AchClear("gold_octillion");
        AchClear("gold_nonillion");
        AchClear("gold_1Decillion");
        AchClear("gold_undecillion");
        AchClear("gold_duodecillion");
        AchClear("gold_tredecillion");
        AchClear("gold_quattuordecillion");

        AchClear("challenge_1");
        AchClear("challenge_5");
        AchClear("challenge_10");
        AchClear("challenge_20");
        AchClear("challenge_all");

        AchClear("level2");
        AchClear("level3");
        AchClear("level4");
        AchClear("level5");
        AchClear("level6");
        AchClear("level7");
        AchClear("level8");
        AchClear("level9");
        AchClear("level10");

        AchClear("prestigepoint_100");
        AchClear("prestigePoint_1000");
        AchClear("prestigePoint_10000");
        AchClear("prestigePoint_100000");
        AchClear("prestigePoint_1million");

        AchClear("ach_100pegs");
        AchClear("ach_10000pegs");
        AchClear("ach_1mpegs");
        AchClear("ach_1redpeg");
        AchClear("ach_1000redpegs");
        AchClear("ach_1rainbowpeg");
        AchClear("ach_1000rainbowpegs");
        AchClear("ach_1bompeg");
        AchClear("ach_1000bombpegs");
        AchClear("ach_1purplepeg");
        AchClear("ach_1000purplepegs");

        AchClear("unlock_newball");
        AchClear("unlock_3balls");
        AchClear("unlock_6balls");
        AchClear("unlock_9balls");
        AchClear("unlock_13balls");
        AchClear("unlock_17balls");
        AchClear("unlock_allballs");

        AchClear("shoot100balls");
        AchClear("shoot5000balls");
        AchClear("shoot100000balls");

        AchClear("drop100balls");
        AchClear("drop10000balls");
        AchClear("drop100000balls");
        AchClear("drop1millionballs");
        AchClear("drop10millionballs");

        AchClear("prestigeUpgrade5");
        AchClear("prestigeUpgrade10");
        AchClear("prestigeUpgrade25");
        AchClear("prestigeUpgrade50");
        AchClear("prestigeUpgrade80");
        AchClear("prestigeUpgrade100");
        AchClear("prestigeUpgrade130");
        AchClear("prestigeUpgrade150");
        AchClear("prestigeUpgradeALL");

        AchClear("shoot2balls");
        AchClear("shoot3balls");
        AchClear("shoot4balls");
        AchClear("shoot5balls");

        AchClear("clearBoard");
        AchClear("clearBoard1000");
        AchClear("clearBoard100000");

        AchClear("fullCharge");
        AchClear("fullCharg10");
        AchClear("fullCharge1000");

        AchClear("goldRush");
        AchClear("goldRush100");
        AchClear("prestigeRush");
        AchClear("prestigeRush25");
        AchClear("allBuffs");
    }
    #endregion

    public void ResetACH()
    {
        for (int i = 0; i < achLocked.Length; i++)
        {
            achLocked[i].SetActive(true);
            achCompleted[i] = false;
        }

        for (int i = 0; i < newAchLocked.Length; i++)
        {
            newAchLocked[i].SetActive(true);
            newAchCompleted[i] = false;
        }

        achCount = 0;
        achAchievedText.text = achCount + "/" + totalAchCount;
    }

    #region Load Data
    public void LoadData(GameData data)
    {
        achCount = data.achCount;
        for (int i = 0; i < achCompleted.Length; i++)
        {
            achCompleted[i] = data.achCompleted[i];
        }

        for (int i = 0; i < newAchCompleted.Length; i++)
        {
            newAchCompleted[i] = data.newAchCompleted[i];
        }
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.achCount = achCount;
        for (int i = 0; i < achCompleted.Length; i++)
        {
            data.achCompleted[i] = achCompleted[i];
        }

        for (int i = 0; i < newAchCompleted.Length; i++)
        {
            data.newAchCompleted[i] = newAchCompleted[i];
        }
    }
    #endregion

}
