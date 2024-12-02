using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Challenges : MonoBehaviour, IDataPersistence
{
    public GameObject[] incompletedButtons;
    public GameObject[] completedButtons;
    public GameObject[] claimButtons;
    public GameObject[] challengesFrames;

    public static bool[] challFinished = new bool[37];
    public static bool[] challCompleted = new bool[37];
    public static int totalChallenges;
    public static int challengesCompleted;

    public GameObject gridLayout;

    public TextMeshProUGUI challCompletedText;
    public TextMeshProUGUI[] challNumberText;
    public GameObject challengeFrame, settingsFrame;

    public TextMeshProUGUI[] progressText;

    public void SetChallengeNumberText()
    {
        for (int i = 0; i < totalChallenges; i++)
        {
            challNumberText[i].text = LocalizationStrings.challenge + (i + 1);
        }

        for (int i = 0; i < totalChallenges; i++)
        {
            if(challCompleted[i] == true) { progressText[i].color = Color.green; }
            else { progressText[i].color = Color.red; }
        }
    }

    private void Awake()
    {
        SetReachVariables();
        SetRewardVariables();
    }

    public void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);

        if (GameData.isDemo == false)
        {
            for (int i = 0; i < Challenges.challCompleted.Length; i++)
            {
                //Debug.Log( i + " challenge is = " + Challenges.challCompleted[i]);
            }
        }

        totalChallenges = 37;
        if(challengesCompleted > 37) { challengesCompleted = 37; }
        challCompletedText.text = challengesCompleted + "/" + totalChallenges;

        SetChallengeNumberText();
        SetChallengeRewardText();
        SetRewardText();

        for (int i = 0; i < totalChallenges; i++)
        {
            if (challCompleted[i] == true)
            {
                incompletedButtons[i].SetActive(false);
                completedButtons[i].SetActive(true);

                GameObject secondChallengeFrame = challengesFrames[i];
                int currentIndex = secondChallengeFrame.transform.GetSiblingIndex();
                secondChallengeFrame.transform.SetSiblingIndex(36);
            }
        }

        CheckFinished();
        CheckCompletedChall();
        locScript.SetBallDesText(); 

        if(challCompleted[24] == true) { GiveReward(24); }
        if (challCompleted[25] == true) { GiveReward(25); }
        if (challCompleted[26] == true) { GiveReward(26); }
        if (challCompleted[27] == true) { GiveReward(27); }
        if (challCompleted[28] == true) { GiveReward(28); }
        if (challCompleted[29] == true) { GiveReward(29); }
        if (challCompleted[30] == true) { GiveReward(30); }
        if (challCompleted[31] == true) { GiveReward(31); }
        if (challCompleted[32] == true) { GiveReward(32); }
        if (challCompleted[33] == true) { GiveReward(33); }
        if (challCompleted[34] == true) { GiveReward(34); }
        if (challCompleted[35] == true) { GiveReward(35); }
        if (challCompleted[36] == true) { GiveReward(36); }
    }

    #region Check finished
    public void CheckFinished()
    {
        //Board clears
        CheckCompleted(1, Levels.board1Clears);
        CheckCompleted(2, Levels.board2Clears);
        CheckCompleted(3, Levels.board3Clears);
        CheckCompleted(4, Levels.board4Clears);
        CheckCompleted(5, Levels.board5Clears);
        CheckCompleted(6, Levels.board6Clears);
        CheckCompleted(7, Levels.board7Clears);
        CheckCompleted(8, Levels.board8Clears);
        CheckCompleted(9, Levels.board9Clears);
        CheckCompleted(10, Levels.board10Clears);

        //Auto drop maxxed
        CheckCompleted(11, ballsReachedMaxAuto);
        CheckCompleted(12, ballsReachedMaxAuto);
        CheckCompleted(13, ballsReachedMaxAuto);
        CheckCompleted(14, ballsReachedMaxAuto);

        //Ball Level
        CheckCompleted(15, ballUpgradeLevel);
        CheckCompleted(16, ballUpgradeLevel);
        CheckCompleted(17, ballUpgradeLevel);

        //Golden pegs hit
        CheckCompleted(18, AllStats.goldenPegsHit);
        CheckCompleted(19, AllStats.goldenPegsHit);
        CheckCompleted(20, AllStats.goldenPegsHit);

        //Buckets entered
        CheckCompleted(21, AllStats.totalBallsPit);
        CheckCompleted(22, AllStats.totalBallsPit);
        CheckCompleted(23, AllStats.totalBallsPit);

        CheckCompleted(24, redBallBounceCount);
        CheckCompleted(25, tinyBallsCount);
        CheckCompleted(26, basketBallPegHitCount);
        CheckCompleted(27, eggDoubleGoldCount);
        CheckCompleted(28, cookieBallExtraCount);
        CheckCompleted(29, goldenBallExtraCount);
        CheckCompleted(30, footballBucketCount);
        CheckCompleted(31, tinyRingBallsCount);
        CheckCompleted(32, prestigeGemsHit);
        CheckCompleted(33, BasicBall.ghostBallsOnScreen);
        CheckCompleted(34, starBallsSpawned);
        CheckCompleted(35, (int)(BallUpgrades.totalRainbowBallIncrease * 100));
        CheckCompleted(36, tinyGlitchyBallsSpawned);
        CheckCompleted(37, tinySharpnelCount);
    }
    #endregion


    public void CheckCompletedChall()
    {
        #region If chall is completed
        if (challCompleted[0] == true || challFinished[0] == true) { progressText[0].text = $"(15/15)"; progressText[0].color = Color.green; }
        if (challCompleted[1] == true || challFinished[1] == true) { progressText[1].text = $"(15/15)"; progressText[1].color = Color.green; }
        if (challCompleted[2] == true || challFinished[2] == true) { progressText[2].text = $"(16/16)"; progressText[2].color = Color.green; }
        if (challCompleted[3] == true || challFinished[3] == true) { progressText[3].text = $"(16/16)"; progressText[3].color = Color.green; }
        if (challCompleted[4] == true || challFinished[4] == true) { progressText[4].text = $"(17/17)"; progressText[4].color = Color.green; }
        if (challCompleted[5] == true || challFinished[5] == true) { progressText[5].text = $"(17/17)"; progressText[5].color = Color.green; }
        if (challCompleted[6] == true || challFinished[6] == true) { progressText[6].text = $"(18/18)"; progressText[6].color = Color.green; }
        if (challCompleted[7] == true || challFinished[7] == true) { progressText[7].text = $"(18/18)"; progressText[7].color = Color.green; }
        if (challCompleted[8] == true || challFinished[8] == true) { progressText[8].text = $"(19/19)"; progressText[8].color = Color.green; }
        if (challCompleted[9] == true || challFinished[9] == true) { progressText[9].text = $"(20/20)"; progressText[9].color = Color.green; }

        if (challCompleted[10] == true || challFinished[10] == true) { progressText[10].text = $"(1/1)"; progressText[10].color = Color.green; }
        if (challCompleted[11] == true || challFinished[11] == true) { progressText[11].text = $"(5/5)"; progressText[11].color = Color.green; }
        if (challCompleted[12] == true || challFinished[12] == true) { progressText[12].text = $"(12/12)"; progressText[12].color = Color.green; }
        if (challCompleted[13] == true || challFinished[13] == true) { progressText[13].text = $"(22/22)"; progressText[13].color = Color.green; }

        if (challCompleted[14] == true || challFinished[14] == true) { progressText[14].text = $"({reachBallLevel1}/{reachBallLevel1})"; progressText[14].color = Color.green; GiveGoldSCaling(); }
        if (challCompleted[15] == true || challFinished[15] == true) { progressText[15].text = $"({reachBallLevel2}/{reachBallLevel2})"; progressText[15].color = Color.green; GiveGoldSCaling(); }
        if (challCompleted[16] == true || challFinished[16] == true) { progressText[16].text = $"({reachBallLevel3}/{reachBallLevel3})"; progressText[16].color = Color.green; GiveGoldSCaling(); }

        if (challCompleted[17] == true || challFinished[17] == true) { progressText[17].text = $"({hitGolden1}/{hitGolden1})"; progressText[17].color = Color.green; }
        if (challCompleted[18] == true || challFinished[18] == true) { progressText[18].text = $"({hitGolden2}/{hitGolden2})"; progressText[18].color = Color.green; }
        if (challCompleted[19] == true || challFinished[19] == true) { progressText[19].text = $"({hitGolden3}/{hitGolden3})"; progressText[19].color = Color.green; }

        if (challCompleted[20] == true || challFinished[20] == true) { progressText[20].text = $"({enterBucket1}/{enterBucket1})"; progressText[20].color = Color.green; }
        if (challCompleted[21] == true || challFinished[21] == true) { progressText[21].text = $"({enterBucket2}/{enterBucket2})"; progressText[21].color = Color.green; }
        if (challCompleted[22] == true || challFinished[22] == true) { progressText[22].text = $"({enterBucket3}/{enterBucket3})"; progressText[22].color = Color.green; }

        if (challCompleted[23] == true || challFinished[23] == true) { progressText[23].text = $"({bounceCH}/{bounceCH})"; progressText[23].color = Color.green; }
        if (challCompleted[24] == true || challFinished[24] == true) { progressText[24].text = $"({explodeTinyCH}/{explodeTinyCH})"; progressText[24].color = Color.green; }
        if (challCompleted[25] == true || challFinished[25] == true) { progressText[25].text = $"({basketballCH}/{basketballCH})"; progressText[25].color = Color.green; }
        if (challCompleted[26] == true || challFinished[26] == true) { progressText[26].text = $"({eggCH}/{eggCH})"; progressText[26].color = Color.green; }
        if (challCompleted[27] == true || challFinished[27] == true) { progressText[27].text = $"({cookieCH}/{cookieCH})"; progressText[27].color = Color.green; }
        if (challCompleted[28] == true || challFinished[28] == true) { progressText[28].text = $"({goldenBallCH}/{goldenBallCH})"; progressText[28].color = Color.green; }
        if (challCompleted[29] == true || challFinished[29] == true) { progressText[29].text = $"({footballCH}/{footballCH})"; progressText[29].color = Color.green; }
        if (challCompleted[30] == true || challFinished[30] == true) { progressText[30].text = $"({tinyRingCH}/{tinyRingCH})"; progressText[30].color = Color.green; }
        if (challCompleted[31] == true || challFinished[31] == true) { progressText[31].text = $"({prestigeGemCH}/{prestigeGemCH})"; progressText[31].color = Color.green; }
        if (challCompleted[32] == true || challFinished[32] == true) { progressText[32].text = $"({ghostballCH}/{ghostballCH})"; progressText[32].color = Color.green; }
        if (challCompleted[33] == true || challFinished[33] == true) { progressText[33].text = $"({starBallCH}/{starBallCH})"; progressText[33].color = Color.green; }
        if (challCompleted[34] == true || challFinished[34] == true) { progressText[34].text = $"({rainbowBallCH}/{rainbowBallCH})"; progressText[34].color = Color.green; }
        if (challCompleted[35] == true || challFinished[35] == true) { progressText[35].text = $"({glitchyBallCH}/{glitchyBallCH})"; progressText[35].color = Color.green; }
        if (challCompleted[36] == true || challFinished[36] == true) { progressText[36].text = $"({sharpnelBallCH}/{sharpnelBallCH})"; progressText[36].color = Color.green; }
        #endregion
    }

    #region Progress and check completed
    public void ChallengeProgress(int challengeNumber ,int progress)
    {
        if(challengeNumber == 1) { progressText[0].text = $"({progress}/15)"; }
        else if (challengeNumber == 2) { progressText[1].text = $"({progress}/15)"; }
        else if (challengeNumber == 3) { progressText[2].text = $"({progress}/16)"; }
        else if (challengeNumber == 4) { progressText[3].text = $"({progress}/16)"; }
        else if (challengeNumber == 5) { progressText[4].text = $"({progress}/17)"; }
        else if (challengeNumber == 6) { progressText[5].text = $"({progress}/17)"; }
        else if (challengeNumber == 7) { progressText[6].text = $"({progress}/18)"; }
        else if (challengeNumber == 8) { progressText[7].text = $"({progress}/18)"; }
        else if (challengeNumber == 9) { progressText[8].text = $"({progress}/19)"; }
        else if (challengeNumber == 10) { progressText[9].text = $"({progress}/20)"; }

        else if (challengeNumber == 11) { progressText[10].text = $"({progress}/1)"; }
        else if (challengeNumber == 12) { progressText[11].text = $"({progress}/5)"; }
        else if (challengeNumber == 13) { progressText[12].text = $"({progress}/12)"; }
        else if (challengeNumber == 14) { progressText[13].text = $"({progress}/22)"; }

        else if (challengeNumber == 15) { progressText[14].text = $"({progress}/{reachBallLevel1})"; }
        else if (challengeNumber == 16) { progressText[15].text = $"({progress}/{reachBallLevel2})"; }
        else if (challengeNumber == 17) { progressText[16].text = $"({progress}/{reachBallLevel3})"; }

        else if (challengeNumber == 18) { progressText[17].text = $"({progress}/{hitGolden1})"; }
        else if (challengeNumber == 19) { progressText[18].text = $"({progress}/{hitGolden2})"; }
        else if (challengeNumber == 20) { progressText[19].text = $"({progress}/{hitGolden3})"; }

        else if (challengeNumber == 21) { progressText[20].text = $"({progress}/{enterBucket1})"; }
        else if (challengeNumber == 22) { progressText[21].text = $"({progress}/{enterBucket2})"; }
        else if (challengeNumber == 23) { progressText[22 ].text = $"({progress}/{enterBucket3})"; }

        else if (challengeNumber == 24) { progressText[23].text = $"({progress}/{bounceCH})"; }
        else if (challengeNumber == 25) { progressText[24].text = $"({progress}/{explodeTinyCH})"; }
        else if (challengeNumber == 26) { progressText[25].text = $"({progress}/{basketballCH})"; }
        else if (challengeNumber == 27) { progressText[26].text = $"({progress}/{eggCH})"; }
        else if (challengeNumber == 28) { progressText[27].text = $"({progress}/{cookieCH})"; }
        else if (challengeNumber == 29) { progressText[28].text = $"({progress}/{goldenBallCH})"; }
        else if (challengeNumber == 30) { progressText[29].text = $"({progress}/{footballCH})"; }
        else if (challengeNumber == 31) { progressText[30].text = $"({progress}/{tinyRingCH})"; }
        else if (challengeNumber == 32) { progressText[31].text = $"({progress}/{prestigeGemCH})"; }
        else if (challengeNumber == 33) { progressText[32].text = $"({progress}/{ghostballCH})"; }
        else if (challengeNumber == 34) { progressText[33].text = $"({progress}/{starBallCH})"; }
        else if (challengeNumber == 35) { progressText[34].text = $"({progress}/{rainbowBallCH})"; }
        else if (challengeNumber == 36) { progressText[35].text = $"({progress}/{glitchyBallCH})"; }
        else if (challengeNumber == 37) { progressText[36].text = $"({progress}/{sharpnelBallCH})"; }
    }

    public void CheckCompleted(int challengeNumber, int progress)
    {
        if(challengeNumber == 1) { if (progress >= 15) { progressText[0].color = Color.green; challFinished[0] = true; FinishedChallenge(0);  }  }
        else if (challengeNumber == 2) { if (progress >= 15) { progressText[1].color = Color.green; challFinished[1] = true; FinishedChallenge(1);  } }
        else if (challengeNumber == 3) { if (progress >= 16) { progressText[2].color = Color.green; challFinished[2] = true; FinishedChallenge(2); } }
        else if (challengeNumber == 4) { if (progress >= 16) { progressText[3].color = Color.green; challFinished[3] = true; FinishedChallenge(3);  } }
        else if (challengeNumber == 5) { if (progress >= 17) { progressText[4].color = Color.green; challFinished[4] = true; FinishedChallenge(4);} }
        else if (challengeNumber == 6) { if (progress >= 17) { progressText[5].color = Color.green; challFinished[5] = true; FinishedChallenge(5);  } }
        else if (challengeNumber == 7) { if (progress >= 18) { progressText[6].color = Color.green; challFinished[6] = true; FinishedChallenge(6);  } }
        else if (challengeNumber == 8) { if (progress >= 18) { progressText[7].color = Color.green; challFinished[7] = true; FinishedChallenge(7);  } }
        else if (challengeNumber == 9) { if (progress >= 19) { progressText[8].color = Color.green; challFinished[8] = true; FinishedChallenge(8); } }
        else if (challengeNumber == 10) { if (progress >= 20) { progressText[9].color = Color.green; challFinished[9] = true; FinishedChallenge(9);  } }

        else if (challengeNumber == 11) { if (progress >= 1) { progressText[10].color = Color.green; challFinished[10] = true; FinishedChallenge(10);  } }
        else if (challengeNumber == 12) { if (progress >= 5) { progressText[11].color = Color.green; challFinished[11] = true; FinishedChallenge(11); } }
        else if (challengeNumber == 13) { if (progress >= 12) { progressText[12].color = Color.green; challFinished[12] = true; FinishedChallenge(12); } }
        else if (challengeNumber == 14) { if (progress >= 22) { progressText[13].color = Color.green; challFinished[13] = true; FinishedChallenge(13); } }

        else if (challengeNumber == 15) { if (progress >= reachBallLevel1) { progressText[14].color = Color.green; challFinished[14] = true; FinishedChallenge(14);  } }
        else if (challengeNumber == 16) { if (progress >= reachBallLevel2) { progressText[15].color = Color.green; challFinished[15] = true; FinishedChallenge(15); } }
        else if (challengeNumber == 17) { if (progress >= reachBallLevel3) { progressText[16].color = Color.green; challFinished[16] = true; FinishedChallenge(16);  } }

        else if (challengeNumber == 18) { if (progress >= hitGolden1) { progressText[17].color = Color.green; challFinished[17] = true; FinishedChallenge(17);  } }
        else if (challengeNumber == 19) { if (progress >= hitGolden2) { progressText[18].color = Color.green; challFinished[18] = true; FinishedChallenge(18); } }
        else if (challengeNumber == 20) { if (progress >= hitGolden3) { progressText[19].color = Color.green; challFinished[19] = true; FinishedChallenge(19);  } }

        else if (challengeNumber == 21) { if (progress >= enterBucket1) { progressText[20].color = Color.green; challFinished[20] = true; FinishedChallenge(20); } }
        else if (challengeNumber == 22) { if (progress >= enterBucket2) { progressText[21].color = Color.green; challFinished[21] = true; FinishedChallenge(21);  } }
        else if (challengeNumber == 23) { if (progress >= enterBucket3) { progressText[22].color = Color.green; challFinished[22] = true; FinishedChallenge(22); } }

        else if (challengeNumber == 24) { if (progress >= bounceCH) { progressText[23].color = Color.green; challFinished[23] = true; FinishedChallenge(23); } }
        else if (challengeNumber == 25) { if (progress >= explodeTinyCH) { progressText[24].color = Color.green; challFinished[24] = true; FinishedChallenge(24); } }
        else if (challengeNumber == 26) { if (progress >= basketballCH) { progressText[25].color = Color.green; challFinished[25] = true; FinishedChallenge(25); } }
        else if (challengeNumber == 27) { if (progress >= eggCH) { progressText[26].color = Color.green; challFinished[26] = true; FinishedChallenge(26);  } }
        else if (challengeNumber == 28) { if (progress >= cookieCH) { progressText[27].color = Color.green; challFinished[27] = true; FinishedChallenge(27); } }
        else if (challengeNumber == 29) { if (progress >= goldenBallCH) { progressText[28].color = Color.green; challFinished[28] = true; FinishedChallenge(28); } }
        else if (challengeNumber == 30) { if (progress >= footballCH) { progressText[29].color = Color.green; challFinished[29] = true; FinishedChallenge(29);  } }
        else if (challengeNumber == 31) { if (progress >= tinyRingCH) { progressText[30].color = Color.green; challFinished[30] = true; FinishedChallenge(30);  } }
        else if (challengeNumber == 32) { if (progress >= prestigeGemCH) { progressText[31].color = Color.green; challFinished[31] = true; FinishedChallenge(31); } }
        else if (challengeNumber == 33) { if (progress >= ghostballCH) { progressText[32].color = Color.green; challFinished[32] = true; FinishedChallenge(32); } }
        else if (challengeNumber == 34) { if (progress >= starBallCH) { progressText[33].color = Color.green; challFinished[33] = true; FinishedChallenge(33); } }
        else if (challengeNumber == 35) { if (progress >= rainbowBallCH) { progressText[34].color = Color.green; challFinished[34] = true; FinishedChallenge(34);  } }
        else if (challengeNumber == 36) { if (progress >= glitchyBallCH) { progressText[35].color = Color.green; challFinished[35] = true; FinishedChallenge(35);  } }
        else if (challengeNumber == 37) { if (progress >= sharpnelBallCH) { progressText[36].color = Color.green; challFinished[36] = true; FinishedChallenge(36);  } }
    }
    #endregion

    public Achievements achScript;
    public AudioManager audioManager;

    #region Claim button
    public void ClaimButton(int challNumber)
    {
        audioManager.Play("Claim");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        completedButtons[challNumber].SetActive(true);
        claimButtons[challNumber].SetActive(false);

        challCompleted[challNumber] = true;
        challengesCompleted += 1;
        challCompletedText.text = challengesCompleted + "/" + totalChallenges;
        GameObject secondChallengeFrame = challengesFrames[challNumber];
        int currentIndex = secondChallengeFrame.transform.GetSiblingIndex();
        secondChallengeFrame.transform.SetSiblingIndex(36);

        //Give reward
        GiveReward(challNumber);
        if(achScript != null) { achScript.CheckChallAch(); }
        if (challengesCompleted > 37) { challengesCompleted = 37; }
    }
    #endregion

    public static float challGoldScaling, challGoldScaling2, challGoldScaling3;
    public BallUpgrades ballScript;

    #region Give Reward
    public void GiveReward(int challNumber)
    {
        if (challNumber == 0) { Prestige.prestigeGoldIncrease += goldReward1; }
        else if (challNumber == 1) { Prestige.activeGoldIncrease += activeReward1; }
        else if (challNumber == 2) { Prestige.goldenPegChance += goldPegReward1; }
        else if (challNumber == 3) { Prestige.activeGoldIncrease += activeReward2; }
        else if (challNumber == 4) { Prestige.prestigeGoldIncrease += goldReward2; }
        else if (challNumber == 5) { Prestige.prestigeGoldIncrease += goldReward3; }
        else if (challNumber == 6) { Prestige.activeGoldIncrease += activeReward3; }
        else if (challNumber == 7) { Prestige.prestigeGoldIncrease += goldReward4; }
        else if (challNumber == 8) { Prestige.prestigeGoldIncrease += goldReward5; }
        else if (challNumber == 9) { Prestige.prestigeGoldIncrease += goldReward6; }

        else if (challNumber == 10) { Prestige.goldenPegChance += goldPegReward2; }
        else if (challNumber == 11) { Prestige.prestigeGoldIncrease += goldReward7; }
        else if (challNumber == 12) { Prestige.prestigePegChance += prestigePegReward; }
        else if (challNumber == 13) { Prestige.prestigeGoldIncrease += goldReward8; }
        else if (challNumber == 14) { GiveGoldSCaling(); }
        else if (challNumber == 15) { GiveGoldSCaling(); } 
        else if (challNumber == 16) { GiveGoldSCaling(); } 
        else if (challNumber == 17) { BallUpgrades.goldenPegIncreaseSCALE = 0.03f; ballScript.BucketGoldPegHoverText(); }
        else if (challNumber == 18) { BallUpgrades.goldenPegIncreaseSCALE = 0.04f; ballScript.BucketGoldPegHoverText(); } 
        else if (challNumber == 19) { BallUpgrades.goldenPegIncreaseSCALE = 0.05f; ballScript.BucketGoldPegHoverText(); } 
        else if (challNumber == 20) { BallUpgrades.bucketIncreaseSCALE = 0.03f; ballScript.BucketGoldPegHoverText(); } 
        else if (challNumber == 21) { BallUpgrades.bucketIncreaseSCALE = 0.04f; ballScript.BucketGoldPegHoverText(); } 
        else if (challNumber == 22) { BallUpgrades.bucketIncreaseSCALE = 0.05f; ballScript.BucketGoldPegHoverText(); } 
        else if (challNumber == 23) { Prestige.prestigeGoldIncrease += goldReward9; }
        else if (challNumber == 24) { BallUpgrades.tinyBallPercent = explodeTinyCHReward; BallUpgrades.tinyBallPercentTotal = 1 * explodeTinyCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 25) { BallUpgrades.basketBallBonus = basketballCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 26) { BallUpgrades.stickyBallDoubleGoldChance = eggCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 27) { BallUpgrades.cookieDoubleChance = cookieCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 28) { BallUpgrades.goldBallDoubleChance = goldBall2XReward; BallUpgrades.goldBallTrippleChance = goldball3XReward; BallUpgrades.goldBall5XGold = goldbal5XReward; locScript.SetBallDesText(); }
        else if (challNumber == 29) { BallUpgrades.footBallBucketIncrease = footballCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 30) { BallUpgrades.spawnedRingGold = tinyRingCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 31) { } //More gems spawn
        else if (challNumber == 32) { BallUpgrades.ghostBallGoldIncrease = ghostballCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 33) { BallUpgrades.starBallPegsHitNeeded = starBallCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 34) { BallUpgrades.rainbowBallGoldIncrease = rainbowBallCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 36) { BallUpgrades.smallSharpnelGold = sharpnelBallCHReward; locScript.SetBallDesText(); }
        else if (challNumber == 35) //Increases all ball buffs
        {
            BallUpgrades.tinyBallPercent = explodeTinyCHReward; BallUpgrades.tinyBallPercentTotal = 1 * (explodeTinyCHReward + 0.05f);
            BallUpgrades.basketBallBonus = basketballCHReward + 0.02f;
            BallUpgrades.stickyBallDoubleGoldChance = eggCHReward + 10;
            BallUpgrades.cookieDoubleChance = cookieCHReward + 15;
            BallUpgrades.goldBallDoubleChance = goldBall2XReward + 2; BallUpgrades.goldBallTrippleChance = goldball3XReward + 2; BallUpgrades.goldBall5XGold = goldbal5XReward + 1;
            BallUpgrades.footBallBucketIncrease = footballCHReward + 0.08f;
            BallUpgrades.spawnedRingGold = tinyRingCHReward + 0.1f;
            BallUpgrades.ghostBallGoldIncrease = ghostballCHReward + 0.03f;
            BallUpgrades.starBallPegsHitNeeded = starBallCHReward - 1;
            BallUpgrades.rainbowBallGoldIncrease = rainbowBallCHReward + 0.01f;
            BallUpgrades.smallSharpnelGold = sharpnelBallCHReward + 0.1f;
            locScript.SetBallDesText();
        }
    }
    #endregion

    public void GiveGoldSCaling()
    {
        if(challCompleted[14] == true) { challGoldScaling = 0.05f; challGoldScaling2 = 0.3f; challGoldScaling3 = 5f; }
        if (challCompleted[15] == true) { challGoldScaling = 0.1f; challGoldScaling2 = 0.5f; challGoldScaling3 = 8f; }
        if (challCompleted[16] == true) { challGoldScaling = 0.2f; challGoldScaling2 = 0.7f; challGoldScaling3 = 14f; }
    }

    public GameObject exIcon, exIcon2;

    #region Finishes Challenge
    public void FinishedChallenge(int challCompletedNumber)
    {
        //Debug.Log(challCompletedNumber);
        if(challCompleted[challCompletedNumber] == false)
        {
            if (!settingsFrame.activeInHierarchy) { exIcon2.SetActive(true); exIcon2.GetComponent<Animation>().Play(); }
            if (!challengeFrame.activeInHierarchy) { exIcon.SetActive(true); }

            claimButtons[challCompletedNumber].SetActive(true);
            incompletedButtons[challCompletedNumber].SetActive(false);

            GameObject secondChallengeFrame = challengesFrames[challCompletedNumber];
            int currentIndex = secondChallengeFrame.transform.GetSiblingIndex();
            secondChallengeFrame.transform.SetSiblingIndex(0);

            CheckCompletedChall();
        }
    }
    #endregion

    #region Set need to reach challenge variables
    public int reachBallLevel1, reachBallLevel2, reachBallLevel3, hitGolden1, hitGolden2, hitGolden3, enterBucket1, enterBucket2, enterBucket3;
    public static int bounceCH, explodeTinyCH, basketballCH, eggCH, cookieCH, goldenBallCH, footballCH, tinyRingCH, prestigeGemCH, ghostballCH, starBallCH, rainbowBallCH, glitchyBallCH, sharpnelBallCH;

    public void SetReachVariables()
    {
        reachBallLevel1 = 90;
        reachBallLevel2 = 210;
        reachBallLevel3 = 420;

        hitGolden1 = 70000;
        hitGolden2 = 500000;
        hitGolden3 = 1500000;

        enterBucket1 = 85000;
        enterBucket2 = 900000;
        enterBucket3 = 2500000;

        bounceCH = 20;
        explodeTinyCH = 15000;
        basketballCH = 3500;
        eggCH = 200;
        cookieCH = 350;
        goldenBallCH = 250;
        footballCH = 5000;
        tinyRingCH = 10000;
        prestigeGemCH = 500;
        ghostballCH = 25;
        starBallCH = 500;
        rainbowBallCH = 150;
        glitchyBallCH = 25000;
        sharpnelBallCH = 2500;
    }
    #endregion

    #region Set challenge reward variables
    public TextMeshProUGUI[] challengeRewardText;

    public static int eggCHReward, cookieCHReward, starBallCHReward;
    public static float footballCHReward, basketballCHReward, explodeTinyCHReward, tinyRingCHReward, ghostballCHReward, rainbowBallCHReward, sharpnelBallCHReward;
    public float goldReward1, goldReward2, goldReward3, goldReward4, goldReward5, goldReward6, goldReward7, goldReward8, goldReward9;
    public float activeReward1, activeReward2, activeReward3;
    public static float goldPegReward1, goldPegReward2, prestigePegReward;
    public static int goldBall2XReward, goldball3XReward, goldbal5XReward;

    public void SetRewardVariables()
    {
        goldBall2XReward = 7;
        goldball3XReward = 4;
        goldbal5XReward = 2;

        explodeTinyCHReward = 0.4f;
        basketballCHReward = 0.04f;
        eggCHReward = 45;
        cookieCHReward = 75;
        footballCHReward = 1.22f;
        tinyRingCHReward = 0.25f;
        ghostballCHReward = 0.07f;
        starBallCHReward = 7;
        rainbowBallCHReward = 0.03f;
        sharpnelBallCHReward = 0.45f;

        goldReward1 = 0.01f;
        goldReward2 = 0.65f;
        goldReward3 = 1.25f;
        goldReward4 = 20f;
        goldReward5 = 40f;
        goldReward6 = 70f;
        goldReward7 = 0.9f;
        goldReward8 = 100f;
        goldReward9 = 0.02f;

        activeReward1 = 0.03f;
        activeReward2 = 0.50f;
        activeReward3 = 2.5f;

        goldPegReward1 = 0.5f;
        goldPegReward2 = 0.5f;

        prestigePegReward = 0.2f;
    }
    #endregion

    #region Set Reward Text
    public void SetRewardText()
    {
        //Gold increase reward
        locScript.ChangeGoldReward(goldReward1);
        challengeRewardText[0].text = LocalizationStrings.goldRewardString;
        locScript.ChangeGoldReward(goldReward2);
        challengeRewardText[4].text = LocalizationStrings.goldRewardString;
        locScript.ChangeGoldReward(goldReward3);
        challengeRewardText[5].text = LocalizationStrings.goldRewardString;
        locScript.ChangeGoldReward(goldReward4);
        challengeRewardText[7].text = LocalizationStrings.goldRewardString;
        locScript.ChangeGoldReward(goldReward5);
        challengeRewardText[8].text = LocalizationStrings.goldRewardString;
        locScript.ChangeGoldReward(goldReward6);
        challengeRewardText[9].text = LocalizationStrings.goldRewardString;
        locScript.ChangeGoldReward(goldReward7);
        challengeRewardText[11].text = LocalizationStrings.goldRewardString;
        locScript.ChangeGoldReward(goldReward8);
        challengeRewardText[13].text = LocalizationStrings.goldRewardString;
        locScript.ChangeGoldReward(goldReward9);
        challengeRewardText[23].text = LocalizationStrings.goldRewardString;

        //Gold peg chance
        locScript.ChangeGoldPegChanceReward(goldPegReward1);
        challengeRewardText[2].text = LocalizationStrings.goldPegRewardString;
        locScript.ChangeGoldPegChanceReward(goldPegReward2);
        challengeRewardText[10].text = LocalizationStrings.goldPegRewardString;

        challengeRewardText[12].text = LocalizationStrings.prestigePegReward;

        challengeRewardText[14].text = LocalizationStrings.goldScaling;
        challengeRewardText[15].text = LocalizationStrings.goldScaling;
        challengeRewardText[16].text = LocalizationStrings.goldScaling;

        locScript.ChangeBucketAndGoldPegIncrease(false, 0.03f);
        challengeRewardText[17].text = LocalizationStrings.bucketAndGoldIncreaseString;
        locScript.ChangeBucketAndGoldPegIncrease(false, 0.04f);
        challengeRewardText[18].text = LocalizationStrings.bucketAndGoldIncreaseString;
        locScript.ChangeBucketAndGoldPegIncrease(false, 0.05f);
        challengeRewardText[19].text = LocalizationStrings.bucketAndGoldIncreaseString;
        locScript.ChangeBucketAndGoldPegIncrease(true, 0.03f);
        challengeRewardText[20].text = LocalizationStrings.bucketAndGoldIncreaseString;
        locScript.ChangeBucketAndGoldPegIncrease(true, 0.04f);
        challengeRewardText[21].text = LocalizationStrings.bucketAndGoldIncreaseString;
        locScript.ChangeBucketAndGoldPegIncrease(true, 0.05f);
        challengeRewardText[22].text = LocalizationStrings.bucketAndGoldIncreaseString;

        //Active rewards
        locScript.ChangeGoldActiveReward(activeReward1);
        challengeRewardText[1].text = LocalizationStrings.goldActiveRewardString;
        locScript.ChangeGoldActiveReward(activeReward2);
        challengeRewardText[3].text = LocalizationStrings.goldActiveRewardString;
        locScript.ChangeGoldActiveReward(activeReward3);
        challengeRewardText[6].text = LocalizationStrings.goldActiveRewardString;

        challengeRewardText[24].text = LocalizationStrings.explodeTinyCHRewardstring;
        challengeRewardText[25].text = LocalizationStrings.basketballCHRewardstring;
        challengeRewardText[26].text = LocalizationStrings.eggCHRewardstring;
        challengeRewardText[27].text = LocalizationStrings.cookieCHRewardstring;
        challengeRewardText[28].text = LocalizationStrings.goldenBallCHRewardstring;
        challengeRewardText[29].text = LocalizationStrings.footballCHRewardstring;
        challengeRewardText[30].text = LocalizationStrings.tinyRingCHRewardstring;
        challengeRewardText[31].text = LocalizationStrings.prestigeGemCHRewardstring;
        challengeRewardText[32].text = LocalizationStrings.ghostballCHRewardstring;
        challengeRewardText[33].text = LocalizationStrings.starBallCHRewardstring;
        challengeRewardText[34].text = LocalizationStrings.rainbowBallCHRewardstring;
        challengeRewardText[35].text = LocalizationStrings.glitchyBallCHRewardstring;
        challengeRewardText[36].text = LocalizationStrings.sharpnelBallCSRewardstring;
    }
    #endregion

    #region Set challenge reward text
    public TextMeshProUGUI[] challengeText;
    public LocalizationStrings locScript;
    public void SetChallengeRewardText()
    {
        for (int i = 0; i < 10; i++)
        {
            locScript.ChangeBoardClearText(i + 1);
            challengeText[i].text = LocalizationStrings.boardClearCHstring;
        }

        locScript.ChangeReachMaxAutoDrop(1, "");
        challengeText[10].text = LocalizationStrings.reachAutoCHstring;
        locScript.ChangeReachMaxAutoDrop(5, "s");
        challengeText[11].text = LocalizationStrings.reachAutoCHstring;
        locScript.ChangeReachMaxAutoDrop(12, "s");
        challengeText[12].text = LocalizationStrings.reachAutoCHstring;
        locScript.ChangeReachMaxAutoDrop(22, "s");
        challengeText[13].text = LocalizationStrings.reachAutoCHstring;

        locScript.ChangeUpgradeBallTo(reachBallLevel1);
        challengeText[14].text = LocalizationStrings.upgradeBallToCH;
        locScript.ChangeUpgradeBallTo(reachBallLevel2);
        challengeText[15].text = LocalizationStrings.upgradeBallToCH;
        locScript.ChangeUpgradeBallTo(reachBallLevel3);
        challengeText[16].text = LocalizationStrings.upgradeBallToCH;

        locScript.ChangeHitGoldenPegs(hitGolden1);
        challengeText[17].text = LocalizationStrings.hitGoldenPegsCH;
        locScript.ChangeHitGoldenPegs(hitGolden2);
        challengeText[18].text = LocalizationStrings.hitGoldenPegsCH;
        locScript.ChangeHitGoldenPegs(hitGolden3);
        challengeText[19].text = LocalizationStrings.hitGoldenPegsCH;

        locScript.ChangeHitBuckets(enterBucket1);
        challengeText[20].text = LocalizationStrings.hitBucketsCH;
        locScript.ChangeHitBuckets(enterBucket2);
        challengeText[21].text = LocalizationStrings.hitBucketsCH;
        locScript.ChangeHitBuckets(enterBucket3);
        challengeText[22].text = LocalizationStrings.hitBucketsCH;

        challengeText[23].text = LocalizationStrings.bounceCHstring;
        challengeText[24].text = LocalizationStrings.explodeTinyCHstring;
        challengeText[25].text = LocalizationStrings.basketballCHstring;
        challengeText[26].text = LocalizationStrings.eggCHstring;
        challengeText[27].text = LocalizationStrings.cookieCHstring;
        challengeText[28].text = LocalizationStrings.goldenBallCHstring;
        challengeText[29].text = LocalizationStrings.footballCHstring;
        challengeText[30].text = LocalizationStrings.tinyRingCHstring;
        challengeText[31].text = LocalizationStrings.prestigeGemCHstring;
        challengeText[32].text = LocalizationStrings.ghostballCHstring;
        challengeText[33].text = LocalizationStrings.starBallCHstring;
        challengeText[34].text = LocalizationStrings.rainbowBallCHstring;
        challengeText[35].text = LocalizationStrings.glitchyBallCHstring;
        challengeText[36].text = LocalizationStrings.sharpnelBallCSstring;
    }
    #endregion

    #region Saving and loading
    public static int ballsReachedMaxAuto;
    public static int ballUpgradeLevel;
    public static int redBallBounceCount, tinyBallsCount, basketBallPegHitCount, eggDoubleGoldCount, cookieBallExtraCount, goldenBallExtraCount, footballBucketCount, tinyRingBallsCount, prestigeGemsHit, starBallsSpawned,  tinyGlitchyBallsSpawned, tinySharpnelCount;

    public void LoadData(GameData data)
    {
        challengesCompleted = data.challengesCompleted;
        ballsReachedMaxAuto = data.ballsReachedMaxAuto;
        ballUpgradeLevel = data.ballUpgradeLevel;
        redBallBounceCount = data.redBallBounceCount;
        tinyBallsCount = data.tinyBallsCount;
        basketBallPegHitCount = data.basketBallPegHitCount;
        eggDoubleGoldCount = data.eggDoubleGoldCount;
        cookieBallExtraCount = data.cookieBallExtraCount;
        goldenBallExtraCount = data.goldenBallExtraCount;
        footballBucketCount = data.footballBucketCount;
        tinyRingBallsCount = data.tinyRingBallsCount;
        prestigeGemsHit = data.prestigeGemsHit;
        starBallsSpawned = data.starBallsSpawned;
        tinyGlitchyBallsSpawned = data.tinyGlitchyBallsSpawned;
        tinySharpnelCount = data.tinySharpnelCount;

        for (int i = 0; i < challCompleted.Length; i++)
        {
            challCompleted[i] = data.challCompleted[i];
        }
    }

    public void SaveData(ref GameData data)
    {
        data.challengesCompleted = challengesCompleted;
        data.ballsReachedMaxAuto = ballsReachedMaxAuto;
        data.ballUpgradeLevel = ballUpgradeLevel;
        data.redBallBounceCount = redBallBounceCount;
        data.tinyBallsCount = tinyBallsCount;
        data.basketBallPegHitCount = basketBallPegHitCount;
        data.eggDoubleGoldCount = eggDoubleGoldCount;
        data.cookieBallExtraCount = cookieBallExtraCount;
        data.goldenBallExtraCount = goldenBallExtraCount;
        data.footballBucketCount = footballBucketCount;
        data.tinyRingBallsCount = tinyRingBallsCount;
        data.prestigeGemsHit = prestigeGemsHit;
        data.starBallsSpawned = starBallsSpawned;
        data.tinyGlitchyBallsSpawned = tinyGlitchyBallsSpawned;
        data.tinySharpnelCount = tinySharpnelCount;

        for (int i = 0; i < challCompleted.Length; i++)
        {
            data.challCompleted[i] = challCompleted[i];
        }
    }
    #endregion

    #region RESET
    public void ResetCH()
    {
        Levels.board1Clears = 0;
        Levels.board2Clears = 0;
        Levels.board3Clears = 0;
        Levels.board4Clears = 0;
        Levels.board5Clears = 0;
        Levels.board6Clears = 0;
        Levels.board7Clears = 0;
        Levels.board8Clears = 0;
        Levels.board9Clears = 0;
        Levels.board10Clears = 0;

        challengesCompleted = 0;
        challCompletedText.text = challengesCompleted + "/" + totalChallenges;

        ballUpgradeLevel = 0;
        ballsReachedMaxAuto = 0;

        redBallBounceCount = 0;
        tinyBallsCount = 0;
        basketBallPegHitCount = 0;
        eggDoubleGoldCount = 0;
        cookieBallExtraCount = 0;
        goldenBallExtraCount = 0;
        footballBucketCount = 0;
        tinyRingBallsCount = 0;
        prestigeGemsHit = 0;
        starBallsSpawned = 0;
        tinyGlitchyBallsSpawned = 0;
        tinySharpnelCount = 0;

        for (int i = 0; i < totalChallenges; i++)
        {
            ChallengeProgress(i + 1, 0);
            progressText[i].color = Color.red;

            incompletedButtons[i].SetActive(true);
            completedButtons[i].SetActive(false);
            claimButtons[i].SetActive(false);

            GameObject challengeFrame = challengesFrames[i];
            int currentIndex = challengeFrame.transform.GetSiblingIndex();
            challengeFrame.transform.SetSiblingIndex(36);
        }

        GameObject challengeFrame2 = challengesFrames[36];
        int currentIndex2 = challengeFrame2.transform.GetSiblingIndex();
        challengeFrame2.transform.SetSiblingIndex(30);
    }
    #endregion

}
