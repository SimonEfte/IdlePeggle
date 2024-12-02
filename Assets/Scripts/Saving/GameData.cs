using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    #region Original ball values
    public static double ORIGINALregularBallGold, ORIGINALRedBallGold, ORIGINALRockBallGold, ORIGINALBombBallGold, ORIGINALaquaBallGold, ORIGINALmudBallGold, ORIGINALbasketBallGold, ORIGINALplumBallGold, ORIGINALstickyBallGold, ORIGINALcandyBallGold, ORIGINALcookieBallGold,ORIGINALlimeBallGold,ORIGINALgoldenBallGold, ORIGINALfootballBallGold, ORIGINALsharpnelBallGold, ORIGINALzonicBallGold,ORIGINALapricotBallGold,ORIGINALpeggoBallGold,ORIGINALghostBallGold, ORIGINALstarBallGold, ORIGINALrainbowBallGold, ORIGINALglitchyBallGold;

    public static double ORIGINALregularBallUpgradePrice, ORIGINALregularBallAutoPrice, ORIGINALregularBallPluss1Price;
    public static double ORIGINALredBallUpgradePrice, ORIGINALredBallAutoPrice, ORIGINALredBallPluss1Price;
    public static double ORIGINALrockBallUpgradePrice, ORIGINALrockBallAutoPrice, ORIGINALrockBallPluss1Price;
    public static double ORIGINALbombBallUpgradePrice, ORIGINALbombBallAutoPrice, ORIGINALbombBallPluss1Price;

    public static double ORIGINALaquaBallUpgradePrice, ORIGINALaquaBallAutoPrice, ORIGINALaquaBallPluss1Price;
    public static double ORIGINALmudBallUpgradePrice, ORIGINALmudBallAutoPrice, ORIGINALmudBallPluss1Price;
    public static double ORIGINALbasketBallUpgradePrice, ORIGINALbasketBallAutoPrice, ORIGINALbasketBallPluss1Price;
    public static double ORIGINALplumBallUpgradePrice, ORIGINALplumBallAutoPrice, ORIGINALplumBallPluss1Price;
    public static double ORIGINALstickyBallUpgradePrice, ORIGINALstickyBallAutoPrice, ORIGINALstickyBallPluss1Price;

    public static double ORIGINALcandyBallUpgradePrice, ORIGINALcookieBallUpgradePrice, ORIGINALlimeBallUpgradePrice,ORIGINALgoldenBallUpgradePrice, ORIGINALfootballBallUpgradePrice, ORIGINALsharpnelBallUpgradePrice,ORIGINALzonicBallUpgradePrice, ORIGINALapricotBallUpgradePrice, ORIGINALpeggoBallUpgradePrice, ORIGINALghostBallUpgradePrice, ORIGINALstarBallUpgradePrice, ORIGINALrainbowBallUpgradePrice, ORIGINALglitchyBallUpgradePrice;

    public static double ORIGINALcandyBallAutoPrice, ORIGINALcookieBallAutoPrice,ORIGINALlimeBallAutoPrice,ORIGINALgoldenBallAutoPrice,ORIGINALfootballBallAutoPrice, ORIGINALsharpnelBallAutoPrice, ORIGINALzonicBallAutoPrice,ORIGINALapricotBallAutoPrice, ORIGINALpeggoBallAutoPrice, ORIGINALghostBallAutoPrice,ORIGINALstarBallAutoPrice, ORIGINALrainbowBallAutoPrice, ORIGINALglitchyBallAutoPrice;

    public static double ORIGINALcandyBallPluss1Price,ORIGINALcookieBallPluss1Price, ORIGINALlimeBallPluss1Price,ORIGINALgoldenBallPluss1Price, ORIGINALfootballBallPluss1Price, ORIGINALsharpnelBallPluss1Price,ORIGINALzonicBallPluss1Price,ORIGINALapricotBallPluss1Price,ORIGINALpeggoBallPluss1Price, ORIGINALghostBallPluss1Price,ORIGINALstarBallPluss1Price, ORIGINALrainbowBallPluss1Price, ORIGINALglitchyBallPluss1Price;

    public static float ORIGINALbasicBallAutoDropTime, ORIGINALredBallAutoDropTime, ORIGINALrockBallAutoDropTime, ORIGINALbombBallAutoDropTime, ORIGINALaquaBallAutoDropTime, ORIGINALmudBallAutoDropTime, ORIGINALbasketBallAutoDropTime, ORIGINALplumBallAutoDropTime, ORIGINALstickyBallAutoDropTime, ORIGINALcandyBallAutoDropTime,ORIGINALcookieBallAutoDropTime,ORIGINALlimeBallAutoDropTime,ORIGINALgoldenBallAutoDropTime,ORIGINALfootballBallAutoDropTime, ORIGINALsharpnelBallAutoDropTime,ORIGINALzonicBallAutoDropTime, ORIGINALapricotBallAutoDropTime, ORIGINALpeggoBallAutoDropTime, ORIGINALghostBallAutoDropTime,ORIGINALstarBallAutoDropTime, ORIGINALrainbowBallAutoDropTime,ORIGINALglitchyBallAutoDropTime;

    public static double ORIGINALbouncyBallPrice, ORIGINALrockBallPrice, ORIGINALbombBallPrice, ORIGINALaquaBallPrice, ORIGINALmudBallPrice, ORIGINALbasketBallPrice, ORIGINALplumBallPrice, ORIGINALstickyBallPrice, ORIGINALcandyBallPrice, ORIGINALcookieBallPrice, ORIGINALlimeBallPrice, ORIGINALgoldenBallPrice, ORIGINALfootballBallPrice,ORIGINALsharpnelBallPrice,ORIGINALzonicBallPrice,ORIGINALapricotBallPrice,ORIGINALpeggoBallPrice, ORIGINALghostBallPrice, ORIGINALstarBallPrice,ORIGINALrainbowBallPrice, ORIGINALglitchyBallPrice;

    public static double ORIGINALbucketPrice, ORIGINALgoldenPegsPrice;
    #endregion

    public static bool isDemo;

    public GameData()
    {
        isDemo = false;
        ORIGINALbucketPrice = 800;
        ORIGINALgoldenPegsPrice = 500;

        #region Auto Drop Time ORIGINAL
        ORIGINALbasicBallAutoDropTime = 3;
        ORIGINALredBallAutoDropTime = 3;
        ORIGINALrockBallAutoDropTime = 3;
        ORIGINALbombBallAutoDropTime = 3;

        //Full Game
        ORIGINALaquaBallAutoDropTime = 3;
        ORIGINALmudBallAutoDropTime = 3;
        ORIGINALbasketBallAutoDropTime = 3;
        ORIGINALplumBallAutoDropTime = 3;
        ORIGINALstickyBallAutoDropTime = 3;
        ORIGINALcandyBallAutoDropTime = 3;
        ORIGINALcookieBallAutoDropTime = 3;
        ORIGINALlimeBallAutoDropTime = 3;
        ORIGINALgoldenBallAutoDropTime = 3;
        ORIGINALfootballBallAutoDropTime = 3;
        ORIGINALsharpnelBallAutoDropTime = 3;
        ORIGINALzonicBallAutoDropTime = 3;
        ORIGINALapricotBallAutoDropTime = 3;
        ORIGINALpeggoBallAutoDropTime = 3;
        ORIGINALghostBallAutoDropTime = 3;
        ORIGINALstarBallAutoDropTime = 3;
        ORIGINALrainbowBallAutoDropTime = 3;
        ORIGINALglitchyBallAutoDropTime = 3;

        #endregion

        #region Ball Price ORIGINAL
        ORIGINALbouncyBallPrice = 250f;
        ORIGINALrockBallPrice = 1150f; //x4.6
        ORIGINALbombBallPrice = 17500; //x15.2

        //Full Game
        ORIGINALaquaBallPrice = 350000; //x17.1
        ORIGINALmudBallPrice = 13000000; //x25
        ORIGINALbasketBallPrice = 900000000; //x32.5
        ORIGINALplumBallPrice = 25000000000; //x40
        ORIGINALstickyBallPrice = 1300000000000; //x47.5
        ORIGINALcandyBallPrice = 78000000000000; //x55
        ORIGINALcookieBallPrice = 5000000000000000; //x63
        ORIGINALlimeBallPrice = 234000000000000000; //x71
        ORIGINALgoldenBallPrice = 28000000000000000000f; //x80
        ORIGINALfootballBallPrice = 2500000000000000000000f; //x90
        ORIGINALsharpnelBallPrice = 467000000000000000000000f; //x100
        ORIGINALzonicBallPrice = 47500000000000000000000000f; //x112
        ORIGINALapricotBallPrice = 7600000000000000000000000000f; //x124
        ORIGINALpeggoBallPrice = 720000000000000000000000000000f; //x138
        ORIGINALghostBallPrice = 125000000000000000000000000000000f; //x153
        ORIGINALstarBallPrice = 19300000000000000000000000000000000f; //x169
        ORIGINALrainbowBallPrice = 5000000000000000000000000000000000000f; //x186
        ORIGINALglitchyBallPrice = 1200000000000000000000000000000000000000d; //x250

        //How long to reach the next ball.
        //With level 2 and no buffs and not playing active.
        //Aqua ball: 3 Min = 55K gold. TOTAL = 16 MIN //CHANGED
        //Mud ball: 3 Min = 381K gold. TOTAL = 74 Min //CHANGES
        //Basket ball: 3 Min = 3.565M gold. TOTAL = 294 Min //CHANGED
        //Plum ball: 3 Min = 148M gold. Total = 505 Min //CHANGED
        //Sticky ball: 3 Min = 4.7B gold. Total = 829 Min //CHANGES
        //Candy ball: 3 Min = 200B Gold. Total = 1170 Min. //CHANGES
        //Cookie ball: 3 Min = 10.7T gold. Total = 1386 Min //CHANGES
        //Lime ball: 3 Min = 326.8T gold. Total = 2 152 Min //CHANGED
        //Golden ball: 3 Min = 32Quad gold. Total = 2 565 Min //CHANGED
        //Football ball: 3 Min = 2Quin gold. Total = 3 600 Min. //CHANGED
        //Shrapnel ball: 3 Min = 306Quin gold. Total = 4 675 min //CHANGED
        //Ring ball: 3 Min = 20.1sx gold. Total 7 125 min //CHANGED
        //Apricot ball: 3 Min = 2.25septillion. Total = 10 133 min. //CHANGED
        //Peggo ball: 3 Min = 167 septillion. Total = 12 933 min.//CHANGED
        //Ghost ball: 3 Min = 24.1 octillion. Total = 15 560 min. //CHANGED
        //Star ball: 3 Min = 3.2 nonillion. Total = 17 886 min //CHANGED
        //Rainbow ball: 3 Min = 782 nonillion. Total = 20 046 min 
        //Glitchy ball: 3 Min = 145 decillion. Total = 25 000 Min //CHANGED

        //7 HOURS AWAY FROM THE FAME
        //433 962 Prestige points
        //look at screenshot

        #endregion

        #region Ball Gold ORIGINAL
        ORIGINALregularBallGold = 1;
        ORIGINALRedBallGold = ORIGINALbouncyBallPrice / 20f;
        ORIGINALRockBallGold = ORIGINALrockBallPrice / 23f;
        ORIGINALBombBallGold = ORIGINALbombBallPrice / 31f;
        ORIGINALaquaBallGold = ORIGINALaquaBallPrice / 45f;
        ORIGINALmudBallGold = ORIGINALmudBallPrice / 52f;
        ORIGINALbasketBallGold = ORIGINALbasketBallPrice / 240f; //Mud balls to collide = 3 461.
        ORIGINALplumBallGold = ORIGINALplumBallPrice / 170f; //Basketballs to collide = 6 333
        ORIGINALstickyBallGold = ORIGINALstickyBallPrice / 245f; //Plum balls to collide = 8 895
        ORIGINALcandyBallGold = ORIGINALcandyBallPrice / 390f; //Egg balls to collide = 14 868
        ORIGINALcookieBallGold = ORIGINALcookieBallPrice / 1200f; //candy balls to collide = 24 506
        ORIGINALlimeBallGold = ORIGINALlimeBallPrice / 1039f; //Cookie balls to collide = 55 894
        ORIGINALgoldenBallGold = ORIGINALgoldenBallPrice / 4688f; //lime balls to collide = 109 804
        ORIGINALfootballBallGold = ORIGINALfootballBallPrice / 8780f; //golden balls to collide = 427 086
        ORIGINALsharpnelBallGold = ORIGINALsharpnelBallPrice / 64800f; //footballs to collide = 1 644 485
        ORIGINALzonicBallGold = ORIGINALzonicBallPrice / 61965f; //shrapnells to collide = 6 590 970
        ORIGINALapricotBallGold = ORIGINALapricotBallPrice / 159468f; //rings to collide = 9 935 297
        ORIGINALpeggoBallGold = ORIGINALpeggoBallPrice / 133506f; // apricot balls to collide = 15 107 613
        ORIGINALghostBallGold = ORIGINALghostBallPrice / 283005f; //peggo balls to collide = 23 175 207
        ORIGINALstarBallGold = ORIGINALstarBallPrice / 2976750f; // ghost balls to collide = 43 853 926
        ORIGINALrainbowBallGold = ORIGINALrainbowBallPrice / 1452000f; //star balls to collide = 154 236 934
        ORIGINALglitchyBallGold = ORIGINALglitchyBallPrice / 950000f; //rainbow balls to collide = 290 390 540
        #endregion

        #region Ball Upgrade Price ORIGINAL
        ORIGINALregularBallUpgradePrice = 5;
        ORIGINALredBallUpgradePrice = ORIGINALbouncyBallPrice * 0.25f;
        ORIGINALrockBallUpgradePrice = ORIGINALrockBallPrice * 0.25f;
        ORIGINALbombBallUpgradePrice = ORIGINALbombBallPrice * 0.25f;

        //Full Game
        ORIGINALaquaBallUpgradePrice = ORIGINALaquaBallPrice * 0.25f;
        ORIGINALmudBallUpgradePrice = ORIGINALmudBallPrice * 0.25f;
        ORIGINALbasketBallUpgradePrice = ORIGINALbasketBallPrice * 0.25f;
        ORIGINALplumBallUpgradePrice = ORIGINALplumBallPrice * 0.25f;
        ORIGINALstickyBallUpgradePrice = ORIGINALstickyBallPrice * 0.25f;
        ORIGINALcandyBallUpgradePrice = ORIGINALcandyBallPrice * 0.25f;
        ORIGINALcookieBallUpgradePrice = ORIGINALcookieBallPrice * 0.25f;
        ORIGINALlimeBallUpgradePrice = ORIGINALlimeBallPrice * 0.25f;
        ORIGINALgoldenBallUpgradePrice = ORIGINALgoldenBallPrice * 0.25f;
        ORIGINALfootballBallUpgradePrice = ORIGINALfootballBallPrice * 0.25f;
        ORIGINALsharpnelBallUpgradePrice = ORIGINALsharpnelBallPrice * 0.25f;
        ORIGINALzonicBallUpgradePrice = ORIGINALzonicBallPrice * 0.25f;
        ORIGINALapricotBallUpgradePrice = ORIGINALapricotBallPrice * 0.25f;
        ORIGINALpeggoBallUpgradePrice = ORIGINALpeggoBallPrice * 0.25f;
        ORIGINALghostBallUpgradePrice = ORIGINALghostBallPrice * 0.25f;
        ORIGINALstarBallUpgradePrice = ORIGINALstarBallPrice * 0.25f;
        ORIGINALrainbowBallUpgradePrice = ORIGINALrainbowBallPrice * 0.25f;
        ORIGINALglitchyBallUpgradePrice = ORIGINALglitchyBallPrice * 0.25f;
        #endregion

        #region Auto Drop Price ORIGINAL
        ORIGINALregularBallAutoPrice = 10;
        ORIGINALredBallAutoPrice = ORIGINALbouncyBallPrice * 0.4f;
        ORIGINALrockBallAutoPrice = ORIGINALrockBallPrice * 0.4f;
        ORIGINALbombBallAutoPrice = ORIGINALbombBallPrice * 0.4f;

        //Full Game
        ORIGINALaquaBallAutoPrice = ORIGINALaquaBallPrice * 0.4f;
        ORIGINALmudBallAutoPrice = ORIGINALmudBallPrice * 0.4f;
        ORIGINALbasketBallAutoPrice = ORIGINALbasketBallPrice * 0.4f;
        ORIGINALplumBallAutoPrice = ORIGINALplumBallPrice * 0.4f;
        ORIGINALstickyBallAutoPrice = ORIGINALstickyBallPrice * 0.4f;
        ORIGINALcandyBallAutoPrice = ORIGINALcandyBallPrice * 0.4f;
        ORIGINALcookieBallAutoPrice = ORIGINALcookieBallPrice * 0.4f;
        ORIGINALlimeBallAutoPrice = ORIGINALlimeBallPrice * 0.4f;
        ORIGINALgoldenBallAutoPrice = ORIGINALgoldenBallPrice * 0.4f;
        ORIGINALfootballBallAutoPrice = ORIGINALfootballBallPrice * 0.4f;
        ORIGINALsharpnelBallAutoPrice = ORIGINALsharpnelBallPrice * 0.4f;
        ORIGINALzonicBallAutoPrice = ORIGINALzonicBallPrice * 0.4f;
        ORIGINALapricotBallAutoPrice = ORIGINALapricotBallPrice * 0.4f;
        ORIGINALpeggoBallAutoPrice = ORIGINALpeggoBallPrice * 0.4f;
        ORIGINALghostBallAutoPrice = ORIGINALghostBallPrice * 0.4f;
        ORIGINALstarBallAutoPrice = ORIGINALstarBallPrice * 0.4f;
        ORIGINALrainbowBallAutoPrice = ORIGINALrainbowBallPrice * 0.4f;
        ORIGINALglitchyBallAutoPrice = ORIGINALglitchyBallPrice * 0.4f;
        #endregion

        #region Pluss 1 Ball Price ORIGINAL
        ORIGINALregularBallPluss1Price = 30;
        ORIGINALredBallPluss1Price = ORIGINALbouncyBallPrice * 0.6f;
        ORIGINALrockBallPluss1Price = ORIGINALrockBallPrice * 0.6f;
        ORIGINALbombBallPluss1Price = ORIGINALbombBallPrice * 0.6f;

        ORIGINALaquaBallPluss1Price = ORIGINALaquaBallPrice * 0.6f;
        ORIGINALmudBallPluss1Price = ORIGINALmudBallPrice * 0.6f;
        ORIGINALbasketBallPluss1Price = ORIGINALbasketBallPrice * 0.6f;
        ORIGINALplumBallPluss1Price = ORIGINALplumBallPrice * 0.6f;
        ORIGINALstickyBallPluss1Price = ORIGINALstickyBallPrice * 0.6f;
        ORIGINALcandyBallPluss1Price = ORIGINALcandyBallPrice * 0.6f;
        ORIGINALcookieBallPluss1Price = ORIGINALcookieBallPrice * 0.6f;
        ORIGINALlimeBallPluss1Price = ORIGINALlimeBallPrice * 0.6f;
        ORIGINALgoldenBallPluss1Price = ORIGINALgoldenBallPrice * 0.6f;
        ORIGINALfootballBallPluss1Price = ORIGINALfootballBallPrice * 0.6f;
        ORIGINALsharpnelBallPluss1Price = ORIGINALsharpnelBallPrice * 0.6f;
        ORIGINALzonicBallPluss1Price = ORIGINALzonicBallPrice * 0.6f;
        ORIGINALapricotBallPluss1Price = ORIGINALapricotBallPrice * 0.6f;
        ORIGINALpeggoBallPluss1Price = ORIGINALpeggoBallPrice * 0.6f;
        ORIGINALghostBallPluss1Price = ORIGINALghostBallPrice * 0.6f;
        ORIGINALstarBallPluss1Price = ORIGINALstarBallPrice * 0.6f;
        ORIGINALrainbowBallPluss1Price = ORIGINALrainbowBallPrice * 0.6f;
        ORIGINALglitchyBallPluss1Price = ORIGINALglitchyBallPrice * 0.6f;
        #endregion

        SaveBallStats();
        PrestigeSaves();
        StatsSaves();
        TurotiralSaves();
        AllLevelSaved();
        ChallengesSaves();
        ACHSaves();
    }

    #region Ball saves
    public double points;

    public double regularBallGold, redBallGold, rockBallGold, bombBallGold, aquaBallGold, mudBallGold, basketBallGold, plumBallGold, stickyBallGold, candyBallGold,cookieBallGold,limeBallGold,goldenBallGold,footballBallGold,sharpnelBallGold,zonicBallGold, apricotBallGold, peggoBallGold,ghostBallGold, starBallGold ,rainbowBallGold, glitchyBallGold;

    public int totalRegularBalls, totalRedBalls, totalRockBalls, totalBombBalls, totalAquaBalls, totalMudBalls, totalBasketBalls, totalPlumBalls, totalStickyBalls, totalCandyBalls, totalCookieBalls, totalLimeBalls,totalGoldenBalls,totalFootballBalls, totalSharpnelBalls, totalZonicBalls, totalApricotBalls, totalPeggoBalls,  totalGhostBalls,  totalStarBalls, totalRainbowBalls, totalGlitchyBalls;

    public int ballNumber, ballNumberEquipped;

    public double regularBallUpgradePrice, regularBallAutoPrice, regularBallPluss1Price;
    public double redBallUpgradePrice, redBallAutoPrice, redBallPluss1Price;
    public double rockBallUpgradePrice, rockBallAutoPrice, rockBallPluss1Price;
    public double bombBallUpgradePrice, bombBallAutoPrice, bombBallPluss1Price;
    public double aquaBallUpgradePrice, aquaBallAutoPrice, aquaBallPluss1Price;
    public double mudBallUpgradePrice, mudBallAutoPrice, mudBallPluss1Price;
    public double basketBallUpgradePrice, basketBallAutoPrice, basketBallPluss1Price;
    public double plumBallUpgradePrice, plumBallAutoPrice, plumBallPluss1Price;
    public double stickyBallUpgradePrice, stickyBallAutoPrice, stickyBallPluss1Price;

    public double candyBallUpgradePrice, cookieBallUpgradePrice, limeBallUpgradePrice, goldenBallUpgradePrice, footballBallUpgradePrice, sharpnelBallUpgradePrice, zonicBallUpgradePrice, apricotBallUpgradePrice, peggoBallUpgradePrice, ghostBallUpgradePrice, starBallUpgradePrice, rainbowBallUpgradePrice, glitchyBallUpgradePrice;

    public double candyBallAutoPrice, cookieBallAutoPrice, limeBallAutoPrice, goldenBallAutoPrice, footballBallAutoPrice, sharpnelBallAutoPrice, zonicBallAutoPrice, apricotBallAutoPrice, peggoBallAutoPrice, ghostBallAutoPrice, starBallAutoPrice, rainbowBallAutoPrice, glitchyBallAutoPrice;

    public double candyBallPluss1Price, cookieBallPluss1Price, limeBallPluss1Price, goldenBallPluss1Price, footballBallPluss1Price, sharpnelBallPluss1Price, zonicBallPluss1Price, apricotBallPluss1Price, peggoBallPluss1Price, ghostBallPluss1Price, starBallPluss1Price, rainbowBallPluss1Price, glitchyBallPluss1Price;

    public float basicBallAutoDropTime, redBallAutoDropTime, rockBallAutoDropTime, bombBallAutoDropTime, aquaBallAutoDropTime, mudBallAutoDropTime, basketBallAutoDropTime, plumBallAutoDropTime, stickyBallAutoDropTime, candyBallAutoDropTime, cookieBallAutoDropTime, limeBallAutoDropTime, goldenBallAutoDropTime, footballBallAutoDropTime, sharpnelBallAutoDropTime, zonicBallAutoDropTime, apricotBallAutoDropTime, peggoBallAutoDropTime, ghostBallAutoDropTime, starBallAutoDropTime, rainbowBallAutoDropTime, glitchyBallAutoDropTime;

    public double bouncyBallPrice, rockBallPrice, bombBallPrice, aquaBallPrice, mudBallPrice, basketBallPrice, plumBallPrice, stickyBallPrice, candyBallPrice, cookieBallPrice, limeBallPrice, goldenBallPrice, footballBallPrice, sharpnelBallPrice, zonicBallPrice, apricotBallPrice, peggoBallPrice, ghostBallPrice, starBallPrice, rainbowBallPrice, glitchyBallPrice;

    public bool isRegularBallAutoPurchased, isRedBallAutoPurchased, isRockBallAutoPurchased, isBombBallAutoPurchased, isAquaBallAutoPurchased, isMudBallAutoPurchased, isBasketBallAutoPurchased, isPlumBallAutoPurchased, isStickyBallAutoPurchased, isCandyBallAutoPurchased, isCookieBallAutoPurchased, isLimeBallAutoPurchased, isGoldenBallAutoPurchased, isFootballBallAutoPurchased, isSharpnelBallAutoPurchased, isZonicBallAutoPurchased, isApricotBallAutoPurchased, isPeggoBallAutoPurchased, isGhostBallAutoPurchased, isStarBallAutoPurchased, isRainbowBallAutoPurchased, isGlitchyBallAutoPurchased;

    public bool bouncyBallPurchased, rockBallPurchased, bombBallPurchased, aquaBallPurchased, mudBallPurchased, basketBallPurchased, plumBallPurchased, stickyBallPurchased, candyBallPurchased, cookieBallPurchased, limeBallPurchased, goldenBallPurchased, footballBallPurchased, sharpnelBallPurchased, zonicBallPurchased, apricotBallPurchased, peggoBallPurchased, ghostBallPurchased, starBallPurchased, rainbowBallPurchased, glitchyBallPurchased;
    public bool firstTimePurchaseNewBall;

    public int regularBallLevel, redBallLevel, rockBallLevel, bombBallLevel, aquaBallLevel, mudBallLevel, basketBallLevel, plumBallLevel, stickyBallLevel, candyBallLevel, cookieBallLevel, limeBallLevel, goldenBallLevel, footballBallLevel, sharpnelBallLevel, zonicBallLevel, apricotBallLevel, peggoBallLevel, ghostBallLevel, starBallLevel, rainbowBallLevel, glitchyBallLevel;

    public double bucketPrice, goldenPegsPrice;
    public int goldenPegsLevel, bucketLevel;

    public float bucketIncrease;
    public float goldenPegsIncrease;

    public int autoPurchased, maxAutoCount;
    public float textSpawnChance, offlineProgressTextChance;

    public bool isBall1AutoTurnedOff, isBall2AutoTurnedOff, isBall3AutoTurnedOff, isBall4AutoTurnedOff, isBall5AutoTurnedOff, isBall6AutoTurnedOff, isBall7AutoTurnedOff, isBall8AutoTurnedOff, isBall9AutoTurnedOff, isBall10AutoTurnedOff, isBall11AutoTurnedOff, isBall12AutoTurnedOff, isBall13AutoTurnedOff, isBall14AutoTurnedOff, isBall15AutoTurnedOff, isBall16AutoTurnedOff, isBall17AutoTurnedOff, isBall18AutoTurnedOff, isBall19AutoTurnedOff, isBall20AutoTurnedOff, isBall21AutoTurnedOff, isBall22AutoTurnedOff;

    public void SaveBallStats()
    {
        this.points = 0;
        this.regularBallGold = ORIGINALregularBallGold;
        this.redBallGold = ORIGINALRedBallGold;
        this.rockBallGold = ORIGINALRockBallGold;
        this.bombBallGold = ORIGINALBombBallGold;

        this.regularBallUpgradePrice = ORIGINALregularBallUpgradePrice;
        this.regularBallAutoPrice = ORIGINALregularBallAutoPrice;
        this.regularBallPluss1Price = ORIGINALregularBallPluss1Price;

        this.redBallUpgradePrice = ORIGINALredBallUpgradePrice;
        this.redBallAutoPrice = ORIGINALredBallAutoPrice;
        this.redBallPluss1Price = ORIGINALredBallPluss1Price;

        this.rockBallUpgradePrice = ORIGINALrockBallUpgradePrice;
        this.rockBallAutoPrice = ORIGINALrockBallAutoPrice;
        this.rockBallPluss1Price = ORIGINALrockBallPluss1Price;

        this.bombBallUpgradePrice = ORIGINALbombBallUpgradePrice;
        this.bombBallAutoPrice = ORIGINALbombBallAutoPrice;
        this.bombBallPluss1Price = ORIGINALbombBallPluss1Price;

        this.basicBallAutoDropTime = ORIGINALbasicBallAutoDropTime;
        this.redBallAutoDropTime = ORIGINALredBallAutoDropTime;
        this.rockBallAutoDropTime = ORIGINALrockBallAutoDropTime;
        this.bombBallAutoDropTime = ORIGINALbombBallAutoDropTime;

        this.bouncyBallPrice = ORIGINALbouncyBallPrice;
        this.rockBallPrice = ORIGINALrockBallPrice;
        this.bombBallPrice = ORIGINALbombBallPrice;

        this.bucketPrice = ORIGINALbucketPrice;
        this.goldenPegsPrice = ORIGINALgoldenPegsPrice;

        this.totalRegularBalls = 1;
        this.totalRedBalls = 1;
        this.totalRockBalls = 1;
        this.totalBombBalls = 1;

        this.regularBallLevel = 1;
        this.redBallLevel = 1;
        this.rockBallLevel = 1;
        this.bombBallLevel = 1;

        this.bucketLevel = 1;
        this.goldenPegsLevel = 1;

        this.ballNumber = 1; this.ballNumberEquipped = 1;

        this.isRegularBallAutoPurchased = false;
        this.isRedBallAutoPurchased = false;
        this.isRockBallAutoPurchased = false;
        this.isBombBallAutoPurchased = false;

        this.bouncyBallPurchased = false;
        this.rockBallPurchased = false;
        this.bombBallPurchased = false;

        this.firstTimePurchaseNewBall = false;

        this.bucketIncrease = 1;
        this.goldenPegsIncrease = 1;

        this.aquaBallGold = ORIGINALaquaBallGold;
        this.mudBallGold = ORIGINALmudBallGold;
        this.basketBallGold = ORIGINALbasketBallGold;
        this.plumBallGold = ORIGINALplumBallGold;
        this.stickyBallGold = ORIGINALstickyBallGold;
        this.candyBallGold = ORIGINALcandyBallGold;
        this.cookieBallGold = ORIGINALcookieBallGold;
        this.limeBallGold = ORIGINALlimeBallGold;
        this.goldenBallGold = ORIGINALgoldenBallGold;
        this.footballBallGold = ORIGINALfootballBallGold;
        this.sharpnelBallGold = ORIGINALsharpnelBallGold;
        this.zonicBallGold = ORIGINALzonicBallGold;
        this.apricotBallGold = ORIGINALapricotBallGold;
        this.peggoBallGold = ORIGINALpeggoBallGold;
        this.ghostBallGold = ORIGINALghostBallGold;
        this.starBallGold = ORIGINALstarBallGold;
        this.rainbowBallGold = ORIGINALrainbowBallGold;
        this.glitchyBallGold = ORIGINALglitchyBallGold;

        this.aquaBallUpgradePrice = ORIGINALaquaBallUpgradePrice;
        this.mudBallUpgradePrice = ORIGINALmudBallUpgradePrice;
        this.basketBallUpgradePrice = ORIGINALbasketBallUpgradePrice;
        this.plumBallUpgradePrice = ORIGINALplumBallUpgradePrice;
        this.stickyBallUpgradePrice = ORIGINALstickyBallUpgradePrice;
        this.candyBallUpgradePrice = ORIGINALcandyBallUpgradePrice;
        this.cookieBallUpgradePrice = ORIGINALcookieBallUpgradePrice;
        this.limeBallUpgradePrice = ORIGINALlimeBallUpgradePrice;
        this.goldenBallUpgradePrice = ORIGINALgoldenBallUpgradePrice;
        this.footballBallUpgradePrice = ORIGINALfootballBallUpgradePrice;
        this.sharpnelBallUpgradePrice = ORIGINALsharpnelBallUpgradePrice;
        this.zonicBallUpgradePrice = ORIGINALzonicBallUpgradePrice;
        this.apricotBallUpgradePrice = ORIGINALapricotBallUpgradePrice;
        this.peggoBallUpgradePrice = ORIGINALpeggoBallUpgradePrice;
        this.ghostBallUpgradePrice = ORIGINALghostBallUpgradePrice;
        this.starBallUpgradePrice = ORIGINALstarBallUpgradePrice;
        this.rainbowBallUpgradePrice = ORIGINALrainbowBallUpgradePrice;
        this.glitchyBallUpgradePrice = ORIGINALglitchyBallUpgradePrice;

        this.aquaBallAutoPrice = ORIGINALaquaBallAutoPrice;
        this.mudBallAutoPrice = ORIGINALmudBallAutoPrice;
        this.basketBallAutoPrice = ORIGINALbasketBallAutoPrice;
        this.plumBallAutoPrice = ORIGINALplumBallAutoPrice;
        this.stickyBallAutoPrice = ORIGINALstickyBallAutoPrice;
        this.candyBallAutoPrice = ORIGINALcandyBallAutoPrice;
        this.cookieBallAutoPrice = ORIGINALcookieBallAutoPrice;
        this.limeBallAutoPrice = ORIGINALlimeBallAutoPrice;
        this.goldenBallAutoPrice = ORIGINALgoldenBallAutoPrice;
        this.footballBallAutoPrice = ORIGINALfootballBallAutoPrice;
        this.sharpnelBallAutoPrice = ORIGINALsharpnelBallAutoPrice;
        this.zonicBallAutoPrice = ORIGINALzonicBallAutoPrice;
        this.apricotBallAutoPrice = ORIGINALapricotBallAutoPrice;
        this.peggoBallAutoPrice = ORIGINALpeggoBallAutoPrice;
        this.ghostBallAutoPrice = ORIGINALghostBallAutoPrice;
        this.starBallAutoPrice = ORIGINALstarBallAutoPrice;
        this.rainbowBallAutoPrice = ORIGINALrainbowBallAutoPrice;
        this.glitchyBallAutoPrice = ORIGINALglitchyBallAutoPrice;

        this.aquaBallPluss1Price = ORIGINALaquaBallPluss1Price;
        this.mudBallPluss1Price = ORIGINALmudBallPluss1Price;
        this.basketBallPluss1Price = ORIGINALbasketBallPluss1Price;
        this.plumBallPluss1Price = ORIGINALplumBallPluss1Price;
        this.stickyBallPluss1Price = ORIGINALstickyBallPluss1Price;
        this.candyBallPluss1Price = ORIGINALcandyBallPluss1Price;
        this.cookieBallPluss1Price = ORIGINALcookieBallPluss1Price;
        this.limeBallPluss1Price = ORIGINALlimeBallPluss1Price;
        this.goldenBallPluss1Price = ORIGINALgoldenBallPluss1Price;
        this.footballBallPluss1Price = ORIGINALfootballBallPluss1Price;
        this.sharpnelBallPluss1Price = ORIGINALsharpnelBallPluss1Price;
        this.zonicBallPluss1Price = ORIGINALzonicBallPluss1Price;
        this.apricotBallPluss1Price = ORIGINALapricotBallPluss1Price;
        this.peggoBallPluss1Price = ORIGINALpeggoBallPluss1Price;
        this.ghostBallPluss1Price = ORIGINALghostBallPluss1Price;
        this.starBallPluss1Price = ORIGINALstarBallPluss1Price;
        this.rainbowBallPluss1Price = ORIGINALrainbowBallPluss1Price;
        this.glitchyBallPluss1Price = ORIGINALglitchyBallPluss1Price;

        this.aquaBallAutoDropTime = ORIGINALaquaBallAutoDropTime;
        this.mudBallAutoDropTime = ORIGINALmudBallAutoDropTime;
        this.basketBallAutoDropTime = ORIGINALbasketBallAutoDropTime;
        this.plumBallAutoDropTime = ORIGINALplumBallAutoDropTime;
        this.stickyBallAutoDropTime = ORIGINALstickyBallAutoDropTime;
        this.candyBallAutoDropTime = ORIGINALcandyBallAutoDropTime;
        this.cookieBallAutoDropTime = ORIGINALcookieBallAutoDropTime;
        this.limeBallAutoDropTime = ORIGINALlimeBallAutoDropTime;
        this.goldenBallAutoDropTime = ORIGINALgoldenBallAutoDropTime;
        this.footballBallAutoDropTime = ORIGINALfootballBallAutoDropTime;
        this.sharpnelBallAutoDropTime = ORIGINALsharpnelBallAutoDropTime;
        this.zonicBallAutoDropTime = ORIGINALzonicBallAutoDropTime;
        this.apricotBallAutoDropTime = ORIGINALapricotBallAutoDropTime;
        this.peggoBallAutoDropTime = ORIGINALpeggoBallAutoDropTime;
        this.ghostBallAutoDropTime = ORIGINALghostBallAutoDropTime;
        this.starBallAutoDropTime = ORIGINALstarBallAutoDropTime;
        this.rainbowBallAutoDropTime = ORIGINALrainbowBallAutoDropTime;
        this.glitchyBallAutoDropTime = ORIGINALglitchyBallAutoDropTime;

        this.aquaBallPrice = ORIGINALaquaBallPrice;
        this.mudBallPrice = ORIGINALmudBallPrice;
        this.basketBallPrice = ORIGINALbasketBallPrice;
        this.plumBallPrice = ORIGINALplumBallPrice;
        this.stickyBallPrice = ORIGINALstickyBallPrice;
        this.candyBallPrice = ORIGINALcandyBallPrice;
        this.cookieBallPrice = ORIGINALcookieBallPrice;
        this.limeBallPrice = ORIGINALlimeBallPrice;
        this.goldenBallPrice = ORIGINALgoldenBallPrice;
        this.footballBallPrice = ORIGINALfootballBallPrice;
        this.sharpnelBallPrice = ORIGINALsharpnelBallPrice;
        this.zonicBallPrice = ORIGINALzonicBallPrice;
        this.apricotBallPrice = ORIGINALapricotBallPrice;
        this.peggoBallPrice = ORIGINALpeggoBallPrice;
        this.ghostBallPrice = ORIGINALghostBallPrice;
        this.starBallPrice = ORIGINALstarBallPrice;
        this.rainbowBallPrice = ORIGINALrainbowBallPrice;
        this.glitchyBallPrice = ORIGINALglitchyBallPrice;

        this.totalAquaBalls = 1;
        this.totalMudBalls = 1;
        this.totalBasketBalls = 1;
        this.totalPlumBalls = 1;
        this.totalStickyBalls = 1;
        this.totalCandyBalls = 1;
        this.totalCookieBalls = 1;
        this.totalLimeBalls = 1;
        this.totalGoldenBalls = 1;
        this.totalFootballBalls = 1;
        this.totalSharpnelBalls = 1;
        this.totalZonicBalls = 1;
        this.totalApricotBalls = 1;
        this.totalPeggoBalls = 1;
        this.totalGhostBalls = 1;
        this.totalStarBalls = 1;
        this.totalRainbowBalls = 1;
        this.totalGlitchyBalls = 1;

        this.aquaBallLevel = 1;
        this.mudBallLevel = 1;
        this.basketBallLevel = 1;
        this.plumBallLevel = 1;
        this.stickyBallLevel = 1;
        this.candyBallLevel = 1;
        this.cookieBallLevel = 1;
        this.limeBallLevel = 1;
        this.goldenBallLevel = 1;
        this.footballBallLevel = 1;
        this.sharpnelBallLevel = 1;
        this.zonicBallLevel = 1;
        this.apricotBallLevel = 1;
        this.peggoBallLevel = 1;
        this.ghostBallLevel = 1;
        this.starBallLevel = 1;
        this.rainbowBallLevel = 1;
        this.glitchyBallLevel = 1;

        this.isAquaBallAutoPurchased = false;
        this.isMudBallAutoPurchased = false;
        this.isBasketBallAutoPurchased = false;
        this.isPlumBallAutoPurchased = false;
        this.isStickyBallAutoPurchased = false;
        this.isCandyBallAutoPurchased = false;
        this.isCookieBallAutoPurchased = false;
        this.isLimeBallAutoPurchased = false;
        this.isGoldenBallAutoPurchased = false;
        this.isFootballBallAutoPurchased = false;
        this.isSharpnelBallAutoPurchased = false;
        this.isZonicBallAutoPurchased = false;
        this.isApricotBallAutoPurchased = false;
        this.isPeggoBallAutoPurchased = false;
        this.isGhostBallAutoPurchased = false;
        this.isStarBallAutoPurchased = false;
        this.isRainbowBallAutoPurchased = false;
        this.isGlitchyBallAutoPurchased = false;

        this.aquaBallPurchased = false;
        this.mudBallPurchased = false;
        this.basketBallPurchased = false;
        this.plumBallPurchased = false;
        this.stickyBallPurchased = false;
        this.candyBallPurchased = false;
        this.cookieBallPurchased = false;
        this.limeBallPurchased = false;
        this.goldenBallPurchased = false;
        this.footballBallPurchased = false;
        this.sharpnelBallPurchased = false;
        this.zonicBallPurchased = false;
        this.apricotBallPurchased = false;
        this.peggoBallPurchased = false;
        this.ghostBallPurchased = false;
        this.starBallPurchased = false;
        this.rainbowBallPurchased = false;
        this.glitchyBallPurchased = false;

        this.autoPurchased = 0;
        this.maxAutoCount = 0;
        this.textSpawnChance = 0;
        this.offlineProgressTextChance = 0;

        this.isBall1AutoTurnedOff = false;
        this.isBall2AutoTurnedOff = false;
        this.isBall3AutoTurnedOff = false;
        this.isBall4AutoTurnedOff = false;
        this.isBall5AutoTurnedOff = false;
        this.isBall6AutoTurnedOff = false;
        this.isBall7AutoTurnedOff = false;
        this.isBall8AutoTurnedOff = false;
        this.isBall9AutoTurnedOff = false;
        this.isBall10AutoTurnedOff = false;
        this.isBall11AutoTurnedOff = false;
        this.isBall12AutoTurnedOff = false;
        this.isBall13AutoTurnedOff = false;
        this.isBall14AutoTurnedOff = false;
        this.isBall15AutoTurnedOff = false;
        this.isBall16AutoTurnedOff = false;
        this.isBall17AutoTurnedOff = false;
        this.isBall18AutoTurnedOff = false;
        this.isBall19AutoTurnedOff = false;
        this.isBall20AutoTurnedOff = false;
        this.isBall21AutoTurnedOff = false;
        this.isBall22AutoTurnedOff = false;
    }
    #endregion

    #region Stats saves
    public double totalGold, totalGoldSpent;
    public int totalBallsShot, totalBallsDropped, totalPegsHit, totalBoardsCleared;

    public float greenPegChance;
    public int greenPegsHit, goldenPegsHit, prestigePegsHit, redPegsHit;
    public double totalPegGold;

    public int totalBallsPit;
    public double totalPitGold;

    public int prestigeUpgradesPurchased, levelsUnlocked, totalPegsUnlocked;
    public int totalPrestigePointSpent, totalPRestigePoints;
    public int rainbowPegsHit, bombPegsHit, purplePegHit;

    public int timesFullyCharge, timesGoldRush, timesPrestigeRush;
    public double goldFromClear, goldFromShootingStat;
    public int prestigePointFromClear, prestigePointsFromBucket;

    public float totalPrestigePointOverflow;

    public void StatsSaves()
    {
        this.totalGold = 0;
        this.totalGoldSpent = 0;
        this.totalBallsShot = 0;
        this.totalBallsDropped = 0;
        this.totalPegsHit = 0;
        this.totalBoardsCleared = 0;

        this.greenPegChance = 100 - (goldenPegChance + prestigePegChance + redPegChance);
        this.greenPegsHit = 0;
        this.goldenPegsHit = 0;
        this.prestigePegsHit = 0;
        this.redPegsHit = 0;
        this.rainbowPegsHit = 0;
        this.bombPegsHit = 0;
        this.purplePegHit = 0;

        this.totalPegGold = 0;

        this.totalBallsPit = 0;
        this.totalPitGold = 0;

        this.totalPegsUnlocked = 3;
        this.levelsUnlocked = 1;
        this.prestigeUpgradesPurchased = 0;

        this.totalPrestigePointSpent = 0;
        this.totalPRestigePoints = 0;

        this.timesFullyCharge = 0;
        this.timesGoldRush = 0;
        this.timesPrestigeRush = 0;
        this.goldFromClear = 0;
        this.goldFromShootingStat = 0;
        this.prestigePointFromClear = 0;
        this.prestigePointsFromBucket = 0;

        this.totalPrestigePointOverflow = 0;
    }
    #endregion

    #region Level saves
    public int middleFillIncrement;
    public int fullFillShots;
    public float fullChargeAmount;
    public int board1Clears, board2Clears, board3Clears, board4Clears, board5Clears, board6Clears, board7Clears, board8Clears, board9Clears, board10Clears;

    public void AllLevelSaved()
    {
        this.middleFillIncrement = 2;
        this.fullFillShots = 15;
        this.fullChargeAmount = 0;

        this.board1Clears = 0;
        this.board2Clears = 0;
        this.board3Clears = 0;
        this.board4Clears = 0;
        this.board5Clears = 0;
        this.board6Clears = 0;
        this.board7Clears = 0;
        this.board8Clears = 0;
        this.board9Clears = 0;
        this.board10Clears = 0;
    }
    #endregion

    #region Prestige saves
    public int prestigePoints;
    public float prestigePointsOverFlow;
    public int levelSelected;

    public bool purchasedFirstUpgrade;

    public bool purchasedLevel2, purchasedLevel3, purchasedLevel4, purchasedLevel5, purchasedLevel6, purchasedLevel7, purchasedLevel8, purchasedLevel9, purchasedLevel10;

    public float prestigeGoldIncrease;
    public float goldenPegChance;

    public int prestigePointsIncrease;
    public float prestigePegChance;

    public float redPegChance;
    public bool isRedPegUnlocked;

    public float activeGoldIncrease;

    public bool G_Upgrade1Purchased;
    public bool G_Upgrade2Purchased;
    public bool G_Upgrade3Purchased;
    public bool G_Upgrade4Purchased;
    public bool G_Upgrade5Purchased;
    public bool G_Upgrade6Purchased;
    public bool G_Upgrade7Purchased;
    public bool G_Upgrade8Purchased;
    public bool G_Upgrade9Purchased;
    public bool G_Upgrade10Purchased;
    public bool G_Upgrade11Purchased;
    public bool G_Upgrade12Purchased;
    public bool G_Upgrade13Purchased;
    public bool G_Upgrade14Purchased;
    public bool G_Upgrade15Purchased;
    public bool G_Upgrade16Purchased;
    public bool G_Upgrade17Purchased;
    public bool G_Upgrade18Purchased;
    public bool G_Upgrade19Purchased;
    public bool G_Upgrade20Purchased;
    public bool G_Upgrade21Purchased;
    public bool G_Upgrade22Purchased;
    public bool G_Upgrade23Purchased;
    public bool G_Upgrade24Purchased;
    public bool G_Upgrade25Purchased;
    public bool G_Upgrade26Purchased;
    public bool G_Upgrade27Purchased;
    public bool G_Upgrade28Purchased;
    public bool G_Upgrade29Purchased;
    public bool G_Upgrade30Purchased;
    public bool G_Upgrade31Purchased;
    public bool G_Upgrade32Purchased;
    public bool G_Upgrade33Purchased;
    public bool G_Upgrade34Purchased;
    public bool G_Upgrade35Purchased;
    public bool G_Upgrade36Purchased;
    public bool G_Upgrade37Purchased;
    public bool G_Upgrade38Purchased;
    public bool G_Upgrade39Purchased;
    public bool G_Upgrade40Purchased;
    public bool G_Upgrade41Purchased;
    public bool G_Upgrade42Purchased;
    public bool G_Upgrade43Purchased;
    public bool G_Upgrade44Purchased;
    public bool G_Upgrade45Purchased;
    public bool G_Upgrade46Purchased;
    public bool G_Upgrade47Purchased;
    public bool G_Upgrade48Purchased;
    public bool G_Upgrade49Purchased;
    public bool G_Upgrade50Purchased;
    public bool G_Upgrade51Purchased;
  
    public bool PU_Upgrade1Purchased;
    public bool PU_Upgrade2Purchased;
    public bool PU_Upgrade3Purchased;
    public bool PU_Upgrade4Purchased;
    public bool PU_Upgrade5Purchased;
    public bool PU_Upgrade6Purchased;
    public bool PU_Upgrade7Purchased;
    public bool PU_Upgrade8Purchased;
    public bool PU_Upgrade9Purchased;
    public bool PU_Upgrade10Purchased;
    public bool PU_Upgrade11Purchased;
    public bool PU_Upgrade12Purchased;
    public bool PU_Upgrade13Purchased;
    public bool PU_Upgrade14Purchased;
    public bool PU_Upgrade15Purchased;
    public bool PU_Upgrade16Purchased;
    public bool PU_Upgrade17Purchased;
    public bool PU_Upgrade18Purchased;
    public bool PU_Upgrade19Purchased;
    public bool PU_Upgrade20Purchased;
    public bool PU_Upgrade21Purchased;
    public bool PU_Upgrade22Purchased;
    public bool PU_Upgrade23Purchased;
    public bool PU_Upgrade24Purchased;
    public bool PU_Upgrade25Purchased;
    public bool PU_Upgrade26Purchased;
    public bool PU_Upgrade27Purchased;
    public bool PU_Upgrade28Purchased;
    public bool PU_Upgrade29Purchased;
    public bool PU_Upgrade30Purchased;
    public bool PU_Upgrade31Purchased;
    public bool PU_Upgrade32Purchased;
    public bool PU_Upgrade33Purchased;
    public bool PU_Upgrade34Purchased;
    public bool PU_Upgrade35Purchased;
    public bool PU_Upgrade36Purchased;
    public bool PU_Upgrade37Purchased;
    public bool PU_Upgrade38Purchased;
    public bool PU_Upgrade39Purchased;
    public bool PU_Upgrade40Purchased;
    public bool PU_Upgrade41Purchased;
    public bool PU_Upgrade42Purchased;
    public bool PU_Upgrade43Purchased;
    public bool PU_Upgrade44Purchased;
    public bool NP_Upgrade1Purchased;
    public bool NP_Upgrade2Purchased;
    public bool NP_Upgrade3Purchased;
    public bool NP_Upgrade4Purchased;
    public bool NP_Upgrade5Purchased;
    public bool NP_Upgrade6Purchased;
    public bool NP_Upgrade7Purchased;
    public bool NP_Upgrade8Purchased;
    public bool NP_Upgrade9Purchased;
    public bool NP_Upgrade10Purchased;
    public bool NP_Upgrade11Purchased;
    public bool NP_Upgrade12Purchased;
    public bool NP_Upgrade13Purchased;
    public bool NP_Upgrade14Purchased;
    public bool NP_Upgrade15Purchased;
    public bool NP_Upgrade16Purchased;
    public bool NP_Upgrade17Purchased;
    public bool NP_Upgrade18Purchased;
    public bool NP_Upgrade19Purchased;
    public bool NP_Upgrade20Purchased;
    public bool NP_Upgrade21Purchased;
    public bool NP_Upgrade22Purchased;
    public bool NP_Upgrade23Purchased;
    public bool NP_Upgrade24Purchased;
    public bool NP_Upgrade25Purchased;
    public bool NP_Upgrade26Purchased;
    public bool NP_Upgrade27Purchased;
    public bool NP_Upgrade28Purchased;
    public bool NP_Upgrade29Purchased;
    public bool NP_Upgrade30Purchased;
    public bool NP_Upgrade31Purchased;
    public bool NP_Upgrade32Purchased;
    public bool NP_Upgrade33Purchased;
    public bool NP_Upgrade34Purchased;
    public bool NP_Upgrade35Purchased;
    public bool A_Upgrade1Purchased;
    public bool A_Upgrade2Purchased;
    public bool A_Upgrade3Purchased;
    public bool A_Upgrade4Purchased;
    public bool A_Upgrade5Purchased;
    public bool A_Upgrade6Purchased;
    public bool A_Upgrade7Purchased;
    public bool A_Upgrade8Purchased;
    public bool A_Upgrade9Purchased;
    public bool A_Upgrade10Purchased;
    public bool A_Upgrade11Purchased;
    public bool A_Upgrade12Purchased;
    public bool A_Upgrade13Purchased;
    public bool A_Upgrade14Purchased;
    public bool A_Upgrade15Purchased;
    public bool A_Upgrade16Purchased;
    public bool A_Upgrade17Purchased;
    public bool A_Upgrade18Purchased;
    public bool A_Upgrade19Purchased;
    public bool A_Upgrade20Purchased;
    public bool A_Upgrade21Purchased;
    public bool A_Upgrade22Purchased;
    public bool A_Upgrade23Purchased;
    public bool A_Upgrade24Purchased;
    public bool A_Upgrade25Purchased;
    public bool A_Upgrade26Purchased;
    public bool A_Upgrade27Purchased;
    public bool A_Upgrade28Purchased;
    public bool A_Upgrade29Purchased;
    public bool A_Upgrade30Purchased;
    public bool A_Upgrade31Purchased;
    public bool A_Upgrade32Purchased;
    public bool A_Upgrade33Purchased;
    public bool moreShots1Purchased;
    public bool moreShots2Purchased;
    public bool moreShots3Purchased;
    public bool moreShots4Purchased;

    public float totalGoldClearBonus, totalTimerGoldClearBonus;
    public int prestigeClearHitsNeeded;
    public float prestigeBucketChance;
    public float rainbowPegChance, bombPegChance, purplePegChance, purplePegIncrease;
    public double startWithGold;
    public int extraPrestigePoints;
    public float goldFromShooting;
    public int totalBallShots;

    public void PrestigeSaves()
    {
        this.totalBallShots = 1;
        this.goldFromShooting = 0;
        this.extraPrestigePoints = 0;
        this.startWithGold = 0;
        this.purplePegIncrease = 0;
        this.purplePegChance = 0;
        this.bombPegChance = 0;
        this.rainbowPegChance = 0;
        this.prestigeBucketChance = 0;
        this.prestigeClearHitsNeeded = 0;
        this.totalGoldClearBonus = 0;
        this.totalTimerGoldClearBonus = 0;

        this.goldenPegChance = 9;
        this.prestigePegChance = 1;
        this.redPegChance = 0;

        this.prestigePoints = 0;

        this.levelSelected = 1;

        this.purchasedFirstUpgrade = false;

        this.purchasedLevel2 = false;

        this.isRedPegUnlocked = false;

        this.prestigeGoldIncrease = 0;
        this.activeGoldIncrease = 0;
        this.prestigePointsIncrease = 1;

        this.G_Upgrade1Purchased = false;
        this.G_Upgrade1Purchased = false;
        this.G_Upgrade2Purchased = false;
        this.G_Upgrade3Purchased = false;
        this.G_Upgrade4Purchased = false;
        this.G_Upgrade5Purchased = false;
        this.G_Upgrade6Purchased = false;
        this.G_Upgrade7Purchased = false;
        this.G_Upgrade8Purchased = false;
        this.G_Upgrade9Purchased = false;
        this.G_Upgrade10Purchased = false;
        this.G_Upgrade11Purchased = false;
        this.G_Upgrade12Purchased = false;
        this.G_Upgrade13Purchased = false;
        this.G_Upgrade14Purchased = false;
        this.G_Upgrade15Purchased = false;
        this.G_Upgrade16Purchased = false;
        this.G_Upgrade17Purchased = false;
        this.G_Upgrade18Purchased = false;
        this.G_Upgrade19Purchased = false;
        this.G_Upgrade20Purchased = false;
        this.G_Upgrade21Purchased = false;
        this.G_Upgrade22Purchased = false;
        this.G_Upgrade23Purchased = false;
        this.G_Upgrade24Purchased = false;
        this.G_Upgrade25Purchased = false;
        this.G_Upgrade26Purchased = false;
        this.G_Upgrade27Purchased = false;
        this.G_Upgrade28Purchased = false;
        this.G_Upgrade29Purchased = false;
        this.G_Upgrade30Purchased = false;
        this.G_Upgrade31Purchased = false;
        this.G_Upgrade32Purchased = false;
        this.G_Upgrade33Purchased = false;
        this.G_Upgrade34Purchased = false;
        this.G_Upgrade35Purchased = false;
        this.G_Upgrade36Purchased = false;
        this.G_Upgrade37Purchased = false;
        this.G_Upgrade38Purchased = false;
        this.G_Upgrade39Purchased = false;
        this.G_Upgrade40Purchased = false;
        this.G_Upgrade41Purchased = false;
        this.G_Upgrade42Purchased = false;
        this.G_Upgrade43Purchased = false;
        this.G_Upgrade44Purchased = false;
        this.G_Upgrade45Purchased = false;
        this.G_Upgrade46Purchased = false;
        this.G_Upgrade47Purchased = false;
        this.G_Upgrade48Purchased = false;
        this.G_Upgrade49Purchased = false;
        this.G_Upgrade50Purchased = false;
        this.G_Upgrade51Purchased = false;
       

        this.PU_Upgrade1Purchased = false;
        this.PU_Upgrade1Purchased = false;
        this.PU_Upgrade2Purchased = false;
        this.PU_Upgrade3Purchased = false;
        this.PU_Upgrade4Purchased = false;
        this.PU_Upgrade5Purchased = false;
        this.PU_Upgrade6Purchased = false;
        this.PU_Upgrade7Purchased = false;
        this.PU_Upgrade8Purchased = false;
        this.PU_Upgrade9Purchased = false;
        this.PU_Upgrade10Purchased = false;
        this.PU_Upgrade11Purchased = false;
        this.PU_Upgrade12Purchased = false;
        this.PU_Upgrade13Purchased = false;
        this.PU_Upgrade14Purchased = false;
        this.PU_Upgrade15Purchased = false;
        this.PU_Upgrade16Purchased = false;
        this.PU_Upgrade17Purchased = false;
        this.PU_Upgrade18Purchased = false;
        this.PU_Upgrade19Purchased = false;
        this.PU_Upgrade20Purchased = false;
        this.PU_Upgrade21Purchased = false;
        this.PU_Upgrade22Purchased = false;
        this.PU_Upgrade23Purchased = false;
        this.PU_Upgrade24Purchased = false;
        this.PU_Upgrade25Purchased = false;
        this.PU_Upgrade26Purchased = false;
        this.PU_Upgrade27Purchased = false;
        this.PU_Upgrade28Purchased = false;
        this.PU_Upgrade29Purchased = false;
        this.PU_Upgrade30Purchased = false;
        this.PU_Upgrade31Purchased = false;
        this.PU_Upgrade32Purchased = false;
        this.PU_Upgrade33Purchased = false;
        this.PU_Upgrade34Purchased = false;
        this.PU_Upgrade35Purchased = false;
        this.PU_Upgrade36Purchased = false;
        this.PU_Upgrade37Purchased = false;
        this.PU_Upgrade38Purchased = false;
        this.PU_Upgrade39Purchased = false;
        this.PU_Upgrade40Purchased = false;
        this.PU_Upgrade41Purchased = false;
        this.PU_Upgrade42Purchased = false;
        this.PU_Upgrade43Purchased = false;
        this.PU_Upgrade44Purchased = false;

        this.NP_Upgrade1Purchased = false;
        this.NP_Upgrade1Purchased = false;
        this.NP_Upgrade2Purchased = false;
        this.NP_Upgrade3Purchased = false;
        this.NP_Upgrade4Purchased = false;
        this.NP_Upgrade5Purchased = false;
        this.NP_Upgrade6Purchased = false;
        this.NP_Upgrade7Purchased = false;
        this.NP_Upgrade8Purchased = false;
        this.NP_Upgrade9Purchased = false;
        this.NP_Upgrade10Purchased = false;
        this.NP_Upgrade11Purchased = false;
        this.NP_Upgrade12Purchased = false;
        this.NP_Upgrade13Purchased = false;
        this.NP_Upgrade14Purchased = false;
        this.NP_Upgrade15Purchased = false;
        this.NP_Upgrade16Purchased = false;
        this.NP_Upgrade17Purchased = false;
        this.NP_Upgrade18Purchased = false;
        this.NP_Upgrade19Purchased = false;
        this.NP_Upgrade20Purchased = false;
        this.NP_Upgrade21Purchased = false;
        this.NP_Upgrade22Purchased = false;
        this.NP_Upgrade23Purchased = false;
        this.NP_Upgrade24Purchased = false;
        this.NP_Upgrade25Purchased = false;
        this.NP_Upgrade26Purchased = false;
        this.NP_Upgrade27Purchased = false;
        this.NP_Upgrade28Purchased = false;
        this.NP_Upgrade29Purchased = false;
        this.NP_Upgrade30Purchased = false;
        this.NP_Upgrade31Purchased = false;
        this.NP_Upgrade32Purchased = false;
        this.NP_Upgrade33Purchased = false;
        this.NP_Upgrade34Purchased = false;
        this.NP_Upgrade35Purchased = false;

        this.A_Upgrade1Purchased = false;
        this.A_Upgrade1Purchased = false;
        this.A_Upgrade2Purchased = false;
        this.A_Upgrade3Purchased = false;
        this.A_Upgrade4Purchased = false;
        this.A_Upgrade5Purchased = false;
        this.A_Upgrade6Purchased = false;
        this.A_Upgrade7Purchased = false;
        this.A_Upgrade8Purchased = false;
        this.A_Upgrade9Purchased = false;
        this.A_Upgrade10Purchased = false;
        this.A_Upgrade11Purchased = false;
        this.A_Upgrade12Purchased = false;
        this.A_Upgrade13Purchased = false;
        this.A_Upgrade14Purchased = false;
        this.A_Upgrade15Purchased = false;
        this.A_Upgrade16Purchased = false;
        this.A_Upgrade17Purchased = false;
        this.A_Upgrade18Purchased = false;
        this.A_Upgrade19Purchased = false;
        this.A_Upgrade20Purchased = false;
        this.A_Upgrade21Purchased = false;
        this.A_Upgrade22Purchased = false;
        this.A_Upgrade23Purchased = false;
        this.A_Upgrade24Purchased = false;
        this.A_Upgrade25Purchased = false;
        this.A_Upgrade26Purchased = false;
        this.A_Upgrade27Purchased = false;
        this.A_Upgrade28Purchased = false;
        this.A_Upgrade29Purchased = false;
        this.A_Upgrade30Purchased = false;
        this.A_Upgrade31Purchased = false;
        this.A_Upgrade32Purchased = false;
        this.A_Upgrade33Purchased = false;

        this.moreShots1Purchased = false;
        this.moreShots2Purchased = false;
        this.moreShots3Purchased = false;
        this.moreShots4Purchased = false;

        this.prestigePointsOverFlow = 0;
    }
    #endregion

    #region Challenges saves
    public bool[] challCompleted = new bool[37];
    public int ballsReachedMaxAuto;
    public int ballUpgradeLevel;
    public int redBallBounceCount, tinyBallsCount, basketBallPegHitCount, eggDoubleGoldCount, cookieBallExtraCount, goldenBallExtraCount, footballBucketCount, tinyRingBallsCount, prestigeGemsHit, starBallsSpawned, tinyGlitchyBallsSpawned, tinySharpnelCount, challengesCompleted;

    public void ChallengesSaves()
    {
        this.challengesCompleted = 0;
        this.ballsReachedMaxAuto = 0;
        this.ballUpgradeLevel = 0;
        this.redBallBounceCount = 0;
        this.tinyBallsCount = 0;
        this.basketBallPegHitCount = 0;
        this.eggDoubleGoldCount = 0;
        this.cookieBallExtraCount = 0;
        this.goldenBallExtraCount = 0;
        this.footballBucketCount = 0;
        this.tinyRingBallsCount = 0;
        this.prestigeGemsHit = 0;
        this.starBallsSpawned = 0;
        this.tinyGlitchyBallsSpawned = 0;
        this.tinySharpnelCount = 0;

        for (int i = 0; i < challCompleted.Length; i++)
        {
            this.challCompleted[i] = false;
        }
    }
    #endregion

    #region ACH saves
    public bool[] achCompleted = new bool[79];
    public bool[] newAchCompleted = new bool[5];
    public int achCount;

    public void ACHSaves()
    {
        this.achCount = 0;

        for (int i = 0; i < achCompleted.Length; i++)
        {
            this.achCompleted[i] = false;
        }

        for (int i = 0; i < newAchCompleted.Length; i++)
        {
            this.newAchCompleted[i] = false;
        }
    }
    #endregion

    public bool playedTutorial;
    public bool firstTimeClearBoard;
    public bool clickedOkFirstClear;

    public void TurotiralSaves()
    {
        this.playedTutorial = false;
        this.firstTimeClearBoard = false;
        this.clickedOkFirstClear = false;
    }
}
