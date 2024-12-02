using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVariables : MonoBehaviour
{
    public Prestige prestigeScript;
    public GameObject ball1Screen, ball2Screen, ball3Screen, prestigeScreen;
    public MainShooter mainShooter;
    public Challenges csScript;
    public Levels levelScript;
    public BallUpgrades ballScript;
    public Achievements achScript;
    public TabsAndFrames tabsScript;
    public PointsMechanics pointScript;

    public void ResetGame(bool completeReset)
    {
        if(completeReset == true)
        {
            AllStats.timesFullyCharge = 0;
            AllStats.timesGoldRush = 0;
            AllStats.timesPrestigeRush = 0;
            AllStats.goldFromClear = 0;
            AllStats.goldFromShooting = 0;
            AllStats.prestigePointFromClear = 0;
            AllStats.prestigePointsFromBucket = 0;

            if(GameData.isDemo == false) { achScript.ResetACH(); }

            BallUpgrades.bucketIncreaseSCALE = 0.02f;
            BallUpgrades.goldenPegIncreaseSCALE = 0.02f;

            prestigeScript.CheckLevelSetInactive();
            Prestige.levelSelected = 1;

            mainShooter.ResetMoreShots();

            ball1Screen.SetActive(true);
            if(GameData.isDemo == false)
            {
                ball2Screen.SetActive(false);
                ball3Screen.SetActive(false);
            }
            prestigeScreen.SetActive(false);
            prestigeScript.ResetPrestige();

            Prestige.reachedOver500 = false;
            Prestige.prestigePoints = 0;
            Prestige.reachedOver500 = false;

            Prestige.prestigeGoldIncrease = 0;
            Prestige.activeGoldIncrease = 0;
            Prestige.prestigePointsIncrease = 1;
            Prestige.redPegChance = 0;
            Prestige.goldenPegChance = 9;
            Prestige.rainbowPegChance = 0;
            Prestige.bombPegChance = 0;
            Prestige.purplePegChance = 0;
            Prestige.prestigePegChance = 1;
            Prestige.redPegChance = 0;
            Prestige.isRedPegUnlocked = false;
            Prestige.totalGoldClearBonus = 0;
            Prestige.totalTimerGoldClearBonus = 0;
            Prestige.prestigeClearHitsNeeded = 0;
            Prestige.prestigeBucketChance = 0;
            Prestige.purplePegIncrease = 0;
            Prestige.startWithGold = 0;
            Prestige.extraPrestigePoints = 0;
            Prestige.goldFromShooting = 0;
            Prestige.totalBallShots = 1;

            AllStats.totalGold = 0;
            AllStats.totalGoldSpent = 0;
            AllStats.totalBallsShot = 0;
            AllStats.totalBallsDropped = 0;
            AllStats.totalPegsHit = 0;
            AllStats.totalBoardsCleared = 0;

            AllStats.greenPegChance = 100 - (Prestige.goldenPegChance + Prestige.prestigePegChance + Prestige.redPegChance);
            AllStats.greenPegsHit = 0;
            AllStats.goldenPegsHit = 0;
            AllStats.prestigePegsHit = 0;
            AllStats.redPegsHit = 0;
            AllStats.bombPegsHit = 0;
            AllStats.purplePegHit = 0;
            AllStats.rainbowPegsHit = 0;
            AllStats.totalPegGold = 0;

            AllStats.totalBallsPit = 0;
            AllStats.totalPitGold = 0;

            AllStats.totalPegsUnlocked = 3;
            AllStats.levelsUnlocked = 1;
            AllStats.prestigeUpgradesPurchased = 0;

            AllStats.totalPRestigePoints = 0;
            AllStats.totalPrestigePointSpent = 0;

            BallUpgrades.isBall1AutoTurnedOff = false;
            BallUpgrades.isBall2AutoTurnedOff = false;
            BallUpgrades.isBall3AutoTurnedOff = false;
            BallUpgrades.isBall4AutoTurnedOff = false;
            BallUpgrades.isBall5AutoTurnedOff = false;
            BallUpgrades.isBall6AutoTurnedOff = false;
            BallUpgrades.isBall7AutoTurnedOff = false;
            BallUpgrades.isBall8AutoTurnedOff = false;
            BallUpgrades.isBall9AutoTurnedOff = false;
            BallUpgrades.isBall10AutoTurnedOff = false;
            BallUpgrades.isBall11AutoTurnedOff = false;
            BallUpgrades.isBall12AutoTurnedOff = false;
            BallUpgrades.isBall13AutoTurnedOff = false;
            BallUpgrades.isBall14AutoTurnedOff = false;
            BallUpgrades.isBall15AutoTurnedOff = false;
            BallUpgrades.isBall16AutoTurnedOff = false;
            BallUpgrades.isBall17AutoTurnedOff = false;
            BallUpgrades.isBall18AutoTurnedOff = false;
            BallUpgrades.isBall19AutoTurnedOff = false;
            BallUpgrades.isBall20AutoTurnedOff = false;
            BallUpgrades.isBall21AutoTurnedOff = false;
            BallUpgrades.isBall22AutoTurnedOff = false;

            ballScript.ResetColor();

            if (GameData.isDemo == false)
            {
                for (int i = 0; i < Challenges.totalChallenges; i++)
                {
                    Challenges.challCompleted[i] = false;
                    Challenges.challFinished[i] = false;
                }  
            }

            if(GameData.isDemo == false) { levelScript.ResetLevelVariables(); }
            if (GameData.isDemo == false) { csScript.ResetCH(); }
            ballScript.OriginalBallBuffs();
            tabsScript.SetFRameBTNS();
            if(GameData.isDemo == false)
            {
                Levels.isPRestigeRush = false;
                Levels.isGoldRush = false;
                Levels.isRainbowGoldBucket = false;
                Levels.isRainbowGoldPeg = false;
                Levels.isRainbowPRestige = false;
                Levels.isRainbowPRestigeBucket = false;
            }
        }
        else
        {
            BallUpgrades.ballsPurchased = 0;
            BallUpgrades.offlineProgressTextChance = 0;
            BallUpgrades.autoPurchased = 0;
            BallUpgrades.maxAutoCount = 0;
            BallUpgrades.textSpawnChance = 0;

            if (GameData.isDemo == false)
            {
                Challenges.ballUpgradeLevel = 0;
                Challenges.ballsReachedMaxAuto = 0;

                MainShooter.aquaBallsAvailable = 1;
                MainShooter.mudBallsAvailable = 1;
                MainShooter.basketBallsAvailable = 1;
                MainShooter.plumBallsAvailable = 1;
                MainShooter.stickyBallsAvailable = 1;
                MainShooter.candyBallsAvailable = 1;
                MainShooter.cookieBallsAvailable = 1;
                MainShooter.limeBallsAvailable = 1;
                MainShooter.goldenBallsAvailable = 1;
                MainShooter.footballBallsAvailable = 1;
                MainShooter.sharpnelBallsAvailable = 1;
                MainShooter.zonicBallsAvailable = 1;
                MainShooter.apricotBallsAvailable = 1;
                MainShooter.peggoBallsAvailable = 1;
                MainShooter.ghostBallsAvailable = 1;
                MainShooter.starBallsAvailable = 1;
                MainShooter.rainbowBallsAvailable = 1;
                MainShooter.glitchyBallsAvailable = 1;

                BallUpgrades.totalAquaBalls = 1;
                BallUpgrades.totalMudBalls = 1;
                BallUpgrades.totalBasketBalls = 1;
                BallUpgrades.totalPlumBalls = 1;
                BallUpgrades.totalStickyBalls = 1;
                BallUpgrades.totalStickyBalls = 1;
                BallUpgrades.totalCandyBalls = 1;
                BallUpgrades.totalCookieBalls = 1;
                BallUpgrades.totalLimeBalls = 1;
                BallUpgrades.totalGoldenBalls = 1;
                BallUpgrades.totalFootballBalls = 1;
                BallUpgrades.totalSharpnelBalls = 1;
                BallUpgrades.totalZonicBalls = 1;
                BallUpgrades.totalApricotBalls = 1;
                BallUpgrades.totalPeggoBalls = 1;
                BallUpgrades.totalGhostBalls = 1;
                BallUpgrades.totalStarBalls = 1;
                BallUpgrades.totalRainbowBalls = 1;
                BallUpgrades.totalGlitchyBalls = 1;

                BallUpgrades.aquaBallLevel = 1;
                BallUpgrades.mudBallLevel = 1;
                BallUpgrades.basketBallLevel = 1;
                BallUpgrades.plumBallLevel = 1;
                BallUpgrades.stickyBallLevel = 1;
                BallUpgrades.candyBallLevel = 1;
                BallUpgrades.cookieBallLevel = 1;
                BallUpgrades.limeBallLevel = 1;
                BallUpgrades.goldenBallLevel = 1;
                BallUpgrades.footballBallLevel = 1;
                BallUpgrades.sharpnelBallLevel = 1;
                BallUpgrades.zonicBallLevel = 1;
                BallUpgrades.apricotBallLevel = 1;
                BallUpgrades.peggoBallLevel = 1;
                BallUpgrades.ghostBallLevel = 1;
                BallUpgrades.starBallLevel = 1;
                BallUpgrades.rainbowBallLevel = 1;
                BallUpgrades.glitchyBallLevel = 1;

                BallUpgrades.isAquaBallAutoPurchased = false;
                BallUpgrades.isMudBallAutoPurchased = false;
                BallUpgrades.isBasketBallAutoPurchased = false;
                BallUpgrades.isPlumBallAutoPurchased = false;
                BallUpgrades.isStickyBallAutoPurchased = false;
                BallUpgrades.isCandyBallAutoPurchased = false;
                BallUpgrades.isCookieBallAutoPurchased = false;
                BallUpgrades.isLimeBallAutoPurchased = false;
                BallUpgrades.isGoldenBallAutoPurchased = false;
                BallUpgrades.isFootballBallAutoPurchased = false;
                BallUpgrades.isSharpnelBallAutoPurchased = false;
                BallUpgrades.isZonicBallAutoPurchased = false;
                BallUpgrades.isApricotBallAutoPurchased = false;
                BallUpgrades.isPeggoBallAutoPurchased = false;
                BallUpgrades.isGhostBallAutoPurchased = false;
                BallUpgrades.isStarBallAutoPurchased = false;
                BallUpgrades.isRainbowBallAutoPurchased = false;
                BallUpgrades.isGlitchyBallAutoPurchased = false;

                BallUpgrades.aquaBallPurchased = false;
                BallUpgrades.mudBallPurchased = false;
                BallUpgrades.basketBallPurchased = false;
                BallUpgrades.plumBallPurchased = false;
                BallUpgrades.stickyBallPurchased = false;
                BallUpgrades.candyBallPurchased = false;
                BallUpgrades.cookieBallPurchased = false;
                BallUpgrades.limeBallPurchased = false;
                BallUpgrades.goldenBallPurchased = false;
                BallUpgrades.footballBallPurchased = false;
                BallUpgrades.sharpnelBallPurchased = false;
                BallUpgrades.zonicBallPurchased = false;
                BallUpgrades.apricotBallPurchased = false;
                BallUpgrades.peggoBallPurchased = false;
                BallUpgrades.ghostBallPurchased = false;
                BallUpgrades.starBallPurchased = false;
                BallUpgrades.rainbowBallPurchased = false;
                BallUpgrades.glitchyBallPurchased = false;

                BallUpgrades.aquaBallGold = GameData.ORIGINALaquaBallGold;
                BallUpgrades.mudBallGold = GameData.ORIGINALmudBallGold;
                BallUpgrades.basketBallGold = GameData.ORIGINALbasketBallGold;
                BallUpgrades.plumBallGold = GameData.ORIGINALplumBallGold;
                BallUpgrades.stickyBallGold = GameData.ORIGINALstickyBallGold;
                BallUpgrades.candyBallGold = GameData.ORIGINALcandyBallGold;
                BallUpgrades.cookieBallGold = GameData.ORIGINALcookieBallGold;
                BallUpgrades.limeBallGold = GameData.ORIGINALlimeBallGold;
                BallUpgrades.goldenBallGold = GameData.ORIGINALgoldenBallGold;
                BallUpgrades.footballBallGold = GameData.ORIGINALfootballBallGold;
                BallUpgrades.sharpnelBallGold = GameData.ORIGINALsharpnelBallGold;
                BallUpgrades.zonicBallGold = GameData.ORIGINALzonicBallGold;
                BallUpgrades.apricotBallGold = GameData.ORIGINALapricotBallGold;
                BallUpgrades.peggoBallGold = GameData.ORIGINALpeggoBallGold;
                BallUpgrades.ghostBallGold = GameData.ORIGINALghostBallGold;
                BallUpgrades.starBallGold = GameData.ORIGINALstarBallGold;
                BallUpgrades.rainbowBallGold = GameData.ORIGINALrainbowBallGold;
                BallUpgrades.glitchyBallGold = GameData.ORIGINALglitchyBallGold;

                BallUpgrades.aquaBallUpgradePrice = GameData.ORIGINALaquaBallUpgradePrice;
                BallUpgrades.mudBallUpgradePrice = GameData.ORIGINALmudBallUpgradePrice;
                BallUpgrades.basketBallUpgradePrice = GameData.ORIGINALbasketBallUpgradePrice;
                BallUpgrades.plumBallUpgradePrice = GameData.ORIGINALplumBallUpgradePrice;
                BallUpgrades.stickyBallUpgradePrice = GameData.ORIGINALstickyBallUpgradePrice;
                BallUpgrades.candyBallUpgradePrice = GameData.ORIGINALcandyBallUpgradePrice;
                BallUpgrades.cookieBallUpgradePrice = GameData.ORIGINALcookieBallUpgradePrice;
                BallUpgrades.limeBallUpgradePrice = GameData.ORIGINALlimeBallUpgradePrice;
                BallUpgrades.goldenBallUpgradePrice = GameData.ORIGINALgoldenBallUpgradePrice;
                BallUpgrades.footballBallUpgradePrice = GameData.ORIGINALfootballBallUpgradePrice;
                BallUpgrades.sharpnelBallUpgradePrice = GameData.ORIGINALsharpnelBallUpgradePrice;
                BallUpgrades.zonicBallUpgradePrice = GameData.ORIGINALzonicBallUpgradePrice;
                BallUpgrades.apricotBallUpgradePrice = GameData.ORIGINALapricotBallUpgradePrice;
                BallUpgrades.peggoBallUpgradePrice = GameData.ORIGINALpeggoBallUpgradePrice;
                BallUpgrades.ghostBallUpgradePrice = GameData.ORIGINALghostBallUpgradePrice;
                BallUpgrades.starBallUpgradePrice = GameData.ORIGINALstarBallUpgradePrice;
                BallUpgrades.rainbowBallUpgradePrice = GameData.ORIGINALrainbowBallUpgradePrice;
                BallUpgrades.glitchyBallUpgradePrice = GameData.ORIGINALglitchyBallUpgradePrice;

                BallUpgrades.aquaBallAutoPrice = GameData.ORIGINALaquaBallAutoPrice;
                BallUpgrades.mudBallAutoPrice = GameData.ORIGINALmudBallAutoPrice;
                BallUpgrades.basketBallAutoPrice = GameData.ORIGINALbasketBallAutoPrice;
                BallUpgrades.plumBallAutoPrice = GameData.ORIGINALplumBallAutoPrice;
                BallUpgrades.stickyBallAutoPrice = GameData.ORIGINALstickyBallAutoPrice;
                BallUpgrades.candyBallAutoPrice = GameData.ORIGINALcandyBallAutoPrice;
                BallUpgrades.cookieBallAutoPrice = GameData.ORIGINALcookieBallAutoPrice;
                BallUpgrades.limeBallAutoPrice = GameData.ORIGINALlimeBallAutoPrice;
                BallUpgrades.goldenBallAutoPrice = GameData.ORIGINALgoldenBallAutoPrice;
                BallUpgrades.footballBallAutoPrice = GameData.ORIGINALfootballBallAutoPrice;
                BallUpgrades.sharpnelBallAutoPrice = GameData.ORIGINALsharpnelBallAutoPrice;
                BallUpgrades.zonicBallAutoPrice = GameData.ORIGINALzonicBallAutoPrice;
                BallUpgrades.apricotBallAutoPrice = GameData.ORIGINALapricotBallAutoPrice;
                BallUpgrades.peggoBallAutoPrice = GameData.ORIGINALpeggoBallAutoPrice;
                BallUpgrades.ghostBallAutoPrice = GameData.ORIGINALghostBallAutoPrice;
                BallUpgrades.starBallAutoPrice = GameData.ORIGINALstarBallAutoPrice;
                BallUpgrades.rainbowBallAutoPrice = GameData.ORIGINALrainbowBallAutoPrice;
                BallUpgrades.glitchyBallAutoPrice = GameData.ORIGINALglitchyBallAutoPrice;

                BallUpgrades.aquaBallPluss1Price = GameData.ORIGINALaquaBallPluss1Price;
                BallUpgrades.mudBallPluss1Price = GameData.ORIGINALmudBallPluss1Price;
                BallUpgrades.basketBallPluss1Price = GameData.ORIGINALbasketBallPluss1Price;
                BallUpgrades.plumBallPluss1Price = GameData.ORIGINALplumBallPluss1Price;
                BallUpgrades.stickyBallPluss1Price = GameData.ORIGINALstickyBallPluss1Price;
                BallUpgrades.candyBallPluss1Price = GameData.ORIGINALcandyBallPluss1Price;
                BallUpgrades.cookieBallPluss1Price = GameData.ORIGINALcookieBallPluss1Price;
                BallUpgrades.limeBallPluss1Price = GameData.ORIGINALlimeBallPluss1Price;
                BallUpgrades.goldenBallPluss1Price = GameData.ORIGINALgoldenBallPluss1Price;
                BallUpgrades.footballBallPluss1Price = GameData.ORIGINALfootballBallPluss1Price;
                BallUpgrades.sharpnelBallPluss1Price = GameData.ORIGINALsharpnelBallPluss1Price;
                BallUpgrades.zonicBallPluss1Price = GameData.ORIGINALzonicBallPluss1Price;
                BallUpgrades.apricotBallPluss1Price = GameData.ORIGINALapricotBallPluss1Price;
                BallUpgrades.peggoBallPluss1Price = GameData.ORIGINALpeggoBallPluss1Price;
                BallUpgrades.ghostBallPluss1Price = GameData.ORIGINALghostBallPluss1Price;
                BallUpgrades.starBallPluss1Price = GameData.ORIGINALstarBallPluss1Price;
                BallUpgrades.rainbowBallPluss1Price = GameData.ORIGINALrainbowBallPluss1Price;
                BallUpgrades.glitchyBallPluss1Price = GameData.ORIGINALglitchyBallPluss1Price;

                BallUpgrades.aquaBallAutoDropTime = GameData.ORIGINALaquaBallAutoDropTime;
                BallUpgrades.mudBallAutoDropTime = GameData.ORIGINALmudBallAutoDropTime;
                BallUpgrades.basketBallAutoDropTime = GameData.ORIGINALbasketBallAutoDropTime;
                BallUpgrades.plumBallAutoDropTime = GameData.ORIGINALplumBallAutoDropTime;
                BallUpgrades.stickyBallAutoDropTime = GameData.ORIGINALstickyBallAutoDropTime;
                BallUpgrades.candyBallAutoDropTime = GameData.ORIGINALcandyBallAutoDropTime;
                BallUpgrades.cookieBallAutoDropTime = GameData.ORIGINALcookieBallAutoDropTime;
                BallUpgrades.limeBallAutoDropTime = GameData.ORIGINALlimeBallAutoDropTime;
                BallUpgrades.goldenBallAutoDropTime = GameData.ORIGINALgoldenBallAutoDropTime;
                BallUpgrades.footballBallAutoDropTime = GameData.ORIGINALfootballBallAutoDropTime;
                BallUpgrades.sharpnelBallAutoDropTime = GameData.ORIGINALsharpnelBallAutoDropTime;
                BallUpgrades.zonicBallAutoDropTime = GameData.ORIGINALzonicBallAutoDropTime;
                BallUpgrades.apricotBallAutoDropTime = GameData.ORIGINALapricotBallAutoDropTime;
                BallUpgrades.peggoBallAutoDropTime = GameData.ORIGINALpeggoBallAutoDropTime;
                BallUpgrades.ghostBallAutoDropTime = GameData.ORIGINALghostBallAutoDropTime;
                BallUpgrades.starBallAutoDropTime = GameData.ORIGINALstarBallAutoDropTime;
                BallUpgrades.rainbowBallAutoDropTime = GameData.ORIGINALrainbowBallAutoDropTime;
                BallUpgrades.glitchyBallAutoDropTime = GameData.ORIGINALglitchyBallAutoDropTime;

                BallUpgrades.aquaBallPrice = GameData.ORIGINALaquaBallPrice;
                BallUpgrades.mudBallPrice = GameData.ORIGINALmudBallPrice;
                BallUpgrades.basketBallPrice = GameData.ORIGINALbasketBallPrice;
                BallUpgrades.plumBallPrice = GameData.ORIGINALplumBallPrice;
                BallUpgrades.stickyBallPrice = GameData.ORIGINALstickyBallPrice;
                BallUpgrades.candyBallPrice = GameData.ORIGINALcandyBallPrice;
                BallUpgrades.cookieBallPrice = GameData.ORIGINALcookieBallPrice;
                BallUpgrades.limeBallPrice = GameData.ORIGINALlimeBallPrice;
                BallUpgrades.goldenBallPrice = GameData.ORIGINALgoldenBallPrice;
                BallUpgrades.footballBallPrice = GameData.ORIGINALfootballBallPrice;
                BallUpgrades.sharpnelBallPrice = GameData.ORIGINALsharpnelBallPrice;
                BallUpgrades.zonicBallPrice = GameData.ORIGINALzonicBallPrice;
                BallUpgrades.apricotBallPrice = GameData.ORIGINALapricotBallPrice;
                BallUpgrades.peggoBallPrice = GameData.ORIGINALpeggoBallPrice;
                BallUpgrades.ghostBallPrice = GameData.ORIGINALghostBallPrice;
                BallUpgrades.starBallPrice = GameData.ORIGINALstarBallPrice;
                BallUpgrades.rainbowBallPrice = GameData.ORIGINALrainbowBallPrice;
                BallUpgrades.glitchyBallPrice = GameData.ORIGINALglitchyBallPrice;
            }

            MainShooter.basicBallsAvailable = 1;
            MainShooter.redBallsAviable = 1;
            MainShooter.rockBallsAviable = 1;
            MainShooter.bombBallsAviable = 1;

            BallUpgrades.totalRegularBalls = 1;
            BallUpgrades.totalRedBalls = 1;
            BallUpgrades.totalRockBalls = 1;
            BallUpgrades.totalBombBalls = 1;

            Levels.middleFillIncrement = 2;
            BallUpgrades.points = 0;

            BallUpgrades.regularBallLevel = 1;
            BallUpgrades.redBallLevel = 1;
            BallUpgrades.rockBallLevel = 1;
            BallUpgrades.bombBallLevel = 1;

            BallUpgrades.bucketLevel = 1;
            BallUpgrades.goldenPegsLevel = 1;

            BallUpgrades.ballNumber = 1; BallUpgrades.ballNumberEquipped = 1;

            BallUpgrades.isRegularBallAutoPurchased = false;
            BallUpgrades.isRedBallAutoPurchased = false;
            BallUpgrades.isRockBallAutoPurchased = false;
            BallUpgrades.isBombBallAutoPurchased = false;

            BallUpgrades.bouncyBallPurchased = false;
            BallUpgrades.rockBallPurchased = false;
            BallUpgrades.bombBallPurchased = false;

            BallUpgrades.bucketIncrease = 1;
            BallUpgrades.goldenPegsIncrease = 1;

            BallUpgrades.regularBallGold = GameData.ORIGINALregularBallGold;
            BallUpgrades.redBallGold = GameData.ORIGINALRedBallGold;
            BallUpgrades.rockBallGold = GameData.ORIGINALRockBallGold;
            BallUpgrades.bombBallGold = GameData.ORIGINALBombBallGold;

            BallUpgrades.regularBallUpgradePrice = GameData.ORIGINALregularBallUpgradePrice;
            BallUpgrades.regularBallAutoPrice = GameData.ORIGINALregularBallAutoPrice;
            BallUpgrades.regularBallPluss1Price = GameData.ORIGINALregularBallPluss1Price;

            BallUpgrades.redBallUpgradePrice = GameData.ORIGINALredBallUpgradePrice;
            BallUpgrades.redBallAutoPrice = GameData.ORIGINALredBallAutoPrice;
            BallUpgrades.redBallPluss1Price = GameData.ORIGINALredBallPluss1Price;

            BallUpgrades.rockBallUpgradePrice = GameData.ORIGINALrockBallUpgradePrice;
            BallUpgrades.rockBallAutoPrice = GameData.ORIGINALrockBallAutoPrice;
            BallUpgrades.rockBallPluss1Price = GameData.ORIGINALrockBallPluss1Price;

            BallUpgrades.bombBallUpgradePrice = GameData.ORIGINALbombBallUpgradePrice;
            BallUpgrades.bombBallAutoPrice = GameData.ORIGINALbombBallAutoPrice;
            BallUpgrades.bombBallPluss1Price = GameData.ORIGINALbombBallPluss1Price;

            BallUpgrades.basicBallAutoDropTime = GameData.ORIGINALbasicBallAutoDropTime;
            BallUpgrades.redBallAutoDropTime = GameData.ORIGINALredBallAutoDropTime;
            BallUpgrades.rockBallAutoDropTime = GameData.ORIGINALrockBallAutoDropTime;
            BallUpgrades.bombBallAutoDropTime = GameData.ORIGINALbombBallAutoDropTime;

            BallUpgrades.bouncyBallPrice = GameData.ORIGINALbouncyBallPrice;
            BallUpgrades.rockBallPrice = GameData.ORIGINALrockBallPrice;
            BallUpgrades.bombBallPrice = GameData.ORIGINALbombBallPrice;

            BallUpgrades.bucketPrice = GameData.ORIGINALbucketPrice;
            BallUpgrades.goldenPegsPrice = GameData.ORIGINALgoldenPegsPrice;

            BallUpgrades.totalGhostBallIncrease = 0;
            BallUpgrades.totalRainbowBallIncrease = 0;

            BasicBall.totalRainbowBallHitPegs = 0;
            BasicBall.starBallPegsHit = 0;
            BasicBall.glitchyBallStarbuffPegsHit = 0;
            BasicBall.ghostBallsOnScreen = 0;
            pointScript.CheckWhichBallsToSpawnText();
        }
    }
}
