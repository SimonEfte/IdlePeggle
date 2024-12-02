using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallUpgrades : MonoBehaviour, IDataPersistence
{
    public static double points;

    public static double regularBallGold, redBallGold, rockBallGold, bombBallGold, aquaBallGold, mudBallGold, basketBallGold, plumBallGold, stickyBallGold, candyBallGold, cookieBallGold, limeBallGold, goldenBallGold, footballBallGold, sharpnelBallGold, zonicBallGold, apricotBallGold, peggoBallGold, ghostBallGold, starBallGold, rainbowBallGold, glitchyBallGold;

    public TextMeshProUGUI totalPointsText;
    public TextMeshProUGUI ballBounceText;
    public TextMeshProUGUI ballEquippedPointsText, ballAutoDropTimeText;

    public TextMeshProUGUI ballsAviableText;

    public TextMeshProUGUI regularBallLevelText, redBallLevelText, rockBallLevelText, bombBallLevelText, aquaBallLevelText, mudBallLevelText, basketBallLevelText, plumBallLevelText, stickyBallLevelText, candyBallLevelText, cookieBallLevelText, limeBallLevelText, goldenBallLevelText, footballBallLevelText, sharpnelBallLevelText, zonicBallLevelText, apricotBallLevelText, peggoBallLevelText, ghostBallLevelText, starBallLevelText, rainbowBallLevelText, glitchyBallLevelText;

    public static int totalRegularBalls, totalRedBalls, totalRockBalls, totalBombBalls, totalAquaBalls, totalMudBalls, totalBasketBalls, totalPlumBalls, totalStickyBalls, totalCandyBalls, totalCookieBalls, totalLimeBalls, totalGoldenBalls, totalFootballBalls, totalSharpnelBalls, totalZonicBalls, totalApricotBalls, totalPeggoBalls, totalGhostBalls, totalStarBalls, totalRainbowBalls, totalGlitchyBalls;
    public static int ballNumber;

    public static double regularBallUpgradePrice, regularBallAutoPrice, regularBallPluss1Price;
    public static double redBallUpgradePrice, redBallAutoPrice, redBallPluss1Price;
    public static double rockBallUpgradePrice, rockBallAutoPrice, rockBallPluss1Price;
    public static double bombBallUpgradePrice, bombBallAutoPrice, bombBallPluss1Price;
    public static double aquaBallUpgradePrice, aquaBallAutoPrice, aquaBallPluss1Price;
    public static double mudBallUpgradePrice, mudBallAutoPrice, mudBallPluss1Price;
    public static double basketBallUpgradePrice, basketBallAutoPrice, basketBallPluss1Price;
    public static double plumBallUpgradePrice, plumBallAutoPrice, plumBallPluss1Price;
    public static double stickyBallUpgradePrice, stickyBallAutoPrice, stickyBallPluss1Price;

    public static double candyBallUpgradePrice, cookieBallUpgradePrice, limeBallUpgradePrice, goldenBallUpgradePrice, footballBallUpgradePrice, sharpnelBallUpgradePrice, zonicBallUpgradePrice, apricotBallUpgradePrice, peggoBallUpgradePrice, ghostBallUpgradePrice, starBallUpgradePrice, rainbowBallUpgradePrice, glitchyBallUpgradePrice;

    public static double candyBallAutoPrice, cookieBallAutoPrice, limeBallAutoPrice, goldenBallAutoPrice, footballBallAutoPrice, sharpnelBallAutoPrice, zonicBallAutoPrice, apricotBallAutoPrice, peggoBallAutoPrice, ghostBallAutoPrice, starBallAutoPrice, rainbowBallAutoPrice, glitchyBallAutoPrice;

    public static double candyBallPluss1Price, cookieBallPluss1Price, limeBallPluss1Price, goldenBallPluss1Price, footballBallPluss1Price, sharpnelBallPluss1Price, zonicBallPluss1Price, apricotBallPluss1Price, peggoBallPluss1Price, ghostBallPluss1Price, starBallPluss1Price, rainbowBallPluss1Price, glitchyBallPluss1Price;

    public TextMeshProUGUI bouncyBallPriceText, rockBallPriceText, bombBallPriceText, aquaBallPriceText, mudBallPriceText, basketBallPriceText, plumBallPriceText, stickyBallPriceText, candyBallPriceText, cookieBallPriceText, limeBallPriceText, goldenBallPriceText, footballBallPriceText, sharpnelBallPriceText, zonicBallPriceText, apricotBallPriceText, peggoBallPriceText, ghostBallPriceText, starBallPriceText, rainbowBallPriceText, glitchyBallPriceText;

    public float b1LessThan1, b1LessThan2, b2LessThan1, b2LessThan2, b3LessThan1, b3LessThan2, b4LessThan1, b4LessThan2;

    public AudioManager audioManager;

    public static bool firstTimePurchaseNewBall;
    public LocalizationStrings locScript;

    public static float bucketIncreaseSCALE, goldenPegIncreaseSCALE;

    public static float tinyBallPercent, tinyBallPercentTotal;

    public float autoPriceIncrease, goldPriceIncrease, ballPriceIcrease;

    public float minAutoDrop;
    public int allBallDivide;

    public double pointsIncrease;

    public static float totalGhostBallIncrease, totalRainbowBallIncrease;

    public void GivePointsBTN()
    {
        pointsIncrease *= 10;
        //Debug.Log(SetHighNumbers.FormatCoinsGoldShort(pointsIncrease));
        testignNumberText.text = SetHighNumbers.FormatCoinsGoldShort(pointsIncrease);
    }

    public void RemovePoints()
    {
        points = 0;
        Prestige.prestigePoints = 0;
    }
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public TextMeshProUGUI testignNumberText;

    public void Pluss1Mill()
    {
        points += pointsIncrease;
        Achievements.achCount += 5;
    }

    public void Pluss50PRestigePoints()
    {
        Prestige.prestigePoints += 50;
    }

    public void Plus1MPrestigePoints()
    {
        Prestige.prestigePoints += 100000000;
        AllStats.totalPRestigePoints += 100000000;

        //Prestige.prestigePoints += 125000000;
        //AllStats.totalPRestigePoints += 125000000;
    }

    public void MinusPP()
    {
        Prestige.prestigePoints -= 1000;
    }

    #region Awake And Start
    public static int stickyBallDoubleGoldChance, cookieDoubleChance;
    public static float basketBallBonus;

    public static int goldBallDoubleChance, goldBallTrippleChance, goldBall5XGold;
    public static float footBallBucketIncrease;
    public static int sharpnelChance1, sharpnelChance2;
    public static float smallSharpnelGold;
    public static int ringBallSpawnChance;
    public static float spawnedRingGold;
    public static float ghostBallGoldIncrease;
    public static int starBallPegsHitNeeded;
    public static float rainbowBallGoldIncrease;

    public void Awake()
    {
        X1UpgradeBTN.interactable = false;
        OriginalBallBuffs();
    }

    public void OriginalBallBuffs()
    {
        rainbowBallGoldIncrease = 0.02f;

        starBallPegsHitNeeded = 10;

        ghostBallGoldIncrease = 0.05f;

        ringBallSpawnChance = 45;
        spawnedRingGold = 0.15f;

        sharpnelChance1 = 18;
        sharpnelChance2 = 7;
        smallSharpnelGold = 0.35f;

        footBallBucketIncrease = 1.15f;

        goldBallDoubleChance = 5;
        goldBallTrippleChance = 3;
        goldBall5XGold = 1;

        cookieDoubleChance = 50;

        stickyBallDoubleGoldChance = 20;

        tinyBallPercent = 0.3f;
        tinyBallPercentTotal = 1 * 0.3f;

        basketBallBonus = 0.03f;
    }

    public int timesAutoPurchasedCount;
    public int goldIncreaseLevel, ballReachLevel;
    public void Start()
    {
        ballReachLevel = 30;
        goldIncreaseLevel = 20;

        regularBallAutoDivide = 15;
        redBallAutoDivide = 15;
        rockBallDivide = 15;
        bombBallDivide = 15;

        allBallDivide = 15;

        minAutoDrop = 0.2f;

        float starAutoTime = 3;
        int count = 0;

        while (starAutoTime > minAutoDrop)
        {
            starAutoTime -= (starAutoTime / allBallDivide);
            count++;
        }

        timesAutoPurchasedCount = count + 1;

        pointsIncrease = 100000;

        goldPriceIncrease = 1.15f;
        autoPriceIncrease = 1.4f;
        ballPriceIcrease = 3f;

        StartCoroutine(waititng());
        StartCoroutine(SetOriginalPrices());
    }
    #endregion

    IEnumerator waititng()
    {
        yield return new WaitForSeconds(0.09f);
        SetTextSpawnChance(false, false);
        CheckPurchasesBalls();
    }

    #region Set load all
    IEnumerator SetOriginalPrices()
    {
        yield return new WaitForSeconds(0.3f);

        //Remeber to remove this
        //basketBallPrice = GameData.ORIGINALbasketBallPrice;
        //basketBallAutoPrice = GameData.ORIGINALbasketBallAutoPrice;
        //basketBallUpgradePrice = GameData.ORIGINALbasketBallUpgradePrice;
        //basketBallPluss1Price = GameData.ORIGINALbasketBallPluss1Price;
        //aquaBallGold = GameData.ORIGINALaquaBallGold;
        //mudBallGold = GameData.ORIGINALmudBallGold;
        //basketBallGold = GameData.ORIGINALbasketBallGold;
        //plumBallGold = GameData.ORIGINALplumBallGold;
        //stickyBallGold = GameData.ORIGINALstickyBallGold;
        //candyBallGold = GameData.ORIGINALcandyBallGold;
        //cookieBallGold = GameData.ORIGINALcookieBallGold;
        //limeBallGold = GameData.ORIGINALlimeBallGold;
        //goldenBallGold = GameData.ORIGINALgoldenBallGold;
        //footballBallGold = GameData.ORIGINALfootballBallGold;
        //sharpnelBallGold = GameData.ORIGINALsharpnelBallGold;
        //zonicBallGold = GameData.ORIGINALzonicBallGold;
        //apricotBallGold = GameData.ORIGINALapricotBallGold;
        //peggoBallGold = GameData.ORIGINALpeggoBallGold;
        // ghostBallGold = GameData.ORIGINALghostBallGold;
        // starBallGold = GameData.ORIGINALstarBallGold;
        // rainbowBallGold = GameData.ORIGINALrainbowBallGold;
        // glitchyBallGold = GameData.ORIGINALglitchyBallGold;

        gameLoadedIn = false;

        #region All LESS THAN
        b1LessThan1 = 7;
        b1LessThan2 = 15;

        b2LessThan1 = 20;
        b2LessThan2 = 35;

        b3LessThan1 = 5;
        b3LessThan2 = 10;

        b4LessThan1 = 8;
        b4LessThan2 = 17;
        #endregion

        #region Set Price text
        pitPriceText.text = SetHighNumbers.FormatCoinsGoldShort(bucketPrice);
        goldenPegsPriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenPegsPrice);

        bouncyBallPriceText.text = GameData.ORIGINALbouncyBallPrice.ToString("F0");
        rockBallPriceText.text = GameData.ORIGINALrockBallPrice.ToString("F0");
        bombBallPriceText.text = GameData.ORIGINALbombBallPrice.ToString("F0");

        //Full game
        if(GameData.isDemo == false)
        {
            aquaBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALaquaBallPrice);
            mudBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALmudBallPrice);
            basketBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALbasketBallPrice);
            plumBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALplumBallPrice);
            stickyBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALstickyBallPrice);
            candyBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALcandyBallPrice);
            cookieBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALcookieBallPrice);
            limeBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALlimeBallPrice);
            goldenBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALgoldenBallPrice);
            footballBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALfootballBallPrice);
            sharpnelBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALsharpnelBallPrice);
            zonicBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALzonicBallPrice);
            apricotBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALapricotBallPrice);
            peggoBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALpeggoBallPrice);
            ghostBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALghostBallPrice);
            starBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALstarBallPrice);
            rainbowBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALrainbowBallPrice);
            glitchyBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(GameData.ORIGINALglitchyBallPrice);
        }
        #endregion


        #region Bucket And Hold Increase
        bucketIncreaseSCALE = 0.02f;
        goldenPegIncreaseSCALE = 0.02f;
        if(Challenges.challCompleted[17] == true) { goldenPegIncreaseSCALE = 0.03f; }
        if (Challenges.challCompleted[18] == true) { goldenPegIncreaseSCALE = 0.04f; }
        if (Challenges.challCompleted[19] == true) { goldenPegIncreaseSCALE = 0.05f; }

        if (Challenges.challCompleted[20] == true) { bucketIncreaseSCALE = 0.03f; }
        if (Challenges.challCompleted[21] == true) { bucketIncreaseSCALE = 0.04f; }
        if (Challenges.challCompleted[22] == true) { bucketIncreaseSCALE = 0.05f; }

        if (bucketIncrease % 1 == 0) 
        {
            bucketIncreaseText.text = "<color=yellow>" + bucketIncrease.ToString("F0") + "X" + "(+" + bucketIncreaseSCALE + "X)";
        }
        else
        {
            bucketIncreaseText.text = "<color=yellow>" + bucketIncrease.ToString("F2") + "X" + "(+" + bucketIncreaseSCALE + "X)";
        }


        if (goldenPegsIncrease % 1 == 0)
        {
            goldenPegsIncreaseText.text = "<color=yellow>" + goldenPegsIncrease.ToString("F0") + "X" + "(+" + goldenPegIncreaseSCALE + "X)";
        }
        else
        {
            goldenPegsIncreaseText.text = "<color=yellow>" + goldenPegsIncrease.ToString("F2") + "X" + "(+" + goldenPegIncreaseSCALE + "X)";
        }
        #endregion

        #region Check Current Ball Equipped
        if (ballNumberEquipped == 1) { MainShooter.basicBallsAvailable = totalRegularBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 1; }
        else if (ballNumberEquipped == 2) { MainShooter.redBallsAviable = totalRedBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 2; }
        else if (ballNumberEquipped == 3) { MainShooter.rockBallsAviable = totalRockBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 3; }
        else if (ballNumberEquipped == 4) { MainShooter.bombBallsAviable = totalBombBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 4; }

        //Full game
        if(GameData.isDemo == false)
        {
            if (ballNumberEquipped == 5) { MainShooter.aquaBallsAvailable = totalAquaBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 5; }
            else if (ballNumberEquipped == 6) { MainShooter.mudBallsAvailable = totalMudBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 6; }
            else if (ballNumberEquipped == 7) { MainShooter.basketBallsAvailable = totalBasketBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 7; }
            else if (ballNumberEquipped == 8) { MainShooter.plumBallsAvailable = totalPlumBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 8; }
            else if (ballNumberEquipped == 9) { MainShooter.stickyBallsAvailable = totalStickyBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 9; }
            else if (ballNumberEquipped == 10) { MainShooter.candyBallsAvailable = totalCandyBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 10; }
            else if (ballNumberEquipped == 11) { MainShooter.cookieBallsAvailable = totalCookieBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 11; }
            else if (ballNumberEquipped == 12) { MainShooter.limeBallsAvailable = totalLimeBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 12; }
            else if (ballNumberEquipped == 13) { MainShooter.goldenBallsAvailable = totalGoldenBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 13; }
            else if (ballNumberEquipped == 14) { MainShooter.footballBallsAvailable = totalFootballBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 14; }
            else if (ballNumberEquipped == 15) { MainShooter.sharpnelBallsAvailable = totalSharpnelBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 15; }
            else if (ballNumberEquipped == 16) { MainShooter.zonicBallsAvailable = totalZonicBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 16; }
            else if (ballNumberEquipped == 17) { MainShooter.apricotBallsAvailable = totalApricotBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 17; }
            else if (ballNumberEquipped == 18) { MainShooter.peggoBallsAvailable = totalPeggoBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 18; }
            else if (ballNumberEquipped == 19) { MainShooter.ghostBallsAvailable = totalGhostBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 19; }
            else if (ballNumberEquipped == 20) { MainShooter.starBallsAvailable = totalStarBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 20; }
            else if (ballNumberEquipped == 21) { MainShooter.rainbowBallsAvailable = totalRainbowBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 21; }
            else if (ballNumberEquipped == 22) { MainShooter.glitchyBallsAvailable = totalGlitchyBalls; SetActiveBalls(MainShooter.basicBallsAvailable); ballNumber = 22; }
        }

        #endregion


        #region Check Auto Drop
        if (isRegularBallAutoPurchased == true) { mainShooterScript.Auto1(); }
        if (isRedBallAutoPurchased == true) { mainShooterScript.Auto2(); }
        if (isRockBallAutoPurchased == true) { mainShooterScript.Auto3(); }
        if (isBombBallAutoPurchased == true) { mainShooterScript.Auto4(); }

        //Full game
        if(GameData.isDemo == false)
        {
            if (isAquaBallAutoPurchased == true) { mainShooterScript.Auto5(); }
            if (isMudBallAutoPurchased == true) { mainShooterScript.Auto6(); }
            if (isBasketBallAutoPurchased == true) { mainShooterScript.Auto7(); }
            if (isPlumBallAutoPurchased == true) { mainShooterScript.Auto8(); }
            if (isStickyBallAutoPurchased == true) { mainShooterScript.Auto9(); }
            if (isCandyBallAutoPurchased == true) { mainShooterScript.Auto10(); }
            if (isCookieBallAutoPurchased == true) { mainShooterScript.Auto11(); }
            if (isLimeBallAutoPurchased == true) { mainShooterScript.Auto12(); }
            if (isGoldenBallAutoPurchased == true) { mainShooterScript.Auto13(); }
            if (isFootballBallAutoPurchased == true) { mainShooterScript.Auto14(); }
            if (isSharpnelBallAutoPurchased == true) { mainShooterScript.Auto15(); }
            if (isZonicBallAutoPurchased == true) { mainShooterScript.Auto16(); }
            if (isApricotBallAutoPurchased == true) { mainShooterScript.Auto17(); }
            if (isPeggoBallAutoPurchased == true) { mainShooterScript.Auto18(); }
            if (isGhostBallAutoPurchased == true) { mainShooterScript.Auto19(); }
            if (isStarBallAutoPurchased == true) { mainShooterScript.Auto20(); }
            if (isRainbowBallAutoPurchased == true) { mainShooterScript.Auto21(); }
            if (isGlitchyBallAutoPurchased == true) { mainShooterScript.Auto22(); }
        }
        #endregion

        EquipBall(false);

        gameLoadedIn = true;

        #region Level Texts
        regularBallLevelText.text = regularBallLevel.ToString();
        redBallLevelText.text = redBallLevel.ToString();
        rockBallLevelText.text = rockBallLevel.ToString();
        bombBallLevelText.text = bombBallLevel.ToString();

        //Full game
        if(GameData.isDemo == false)
        {
            aquaBallLevelText.text = aquaBallLevel.ToString();
            mudBallLevelText.text = mudBallLevel.ToString();
            basketBallLevelText.text = basketBallLevel.ToString();
            plumBallLevelText.text = plumBallLevel.ToString();
            stickyBallLevelText.text = stickyBallLevel.ToString();
            candyBallLevelText.text = candyBallLevel.ToString();
            cookieBallLevelText.text = cookieBallLevel.ToString();
            limeBallLevelText.text = limeBallLevel.ToString();
            goldenBallLevelText.text = goldenBallLevel.ToString();
            footballBallLevelText.text = footballBallLevel.ToString();
            sharpnelBallLevelText.text = sharpnelBallLevel.ToString();
            zonicBallLevelText.text = zonicBallLevel.ToString();
            apricotBallLevelText.text = apricotBallLevel.ToString();
            peggoBallLevelText.text = peggoBallLevel.ToString();
            ghostBallLevelText.text = ghostBallLevel.ToString();
            starBallLevelText.text = starBallLevel.ToString();
            rainbowBallLevelText.text = rainbowBallLevel.ToString();
            glitchyBallLevelText.text = glitchyBallLevel.ToString();
        }
        #endregion

        #region All Ball GOLD Increment
        regularBallGoldIncrement = 1;

        bouncyBallGoldIncrement = GameData.ORIGINALRedBallGold / 4f;
        rockBallGoldIncrement = GameData.ORIGINALRockBallGold / 5.5f;
        bombBallGoldIncrement = GameData.ORIGINALBombBallGold / 6.5f;
        aquaBallGoldIncrement = GameData.ORIGINALaquaBallGold / 9f;
        mudBallGoldIncrement = GameData.ORIGINALmudBallGold / 11f;
        basketBallGoldIncrement = GameData.ORIGINALbasketBallGold / 12.5f;
        plumBallGoldIncrement = GameData.ORIGINALplumBallGold / 13.5f;
        stickyBallGoldIncrement = GameData.ORIGINALstickyBallGold / 15f;
        candyBallGoldIncrement = GameData.ORIGINALcandyBallGold / 16f;
        cookieBallGoldIncrement = GameData.ORIGINALcookieBallGold / 18.5f;
        limeBallGoldIncrement = GameData.ORIGINALlimeBallGold / 23f;
        goldenBallGoldIncrement = GameData.ORIGINALgoldenBallGold / 26f;
        footballBallGoldIncrement = GameData.ORIGINALfootballBallGold / 30f;
        sharpnelBallGoldIncrement = GameData.ORIGINALsharpnelBallGold / 36f;
        zonicBallGoldIncrement = GameData.ORIGINALzonicBallGold / 41f;
        apricotBallGoldIncrement = GameData.ORIGINALapricotBallGold / 47f;
        peggoBallGoldIncrement = GameData.ORIGINALpeggoBallGold / 55f;
        ghostBallGoldIncrement = GameData.ORIGINALghostBallGold / 67f;
        starBallGoldIncrement = GameData.ORIGINALstarBallGold / 77f;
        rainbowBallGoldIncrement = GameData.ORIGINALrainbowBallGold / 95f;
        glitchyBallGoldIncrement = GameData.ORIGINALglitchyBallGold / 130f;
        #endregion

        //500T
        // limeBallGold += ((limeBallLevel - 1) * limeBallGoldIncrement);

        if (isBall1AutoTurnedOff == true) { FrameColor(0, true); }
        if (isBall2AutoTurnedOff == true) { FrameColor(1, true); }
        if (isBall3AutoTurnedOff == true) { FrameColor(2, true); }
        if (isBall4AutoTurnedOff == true) { FrameColor(3, true); }
        if (isBall5AutoTurnedOff == true) { FrameColor(4, true); }
        if (isBall6AutoTurnedOff == true) { FrameColor(5, true); }
        if (isBall7AutoTurnedOff == true) { FrameColor(6, true); }
        if (isBall8AutoTurnedOff == true) { FrameColor(7, true); }
        if (isBall9AutoTurnedOff == true) { FrameColor(8, true); }
        if (isBall10AutoTurnedOff == true) { FrameColor(9, true); }
        if (isBall11AutoTurnedOff == true) { FrameColor(10, true); }
        if (isBall12AutoTurnedOff == true) { FrameColor(11, true); }
        if (isBall13AutoTurnedOff == true) { FrameColor(12, true); }
        if (isBall14AutoTurnedOff == true) { FrameColor(13, true); }
        if (isBall15AutoTurnedOff == true) { FrameColor(14, true); }
        if (isBall16AutoTurnedOff == true) { FrameColor(15, true); }
        if (isBall17AutoTurnedOff == true) { FrameColor(16, true); }
        if (isBall18AutoTurnedOff == true) { FrameColor(17, true); }
        if (isBall19AutoTurnedOff == true) { FrameColor(18, true); }
        if (isBall20AutoTurnedOff == true) { FrameColor(19, true); }
        if (isBall21AutoTurnedOff == true) { FrameColor(20, true); }
        if (isBall22AutoTurnedOff == true) { FrameColor(21, true); }

    }
    #endregion

    #region Check purchased balls
    public void CheckPurchasesBalls()
    {
        if(bouncyBallPurchased == true)
        {
            bouncyBallButton.interactable = true;
            ball2UnlockedFrame.SetActive(true);
            ball2PriceLockedFrame.SetActive(false);
            ball3PriceLockedFrame.SetActive(true);
            ball3LockFrame.SetActive(false);
            ballsPurchased += 1;
        }

        if (rockBallPurchased == true)
        {
            rockBallButton.interactable = true;
            ball3UnlockedFrame.SetActive(true);
            ball3PriceLockedFrame.SetActive(false);
            ball4PriceLockedFrame.SetActive(true);
            ball4LockFrame.SetActive(false);
            ballsPurchased += 1;
        }

        if (bombBallPurchased == true)
        {
            bombBallButton.interactable = true;
            ball4UnlockedFrame.SetActive(true);
            ball4PriceLockedFrame.SetActive(false);
            if(GameData.isDemo == false)
            {
                ball5PriceLockedFrame.SetActive(true);
                ball5LockFrame.SetActive(false);
            }
            ballsPurchased += 1;
        }

        if (GameData.isDemo == false)
        {
            if (aquaBallPurchased == true)
            {
                aquaBallButton.interactable = true;
                ball5UnlockedFrame.SetActive(true);
                ball5PriceLockedFrame.SetActive(false);
                ball6PriceLockedFrame.SetActive(true);
                ball6LockFrame.SetActive(false);
                ballsPurchased += 1;
            }

            if (mudBallPurchased == true)
            {
                mudBallButton.interactable = true;
                ball6UnlockedFrame.SetActive(true);
                ball6PriceLockedFrame.SetActive(false);
                ball7PriceLockedFrame.SetActive(true);
                ball7LockFrame.SetActive(false);
                ballsPurchased += 1;
            }

            if (basketBallPurchased == true)
            {
                basketBallButton.interactable = true;
                ball7UnlockedFrame.SetActive(true);
                ball7PriceLockedFrame.SetActive(false);
                ball8PriceLockedFrame.SetActive(true);
                ball8LockFrame.SetActive(false);
                ballsPurchased += 1;
            }

            if (plumBallPurchased == true)
            {
                plumBallButton.interactable = true;
                ball8UnlockedFrame.SetActive(true);
                ball8PriceLockedFrame.SetActive(false);
                ball9PriceLockedFrame.SetActive(true);
                ball9LockFrame.SetActive(false);
                ballsPurchased += 1;
            }

            if (stickyBallPurchased == true)
            {
                stickyBallButton.interactable = true;
                ball9UnlockedFrame.SetActive(true);
                ball9PriceLockedFrame.SetActive(false);
                ball10PriceLockedFrame.SetActive(true);
                ball10LockFrame.SetActive(false);
                ballsPurchased += 1;
            }
            if (candyBallPurchased)
            {
                candyBallButton.interactable = true;
                ball10UnlockedFrame.SetActive(true);
                ball10PriceLockedFrame.SetActive(false);
                ball11PriceLockedFrame.SetActive(true);
                ball11LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (cookieBallPurchased)
            {
                cookieBallButton.interactable = true;
                ball11UnlockedFrame.SetActive(true);
                ball11PriceLockedFrame.SetActive(false);
                ball12PriceLockedFrame.SetActive(true);
                ball12LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (limeBallPurchased)
            {
                limeBallButton.interactable = true;
                ball12UnlockedFrame.SetActive(true);
                ball12PriceLockedFrame.SetActive(false);
                ball13PriceLockedFrame.SetActive(true);
                ball13LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (goldenBallPurchased)
            {
                goldenBallButton.interactable = true;
                ball13UnlockedFrame.SetActive(true);
                ball13PriceLockedFrame.SetActive(false);
                ball14PriceLockedFrame.SetActive(true);
                ball14LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (footballBallPurchased)
            {
                footballBallButton.interactable = true;
                ball14UnlockedFrame.SetActive(true);
                ball14PriceLockedFrame.SetActive(false);
                ball15PriceLockedFrame.SetActive(true);
                ball15LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (sharpnelBallPurchased)
            {
                sharpnelBallButton.interactable = true;
                ball15UnlockedFrame.SetActive(true);
                ball15PriceLockedFrame.SetActive(false);
                ball16PriceLockedFrame.SetActive(true);
                ball16LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (zonicBallPurchased)
            {
                zonicBallButton.interactable = true;
                ball16UnlockedFrame.SetActive(true);
                ball16PriceLockedFrame.SetActive(false);
                ball17PriceLockedFrame.SetActive(true);
                ball17LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (apricotBallPurchased)
            {
                apricotBallButton.interactable = true;
                ball17UnlockedFrame.SetActive(true);
                ball17PriceLockedFrame.SetActive(false);
                ball18PriceLockedFrame.SetActive(true);
                ball18LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (peggoBallPurchased)
            {
                peggoBallButton.interactable = true;
                ball18UnlockedFrame.SetActive(true);
                ball18PriceLockedFrame.SetActive(false);
                ball19PriceLockedFrame.SetActive(true);
                ball19LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (ghostBallPurchased)
            {
                ghostBallButton.interactable = true;
                ball19UnlockedFrame.SetActive(true);
                ball19PriceLockedFrame.SetActive(false);
                ball20PriceLockedFrame.SetActive(true);
                ball20LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (starBallPurchased)
            {
                starBallButton.interactable = true;
                ball20UnlockedFrame.SetActive(true);
                ball20PriceLockedFrame.SetActive(false);
                ball21PriceLockedFrame.SetActive(true);
                ball21LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (rainbowBallPurchased)
            {
                rainbowBallButton.interactable = true;
                ball21UnlockedFrame.SetActive(true);
                ball21PriceLockedFrame.SetActive(false);
                ball22PriceLockedFrame.SetActive(true);
                ball22LockFrame.SetActive(false); ballsPurchased += 1;
            }

            if (glitchyBallPurchased)
            {
                glitchyBallButton.interactable = true;
                ball22UnlockedFrame.SetActive(true);
                ball22PriceLockedFrame.SetActive(false); ballsPurchased += 1;
            }

        }
    }
    #endregion

    public GameObject ballUpgradeFrame;

    public TextMeshProUGUI pitPriceText, goldenPegsPriceText;

    #region Chec Input
    public void CheckInput()
    {
        //if(openedBallFrame == true) { return; }
        if(Prestige.isInPrestigeScreen == true) { return; }

        if (isInBallScreen1 == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { ballNumber = 1; EquipBall(true); }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) { if (bouncyBallPurchased == true) { ballNumber = 2; EquipBall(true); } }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) { if (rockBallPurchased == true) { ballNumber = 3; EquipBall(true); } }
            else if (Input.GetKeyDown(KeyCode.Alpha4)) { if (bombBallPurchased == true) { ballNumber = 4; EquipBall(true); } }
            if (GameData.isDemo == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha5)) { if (aquaBallPurchased == true) { ballNumber = 5; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha6)) { if (mudBallPurchased == true) { ballNumber = 6; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha7)) { if (basketBallPurchased == true) { ballNumber = 7; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha8)) { if (plumBallPurchased == true) { ballNumber = 8; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha9)) { if (stickyBallPurchased == true) { ballNumber = 9; EquipBall(true); } }
            }
        }

        if (GameData.isDemo == false)
        {
            if(isInBallScreen2 == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) { if (candyBallPurchased == true) { ballNumber = 10; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha2)) { if (cookieBallPurchased == true) { ballNumber = 11; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha3)) { if (limeBallPurchased == true) { ballNumber = 12; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha4)) { if (goldenBallPurchased == true) { ballNumber = 13; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha5)) { if (footballBallPurchased == true) { ballNumber = 14; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha6)) { if (sharpnelBallPurchased == true) { ballNumber = 15; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha7)) { if (zonicBallPurchased == true) { ballNumber = 16; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha8)) { if (apricotBallPurchased == true) { ballNumber = 17; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha9)) { if (peggoBallPurchased == true) { ballNumber = 18; EquipBall(true); } }
            }
            if (isInBallScreen3 == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) { if (ghostBallPurchased == true) { ballNumber = 19; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha2)) { if (starBallPurchased == true) { ballNumber = 20; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha3)) { if (rainbowBallPurchased == true) { ballNumber = 21; EquipBall(true); } }
                else if (Input.GetKeyDown(KeyCode.Alpha4)) { if (glitchyBallPurchased == true) { ballNumber = 22; EquipBall(true); } }
            }
          
        }
    }
    #endregion

    public bool isKeyPressed;

    public TextMeshProUGUI maxUpgradeX, maxAutoX, maxPluss1X, maxBucketPluss, maxGoldenPEgPluss;
    public TextMeshProUGUI maxUpgradePriceText;

    public GameObject xFramesBallUpgrades, xFramesBandPupgrades;

    //goldPriceIncrease = 1.15f;
    //autoPriceIncrease = 1.4f;
    //ballPriceIcrease = 3f;

    public double totalUpgradePrice, totalAutoUpgradePrice, totalPluss1BallUpgradePrice, totalBucketUpgradePrice, totalGoldenPegsUpgradePrice;

    #region Calculate max upgrade
    public void CalculateMaxUpgrade()
    {
        if (currentBallFrame == 0) { }
        else
        {
            double remainingPoints = points;
            double upgradePrice = 0;
            maxUpgradeCount = 0;

            if (currentBallFrame == 1) { upgradePrice = regularBallUpgradePrice; totalUpgradePrice = regularBallUpgradePrice; }
            else if (currentBallFrame == 2) { upgradePrice = redBallUpgradePrice; totalUpgradePrice = redBallUpgradePrice; }
            else if (currentBallFrame == 3) { upgradePrice = rockBallUpgradePrice; totalUpgradePrice = rockBallUpgradePrice; }
            else if (currentBallFrame == 4) { upgradePrice = bombBallUpgradePrice; totalUpgradePrice = bombBallUpgradePrice; }
            else if (currentBallFrame == 5) { upgradePrice = aquaBallUpgradePrice; totalUpgradePrice = aquaBallUpgradePrice; }
            else if (currentBallFrame == 6) { upgradePrice = mudBallUpgradePrice; totalUpgradePrice = mudBallUpgradePrice; }
            else if (currentBallFrame == 7) { upgradePrice = basketBallUpgradePrice; totalUpgradePrice = basketBallUpgradePrice; }
            else if (currentBallFrame == 8) { upgradePrice = plumBallUpgradePrice; totalUpgradePrice = plumBallUpgradePrice; }
            else if (currentBallFrame == 9) { upgradePrice = stickyBallUpgradePrice; totalUpgradePrice = stickyBallUpgradePrice; }
            else if (currentBallFrame == 10) { upgradePrice = candyBallUpgradePrice; totalUpgradePrice = candyBallUpgradePrice; }
            else if (currentBallFrame == 11) { upgradePrice = cookieBallUpgradePrice; totalUpgradePrice = cookieBallUpgradePrice; }
            else if (currentBallFrame == 12) { upgradePrice = limeBallUpgradePrice; totalUpgradePrice = limeBallUpgradePrice; }
            else if (currentBallFrame == 13) { upgradePrice = goldenBallUpgradePrice; totalUpgradePrice = goldenBallUpgradePrice; }
            else if (currentBallFrame == 14) { upgradePrice = footballBallUpgradePrice; totalUpgradePrice = footballBallUpgradePrice; }
            else if (currentBallFrame == 15) { upgradePrice = sharpnelBallUpgradePrice; totalUpgradePrice = sharpnelBallUpgradePrice; }
            else if (currentBallFrame == 16) { upgradePrice = zonicBallUpgradePrice; totalUpgradePrice = zonicBallUpgradePrice; }
            else if (currentBallFrame == 17) { upgradePrice = apricotBallUpgradePrice; totalUpgradePrice = apricotBallUpgradePrice; }
            else if (currentBallFrame == 18) { upgradePrice = peggoBallUpgradePrice; totalUpgradePrice = peggoBallUpgradePrice; }
            else if (currentBallFrame == 19) { upgradePrice = ghostBallUpgradePrice; totalUpgradePrice = ghostBallUpgradePrice; }
            else if (currentBallFrame == 20) { upgradePrice = starBallUpgradePrice; totalUpgradePrice = starBallUpgradePrice; }
            else if (currentBallFrame == 21) { upgradePrice = rainbowBallUpgradePrice; totalUpgradePrice = rainbowBallUpgradePrice; }
            else if (currentBallFrame == 22) { upgradePrice = glitchyBallUpgradePrice; totalUpgradePrice = glitchyBallUpgradePrice; }


            while (remainingPoints >= upgradePrice)
            {
                remainingPoints -= upgradePrice;
                upgradePrice *= goldPriceIncrease;
                maxUpgradeCount++;
            }

            double total = 0;
            int count = 0;

            while (count < maxUpgradeCount)
            {
                count += 1;

                total += totalUpgradePrice;

                totalUpgradePrice *= goldPriceIncrease;
                RoundToNearestWhole(totalUpgradePrice);
                totalUpgradePrice = currentDouble;
            }

            if (maxUpgradeCount > 1) { ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(total); }
            maxUpgradeX.text = "X" + maxUpgradeCount.ToString("F0");
        }
    }

    public void SetNormal1XBallUpgrade()
    {
        double upgradePrice = 0;
        if (currentBallFrame == 1) { upgradePrice = regularBallUpgradePrice;  }
        else if (currentBallFrame == 2) { upgradePrice = redBallUpgradePrice;  }
        else if (currentBallFrame == 3) { upgradePrice = rockBallUpgradePrice;  }
        else if (currentBallFrame == 4) { upgradePrice = bombBallUpgradePrice; }
        else if (currentBallFrame == 5) { upgradePrice = aquaBallUpgradePrice;  }
        else if (currentBallFrame == 6) { upgradePrice = mudBallUpgradePrice;  }
        else if (currentBallFrame == 7) { upgradePrice = basketBallUpgradePrice;  }
        else if (currentBallFrame == 8) { upgradePrice = plumBallUpgradePrice;  }
        else if (currentBallFrame == 9) { upgradePrice = stickyBallUpgradePrice;  }
        else if (currentBallFrame == 10) { upgradePrice = candyBallUpgradePrice;  }
        else if (currentBallFrame == 11) { upgradePrice = cookieBallUpgradePrice;  }
        else if (currentBallFrame == 12) { upgradePrice = limeBallUpgradePrice;  }
        else if (currentBallFrame == 13) { upgradePrice = goldenBallUpgradePrice;  }
        else if (currentBallFrame == 14) { upgradePrice = footballBallUpgradePrice;  }
        else if (currentBallFrame == 15) { upgradePrice = sharpnelBallUpgradePrice;  }
        else if (currentBallFrame == 16) { upgradePrice = zonicBallUpgradePrice;  }
        else if (currentBallFrame == 17) { upgradePrice = apricotBallUpgradePrice;  }
        else if (currentBallFrame == 18) { upgradePrice = peggoBallUpgradePrice;  }
        else if (currentBallFrame == 19) { upgradePrice = ghostBallUpgradePrice;  }
        else if (currentBallFrame == 20) { upgradePrice = starBallUpgradePrice; }
        else if (currentBallFrame == 21) { upgradePrice = rainbowBallUpgradePrice;  }
        else if (currentBallFrame == 22) { upgradePrice = glitchyBallUpgradePrice;  }

       ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(upgradePrice);
    }

    #endregion

    #region Calculate max auto upgrade

    public void CalculateMaxAutoUpgrade()
    {
        if (currentBallFrame == 0) { }
        else
        {
            double remainingPoints = points;
            double upgradePrice = 0;
            maxAutoUpgradeCount = 0;

            if (currentBallFrame == 1) { upgradePrice = regularBallAutoPrice; totalAutoUpgradePrice = regularBallAutoPrice; }
            else if (currentBallFrame == 2) { upgradePrice = redBallAutoPrice; totalAutoUpgradePrice = redBallAutoPrice; }
            else if (currentBallFrame == 3) { upgradePrice = rockBallAutoPrice; totalAutoUpgradePrice = rockBallAutoPrice; }
            else if (currentBallFrame == 4) { upgradePrice = bombBallAutoPrice; totalAutoUpgradePrice = bombBallAutoPrice; }
            else if (currentBallFrame == 5) { upgradePrice = aquaBallAutoPrice; totalAutoUpgradePrice = aquaBallAutoPrice; }
            else if (currentBallFrame == 6) { upgradePrice = mudBallAutoPrice; totalAutoUpgradePrice = mudBallAutoPrice; }
            else if (currentBallFrame == 7) { upgradePrice = basketBallAutoPrice; totalAutoUpgradePrice = basketBallAutoPrice; }
            else if (currentBallFrame == 8) { upgradePrice = plumBallAutoPrice; totalAutoUpgradePrice = plumBallAutoPrice; }
            else if (currentBallFrame == 9) { upgradePrice = stickyBallAutoPrice; totalAutoUpgradePrice = stickyBallAutoPrice; }
            else if (currentBallFrame == 10) { upgradePrice = candyBallAutoPrice; totalAutoUpgradePrice = candyBallAutoPrice; }
            else if (currentBallFrame == 11) { upgradePrice = cookieBallAutoPrice; totalAutoUpgradePrice = cookieBallAutoPrice; }
            else if (currentBallFrame == 12) { upgradePrice = limeBallAutoPrice; totalAutoUpgradePrice = limeBallAutoPrice; }
            else if (currentBallFrame == 13) { upgradePrice = goldenBallAutoPrice; totalAutoUpgradePrice = goldenBallAutoPrice; }
            else if (currentBallFrame == 14) { upgradePrice = footballBallAutoPrice; totalAutoUpgradePrice = footballBallAutoPrice; }
            else if (currentBallFrame == 15) { upgradePrice = sharpnelBallAutoPrice; totalAutoUpgradePrice = sharpnelBallAutoPrice; }
            else if (currentBallFrame == 16) { upgradePrice = zonicBallAutoPrice; totalAutoUpgradePrice = zonicBallAutoPrice; }
            else if (currentBallFrame == 17) { upgradePrice = apricotBallAutoPrice; totalAutoUpgradePrice = apricotBallAutoPrice; }
            else if (currentBallFrame == 18) { upgradePrice = peggoBallAutoPrice; totalAutoUpgradePrice = peggoBallAutoPrice; }
            else if (currentBallFrame == 19) { upgradePrice = ghostBallAutoPrice; totalAutoUpgradePrice = ghostBallAutoPrice; }
            else if (currentBallFrame == 20) { upgradePrice = starBallAutoPrice; totalAutoUpgradePrice = starBallAutoPrice; }
            else if (currentBallFrame == 21) { upgradePrice = rainbowBallAutoPrice; totalAutoUpgradePrice = rainbowBallAutoPrice; }
            else if (currentBallFrame == 22) { upgradePrice = glitchyBallAutoPrice; totalAutoUpgradePrice = glitchyBallAutoPrice; }

            while (remainingPoints >= upgradePrice)
            {
                remainingPoints -= upgradePrice;
                upgradePrice *= autoPriceIncrease;
                maxAutoUpgradeCount++;
            }

            float ballDropTime = 0;

            if (currentBallFrame == 1) { ballDropTime = basicBallAutoDropTime; }
            else if (currentBallFrame == 2) { ballDropTime = redBallAutoDropTime; }
            else if (currentBallFrame == 3) { ballDropTime = rockBallAutoDropTime; }
            else if (currentBallFrame == 4) { ballDropTime = bombBallAutoDropTime; }
            else if (currentBallFrame == 5) { ballDropTime = aquaBallAutoDropTime; }
            else if (currentBallFrame == 6) { ballDropTime = mudBallAutoDropTime; }
            else if (currentBallFrame == 7) { ballDropTime = basketBallAutoDropTime; }
            else if (currentBallFrame == 8) { ballDropTime = plumBallAutoDropTime; }
            else if (currentBallFrame == 9) { ballDropTime = stickyBallAutoDropTime; }
            else if (currentBallFrame == 10) { ballDropTime = candyBallAutoDropTime; }
            else if (currentBallFrame == 11) { ballDropTime = cookieBallAutoDropTime; }
            else if (currentBallFrame == 12) { ballDropTime = limeBallAutoDropTime; }
            else if (currentBallFrame == 13) { ballDropTime = goldenBallAutoDropTime; }
            else if (currentBallFrame == 14) { ballDropTime = footballBallAutoDropTime; }
            else if (currentBallFrame == 15) { ballDropTime = sharpnelBallAutoDropTime; }
            else if (currentBallFrame == 16) { ballDropTime = zonicBallAutoDropTime; }
            else if (currentBallFrame == 17) { ballDropTime = apricotBallAutoDropTime; }
            else if (currentBallFrame == 18) { ballDropTime = peggoBallAutoDropTime; }
            else if (currentBallFrame == 19) { ballDropTime = ghostBallAutoDropTime; }
            else if (currentBallFrame == 20) { ballDropTime = starBallAutoDropTime; }
            else if (currentBallFrame == 21) { ballDropTime = rainbowBallAutoDropTime; }
            else if (currentBallFrame == 22) { ballDropTime = glitchyBallAutoDropTime; }

            int autoCount = 0;

            while (ballDropTime > minAutoDrop)
            {
                ballDropTime -= (ballDropTime / allBallDivide);
                autoCount++;
            }

            if(autoNotPurchased == true) { autoCount++; }

            if (maxAutoUpgradeCount > autoCount) { maxAutoUpgradeCount = autoCount; }


            double total = 0;
            int count = 0;

            while (count < maxAutoUpgradeCount)
            {
                count += 1;

                total += totalAutoUpgradePrice;

                totalAutoUpgradePrice *= autoPriceIncrease;
                RoundToNearestWhole(totalAutoUpgradePrice);
                totalAutoUpgradePrice = currentDouble;
            }

            if(ballDropTime != minAutoDrop) { if (maxAutoUpgradeCount > 1) { ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(total); } }

            maxAutoX.text = "X" + maxAutoUpgradeCount.ToString("F0");
        }
    }

    public void SetNormalAutoPrice()
    {
        double upgradePrice = 0;
        float ballDropTime = 0;
        if (currentBallFrame == 1) { ballDropTime = basicBallAutoDropTime; }
        else if (currentBallFrame == 2) { ballDropTime = redBallAutoDropTime; }
        else if (currentBallFrame == 3) { ballDropTime = rockBallAutoDropTime; }
        else if (currentBallFrame == 4) { ballDropTime = bombBallAutoDropTime; }
        else if (currentBallFrame == 5) { ballDropTime = aquaBallAutoDropTime; }
        else if (currentBallFrame == 6) { ballDropTime = mudBallAutoDropTime; }
        else if (currentBallFrame == 7) { ballDropTime = basketBallAutoDropTime; }
        else if (currentBallFrame == 8) { ballDropTime = plumBallAutoDropTime; }
        else if (currentBallFrame == 9) { ballDropTime = stickyBallAutoDropTime; }
        else if (currentBallFrame == 10) { ballDropTime = candyBallAutoDropTime; }
        else if (currentBallFrame == 11) { ballDropTime = cookieBallAutoDropTime; }
        else if (currentBallFrame == 12) { ballDropTime = limeBallAutoDropTime; }
        else if (currentBallFrame == 13) { ballDropTime = goldenBallAutoDropTime; }
        else if (currentBallFrame == 14) { ballDropTime = footballBallAutoDropTime; }
        else if (currentBallFrame == 15) { ballDropTime = sharpnelBallAutoDropTime; }
        else if (currentBallFrame == 16) { ballDropTime = zonicBallAutoDropTime; }
        else if (currentBallFrame == 17) { ballDropTime = apricotBallAutoDropTime; }
        else if (currentBallFrame == 18) { ballDropTime = peggoBallAutoDropTime; }
        else if (currentBallFrame == 19) { ballDropTime = ghostBallAutoDropTime; }
        else if (currentBallFrame == 20) { ballDropTime = starBallAutoDropTime; }
        else if (currentBallFrame == 21) { ballDropTime = rainbowBallAutoDropTime; }
        else if (currentBallFrame == 22) { ballDropTime = glitchyBallAutoDropTime; }
      
        if (ballDropTime != minAutoDrop)
        {
            if (currentBallFrame == 1) { upgradePrice = regularBallAutoPrice; }
            else if (currentBallFrame == 2) { upgradePrice = redBallAutoPrice; }
            else if (currentBallFrame == 3) { upgradePrice = rockBallAutoPrice; }
            else if (currentBallFrame == 4) { upgradePrice = bombBallAutoPrice; }
            else if (currentBallFrame == 5) { upgradePrice = aquaBallAutoPrice; }
            else if (currentBallFrame == 6) { upgradePrice = mudBallAutoPrice; }
            else if (currentBallFrame == 7) { upgradePrice = basketBallAutoPrice; }
            else if (currentBallFrame == 8) { upgradePrice = plumBallAutoPrice; }
            else if (currentBallFrame == 9) { upgradePrice = stickyBallAutoPrice; }
            else if (currentBallFrame == 10) { upgradePrice = candyBallAutoPrice; }
            else if (currentBallFrame == 11) { upgradePrice = cookieBallAutoPrice; }
            else if (currentBallFrame == 12) { upgradePrice = limeBallAutoPrice; }
            else if (currentBallFrame == 13) { upgradePrice = goldenBallAutoPrice; }
            else if (currentBallFrame == 14) { upgradePrice = footballBallAutoPrice; }
            else if (currentBallFrame == 15) { upgradePrice = sharpnelBallAutoPrice; }
            else if (currentBallFrame == 16) { upgradePrice = zonicBallAutoPrice; }
            else if (currentBallFrame == 17) { upgradePrice = apricotBallAutoPrice; }
            else if (currentBallFrame == 18) { upgradePrice = peggoBallAutoPrice; }
            else if (currentBallFrame == 19) { upgradePrice = ghostBallAutoPrice; }
            else if (currentBallFrame == 20) { upgradePrice = starBallAutoPrice; }
            else if (currentBallFrame == 21) { upgradePrice = rainbowBallAutoPrice; }
            else if (currentBallFrame == 22) { upgradePrice = glitchyBallAutoPrice; }

            ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(upgradePrice);
        }
    }
    #endregion

    #region Calculate max pluss 1 upgrade
    public void CalculateMaxPluss1Upgrade()
    {
        if (currentBallFrame == 0) { }
        else
        {
            double remainingPoints = points;
            double upgradePrice = 0;
            maxPluss1BallUpgradeCount = 0;

            if (currentBallFrame == 1) { upgradePrice = regularBallPluss1Price; totalPluss1BallUpgradePrice = regularBallPluss1Price; }
            else if (currentBallFrame == 2) { upgradePrice = redBallPluss1Price; totalPluss1BallUpgradePrice = redBallPluss1Price; }
            else if (currentBallFrame == 3) { upgradePrice = rockBallPluss1Price; totalPluss1BallUpgradePrice = rockBallPluss1Price; }
            else if (currentBallFrame == 4) { upgradePrice = bombBallPluss1Price; totalPluss1BallUpgradePrice = bombBallPluss1Price; }
            else if (currentBallFrame == 5) { upgradePrice = aquaBallPluss1Price; totalPluss1BallUpgradePrice = aquaBallPluss1Price; }
            else if (currentBallFrame == 6) { upgradePrice = mudBallPluss1Price; totalPluss1BallUpgradePrice = mudBallPluss1Price; }
            else if (currentBallFrame == 7) { upgradePrice = basketBallPluss1Price; totalPluss1BallUpgradePrice = basketBallPluss1Price; }
            else if (currentBallFrame == 8) { upgradePrice = plumBallPluss1Price; totalPluss1BallUpgradePrice = plumBallPluss1Price; }
            else if (currentBallFrame == 9) { upgradePrice = stickyBallPluss1Price; totalPluss1BallUpgradePrice = stickyBallPluss1Price; }
            else if (currentBallFrame == 10) { upgradePrice = candyBallPluss1Price; totalPluss1BallUpgradePrice = candyBallPluss1Price; }
            else if (currentBallFrame == 11) { upgradePrice = cookieBallPluss1Price; totalPluss1BallUpgradePrice = cookieBallPluss1Price; }
            else if (currentBallFrame == 12) { upgradePrice = limeBallPluss1Price; totalPluss1BallUpgradePrice = limeBallPluss1Price; }
            else if (currentBallFrame == 13) { upgradePrice = goldenBallPluss1Price; totalPluss1BallUpgradePrice = goldenBallPluss1Price; }
            else if (currentBallFrame == 14) { upgradePrice = footballBallPluss1Price; totalPluss1BallUpgradePrice = footballBallPluss1Price; }
            else if (currentBallFrame == 15) { upgradePrice = sharpnelBallPluss1Price; totalPluss1BallUpgradePrice = sharpnelBallPluss1Price; }
            else if (currentBallFrame == 16) { upgradePrice = zonicBallPluss1Price; totalPluss1BallUpgradePrice = zonicBallPluss1Price; }
            else if (currentBallFrame == 17) { upgradePrice = apricotBallPluss1Price; totalPluss1BallUpgradePrice = apricotBallPluss1Price; }
            else if (currentBallFrame == 18) { upgradePrice = peggoBallPluss1Price; totalPluss1BallUpgradePrice = peggoBallPluss1Price; }
            else if (currentBallFrame == 19) { upgradePrice = ghostBallPluss1Price; totalPluss1BallUpgradePrice = ghostBallPluss1Price; }
            else if (currentBallFrame == 20) { upgradePrice = starBallPluss1Price; totalPluss1BallUpgradePrice = starBallPluss1Price; }
            else if (currentBallFrame == 21) { upgradePrice = rainbowBallPluss1Price; totalPluss1BallUpgradePrice = rainbowBallPluss1Price; }
            else if (currentBallFrame == 22) { upgradePrice = glitchyBallPluss1Price; totalPluss1BallUpgradePrice = glitchyBallPluss1Price; }

            while (remainingPoints >= upgradePrice)
            {
                remainingPoints -= upgradePrice;
                upgradePrice *= ballPriceIcrease;
                maxPluss1BallUpgradeCount++;
            }

            if (currentBallFrame == 1) { currentTotalBalls = totalRegularBalls; }
            else if (currentBallFrame == 2) { currentTotalBalls = totalRedBalls; }
            else if (currentBallFrame == 3) { currentTotalBalls = totalRockBalls; }
            else if (currentBallFrame == 4) { currentTotalBalls = totalBombBalls; }
            else if (currentBallFrame == 5) { currentTotalBalls = totalAquaBalls; }
            else if (currentBallFrame == 6) { currentTotalBalls = totalMudBalls; }
            else if (currentBallFrame == 7) { currentTotalBalls = totalBasketBalls; }
            else if (currentBallFrame == 8) { currentTotalBalls = totalPlumBalls; }
            else if (currentBallFrame == 9) { currentTotalBalls = totalStickyBalls; }
            else if (currentBallFrame == 10) { currentTotalBalls = totalCandyBalls; }
            else if (currentBallFrame == 11) { currentTotalBalls = totalCookieBalls; }
            else if (currentBallFrame == 12) { currentTotalBalls = totalLimeBalls; }
            else if (currentBallFrame == 13) { currentTotalBalls = totalGoldenBalls; }
            else if (currentBallFrame == 14) { currentTotalBalls = totalFootballBalls; }
            else if (currentBallFrame == 15) { currentTotalBalls = totalSharpnelBalls; }
            else if (currentBallFrame == 16) { currentTotalBalls = totalZonicBalls; }
            else if (currentBallFrame == 17) { currentTotalBalls = totalApricotBalls; }
            else if (currentBallFrame == 18) { currentTotalBalls = totalPeggoBalls; }
            else if (currentBallFrame == 19) { currentTotalBalls = totalGhostBalls; }
            else if (currentBallFrame == 20) { currentTotalBalls = totalStarBalls; }
            else if (currentBallFrame == 21) { currentTotalBalls = totalRainbowBalls; }
            else if (currentBallFrame == 22) { currentTotalBalls = totalGlitchyBalls; }


            double total = 0;
            int count = 0;

            while (count < maxPluss1BallUpgradeCount)
            {
                count += 1;

                if(count < (10 - currentTotalBalls))
                {
                    total += totalPluss1BallUpgradePrice;

                    totalPluss1BallUpgradePrice *= ballPriceIcrease;
                    RoundToNearestWhole(totalPluss1BallUpgradePrice);
                    totalPluss1BallUpgradePrice = currentDouble;
                }
            }

            if(currentTotalBalls != 10) 
            { 
                if (maxPluss1BallUpgradeCount > 1) { ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(total); } 
            }


            if (maxPluss1BallUpgradeCount > (10 - currentTotalBalls)) { maxPluss1BallUpgradeCount = (10 - currentTotalBalls); }

            maxPluss1X.text = "X" + maxPluss1BallUpgradeCount.ToString("F0");
        }
    }

    public void SetNormalPluss1PRice()
    {
        double upgradePrice = 0;

        if (currentBallFrame == 1) { currentTotalBalls = totalRegularBalls; }
        else if (currentBallFrame == 2) { currentTotalBalls = totalRedBalls; }
        else if (currentBallFrame == 3) { currentTotalBalls = totalRockBalls; }
        else if (currentBallFrame == 4) { currentTotalBalls = totalBombBalls; }
        else if (currentBallFrame == 5) { currentTotalBalls = totalAquaBalls; }
        else if (currentBallFrame == 6) { currentTotalBalls = totalMudBalls; }
        else if (currentBallFrame == 7) { currentTotalBalls = totalBasketBalls; }
        else if (currentBallFrame == 8) { currentTotalBalls = totalPlumBalls; }
        else if (currentBallFrame == 9) { currentTotalBalls = totalStickyBalls; }
        else if (currentBallFrame == 10) { currentTotalBalls = totalCandyBalls; }
        else if (currentBallFrame == 11) { currentTotalBalls = totalCookieBalls; }
        else if (currentBallFrame == 12) { currentTotalBalls = totalLimeBalls; }
        else if (currentBallFrame == 13) { currentTotalBalls = totalGoldenBalls; }
        else if (currentBallFrame == 14) { currentTotalBalls = totalFootballBalls; }
        else if (currentBallFrame == 15) { currentTotalBalls = totalSharpnelBalls; }
        else if (currentBallFrame == 16) { currentTotalBalls = totalZonicBalls; }
        else if (currentBallFrame == 17) { currentTotalBalls = totalApricotBalls; }
        else if (currentBallFrame == 18) { currentTotalBalls = totalPeggoBalls; }
        else if (currentBallFrame == 19) { currentTotalBalls = totalGhostBalls; }
        else if (currentBallFrame == 20) { currentTotalBalls = totalStarBalls; }
        else if (currentBallFrame == 21) { currentTotalBalls = totalRainbowBalls; }
        else if (currentBallFrame == 22) { currentTotalBalls = totalGlitchyBalls; }

        if (currentTotalBalls != 10)
        {
            if (currentBallFrame == 1) { upgradePrice = regularBallPluss1Price; }
            else if (currentBallFrame == 2) { upgradePrice = redBallPluss1Price; }
            else if (currentBallFrame == 3) { upgradePrice = rockBallPluss1Price; }
            else if (currentBallFrame == 4) { upgradePrice = bombBallPluss1Price; }
            else if (currentBallFrame == 5) { upgradePrice = aquaBallPluss1Price; }
            else if (currentBallFrame == 6) { upgradePrice = mudBallPluss1Price; }
            else if (currentBallFrame == 7) { upgradePrice = basketBallPluss1Price; }
            else if (currentBallFrame == 8) { upgradePrice = plumBallPluss1Price; }
            else if (currentBallFrame == 9) { upgradePrice = stickyBallPluss1Price; }
            else if (currentBallFrame == 10) { upgradePrice = candyBallPluss1Price; }
            else if (currentBallFrame == 11) { upgradePrice = cookieBallPluss1Price; }
            else if (currentBallFrame == 12) { upgradePrice = limeBallPluss1Price; }
            else if (currentBallFrame == 13) { upgradePrice = goldenBallPluss1Price; }
            else if (currentBallFrame == 14) { upgradePrice = footballBallPluss1Price; }
            else if (currentBallFrame == 15) { upgradePrice = sharpnelBallPluss1Price; }
            else if (currentBallFrame == 16) { upgradePrice = zonicBallPluss1Price; }
            else if (currentBallFrame == 17) { upgradePrice = apricotBallPluss1Price; }
            else if (currentBallFrame == 18) { upgradePrice = peggoBallPluss1Price; }
            else if (currentBallFrame == 19) { upgradePrice = ghostBallPluss1Price; }
            else if (currentBallFrame == 20) { upgradePrice = starBallPluss1Price; }
            else if (currentBallFrame == 21) { upgradePrice = rainbowBallPluss1Price; }
            else if (currentBallFrame == 22) { upgradePrice = glitchyBallPluss1Price; }

            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(upgradePrice);
        }
    }

    #endregion

    #region Calculate max golden peg
    public void CalculateMaxGoldenPeg()
    {
        double remainingPoints = points;
        double upgradePrice = goldenPegsPrice;
        totalBucketUpgradePrice = goldenPegsPrice;
        maxGoldenPegUpgradeCount = 0;

        while (remainingPoints >= upgradePrice)
        {
            remainingPoints -= upgradePrice;
            upgradePrice *= 2.25f;
            maxGoldenPegUpgradeCount++;
        }

        double total = 0;
        int count = 0;

        while (count < maxGoldenPegUpgradeCount)
        {
            count += 1;

            total += totalBucketUpgradePrice;

            totalBucketUpgradePrice *= 2.25f;
            RoundToNearestWhole(totalBucketUpgradePrice);
            totalBucketUpgradePrice = currentDouble;
        }

        if (maxGoldenPegUpgradeCount > 1) { goldenPegsPriceText.text = SetHighNumbers.FormatCoinsGoldShort(total); }

        maxGoldenPEgPluss.text = "X" + maxGoldenPegUpgradeCount.ToString("F0");
    }
    #endregion

    #region Calculate max bucket
    public void CalculateMaxBucket()
    {
        double remainingPoints = points;
        totalGoldenPegsUpgradePrice = bucketPrice;
        double upgradePrice = bucketPrice;
        maxBucketUpgradeCount = 0;

        while (remainingPoints >= upgradePrice)
        {
            remainingPoints -= upgradePrice;
            upgradePrice *= 2.25f;
            maxBucketUpgradeCount++;
        }


        double total = 0;
        int count = 0;

        while (count < maxBucketUpgradeCount)
        {
            count += 1;

            total += totalGoldenPegsUpgradePrice;

            totalGoldenPegsUpgradePrice *= 2.25f;
            RoundToNearestWhole(totalGoldenPegsUpgradePrice);
            totalGoldenPegsUpgradePrice = currentDouble;
        }

        if (maxBucketUpgradeCount > 1) { pitPriceText.text = SetHighNumbers.FormatCoinsGoldShort(total); }


        maxBucketPluss.text = "X" + maxBucketUpgradeCount.ToString("F0");
    }

    public void SetBucketAndPegNormalPrice()
    {
        pitPriceText.text = SetHighNumbers.FormatCoinsGoldShort(bucketPrice);
        goldenPegsPriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenPegsPrice);
    }
    #endregion

    public void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            xFramesBallUpgrades.SetActive(true);
            xFramesBandPupgrades.SetActive(true);
            isMax = true;
            CalculateMaxUpgrade();
            CalculateMaxGoldenPeg();
            CalculateMaxBucket();
            CalculateMaxAutoUpgrade();
            CalculateMaxPluss1Upgrade();
        }
        else
        {
            if(isMaxPressed == true)
            {
                xFramesBallUpgrades.SetActive(true);
                xFramesBandPupgrades.SetActive(true);
                isMax = true; 
                CalculateMaxUpgrade();
                CalculateMaxGoldenPeg();
                CalculateMaxBucket();
                CalculateMaxAutoUpgrade();
                CalculateMaxPluss1Upgrade();
            }
            else 
            { 
                if(isMax == true)
                {
                    SetNormal1XBallUpgrade();
                    SetNormalAutoPrice();
                    SetBucketAndPegNormalPrice();
                    SetNormalPluss1PRice();
                }

                isMax = false;
                xFramesBallUpgrades.SetActive(false);
                xFramesBandPupgrades.SetActive(false);
            }
        }

        if (Input.anyKey) 
        {
            CheckInput();
            isKeyPressed = true;
        }
         // else if (!Input.anyKey)
         //{
         //    isKeyPressed = false;
         // 
         //}

        #region Unlock new balls text color
        if(bouncyBallPurchased == false)
        {
            if (points < bouncyBallPrice) { bouncyBallPriceText.color = Color.red; }
            else { bouncyBallPriceText.color = Color.green; }
        }
        else if (rockBallPurchased == false)
        {
            if (points < rockBallPrice) { rockBallPriceText.color = Color.red; }
            else { rockBallPriceText.color = Color.green; }
        }
        else if (bombBallPurchased == false)
        {
            if (points < bombBallPrice) { bombBallPriceText.color = Color.red; }
            else { bombBallPriceText.color = Color.green; }
        }

        if(GameData.isDemo == false)
        {
            if (aquaBallPurchased == false)
            {
                if (points < aquaBallPrice) { aquaBallPriceText.color = Color.red; }
                else { aquaBallPriceText.color = Color.green; }
            }
            else if (mudBallPurchased == false)
            {
                if (points < mudBallPrice) { mudBallPriceText.color = Color.red; }
                else { mudBallPriceText.color = Color.green; }
            }
            else if (basketBallPurchased == false)
            {
                if (points < basketBallPrice) { basketBallPriceText.color = Color.red; }
                else { basketBallPriceText.color = Color.green; }
            }
            else if (plumBallPurchased == false)
            {
                if (points < plumBallPrice) { plumBallPriceText.color = Color.red; }
                else { plumBallPriceText.color = Color.green; }
            }
            else if (stickyBallPurchased == false)
            {
                if (points < stickyBallPrice) { stickyBallPriceText.color = Color.red; }
                else { stickyBallPriceText.color = Color.green; }
            }
            // For Candy Ball
            else if (!candyBallPurchased)
            {
                if (points < candyBallPrice)
                {
                    candyBallPriceText.color = Color.red;
                }
                else
                {
                    candyBallPriceText.color = Color.green;
                }
            }

            // For Cookie Ball
            else if (!cookieBallPurchased)
            {
                if (points < cookieBallPrice)
                {
                    cookieBallPriceText.color = Color.red;
                }
                else
                {
                    cookieBallPriceText.color = Color.green;
                }
            }

            // For Lime Ball
            else if (!limeBallPurchased)
            {
                if (points < limeBallPrice)
                {
                    limeBallPriceText.color = Color.red;
                }
                else
                {
                    limeBallPriceText.color = Color.green;
                }
            }

            // For Golden Ball
            else if (!goldenBallPurchased)
            {
                if (points < goldenBallPrice)
                {
                    goldenBallPriceText.color = Color.red;
                }
                else
                {
                    goldenBallPriceText.color = Color.green;
                }
            }

            // For Football Ball
            else if (!footballBallPurchased)
            {
                if (points < footballBallPrice)
                {
                    footballBallPriceText.color = Color.red;
                }
                else
                {
                    footballBallPriceText.color = Color.green;
                }
            }

            // For Sharpnel Ball
            else if (!sharpnelBallPurchased)
            {
                if (points < sharpnelBallPrice)
                {
                    sharpnelBallPriceText.color = Color.red;
                }
                else
                {
                    sharpnelBallPriceText.color = Color.green;
                }
            }

            // For Zonic Ball
            else if (!zonicBallPurchased)
            {
                if (points < zonicBallPrice)
                {
                    zonicBallPriceText.color = Color.red;
                }
                else
                {
                    zonicBallPriceText.color = Color.green;
                }
            }

            // For Apricot Ball
            else if (!apricotBallPurchased)
            {
                if (points < apricotBallPrice)
                {
                    apricotBallPriceText.color = Color.red;
                }
                else
                {
                    apricotBallPriceText.color = Color.green;
                }
            }

            // For Peggo Ball
            else if (!peggoBallPurchased)
            {
                if (points < peggoBallPrice)
                {
                    peggoBallPriceText.color = Color.red;
                }
                else
                {
                    peggoBallPriceText.color = Color.green;
                }
            }

            // For Ghost Ball
            else if (!ghostBallPurchased)
            {
                if (points < ghostBallPrice)
                {
                    ghostBallPriceText.color = Color.red;
                }
                else
                {
                    ghostBallPriceText.color = Color.green;
                }
            }

            // For Star Ball
            else if (!starBallPurchased)
            {
                if (points < starBallPrice)
                {
                    starBallPriceText.color = Color.red;
                }
                else
                {
                    starBallPriceText.color = Color.green;
                }
            }

            // For Rainbow Ball
            else if (!rainbowBallPurchased)
            {
                if (points < rainbowBallPrice)
                {
                    rainbowBallPriceText.color = Color.red;
                }
                else
                {
                    rainbowBallPriceText.color = Color.green;
                }
            }

            // For Glitchy Ball
            else if (!glitchyBallPurchased)
            {
                if (points < glitchyBallPrice)
                {
                    glitchyBallPriceText.color = Color.red;
                }
                else
                {
                    glitchyBallPriceText.color = Color.green;
                }
            }
        }
       
        #endregion

        #region Pits and golden pegs text color
        if (points < bucketPrice) { pitPriceText.color = Color.red; }
        else { pitPriceText.color = Color.green; }

        if (points < goldenPegsPrice) { goldenPegsPriceText.color = Color.red; }
        else { goldenPegsPriceText.color = Color.green; }
        #endregion

        #region Ball upgrades text color
        if(ballUpgradeFrame.activeInHierarchy == true)
        {
            if (currentBallFrame == 1)
            {
                if (points < regularBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < regularBallAutoPrice || isBall1MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < regularBallPluss1Price || totalRegularBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 2)
            {
                if (points < redBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < redBallAutoPrice || isBall2MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < redBallPluss1Price || totalRedBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }

            else if (currentBallFrame == 3)
            {
                if (points < rockBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < rockBallAutoPrice || isBall3MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < rockBallPluss1Price || totalRockBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }

            else if (currentBallFrame == 4)
            {
                if (points < bombBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < bombBallAutoPrice || isBall4MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < bombBallPluss1Price || totalBombBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 5)
            {
                if (points < aquaBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < aquaBallAutoPrice || isBall5MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < aquaBallPluss1Price || totalAquaBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }

            else if (currentBallFrame == 6)
            {
                if (points < mudBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < mudBallAutoPrice || isBall6MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < mudBallPluss1Price || totalMudBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }

            else if (currentBallFrame == 7)
            {
                if (points < basketBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < basketBallAutoPrice || isBall7MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < basketBallPluss1Price || totalBasketBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }

            else if (currentBallFrame == 8)
            {
                if (points < plumBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < plumBallAutoPrice || isBall8MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < plumBallPluss1Price || totalPlumBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }

            else if (currentBallFrame == 9)
            {
                if (points < stickyBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < stickyBallAutoPrice || isBall9MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < stickyBallPluss1Price || totalStickyBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }

            else if (currentBallFrame == 10)
            {
                if (points < candyBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < candyBallAutoPrice || isBall10MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < candyBallPluss1Price || totalCandyBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 11)
            {
                if (points < cookieBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < cookieBallAutoPrice || isBall11MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < cookieBallPluss1Price || totalCookieBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 12)
            {
                if (points < limeBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < limeBallAutoPrice || isBall12MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < limeBallPluss1Price || totalLimeBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 13)
            {
                if (points < goldenBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < goldenBallAutoPrice || isBall13MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < goldenBallPluss1Price || totalGoldenBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 14)
            {
                if (points < footballBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < footballBallAutoPrice || isBall14MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < footballBallPluss1Price || totalFootballBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 15)
            {
                if (points < sharpnelBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < sharpnelBallAutoPrice || isBall15MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < sharpnelBallPluss1Price || totalSharpnelBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 16)
            {
                if (points < zonicBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < zonicBallAutoPrice || isBall16MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < zonicBallPluss1Price || totalZonicBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 17)
            {
                if (points < apricotBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < apricotBallAutoPrice || isBall17MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < apricotBallPluss1Price || totalApricotBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 18)
            {
                if (points < peggoBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < peggoBallAutoPrice || isBall18MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < peggoBallPluss1Price || totalPeggoBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 19)
            {
                if (points < ghostBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < ghostBallAutoPrice || isBall19MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < ghostBallPluss1Price || totalGhostBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 20)
            {
                if (points < starBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < starBallAutoPrice || isBall20MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < starBallPluss1Price || totalStarBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 21)
            {
                if (points < rainbowBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < rainbowBallAutoPrice || isBall21MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < rainbowBallPluss1Price || totalRainbowBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
            else if (currentBallFrame == 22)
            {
                if (points < glitchyBallUpgradePrice) { ballFrameUpgradePriceText.color = Color.red; }
                else { ballFrameUpgradePriceText.color = Color.green; }
                if (points < glitchyBallAutoPrice || isBall22MAXAUTO == true) { ballFrameAutoDropPriceText.color = Color.red; }
                else { ballFrameAutoDropPriceText.color = Color.green; }
                if (points < glitchyBallPluss1Price || totalGlitchyBalls == 10) { ballFramePurchaseBallPriceText.color = Color.red; }
                else { ballFramePurchaseBallPriceText.color = Color.green; }
            }
        }
        #endregion

        #region Ball upgrade frame
        if (Input.GetKeyDown(KeyCode.Mouse0) && openedBallFrame == true)
        {
            if(isHooked == false)
            {
                if (SetUpgradeFrameOff.isHovering == false) { ballUpgradeFrame.SetActive(false); openedBallFrame = false; }
            }
          
            //if (SetUpgradeFrameOff.isHovering == true) { ballUpgradeFrame.SetActive(true); }

            //Debug.Log(SetUpgradeFrameOff.isHovering); Debug.Log(openedBallFrame);
        }
        #endregion

        if(points > 1000 || points < 1) { totalPointsText.text = SetHighNumbers.FormatCoinsGoldShort(points); }
        else if (points % 1 == 0) { totalPointsText.text = SetHighNumbers.FormatCoinsGoldShort(points); }
        else { totalPointsText.text = points.ToString("F1"); }

        if (ghostBallPurchased == true) { totalGhostBallIncrease = BasicBall.ghostBallsOnScreen * ghostBallGoldIncrease; }
        if(rainbowBallPurchased == true) 
        { 
            totalRainbowBallIncrease = BasicBall.totalRainbowBallHitPegs * rainbowBallGoldIncrease;
        }
    }

    #region Check Challenge progress
    public void CheckChallProgress()
    {

    }
    #endregion

    #region Max upgrade frame
    public Animation maxFrame;
    public static bool isIn;
    public int maxUpgradeCount, maxAutoUpgradeCount, maxPluss1BallUpgradeCount, maxBucketUpgradeCount, maxGoldenPegUpgradeCount;
    public GameObject arrow;

    public void MaxFrameAnim()
    {
        if(isIn == false) 
        { 
            maxFrame.Play("maxTabIn"); isIn = true; SetUpgradeFrameOff.clickedAnim = false; StartCoroutine(WaitAnim(maxFrame));
            arrow.transform.localScale = new Vector3(0.3717124f, 0.3717124f, 0.3717124f);
        }
        else 
        {
            maxFrame.Play("maxTabOut"); isIn = false; SetUpgradeFrameOff.clickedAnim = false;
            arrow.transform.localScale = new Vector3(-0.3717124f, 0.3717124f, 0.3717124f);
        }
    }

    IEnumerator WaitAnim(Animation anim)
    {
        while (anim.isPlaying)
        {
            yield return null;
            SetUpgradeFrameOff.clickedAnim = false;
        }

        SetUpgradeFrameOff.clickedAnim = true;
    }

    public static bool isMax;
    public GameObject selected1XOrMore;
    public Button X1UpgradeBTN, maxUpgradeBTN;

    public void X1Upgrade()
    {
        audioManager.Play("UIClick1");
        maxUpgradeCount = 1;
        isMax = false;
        selected1XOrMore.transform.position = X1UpgradeBTN.gameObject.transform.position;
        X1UpgradeBTN.interactable = false;
        maxUpgradeBTN.interactable = true;
        isMaxPressed = false;
        SetNormal1XBallUpgrade();
        SetNormalAutoPrice();
        SetBucketAndPegNormalPrice();
        SetNormalPluss1PRice();
    }

    public bool isMaxPressed;
    public void MaxUpgrade()
    {
        audioManager.Play("UIClick1");
        isMaxPressed = true;
        isMax = true;
        selected1XOrMore.transform.position = maxUpgradeBTN.gameObject.transform.position;
        X1UpgradeBTN.interactable = true;
        maxUpgradeBTN.interactable = false;
    }
    #endregion

    #region Upgrade Balls
    public double goldIncrement;

    public static int regularBallLevel, redBallLevel, rockBallLevel, bombBallLevel, aquaBallLevel, mudBallLevel, basketBallLevel, plumBallLevel, stickyBallLevel, candyBallLevel,cookieBallLevel,limeBallLevel,goldenBallLevel,footballBallLevel, sharpnelBallLevel, zonicBallLevel, apricotBallLevel, peggoBallLevel, ghostBallLevel, starBallLevel, rainbowBallLevel, glitchyBallLevel;

    public double currentGoldDisplay;
    public TextMeshProUGUI currentBallLevelDisplay;

    public static double regularBallGoldIncrement, bouncyBallGoldIncrement, rockBallGoldIncrement, bombBallGoldIncrement, aquaBallGoldIncrement, mudBallGoldIncrement, basketBallGoldIncrement, plumBallGoldIncrement, stickyBallGoldIncrement, candyBallGoldIncrement, cookieBallGoldIncrement, limeBallGoldIncrement, goldenBallGoldIncrement, footballBallGoldIncrement, sharpnelBallGoldIncrement, zonicBallGoldIncrement, apricotBallGoldIncrement, peggoBallGoldIncrement, ghostBallGoldIncrement, starBallGoldIncrement, rainbowBallGoldIncrement, glitchyBallGoldIncrement;

    public void UpgradeBall()
    {
        if(isMax == false) { maxUpgradeCount = 1; }

        #region Ball1
        if (currentBallFrame == 1)
        {
            if (points >= regularBallUpgradePrice)
            {
                PurchaseSounds();

                for (int i = 0; i < maxUpgradeCount; i++)
                {
                    points -= regularBallUpgradePrice;
                    SetTotalGoldSpent(regularBallUpgradePrice);

                    regularBallLevel += 1;
                    regularBallLevelText.text = regularBallLevel + "";

                    CheckGoldScale(currentBallFrame, regularBallLevel, regularBallGoldIncrement);

                    regularBallGold += goldIncrement;
                    ballFrameUpgradeText.text = SetHighNumbers.FormatCoinsGoldShort(regularBallGold) + " (+" + SetHighNumbers.FormatCoinsGoldShort(goldIncrement) + ")";

                    regularBallUpgradePrice *= goldPriceIncrease;
                    ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(regularBallUpgradePrice);

                    RoundToNearestWhole(regularBallGold);
                    regularBallGold = currentDouble;
                    RoundToNearestWhole(goldIncrement);
                    goldIncrement = currentDouble;
                    RoundToNearestWhole(regularBallUpgradePrice);
                    regularBallUpgradePrice = currentDouble;

                    currentGoldDisplay = regularBallGold;
                    if (currentBallFrame == ballNumberEquipped)
                    {
                        DisplayCorrectGoldText(currentGoldDisplay);
                        currentBallLevelDisplay.text = LocalizationStrings.levelString + regularBallLevel;
                    }
                }
                
                return;
            }
        }
        #endregion

        #region Ball2
        if (currentBallFrame == 2)
        {
            if (points >= redBallUpgradePrice)
            {
                PurchaseSounds();

                for (int i = 0; i < maxUpgradeCount; i++)
                {
                    points -= redBallUpgradePrice;
                    SetTotalGoldSpent(redBallUpgradePrice);

                    redBallLevel += 1;
                    redBallLevelText.text = redBallLevel + "";

                    CheckGoldScale(currentBallFrame, redBallLevel, bouncyBallGoldIncrement);

                    redBallGold += goldIncrement;

                    redBallUpgradePrice *= goldPriceIncrease;
                    ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(redBallUpgradePrice);

                    ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(redBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                    RoundToNearestWhole(redBallGold);
                    redBallGold = currentDouble;
                    RoundToNearestWhole(bouncyBallGoldIncrement);
                    bouncyBallGoldIncrement = currentDouble;
                    RoundToNearestWhole(redBallUpgradePrice);
                    redBallUpgradePrice = currentDouble;

                    currentGoldDisplay = redBallGold;
                    if (currentBallFrame == ballNumberEquipped)
                    {
                        DisplayCorrectGoldText(currentGoldDisplay);
                        currentBallLevelDisplay.text = LocalizationStrings.levelString + redBallLevel;
                    }
                }
                   
                return;
            }
        }
        #endregion

        #region Ball3
        if (currentBallFrame == 3)
        {
            if (points >= rockBallUpgradePrice)
            {
                PurchaseSounds();

                for (int i = 0; i < maxUpgradeCount; i++)
                {
                    points -= rockBallUpgradePrice;
                    SetTotalGoldSpent(rockBallUpgradePrice);

                    rockBallLevel += 1;
                    rockBallLevelText.text = rockBallLevel + "";

                    CheckGoldScale(currentBallFrame, rockBallLevel, rockBallGoldIncrement);

                    rockBallGold += goldIncrement;

                    rockBallUpgradePrice *= goldPriceIncrease;
                    ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(rockBallUpgradePrice);

                    ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(rockBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                    RoundToNearestWhole(rockBallGold);
                    rockBallGold = currentDouble;
                    RoundToNearestWhole(rockBallGoldIncrement);
                    rockBallGoldIncrement = currentDouble;
                    RoundToNearestWhole(rockBallUpgradePrice);
                    rockBallUpgradePrice = currentDouble;

                    currentGoldDisplay = rockBallGold;
                    if (currentBallFrame == ballNumberEquipped)
                    {
                        DisplayCorrectGoldText(currentGoldDisplay);
                        currentBallLevelDisplay.text = LocalizationStrings.levelString + rockBallLevel;
                    }
                }
              
                return;
            }
        }
        #endregion

        #region Ball4
        if (currentBallFrame == 4)
        {
            if (points >= bombBallUpgradePrice)
            {
                PurchaseSounds();

                for (int i = 0; i < maxUpgradeCount; i++)
                {
                    points -= bombBallUpgradePrice;
                    SetTotalGoldSpent(bombBallUpgradePrice);

                    bombBallLevel += 1;
                    bombBallLevelText.text = bombBallLevel + "";

                    CheckGoldScale(currentBallFrame, bombBallLevel, bombBallGoldIncrement);
                    bombBallGold += goldIncrement;

                    bombBallUpgradePrice *= goldPriceIncrease;
                    ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(bombBallUpgradePrice);

                    ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(bombBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                    currentGoldDisplay = bombBallGold;

                    RoundToNearestWhole(bombBallGold);
                    bombBallGold = currentDouble;
                    RoundToNearestWhole(goldIncrement);
                    goldIncrement = currentDouble;
                    RoundToNearestWhole(bombBallUpgradePrice);
                    bombBallUpgradePrice = currentDouble;

                    if (currentBallFrame == ballNumberEquipped)
                    {
                        DisplayCorrectGoldText(currentGoldDisplay);
                        currentBallLevelDisplay.text = LocalizationStrings.levelString + bombBallLevel;
                    }
                }
            }
            return;
        }
        #endregion

        if(GameData.isDemo == false)
        {
            #region Aqua Ball
            if (currentBallFrame == 5)
            {
                if (points >= aquaBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= aquaBallUpgradePrice;
                        SetTotalGoldSpent(aquaBallUpgradePrice);

                        aquaBallLevel += 1;
                        aquaBallLevelText.text = aquaBallLevel + "";

                        CheckGoldScale(currentBallFrame, aquaBallLevel, aquaBallGoldIncrement);
                        aquaBallGold += goldIncrement;

                        aquaBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(aquaBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(aquaBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = aquaBallGold;

                        RoundToNearestWhole(aquaBallGold);
                        aquaBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(aquaBallUpgradePrice);
                        aquaBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + aquaBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Mud Ball
            if (currentBallFrame == 6)
            {
                if (points >= mudBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= mudBallUpgradePrice;
                        SetTotalGoldSpent(mudBallUpgradePrice);

                        mudBallLevel += 1;
                        mudBallLevelText.text = mudBallLevel + "";

                        CheckGoldScale(currentBallFrame, mudBallLevel, mudBallGoldIncrement);
                        mudBallGold += goldIncrement;

                        mudBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(mudBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(mudBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = mudBallGold;

                        RoundToNearestWhole(mudBallGold);
                        mudBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(mudBallUpgradePrice);
                        mudBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + mudBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Basket Ball
            if (currentBallFrame == 7)
            {
                if (points >= basketBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= basketBallUpgradePrice;
                        SetTotalGoldSpent(basketBallUpgradePrice);

                        basketBallLevel += 1;
                        basketBallLevelText.text = basketBallLevel + "";

                        CheckGoldScale(currentBallFrame, basketBallLevel, basketBallGoldIncrement);
                        basketBallGold += goldIncrement;

                        basketBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(basketBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(basketBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = basketBallGold;

                        RoundToNearestWhole(basketBallGold);
                        basketBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(basketBallUpgradePrice);
                        basketBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + basketBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Plum Ball
            if (currentBallFrame == 8)
            {
                if (points >= plumBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= plumBallUpgradePrice;
                        SetTotalGoldSpent(plumBallUpgradePrice);

                        plumBallLevel += 1;
                        plumBallLevelText.text = plumBallLevel + "";

                        CheckGoldScale(currentBallFrame, plumBallLevel, plumBallGoldIncrement);
                        plumBallGold += goldIncrement;

                        plumBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(plumBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(plumBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = plumBallGold;

                        RoundToNearestWhole(plumBallGold);
                        plumBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(plumBallUpgradePrice);
                        plumBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + plumBallLevel;
                        }
                    }
                      
                }
                return;
            }
            #endregion

            #region Sticky Ball
            if (currentBallFrame == 9)
            {
                if (points >= stickyBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= stickyBallUpgradePrice;
                        SetTotalGoldSpent(stickyBallUpgradePrice);

                        stickyBallLevel += 1;
                        stickyBallLevelText.text = stickyBallLevel + "";

                        CheckGoldScale(currentBallFrame, stickyBallLevel, stickyBallGoldIncrement);
                        stickyBallGold += goldIncrement;

                        stickyBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(stickyBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(stickyBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = stickyBallGold;

                        RoundToNearestWhole(stickyBallGold);
                        stickyBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(stickyBallUpgradePrice);
                        stickyBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + stickyBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Candy Ball
            if (currentBallFrame == 10)
            {
                if (points >= candyBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= candyBallUpgradePrice;
                        SetTotalGoldSpent(candyBallUpgradePrice);

                        candyBallLevel += 1;
                        candyBallLevelText.text = candyBallLevel + "";

                        CheckGoldScale(currentBallFrame, candyBallLevel, candyBallGoldIncrement);
                        candyBallGold += goldIncrement;

                        candyBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(candyBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(candyBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = candyBallGold;

                        RoundToNearestWhole(candyBallGold);
                        candyBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(candyBallUpgradePrice);
                        candyBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + candyBallLevel;
                        }
                    }
                      
                }
                return;
            }
            #endregion

            #region Cookie Ball
            if (currentBallFrame == 11)
            {
                if (points >= cookieBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= cookieBallUpgradePrice;
                        SetTotalGoldSpent(cookieBallUpgradePrice);

                        cookieBallLevel += 1;
                        cookieBallLevelText.text = cookieBallLevel + "";

                        CheckGoldScale(currentBallFrame, cookieBallLevel, cookieBallGoldIncrement);
                        cookieBallGold += goldIncrement;

                        cookieBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(cookieBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(cookieBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = cookieBallGold;

                        RoundToNearestWhole(cookieBallGold);
                        cookieBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(cookieBallUpgradePrice);
                        cookieBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + cookieBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Lime Ball
            if (currentBallFrame == 12)
            {
                if (points >= limeBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= limeBallUpgradePrice;
                        SetTotalGoldSpent(limeBallUpgradePrice);

                        limeBallLevel += 1;
                        limeBallLevelText.text = limeBallLevel + "";

                        CheckGoldScale(currentBallFrame, limeBallLevel, limeBallGoldIncrement);
                        limeBallGold += goldIncrement;

                        limeBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(limeBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(limeBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = limeBallGold;

                        RoundToNearestWhole(limeBallGold);
                        limeBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(limeBallUpgradePrice);
                        limeBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + limeBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Golden Ball
            if (currentBallFrame == 13)
            {
                if (points >= goldenBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= goldenBallUpgradePrice;
                        SetTotalGoldSpent(goldenBallUpgradePrice);

                        goldenBallLevel += 1;
                        goldenBallLevelText.text = goldenBallLevel + "";

                        CheckGoldScale(currentBallFrame, goldenBallLevel, goldenBallGoldIncrement);
                        goldenBallGold += goldIncrement;

                        goldenBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(goldenBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = goldenBallGold;

                        RoundToNearestWhole(goldenBallGold);
                        goldenBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(goldenBallUpgradePrice);
                        goldenBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + goldenBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Football Ball
            if (currentBallFrame == 14)
            {
                if (points >= footballBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= footballBallUpgradePrice;
                        SetTotalGoldSpent(footballBallUpgradePrice);

                        footballBallLevel += 1;
                        footballBallLevelText.text = footballBallLevel + "";

                        CheckGoldScale(currentBallFrame, footballBallLevel, footballBallGoldIncrement);
                        footballBallGold += goldIncrement;

                        footballBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(footballBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(footballBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = footballBallGold;

                        RoundToNearestWhole(footballBallGold);
                        footballBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(footballBallUpgradePrice);
                        footballBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + footballBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Sharpnel Ball
            if (currentBallFrame == 15)
            {
                if (points >= sharpnelBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= sharpnelBallUpgradePrice;
                        SetTotalGoldSpent(sharpnelBallUpgradePrice);

                        sharpnelBallLevel += 1;
                        sharpnelBallLevelText.text = sharpnelBallLevel + "";

                        CheckGoldScale(currentBallFrame, sharpnelBallLevel, sharpnelBallGoldIncrement);
                        sharpnelBallGold += goldIncrement;

                        sharpnelBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(sharpnelBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(sharpnelBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = sharpnelBallGold;

                        RoundToNearestWhole(sharpnelBallGold);
                        sharpnelBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(sharpnelBallUpgradePrice);
                        sharpnelBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + sharpnelBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Zonic Ball
            if (currentBallFrame == 16)
            {
                if (points >= zonicBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= zonicBallUpgradePrice;
                        SetTotalGoldSpent(zonicBallUpgradePrice);

                        zonicBallLevel += 1;
                        zonicBallLevelText.text = zonicBallLevel + "";

                        CheckGoldScale(currentBallFrame, zonicBallLevel, zonicBallGoldIncrement);
                        zonicBallGold += goldIncrement;

                        zonicBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(zonicBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(zonicBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = zonicBallGold;

                        RoundToNearestWhole(zonicBallGold);
                        zonicBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(zonicBallUpgradePrice);
                        zonicBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + zonicBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Apricot Ball
            if (currentBallFrame == 17)
            {
                if (points >= apricotBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= apricotBallUpgradePrice;
                        SetTotalGoldSpent(apricotBallUpgradePrice);

                        apricotBallLevel += 1;
                        apricotBallLevelText.text = apricotBallLevel + "";

                        CheckGoldScale(currentBallFrame, apricotBallLevel, apricotBallGoldIncrement);
                        apricotBallGold += goldIncrement;

                        apricotBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(apricotBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(apricotBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = apricotBallGold;

                        RoundToNearestWhole(apricotBallGold);
                        apricotBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(apricotBallUpgradePrice);
                        apricotBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + apricotBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Peggo Ball
            if (currentBallFrame == 18)
            {
                if (points >= peggoBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= peggoBallUpgradePrice;
                        SetTotalGoldSpent(peggoBallUpgradePrice);

                        peggoBallLevel += 1;
                        peggoBallLevelText.text = peggoBallLevel + "";

                        CheckGoldScale(currentBallFrame, peggoBallLevel, peggoBallGoldIncrement);
                        peggoBallGold += goldIncrement;

                        peggoBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(peggoBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(peggoBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = peggoBallGold;

                        RoundToNearestWhole(peggoBallGold);
                        peggoBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(peggoBallUpgradePrice);
                        peggoBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + peggoBallLevel;
                        }
                    }
                  
                }
                return;
            }
            #endregion

            #region Ghost Ball
            if (currentBallFrame == 19)
            {
                if (points >= ghostBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= ghostBallUpgradePrice;
                        SetTotalGoldSpent(ghostBallUpgradePrice);

                        ghostBallLevel += 1;
                        ghostBallLevelText.text = ghostBallLevel + "";

                        CheckGoldScale(currentBallFrame, ghostBallLevel, ghostBallGoldIncrement);
                        ghostBallGold += goldIncrement;

                        ghostBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(ghostBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(ghostBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = ghostBallGold;

                        RoundToNearestWhole(ghostBallGold);
                        ghostBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(ghostBallUpgradePrice);
                        ghostBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + ghostBallLevel;
                        }
                    }
                      
                }
                return;
            }
            #endregion

            #region Star Ball
            if (currentBallFrame == 20)
            {
                if (points >= starBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= starBallUpgradePrice;
                        SetTotalGoldSpent(starBallUpgradePrice);

                        starBallLevel += 1;
                        starBallLevelText.text = starBallLevel + "";

                        CheckGoldScale(currentBallFrame, starBallLevel, starBallGoldIncrement);
                        starBallGold += goldIncrement;

                        starBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(starBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(starBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = starBallGold;

                        RoundToNearestWhole(starBallGold);
                        starBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(starBallUpgradePrice);
                        starBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + starBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Rainbow Ball
            if (currentBallFrame == 21)
            {
                if (points >= rainbowBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= rainbowBallUpgradePrice;
                        SetTotalGoldSpent(rainbowBallUpgradePrice);

                        rainbowBallLevel += 1;
                        rainbowBallLevelText.text = rainbowBallLevel + "";

                        CheckGoldScale(currentBallFrame, rainbowBallLevel, rainbowBallGoldIncrement);
                        rainbowBallGold += goldIncrement;

                        rainbowBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(rainbowBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(rainbowBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = rainbowBallGold;

                        RoundToNearestWhole(rainbowBallGold);
                        rainbowBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(rainbowBallUpgradePrice);
                        rainbowBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + rainbowBallLevel;
                        }
                    }
                }
                return;
            }
            #endregion

            #region Glitchy Ball
            if (currentBallFrame == 22)
            {
                if (points >= glitchyBallUpgradePrice)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxUpgradeCount; i++)
                    {
                        points -= glitchyBallUpgradePrice;
                        SetTotalGoldSpent(glitchyBallUpgradePrice);

                        glitchyBallLevel += 1;
                        glitchyBallLevelText.text = glitchyBallLevel + "";

                        CheckGoldScale(currentBallFrame, glitchyBallLevel, glitchyBallGoldIncrement);
                        glitchyBallGold += goldIncrement;

                        glitchyBallUpgradePrice *= goldPriceIncrease;
                        ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(glitchyBallUpgradePrice);

                        ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(glitchyBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                        currentGoldDisplay = glitchyBallGold;

                        RoundToNearestWhole(glitchyBallGold);
                        glitchyBallGold = currentDouble;
                        RoundToNearestWhole(goldIncrement);
                        goldIncrement = currentDouble;
                        RoundToNearestWhole(glitchyBallUpgradePrice);
                        glitchyBallUpgradePrice = currentDouble;

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            DisplayCorrectGoldText(currentGoldDisplay);
                            currentBallLevelDisplay.text = LocalizationStrings.levelString + glitchyBallLevel;
                        }
                    }
                   
                }
                return;
            }
            #endregion
        }

        CantAfford();
    }

    public void CheckHighestLEvelBall()
    {
        if(GameData.isDemo == true) { return; }

        if(regularBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = regularBallLevel; }
        if (redBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = redBallLevel; }
        if (rockBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = rockBallLevel; }
        if (bombBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = bombBallLevel; }
        if (aquaBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = aquaBallLevel; }
        if (mudBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = mudBallLevel; }
        if (basketBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = basketBallLevel; }
        if (plumBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = plumBallLevel; }
        if (stickyBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = stickyBallLevel; }
        if (candyBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = candyBallLevel; }
        if (cookieBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = cookieBallLevel; }
        if (limeBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = limeBallLevel; }
        if (goldenBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = goldenBallLevel; }
        if (footballBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = footballBallLevel; }
        if (sharpnelBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = sharpnelBallLevel; }
        if (zonicBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = zonicBallLevel; }
        if (apricotBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = apricotBallLevel; }
        if (peggoBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = peggoBallLevel; }
        if (ghostBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = ghostBallLevel; }
        if (starBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = starBallLevel; }
        if (rainbowBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = rainbowBallLevel; }
        if (glitchyBallLevel > Challenges.ballUpgradeLevel) { Challenges.ballUpgradeLevel = glitchyBallLevel; }

        if (Challenges.challCompleted[14] == false && Challenges.challFinished[14] == false) { challScript.CheckCompleted(15, Challenges.ballUpgradeLevel); }
        if (Challenges.challCompleted[15] == false && Challenges.challFinished[15] == false) { challScript.CheckCompleted(16, Challenges.ballUpgradeLevel); }
        if (Challenges.challCompleted[16] == false && Challenges.challFinished[16] == false) { challScript.CheckCompleted(17, Challenges.ballUpgradeLevel); }

        if (Challenges.challCompleted[14] == false && Challenges.challFinished[14] == false) { challScript.ChallengeProgress(15, Challenges.ballUpgradeLevel); }
        if (Challenges.challCompleted[15] == false && Challenges.challFinished[15] == false) { challScript.ChallengeProgress(16, Challenges.ballUpgradeLevel); }
        if (Challenges.challCompleted[16] == false && Challenges.challFinished[16] == false) { challScript.ChallengeProgress(17, Challenges.ballUpgradeLevel); }
    }

    public void DisplayCorrectGoldText(double ballGold)
    {
        ballEquippedPointsText.text = SetHighNumbers.FormatCoinsGoldShort(ballGold);
    }

    public float divideScale, otherDivideScale;
    public void SetNewGoldIncrement(int ballNumber, int timesIncrement)
    {
        otherDivideScale = 8;

        if (GameData.isDemo == true) 
        {
            if (ballNumber == 1 && timesIncrement > 2) { divideScale = 1.2f; }
            else if (ballNumber > 2 && ballNumber < 10) { divideScale = 60f; }
            else if (ballNumber > 9 && ballNumber < 19) { divideScale = 60f; }
            else if (ballNumber > 19 && ballNumber < 23) { divideScale = 60f; }
            else { divideScale = 2; }
        }
        else
        {
            if (ballNumber == 1 && timesIncrement > 2) { divideScale = 1.2f - Challenges.challGoldScaling; }
            else if (ballNumber > 2 && ballNumber < 10) { divideScale = 60f - Challenges.challGoldScaling3; }
            else if (ballNumber > 9 && ballNumber < 19) { divideScale = 60f - Challenges.challGoldScaling3; }
            else if (ballNumber > 19 && ballNumber < 23) { divideScale = 60f - Challenges.challGoldScaling3; }
            else { divideScale = 2 - Challenges.challGoldScaling2; }
        }

        if(ballNumber != 1 && ballNumber != 2 && ballNumber != 22 && timesIncrement == 1)
        {
            if (ballNumber < 4 && (timesIncrement == 3 - (ballNumber - 1))) { goldIncrement = bombBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 5 && (timesIncrement == 4 - (ballNumber - 1))) { goldIncrement = aquaBallGoldIncrement / otherDivideScale;  }
            else if (ballNumber < 6 && (timesIncrement == 5 - (ballNumber - 1))) { goldIncrement = mudBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 7 && (timesIncrement == 6 - (ballNumber - 1))) { goldIncrement = basketBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 8 && (timesIncrement == 7 - (ballNumber - 1))) { goldIncrement = plumBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 9 && (timesIncrement == 8 - (ballNumber - 1))) { goldIncrement = stickyBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 10 && (timesIncrement == 9 - (ballNumber - 1))) { goldIncrement = candyBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 11 && (timesIncrement == 10 - (ballNumber - 1))) { goldIncrement = cookieBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 12 && (timesIncrement == 11 - (ballNumber - 1))) { goldIncrement = limeBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 13 && (timesIncrement == 12 - (ballNumber - 1))) { goldIncrement = goldenBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 14 && (timesIncrement == 13 - (ballNumber - 1))) { goldIncrement = footballBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 15 && (timesIncrement == 14 - (ballNumber - 1))) { goldIncrement = sharpnelBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 16 && (timesIncrement == 15 - (ballNumber - 1))) { goldIncrement = zonicBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 17 && (timesIncrement == 16 - (ballNumber - 1))) { goldIncrement = apricotBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 18 && (timesIncrement == 17 - (ballNumber - 1))) { goldIncrement = peggoBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 19 && (timesIncrement == 18 - (ballNumber - 1))) { goldIncrement = ghostBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 20 && (timesIncrement == 19 - (ballNumber - 1))) { goldIncrement = starBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 21 && (timesIncrement == 20 - (ballNumber - 1))) { goldIncrement = rainbowBallGoldIncrement / otherDivideScale; }
            else if (ballNumber < 22 && (timesIncrement == 21 - (ballNumber - 1))) { goldIncrement = glitchyBallGoldIncrement / otherDivideScale; }
        }
        else
        {
            if (ballNumber < 2 && timesIncrement == 1) { goldIncrement = bouncyBallGoldIncrement; }
            else if (ballNumber < 3 && (timesIncrement == 2 - (ballNumber - 1))) { goldIncrement = rockBallGoldIncrement / divideScale; }
            else if (ballNumber < 4 && (timesIncrement == 3 - (ballNumber - 1))) { goldIncrement = bombBallGoldIncrement / divideScale; }
            else if (ballNumber < 5 && (timesIncrement == 4 - (ballNumber - 1))) { goldIncrement = aquaBallGoldIncrement / divideScale; }
            else if (ballNumber < 6 && (timesIncrement == 5 - (ballNumber - 1))) { goldIncrement = mudBallGoldIncrement / divideScale; }
            else if (ballNumber < 7 && (timesIncrement == 6 - (ballNumber - 1))) { goldIncrement = basketBallGoldIncrement / divideScale; }
            else if (ballNumber < 8 && (timesIncrement == 7 - (ballNumber - 1))) { goldIncrement = plumBallGoldIncrement / divideScale; }
            else if (ballNumber < 9 && (timesIncrement == 8 - (ballNumber - 1))) { goldIncrement = stickyBallGoldIncrement / divideScale; }
            else if (ballNumber < 10 && (timesIncrement == 9 - (ballNumber - 1))) { goldIncrement = candyBallGoldIncrement / divideScale; }
            else if (ballNumber < 11 && (timesIncrement == 10 - (ballNumber - 1))) { goldIncrement = cookieBallGoldIncrement / divideScale; }
            else if (ballNumber < 12 && (timesIncrement == 11 - (ballNumber - 1))) { goldIncrement = limeBallGoldIncrement / divideScale; }
            else if (ballNumber < 13 && (timesIncrement == 12 - (ballNumber - 1))) { goldIncrement = goldenBallGoldIncrement / divideScale; }
            else if (ballNumber < 14 && (timesIncrement == 13 - (ballNumber - 1))) { goldIncrement = footballBallGoldIncrement / divideScale; }
            else if (ballNumber < 15 && (timesIncrement == 14 - (ballNumber - 1))) { goldIncrement = sharpnelBallGoldIncrement / divideScale; }
            else if (ballNumber < 16 && (timesIncrement == 15 - (ballNumber - 1))) { goldIncrement = zonicBallGoldIncrement / divideScale; }
            else if (ballNumber < 17 && (timesIncrement == 16 - (ballNumber - 1))) { goldIncrement = apricotBallGoldIncrement / divideScale; }
            else if (ballNumber < 18 && (timesIncrement == 17 - (ballNumber - 1))) { goldIncrement = peggoBallGoldIncrement / divideScale; }
            else if (ballNumber < 19 && (timesIncrement == 18 - (ballNumber - 1))) { goldIncrement = ghostBallGoldIncrement / divideScale; }
            else if (ballNumber < 20 && (timesIncrement == 19 - (ballNumber - 1))) { goldIncrement = starBallGoldIncrement / divideScale; }
            else if (ballNumber < 21 && (timesIncrement == 20 - (ballNumber - 1))) { goldIncrement = rainbowBallGoldIncrement / divideScale; }
            else if (ballNumber < 22 && (timesIncrement == 21 - (ballNumber - 1))) { goldIncrement = glitchyBallGoldIncrement / divideScale; }
            else if (ballNumber == 22 && timesIncrement > 0) { goldIncrement = glitchyBallGoldIncrement * (1 + (timesIncrement / 2f)); }
            else
            {
                int totalBalls = 22;
                int scale = (timesIncrement + ballNumber) - totalBalls;
                goldIncrement = glitchyBallGoldIncrement * (1 + (scale / 2f));
            }
        }
    }
    #endregion

    #region Unlock New Balls
    public static double bouncyBallPrice, rockBallPrice, bombBallPrice, aquaBallPrice, mudBallPrice, basketBallPrice, plumBallPrice, stickyBallPrice, candyBallPrice,cookieBallPrice,limeBallPrice,goldenBallPrice,footballBallPrice,sharpnelBallPrice,zonicBallPrice,apricotBallPrice,peggoBallPrice,ghostBallPrice,starBallPrice,rainbowBallPrice,glitchyBallPrice;

    public GameObject ball3LockFrame, ball4LockFrame, ball5LockFrame, ball6LockFrame, ball7LockFrame, ball8LockFrame, ball9LockFrame, ball10LockFrame, ball11LockFrame, ball12LockFrame, ball13LockFrame, ball14LockFrame, ball15LockFrame, ball16LockFrame, ball17LockFrame, ball18LockFrame, ball19LockFrame, ball20LockFrame, ball21LockFrame, ball22LockFrame;

    public GameObject ball2PriceLockedFrame, ball3PriceLockedFrame, ball4PriceLockedFrame, ball5PriceLockedFrame, ball6PriceLockedFrame, ball7PriceLockedFrame, ball8PriceLockedFrame, ball9PriceLockedFrame, ball10PriceLockedFrame, ball11PriceLockedFrame, ball12PriceLockedFrame, ball13PriceLockedFrame, ball14PriceLockedFrame, ball15PriceLockedFrame, ball16PriceLockedFrame, ball17PriceLockedFrame, ball18PriceLockedFrame, ball19PriceLockedFrame, ball20PriceLockedFrame, ball21PriceLockedFrame, ball22PriceLockedFrame;

    public GameObject ball2UnlockedFrame, ball3UnlockedFrame, ball4UnlockedFrame, ball5UnlockedFrame, ball6UnlockedFrame, ball7UnlockedFrame, ball8UnlockedFrame, ball9UnlockedFrame, ball10UnlockedFrame, ball11UnlockedFrame, ball12UnlockedFrame, ball13UnlockedFrame, ball14UnlockedFrame, ball15UnlockedFrame, ball16UnlockedFrame, ball17UnlockedFrame, ball18UnlockedFrame, ball19UnlockedFrame, ball20UnlockedFrame, ball21UnlockedFrame, ball22UnlockedFrame;

    public Button bouncyBallButton, rockBallButton, bombBallButton, aquaBallButton, mudBallButton, basketBallButton, plumBallButton, stickyBallButton, candyBallButton, cookieBallButton, limeBallButton,goldenBallButton, footballBallButton, sharpnelBallButton,zonicBallButton, apricotBallButton, peggoBallButton, ghostBallButton,starBallButton, rainbowBallButton, glitchyBallButton;
    public static bool bouncyBallPurchased, rockBallPurchased, bombBallPurchased, aquaBallPurchased, mudBallPurchased, basketBallPurchased, plumBallPurchased, stickyBallPurchased, candyBallPurchased, cookieBallPurchased, limeBallPurchased, goldenBallPurchased, footballBallPurchased, sharpnelBallPurchased, zonicBallPurchased, apricotBallPurchased, peggoBallPurchased, ghostBallPurchased, starBallPurchased, rainbowBallPurchased, glitchyBallPurchased;

    public static int ballsPurchased;
    public TabsAndFrames tabsSCript;

    public PointsMechanics pointsScript;

    public void PurchaseNewBall(int ballNumber)
    {
        #region Ball 2
        if (ballNumber == 2 && points >= bouncyBallPrice)
        {
            ballsPurchased += 1;
            audioManager.Play("PurchaseBall");
            if (firstTimePurchaseNewBall == false) { firstTimePurchaseNewBall = true; }

            bouncyBallPurchased = true;
            points -= bouncyBallPrice;
            SetTotalGoldSpent(bouncyBallPrice);
            bouncyBallButton.interactable = true;
            ball2UnlockedFrame.SetActive(true);
            ball2PriceLockedFrame.SetActive(false);
            ball3PriceLockedFrame.SetActive(true);
            ball3LockFrame.SetActive(false);
            CheckNewBallACH();
            if(isBall2AutoTurnedOff == true) { FrameColor(1, true); }
            else { FrameColor(1, false); }
            pointsScript.CheckWhichBallsToSpawnText();

            return;
        }
        #endregion

        #region Ball 3
        if (ballNumber == 3 && points >= rockBallPrice)
        {
            ballsPurchased += 1;

            audioManager.Play("PurchaseBall");
            rockBallPurchased = true;
            points -= rockBallPrice;
            SetTotalGoldSpent(rockBallPrice);
            rockBallButton.interactable = true;
            ball3UnlockedFrame.SetActive(true);
            ball3PriceLockedFrame.SetActive(false);
            ball4PriceLockedFrame.SetActive(true);
            ball4LockFrame.SetActive(false);
            if (isBall3AutoTurnedOff == true) { FrameColor(2, true); }
            else { FrameColor(2, false); }
            pointsScript.CheckWhichBallsToSpawnText();

            return;
        }
        #endregion

        #region Ball 4
        if (ballNumber == 4 && points >= bombBallPrice)
        {
            ballsPurchased += 1;

            audioManager.Play("PurchaseBall");
            bombBallPurchased = true;
            points -= bombBallPrice;
            SetTotalGoldSpent(bombBallPrice);
            bombBallButton.interactable = true;
            ball4UnlockedFrame.SetActive(true);
            ball4PriceLockedFrame.SetActive(false);

            if(GameData.isDemo == false)
            {
                ball5PriceLockedFrame.SetActive(true);
                ball5LockFrame.SetActive(false);
            }
            CheckNewBallACH();
            if (isBall4AutoTurnedOff == true) { FrameColor(3, true); }
            else { FrameColor(3, false); }
            pointsScript.CheckWhichBallsToSpawnText();

            return;
        }
        #endregion

        if(GameData.isDemo == false)
        {
            #region Aqua Ball
            if (ballNumber == 5 && points >= aquaBallPrice)
            {
                ballsPurchased += 1;

                audioManager.Play("PurchaseBall");
                aquaBallPurchased = true;
                points -= aquaBallPrice;
                SetTotalGoldSpent(aquaBallPrice);
                aquaBallButton.interactable = true;
                ball5UnlockedFrame.SetActive(true);
                ball5PriceLockedFrame.SetActive(false);
                ball6PriceLockedFrame.SetActive(true);
                ball6LockFrame.SetActive(false);
                if (isBall5AutoTurnedOff == true) { FrameColor(4, true); }
                else { FrameColor(4, false); }
                pointsScript.CheckWhichBallsToSpawnText();

                return;
            }
            #endregion

            #region Mud Ball
            if (ballNumber == 6 && points >= mudBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                mudBallPurchased = true;
                points -= mudBallPrice;
                SetTotalGoldSpent(mudBallPrice);
                mudBallButton.interactable = true;
                ball6UnlockedFrame.SetActive(true);
                ball6PriceLockedFrame.SetActive(false);
                ball7PriceLockedFrame.SetActive(true);
                ball7LockFrame.SetActive(false);
                if (isBall6AutoTurnedOff == true) { FrameColor(5, true); }
                else { FrameColor(5, false); }
                pointsScript.CheckWhichBallsToSpawnText();

                return;
            }
            #endregion

            #region Basket Ball
            if (ballNumber == 7 && points >= basketBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                basketBallPurchased = true;
                points -= basketBallPrice;
                SetTotalGoldSpent(basketBallPrice);
                basketBallButton.interactable = true;
                ball7UnlockedFrame.SetActive(true);
                ball7PriceLockedFrame.SetActive(false);
                ball8PriceLockedFrame.SetActive(true);
                ball8LockFrame.SetActive(false);
                CheckNewBallACH();
                if (isBall7AutoTurnedOff == true) { FrameColor(6, true); }
                else { FrameColor(6, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Plum Ball
            if (ballNumber == 8 && points >= plumBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                plumBallPurchased = true;
                points -= plumBallPrice;
                SetTotalGoldSpent(plumBallPrice);
                plumBallButton.interactable = true;
                ball8UnlockedFrame.SetActive(true);
                ball8PriceLockedFrame.SetActive(false);
                ball9PriceLockedFrame.SetActive(true);
                ball9LockFrame.SetActive(false);
                if (isBall8AutoTurnedOff == true) { FrameColor(7, true); }
                else { FrameColor(7, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Sticky Ball
            if (ballNumber == 9 && points >= stickyBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                stickyBallPurchased = true;
                points -= stickyBallPrice;
                SetTotalGoldSpent(stickyBallPrice);
                stickyBallButton.interactable = true;
                ball9UnlockedFrame.SetActive(true);
                ball9PriceLockedFrame.SetActive(false);
                ball10PriceLockedFrame.SetActive(true);
                ball10LockFrame.SetActive(false);
                tabsSCript.SetFRameBTNS();
                if (isBall9AutoTurnedOff == true) { FrameColor(8, true); }
                else { FrameColor(8, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Candy Ball
            if (ballNumber == 10 && points >= candyBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                candyBallPurchased = true;
                points -= candyBallPrice;
                SetTotalGoldSpent(candyBallPrice);
                candyBallButton.interactable = true;
                ball10UnlockedFrame.SetActive(true);
                ball10PriceLockedFrame.SetActive(false);
                ball11PriceLockedFrame.SetActive(true);
                ball11LockFrame.SetActive(false);
               
                CheckNewBallACH();
                if (isBall10AutoTurnedOff == true) { FrameColor(9, true); }
                else { FrameColor(9, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Cookie Ball
            if (ballNumber == 11 && points >= cookieBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                cookieBallPurchased = true;
                points -= cookieBallPrice;
                SetTotalGoldSpent(cookieBallPrice);
                cookieBallButton.interactable = true;
                ball11UnlockedFrame.SetActive(true);
                ball11PriceLockedFrame.SetActive(false);
                ball12PriceLockedFrame.SetActive(true);
                ball12LockFrame.SetActive(false);
                if (isBall11AutoTurnedOff == true) { FrameColor(10, true); }
                else { FrameColor(10, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Lime Ball
            if (ballNumber == 12 && points >= limeBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                limeBallPurchased = true;
                points -= limeBallPrice;
                SetTotalGoldSpent(limeBallPrice);
                limeBallButton.interactable = true;
                ball12UnlockedFrame.SetActive(true);
                ball12PriceLockedFrame.SetActive(false);
                ball13PriceLockedFrame.SetActive(true);
                ball13LockFrame.SetActive(false);
                if (isBall12AutoTurnedOff == true) { FrameColor(11, true); }
                else { FrameColor(11, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Golden Ball
            if (ballNumber == 13 && points >= goldenBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                goldenBallPurchased = true;
                points -= goldenBallPrice;
                SetTotalGoldSpent(goldenBallPrice);
                goldenBallButton.interactable = true;
                ball13UnlockedFrame.SetActive(true);
                ball13PriceLockedFrame.SetActive(false);
                ball14PriceLockedFrame.SetActive(true);
                ball14LockFrame.SetActive(false);
                if (isBall13AutoTurnedOff == true) { FrameColor(12, true); }
                else { FrameColor(12, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Football Ball
            if (ballNumber == 14 && points >= footballBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                footballBallPurchased = true;
                points -= footballBallPrice;
                SetTotalGoldSpent(footballBallPrice);
                footballBallButton.interactable = true;
                ball14UnlockedFrame.SetActive(true);
                ball14PriceLockedFrame.SetActive(false);
                ball15PriceLockedFrame.SetActive(true);
                ball15LockFrame.SetActive(false);
                CheckNewBallACH();
                if (isBall14AutoTurnedOff == true) { FrameColor(13, true); }
                else { FrameColor(13, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Sharpnel Ball
            if (ballNumber == 15 && points >= sharpnelBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                sharpnelBallPurchased = true;
                points -= sharpnelBallPrice;
                SetTotalGoldSpent(sharpnelBallPrice);
                sharpnelBallButton.interactable = true;
                ball15UnlockedFrame.SetActive(true);
                ball15PriceLockedFrame.SetActive(false);
                ball16PriceLockedFrame.SetActive(true);
                ball16LockFrame.SetActive(false);
                if (isBall15AutoTurnedOff == true) { FrameColor(14, true); }
                else { FrameColor(14, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Zonic Ball
            if (ballNumber == 16 && points >= zonicBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                zonicBallPurchased = true;
                points -= zonicBallPrice;
                SetTotalGoldSpent(zonicBallPrice);
                zonicBallButton.interactable = true;
                ball16UnlockedFrame.SetActive(true);
                ball16PriceLockedFrame.SetActive(false);
                ball17PriceLockedFrame.SetActive(true);
                ball17LockFrame.SetActive(false);
                if (isBall16AutoTurnedOff == true) { FrameColor(15, true); }
                else { FrameColor(15, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Apricot Ball
            if (ballNumber == 17 && points >= apricotBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                apricotBallPurchased = true;
                points -= apricotBallPrice;
                SetTotalGoldSpent(apricotBallPrice);
                apricotBallButton.interactable = true;
                ball17UnlockedFrame.SetActive(true);
                ball17PriceLockedFrame.SetActive(false);
                ball18PriceLockedFrame.SetActive(true);
                ball18LockFrame.SetActive(false);
                if (isBall17AutoTurnedOff == true) { FrameColor(16, true); }
                else { FrameColor(16, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Peggo Ball
            if (ballNumber == 18 && points >= peggoBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                peggoBallPurchased = true;
                points -= peggoBallPrice;
                SetTotalGoldSpent(peggoBallPrice);
                peggoBallButton.interactable = true;
                ball18UnlockedFrame.SetActive(true);
                ball18PriceLockedFrame.SetActive(false);
                ball19PriceLockedFrame.SetActive(true);
                ball19LockFrame.SetActive(false);
                tabsSCript.SetFRameBTNS();
                CheckNewBallACH();
                if (isBall18AutoTurnedOff == true) { FrameColor(17, true); }
                else { FrameColor(17, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Ghost Ball
            if (ballNumber == 19 && points >= ghostBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                ghostBallPurchased = true;
                points -= ghostBallPrice;
                SetTotalGoldSpent(ghostBallPrice);
                ghostBallButton.interactable = true;
                ball19UnlockedFrame.SetActive(true);
                ball19PriceLockedFrame.SetActive(false);
                ball20PriceLockedFrame.SetActive(true);
                ball20LockFrame.SetActive(false);
                if (isBall19AutoTurnedOff == true) { FrameColor(18, true); }
                else { FrameColor(18, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Star Ball
            if (ballNumber == 20 && points >= starBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                starBallPurchased = true;
                points -= starBallPrice;
                SetTotalGoldSpent(starBallPrice);
                starBallButton.interactable = true;
                ball20UnlockedFrame.SetActive(true);
                ball20PriceLockedFrame.SetActive(false);
                ball21PriceLockedFrame.SetActive(true);
                ball21LockFrame.SetActive(false);
                if (isBall20AutoTurnedOff == true) { FrameColor(19, true); }
                else { FrameColor(19, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Rainbow Ball
            if (ballNumber == 21 && points >= rainbowBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                rainbowBallPurchased = true;
                points -= rainbowBallPrice;
                SetTotalGoldSpent(rainbowBallPrice);
                rainbowBallButton.interactable = true;
                ball21UnlockedFrame.SetActive(true);
                ball21PriceLockedFrame.SetActive(false);
                ball22PriceLockedFrame.SetActive(true);
                ball22LockFrame.SetActive(false);
                if (isBall21AutoTurnedOff == true) { FrameColor(20, true); }
                else { FrameColor(20, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion

            #region Glitchy Ball
            if (ballNumber == 22 && points >= glitchyBallPrice)
            {
                ballsPurchased += 1;
                audioManager.Play("PurchaseBall");
                glitchyBallPurchased = true;
                points -= glitchyBallPrice;
                SetTotalGoldSpent(glitchyBallPrice);
                glitchyBallButton.interactable = true;
                ball22UnlockedFrame.SetActive(true);
                ball22PriceLockedFrame.SetActive(false);
                CheckNewBallACH();
                if (isBall22AutoTurnedOff == true) { FrameColor(21, true); }
                else { FrameColor(21, false); }
                pointsScript.CheckWhichBallsToSpawnText();
                return;
            }
            #endregion
        }

        CantAfford();
    }
    #endregion

    #region Purchase 1 Ball
    public void PurchasePluss1Ball()
    {
        if (isMax == false) { maxPluss1BallUpgradeCount = 1; }

        #region Ball 1
        if (currentBallFrame == 1)
        {
            if(points >= regularBallPluss1Price && totalRegularBalls < 10)
            {
                PurchaseSounds();

                for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                {
                    if(totalRegularBalls < 10)
                    {
                        points -= regularBallPluss1Price;
                        SetTotalGoldSpent(regularBallPluss1Price);

                        regularBallPluss1Price *= ballPriceIcrease;
                        ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(regularBallPluss1Price);

                        totalRegularBalls += 1;
                        MainShooter.basicBallsAvailable += 1;

                        if (totalRegularBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                        else { ballFramePurchaseBallText.text = $"{totalRegularBalls} (+1)"; }

                        if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.basicBallsAvailable); }

                        RoundToNearestWhole(regularBallPluss1Price);
                        regularBallPluss1Price = currentDouble;
                    }
                }

                return;
            }
        }
        #endregion

        #region Ball 2
        if (currentBallFrame == 2)
        {
            if(points >= redBallPluss1Price && totalRedBalls < 10)
            {
                PurchaseSounds();

                for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                {
                    if (totalRedBalls < 10)
                    {
                        points -= redBallPluss1Price;
                        SetTotalGoldSpent(redBallPluss1Price);

                        redBallPluss1Price *= ballPriceIcrease;
                        ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(redBallPluss1Price);

                        totalRedBalls += 1;

                        if (totalRedBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                        else { ballFramePurchaseBallText.text = $"{totalRedBalls} (+1)"; }

                        MainShooter.redBallsAviable += 1;

                        if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.redBallsAviable); }

                        RoundToNearestWhole(redBallPluss1Price);
                        redBallPluss1Price = currentDouble;
                    }
                }
               
                return;
            }
        }
        #endregion

        #region Ball 3
        if (currentBallFrame == 3)
        {
            if (points >= rockBallPluss1Price && totalRockBalls < 10)
            {
                PurchaseSounds();

                for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                {
                    if (totalRockBalls < 10)
                    {
                        points -= rockBallPluss1Price;
                        SetTotalGoldSpent(rockBallPluss1Price);

                        rockBallPluss1Price *= ballPriceIcrease;
                        ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(rockBallPluss1Price);

                        totalRockBalls += 1;

                        if (totalRockBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                        else { ballFramePurchaseBallText.text = $"{totalRockBalls} (+1)"; }

                        MainShooter.rockBallsAviable += 1;

                        if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.rockBallsAviable); }

                        RoundToNearestWhole(rockBallPluss1Price);
                        rockBallPluss1Price = currentDouble;
                    }
                }

                return;
            }
        }
        #endregion

        #region Ball 4
        if (currentBallFrame == 4)
        {
            if (points >= bombBallPluss1Price && totalBombBalls < 10)
            {
                PurchaseSounds();

                for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                {
                    if (totalBombBalls < 10)
                    {
                        points -= bombBallPluss1Price;
                        SetTotalGoldSpent(bombBallPluss1Price);

                        bombBallPluss1Price *= ballPriceIcrease;
                        ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(bombBallPluss1Price);

                        totalBombBalls += 1;

                        if (totalBombBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                        else { ballFramePurchaseBallText.text = $"{totalBombBalls} (+1)"; }

                        MainShooter.bombBallsAviable += 1;

                        if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.bombBallsAviable); }

                        RoundToNearestWhole(bombBallPluss1Price);
                        bombBallPluss1Price = currentDouble;
                    }
                }

                return;
            }
        }
        #endregion 

        if(GameData.isDemo == false)
        {
            #region Aqua Ball
            if (currentBallFrame == 5)
            {
                if (points >= aquaBallPluss1Price && totalAquaBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalAquaBalls < 10)
                        {
                            points -= aquaBallPluss1Price;
                            SetTotalGoldSpent(aquaBallPluss1Price);

                            aquaBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(aquaBallPluss1Price);

                            totalAquaBalls += 1;

                            if (totalAquaBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalAquaBalls} (+1)"; }

                            MainShooter.aquaBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.aquaBallsAvailable); }

                            RoundToNearestWhole(aquaBallPluss1Price);
                            aquaBallPluss1Price = currentDouble;
                        }
                    }
                    return;
                }
            }
            #endregion

            #region Mud Ball
            if (currentBallFrame == 6)
            {
                if (points >= mudBallPluss1Price && totalMudBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalMudBalls < 10)
                        {
                            points -= mudBallPluss1Price;
                            SetTotalGoldSpent(mudBallPluss1Price);

                            mudBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(mudBallPluss1Price);

                            totalMudBalls += 1;

                            if (totalMudBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalMudBalls} (+1)"; }

                            MainShooter.mudBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.mudBallsAvailable); }

                            RoundToNearestWhole(mudBallPluss1Price);
                            mudBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Basket Ball
            if (currentBallFrame == 7)
            {
                if (points >= basketBallPluss1Price && totalBasketBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalBasketBalls < 10)
                        {
                            points -= basketBallPluss1Price;
                            SetTotalGoldSpent(basketBallPluss1Price);

                            basketBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(basketBallPluss1Price);

                            totalBasketBalls += 1;

                            if (totalBasketBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalBasketBalls} (+1)"; }

                            MainShooter.basketBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.basketBallsAvailable); }

                            RoundToNearestWhole(basketBallPluss1Price);
                            basketBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Plum Ball
            if (currentBallFrame == 8)
            {
                if (points >= plumBallPluss1Price && totalPlumBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalPlumBalls < 10)
                        {
                            points -= plumBallPluss1Price;
                            SetTotalGoldSpent(plumBallPluss1Price);

                            plumBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(plumBallPluss1Price);

                            totalPlumBalls += 1;

                            if (totalPlumBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalPlumBalls} (+1)"; }

                            MainShooter.plumBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.plumBallsAvailable); }

                            RoundToNearestWhole(plumBallPluss1Price);
                            plumBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Sticky Ball
            if (currentBallFrame == 9)
            {
                if (points >= stickyBallPluss1Price && totalStickyBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalStickyBalls < 10)
                        {
                            points -= stickyBallPluss1Price;
                            SetTotalGoldSpent(stickyBallPluss1Price);

                            stickyBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(stickyBallPluss1Price);

                            totalStickyBalls += 1;

                            if (totalStickyBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalStickyBalls} (+1)"; }

                            MainShooter.stickyBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.stickyBallsAvailable); }

                            RoundToNearestWhole(stickyBallPluss1Price);
                            stickyBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Sticky Ball
            if (currentBallFrame == 10)
            {
                if (points >= candyBallPluss1Price && totalCandyBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalCandyBalls < 10)
                        {
                            points -= candyBallPluss1Price;
                            SetTotalGoldSpent(candyBallPluss1Price);

                            candyBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(candyBallPluss1Price);

                            totalCandyBalls += 1;

                            if (totalCandyBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalCandyBalls} (+1)"; }

                            MainShooter.candyBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.candyBallsAvailable); }

                            RoundToNearestWhole(candyBallPluss1Price);
                            candyBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Candy Ball
            if (currentBallFrame == 11)
            {
                if (points >= cookieBallPluss1Price && totalCookieBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalCookieBalls < 10)
                        {
                            points -= cookieBallPluss1Price;
                            SetTotalGoldSpent(cookieBallPluss1Price);

                            cookieBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(cookieBallPluss1Price);

                            totalCookieBalls += 1;

                            if (totalCookieBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalCookieBalls} (+1)"; }

                            MainShooter.cookieBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.cookieBallsAvailable); }

                            RoundToNearestWhole(cookieBallPluss1Price);
                            cookieBallPluss1Price = currentDouble;
                        }
                    }
                     
                    return;
                }
            }
            #endregion

            #region Lime Ball
            if (currentBallFrame == 12)
            {
                if (points >= limeBallPluss1Price && totalLimeBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalLimeBalls < 10)
                        {
                            points -= limeBallPluss1Price;
                            SetTotalGoldSpent(limeBallPluss1Price);

                            limeBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(limeBallPluss1Price);

                            totalLimeBalls += 1;

                            if (totalLimeBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalLimeBalls} (+1)"; }

                            MainShooter.limeBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.limeBallsAvailable); }

                            RoundToNearestWhole(limeBallPluss1Price);
                            limeBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Golden Ball
            if (currentBallFrame == 13)
            {
                if (points >= goldenBallPluss1Price && totalGoldenBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalGoldenBalls < 10)
                        {
                            points -= goldenBallPluss1Price;
                            SetTotalGoldSpent(goldenBallPluss1Price);

                            goldenBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenBallPluss1Price);

                            totalGoldenBalls += 1;

                            if (totalGoldenBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalGoldenBalls} (+1)"; }

                            MainShooter.goldenBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.goldenBallsAvailable); }

                            RoundToNearestWhole(goldenBallPluss1Price);
                            goldenBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Football Ball
            if (currentBallFrame == 14)
            {
                if (points >= footballBallPluss1Price && totalFootballBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalFootballBalls < 10)
                        {
                            points -= footballBallPluss1Price;
                            SetTotalGoldSpent(footballBallPluss1Price);

                            footballBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(footballBallPluss1Price);

                            totalFootballBalls += 1;

                            if (totalFootballBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalFootballBalls} (+1)"; }

                            MainShooter.footballBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.footballBallsAvailable); }

                            RoundToNearestWhole(footballBallPluss1Price);
                            footballBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Sharpnel Ball
            if (currentBallFrame == 15)
            {
                if (points >= sharpnelBallPluss1Price && totalSharpnelBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalSharpnelBalls < 10)
                        {
                            points -= sharpnelBallPluss1Price;
                            SetTotalGoldSpent(sharpnelBallPluss1Price);

                            sharpnelBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(sharpnelBallPluss1Price);

                            totalSharpnelBalls += 1;

                            if (totalSharpnelBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalSharpnelBalls} (+1)"; }

                            MainShooter.sharpnelBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.sharpnelBallsAvailable); }

                            RoundToNearestWhole(sharpnelBallPluss1Price);
                            sharpnelBallPluss1Price = currentDouble;
                        }
                           
                    }

                    return;
                }
            }
            #endregion

            #region Zonic Ball
            if (currentBallFrame == 16)
            {
                if (points >= zonicBallPluss1Price && totalZonicBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalZonicBalls < 10)
                        {
                            points -= zonicBallPluss1Price;
                            SetTotalGoldSpent(zonicBallPluss1Price);

                            zonicBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(zonicBallPluss1Price);

                            totalZonicBalls += 1;

                            if (totalZonicBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalZonicBalls} (+1)"; }

                            MainShooter.zonicBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.zonicBallsAvailable); }

                            RoundToNearestWhole(zonicBallPluss1Price);
                            zonicBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Apricot Ball
            if (currentBallFrame == 17)
            {
                if (points >= apricotBallPluss1Price && totalApricotBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalApricotBalls < 10)
                        {
                            points -= apricotBallPluss1Price;
                            SetTotalGoldSpent(apricotBallPluss1Price);

                            apricotBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(apricotBallPluss1Price);

                            totalApricotBalls += 1;

                            if (totalApricotBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalApricotBalls} (+1)"; }

                            MainShooter.apricotBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.apricotBallsAvailable); }

                            RoundToNearestWhole(apricotBallPluss1Price);
                            apricotBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Peggo Ball
            if (currentBallFrame == 18)
            {
                if (points >= peggoBallPluss1Price && totalPeggoBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalPeggoBalls < 10)
                        {
                            points -= peggoBallPluss1Price;
                            SetTotalGoldSpent(peggoBallPluss1Price);

                            peggoBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(peggoBallPluss1Price);

                            totalPeggoBalls += 1;

                            if (totalPeggoBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalPeggoBalls} (+1)"; }

                            MainShooter.peggoBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.peggoBallsAvailable); }

                            RoundToNearestWhole(peggoBallPluss1Price);
                            peggoBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Ghost Ball
            if (currentBallFrame == 19)
            {
                if (points >= ghostBallPluss1Price && totalGhostBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalGhostBalls < 10)
                        {
                            points -= ghostBallPluss1Price;
                            SetTotalGoldSpent(ghostBallPluss1Price);

                            ghostBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(ghostBallPluss1Price);

                            totalGhostBalls += 1;

                            if (totalGhostBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalGhostBalls} (+1)"; }

                            MainShooter.ghostBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.ghostBallsAvailable); }

                            RoundToNearestWhole(ghostBallPluss1Price);
                            ghostBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Star Ball
            if (currentBallFrame == 20)
            {
                if (points >= starBallPluss1Price && totalStarBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalStarBalls < 10)
                        {
                            points -= starBallPluss1Price;
                            SetTotalGoldSpent(starBallPluss1Price);

                            starBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(starBallPluss1Price);

                            totalStarBalls += 1;

                            if (totalStarBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalStarBalls} (+1)"; }

                            MainShooter.starBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.starBallsAvailable); }

                            RoundToNearestWhole(starBallPluss1Price);
                            starBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Rainbow Ball
            if (currentBallFrame == 21)
            {
                if (points >= rainbowBallPluss1Price && totalRainbowBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalRainbowBalls < 10)
                        {
                            points -= rainbowBallPluss1Price;
                            SetTotalGoldSpent(rainbowBallPluss1Price);

                            rainbowBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(rainbowBallPluss1Price);

                            totalRainbowBalls += 1;

                            if (totalRainbowBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalRainbowBalls} (+1)"; }

                            MainShooter.rainbowBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.rainbowBallsAvailable); }

                            RoundToNearestWhole(rainbowBallPluss1Price);
                            rainbowBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion

            #region Glitchy Ball
            if (currentBallFrame == 22)
            {
                if (points >= glitchyBallPluss1Price && totalGlitchyBalls < 10)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxPluss1BallUpgradeCount; i++)
                    {
                        if (totalGlitchyBalls < 10)
                        {
                            points -= glitchyBallPluss1Price;
                            SetTotalGoldSpent(glitchyBallPluss1Price);

                            glitchyBallPluss1Price *= ballPriceIcrease;
                            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(glitchyBallPluss1Price);

                            totalGlitchyBalls += 1;

                            if (totalGlitchyBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                            else { ballFramePurchaseBallText.text = $"{totalGlitchyBalls} (+1)"; }

                            MainShooter.glitchyBallsAvailable += 1;

                            if (ballNumberEquipped == currentBallFrame) { SetActiveBalls(MainShooter.glitchyBallsAvailable); }

                            RoundToNearestWhole(glitchyBallPluss1Price);
                            glitchyBallPluss1Price = currentDouble;
                        }
                    }

                    return;
                }
            }
            #endregion
        }

        CantAfford();
    }
    #endregion

    #region Purchase Auto Ball
    public static bool isRegularBallAutoPurchased, isRedBallAutoPurchased, isRockBallAutoPurchased, isBombBallAutoPurchased, isAquaBallAutoPurchased, isMudBallAutoPurchased, isBasketBallAutoPurchased, isPlumBallAutoPurchased, isStickyBallAutoPurchased, isCandyBallAutoPurchased,isCookieBallAutoPurchased,isLimeBallAutoPurchased,isGoldenBallAutoPurchased,isFootballBallAutoPurchased,isSharpnelBallAutoPurchased,isZonicBallAutoPurchased,isApricotBallAutoPurchased,isPeggoBallAutoPurchased,isGhostBallAutoPurchased,isStarBallAutoPurchased,isRainbowBallAutoPurchased,isGlitchyBallAutoPurchased;

    public static float basicBallAutoDropTime, redBallAutoDropTime, rockBallAutoDropTime, bombBallAutoDropTime, aquaBallAutoDropTime, mudBallAutoDropTime, basketBallAutoDropTime, plumBallAutoDropTime, stickyBallAutoDropTime, candyBallAutoDropTime, cookieBallAutoDropTime, limeBallAutoDropTime, goldenBallAutoDropTime, footballBallAutoDropTime, sharpnelBallAutoDropTime, zonicBallAutoDropTime, apricotBallAutoDropTime, peggoBallAutoDropTime, ghostBallAutoDropTime, starBallAutoDropTime, rainbowBallAutoDropTime, glitchyBallAutoDropTime;

    public static float regularBallAutoDivide, redBallAutoDivide, rockBallDivide, bombBallDivide;

    public float currentEquippedDropTime;

    public MainShooter mainShooterScript;


    public void PurchaseAutoBall()
    {
        if(isMax == false) { maxAutoUpgradeCount = 1; }

        #region Ball 1 auto
        if (currentBallFrame == 1)
        {
            if(points >= regularBallAutoPrice && basicBallAutoDropTime > minAutoDrop)
            {
                autoNotPurchased = false;
                PurchaseSounds();

                for (int i = 0; i < maxAutoUpgradeCount; i++)
                {
                    points -= regularBallAutoPrice;
                    SetTotalGoldSpent(regularBallAutoPrice);

                    regularBallAutoPrice *= autoPriceIncrease;
                    ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(regularBallAutoPrice);

                    if (isRegularBallAutoPurchased == true)
                    {
                        basicBallAutoDropTime -= basicBallAutoDropTime / regularBallAutoDivide;
                    }
                    else
                    {
                        isRegularBallAutoPurchased = true;
                        mainShooterScript.Auto1();
                    }

                    ballFrameAutoDropText.text = $"{basicBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(basicBallAutoDropTime / regularBallAutoDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                    if (currentBallFrame == ballNumberEquipped)
                    {
                        currentEquippedDropTime = basicBallAutoDropTime;
                        SetTextForAuto(currentEquippedDropTime);
                    }

                    CheckAutoDropTime(currentBallFrame, true);
                    RoundToNearestWhole(regularBallAutoPrice);
                    regularBallAutoPrice = currentDouble;
                    SetTextSpawnChance(false, true);
                }

                return;
            }
        }
        #endregion

        #region Ball 2 auto
        if (currentBallFrame == 2)
        {
            if (points >= redBallAutoPrice && redBallAutoDropTime > minAutoDrop)
            {
                autoNotPurchased = false;
                PurchaseSounds();

                for (int i = 0; i < maxAutoUpgradeCount; i++)
                {
                    points -= redBallAutoPrice;
                    SetTotalGoldSpent(redBallAutoPrice);

                    redBallAutoPrice *= autoPriceIncrease;
                    ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(redBallAutoPrice);

                    if (isRedBallAutoPurchased == true)
                    {
                        redBallAutoDropTime -= redBallAutoDropTime / redBallAutoDivide;
                    }
                    else
                    {
                        isRedBallAutoPurchased = true;
                        mainShooterScript.Auto2();
                    }

                    ballFrameAutoDropText.text = $"{redBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(redBallAutoDropTime / redBallAutoDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                    if (currentBallFrame == ballNumberEquipped)
                    {
                        currentEquippedDropTime = redBallAutoDropTime;
                        SetTextForAuto(currentEquippedDropTime);
                    }

                    CheckAutoDropTime(currentBallFrame, true);
                    RoundToNearestWhole(redBallAutoPrice);
                    redBallAutoPrice = currentDouble;
                    SetTextSpawnChance(false, true);
                }

                return;
            }
        }
        #endregion

        #region Ball 3 auto
        if (currentBallFrame == 3)
        {
            if (points >= rockBallAutoPrice && rockBallAutoDropTime > minAutoDrop)
            {
                autoNotPurchased = false;
                PurchaseSounds();

                for (int i = 0; i < maxAutoUpgradeCount; i++)
                {
                    points -= rockBallAutoPrice;
                    SetTotalGoldSpent(rockBallAutoPrice);

                    rockBallAutoPrice *= autoPriceIncrease;
                    ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(rockBallAutoPrice);

                    if (isRockBallAutoPurchased == true)
                    {
                        rockBallAutoDropTime -= rockBallAutoDropTime / rockBallDivide;
                    }
                    else
                    {
                        isRockBallAutoPurchased = true;
                        mainShooterScript.Auto3();
                    }

                    ballFrameAutoDropText.text = $"{rockBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(rockBallAutoDropTime / rockBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                    if (currentBallFrame == ballNumberEquipped)
                    {
                        currentEquippedDropTime = rockBallAutoDropTime;
                        SetTextForAuto(currentEquippedDropTime);
                    }

                    CheckAutoDropTime(currentBallFrame, true);
                    RoundToNearestWhole(rockBallAutoPrice);
                    rockBallAutoPrice = currentDouble;
                    SetTextSpawnChance(false, true);
                }

                return;
            }
        }
        #endregion

        #region Ball 4 auto
        if (currentBallFrame == 4)
        {
            if (points >= bombBallAutoPrice && bombBallAutoDropTime > minAutoDrop)
            {
                autoNotPurchased = false;
                PurchaseSounds();

                for (int i = 0; i < maxAutoUpgradeCount; i++)
                {
                    points -= bombBallAutoPrice;
                    SetTotalGoldSpent(bombBallAutoPrice);

                    bombBallAutoPrice *= autoPriceIncrease;
                    ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(bombBallAutoPrice);

                    if (isBombBallAutoPurchased == true)
                    {
                        bombBallAutoDropTime -= bombBallAutoDropTime / bombBallDivide;
                    }
                    else
                    {
                        isBombBallAutoPurchased = true;
                        mainShooterScript.Auto4();
                    }

                    ballFrameAutoDropText.text = $"{bombBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(bombBallAutoDropTime / bombBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                    if (currentBallFrame == ballNumberEquipped)
                    {
                        currentEquippedDropTime = bombBallAutoDropTime;
                        SetTextForAuto(currentEquippedDropTime);
                    }

                    CheckAutoDropTime(currentBallFrame, true);
                    RoundToNearestWhole(bombBallAutoPrice);
                    bombBallAutoPrice = currentDouble;
                    SetTextSpawnChance(false, true);
                }

                return;
            }
        }
        #endregion

        if(GameData.isDemo == false)
        {
            #region Aqua Ball 5 Auto
            if (ballNumber == 5)
            {
                if (points >= aquaBallAutoPrice && aquaBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= aquaBallAutoPrice;
                        SetTotalGoldSpent(aquaBallAutoPrice);

                        aquaBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(aquaBallAutoPrice);

                        if (isAquaBallAutoPurchased == true)
                        {
                            aquaBallAutoDropTime -= aquaBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isAquaBallAutoPurchased = true;
                            mainShooterScript.Auto5();
                        }

                        ballFrameAutoDropText.text = $"{aquaBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(aquaBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = aquaBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(aquaBallAutoPrice);
                        aquaBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Mud Ball 6 auto
            if (currentBallFrame == 6)
            {
                if (points >= mudBallAutoPrice && mudBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= mudBallAutoPrice;
                        SetTotalGoldSpent(mudBallAutoPrice);

                        mudBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(mudBallAutoPrice);

                        if (isMudBallAutoPurchased == true)
                        {
                            mudBallAutoDropTime -= mudBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isMudBallAutoPurchased = true;
                            mainShooterScript.Auto6();
                        }

                        ballFrameAutoDropText.text = $"{mudBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(mudBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = mudBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(mudBallAutoPrice);
                        mudBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Basket Ball 7 auto
            if (currentBallFrame == 7)
            {
                if (points >= basketBallAutoPrice && basketBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= basketBallAutoPrice;
                        SetTotalGoldSpent(basketBallAutoPrice);

                        basketBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(basketBallAutoPrice);

                        if (isBasketBallAutoPurchased == true)
                        {
                            basketBallAutoDropTime -= basketBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isBasketBallAutoPurchased = true;
                            mainShooterScript.Auto7();
                        }

                        ballFrameAutoDropText.text = $"{basketBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(basketBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = basketBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(basketBallAutoPrice);
                        basketBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Plum Ball 8 auto
            if (currentBallFrame == 8)
            {
                if (points >= plumBallAutoPrice && plumBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= plumBallAutoPrice;
                        SetTotalGoldSpent(plumBallAutoPrice);

                        plumBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(plumBallAutoPrice);

                        if (isPlumBallAutoPurchased == true)
                        {
                            plumBallAutoDropTime -= plumBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isPlumBallAutoPurchased = true;
                            mainShooterScript.Auto8();
                        }

                        ballFrameAutoDropText.text = $"{plumBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(plumBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = plumBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(plumBallAutoPrice);
                        plumBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Sticky Ball 9 auto
            if (currentBallFrame == 9)
            {
                if (points >= stickyBallAutoPrice && stickyBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= stickyBallAutoPrice;
                        SetTotalGoldSpent(stickyBallAutoPrice);

                        stickyBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(stickyBallAutoPrice);

                        if (isStickyBallAutoPurchased == true)
                        {
                            stickyBallAutoDropTime -= stickyBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isStickyBallAutoPurchased = true;
                            mainShooterScript.Auto9();
                        }

                        ballFrameAutoDropText.text = $"{stickyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(stickyBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = stickyBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(stickyBallAutoPrice);
                        stickyBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Candy Ball auto
            if (currentBallFrame == 10)
            {
                if (points >= candyBallAutoPrice && candyBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= candyBallAutoPrice;
                        SetTotalGoldSpent(candyBallAutoPrice);

                        candyBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(candyBallAutoPrice);

                        if (isCandyBallAutoPurchased == true)
                        {
                            candyBallAutoDropTime -= candyBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isCandyBallAutoPurchased = true;
                            mainShooterScript.Auto10();
                        }

                        ballFrameAutoDropText.text = $"{candyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(candyBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = candyBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(candyBallAutoPrice);
                        candyBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Cookie Ball auto
            if (currentBallFrame == 11)
            {
                if (points >= cookieBallAutoPrice && cookieBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= cookieBallAutoPrice;
                        SetTotalGoldSpent(cookieBallAutoPrice);

                        cookieBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(cookieBallAutoPrice);

                        if (isCookieBallAutoPurchased == true)
                        {
                            cookieBallAutoDropTime -= cookieBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isCookieBallAutoPurchased = true;
                            mainShooterScript.Auto11();
                        }

                        ballFrameAutoDropText.text = $"{cookieBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(cookieBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = cookieBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(cookieBallAutoPrice);
                        cookieBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Lime Ball auto
            if (currentBallFrame == 12)
            {
                if (points >= limeBallAutoPrice && limeBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++) 
                    {
                        points -= limeBallAutoPrice;
                        SetTotalGoldSpent(limeBallAutoPrice);

                        limeBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(limeBallAutoPrice);

                        if (isLimeBallAutoPurchased == true)
                        {
                            limeBallAutoDropTime -= limeBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isLimeBallAutoPurchased = true;
                            mainShooterScript.Auto12();
                        }

                        ballFrameAutoDropText.text = $"{limeBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(limeBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = limeBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(limeBallAutoPrice);
                        limeBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Golden Ball auto
            if (currentBallFrame == 13)
            {
                if (points >= goldenBallAutoPrice && goldenBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= goldenBallAutoPrice;
                        SetTotalGoldSpent(goldenBallAutoPrice);

                        goldenBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenBallAutoPrice);

                        if (isGoldenBallAutoPurchased == true)
                        {
                            goldenBallAutoDropTime -= goldenBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isGoldenBallAutoPurchased = true;
                            mainShooterScript.Auto13();
                        }

                        ballFrameAutoDropText.text = $"{goldenBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(goldenBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = goldenBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(goldenBallAutoPrice);
                        goldenBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }
                      
                    return;
                }
            }
            #endregion

            #region Football Ball auto
            if (currentBallFrame == 14)
            {
                if (points >= footballBallAutoPrice && footballBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= footballBallAutoPrice;
                        SetTotalGoldSpent(footballBallAutoPrice);

                        footballBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(footballBallAutoPrice);

                        if (isFootballBallAutoPurchased == true)
                        {
                            footballBallAutoDropTime -= footballBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isFootballBallAutoPurchased = true;
                            mainShooterScript.Auto14();
                        }

                        ballFrameAutoDropText.text = $"{footballBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(footballBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = footballBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(footballBallAutoPrice);
                        footballBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Sharpnel Ball auto
            if (currentBallFrame == 15)
            {
                if (points >= sharpnelBallAutoPrice && sharpnelBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= sharpnelBallAutoPrice;
                        SetTotalGoldSpent(sharpnelBallAutoPrice);

                        sharpnelBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(sharpnelBallAutoPrice);

                        if (isSharpnelBallAutoPurchased == true)
                        {
                            sharpnelBallAutoDropTime -= sharpnelBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isSharpnelBallAutoPurchased = true;
                            mainShooterScript.Auto15();
                        }

                        ballFrameAutoDropText.text = $"{sharpnelBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(sharpnelBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = sharpnelBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(sharpnelBallAutoPrice);
                        sharpnelBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Zonic Ball auto
            if (currentBallFrame == 16)
            {
                if (points >= zonicBallAutoPrice && zonicBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= zonicBallAutoPrice;
                        SetTotalGoldSpent(zonicBallAutoPrice);

                        zonicBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(zonicBallAutoPrice);

                        if (isZonicBallAutoPurchased == true)
                        {
                            zonicBallAutoDropTime -= zonicBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isZonicBallAutoPurchased = true;
                            mainShooterScript.Auto16();
                        }

                        ballFrameAutoDropText.text = $"{zonicBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(zonicBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = zonicBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(zonicBallAutoPrice);
                        zonicBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Apricot Ball auto
            if (currentBallFrame == 17)
            {
                if (points >= apricotBallAutoPrice && apricotBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= apricotBallAutoPrice;
                        SetTotalGoldSpent(apricotBallAutoPrice);

                        apricotBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(apricotBallAutoPrice);

                        if (isApricotBallAutoPurchased == true)
                        {
                            apricotBallAutoDropTime -= apricotBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isApricotBallAutoPurchased = true;
                            mainShooterScript.Auto17();
                        }

                        ballFrameAutoDropText.text = $"{apricotBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(apricotBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = apricotBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(apricotBallAutoPrice);
                        apricotBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Peggo Ball auto
            if (currentBallFrame == 18)
            {
                if (points >= peggoBallAutoPrice && peggoBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= peggoBallAutoPrice;
                        SetTotalGoldSpent(peggoBallAutoPrice);

                        peggoBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(peggoBallAutoPrice);

                        if (isPeggoBallAutoPurchased == true)
                        {
                            peggoBallAutoDropTime -= peggoBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isPeggoBallAutoPurchased = true;
                            mainShooterScript.Auto18();
                        }

                        ballFrameAutoDropText.text = $"{peggoBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(peggoBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = peggoBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(peggoBallAutoPrice);
                        peggoBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Ghost Ball auto
            if (currentBallFrame == 19)
            {
                if (points >= ghostBallAutoPrice && ghostBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= ghostBallAutoPrice;
                        SetTotalGoldSpent(ghostBallAutoPrice);

                        ghostBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(ghostBallAutoPrice);

                        if (isGhostBallAutoPurchased == true)
                        {
                            ghostBallAutoDropTime -= ghostBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isGhostBallAutoPurchased = true;
                            mainShooterScript.Auto19();
                        }

                        ballFrameAutoDropText.text = $"{ghostBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(ghostBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = ghostBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(ghostBallAutoPrice);
                        ghostBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Star Ball auto
            if (currentBallFrame == 20)
            {
                if (points >= starBallAutoPrice && starBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= starBallAutoPrice;
                        SetTotalGoldSpent(starBallAutoPrice);

                        starBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(starBallAutoPrice);

                        if (isStarBallAutoPurchased == true)
                        {
                            starBallAutoDropTime -= starBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isStarBallAutoPurchased = true;
                            mainShooterScript.Auto20();
                        }

                        ballFrameAutoDropText.text = $"{starBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(starBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = starBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(starBallAutoPrice);
                        starBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Rainbow Ball auto
            if (currentBallFrame == 21)
            {
                if (points >= rainbowBallAutoPrice && rainbowBallAutoDropTime > minAutoDrop)
                {
                    autoNotPurchased = false;
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= rainbowBallAutoPrice;
                        SetTotalGoldSpent(rainbowBallAutoPrice);

                        rainbowBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(rainbowBallAutoPrice);

                        if (isRainbowBallAutoPurchased == true)
                        {
                            rainbowBallAutoDropTime -= rainbowBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isRainbowBallAutoPurchased = true;
                            mainShooterScript.Auto21();
                        }

                        ballFrameAutoDropText.text = $"{rainbowBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(rainbowBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";


                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = rainbowBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(rainbowBallAutoPrice);
                        rainbowBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }

                    return;
                }
            }
            #endregion

            #region Glitchy Ball auto
            if (currentBallFrame == 22)
            {
                autoNotPurchased = false;
                if (points >= glitchyBallAutoPrice && glitchyBallAutoDropTime > minAutoDrop)
                {
                    PurchaseSounds();

                    for (int i = 0; i < maxAutoUpgradeCount; i++)
                    {
                        points -= glitchyBallAutoPrice;
                        SetTotalGoldSpent(glitchyBallAutoPrice);

                        glitchyBallAutoPrice *= autoPriceIncrease;
                        ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(glitchyBallAutoPrice);

                        if (isGlitchyBallAutoPurchased == true)
                        {
                            glitchyBallAutoDropTime -= glitchyBallAutoDropTime / allBallDivide;
                        }
                        else
                        {
                            isGlitchyBallAutoPurchased = true;
                            mainShooterScript.Auto22();
                        }

                        ballFrameAutoDropText.text = $"{glitchyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(glitchyBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})";

                        if (currentBallFrame == ballNumberEquipped)
                        {
                            currentEquippedDropTime = glitchyBallAutoDropTime;
                            SetTextForAuto(currentEquippedDropTime);
                        }

                        CheckAutoDropTime(currentBallFrame, true);
                        RoundToNearestWhole(glitchyBallAutoPrice);
                        glitchyBallAutoPrice = currentDouble;
                        SetTextSpawnChance(false, true);
                    }
                      
                    return;
                }
            }
            #endregion
        }

        CantAfford();
    }

    public void SetTextForAuto(float ballAutoDropTime)
    {
        ballAutoDropTimeText.text = ballAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation;
    }
    #endregion

    #region ToggleAutoDrop
    public GameObject autoOffObject, autoOnObject;

    public static bool isBall1AutoTurnedOff, isBall2AutoTurnedOff, isBall3AutoTurnedOff, isBall4AutoTurnedOff, isBall5AutoTurnedOff, isBall6AutoTurnedOff, isBall7AutoTurnedOff, isBall8AutoTurnedOff, isBall9AutoTurnedOff, isBall10AutoTurnedOff, isBall11AutoTurnedOff, isBall12AutoTurnedOff, isBall13AutoTurnedOff, isBall14AutoTurnedOff, isBall15AutoTurnedOff, isBall16AutoTurnedOff, isBall17AutoTurnedOff, isBall18AutoTurnedOff, isBall19AutoTurnedOff, isBall20AutoTurnedOff, isBall21AutoTurnedOff, isBall22AutoTurnedOff;
    
    public void ToggleAutoDrop(int ballNumber)
    {
        audioManager.Play("UIClick1");

        if (currentBallFrame == 1) 
        {
            if(isBall1AutoTurnedOff == false) { isBall1AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(0,true); }
            else { isBall1AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(0, false); }
        }
        if (currentBallFrame == 2)
        {
            if (isBall2AutoTurnedOff == false) { isBall2AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(1, true); }
            else { isBall2AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(1, false); }
        }
        if (currentBallFrame == 3)
        {
            if (isBall3AutoTurnedOff == false) { isBall3AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(2, true); }
            else { isBall3AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(2, false); }
        }
        if (currentBallFrame == 4)
        {
            if (isBall4AutoTurnedOff == false) { isBall4AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(3, true); }
            else { isBall4AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(3, false); }
        }
        if (currentBallFrame == 5)
        {
            if (isBall5AutoTurnedOff == false) { isBall5AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(4, true); }
            else { isBall5AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(4, false); }
        }
        if (currentBallFrame == 6)
        {
            if (isBall6AutoTurnedOff == false) { isBall6AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(5, true); }
            else { isBall6AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(5, false); }
        }
        if (currentBallFrame == 7)
        {
            if (isBall7AutoTurnedOff == false) { isBall7AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(6, true); }
            else { isBall7AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(6, false); }
        }
        if (currentBallFrame == 8)
        {
            if (isBall8AutoTurnedOff == false) { isBall8AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(7, true); }
            else { isBall8AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(7, false); }
        }
        if (currentBallFrame == 9)
        {
            if (isBall9AutoTurnedOff == false) { isBall9AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(8, true); }
            else { isBall9AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(8, false); }
        }
        if (currentBallFrame == 10)
        {
            if (isBall10AutoTurnedOff == false) { isBall10AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(9, true); }
            else { isBall10AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(9, false); }
        }
        if (currentBallFrame == 11)
        {
            if (isBall11AutoTurnedOff == false) { isBall11AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(10, true); }
            else { isBall11AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(10, false); }
        }
        if (currentBallFrame == 12)
        {
            if (isBall12AutoTurnedOff == false) { isBall12AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(11, true); }
            else { isBall12AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(11, false); }
        }
        if (currentBallFrame == 13)
        {
            if (isBall13AutoTurnedOff == false) { isBall13AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(12, true); }
            else { isBall13AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(12, false); }
        }
        if (currentBallFrame == 14)
        {
            if (isBall14AutoTurnedOff == false) { isBall14AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(13, true); }
            else { isBall14AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(13, false); }
        }
        if (currentBallFrame == 15)
        {
            if (isBall15AutoTurnedOff == false) { isBall15AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(14, true); }
            else { isBall15AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(14, false); }
        }
        if (currentBallFrame == 16)
        {
            if (isBall16AutoTurnedOff == false) { isBall16AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(15, true); }
            else { isBall16AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(15, false); }
        }
        if (currentBallFrame == 17)
        {
            if (isBall17AutoTurnedOff == false) { isBall17AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(16, true); }
            else { isBall17AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(16, false); }
        }
        if (currentBallFrame == 18)
        {
            if (isBall18AutoTurnedOff == false) { isBall18AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(17, true); }
            else { isBall18AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(17, false); }
        }
        if (currentBallFrame == 19)
        {
            if (isBall19AutoTurnedOff == false) { isBall19AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(18, true); }
            else { isBall19AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(18, false); }
        }
        if (currentBallFrame == 20)
        {
            if (isBall20AutoTurnedOff == false) { isBall20AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(19, true); }
            else { isBall20AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(19, false); }
        }
        if (currentBallFrame == 21)
        {
            if (isBall21AutoTurnedOff == false) { isBall21AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(20, true); }
            else { isBall21AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(20, false); }
        }
        if (currentBallFrame == 22)
        {
            if (isBall22AutoTurnedOff == false) { isBall22AutoTurnedOff = true; SetAutoToggleObjects(true); FrameColor(21, true); }
            else { isBall22AutoTurnedOff = false; SetAutoToggleObjects(false); FrameColor(21, false); }
        }

        SetTextSpawnChance(false, false);
    }

    public void RightClickToggle(int ballNumber)
    {
        audioManager.Play("UIClick1");

        if (ballNumber == 1)
        {
            if (isBall1AutoTurnedOff == false) { isBall1AutoTurnedOff = true;  FrameColor(0, true); }
            else { isBall1AutoTurnedOff = false; FrameColor(0, false); }
            if( ballNumber == currentBallFrame && isBall1AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall1AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 2)
        {
            if (isBall2AutoTurnedOff == false) { isBall2AutoTurnedOff = true; FrameColor(1, true); }
            else { isBall2AutoTurnedOff = false; FrameColor(1, false); }
            if (ballNumber == currentBallFrame && isBall2AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall2AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 3)
        {
            if (isBall3AutoTurnedOff == false) { isBall3AutoTurnedOff = true; FrameColor(2, true); }
            else { isBall3AutoTurnedOff = false; FrameColor(2, false); }
            if (ballNumber == currentBallFrame && isBall3AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall3AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if ( ballNumber == 4)
        {
            if (isBall4AutoTurnedOff == false) { isBall4AutoTurnedOff = true; FrameColor(3, true); }
            else { isBall4AutoTurnedOff = false; FrameColor(3, false); }
            if (ballNumber == currentBallFrame && isBall4AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall4AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 5)
        {
            if (isBall5AutoTurnedOff == false) { isBall5AutoTurnedOff = true; FrameColor(4, true); }
            else { isBall5AutoTurnedOff = false; FrameColor(4, false); }
            if (ballNumber == currentBallFrame && isBall5AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall5AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 6)
        {
            if (isBall6AutoTurnedOff == false) { isBall6AutoTurnedOff = true; FrameColor(5, true); }
            else { isBall6AutoTurnedOff = false; FrameColor(5, false); }
            if (ballNumber == currentBallFrame && isBall6AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall6AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 7)
        {
            if (isBall7AutoTurnedOff == false) { isBall7AutoTurnedOff = true; FrameColor(6, true); }
            else { isBall7AutoTurnedOff = false; FrameColor(6, false); }
            if (ballNumber == currentBallFrame && isBall7AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall7AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 8)
        {
            if (isBall8AutoTurnedOff == false) { isBall8AutoTurnedOff = true; FrameColor(7, true); }
            else { isBall8AutoTurnedOff = false; FrameColor(7, false); }
            if (ballNumber == currentBallFrame && isBall8AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall8AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 9)
        {
            if (isBall9AutoTurnedOff == false) { isBall9AutoTurnedOff = true;  FrameColor(8, true); }
            else { isBall9AutoTurnedOff = false;  FrameColor(8, false); }
            if (ballNumber == currentBallFrame && isBall9AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall9AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 10)
        {
            if (isBall10AutoTurnedOff == false) { isBall10AutoTurnedOff = true;  FrameColor(9, true); }
            else { isBall10AutoTurnedOff = false;  FrameColor(9, false); }
            if (ballNumber == currentBallFrame && isBall10AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall10AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 11)
        {
            if (isBall11AutoTurnedOff == false) { isBall11AutoTurnedOff = true;  FrameColor(10, true); }
            else { isBall11AutoTurnedOff = false;  FrameColor(10, false); }
            if (ballNumber == currentBallFrame && isBall11AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall11AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 12)
        {
            if (isBall12AutoTurnedOff == false) { isBall12AutoTurnedOff = true;  FrameColor(11, true); }
            else { isBall12AutoTurnedOff = false;  FrameColor(11, false); }
            if (ballNumber == currentBallFrame && isBall12AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall12AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 13)
        {
            if (isBall13AutoTurnedOff == false) { isBall13AutoTurnedOff = true; FrameColor(12, true); }
            else { isBall13AutoTurnedOff = false;  FrameColor(12, false); }
            if (ballNumber == currentBallFrame && isBall13AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall13AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 14)
        {
            if (isBall14AutoTurnedOff == false) { isBall14AutoTurnedOff = true;  FrameColor(13, true); }
            else { isBall14AutoTurnedOff = false;  FrameColor(13, false); }
            if (ballNumber == currentBallFrame && isBall14AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall14AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 15)
        {
            if (isBall15AutoTurnedOff == false) { isBall15AutoTurnedOff = true; FrameColor(14, true); }
            else { isBall15AutoTurnedOff = false;  FrameColor(14, false); }
            if (ballNumber == currentBallFrame && isBall15AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall15AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 16)
        {
            if (isBall16AutoTurnedOff == false) { isBall16AutoTurnedOff = true;  FrameColor(15, true); }
            else { isBall16AutoTurnedOff = false;  FrameColor(15, false); }
            if (ballNumber == currentBallFrame && isBall16AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall16AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 17)
        {
            if (isBall17AutoTurnedOff == false) { isBall17AutoTurnedOff = true;  FrameColor(16, true); }
            else { isBall17AutoTurnedOff = false;  FrameColor(16, false); }
            if (ballNumber == currentBallFrame && isBall17AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall17AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 18)
        {
            if (isBall18AutoTurnedOff == false) { isBall18AutoTurnedOff = true; FrameColor(17, true); }
            else { isBall18AutoTurnedOff = false;  FrameColor(17, false); }
            if (ballNumber == currentBallFrame && isBall18AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall18AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 19)
        {
            if (isBall19AutoTurnedOff == false) { isBall19AutoTurnedOff = true;  FrameColor(18, true); }
            else { isBall19AutoTurnedOff = false; FrameColor(18, false); }
            if (ballNumber == currentBallFrame && isBall19AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall19AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 20)
        {
            if (isBall20AutoTurnedOff == false) { isBall20AutoTurnedOff = true;  FrameColor(19, true); }
            else { isBall20AutoTurnedOff = false;  FrameColor(19, false); }
            if (ballNumber == currentBallFrame && isBall20AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall20AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 21)
        {
            if (isBall21AutoTurnedOff == false) { isBall21AutoTurnedOff = true;  FrameColor(20, true); }
            else { isBall21AutoTurnedOff = false;  FrameColor(20, false); }
            if (ballNumber == currentBallFrame && isBall21AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall21AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }
        if (ballNumber == 22)
        {
            if (isBall22AutoTurnedOff == false) { isBall22AutoTurnedOff = true; FrameColor(21, true); }
            else { isBall22AutoTurnedOff = false;  FrameColor(21, false); }
            if (ballNumber == currentBallFrame && isBall22AutoTurnedOff == false) { SetAutoToggleObjects(false); }
            else if (ballNumber == currentBallFrame && isBall22AutoTurnedOff == true) { SetAutoToggleObjects(true); }
        }

        if(ballNumber == currentBallFrame)
        {

        }

        SetTextSpawnChance(false, false);
    }

    public void SetAutoToggleObjects(bool turnedOff)
    {
        if(turnedOff == true)
        { 
            autoOffObject.SetActive(true); autoOnObject.SetActive(false);
            autoDropONOFFtext.text = LocalizationStrings.autoDropOff;
        }
        if (turnedOff == false) 
        { 
            autoOffObject.SetActive(false); autoOnObject.SetActive(true);
            autoDropONOFFtext.text = LocalizationStrings.autoDropOn;
        }
    }

    #endregion

    #region All Auto drop button
    public void SetAAllAutoDrop(bool off)
    {
        ClickSound();

        if (off == true)
        {
            isBall1AutoTurnedOff = true;
            isBall2AutoTurnedOff = true;
            isBall3AutoTurnedOff = true;
            isBall4AutoTurnedOff = true;
            isBall5AutoTurnedOff = true;
            isBall6AutoTurnedOff = true;
            isBall7AutoTurnedOff = true;
            isBall8AutoTurnedOff = true;
            isBall9AutoTurnedOff = true;
            isBall10AutoTurnedOff = true;
            isBall11AutoTurnedOff = true;
            isBall12AutoTurnedOff = true;
            isBall13AutoTurnedOff = true;
            isBall14AutoTurnedOff = true;
            isBall15AutoTurnedOff = true;
            isBall16AutoTurnedOff = true;
            isBall17AutoTurnedOff = true;
            isBall18AutoTurnedOff = true;
            isBall19AutoTurnedOff = true;
            isBall20AutoTurnedOff = true;
            isBall21AutoTurnedOff = true;
            isBall22AutoTurnedOff = true;

            for (int i = 0; i < 22; i++)
            {
                FrameColor(i, true);
            }
        }
        if (off == false)
        {
            isBall1AutoTurnedOff = false;
            isBall2AutoTurnedOff = false;
            isBall3AutoTurnedOff = false;
            isBall4AutoTurnedOff = false;
            isBall5AutoTurnedOff = false;
            isBall6AutoTurnedOff = false;
            isBall7AutoTurnedOff = false;
            isBall8AutoTurnedOff = false;
            isBall9AutoTurnedOff = false;
            isBall10AutoTurnedOff = false;
            isBall11AutoTurnedOff = false;
            isBall12AutoTurnedOff = false;
            isBall13AutoTurnedOff = false;
            isBall14AutoTurnedOff = false;
            isBall15AutoTurnedOff = false;
            isBall16AutoTurnedOff = false;
            isBall17AutoTurnedOff = false;
            isBall18AutoTurnedOff = false;
            isBall19AutoTurnedOff = false;
            isBall20AutoTurnedOff = false;
            isBall21AutoTurnedOff = false;
            isBall22AutoTurnedOff = false;

            for (int i = 0; i < 22; i++)
            {
                FrameColor(i, false);
            }
        }

        SetTextSpawnChance(false,false);
    }
    #endregion

    #region Text spawn chance
    public static float textSpawnChance, offlineProgressTextChance;
    public static int autoPurchased, maxAutoCount;
    //41 times to reach max
    //902 for all balls
    //Max auto for all 22 would be -22 chance to spawn
    //

    public void SetTextSpawnChance(bool isMaxAuto, bool addAutoPurchased)
    {
        if(addAutoPurchased == true) { autoPurchased += 1; }
        if(isMaxAuto == true) { maxAutoCount += 1; }

        int autoTurnedOff = 0;
        float autoOffMinus = 0;
        float autoPurchaseChance;

        #region Check auto drop switch off
        if (isBall1AutoTurnedOff == true && isRegularBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall2AutoTurnedOff == true && isRedBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall3AutoTurnedOff == true && isRockBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall4AutoTurnedOff == true && isBombBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall5AutoTurnedOff == true && isAquaBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall6AutoTurnedOff == true && isMudBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall7AutoTurnedOff == true && isBasketBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall8AutoTurnedOff == true && isPlumBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall9AutoTurnedOff == true && isStickyBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall10AutoTurnedOff == true && isCandyBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall11AutoTurnedOff == true && isCookieBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall12AutoTurnedOff == true && isLimeBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall13AutoTurnedOff == true && isGoldenBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall14AutoTurnedOff == true && isFootballBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall15AutoTurnedOff == true && isSharpnelBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall16AutoTurnedOff == true && isZonicBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall17AutoTurnedOff == true && isApricotBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall18AutoTurnedOff == true && isPeggoBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall19AutoTurnedOff == true && isGhostBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall20AutoTurnedOff == true && isStarBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall21AutoTurnedOff == true && isRainbowBallAutoPurchased == true) { autoTurnedOff += 1; }
        if (isBall22AutoTurnedOff == true && isGlitchyBallAutoPurchased == true) { autoTurnedOff += 1; }
        #endregion

        #region Checks balls purchased
        int ballsAutoPurchased = 0;
        if (isRegularBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isRedBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isRockBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isBombBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isAquaBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isMudBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isBasketBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isPlumBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isStickyBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isCandyBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isCookieBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isLimeBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isGoldenBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isFootballBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isSharpnelBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isZonicBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isApricotBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isPeggoBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isGhostBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isStarBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isRainbowBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        if (isGlitchyBallAutoPurchased == true) { ballsAutoPurchased += 1; }
        #endregion

        autoPurchaseChance = autoPurchased / 8.9f;

        textSpawnChance = maxAutoCount + autoPurchaseChance;
        offlineProgressTextChance = textSpawnChance;

        if (autoTurnedOff > 0)
        {
            for (int i = 0; i < autoTurnedOff; i++)
            {
                autoOffMinus = textSpawnChance / ((ballsAutoPurchased - autoTurnedOff) + 1);
                textSpawnChance -= autoOffMinus;
            }
        }

        if (textSpawnChance > 95) { textSpawnChance = 95; }

       // Debug.Log(textSpawnChance);
    }
    #endregion

    #region Set color of frame
    public Image[] ballUpgradeFrames;

    public void FrameColor(int frame, bool off)
    {
        if(off == true)
        {
            if (frame == 1 && bouncyBallPurchased == false) { return; }
            if (frame == 2 && rockBallPurchased == false) { return; }
            if (frame == 3 && bombBallPurchased == false) { return; }
            if (frame == 4 && aquaBallPurchased == false) { return; }
            if (frame == 5 && mudBallPurchased == false) { return; }
            if (frame == 6 && basketBallPurchased == false) { return; }
            if (frame == 7 && plumBallPurchased == false) { return; }
            if (frame == 8 && stickyBallPurchased == false) { return; }
            if (frame == 9 && candyBallPurchased == false) { return; }
            if (frame == 10 && cookieBallPurchased == false) { return; }
            if (frame == 11 && limeBallPurchased == false) { return; }
            if (frame == 12 && goldenBallPurchased == false) { return; }
            if (frame == 13 && footballBallPurchased == false) { return; }
            if (frame == 14 && sharpnelBallPurchased == false) { return; }
            if (frame == 15 && zonicBallPurchased == false) { return; }
            if (frame == 16 && apricotBallPurchased == false) { return; }
            if (frame == 17 && peggoBallPurchased == false) { return; }
            if (frame == 18 && ghostBallPurchased == false) { return; }
            if (frame == 19 && starBallPurchased == false) { return; }
            if (frame == 20 && rainbowBallPurchased == false) { return; }
            if (frame == 21 && glitchyBallPurchased == false) { return; }
        }
      
        string offColor = "#FFD2C9";
        string onColor = "#FFFFFF";
        Color newColor;

        if(off == true)
        {
            if (ColorUtility.TryParseHtmlString(offColor, out newColor))
            {
                // Set the color of the Image component
                ballUpgradeFrames[frame].color = newColor;
            }
        }
        else
        {
            if (ColorUtility.TryParseHtmlString(onColor, out newColor))
            {
                // Set the color of the Image component
                ballUpgradeFrames[frame].color = newColor;
            }
        }
        
    }

    public void SetNormalColor()
    {
        for (int i = 1; i < 22; i++)
        {
            FrameColor(i, false);
        }
    }
    #endregion

    public static bool isInBallScreen1, isInBallScreen2, isInBallScreen3;

    #region Open Upgrade Frame
    public GameObject showUpgrades;
    public TextMeshProUGUI ballFrameNameText;

    public TextMeshProUGUI ballFrameUpgradePriceText, ballFrameAutoDropPriceText, ballFramePurchaseBallPriceText;
    public TextMeshProUGUI ballFrameUpgradeText, ballFrameAutoDropText, ballFramePurchaseBallText;
    public GameObject ballFrameEquippedButton, ballFrameUnequippedButton;

    public static int currentBallFrame;
    public static bool openedBallFrame;

    public int currentTotalBalls;
    public bool autoNotPurchased;

    public TextMeshProUGUI autoDropONOFFtext;

    public void OpenBallUpgradeFrame(int ball)
    {
        autoNotPurchased = false;
        ClickSound();

        ballNumber = ball;

        #region Regular Ball
        if (ball == 1)
        {
            showUpgrades.transform.localPosition = new Vector3(560, 320, 0);

            if (isRegularBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{basicBallAutoDropTime.ToString("F2") }{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
            else { ballFrameAutoDropText.text = $"{basicBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(basicBallAutoDropTime / regularBallAutoDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

            ballFrameNameText.text = LocalizationStrings.regularBallUpgrades;

            ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(regularBallUpgradePrice);
            ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(regularBallAutoPrice);
            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(regularBallPluss1Price);

            CheckGoldScale(ball, regularBallLevel, regularBallGoldIncrement);
            ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(regularBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

            if (totalRegularBalls == 10) { ballFramePurchaseBallText.text = "10" + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
            else { ballFramePurchaseBallText.text = $"{totalRegularBalls} (+1)"; }

            if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + regularBallLevel; }
            

            CheckAutoDropTime(ball, false);
        }
        #endregion

        #region Red Ball
        else if (ball == 2)
        {
            showUpgrades.transform.localPosition = new Vector3(740, 320, 0);

            if (isRedBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{redBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
            else { ballFrameAutoDropText.text = $"{redBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(redBallAutoDropTime / redBallAutoDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

            ballFrameNameText.text = LocalizationStrings.bouncyBallUpgrades;

            ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(redBallUpgradePrice);
            ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(redBallAutoPrice);
            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(redBallPluss1Price);


            CheckGoldScale(ball, redBallLevel, bouncyBallGoldIncrement);
            ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(redBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

            if (totalRedBalls == 10) { ballFramePurchaseBallText.text = "10" + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
            else { ballFramePurchaseBallText.text = $"{totalRedBalls} (+1)"; }

            if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + redBallLevel; }

            CheckAutoDropTime(ball, false);
        }
        #endregion

        #region Rock Ball
        else if(ball == 3)
        {
            showUpgrades.transform.localPosition = new Vector3(787, 320, 0);

            if (isRockBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{rockBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
            else { ballFrameAutoDropText.text = $"{rockBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(rockBallAutoDropTime / rockBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

            ballFrameNameText.text = LocalizationStrings.rockBallUgrades;

            ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(rockBallUpgradePrice);
            ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(rockBallAutoPrice);
            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(rockBallPluss1Price);

            CheckGoldScale(ball, rockBallLevel, rockBallGoldIncrement);
            ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(rockBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

            if (totalRockBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
            else { ballFramePurchaseBallText.text = $"{totalRockBalls} (+1)"; }

            if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + rockBallLevel; }

            CheckAutoDropTime(ball, false);
        }
        #endregion

        #region Bomb Ball
        else  if (ball == 4)
        {
            showUpgrades.transform.localPosition = new Vector3(555, 117, 0);

            if (isBombBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{bombBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
            else { ballFrameAutoDropText.text = $"{bombBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(bombBallAutoDropTime / bombBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

            ballFrameNameText.text = LocalizationStrings.bombBallUpgrades;

            ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(bombBallUpgradePrice);
            ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(bombBallAutoPrice);
            ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(bombBallPluss1Price);

            CheckGoldScale(ball, bombBallLevel, bombBallGoldIncrement);
            ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(bombBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

            if (totalBombBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
            else { ballFramePurchaseBallText.text = $"{totalBombBalls} (+1)"; }

            if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + bombBallLevel; }

            CheckAutoDropTime(ball, false);
        }
        #endregion

        if(GameData.isDemo == false)
        {
            #region Aqua Ball
            if (ball == 5)
            {
                showUpgrades.transform.localPosition = new Vector3(750, 117, 0);

                if (isAquaBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{aquaBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{aquaBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(aquaBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.aquaBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(aquaBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(aquaBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(aquaBallPluss1Price);

                CheckGoldScale(ball, aquaBallLevel, aquaBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(aquaBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalAquaBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalAquaBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + aquaBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Mud Ball
            else if(ball == 6)
            {
                showUpgrades.transform.localPosition = new Vector3(777, 117, 0);

                if (isMudBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{mudBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{mudBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(mudBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.mudBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(mudBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(mudBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(mudBallPluss1Price);

                CheckGoldScale(ball, mudBallLevel, mudBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(mudBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalMudBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalMudBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + mudBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Basket Ball
            else if (ball == 7)
            {
                showUpgrades.transform.localPosition = new Vector3(565, -90, 0);

                if (isBasketBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{basketBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{basketBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(basketBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.basketBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(basketBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(basketBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(basketBallPluss1Price);

                CheckGoldScale(ball, basketBallLevel, basketBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(basketBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalBasketBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalBasketBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + basketBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Plum Ball
            else if (ball == 8)
            {
                showUpgrades.transform.localPosition = new Vector3(740, -90, 0);

                if (isPlumBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{plumBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{plumBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(plumBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.plumBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(plumBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(plumBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(plumBallPluss1Price);

                CheckGoldScale(ball, plumBallLevel, plumBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(plumBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalPlumBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalPlumBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + plumBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Sticky Ball
            else if(ball == 9)
            {
                showUpgrades.transform.localPosition = new Vector3(777, -90, 0);

                if (isStickyBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{stickyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{stickyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(stickyBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.stickyBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(stickyBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(stickyBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(stickyBallPluss1Price);

                CheckGoldScale(ball, stickyBallLevel, stickyBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(stickyBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalStickyBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalStickyBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + stickyBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Candy Ball
            else if(ball == 10)
            {
                showUpgrades.transform.localPosition = new Vector3(560, 320, 0);

                if (isCandyBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{candyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{candyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(candyBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.candyBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(candyBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(candyBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(candyBallPluss1Price);

                CheckGoldScale(ball, candyBallLevel, candyBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(candyBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalCandyBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalCandyBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + candyBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Cookie Ball
            else if(ball == 11)
            {
                showUpgrades.transform.localPosition = new Vector3(740, 320, 0);

                if (isCookieBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{cookieBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{cookieBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(cookieBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.cookieBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(cookieBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(cookieBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(cookieBallPluss1Price);

                CheckGoldScale(ball, cookieBallLevel, cookieBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(cookieBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalCookieBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalCookieBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + cookieBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Lime Ball
            else if(ball == 12)
            {
                showUpgrades.transform.localPosition = new Vector3(787, 320, 0);

                if (isLimeBallAutoPurchased == false) {ballFrameAutoDropText.text = $"<color=red>{limeBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{limeBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(limeBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.limeBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(limeBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(limeBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(limeBallPluss1Price);

                CheckGoldScale(ball, limeBallLevel, limeBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(limeBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalLimeBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalLimeBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + limeBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Golden Ball
            else if(ball == 13)
            {
                showUpgrades.transform.localPosition = new Vector3(555, 117, 0);

                if (isGoldenBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{goldenBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{goldenBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(goldenBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.goldenBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenBallPluss1Price);

                CheckGoldScale(ball, goldenBallLevel, goldenBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(goldenBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalGoldenBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalGoldenBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + goldenBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Football Ball
            else if (ball == 14)
            {
                showUpgrades.transform.localPosition = new Vector3(750, 117, 0);

                if (isFootballBallAutoPurchased == false)
                {
                    ballFrameAutoDropText.text = $"<color=red>{footballBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true;
                }
                else { ballFrameAutoDropText.text = $"{footballBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(footballBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.footballBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(footballBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(footballBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(footballBallPluss1Price);

                CheckGoldScale(ball, footballBallLevel, footballBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(footballBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalFootballBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalFootballBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + footballBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Shrapnel Ball
            else if(ball == 15)
            {
                showUpgrades.transform.localPosition = new Vector3(777, 117, 0);

                if (isSharpnelBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{sharpnelBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{sharpnelBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(sharpnelBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.sharpnelBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(sharpnelBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(sharpnelBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(sharpnelBallPluss1Price);

                CheckGoldScale(ball, sharpnelBallLevel, sharpnelBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(sharpnelBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalSharpnelBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalSharpnelBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + sharpnelBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Zonic Ball
            else if(ball == 16)
            {
                showUpgrades.transform.localPosition = new Vector3(565, -90, 0);

                if (isZonicBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{zonicBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{zonicBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(zonicBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.zonicBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(zonicBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(zonicBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(zonicBallPluss1Price);

                CheckGoldScale(ball, zonicBallLevel, zonicBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(zonicBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalZonicBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalZonicBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + zonicBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Apricot Ball
            else if(ball == 17)
            {
                showUpgrades.transform.localPosition = new Vector3(740, -90, 0);

                if (isApricotBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{apricotBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{apricotBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(apricotBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.apricotBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(apricotBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(apricotBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(apricotBallPluss1Price);

                CheckGoldScale(ball, apricotBallLevel, apricotBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(apricotBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalApricotBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalApricotBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + apricotBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Peggo Ball
            else if(ball == 18)
            {
                showUpgrades.transform.localPosition = new Vector3(777, -90, 0);

                if (isPeggoBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{peggoBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{peggoBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(peggoBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.peggoBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(peggoBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(peggoBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(peggoBallPluss1Price);

                CheckGoldScale(ball, peggoBallLevel, peggoBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(peggoBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalPeggoBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalPeggoBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + peggoBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Ghost Ball
            else if(ball == 19)
            {
                showUpgrades.transform.localPosition = new Vector3(633, 305, 0);

                if (isGhostBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{ghostBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{ghostBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(ghostBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.ghostBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(ghostBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(ghostBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(ghostBallPluss1Price);

                CheckGoldScale(ball, ghostBallLevel, ghostBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(ghostBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalGhostBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalGhostBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + ghostBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Star Ball
            else if(ball == 20)
            {
                showUpgrades.transform.localPosition = new Vector3(777, 305, 0);

                if (isStarBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{starBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{starBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(starBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.starBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(starBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(starBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(starBallPluss1Price);

                CheckGoldScale(ball, starBallLevel, starBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(starBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalStarBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalStarBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + starBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Rainbow Ball
            else if(ball == 21)
            {
                showUpgrades.transform.localPosition = new Vector3(625, 24, 0);

                if (isRainbowBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{rainbowBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{rainbowBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(rainbowBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.rainbowBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(rainbowBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(rainbowBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(rainbowBallPluss1Price);

                CheckGoldScale(ball, rainbowBallLevel, rainbowBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(rainbowBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalRainbowBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalRainbowBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + rainbowBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion

            #region Glitchy Ball
            else if(ball == 22)
            {
                showUpgrades.transform.localPosition = new Vector3(777,24, 0);

                if (isGlitchyBallAutoPurchased == false) { ballFrameAutoDropText.text = $"<color=red>{glitchyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.lockedString}"; autoNotPurchased = true; }
                else { ballFrameAutoDropText.text = $"{glitchyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} (-{(glitchyBallAutoDropTime / allBallDivide).ToString("F2")}{LocalizationStrings.secondAbbreviation})"; }

                ballFrameNameText.text = LocalizationStrings.glitchyBallUpgrades;

                ballFrameUpgradePriceText.text = SetHighNumbers.FormatCoinsGoldShort(glitchyBallUpgradePrice);
                ballFrameAutoDropPriceText.text = SetHighNumbers.FormatCoinsGoldShort(glitchyBallAutoPrice);
                ballFramePurchaseBallPriceText.text = SetHighNumbers.FormatCoinsGoldShort(glitchyBallPluss1Price);

                CheckGoldScale(ball, glitchyBallLevel, glitchyBallGoldIncrement);
                ballFrameUpgradeText.text = $"{SetHighNumbers.FormatCoinsGoldShort(glitchyBallGold)} (+{SetHighNumbers.FormatCoinsGoldShort(goldIncrement)})";

                if (totalGlitchyBalls == 10) { ballFramePurchaseBallText.text = "10 " + LocalizationStrings.maxString2; ballFramePurchaseBallPriceText.text = LocalizationStrings.maxString; }
                else { ballFramePurchaseBallText.text = $"{totalGlitchyBalls} (+1)"; }

                if (ball == ballNumberEquipped) { currentBallLevelDisplay.text = LocalizationStrings.levelString + glitchyBallLevel; }

                CheckAutoDropTime(ball, false);
            }
            #endregion
        }

        SetTextScale(ballFrameUpgradePriceText); SetTextScale(ballFrameAutoDropPriceText); SetTextScale(ballFramePurchaseBallPriceText);


        #region Open And Close
        if (ballNumber == ballNumberEquipped) { ballFrameEquippedButton.SetActive(true); ballFrameUnequippedButton.SetActive(false); }
        else { ballFrameEquippedButton.SetActive(false); ballFrameUnequippedButton.SetActive(true); }

        if (MobileScript.isMobile == false)
        {
            if (showUpgrades.activeInHierarchy == false)
            {
                //SetUpgradeFrameOff.isHovering = true;
                openedBallFrame = true;
                showUpgrades.SetActive(true);
            }
            else
            {
                if (ball == currentBallFrame && showUpgrades.activeInHierarchy == true) { showUpgrades.SetActive(false); openedBallFrame = false; currentBallFrame = 0; }
                else if (ball == currentBallFrame && showUpgrades.activeInHierarchy == false) { showUpgrades.SetActive(true); openedBallFrame = true; }
                else if (ball != currentBallFrame && showUpgrades.activeInHierarchy == true) { showUpgrades.SetActive(true); openedBallFrame = true; }
            }
        }
        else
        {
            blackBlockUpgradeBar.SetActive(true);
            showUpgrades.SetActive(true);
            showUpgrades.transform.localScale = new Vector2(2.5f,2.5f);
            showUpgrades.transform.localPosition = new Vector2(235f, 45f);
            closeBallUpgradeBtn.SetActive(true);
        }
      
        currentBallFrame = ball;
        #endregion

        CheckAutoDropToggle(ball);
    }

    public void SetTextScale(TextMeshProUGUI text)
    {
        float preferredWidth = text.GetPreferredValues().x;
        text.rectTransform.sizeDelta = new Vector2(preferredWidth, text.rectTransform.sizeDelta.y);
    }

    public GameObject closeBallUpgradeBtn;

    public void MobileCloseBallUpgrades()
    {
        ClickSound();
        closeBallUpgradeBtn.SetActive(false);
        blackBlockUpgradeBar.SetActive(false);
        showUpgrades.SetActive(false);
    }

    public GameObject blackBlockUpgradeBar;

    public void ExitBallUpgradeFrame()
    {
        hookHooked.SetActive(false);
        hookUnhooked.SetActive(true);
        isHooked = false;

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        ClickSound();
        showUpgrades.SetActive(false);
    }

    public void CheckAutoDropToggle(int ball)
    {
        #region check auto drop
        if (ball == 1)
        {
            if (isBall1AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 2)
        {
            if (isBall2AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 3)
        {
            if (isBall3AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 4)
        {
            if (isBall4AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 5)
        {
            if (isBall5AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 6)
        {
            if (isBall6AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 7)
        {
            if (isBall7AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 8)
        {
            if (isBall8AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 9)
        {
            if (isBall9AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 10)
        {
            if (isBall10AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 11)
        {
            if (isBall11AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 12)
        {
            if (isBall12AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 13)
        {
            if (isBall13AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 14)
        {
            if (isBall14AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 15)
        {
            if (isBall15AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 16)
        {
            if (isBall16AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 17)
        {
            if (isBall17AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 18)
        {
            if (isBall18AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 19)
        {
            if (isBall19AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 20)
        {
            if (isBall20AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 21)
        {
            if (isBall21AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        if (ball == 22)
        {
            if (isBall22AutoTurnedOff == true) { SetAutoToggleObjects(true); }
            else { SetAutoToggleObjects(false); }
        }
        #endregion
    }

#endregion

    public void CheckGoldScale(int ball, int level, double normalIncrement)
    {
        int levelIncrement = (level / ballReachLevel);
        if (levelIncrement < 1) { goldIncrement = normalIncrement; }
        else { SetNewGoldIncrement(ball, levelIncrement); }
        CheckHighestLEvelBall();
    }

    #region Equip Balls
    public TextMeshProUGUI ballEquippedText;

    public GameObject equippedBallFrame;
    public GameObject ball1Frame, ball2Frame, ball3Frame, ball4Frame, ball5Frame, ball6Frame, ball7Frame, ball8Frame, ball9Frame, ball10Frame, ball11Frame, ball12Frame, ball13Frame, ball14Frame, ball15Frame, ball16Frame, ball17Frame, ball18Frame, ball19Frame, ball20Frame, ball21Frame, ball22Frame;

    public Sprite ball1Sprite, ball2Sprite, ball3Sprite, ball4Sprite, ball5Sprite, ball6Sprite, ball7Sprite, ball8Sprite, ball9Sprite, ball10Sprite, ball11Sprite, ball12Sprite, ball13Sprite, ball14Sprite, ball15Sprite, ball16Sprite, ball17Sprite, ball18Sprite, ball19Sprite, ball20Sprite, ball21Sprite, ball22Sprite;
    public static int ballNumberEquipped;
    public bool gameLoadedIn;

    public static bool isBallEquippedScreen1, isBallEquippedScreen2, isBallEquippedScreen3;

    public void EquipBall(bool playSound)
    {
        if((ballNumber == ballNumberEquipped) && (gameLoadedIn == true))
        {
            return;
        }
        else
        {
            if(playSound == true) { audioManager.Play("Equip"); }

            SetEverythingFalse();

            if(currentBallFrame == ballNumber) { ballFrameEquippedButton.SetActive(true); ballFrameUnequippedButton.SetActive(false); }

            #region Ball1
            if (ballNumber == 1)
            {
                equippedBallFrame.transform.position = ball1Frame.transform.position; SetBallsSprite(ball1Sprite, MainShooter.basicBallsAvailable);
                ballBounceText.text = LocalizationStrings.midBounce;
                ballEquippedText.text = LocalizationStrings.regularBallEquipped;
                DisplayCorrectGoldText(regularBallGold);

                if(isRegularBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                else { ballAutoDropTimeText.text = basicBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
              
                SetActiveBalls(MainShooter.basicBallsAvailable);

                currentBallLevelDisplay.text = LocalizationStrings.levelString + regularBallLevel;
            }
            #endregion

            #region Ball2
            if (ballNumber == 2)
            {
                equippedBallFrame.transform.position = ball2Frame.transform.position; SetBallsSprite(ball2Sprite, MainShooter.redBallsAviable);
                ballBounceText.text = LocalizationStrings.highBounce;
                ballEquippedText.text = LocalizationStrings.bouncyBallEquipped;
                DisplayCorrectGoldText(redBallGold);

                if (isRedBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                else { ballAutoDropTimeText.text = redBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                SetActiveBalls(MainShooter.redBallsAviable);
                currentBallLevelDisplay.text = LocalizationStrings.levelString + redBallLevel;
            }
            #endregion

            #region Ball3
            if (ballNumber == 3)
            {
                equippedBallFrame.transform.position = ball3Frame.transform.position;
                SetBallsSprite(ball3Sprite, MainShooter.rockBallsAviable);
                ballBounceText.text = LocalizationStrings.lowBounce;
                ballEquippedText.text = LocalizationStrings.rockBallEquipped;
                DisplayCorrectGoldText(rockBallGold);

                if (isRockBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                else { ballAutoDropTimeText.text = rockBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                SetActiveBalls(MainShooter.rockBallsAviable);
                currentBallLevelDisplay.text = LocalizationStrings.levelString + rockBallLevel;
            }
            #endregion

            #region Ball4
            if (ballNumber == 4)
            {
                equippedBallFrame.transform.position = ball4Frame.transform.position;
                SetBallsSprite(ball4Sprite, MainShooter.bombBallsAviable);
                ballBounceText.text = LocalizationStrings.lowBounce;
                ballEquippedText.text = LocalizationStrings.bombBallEquipped;
                DisplayCorrectGoldText(bombBallGold);

                if (isBombBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                else { ballAutoDropTimeText.text = bombBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                SetActiveBalls(MainShooter.bombBallsAviable);
                currentBallLevelDisplay.text = LocalizationStrings.levelString + bombBallLevel;
            }
            #endregion

            if(GameData.isDemo == false)
            {
                #region Aqua Ball
                if (ballNumber == 5)
                {
                    equippedBallFrame.transform.position = ball5Frame.transform.position;
                    SetBallsSprite(ball5Sprite, MainShooter.aquaBallsAvailable);
                    ballBounceText.text = LocalizationStrings.midBounce;
                    ballEquippedText.text = LocalizationStrings.aquaBallEquipped;
                    DisplayCorrectGoldText(aquaBallGold);

                    if (isAquaBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = aquaBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.aquaBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + aquaBallLevel;
                }
                #endregion

                #region Mud Ball
                if (ballNumber == 6)
                {
                    equippedBallFrame.transform.position = ball6Frame.transform.position;
                    SetBallsSprite(ball6Sprite, MainShooter.mudBallsAvailable);
                    ballBounceText.text = LocalizationStrings.midBounce;
                    ballEquippedText.text = LocalizationStrings.mudBallEquipped;
                    DisplayCorrectGoldText(mudBallGold);

                    if (isMudBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = mudBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.mudBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + mudBallLevel;
                }
                #endregion

                #region Basket Ball
                if (ballNumber == 7)
                {
                    equippedBallFrame.transform.position = ball7Frame.transform.position;
                    SetBallsSprite(ball7Sprite, MainShooter.basketBallsAvailable);
                    ballBounceText.text = LocalizationStrings.highBounce;
                    ballEquippedText.text = LocalizationStrings.basketBallEquipped;
                    DisplayCorrectGoldText(basketBallGold);

                    if (isBasketBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = basketBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.basketBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + basketBallLevel;
                }
                #endregion

                #region Plum Ball
                if (ballNumber == 8)
                {
                    equippedBallFrame.transform.position = ball8Frame.transform.position;
                    SetBallsSprite(ball8Sprite, MainShooter.plumBallsAvailable);
                    ballBounceText.text = LocalizationStrings.midBounce;
                    ballEquippedText.text = LocalizationStrings.plumBallEquipped;
                    DisplayCorrectGoldText(plumBallGold);

                    if (isPlumBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = plumBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.plumBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + plumBallLevel;
                }
                #endregion

                #region Sticky Ball
                if (ballNumber == 9)
                {
                    equippedBallFrame.transform.position = ball9Frame.transform.position;
                    SetBallsSprite(ball9Sprite, MainShooter.stickyBallsAvailable);
                    ballBounceText.text = LocalizationStrings.lowBounce;
                    ballEquippedText.text = LocalizationStrings.stickyBallEquipped;
                    DisplayCorrectGoldText(stickyBallGold);

                    if (isStickyBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = stickyBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.stickyBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + stickyBallLevel;
                }
                #endregion

                #region Candy Ball
                if (ballNumber == 10)
                {
                    equippedBallFrame.transform.position = ball10Frame.transform.position;
                    SetBallsSprite(ball10Sprite, MainShooter.candyBallsAvailable);
                    ballBounceText.text = LocalizationStrings.midBounce;
                    ballEquippedText.text = LocalizationStrings.candyBallEquipped;
                    DisplayCorrectGoldText(candyBallGold);

                    if (isCandyBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = candyBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.candyBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + candyBallLevel;
                }
                #endregion

                #region Cookie Ball
                if (ballNumber == 11)
                {
                    equippedBallFrame.transform.position = ball11Frame.transform.position;
                    SetBallsSprite(ball11Sprite, MainShooter.cookieBallsAvailable);
                    ballBounceText.text = LocalizationStrings.midBounce;
                    ballEquippedText.text = LocalizationStrings.cookieBallEquipped;
                    DisplayCorrectGoldText(cookieBallGold);

                    if (isCookieBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = cookieBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.cookieBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + cookieBallLevel;
                }
                #endregion

                #region Lime Ball
                if (ballNumber == 12)
                {
                    equippedBallFrame.transform.position = ball12Frame.transform.position;
                    SetBallsSprite(ball12Sprite, MainShooter.limeBallsAvailable);
                    ballBounceText.text = LocalizationStrings.highBounce;
                    ballEquippedText.text = LocalizationStrings.limeBallEquipped;
                    DisplayCorrectGoldText(limeBallGold);

                    if (isLimeBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = limeBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.limeBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + limeBallLevel;
                }
                #endregion

                #region Golden Ball
                if (ballNumber == 13)
                {
                    equippedBallFrame.transform.position = ball13Frame.transform.position;
                    SetBallsSprite(ball13Sprite, MainShooter.goldenBallsAvailable);
                    ballBounceText.text = LocalizationStrings.highBounce;
                    ballEquippedText.text = LocalizationStrings.goldenBallEquipped;
                    DisplayCorrectGoldText(goldenBallGold);

                    if (isGoldenBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = goldenBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.goldenBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + goldenBallLevel;
                }
                #endregion

                #region Football Ball
                if (ballNumber == 14)
                {
                    equippedBallFrame.transform.position = ball14Frame.transform.position;
                    SetBallsSprite(ball14Sprite, MainShooter.footballBallsAvailable);
                    ballBounceText.text = LocalizationStrings.midBounce;
                    ballEquippedText.text = LocalizationStrings.footballBallEquipped;
                    DisplayCorrectGoldText(footballBallGold);

                    if (isFootballBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = footballBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.footballBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + footballBallLevel;
                }
                #endregion

                #region Shrapnel Ball
                if (ballNumber == 15)
                {
                    equippedBallFrame.transform.position = ball15Frame.transform.position;
                    SetBallsSprite(ball15Sprite, MainShooter.sharpnelBallsAvailable);
                    ballBounceText.text = LocalizationStrings.lowBounce;
                    ballEquippedText.text = LocalizationStrings.sharpnelBallEquipped;
                    DisplayCorrectGoldText(sharpnelBallGold);

                    if (isSharpnelBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = sharpnelBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.sharpnelBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + sharpnelBallLevel;
                }
                #endregion

                #region Zonic Ball
                if (ballNumber == 16)
                {
                    equippedBallFrame.transform.position = ball16Frame.transform.position;
                    SetBallsSprite(ball16Sprite, MainShooter.zonicBallsAvailable);
                    ballBounceText.text = LocalizationStrings.midBounce;
                    ballEquippedText.text = LocalizationStrings.zonicBallEquipped;
                    DisplayCorrectGoldText(zonicBallGold);

                    if (isZonicBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = zonicBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.zonicBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + zonicBallLevel;
                }
                #endregion

                #region Apricot Ball
                if (ballNumber == 17)
                {
                    equippedBallFrame.transform.position = ball17Frame.transform.position;
                    SetBallsSprite(ball17Sprite, MainShooter.apricotBallsAvailable);
                    ballBounceText.text = LocalizationStrings.midBounce;
                    ballEquippedText.text = LocalizationStrings.apricotBallEquipped;
                    DisplayCorrectGoldText(apricotBallGold);

                    if (isApricotBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = apricotBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.apricotBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + apricotBallLevel;
                }
                #endregion

                #region Peggo Ball
                if (ballNumber == 18)
                {
                    equippedBallFrame.transform.position = ball18Frame.transform.position;
                    SetBallsSprite(ball18Sprite, MainShooter.peggoBallsAvailable);
                    ballBounceText.text = LocalizationStrings.highBounce;
                    ballEquippedText.text = LocalizationStrings.peggoBallEquipped;
                    DisplayCorrectGoldText(peggoBallGold);

                    if (isPeggoBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = peggoBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.peggoBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + peggoBallLevel;
                }
                #endregion

                #region Ghost Ball
                if (ballNumber == 19)
                {
                    equippedBallFrame.transform.position = ball19Frame.transform.position;
                    SetBallsSprite(ball19Sprite, MainShooter.ghostBallsAvailable);
                    ballBounceText.text = LocalizationStrings.noBounce;
                    ballEquippedText.text = LocalizationStrings.ghostBallEquipped;
                    DisplayCorrectGoldText(ghostBallGold);

                    if (isGhostBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = ghostBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.ghostBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + ghostBallLevel;
                }
                #endregion

                #region Star Ball
                if (ballNumber == 20)
                {
                    equippedBallFrame.transform.position = ball20Frame.transform.position;
                    SetBallsSprite(ball20Sprite, MainShooter.starBallsAvailable);
                    ballBounceText.text = LocalizationStrings.highBounce;
                    ballEquippedText.text = LocalizationStrings.starBallEquipped;
                    DisplayCorrectGoldText(starBallGold);

                    if (isStarBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = starBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.starBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + starBallLevel;
                }
                #endregion

                #region Rainbow Ball
                if (ballNumber == 21)
                {
                    equippedBallFrame.transform.position = ball21Frame.transform.position;
                    SetBallsSprite(ball21Sprite, MainShooter.rainbowBallsAvailable);
                    ballBounceText.text = LocalizationStrings.highBounce;
                    ballEquippedText.text = LocalizationStrings.rainbowBallEquipped;
                    DisplayCorrectGoldText(rainbowBallGold);

                    if (isRainbowBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = rainbowBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.rainbowBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + rainbowBallLevel;
                }
                #endregion

                #region Glitchy Ball
                if (ballNumber == 22)
                {
                    equippedBallFrame.transform.position = ball22Frame.transform.position;
                    SetBallsSprite(ball22Sprite, MainShooter.glitchyBallsAvailable);
                    ballBounceText.text = LocalizationStrings.highBounce;
                    ballEquippedText.text = LocalizationStrings.glitchyBallEquipped;
                    DisplayCorrectGoldText(glitchyBallGold);

                    if (isGlitchyBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
                    else { ballAutoDropTimeText.text = glitchyBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }

                    SetActiveBalls(MainShooter.glitchyBallsAvailable);
                    currentBallLevelDisplay.text = LocalizationStrings.levelString + glitchyBallLevel;
                }
                #endregion
            }

            equippedBallFrame.SetActive(true);
            ballNumberEquipped = ballNumber;
            if(ballNumberEquipped < 10)
            { 
                isBallEquippedScreen1 = true; isBallEquippedScreen2 = false; isBallEquippedScreen3 = false;
                equippedBallFrame.transform.localScale = new Vector3(TabsAndFrames.smallEquipSize, TabsAndFrames.smallEquipSize, TabsAndFrames.smallEquipSize);
            }
            else if (ballNumberEquipped > 9 && ballNumberEquipped < 19)
            { 
                isBallEquippedScreen2 = true; isBallEquippedScreen1 = false; isBallEquippedScreen3 = false;
                equippedBallFrame.transform.localScale = new Vector3(TabsAndFrames.smallEquipSize, TabsAndFrames.smallEquipSize, TabsAndFrames.smallEquipSize);
            }
            else
            {
                isBallEquippedScreen1 = false; isBallEquippedScreen2 = false; isBallEquippedScreen3 = true;
                equippedBallFrame.transform.localScale = new Vector3(TabsAndFrames.bigEquipSize, TabsAndFrames.bigEquipSize, TabsAndFrames.bigEquipSize);
            }
        }
    }

    public void SetEverythingFalse()
    {
    }

    public void SetBallsSprite(Sprite sprite, int ballCount)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].GetComponent<Image>().sprite = sprite;
        }

        SetActiveBalls(ballCount);
    }
    #endregion

    #region SetActiveBalls
    public GameObject[] balls;

    public void SetActiveBalls(int count)
    {
        ballsAviableText.text = count.ToString("F0");
        // Ensure count is within the bounds of the array
        count = Mathf.Clamp(count, 0, balls.Length);

        // Activate the GameObjects up to the specified count
        for (int i = 0; i < count; i++)
        {
            balls[i].SetActive(true);
        }

        // Deactivate the remaining GameObjects
        for (int i = count; i < balls.Length; i++)
        {
            balls[i].SetActive(false);
        }
    }
    #endregion

    #region Hook upgrade frame
    public GameObject hookHooked, hookUnhooked;
    public static bool isHooked;

    public void HookFrame()
    {
        if(hookUnhooked.activeInHierarchy == true)
        {
            isHooked = true;
            hookHooked.SetActive(true); hookUnhooked.SetActive(false);
        }
        else
        {
            isHooked = false;
            hookHooked.SetActive(false); hookUnhooked.SetActive(true);
        }
    }
    #endregion

    //Pits and pegs
    #region Upgrade Buckets
    public static float bucketIncrease;
    public static int bucketLevel;
    public TextMeshProUGUI pitsLevelText;
    public TextMeshProUGUI bucketIncreaseText;

    public static double bucketPrice;

    public void UpgradePits()
    {
        if(MobileScript.isMobile == true && isBucketFrameOpen == false) { return; }

        if(points >= bucketPrice)
        {
            PurchaseSounds();

            if (isMax == false)
            {
                maxBucketUpgradeCount = 1;
            }
            for (int i = 0; i < maxBucketUpgradeCount; i++)
            {   
                points -= bucketPrice;
                SetTotalGoldSpent(bucketPrice);

                bucketLevel += 1;
                locScript.ChangeBucketAndGoldenPegs(true);
                pitsLevelText.text = LocalizationStrings.bucketString;

                bucketPrice *= 2.25f;
                pitPriceText.text = SetHighNumbers.FormatCoinsGoldShort(bucketPrice);

                bucketIncrease += bucketIncreaseSCALE;
                BucketGoldPegHoverText();

                RoundToNearestWhole(bucketPrice);
                bucketPrice = currentDouble;
            }
        }
        else
        {
            CantAfford();
        }
    }

    #endregion

    #region Upgrade Pegs
    public static float goldenPegsIncrease;
    public TextMeshProUGUI goldenPegsIncreaseText;

    public static double goldenPegsPrice;

    public static int goldenPegsLevel;
    public TextMeshProUGUI goldenPegsLevelText;

    public void UpgradeGoldenPegs()
    {
        if (MobileScript.isMobile == true && isPegFrameOpen == false) { return; }

        if (points >= goldenPegsPrice)
        {
            if(isMax == false) { maxGoldenPegUpgradeCount = 1; }

            PurchaseSounds();

            for (int i = 0; i < maxGoldenPegUpgradeCount; i++)
            {
                points -= goldenPegsPrice;
                SetTotalGoldSpent(goldenPegsPrice);

                goldenPegsLevel += 1;
                locScript.ChangeBucketAndGoldenPegs(false);
                goldenPegsLevelText.text = LocalizationStrings.goldenPegString;

                goldenPegsPrice *= 2.25f;
                goldenPegsPriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenPegsPrice);

                goldenPegsIncrease += goldenPegIncreaseSCALE;
                BucketGoldPegHoverText();

                RoundToNearestWhole(goldenPegsPrice);
                goldenPegsPrice = currentDouble;
            }
        }
        else
        {
            CantAfford();
        }
    }
    #endregion

    #region check chall script
    public Challenges challScript;

    public void CheckMaxAutoChall()
    {
        if(GameData.isDemo == true) { return; }

        if (Challenges.challCompleted[10] == false && Challenges.challFinished[10] == false) { challScript.CheckCompleted(11, Challenges.ballsReachedMaxAuto); }
        if (Challenges.challCompleted[11] == false && Challenges.challFinished[11] == false) { challScript.CheckCompleted(12, Challenges.ballsReachedMaxAuto); }
        if (Challenges.challCompleted[12] == false && Challenges.challFinished[12] == false) { challScript.CheckCompleted(13, Challenges.ballsReachedMaxAuto); }
        if (Challenges.challCompleted[13] == false && Challenges.challFinished[13] == false) { challScript.CheckCompleted(14, Challenges.ballsReachedMaxAuto); }

        if (SettingsOptions.isInChallengeTab == true)
        {
            if (Challenges.challCompleted[10] == false && Challenges.challFinished[10] == false) { challScript.ChallengeProgress(11, Challenges.ballsReachedMaxAuto); }
            if (Challenges.challCompleted[11] == false && Challenges.challFinished[11] == false) { challScript.ChallengeProgress(12, Challenges.ballsReachedMaxAuto); }
            if (Challenges.challCompleted[12] == false && Challenges.challFinished[12] == false) { challScript.ChallengeProgress(13, Challenges.ballsReachedMaxAuto); }
            if (Challenges.challCompleted[13] == false && Challenges.challFinished[13] == false) { challScript.ChallengeProgress(14, Challenges.ballsReachedMaxAuto); }
        }
    }
    #endregion

    #region Check ach
    public Achievements achScript;

    public void CheckNewBallACH()
    {
        if(achScript != null) { achScript.CheckUnlockBalls(); }
    }

    #endregion

    #region check max auto drop time

    public bool isBall1MAXAUTO, isBall2MAXAUTO, isBall3MAXAUTO, isBall4MAXAUTO, isBall5MAXAUTO, isBall6MAXAUTO, isBall7MAXAUTO, isBall8MAXAUTO, isBall9MAXAUTO, isBall10MAXAUTO, isBall11MAXAUTO, isBall12MAXAUTO, isBall13MAXAUTO, isBall14MAXAUTO, isBall15MAXAUTO, isBall16MAXAUTO, isBall17MAXAUTO, isBall18MAXAUTO, isBall19MAXAUTO, isBall20MAXAUTO, isBall21MAXAUTO, isBall22MAXAUTO;

    public void CheckAutoDropTime(int ballNumber, bool checkPurchase)
    {
        bool maxxed = false;
        if (ballNumber == 1)
        {
            if (basicBallAutoDropTime <= minAutoDrop)
            {
                isBall1MAXAUTO = true;
                basicBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{basicBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if(checkPurchase == true) { maxxed = true; }
            }
            else { isBall1MAXAUTO = false; }
        }
        else if (ballNumber == 2)
        {
            if (redBallAutoDropTime <= minAutoDrop)
            {
                isBall2MAXAUTO = true;
                redBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{redBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall2MAXAUTO = false; }
        }
        else if(ballNumber == 3)
        {
            if (rockBallAutoDropTime <= minAutoDrop)
            {
                isBall3MAXAUTO = true;
                rockBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{rockBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall3MAXAUTO = false; }
        }
        else if(ballNumber == 4)
        {
            if (bombBallAutoDropTime <= minAutoDrop)
            {
                isBall4MAXAUTO = true;
                bombBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{bombBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall4MAXAUTO = false; }
        }
        else if(ballNumber == 5)
        {
            if (aquaBallAutoDropTime <= minAutoDrop)
            {
                isBall5MAXAUTO = true;
                aquaBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{aquaBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall5MAXAUTO = false; }
        }
        else if (ballNumber == 6)
        {
            if (mudBallAutoDropTime <= minAutoDrop)
            {
                isBall6MAXAUTO = true;
                mudBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{mudBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall6MAXAUTO = false; }
        }
        else if(ballNumber == 7)
        {
            if (basketBallAutoDropTime <= minAutoDrop)
            {
                isBall7MAXAUTO = true;
                basketBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{basketBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall7MAXAUTO = false; }
        }
        else if(ballNumber == 8)
        {
            if (plumBallAutoDropTime <= minAutoDrop)
            {
                isBall8MAXAUTO = true;
                plumBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{plumBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall8MAXAUTO = false; }
        }
        else if(ballNumber == 9)
        {
            if (stickyBallAutoDropTime <= minAutoDrop)
            {
                isBall9MAXAUTO = true;
                stickyBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{stickyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall9MAXAUTO = false; }
        }
        else if(ballNumber == 10)
        {
            if (candyBallAutoDropTime <= minAutoDrop)
            {
                isBall10MAXAUTO = true;
                candyBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{candyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall10MAXAUTO = false; }
        }
        else if(ballNumber == 11)
        {
            if (cookieBallAutoDropTime <= minAutoDrop)
            {
                isBall11MAXAUTO = true;
                cookieBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{cookieBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall11MAXAUTO = false; }
        }
        else  if (ballNumber == 12)
        {
            if (limeBallAutoDropTime <= minAutoDrop)
            {
                isBall12MAXAUTO = true;
                limeBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{limeBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall12MAXAUTO = false; }
        }
        else if (ballNumber == 13)
        {
            if (goldenBallAutoDropTime <= minAutoDrop)
            {
                isBall13MAXAUTO = true;
                goldenBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{goldenBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall13MAXAUTO = false; }
        }
        else if (ballNumber == 14)
        {
            if (footballBallAutoDropTime <= minAutoDrop)
            {
                isBall14MAXAUTO = true;
                footballBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{footballBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall14MAXAUTO = false; }
        }
        else if (ballNumber == 15)
        {
            if (sharpnelBallAutoDropTime <= minAutoDrop)
            {
                isBall15MAXAUTO = true;
                sharpnelBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{sharpnelBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall15MAXAUTO = false; }
        }
        else if (ballNumber == 16)
        {
            if (zonicBallAutoDropTime <= minAutoDrop)
            {
                isBall16MAXAUTO = true;
                zonicBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{zonicBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall16MAXAUTO = false; }
        }
        else if (ballNumber == 17)
        {
            if (apricotBallAutoDropTime <= minAutoDrop)
            {
                isBall17MAXAUTO = true;
                apricotBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{apricotBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall17MAXAUTO = false; }
        }
        else if (ballNumber == 18)
        {
            if (peggoBallAutoDropTime <= minAutoDrop)
            {
                isBall18MAXAUTO = true;
                peggoBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{peggoBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall18MAXAUTO = false; }
        }
        else if (ballNumber == 19)
        {
            if (ghostBallAutoDropTime <= minAutoDrop)
            {
                isBall19MAXAUTO = true;
                ghostBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{ghostBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall19MAXAUTO = false; }
        }
        else if (ballNumber == 20)
        {
            if (starBallAutoDropTime <= minAutoDrop)
            {
                isBall20MAXAUTO = true;
                starBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{starBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall20MAXAUTO = false; }
        }
        else if (ballNumber == 21)
        {
            if (rainbowBallAutoDropTime <= minAutoDrop)
            {
                isBall21MAXAUTO = true;
                rainbowBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{rainbowBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall21MAXAUTO = false; }
        }
        else if (ballNumber == 22)
        {
            if (glitchyBallAutoDropTime <= minAutoDrop)
            {
                isBall22MAXAUTO = true;
                glitchyBallAutoDropTime = minAutoDrop;
                ballFrameAutoDropText.text = $"{glitchyBallAutoDropTime.ToString("F1")}{LocalizationStrings.secondAbbreviation} {LocalizationStrings.maxString2}";
                ballFrameAutoDropPriceText.text = LocalizationStrings.maxString;
                if (checkPurchase == true) { maxxed = true; }
            }
            else { isBall22MAXAUTO = false; }
        }

        if(maxxed == true)
        {
            Challenges.ballsReachedMaxAuto += 1;
            SetTextSpawnChance(true, false);
            CheckMaxAutoChall();
        }
    }
    #endregion


    #region Mobile methods
    public bool isBucketFrameOpen;
    public GameObject bucketFrame, pegFrame, bucketAndPegClose, bucketAndPegDark, upgradeButton;

    public void OpenBucket()
    {
        if(MobileScript.isMobile == false) { return; }
        ClickSound();
        upgradeButton.SetActive(true);
        bucketAndPegDark.SetActive(true);
        bucketAndPegClose.SetActive(true);
        bucketFrame.SetActive(true);
        bucketFrame.transform.localPosition = new Vector2(0f, 55f);
        bucketFrame.transform.localScale = new Vector2(2.75f, 2.75f);
        isBucketFrameOpen = true;
    }

    public static bool isPegFrameOpen;
    public void OpenPegs()
    {
        if (MobileScript.isMobile == false) { return; }
        ClickSound();
        upgradeButton.SetActive(true);
        bucketAndPegDark.SetActive(true);
        bucketAndPegClose.SetActive(true);
        pegFrame.transform.localScale = new Vector2(2.75f, 2.75f);
        pegFrame.transform.localPosition = new Vector2(0f, 55f);
        pegFrame.SetActive(true);
        isPegFrameOpen = true;
    }

    public void ClosePegAndBucket()
    {
        ClickSound();
        upgradeButton.SetActive(false);
        bucketAndPegDark.SetActive(false);
        bucketAndPegClose.SetActive(false);
        bucketFrame.SetActive(false);
        pegFrame.SetActive(false);
        isPegFrameOpen = false;
        isBucketFrameOpen = false;
    }
    #endregion


    #region Set golden bucket and peg scale text
    public void BucketGoldPegHoverText()
    {
        //Golden peg
        if (goldenPegsIncrease % 1 == 0)
        {
            goldenPegsIncreaseText.text = "<color=yellow>" + goldenPegsIncrease.ToString("F0") + "X" + "(+" + goldenPegIncreaseSCALE + "X)";
        }
        else
        {
            goldenPegsIncreaseText.text = "<color=yellow>" + goldenPegsIncrease.ToString("F2") + "X" + "(+" + goldenPegIncreaseSCALE + "X)";
        }

        //Buckets
        if (bucketIncrease % 1 == 0)
        {
            bucketIncreaseText.text = "<color=yellow>" + bucketIncrease.ToString("F0") + "X" + "(+" + bucketIncreaseSCALE + "X)";
        }
        else
        {
            bucketIncreaseText.text = "<color=yellow>" + bucketIncrease.ToString("F2") + "X" + "(+" + bucketIncreaseSCALE + "X)";
        }
    }
    #endregion


    #region Reset Balls
    public void ResetBalls()
    {

        hookHooked.SetActive(false);
        hookUnhooked.SetActive(true);
        isHooked = false;

        goldenPegsIncrease = 1;
        goldenPegsIncreaseText.text = "<color=yellow>" + goldenPegsIncrease.ToString("F0") + "X" + "(+" + goldenPegIncreaseSCALE + "X)";

        bucketIncrease = 1;
        bucketIncreaseText.text = "<color=yellow>" + bucketIncrease.ToString("F0") + "X" + "(+" + bucketIncreaseSCALE + "X)";

        BucketGoldPegHoverText();

        ballBounceText.text = 0.5f + "";
        ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString;

        ballEquippedPointsText.text = "1";

        bucketLevel = 1;
        goldenPegsLevel = 1;

        locScript.ChangeBucketAndGoldenPegs(false);
        locScript.ChangeBucketAndGoldenPegs(true);
        pitsLevelText.text = LocalizationStrings.bucketString;
        goldenPegsLevelText.text = LocalizationStrings.goldenPegString;

        bucketPrice = GameData.ORIGINALbucketPrice;
        goldenPegsPrice = GameData.ORIGINALgoldenPegsPrice;

        pitPriceText.text = SetHighNumbers.FormatCoinsGoldShort(bucketPrice);
        goldenPegsPriceText.text = SetHighNumbers.FormatCoinsGoldShort(goldenPegsPrice);

        equippedBallFrame.transform.position = ball1Frame.transform.position;

        ballNumber = 1;
        EquipBall(false);
        MainShooter.basicBallsAvailable = 1;
        SetBallsSprite(ball1Sprite, MainShooter.basicBallsAvailable);
        ballNumberEquipped = 1;

        regularBallLevel = 1;
        redBallLevel = 1;
        rockBallLevel = 1;
        bombBallLevel = 1;
        aquaBallLevel = 1;
        mudBallLevel = 1;
        basketBallLevel = 1;
        plumBallLevel = 1;
        stickyBallLevel = 1;
        candyBallLevel = 1;
        cookieBallLevel = 1;
        limeBallLevel = 1;
        goldenBallLevel = 1;
        footballBallLevel = 1;
        sharpnelBallLevel = 1;
        zonicBallLevel = 1;
        apricotBallLevel = 1;
        peggoBallLevel = 1;
        ghostBallLevel = 1;
        starBallLevel = 1;
        rainbowBallLevel = 1;
        glitchyBallLevel = 1;

        currentBallLevelDisplay.text = LocalizationStrings.levelString + regularBallLevel;

        regularBallLevelText.text = regularBallLevel.ToString();
        redBallLevelText.text = redBallLevel.ToString();
        rockBallLevelText.text = rockBallLevel.ToString();
        bombBallLevelText.text = bombBallLevel.ToString();
        if (GameData.isDemo == false)
        {
            aquaBallLevelText.text = aquaBallLevel.ToString();
            mudBallLevelText.text = mudBallLevel.ToString();
            basketBallLevelText.text = basketBallLevel.ToString();
            plumBallLevelText.text = plumBallLevel.ToString();
            stickyBallLevelText.text = stickyBallLevel.ToString();
            candyBallLevelText.text = candyBallLevel.ToString();
            cookieBallLevelText.text = cookieBallLevel.ToString();
            limeBallLevelText.text = limeBallLevel.ToString();
            goldenBallLevelText.text = goldenBallLevel.ToString();
            footballBallLevelText.text = footballBallLevel.ToString();
            sharpnelBallLevelText.text = sharpnelBallLevel.ToString();
            zonicBallLevelText.text = zonicBallLevel.ToString();
            apricotBallLevelText.text = apricotBallLevel.ToString();
            peggoBallLevelText.text = peggoBallLevel.ToString();
            ghostBallLevelText.text = ghostBallLevel.ToString();
            starBallLevelText.text = starBallLevel.ToString();
            rainbowBallLevelText.text = rainbowBallLevel.ToString();
            glitchyBallLevelText.text = glitchyBallLevel.ToString();
        }

        bouncyBallPurchased = false;
        rockBallPurchased = false;
        bombBallPurchased = false;
        aquaBallPurchased = false;
        mudBallPurchased = false;
        basketBallPurchased = false;
        plumBallPurchased = false;
        stickyBallPurchased = false;
        candyBallPurchased = false;
        cookieBallPurchased = false;
        limeBallPurchased = false;
        goldenBallPurchased = false;
        footballBallPurchased = false;
        sharpnelBallPurchased = false;
        zonicBallPurchased = false;
        apricotBallPurchased = false;
        peggoBallPurchased = false;
        ghostBallPurchased = false;
        starBallPurchased = false;
        rainbowBallPurchased = false;
        glitchyBallPurchased = false;

        bouncyBallButton.interactable = false;
        rockBallButton.interactable = false;
        bombBallButton.interactable = false;
        if (GameData.isDemo == false)
        {
            aquaBallButton.interactable = false;
            mudBallButton.interactable = false;
            basketBallButton.interactable = false;
            plumBallButton.interactable = false;
            stickyBallButton.interactable = false;
            candyBallButton.interactable = false;
            cookieBallButton.interactable = false;
            limeBallButton.interactable = false;
            goldenBallButton.interactable = false;
            footballBallButton.interactable = false;
            sharpnelBallButton.interactable = false;
            zonicBallButton.interactable = false;
            apricotBallButton.interactable = false;
            peggoBallButton.interactable = false;
            ghostBallButton.interactable = false;
            starBallButton.interactable = false;
            rainbowBallButton.interactable = false;
            glitchyBallButton.interactable = false;
        }

        ball2PriceLockedFrame.SetActive(true);

        ball2UnlockedFrame.SetActive(false);
        ball3UnlockedFrame.SetActive(false);
        ball4UnlockedFrame.SetActive(false);
        if(GameData.isDemo == false)
        {
            ball5UnlockedFrame.SetActive(false);
            ball6UnlockedFrame.SetActive(false);
            ball7UnlockedFrame.SetActive(false);
            ball8UnlockedFrame.SetActive(false);
            ball9UnlockedFrame.SetActive(false);
            ball10UnlockedFrame.SetActive(false);
            ball11UnlockedFrame.SetActive(false);
            ball12UnlockedFrame.SetActive(false);
            ball13UnlockedFrame.SetActive(false);
            ball14UnlockedFrame.SetActive(false);
            ball15UnlockedFrame.SetActive(false);
            ball16UnlockedFrame.SetActive(false);
            ball17UnlockedFrame.SetActive(false);
            ball18UnlockedFrame.SetActive(false);
            ball19UnlockedFrame.SetActive(false);
            ball20UnlockedFrame.SetActive(false);
            ball21UnlockedFrame.SetActive(false);
            ball22UnlockedFrame.SetActive(false);
        }
       
        ball3PriceLockedFrame.SetActive(false);
        ball4PriceLockedFrame.SetActive(false);
        if (GameData.isDemo == false)
        {
            ball5PriceLockedFrame.SetActive(false);
            ball6PriceLockedFrame.SetActive(false);
            ball7PriceLockedFrame.SetActive(false);
            ball8PriceLockedFrame.SetActive(false);
            ball9PriceLockedFrame.SetActive(false);
            ball10PriceLockedFrame.SetActive(false);
            ball11PriceLockedFrame.SetActive(false);
            ball12PriceLockedFrame.SetActive(false);
            ball13PriceLockedFrame.SetActive(false);
            ball14PriceLockedFrame.SetActive(false);
            ball15PriceLockedFrame.SetActive(false);
            ball16PriceLockedFrame.SetActive(false);
            ball17PriceLockedFrame.SetActive(false);
            ball18PriceLockedFrame.SetActive(false);
            ball19PriceLockedFrame.SetActive(false);
            ball20PriceLockedFrame.SetActive(false);
            ball21PriceLockedFrame.SetActive(false);
            ball22PriceLockedFrame.SetActive(false);
        }

        ball3LockFrame.SetActive(true);
        ball4LockFrame.SetActive(true);
        if (GameData.isDemo == false)
        {
            ball5LockFrame.SetActive(true);
            ball6LockFrame.SetActive(true);
            ball7LockFrame.SetActive(true);
            ball8LockFrame.SetActive(true);
            ball9LockFrame.SetActive(true);
            ball10LockFrame.SetActive(true);
            ball11LockFrame.SetActive(true);
            ball12LockFrame.SetActive(true);
            ball13LockFrame.SetActive(true);
            ball14LockFrame.SetActive(true);
            ball15LockFrame.SetActive(true);
            ball16LockFrame.SetActive(true);
            ball17LockFrame.SetActive(true);
            ball18LockFrame.SetActive(true);
            ball19LockFrame.SetActive(true);
            ball20LockFrame.SetActive(true);
            ball21LockFrame.SetActive(true);
            ball22LockFrame.SetActive(true);
        }
    }
    #endregion

    #region LocChanges
    public void SetNewText()
    {
        if(ballNumberEquipped == 1) 
        {
            ballEquippedText.text = LocalizationStrings.regularBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + regularBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (isRegularBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = basicBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 2)
        {
            ballEquippedText.text = LocalizationStrings.bouncyBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + redBallLevel;
            ballBounceText.text = LocalizationStrings.highBounce;

            if (isRedBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = redBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if(ballNumberEquipped == 3)
        {
            ballEquippedText.text = LocalizationStrings.rockBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + rockBallLevel;
            ballBounceText.text = LocalizationStrings.lowBounce;

            if (isRockBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = rockBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 4)
        {
            ballEquippedText.text = LocalizationStrings.bombBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + bombBallLevel;
            ballBounceText.text = LocalizationStrings.lowBounce;

            if (isBombBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = bombBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 5)
        {
            ballEquippedText.text = LocalizationStrings.aquaBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + aquaBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (isAquaBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = aquaBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 6)
        {
            ballEquippedText.text = LocalizationStrings.mudBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + mudBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (isMudBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = mudBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 7)
        {
            ballEquippedText.text = LocalizationStrings.basketBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + basketBallLevel;
            ballBounceText.text = LocalizationStrings.highBounce;

            if (isBasketBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = basketBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }

        else if (ballNumberEquipped == 8)
        {
            ballEquippedText.text = LocalizationStrings.plumBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + plumBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (isPlumBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = plumBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }

        else if (ballNumberEquipped == 9)
        {
            ballEquippedText.text = LocalizationStrings.stickyBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + stickyBallLevel;
            ballBounceText.text = LocalizationStrings.lowBounce;

            if (isStickyBallAutoPurchased == false) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = stickyBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 10)
        {
            ballEquippedText.text = LocalizationStrings.candyBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + candyBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (!isCandyBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = candyBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 11)
        {
            ballEquippedText.text = LocalizationStrings.cookieBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + cookieBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (!isCookieBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = cookieBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 12)
        {
            ballEquippedText.text = LocalizationStrings.limeBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + limeBallLevel;
            ballBounceText.text = LocalizationStrings.highBounce;

            if (!isLimeBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = limeBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 13)
        {
            ballEquippedText.text = LocalizationStrings.goldenBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + goldenBallLevel;
            ballBounceText.text = LocalizationStrings.highBounce;

            if (!isGoldenBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = goldenBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 14)
        {
            ballEquippedText.text = LocalizationStrings.footballBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + footballBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (!isFootballBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = footballBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 15)
        {
            ballEquippedText.text = LocalizationStrings.sharpnelBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + sharpnelBallLevel;
            ballBounceText.text = LocalizationStrings.lowBounce;

            if (!isSharpnelBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = sharpnelBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 16)
        {
            ballEquippedText.text = LocalizationStrings.zonicBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + zonicBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (!isZonicBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = zonicBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 17)
        {
            ballEquippedText.text = LocalizationStrings.apricotBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + apricotBallLevel;
            ballBounceText.text = LocalizationStrings.midBounce;

            if (!isApricotBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = apricotBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 18)
        {
            ballEquippedText.text = LocalizationStrings.peggoBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + peggoBallLevel;
            ballBounceText.text = LocalizationStrings.highBounce;

            if (!isPeggoBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = peggoBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 19)
        {
            ballEquippedText.text = LocalizationStrings.ghostBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + ghostBallLevel;
            ballBounceText.text = LocalizationStrings.noBounce;

            if (!isGhostBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = ghostBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 20)
        {
            ballEquippedText.text = LocalizationStrings.starBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + starBallLevel;
            ballBounceText.text = LocalizationStrings.highBounce;

            if (!isStarBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = starBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 21)
        {
            ballEquippedText.text = LocalizationStrings.rainbowBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + rainbowBallLevel;
            ballBounceText.text = LocalizationStrings.highBounce;

            if (!isRainbowBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = rainbowBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }
        else if (ballNumberEquipped == 22)
        {
            ballEquippedText.text = LocalizationStrings.glitchyBallEquipped;
            currentBallLevelDisplay.text = LocalizationStrings.levelString + glitchyBallLevel;
            ballBounceText.text = LocalizationStrings.highBounce;

            if (!isGlitchyBallAutoPurchased) { ballAutoDropTimeText.text = "<color=red>" + LocalizationStrings.lockedString; }
            else { ballAutoDropTimeText.text = glitchyBallAutoDropTime.ToString("F1") + LocalizationStrings.secondAbbreviation; }
        }


        locScript.ChangeBucketAndGoldenPegs(false);
        locScript.ChangeBucketAndGoldenPegs(true);
        pitsLevelText.text = LocalizationStrings.bucketString;
        goldenPegsLevelText.text = LocalizationStrings.goldenPegString;
    }

    #endregion


    public void SetTotalGoldSpent(double gold)
    {
        AllStats.totalGoldSpent += gold;
    }

    #region Sounds
    public void PurchaseSounds()
    {
        int random = Random.Range(1, 4);
        if (random == 1) { audioManager.Play("Purchase1"); }
        if (random == 2) { audioManager.Play("Purchase2"); }
        if (random == 3) { audioManager.Play("Purchase3"); }
    }

    public void ClickSound()
    {
        int random = Random.Range(1, 3);
        if (random == 1) { audioManager.Play("UIClick1"); }
        if (random == 2) { audioManager.Play("UIClick2"); }
    }

    public void CantAfford()
    {
        audioManager.Play("CantAfford");
    }
    #endregion

    #region round double number
    public static double currentDouble;
    public double RoundToNearestWhole(double value)
    {
        if (value % 1 != 0)
        {
            double decimalComponent = value % 1;

            if (decimalComponent < 0.5f)
            {
                value -= decimalComponent;
            }
            else
            {
                value += (1 - decimalComponent);
            }
        }

        currentDouble = value;
        return value;
    }
    #endregion

    #region Star Ball drop
    public void SpawnStarBall()
    {
        GameObject starBall = ObjectPool2.instance.GetStarBallFromPool();
        starBall.layer = 15;

        float random = Random.Range(-900, 260);
        starBall.transform.localPosition = new Vector2(random, 700);

        AllStats.totalBallsDropped += 1;
    }
    #endregion

    #region glitchy ball spawn
    public void SpawnGlitchyBall()
    {
        GameObject glitchyBall = ObjectPool2.instance.GetGlitchyBallFromPool();
        glitchyBall.layer = 15;

        float random = Random.Range(-900, 260);
        glitchyBall.transform.localPosition = new Vector2(random, 700);

        AllStats.totalBallsDropped += 1;
    }
    #endregion

    public void ResetColor()
    {
        for (int i = 0; i < 22; i++)
        {
            if(GameData.isDemo == false)
            {
                FrameColor(i, false);
            }
            else
            {
                FrameColor(0, false);
                FrameColor(1, false);
                FrameColor(2, false);
                FrameColor(3, false);
            }
        }
    }


    #region Load Data
    public void LoadData(GameData data)
    {
        points = data.points;
        regularBallGold = data.regularBallGold;
        redBallGold = data.redBallGold;
        rockBallGold = data.rockBallGold;
        bombBallGold = data.bombBallGold;

        totalRegularBalls = data.totalRegularBalls;
        totalRedBalls = data.totalRedBalls;
        totalRockBalls = data.totalRockBalls;
        totalBombBalls = data.totalBombBalls;

        ballNumber = data.ballNumber;
        ballNumberEquipped = data.ballNumberEquipped;

        regularBallUpgradePrice = data.regularBallUpgradePrice;
        regularBallAutoPrice = data.regularBallAutoPrice;
        regularBallPluss1Price = data.regularBallPluss1Price;

        redBallUpgradePrice = data.redBallUpgradePrice;
        redBallAutoPrice = data.redBallAutoPrice;
        redBallPluss1Price = data.redBallPluss1Price;

        rockBallUpgradePrice = data.rockBallUpgradePrice;
        rockBallAutoPrice = data.rockBallAutoPrice;
        rockBallPluss1Price = data.rockBallPluss1Price;

        bombBallUpgradePrice = data.bombBallUpgradePrice;
        bombBallAutoPrice = data.bombBallAutoPrice;
        bombBallPluss1Price = data.bombBallPluss1Price;

        basicBallAutoDropTime = data.basicBallAutoDropTime;
        redBallAutoDropTime = data.redBallAutoDropTime;
        rockBallAutoDropTime = data.rockBallAutoDropTime;
        bombBallAutoDropTime = data.bombBallAutoDropTime;

        bouncyBallPrice = data.bouncyBallPrice;
        rockBallPrice = data.rockBallPrice;
        bombBallPrice = data.bombBallPrice;

        isRegularBallAutoPurchased = data.isRegularBallAutoPurchased;
        isRedBallAutoPurchased = data.isRedBallAutoPurchased;
        isRockBallAutoPurchased = data.isRockBallAutoPurchased;
        isBombBallAutoPurchased = data.isBombBallAutoPurchased;

        bouncyBallPurchased = data.bouncyBallPurchased;
        rockBallPurchased = data.rockBallPurchased;
        bombBallPurchased = data.bombBallPurchased;

        firstTimePurchaseNewBall = data.firstTimePurchaseNewBall;

        regularBallLevel = data.regularBallLevel;
        redBallLevel = data.redBallLevel;
        rockBallLevel = data.rockBallLevel;
        bombBallLevel = data.bombBallLevel;

        bucketPrice = data.bucketPrice;
        goldenPegsPrice = data.goldenPegsPrice;
        goldenPegsLevel = data.goldenPegsLevel;
        bucketLevel = data.bucketLevel;

        bucketIncrease = data.bucketIncrease;
        goldenPegsIncrease = data.goldenPegsIncrease;

        autoPurchased = data.autoPurchased;
        maxAutoCount = data.maxAutoCount;
        textSpawnChance = data.textSpawnChance;

        isBall1AutoTurnedOff = data.isBall1AutoTurnedOff;
        isBall2AutoTurnedOff = data.isBall2AutoTurnedOff;
        isBall3AutoTurnedOff = data.isBall3AutoTurnedOff;
        isBall4AutoTurnedOff = data.isBall4AutoTurnedOff;
        isBall5AutoTurnedOff = data.isBall5AutoTurnedOff;
        isBall6AutoTurnedOff = data.isBall6AutoTurnedOff;
        isBall7AutoTurnedOff = data.isBall7AutoTurnedOff;
        isBall8AutoTurnedOff = data.isBall8AutoTurnedOff;
        isBall9AutoTurnedOff = data.isBall9AutoTurnedOff;
        isBall10AutoTurnedOff = data.isBall10AutoTurnedOff;
        isBall11AutoTurnedOff = data.isBall11AutoTurnedOff;
        isBall12AutoTurnedOff = data.isBall12AutoTurnedOff;
        isBall13AutoTurnedOff = data.isBall13AutoTurnedOff;
        isBall14AutoTurnedOff = data.isBall14AutoTurnedOff;
        isBall15AutoTurnedOff = data.isBall15AutoTurnedOff;
        isBall16AutoTurnedOff = data.isBall16AutoTurnedOff;
        isBall17AutoTurnedOff = data.isBall17AutoTurnedOff;
        isBall18AutoTurnedOff = data.isBall18AutoTurnedOff;
        isBall19AutoTurnedOff = data.isBall19AutoTurnedOff;
        isBall20AutoTurnedOff = data.isBall20AutoTurnedOff;
        isBall21AutoTurnedOff = data.isBall21AutoTurnedOff;
        isBall22AutoTurnedOff = data.isBall22AutoTurnedOff;

        if (GameData.isDemo == false)
        {
            offlineProgressTextChance = data.offlineProgressTextChance;

            aquaBallGold = data.aquaBallGold;
            mudBallGold = data.mudBallGold;
            basketBallGold = data.basketBallGold;
            plumBallGold = data.plumBallGold;
            stickyBallGold = data.stickyBallGold;
            candyBallGold = data.candyBallGold;
            cookieBallGold = data.cookieBallGold;
            limeBallGold = data.limeBallGold;
            goldenBallGold = data.goldenBallGold;
            footballBallGold = data.footballBallGold;
            sharpnelBallGold = data.sharpnelBallGold;
            zonicBallGold = data.zonicBallGold;
            apricotBallGold = data.apricotBallGold;
            peggoBallGold = data.peggoBallGold;
            ghostBallGold = data.ghostBallGold;
            starBallGold = data.starBallGold;
            rainbowBallGold = data.rainbowBallGold;
            glitchyBallGold = data.glitchyBallGold;

            totalAquaBalls = data.totalAquaBalls;
            totalMudBalls = data.totalMudBalls;
            totalBasketBalls = data.totalBasketBalls;
            totalPlumBalls = data.totalPlumBalls;
            totalStickyBalls = data.totalStickyBalls;
            totalCandyBalls = data.totalCandyBalls;
            totalCookieBalls = data.totalCookieBalls;
            totalLimeBalls = data.totalLimeBalls;
            totalGoldenBalls = data.totalGoldenBalls;
            totalFootballBalls = data.totalFootballBalls;
            totalSharpnelBalls = data.totalSharpnelBalls;
            totalZonicBalls = data.totalZonicBalls;
            totalApricotBalls = data.totalApricotBalls;
            totalPeggoBalls = data.totalPeggoBalls;
            totalGhostBalls = data.totalGhostBalls;
            totalStarBalls = data.totalStarBalls;
            totalRainbowBalls = data.totalRainbowBalls;
            totalGlitchyBalls = data.totalGlitchyBalls;

            aquaBallUpgradePrice = data.aquaBallUpgradePrice;
            mudBallUpgradePrice = data.mudBallUpgradePrice;
            basketBallUpgradePrice = data.basketBallUpgradePrice;
            plumBallUpgradePrice = data.plumBallUpgradePrice;
            stickyBallUpgradePrice = data.stickyBallUpgradePrice;
            candyBallUpgradePrice = data.candyBallUpgradePrice;
            cookieBallUpgradePrice = data.cookieBallUpgradePrice;
            limeBallUpgradePrice = data.limeBallUpgradePrice;
            goldenBallUpgradePrice = data.goldenBallUpgradePrice;
            footballBallUpgradePrice = data.footballBallUpgradePrice;
            sharpnelBallUpgradePrice = data.sharpnelBallUpgradePrice;
            zonicBallUpgradePrice = data.zonicBallUpgradePrice;
            apricotBallUpgradePrice = data.apricotBallUpgradePrice;
            peggoBallUpgradePrice = data.peggoBallUpgradePrice;
            ghostBallUpgradePrice = data.ghostBallUpgradePrice;
            starBallUpgradePrice = data.starBallUpgradePrice;
            rainbowBallUpgradePrice = data.rainbowBallUpgradePrice;
            glitchyBallUpgradePrice = data.glitchyBallUpgradePrice;

            aquaBallAutoPrice = data.aquaBallAutoPrice;
            mudBallAutoPrice = data.mudBallAutoPrice;
            basketBallAutoPrice = data.basketBallAutoPrice;
            plumBallAutoPrice = data.plumBallAutoPrice;
            stickyBallAutoPrice = data.stickyBallAutoPrice;
            candyBallAutoPrice = data.candyBallAutoPrice;
            cookieBallAutoPrice = data.cookieBallAutoPrice;
            limeBallAutoPrice = data.limeBallAutoPrice;
            goldenBallAutoPrice = data.goldenBallAutoPrice;
            footballBallAutoPrice = data.footballBallAutoPrice;
            sharpnelBallAutoPrice = data.sharpnelBallAutoPrice;
            zonicBallAutoPrice = data.zonicBallAutoPrice;
            apricotBallAutoPrice = data.apricotBallAutoPrice;
            peggoBallAutoPrice = data.peggoBallAutoPrice;
            ghostBallAutoPrice = data.ghostBallAutoPrice;
            starBallAutoPrice = data.starBallAutoPrice;
            rainbowBallAutoPrice = data.rainbowBallAutoPrice;
            glitchyBallAutoPrice = data.glitchyBallAutoPrice;

            aquaBallPluss1Price = data.aquaBallPluss1Price;
            mudBallPluss1Price = data.mudBallPluss1Price;
            basketBallPluss1Price = data.basketBallPluss1Price;
            plumBallPluss1Price = data.plumBallPluss1Price;
            stickyBallPluss1Price = data.stickyBallPluss1Price;
            candyBallPluss1Price = data.candyBallPluss1Price;
            cookieBallPluss1Price = data.cookieBallPluss1Price;
            limeBallPluss1Price = data.limeBallPluss1Price;
            goldenBallPluss1Price = data.goldenBallPluss1Price;
            footballBallPluss1Price = data.footballBallPluss1Price;
            sharpnelBallPluss1Price = data.sharpnelBallPluss1Price;
            zonicBallPluss1Price = data.zonicBallPluss1Price;
            apricotBallPluss1Price = data.apricotBallPluss1Price;
            peggoBallPluss1Price = data.peggoBallPluss1Price;
            ghostBallPluss1Price = data.ghostBallPluss1Price;
            starBallPluss1Price = data.starBallPluss1Price;
            rainbowBallPluss1Price = data.rainbowBallPluss1Price;
            glitchyBallPluss1Price = data.glitchyBallPluss1Price;

            aquaBallAutoDropTime = data.aquaBallAutoDropTime;
            mudBallAutoDropTime = data.mudBallAutoDropTime;
            basketBallAutoDropTime = data.basketBallAutoDropTime;
            plumBallAutoDropTime = data.plumBallAutoDropTime;
            stickyBallAutoDropTime = data.stickyBallAutoDropTime;
            candyBallAutoDropTime = data.candyBallAutoDropTime;
            cookieBallAutoDropTime = data.cookieBallAutoDropTime;
            limeBallAutoDropTime = data.limeBallAutoDropTime;
            goldenBallAutoDropTime = data.goldenBallAutoDropTime;
            footballBallAutoDropTime = data.footballBallAutoDropTime;
            sharpnelBallAutoDropTime = data.sharpnelBallAutoDropTime;
            zonicBallAutoDropTime = data.zonicBallAutoDropTime;
            apricotBallAutoDropTime = data.apricotBallAutoDropTime;
            peggoBallAutoDropTime = data.peggoBallAutoDropTime;
            ghostBallAutoDropTime = data.ghostBallAutoDropTime;
            starBallAutoDropTime = data.starBallAutoDropTime;
            rainbowBallAutoDropTime = data.rainbowBallAutoDropTime;
            glitchyBallAutoDropTime = data.glitchyBallAutoDropTime;

            aquaBallPrice = data.aquaBallPrice;
            mudBallPrice = data.mudBallPrice;
            basketBallPrice = data.basketBallPrice;
            plumBallPrice = data.plumBallPrice;
            stickyBallPrice = data.stickyBallPrice;
            candyBallPrice = data.candyBallPrice;
            cookieBallPrice = data.cookieBallPrice;
            limeBallPrice = data.limeBallPrice;
            goldenBallPrice = data.goldenBallPrice;
            footballBallPrice = data.footballBallPrice;
            sharpnelBallPrice = data.sharpnelBallPrice;
            zonicBallPrice = data.zonicBallPrice;
            apricotBallPrice = data.apricotBallPrice;
            peggoBallPrice = data.peggoBallPrice;
            ghostBallPrice = data.ghostBallPrice;
            starBallPrice = data.starBallPrice;
            rainbowBallPrice = data.rainbowBallPrice;
            glitchyBallPrice = data.glitchyBallPrice;

            isAquaBallAutoPurchased = data.isAquaBallAutoPurchased;
            isMudBallAutoPurchased = data.isMudBallAutoPurchased;
            isBasketBallAutoPurchased = data.isBasketBallAutoPurchased;
            isPlumBallAutoPurchased = data.isPlumBallAutoPurchased;
            isStickyBallAutoPurchased = data.isStickyBallAutoPurchased;
            isCandyBallAutoPurchased = data.isCandyBallAutoPurchased;
            isCookieBallAutoPurchased = data.isCookieBallAutoPurchased;
            isLimeBallAutoPurchased = data.isLimeBallAutoPurchased;
            isGoldenBallAutoPurchased = data.isGoldenBallAutoPurchased;
            isFootballBallAutoPurchased = data.isFootballBallAutoPurchased;
            isSharpnelBallAutoPurchased = data.isSharpnelBallAutoPurchased;
            isZonicBallAutoPurchased = data.isZonicBallAutoPurchased;
            isApricotBallAutoPurchased = data.isApricotBallAutoPurchased;
            isPeggoBallAutoPurchased = data.isPeggoBallAutoPurchased;
            isGhostBallAutoPurchased = data.isGhostBallAutoPurchased;
            isStarBallAutoPurchased = data.isStarBallAutoPurchased;
            isRainbowBallAutoPurchased = data.isRainbowBallAutoPurchased;
            isGlitchyBallAutoPurchased = data.isGlitchyBallAutoPurchased;

            aquaBallPurchased = data.aquaBallPurchased;
            mudBallPurchased = data.mudBallPurchased;
            basketBallPurchased = data.basketBallPurchased;
            plumBallPurchased = data.plumBallPurchased;
            stickyBallPurchased = data.stickyBallPurchased;
            candyBallPurchased = data.candyBallPurchased;
            cookieBallPurchased = data.cookieBallPurchased;
            limeBallPurchased = data.limeBallPurchased;
            goldenBallPurchased = data.goldenBallPurchased;
            footballBallPurchased = data.footballBallPurchased;
            sharpnelBallPurchased = data.sharpnelBallPurchased;
            zonicBallPurchased = data.zonicBallPurchased;
            apricotBallPurchased = data.apricotBallPurchased;
            peggoBallPurchased = data.peggoBallPurchased;
            ghostBallPurchased = data.ghostBallPurchased;
            starBallPurchased = data.starBallPurchased;
            rainbowBallPurchased = data.rainbowBallPurchased;
            glitchyBallPurchased = data.glitchyBallPurchased;

            aquaBallLevel = data.aquaBallLevel;
            mudBallLevel = data.mudBallLevel;
            basketBallLevel = data.basketBallLevel;
            plumBallLevel = data.plumBallLevel;
            stickyBallLevel = data.stickyBallLevel;
            candyBallLevel = data.candyBallLevel;
            cookieBallLevel = data.cookieBallLevel;
            limeBallLevel = data.limeBallLevel;
            goldenBallLevel = data.goldenBallLevel;
            footballBallLevel = data.footballBallLevel;
            sharpnelBallLevel = data.sharpnelBallLevel;
            zonicBallLevel = data.zonicBallLevel;
            apricotBallLevel = data.apricotBallLevel;
            peggoBallLevel = data.peggoBallLevel;
            ghostBallLevel = data.ghostBallLevel;
            starBallLevel = data.starBallLevel;
            rainbowBallLevel = data.rainbowBallLevel;
            glitchyBallLevel = data.glitchyBallLevel;
        }
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.points = points;
        data.regularBallGold = regularBallGold;
        data.redBallGold = redBallGold;
        data.rockBallGold = rockBallGold;
        data.bombBallGold = bombBallGold;

        data.totalRegularBalls = totalRegularBalls;
        data.totalRedBalls = totalRedBalls;
        data.totalRockBalls = totalRockBalls;
        data.totalBombBalls = totalBombBalls;
        data.ballNumber = ballNumber;
        data.ballNumberEquipped = ballNumberEquipped;

        data.regularBallUpgradePrice = regularBallUpgradePrice;
        data.regularBallAutoPrice = regularBallAutoPrice;
        data.regularBallPluss1Price = regularBallPluss1Price;
        data.redBallUpgradePrice = redBallUpgradePrice;
        data.redBallAutoPrice = redBallAutoPrice;
        data.redBallPluss1Price = redBallPluss1Price;
        data.rockBallUpgradePrice = rockBallUpgradePrice;
        data.rockBallAutoPrice = rockBallAutoPrice;
        data.rockBallPluss1Price = rockBallPluss1Price;
        data.bombBallUpgradePrice = bombBallUpgradePrice;
        data.bombBallAutoPrice = bombBallAutoPrice;
        data.bombBallPluss1Price = bombBallPluss1Price;

        data.basicBallAutoDropTime = basicBallAutoDropTime;
        data.redBallAutoDropTime = redBallAutoDropTime;
        data.rockBallAutoDropTime = rockBallAutoDropTime;
        data.bombBallAutoDropTime = bombBallAutoDropTime;

        data.bouncyBallPrice = bouncyBallPrice;
        data.rockBallPrice = rockBallPrice;
        data.bombBallPrice = bombBallPrice;

        data.isRegularBallAutoPurchased = isRegularBallAutoPurchased;
        data.isRedBallAutoPurchased = isRedBallAutoPurchased;
        data.isRockBallAutoPurchased = isRockBallAutoPurchased;
        data.isBombBallAutoPurchased = isBombBallAutoPurchased;

        data.bouncyBallPurchased = bouncyBallPurchased;
        data.rockBallPurchased = rockBallPurchased;
        data.bombBallPurchased = bombBallPurchased;

        data.firstTimePurchaseNewBall = firstTimePurchaseNewBall;

        data.regularBallLevel = regularBallLevel;
        data.redBallLevel = redBallLevel;
        data.rockBallLevel = rockBallLevel;
        data.bombBallLevel = bombBallLevel;

        data.bucketPrice = bucketPrice;
        data.goldenPegsPrice = goldenPegsPrice;
        data.goldenPegsLevel = goldenPegsLevel;
        data.bucketLevel = bucketLevel;

        data.bucketIncrease = bucketIncrease;
        data.goldenPegsIncrease = goldenPegsIncrease;

        data.autoPurchased = autoPurchased;
        data.maxAutoCount = maxAutoCount;
        data.textSpawnChance = textSpawnChance;

        data.isBall1AutoTurnedOff = isBall1AutoTurnedOff;
        data.isBall2AutoTurnedOff = isBall2AutoTurnedOff;
        data.isBall3AutoTurnedOff = isBall3AutoTurnedOff;
        data.isBall4AutoTurnedOff = isBall4AutoTurnedOff;
        data.isBall5AutoTurnedOff = isBall5AutoTurnedOff;
        data.isBall6AutoTurnedOff = isBall6AutoTurnedOff;
        data.isBall7AutoTurnedOff = isBall7AutoTurnedOff;
        data.isBall8AutoTurnedOff = isBall8AutoTurnedOff;
        data.isBall9AutoTurnedOff = isBall9AutoTurnedOff;
        data.isBall10AutoTurnedOff = isBall10AutoTurnedOff;
        data.isBall11AutoTurnedOff = isBall11AutoTurnedOff;
        data.isBall12AutoTurnedOff = isBall12AutoTurnedOff;
        data.isBall13AutoTurnedOff = isBall13AutoTurnedOff;
        data.isBall14AutoTurnedOff = isBall14AutoTurnedOff;
        data.isBall15AutoTurnedOff = isBall15AutoTurnedOff;
        data.isBall16AutoTurnedOff = isBall16AutoTurnedOff;
        data.isBall17AutoTurnedOff = isBall17AutoTurnedOff;
        data.isBall18AutoTurnedOff = isBall18AutoTurnedOff;
        data.isBall19AutoTurnedOff = isBall19AutoTurnedOff;
        data.isBall20AutoTurnedOff = isBall20AutoTurnedOff;
        data.isBall21AutoTurnedOff = isBall21AutoTurnedOff;
        data.isBall22AutoTurnedOff = isBall22AutoTurnedOff;

        if (GameData.isDemo == false)
        {
            data.offlineProgressTextChance = offlineProgressTextChance;

            data.aquaBallGold = aquaBallGold;
            data.mudBallGold = mudBallGold;
            data.basketBallGold = basketBallGold;
            data.plumBallGold = plumBallGold;
            data.stickyBallGold = stickyBallGold;
            data.candyBallGold = candyBallGold;
            data.cookieBallGold = cookieBallGold;
            data.limeBallGold = limeBallGold;
            data.goldenBallGold = goldenBallGold;
            data.footballBallGold = footballBallGold;
            data.sharpnelBallGold = sharpnelBallGold;
            data.zonicBallGold = zonicBallGold;
            data.apricotBallGold = apricotBallGold;
            data.peggoBallGold = peggoBallGold;
            data.ghostBallGold = ghostBallGold;
            data.starBallGold = starBallGold;
            data.rainbowBallGold = rainbowBallGold;
            data.glitchyBallGold = glitchyBallGold;

            data.totalAquaBalls = totalAquaBalls;
            data.totalMudBalls = totalMudBalls;
            data.totalBasketBalls = totalBasketBalls;
            data.totalPlumBalls = totalPlumBalls;
            data.totalStickyBalls = totalStickyBalls;
            data.totalCandyBalls = totalCandyBalls;
            data.totalCookieBalls = totalCookieBalls;
            data.totalLimeBalls = totalLimeBalls;
            data.totalGoldenBalls = totalGoldenBalls;
            data.totalFootballBalls = totalFootballBalls;
            data.totalSharpnelBalls = totalSharpnelBalls;
            data.totalZonicBalls = totalZonicBalls;
            data.totalApricotBalls = totalApricotBalls;
            data.totalPeggoBalls = totalPeggoBalls;
            data.totalGhostBalls = totalGhostBalls;
            data.totalStarBalls = totalStarBalls;
            data.totalRainbowBalls = totalRainbowBalls;
            data.totalGlitchyBalls = totalGlitchyBalls;

            data.aquaBallUpgradePrice = aquaBallUpgradePrice;
            data.mudBallUpgradePrice = mudBallUpgradePrice;
            data.basketBallUpgradePrice = basketBallUpgradePrice;
            data.plumBallUpgradePrice = plumBallUpgradePrice;
            data.stickyBallUpgradePrice = stickyBallUpgradePrice;
            data.candyBallUpgradePrice = candyBallUpgradePrice;
            data.cookieBallUpgradePrice = cookieBallUpgradePrice;
            data.limeBallUpgradePrice = limeBallUpgradePrice;
            data.goldenBallUpgradePrice = goldenBallUpgradePrice;
            data.footballBallUpgradePrice = footballBallUpgradePrice;
            data.sharpnelBallUpgradePrice = sharpnelBallUpgradePrice;
            data.zonicBallUpgradePrice = zonicBallUpgradePrice;
            data.apricotBallUpgradePrice = apricotBallUpgradePrice;
            data.peggoBallUpgradePrice = peggoBallUpgradePrice;
            data.ghostBallUpgradePrice = ghostBallUpgradePrice;
            data.starBallUpgradePrice = starBallUpgradePrice;
            data.rainbowBallUpgradePrice = rainbowBallUpgradePrice;
            data.glitchyBallUpgradePrice = glitchyBallUpgradePrice;

            data.aquaBallAutoPrice = aquaBallAutoPrice;
            data.mudBallAutoPrice = mudBallAutoPrice;
            data.basketBallAutoPrice = basketBallAutoPrice;
            data.plumBallAutoPrice = plumBallAutoPrice;
            data.stickyBallAutoPrice = stickyBallAutoPrice;
            data.candyBallAutoPrice = candyBallAutoPrice;
            data.cookieBallAutoPrice = cookieBallAutoPrice;
            data.limeBallAutoPrice = limeBallAutoPrice;
            data.goldenBallAutoPrice = goldenBallAutoPrice;
            data.footballBallAutoPrice = footballBallAutoPrice;
            data.sharpnelBallAutoPrice = sharpnelBallAutoPrice;
            data.zonicBallAutoPrice = zonicBallAutoPrice;
            data.apricotBallAutoPrice = apricotBallAutoPrice;
            data.peggoBallAutoPrice = peggoBallAutoPrice;
            data.ghostBallAutoPrice = ghostBallAutoPrice;
            data.starBallAutoPrice = starBallAutoPrice;
            data.rainbowBallAutoPrice = rainbowBallAutoPrice;
            data.glitchyBallAutoPrice = glitchyBallAutoPrice;

            data.aquaBallPluss1Price = aquaBallPluss1Price;
            data.mudBallPluss1Price = mudBallPluss1Price;
            data.basketBallPluss1Price = basketBallPluss1Price;
            data.plumBallPluss1Price = plumBallPluss1Price;
            data.stickyBallPluss1Price = stickyBallPluss1Price;
            data.candyBallPluss1Price = candyBallPluss1Price;
            data.cookieBallPluss1Price = cookieBallPluss1Price;
            data.limeBallPluss1Price = limeBallPluss1Price;
            data.goldenBallPluss1Price = goldenBallPluss1Price;
            data.footballBallPluss1Price = footballBallPluss1Price;
            data.sharpnelBallPluss1Price = sharpnelBallPluss1Price;
            data.zonicBallPluss1Price = zonicBallPluss1Price;
            data.apricotBallPluss1Price = apricotBallPluss1Price;
            data.peggoBallPluss1Price = peggoBallPluss1Price;
            data.ghostBallPluss1Price = ghostBallPluss1Price;
            data.starBallPluss1Price = starBallPluss1Price;
            data.rainbowBallPluss1Price = rainbowBallPluss1Price;
            data.glitchyBallPluss1Price = glitchyBallPluss1Price;

            data.aquaBallAutoDropTime = aquaBallAutoDropTime;
            data.mudBallAutoDropTime = mudBallAutoDropTime;
            data.basketBallAutoDropTime = basketBallAutoDropTime;
            data.plumBallAutoDropTime = plumBallAutoDropTime;
            data.stickyBallAutoDropTime = stickyBallAutoDropTime;
            data.candyBallAutoDropTime = candyBallAutoDropTime;
            data.cookieBallAutoDropTime = cookieBallAutoDropTime;
            data.limeBallAutoDropTime = limeBallAutoDropTime;
            data.goldenBallAutoDropTime = goldenBallAutoDropTime;
            data.footballBallAutoDropTime = footballBallAutoDropTime;
            data.sharpnelBallAutoDropTime = sharpnelBallAutoDropTime;
            data.zonicBallAutoDropTime = zonicBallAutoDropTime;
            data.apricotBallAutoDropTime = apricotBallAutoDropTime;
            data.peggoBallAutoDropTime = peggoBallAutoDropTime;
            data.ghostBallAutoDropTime = ghostBallAutoDropTime;
            data.starBallAutoDropTime = starBallAutoDropTime;
            data.rainbowBallAutoDropTime = rainbowBallAutoDropTime;
            data.glitchyBallAutoDropTime = glitchyBallAutoDropTime;

            data.aquaBallPrice = aquaBallPrice;
            data.mudBallPrice = mudBallPrice;
            data.basketBallPrice = basketBallPrice;
            data.plumBallPrice = plumBallPrice;
            data.stickyBallPrice = stickyBallPrice;
            data.candyBallPrice = candyBallPrice;
            data.cookieBallPrice = cookieBallPrice;
            data.limeBallPrice = limeBallPrice;
            data.goldenBallPrice = goldenBallPrice;
            data.footballBallPrice = footballBallPrice;
            data.sharpnelBallPrice = sharpnelBallPrice;
            data.zonicBallPrice = zonicBallPrice;
            data.apricotBallPrice = apricotBallPrice;
            data.peggoBallPrice = peggoBallPrice;
            data.ghostBallPrice = ghostBallPrice;
            data.starBallPrice = starBallPrice;
            data.rainbowBallPrice = rainbowBallPrice;
            data.glitchyBallPrice = glitchyBallPrice;

            data.isAquaBallAutoPurchased = isAquaBallAutoPurchased;
            data.isMudBallAutoPurchased = isMudBallAutoPurchased;
            data.isBasketBallAutoPurchased = isBasketBallAutoPurchased;
            data.isPlumBallAutoPurchased = isPlumBallAutoPurchased;
            data.isStickyBallAutoPurchased = isStickyBallAutoPurchased;
            data.isCandyBallAutoPurchased = isCandyBallAutoPurchased;
            data.isCookieBallAutoPurchased = isCookieBallAutoPurchased;
            data.isLimeBallAutoPurchased = isLimeBallAutoPurchased;
            data.isGoldenBallAutoPurchased = isGoldenBallAutoPurchased;
            data.isFootballBallAutoPurchased = isFootballBallAutoPurchased;
            data.isSharpnelBallAutoPurchased = isSharpnelBallAutoPurchased;
            data.isZonicBallAutoPurchased = isZonicBallAutoPurchased;
            data.isApricotBallAutoPurchased = isApricotBallAutoPurchased;
            data.isPeggoBallAutoPurchased = isPeggoBallAutoPurchased;
            data.isGhostBallAutoPurchased = isGhostBallAutoPurchased;
            data.isStarBallAutoPurchased = isStarBallAutoPurchased;
            data.isRainbowBallAutoPurchased = isRainbowBallAutoPurchased;
            data.isGlitchyBallAutoPurchased = isGlitchyBallAutoPurchased;

            data.aquaBallPurchased = aquaBallPurchased;
            data.mudBallPurchased = mudBallPurchased;
            data.basketBallPurchased = basketBallPurchased;
            data.plumBallPurchased = plumBallPurchased;
            data.stickyBallPurchased = stickyBallPurchased;
            data.candyBallPurchased = candyBallPurchased;
            data.cookieBallPurchased = cookieBallPurchased;
            data.limeBallPurchased = limeBallPurchased;
            data.goldenBallPurchased = goldenBallPurchased;
            data.footballBallPurchased = footballBallPurchased;
            data.sharpnelBallPurchased = sharpnelBallPurchased;
            data.zonicBallPurchased = zonicBallPurchased;
            data.apricotBallPurchased = apricotBallPurchased;
            data.peggoBallPurchased = peggoBallPurchased;
            data.ghostBallPurchased = ghostBallPurchased;
            data.starBallPurchased = starBallPurchased;
            data.rainbowBallPurchased = rainbowBallPurchased;
            data.glitchyBallPurchased = glitchyBallPurchased;

            data.aquaBallLevel = aquaBallLevel;
            data.mudBallLevel = mudBallLevel;
            data.basketBallLevel = basketBallLevel;
            data.plumBallLevel = plumBallLevel;
            data.stickyBallLevel = stickyBallLevel;
            data.candyBallLevel = candyBallLevel;
            data.cookieBallLevel = cookieBallLevel;
            data.limeBallLevel = limeBallLevel;
            data.goldenBallLevel = goldenBallLevel;
            data.footballBallLevel = footballBallLevel;
            data.sharpnelBallLevel = sharpnelBallLevel;
            data.zonicBallLevel = zonicBallLevel;
            data.apricotBallLevel = apricotBallLevel;
            data.peggoBallLevel = peggoBallLevel;
            data.ghostBallLevel = ghostBallLevel;
            data.starBallLevel = starBallLevel;
            data.rainbowBallLevel = rainbowBallLevel;
            data.glitchyBallLevel = glitchyBallLevel;
        }
    }
    #endregion
}
