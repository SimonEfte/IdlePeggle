using System.Collections;
using System.Globalization;
using UnityEngine;

public class LocalizationStrings : MonoBehaviour
{
    public static bool englishLanguage, chineseLanguage, koreanLanguage, japaneseLanguage, russianLanguage, spanishLanguage, germanLanguage, frenchLanguage;
    public static int language;

    public Challenges challScript;
    public PointsMechanics pointsScript;

    public void Start()
    {
        #region High number names
        million = "Million";
        billion = "Billion";
        trillion = "Trillion";
        quadrillion = "Quadrillion";
        quintillion = "Quintillion";
        sextillion = "Sextillion";
        septillion = "Septillion";
        octillion = "Octillion";
        nonillion = "Nonillion";
        decillion = "Decillion";
        undecillion = "Undecillion";
        duodecillion = "Duodecillion";
        tredecillion = "Tredecillion";
        quattuordecillion = "Quattuordecillion";
        quindecillion = "Quindecillion";
        sexdecillion = "Sexdecillion";
        septendecillion = "Septendecillion";
        octodecillion = "Octodecillion";
        novemdecillion = "Novemdecillion";
        vigintillion = "Vigintillion";
        unvigintillion = "Unvigintillion";
        duovigintillion = "Duovigintillion";
        trevigintillion = "Trevigintillion";

        millionAB = "m";
        billionAB = "b";
        trillionAB = "t";
        quadrillionAB = "qd";
        quintillionAB = "qi";
        sextillionAB = "sx";
        septillionAB = "sp";
        octillionAB = "o";
        nonillionAB = "n";
        decillionAB = "dc";
        undecillionAB = "ud";
        duodecillionAB = "dd";
        tredecillionAB = "td";
        quattuordecillionAB = "qtd";
        quindecillionAB = "qd";
        sexdecillionAB = "sxd";
        septendecillionAB = "sdc";
        octodecillionAB = "od";
        novemdecillionAB = "nd";
        vigintillionAB = "vt";
        unvigintillionAB = "ut";
        duovigintillionAB = "dv";
        trevigintillionAB = "tv";
        #endregion

        if (MobileScript.isMobile == false)
        {
            if (PlayerPrefs.HasKey("languageSelected"))
            {
                language = PlayerPrefs.GetInt("languageSelected");

                if (language == 1) { ChooseLanguage("English"); }
                if (language == 2) { ChooseLanguage("Chinese"); }
                if (language == 3) { ChooseLanguage("Japanese"); }
                if (language == 4) { ChooseLanguage("Korean"); }
                if (language == 5) { ChooseLanguage("Russian"); }
                if (language == 6) { ChooseLanguage("German"); }
                if (language == 7) { ChooseLanguage("French"); }
                if (language == 8) { ChooseLanguage("Spanish"); }
            }

            if (!PlayerPrefs.HasKey("languageSelected"))
            {
                // Determine the user's culture
                CultureInfo userCulture = CultureInfo.CurrentCulture;
                RegionInfo region = new RegionInfo(userCulture.Name);

                // Use the region name to set the language
                string regionName = region.Name;

                SetLanguageByRegion(regionName);
            }
        }
        else
        {
            ChooseLanguage("English");
        }
    }

    #region Check Country
    void SetLanguageByRegion(string regionName)
    {
        switch (regionName)
        {
            case "US":
            case "CA":
                ChooseLanguage("English");
                break;
            case "RU":
                ChooseLanguage("Russian"); 
                break;
            case "JP":
                ChooseLanguage("Japanese"); 
                break;
            case "KR":
                ChooseLanguage("Korean"); 
                break;
            case "CN":
                ChooseLanguage("Chinese"); 
                break;
            case "DE":
                ChooseLanguage("German"); 
                break;
            case "FR":
                ChooseLanguage("French"); 
                break;
            case "ES":
                ChooseLanguage("Spanish"); 
                break;
           
            default:
                // Set a default language if none of the cases match
                ChooseLanguage("English"); 
                break;
        }
    }
    #endregion


    #region ChooseLanguage
    public void ChooseLanguage(string language)
    {
        englishLanguage = false;
        chineseLanguage = false;
        koreanLanguage = false;
        japaneseLanguage = false;
        russianLanguage = false;
        spanishLanguage = false;
        germanLanguage = false;
        frenchLanguage = false;

        if (language == "Chinese") 
        { 
            chineseLanguage = true;
            ChineseChangeText();
        }
        if (language == "Korean") 
        { 
            koreanLanguage = true;
            KoreanChangeText();
        }
        if (language == "Japanese")
        {
            japaneseLanguage = true;
            JapaneseChangeText();
        }
        if (language == "English") 
        { 
            englishLanguage = true;
            EnglishChangeTexts();
        }
        if (language == "Russian") 
        {
            russianLanguage = true;
            RussianChangeText();
        }
        if (language == "German") 
        { 
            germanLanguage = true;
            GermanChangeText();
        }
        if (language == "French") 
        { 
            frenchLanguage = true;
            FrenchChangeText();
        }
        if (language == "Spanish") 
        { 
            spanishLanguage = true;
            SpanishChangeText();
        }

        StartCoroutine(wait());
        SetBallDesText();
        pointsScript.TextPopUpSliderValue();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        levelScript.SetNewText();
        tutorialScript.SetNewText();
        ballUpgradesScript.SetNewText();
        challScript.SetChallengeNumberText();
        challScript.SetRewardText();
        challScript.SetChallengeRewardText();
    }
    #endregion

    #region Variables
    public Levels levelScript;
    public Tutorial tutorialScript;
    public BallUpgrades ballUpgradesScript;

    public static string regularBallUpgrades, bouncyBallUpgrades, rockBallUgrades, bombBallUpgrades, aquaBallUpgrades, mudBallUpgrades, basketBallUpgrades, plumBallUpgrades, stickyBallUpgrades, candyBallUpgrades, cookieBallUpgrades, limeBallUpgrades, goldenBallUpgrades, footballBallUpgrades, sharpnelBallUpgrades, zonicBallUpgrades, apricotBallUpgrades, peggoBallUpgrades, ghostBallUpgrades, starBallUpgrades, rainbowBallUpgrades, glitchyBallUpgrades;

    public static string regularBallEquipped, bouncyBallEquipped, rockBallEquipped, bombBallEquipped, aquaBallEquipped, mudBallEquipped, basketBallEquipped, plumBallEquipped, stickyBallEquipped, candyBallEquipped, cookieBallEquipped, limeBallEquipped, goldenBallEquipped, footballBallEquipped, sharpnelBallEquipped, zonicBallEquipped, apricotBallEquipped, peggoBallEquipped, ghostBallEquipped, starBallEquipped, rainbowBallEquipped, glitchyBallEquipped;

    public static string levelString;
    public static string secondAbbreviation;

    public static string tutString1, tutString2, tutString3, tutString4, tutString5, tutString6;

    public static string goldenPegString, bucketString;

    public static string maxString, maxString2, lockedString;

    public static string firstRedPegString, firstRedPegString2;
    public static string goldenPegChanceString, prestigePegChanceString, prestigePointsString, ballsShotGoldIncreaseString, goldGainIncreaseString;
    public static string levelUnlockedString, levelBoardsAndPegsString;

    public static string levelSelectedString;
    public static string levelBoardCountString, levelPegsCountString;
    public static string bucket1MidString, bucketsLevel3, bucketsLevel4, bucketsLevel5, bucketsLevel6, bucketsLevel7, bucketsLevel8, bucketsLevel9, bucketsLevel10;
    public static string level1NameString, level2NameString, level3NameString, level4NameString, level5NameString, level6NameString, level7NameString, level8NameString, level9NameString, level10NameString;

    public static string chargedUpAmountString, ballsShotString;

    public static string regularBallDesString, bouncyBallDesString, rockBallDesString, bombBallDesString, aquaBallDesString, mudBallDesString, basketBallDesString, plumBallDesString, stickyBallDesString, candyBallDesString, cookieBallDesString, limeBallDesString, goldBallDesString, footBallDesString, sharpnelBallDesString, ringBallDesString, apricotBallDesString, peggoBallDesString, ghostBallDesString, starBallDesString, rainbowBallDesString, glitchyBallDesString;

    public static string redPegSpawnChanceString, redPegsHitString, rainbowPegSpawnChance, rainbowPegsHit, bombPegsSpawnChance, bombPegsHit, purplePegsSpawnChance, purplePegsHit, totalPrestigePointsGained, totalRestigePointsSpent;

    public static string million, billion, trillion, quadrillion, quintillion, sextillion, septillion, octillion, nonillion, decillion, undecillion, duodecillion, tredecillion, quattuordecillion, quindecillion, sexdecillion, septendecillion, octodecillion, novemdecillion, vigintillion, unvigintillion, duovigintillion, trevigintillion;

    public static string millionAB, billionAB, trillionAB, quadrillionAB, quintillionAB, sextillionAB, septillionAB, octillionAB, nonillionAB, decillionAB, undecillionAB, duodecillionAB, tredecillionAB, quattuordecillionAB, quindecillionAB, sexdecillionAB, septendecillionAB, octodecillionAB, novemdecillionAB, vigintillionAB, unvigintillionAB, duovigintillionAB, trevigintillionAB;

    public static string clearBonusString, bucketGoldClear, bucketGoldClear2, clearBonusAmountString, goldRushString, goldRushString2, goldDoubleOrMoreChances, goldBucketDoubleOrMoreChances, clearTimerString, clearTimerAmount;

    public static string prestigeClearBonus, prestigeClearBonus2, prestigeClearBonusAmount, prestigePointBucket, prestigePointBucketAmount, prestigeRush, prestigeRush2, prestige2XorMore;

    public static string redPegChance, redPegGoldDouble, redPegPrestigeDouble, rainbowPeg1, rainbowPeg2, rainbowPegChance, rainbowPegIncreaseBuffs, rainbowPegReceiveAllBuffs, bombPeg1, bombPeg2, bombPegChance, bombPeg3Balls, bombPeg3to5Balls, purplePeg1, purplePeg2, purplePegIncrease, purplePegChance, purplePegPrestigePoint, purplePegNextBall;

    public static string moreShots;

    public static string startWithGold, goldFromShooting, prestigePointFromShooting, morePrestigePointFromShooting;

    public static string lowBounce, midBounce, highBounce, noBounce;

    public static string challenge;

    public static string bounceCHstring, explodeTinyCHstring, basketballCHstring, eggCHstring, cookieCHstring, goldenBallCHstring, footballCHstring, tinyRingCHstring, prestigeGemCHstring, ghostballCHstring, starBallCHstring, rainbowBallCHstring, glitchyBallCHstring, sharpnelBallCSstring;

    public static string explodeTinyCHRewardstring, basketballCHRewardstring, eggCHRewardstring, cookieCHRewardstring, goldenBallCHRewardstring, footballCHRewardstring, tinyRingCHRewardstring, prestigeGemCHRewardstring, ghostballCHRewardstring, starBallCHRewardstring, rainbowBallCHRewardstring, glitchyBallCHRewardstring, goldScaling, sharpnelBallCSRewardstring;

    public static string prestigePegReward;

    public static string achString, chall1String, gold100string, purchase1Ballstring, goldRushACH, goldRushACH2, prestigeRushACH, prestigeRushACH2, allBufsString, clearBoardString, fullyChargeACHstring;

    public static string totalGoldRush, totalPRestigeRush, totalGoldFromClear, totalPrestigePointFromClear, totalPrestigePointFromBucket, totalGoldFromShooting;

    public static string goldFromPegsBUFF, goldFromBucketsBUFF, prestigePointsBUFF, prestigePointAllSourcesBuff, chancePrestigePointBucketBUFF, goldFromAllSourcesBUFF;

    public static string autoDropOff, autoDropOn;

    public static string sliderAll, sliderHalf, slider4Latest, slider3Latest, slider2Latest, sliderLatest, sliderNONE;

    #endregion

    //1
    #region English
    public void EnglishChangeTexts()
    {
        language = 1;
        PlayerPrefs.SetInt("languageSelected", language);

        autoDropOff = "AUTO DROP <color=red>(OFF)";
        autoDropOn = "AUTO DROP <color=green>(ON)";

        //New - Also add to demo
        lowBounce = "LOW";
        midBounce = "MID";
        highBounce = "HIGH";
        noBounce = "NONE";
        totalPrestigePointsGained = "Total prestige points gained:";
        totalRestigePointsSpent = "Total prestige points spent:";
        chancePrestigePointBucketBUFF = "<size==15>" + Prestige.rainbowPegPrestigePointChance + "% chance for 1 prestige point when a ball enteres a bucket.";
        goldFromAllSourcesBUFF = "<size==19>" + Prestige.goldRushIncrease + "X gold from all sources";
        prestigePointAllSourcesBuff = "<size==17>" + Prestige.prestigeRushIncrease + "X prestige points from all sources";

        regularBallUpgrades = "Regular Ball Upgrades";
        bouncyBallUpgrades = "Bouncy Ball Upgrades";
        rockBallUgrades = "Rock Ball Upgrades";
        bombBallUpgrades = "Bomb Ball Upgrades";

        #region Full game variables
        if (GameData.isDemo == false)
        {
            challenge = "CHALLENGE #";

            //Upgrades string
            #region Ball Upgrades
            aquaBallUpgrades = "Aqua Ball Upgrades";
            mudBallUpgrades = "Mud Ball Upgrades";
            basketBallUpgrades = "Basket Ball Upgrades";
            plumBallUpgrades = "Plum Ball Upgrades";
            stickyBallUpgrades = "Egg Ball Upgrades";
            candyBallUpgrades = "Candy Ball Upgrades";
            cookieBallUpgrades = "Cookie Ball Upgrades";
            limeBallUpgrades = "Lime Ball Upgrades";
            goldenBallUpgrades = "Golden Ball Upgrades";
            footballBallUpgrades = "Football Upgrades";
            sharpnelBallUpgrades = "Shrapnel Ball Upgrades";
            zonicBallUpgrades = "Ring Ball Upgrades";
            apricotBallUpgrades = "Apricot Ball Upgrades";
            peggoBallUpgrades = "Peggo Ball Upgrades";
            ghostBallUpgrades = "Ghost Ball Upgrades";
            starBallUpgrades = "Star Ball Upgrades";
            rainbowBallUpgrades = "Rainbow Ball Upgrades";
            glitchyBallUpgrades = "Glitchy Ball Upgrades";
            #endregion

            //Equipped strings
            #region Equipped
            aquaBallEquipped = "Aqua Ball Equipped";
            mudBallEquipped = "Mud Ball Equipped";
            basketBallEquipped = "Basketball Equipped";
            plumBallEquipped = "Plum Ball Equipped";
            stickyBallEquipped = "Egg Ball Equipped";
            candyBallEquipped = "Candy Ball Equipped";
            cookieBallEquipped = "Cookie Ball Equipped";
            limeBallEquipped = "Lime Ball Equipped";
            goldenBallEquipped = "Golden Ball Equipped";
            footballBallEquipped = "Football Equipped";
            sharpnelBallEquipped = "Shrapnel Ball Equipped";
            zonicBallEquipped = "Ring Ball Equipped";
            apricotBallEquipped = "Apricot Ball Equipped";
            peggoBallEquipped = "Peggo Ball Equipped";
            ghostBallEquipped = "Ghost Ball Equipped";
            starBallEquipped = "Star Ball Equipped";
            rainbowBallEquipped = "Rainbow Ball Equipped";
            glitchyBallEquipped = "Glitchy Ball Equipped";
            #endregion

            //Level names
            #region Level names
            level3NameString = "Level 3 - Dark Forest";
            level4NameString = "Level 4 - Frozen Night";
            level5NameString = "Level 5 - Graveyard";
            level6NameString = "Level 6 - Purple Forest";
            level7NameString = "Level 7 - Crypt";
            level8NameString = "Level 8 - Blue Forest";
            level9NameString = "Level 9 - Gold Cave";
            level10NameString = "Level 10 - Space";
            #endregion

            #region gold prestige upgrade text strings
            clearBonusString = "You now receive a gold bonus upon clearing the board.";
            bucketGoldClear = "You now also receive a board clear gold bonus when a ball enteres a bucket.";
            bucketGoldClear2 = $"Each time a ball enteres a bucket, <color=yellow>+{(Prestige.goldClearBonusFromBucket * 100).ToString("F0")}%</color> gold from the unlocked ball with the most gold will be added to the board clear bonus.";
            goldRushString = $"Hitting a golden peg have a <color=yellow>{Prestige.goldRushChance}%</color> chance to cause a <color=yellow>GOLD RUSH!";
            goldRushString2 = $"Gold rush will increase all gold received by <color=yellow>{Prestige.goldRushIncrease}X</color> for <color=green>{Prestige.goldRushTimer}</color> seconds";
            clearTimerString = "Board clear gold bonus will now also receive more gold based on how fast a board is cleared.";
            #endregion

            #region prestige upgrades text strings
            prestigeClearBonus = "You now receive a prestige point bonus upon clearing the board!";
            prestigeClearBonus2 = $"You will receive <color=orange>1</color> extra prestige point for each <color=orange>{Prestige.prestigeClearBonus1}</color> prestige pegs hit. Prestige pegs also give <color=orange>+1</color> prestige points.";
            prestigePointBucket = "You now have a small chance to receive prestige points when a ball enteres a bucket.";
            prestigeRush = $"Hitting a prestige peg has a <color=orange>{Prestige.prestigeRushChance}%</color> to cause a <color=orange>PRESTIGE RUSH!";
            prestigeRush2 = $"Prestige rush will increase all prestige points received by <color=orange>{Prestige.prestigeRushIncrease}X</color> for <color=green>{Prestige.prestigeRushTimer}</color> seconds";
            #endregion

            #region new pegs upgreades text string
            redPegGoldDouble = "Gold received from red pegs is doubled";
            redPegPrestigeDouble = "Prestige points received from red pegs is doubled";

            rainbowPeg1 = $"Rainbow pegs will start spawning! Rainbow pegs have a <color=green>{Prestige.rainbowPegChance1}%</color> chance to spawn.";
            rainbowPeg2 = $"Rainbow pegs will give <color=green>1 out of 4</color> buffs that last for <color=green>{Prestige.rainbowPegTimer}</color> seconds. \n<color=green>Buff 1:</color> 2X gold from golden pegs. \n<color=green>Buff 2:</color> 2X gold from the buckets. \n<color=green>Buff 3:</color> 2X prestige points. \n<color=green>Buff 4:</color> {Prestige.rainbowPegPrestigePointChance}% chance for prestige points when a ball enters a bucket.";

            rainbowPegIncreaseBuffs = "Buffs now give <color=green>3X</color> gold and prestige points.";
            rainbowPegReceiveAllBuffs = "Hitting a rainbow peg will now give all <color=green>4</color> buffs.";

            bombPeg1 = $"Bomb pegs will start spawning! Bomb pegs have a <color=green>{Prestige.bombPegChance1}%</color> chance to spawn.";
            bombPeg2 = "Balls that hit the bomb peg will explode into <color=green>2</color> more balls.";
            bombPeg3Balls = "Bomb pegs now explode into <color=green>3</color> balls!";
            bombPeg3to5Balls = "Bomb pegs now explode into <color=green>3-5</color> balls!";

            purplePeg1 = $"Purple pegs will start spawning! Purple pegs have a <color=green>{Prestige.purplePegChance1}%</color> chance to spawn.";
            purplePeg2 = $"Balls that hit the purple peg will be enhanced. Enhanced balls will receive <color=green>{Prestige.purplePegEnchanceIncrease1}X</color> gold and prestige points.";
            purplePegPrestigePoint = "Enhanced balls that land into the bucket always give <color=orange>1</color> prestige point.";
            purplePegNextBall = "<size=11>When hitting a purple peg, the next ball that is either dropped or shot is already enhanced.";
            #endregion

            //Stats
            #region new stats
            rainbowPegSpawnChance = "Rainbow peg spawn chance:";
            rainbowPegsHit = "Rainbow pegs hit:";
            bombPegsSpawnChance = "Bomb peg spawn chance:";
            bombPegsHit = "Bomb pegs hit:";
            purplePegsSpawnChance = "Purple peg spawn chance:";
            purplePegsHit = "Purple pegs hit:";

            totalGoldRush = "Total times achieved a gold rush:";
            totalGoldFromClear = "Total gold from clear bonus: ";
            totalGoldFromShooting = "Total gold from shooting: ";

            totalPRestigeRush = "Total times achieved a prestige rush:";
            totalPrestigePointFromClear = "Total prestige points from clear bonus:";
            totalPrestigePointFromBucket = "Total prestige points from bucket:";
            #endregion

            //Challenges
            #region Challenge strings
            bounceCHstring = $"Bounce a bouncy ball on {Challenges.bounceCH} pegs";
            explodeTinyCHstring = $"Explode bomb balls into {Challenges.explodeTinyCH} tiny balls";
            basketballCHstring = $"Hit {Challenges.basketballCH} pegs with the basketball";
            eggCHstring = $"Receive double gold from egg balls {Challenges.eggCH}\ntimes";
            cookieCHstring = $"Receive {Challenges.cookieCH} extra prestige points from \ncookie balls";
            goldenBallCHstring = $"Receive extra gold from the golden ball \n{Challenges.goldenBallCH} times";
            footballCHstring = $"Enter {Challenges.footballCH} footballs into the bucket";
            tinyRingCHstring = $"Spawn {Challenges.tinyRingCH} tiny ring balls";
            prestigeGemCHstring = $"Hit {Challenges.prestigeGemCH} prestige gems";
            ghostballCHstring = $"Have {Challenges.ghostballCH} ghost balls on screen at the \nsame time";
            starBallCHstring = $"Spawn {Challenges.starBallCH} star balls";
            rainbowBallCHstring = $"Receive a total of +{Challenges.rainbowBallCH}% gold from \nrainbow balls";
            glitchyBallCHstring = $"Spawn {Challenges.glitchyBallCH} tiny glitchy balls";
            sharpnelBallCSstring = $"Spawn {Challenges.sharpnelBallCH} tiny shrapnel balls";

            //Rewards
            explodeTinyCHRewardstring = $"Reward: Tiny bomb balls now give <color=yellow>{Challenges.explodeTinyCHReward * 100}%</color> of the bomb balls gold";
            basketballCHRewardstring = $"Reward: Basketballs now give <color=yellow>+{Challenges.basketballCHReward * 100}%</color> gold increase per bounce";
            eggCHRewardstring = $"Reward: Egg balls now have a <color=yellow>{Challenges.eggCHReward}%</color> to receive double gold";
            cookieCHRewardstring = $"Reward: Cookie balls now have a <color=green>{Challenges.cookieCHReward}%</color> chance to receive <color=orange>2X</color> prestige points";
            goldenBallCHRewardstring = "Reward: Increases <color=yellow>2X, 3X and 5X</color> gold chances for golden balls";
            footballCHRewardstring = $"Reward: Footballs now give <color=yellow>{Challenges.footballCHReward}X</color> gold upon landing in a bucket";
            tinyRingCHRewardstring = $"Reward: Tiny ring balls now give <color=yellow>{Challenges.tinyRingCHReward * 100}%</color> of the ring balls gold";
            prestigeGemCHRewardstring = $"Reward: More prestige gems spawn";
            ghostballCHRewardstring = $"Reward: Ghost balls now give a <color=yellow>+{Challenges.ghostballCHReward * 100}%</color> gold increase";
            starBallCHRewardstring = $"Reward: It now takes <color=green>{Challenges.starBallCHReward}</color> peg hits to spawn a star ball";
            rainbowBallCHRewardstring = $"Reward: Rainbow balls now give <color=yellow>+{Challenges.rainbowBallCHReward * 100}%</color> gold increase per peg hit";
            glitchyBallCHRewardstring = $"Reward: Improves the buffs of all balls";
            goldScaling = "Reward: Increases the gold scaling per level <color=green>30</color>";
            prestigePegReward = $"Reward: <color=orange>+{Challenges.prestigePegReward}%</color> prestige peg spawn chance";
            sharpnelBallCSRewardstring = $"Reward: Tiny shrapnel balls now give <color=green>{Challenges.sharpnelBallCHReward * 100}%</color> of the shrapnels ball gold";
            #endregion
            
            //ACH
            #region ACH string
            clearBoardString = "Clear the board";
            fullyChargeACHstring = "Fully charge the shooter";
            chall1String = "Complete a challenge";
            purchase1Ballstring = "Purchase a new ball";
            goldRushACH = "Achieve a gold rush";
            goldRushACH2 = $"Achieve a gold rush {Achievements.goldRushNeeded2} times";
            prestigeRushACH = "Achieve a prestige rush";
            prestigeRushACH2 = $"Achieve a prestige rush {Achievements.prestigeRushNeeded2} times";
            allBufsString = "Acquire all buffs at the same time";
            #endregion

            #region Slider strings
            sliderAll = "Gold text pop ups = <color=green>ALL BALLS";
            sliderHalf = "Gold text pop ups = <color=green>50% OF BALLS";
            slider4Latest = "Gold text pop ups = <color=green>4 LATEST BALLS";
            slider3Latest = "Gold text pop ups = <color=green>3 LATEST BALLS";
            slider2Latest = "Gold text pop ups = <color=green>2 LATEST BALLS";
            sliderLatest = "Gold text pop ups = <color=green>LATEST BALL";
            sliderNONE = "Gold text pop ups = <color=red>NONE";
            #endregion

            prestigePointFromShooting = $"Shooting balls have a <color=green>{Prestige.prestigePointFromShotChance}%</color> chance to give <color=orange>1</color> prestige point.";
        }
        #endregion

        regularBallEquipped = "Regular Ball Equipped";
        bouncyBallEquipped = "Bouncy Ball Equipped";
        rockBallEquipped = "Rock Ball Equipped";
        bombBallEquipped = "Bomb Ball Equipped";

        levelString = "Level ";
        secondAbbreviation = "s";

        maxString = "MAX";
        maxString2 = "(MAX)";

        lockedString = "<size=22>(LOCKED)";

        level1NameString = "Level 1 - Forest";
        level2NameString = "Level 2 - City";
        
        firstRedPegString = $"Red pegs will start spawning. Red pegs have a <color=green>{Prestige.redPegChance1.ToString("F1")}%</color> chance to spawn.";
        firstRedPegString2 = "Red pegs give both gold and prestige points.";

        bucket1MidString = "Buckets:<color=green> 1 Mid Size";
        bucketsLevel3 = "Buckets:<color=green> 1 Large";
        bucketsLevel4 = "Buckets:<color=green> 1 Large & 1 small size";
        bucketsLevel5 = "Buckets:<color=green> 1 Large & 1 mid size";
        bucketsLevel6 = "Buckets:<color=green> 1 Large, 1 mid & 1 small size";
        bucketsLevel7 = "Buckets:<color=green> 2 Large size";
        bucketsLevel8 = "Buckets:<color=green> 2 Large & 1 mid size";
        bucketsLevel9 = "Buckets:<color=green> 2 Large & 2 mid size";
        bucketsLevel10 = "Buckets:<color=green> 2 Large, 2 mid & 2 small size";

        redPegSpawnChanceString = "Red peg spawn chance:";
        redPegsHitString = "Red pegs hit:";

        #region Tutorial Strings
        if (MobileScript.isMobile == false)
        {
            tutString1 = "Aim anywhere on the board to shoot balls at the pegs!";
            tutString2 = "You just cleared the board for the first time and a new board will spawn! Your ball shooter will charge up each time the board is cleared. Hover over the ball shooter to see the progress.";
            tutString3 = "You just purchased a new ball! You can equip each ball inside the ball upgrade frame, or INSTA EQUIPP by pressing the number <color=green>1-9 keys.";
            tutString4 = "Once the ball falls into the pit or the bucket, the ball will be returned.";
            tutString5 = "Hit the pegs! Green pegs bounces the ball. Gold pegs give gold. Orange \"Prestige Pegs\" give prestige points!";
            tutString6 = "<size=22>Click on the balls to open the ball upgrades frame! When leveling up the ball, every 30th level increases the ball gold increment amount. Hold down TAB to purchase MAX upgrades!";
        }

        if(MobileScript.isMobile == true)
        {
            tutString1 = "Tap anywhere on the board to shoot balls at the pegs!";
            tutString2 = "<size=22>You just cleared the board for the first time and a new board will spawn! Your ball shooter will charge up each time the board is cleared. Click on the ball shooter to see the progress.";
            tutString3 = "<size=25>You just purchased a new ball! You can equip each ball inside the ball upgrade frame.";
            tutString4 = "Once the ball falls into the pit or the bucket, the ball will be returned.";
            tutString5 = "Hit the pegs! Green pegs bounces the ball. Gold pegs give gold. Orange \"Prestige Pegs\" give prestige points!";
            tutString6 = "<size=22>Click on the balls to open the ball upgrades frame! When leveling up the ball, every 30th level increases the ball gold increment amount.";
        }
        #endregion
    }
    #endregion

    //2
    #region Chinese
    public void ChineseChangeText()
    {
        language = 2;
        PlayerPrefs.SetInt("languageSelected", language);

        autoDropOff = "自动掉落 <color=red>(关)";
        autoDropOn = "自动掉落 <color=green>(开)";

        regularBallUpgrades = "正常弹珠升级";
        bouncyBallUpgrades = "弹力弹珠升级";
        rockBallUgrades = "岩石弹珠升级";
        bombBallUpgrades = "炸弹弹珠升级";

        regularBallEquipped = "正常弹珠已装备";
        bouncyBallEquipped = "弹力弹珠已装备";
        rockBallEquipped = "岩石弹珠已装备";
        bombBallEquipped = "炸弹弹珠已装备";

        //New - Also add to demo
        lowBounce = "低弹";
        midBounce = "中弹";
        highBounce = "高弹";
        noBounce = "无弹";
        totalPrestigePointsGained = "获得的威望分总数：";
        totalRestigePointsSpent = "花费的威望分总数：";
        chancePrestigePointBucketBUFF = "<size==15>弹珠进入桶中时有" + Prestige.rainbowPegPrestigePointChance + "%的几率获得1分威望分";
        goldFromAllSourcesBUFF = "<size==19>所有来源的的" + Prestige.goldRushIncrease + "倍金币";
        prestigePointAllSourcesBuff = "<size==17>所有来源的" + Prestige.prestigeRushIncrease + "倍威望分";

        levelString = "等级: ";
        secondAbbreviation = "秒";

        maxString = "最大";
        maxString2 = "(最大)";

        lockedString = "(已锁定)";
     
        firstRedPegString = $"红色彩钉将开始生成。红色彩钉生成的几率为<color=green>{Prestige.redPegChance1}%";
        firstRedPegString2 = "红色彩钉给予金币和威望点数。";

        level1NameString = "第 1 级 - 森林";
        level2NameString = "第 2 级 - 城市";

        bucket1MidString = "桶：<color=green>1 个中型";
        bucketsLevel3 = "桶:<color=green> 1个大型";
        bucketsLevel4 = "桶:<color=green> 1个大型1个小型";
        bucketsLevel5 = "桶:<color=green> 1个大型1个中型";
        bucketsLevel6 = "桶:<color=green> 1个大型1个中型1个小型";
        bucketsLevel7 = "桶:<color=green> 2个大型";
        bucketsLevel8 = "桶:<color=green> 2个大型1个中型";
        bucketsLevel9 = "桶:<color=green> 2个大型2个中型";
        bucketsLevel10 = "桶:<color=green> 2个大型2个中型2个小型";

        redPegSpawnChanceString = "红色彩钉生成几率：";
        redPegsHitString = "红色彩钉彩钉击中：";

        #region Full game variables
        if (GameData.isDemo == false)
        {
            challenge = "挑战 #";

            //Upgrades string
            #region Ball Upgrades
            aquaBallUpgrades = "水弹珠升级";
            mudBallUpgrades = "泥弹珠升级";
            basketBallUpgrades = "篮子弹珠升级";
            plumBallUpgrades = "李子弹珠升级";
            stickyBallUpgrades = "蛋弹珠升级";
            candyBallUpgrades = "糖果弹珠升级";
            cookieBallUpgrades = "饼干弹珠升级";
            limeBallUpgrades = "青柠弹珠升级";
            goldenBallUpgrades = "金弹珠升级";
            footballBallUpgrades = "足球弹珠升级";
            sharpnelBallUpgrades = "弹片弹珠升级";
            zonicBallUpgrades = "环形弹珠升级";
            apricotBallUpgrades = "杏子弹珠升级";
            peggoBallUpgrades = "Peggo弹珠升级";
            ghostBallUpgrades = "幽灵弹珠升级";
            starBallUpgrades = "星星弹珠升级";
            rainbowBallUpgrades = "彩虹弹珠升级";
            glitchyBallUpgrades = "故障弹珠升级";
            #endregion

            //Equipped strings
            #region Equipped
            aquaBallEquipped = "水弹珠已装备";
            mudBallEquipped = "泥弹珠已装备";
            basketBallEquipped = "篮球弹珠已装备";
            plumBallEquipped = "李子弹珠已装备";
            stickyBallEquipped = "蛋弹珠已装备";
            candyBallEquipped = "糖果弹珠已装备";
            cookieBallEquipped = "饼干弹珠已装备";
            limeBallEquipped = "青柠弹珠已装备";
            goldenBallEquipped = "金弹珠已装备";
            footballBallEquipped = "足球弹珠已装备";
            sharpnelBallEquipped = "弹片弹珠已装备";
            zonicBallEquipped = "环形弹珠已装备";
            apricotBallEquipped = "杏子弹珠已装备";
            peggoBallEquipped = "Peggo弹珠已装备";
            ghostBallEquipped = "幽灵弹珠已装备";
            starBallEquipped = "星星弹珠已装备";
            rainbowBallEquipped = "彩虹弹珠已装备";
            glitchyBallEquipped = "故障弹珠已装备";
            #endregion

            //Level names
            #region Level names
            level3NameString = "关卡 3 - 黑暗森林";
            level4NameString = "关卡 4 - 冰冻之夜";
            level5NameString = "关卡 5 - 墓园";
            level6NameString = "关卡 6 - 紫色森林";
            level7NameString = "关卡 7 - 地穴";
            level8NameString = "关卡 8 - 蓝色森林";
            level9NameString = "关卡 9 - 金色洞穴";
            level10NameString = "关卡 10 - 太空";
            #endregion

            #region gold prestige upgrade text strings
            clearBonusString = "完成关卡后，您现在可以获得金币奖励。";
            bucketGoldClear = "当球进入桶中时，您现在还会获得清空游戏盘的金币奖励。";
            bucketGoldClear2 = $"每次弹珠进入桶中时，金币最多的已解锁弹珠中的<color=yellow>{(Prestige.goldClearBonusFromBucket * 100).ToString("F0")}%</color>金币会被加到清空游戏盘的奖励中。";
            goldRushString = $"击中黄金彩钉有<color=yellow>{Prestige.goldRushChance}%</color>的几率触发金币狂潮！";
            goldRushString2 = $"金币狂潮会使所有获得的金币在<color=green>{Prestige.goldRushTimer}</color>秒内增加<color=yellow>{Prestige.goldRushIncrease}</color>倍。";
            clearTimerString = "清空游戏盘的金币奖励现在还会根据清空游戏盘的速度获得更多金币。";
            #endregion

            #region prestige upgrades text strings
            prestigeClearBonus = "完成关卡后，您现在可以获得威望奖励分！";
            prestigeClearBonus2 = $"每击中<color=orange>{Prestige.prestigeClearBonus1}</color>个威望彩钉，就会获得<color=orange>1</color>个额外的威望分。威望彩钉还会额外给予<color=orange>+1</color>个声望分。";
            prestigePointBucket = "现在弹珠进入桶中时，有小概率获得威望分。";
            prestigeRush = $"击中威望彩钉有<color=orange>{Prestige.prestigeRushChance}%</color>的几率触发威望狂潮！";
            prestigeRush2 = $"威望狂潮会使所有获得的威望分在<color=green>{Prestige.prestigeRushTimer}</color>秒内增加<color=orange>{Prestige.prestigeRushIncrease}</color>倍";
            #endregion

            #region new pegs upgreades text string
            redPegGoldDouble = "从红色彩钉获得的金币翻倍。";
            redPegPrestigeDouble = "从红色彩钉获得的威望分翻倍。";

            rainbowPeg1 = $"彩虹彩钉将开始生成！彩虹彩钉有<color=green>{Prestige.rainbowPegChance1}%</color>的几率生成。";
            rainbowPeg2 = $"彩虹彩钉将提供4种增益中的1种，持续<color=green>{Prestige.rainbowPegTimer}</color>秒。\n增益1：黄金彩钉的金币翻倍。\n增益2：从桶中获得的金币翻倍。\n增益3：威望分翻倍。\n增益4：弹珠进入桶中时，有{Prestige.rainbowPegPrestigePointChance}%的几率获得威望分。";
            rainbowPegIncreaseBuffs = "增益现在提供<color=green>3</color>倍的金币和威望分。";
            rainbowPegReceiveAllBuffs = "击中彩虹彩钉现在将获得所有<color=green>4</color>种增益。";

            bombPeg1 = $"炸弹彩钉将开始生成！炸弹彩钉有<color=green>{Prestige.bombPegChance1}%</color>的几率生成。";
            bombPeg2 = "击中炸弹彩钉的弹珠会爆炸成另外两个弹珠。";
            bombPeg3Balls = "炸弹彩钉现在爆炸成<color=green>3</color>个弹珠！";
            bombPeg3to5Balls = "炸弹彩钉现在爆炸成<color=green>3-5</color>个弹珠！";

            purplePeg1 = $"紫色彩钉开始生成！紫色彩钉有<color=green>{Prestige.purplePegChance1}%</color>的几率生成。";
            purplePeg2 = $"击中紫色彩钉的球会被强化。强化后的球将获得3倍金币和威望分。";
            purplePegPrestigePoint = "掉进桶里的强化弹珠都会给<color=orange>1</color>分威望分。";
            purplePegNextBall = "击中紫色彩钉后，下一个掉落或发射的球会直接被强化。";
            #endregion

            //Stats
            #region new stats
            rainbowPegSpawnChance = "彩虹彩钉生成几率：";
            rainbowPegsHit = "击中彩虹彩钉：";
            bombPegsSpawnChance = "炸弹彩钉生成几率：";
            bombPegsHit = "击中炸弹彩钉：";
            purplePegsSpawnChance = "紫色彩钉生成几率：";
            purplePegsHit = "击中紫色彩钉：";

            totalGoldRush = "达成黄金狂潮的总次数：";
            totalGoldFromClear = "来自清除奖励的总金币：";
            totalGoldFromShooting = "来自射击的总金币：";

            totalPRestigeRush = "达成威望狂潮的总次数：";
            totalPrestigePointFromClear = "来自清除奖励的总威望分：";
            totalPrestigePointFromBucket = "来自桶的总威望分：";
            #endregion

            //Challenges
            #region Challenge strings
            bounceCHstring = $"使弹力弹珠弹到{Challenges.bounceCH}个彩钉上";
            explodeTinyCHstring = $"将炸弹弹珠爆炸成{Challenges.explodeTinyCH}个小弹珠";
            basketballCHstring = $"用篮球弹珠击中{Challenges.basketballCH}个彩钉";
            eggCHstring = $"从蛋弹珠中获得双倍金币{Challenges.eggCH}次";
            cookieCHstring = $"从饼干弹珠中获得额外{Challenges.cookieCH}威望分";
            goldenBallCHstring = $"从金弹珠中获得额外金币{Challenges.goldenBallCH}次";
            footballCHstring = $"将{Challenges.footballCH}个足球弹珠送入桶中";
            tinyRingCHstring = $"生成{Challenges.tinyRingCH}个小环弹珠";
            prestigeGemCHstring = $"击中{Challenges.prestigeGemCH}个威望宝石";
            ghostballCHstring = $"同时在屏幕上出现{Challenges.ghostballCH}个幽灵弹珠";
            starBallCHstring = $"生成{Challenges.starBallCH}个星星弹珠";
            rainbowBallCHstring = $"从彩虹弹珠中总共获得+{Challenges.rainbowBallCH}%的金币";
            glitchyBallCHstring = $"生成{Challenges.glitchyBallCH}个小故障弹珠";
            sharpnelBallCSstring = $"生成{Challenges.sharpnelBallCH}个小弹片弹珠";

            //Rewards
            explodeTinyCHRewardstring = $"奖励：小炸弹弹珠现在给予炸弹弹珠金币的<color=yellow>{Challenges.explodeTinyCHReward * 100}%";
            basketballCHRewardstring = $"奖励：篮球弹珠现在每次弹跳增加<color=yellow>+{Challenges.basketballCHReward * 100}%</color>的金币";
            eggCHRewardstring = $"奖励：蛋弹珠现在有<color=yellow>{Challenges.eggCHReward}%</color>的几率获得双倍金币";
            cookieCHRewardstring = $"奖励：饼干弹珠现在有<color=green>{Challenges.cookieCHReward}%</color>的几率获得2倍威望分";
            goldenBallCHRewardstring = "奖励：增加黄金弹珠的<color=yellow>2倍、3倍和5</color>倍金币几率";
            footballCHRewardstring = $"奖励：足球弹珠现在落入桶中时给予<color=yellow>{Challenges.footballCHReward}</color>倍的金币";
            tinyRingCHRewardstring = $"奖励：小环形弹珠现在给予环形弹珠金币的<color=yellow>{Challenges.tinyRingCHReward * 100}%</color>";
            prestigeGemCHRewardstring = $"奖励：生成更多威望宝石";
            ghostballCHRewardstring = $"奖励：幽灵弹珠现在给予增加<color=yellow>+{Challenges.ghostballCHReward * 100}%</color>的金币";
            starBallCHRewardstring = $"奖励：现在击中<color=green>{Challenges.starBallCHReward}</color>个彩钉生成一个星星弹珠";
            rainbowBallCHRewardstring = $"奖励：彩虹弹珠每击中一个彩钉给予增加<color=yellow>+{Challenges.rainbowBallCHReward * 100}%</color>的金币";
            glitchyBallCHRewardstring = $"奖励：提升所有弹珠的增益效果";
            goldScaling = "奖励：增加每个弹珠等级30的金币缩放";
            prestigePegReward = $"奖励：<color=orange>+{Challenges.prestigePegReward}%</color>威望钉生成几率";
            sharpnelBallCSRewardstring = $"奖励：小弹片弹珠现在给予弹片弹珠金币的<color=green>{Challenges.sharpnelBallCHReward * 100}%</color>";
            #endregion

            //ACH
            #region ACH string
            clearBoardString = "清除游戏盘";
            fullyChargeACHstring = "完全充能发射器";
            chall1String = "完成一个挑战";
            purchase1Ballstring = "购买一个新弹珠";
            goldRushACH = "达成黄金狂潮";
            goldRushACH2 = $"达成黄金狂潮{Achievements.goldRushNeeded2}次";
            prestigeRushACH = "达成威望狂潮";
            prestigeRushACH2 = $"达成威望狂潮{Achievements.prestigeRushNeeded2}次";
            allBufsString = "同时获得所有增益";
            #endregion

            #region Slider strings
            sliderAll = "金色文字弹出 = <color=green>所有球";
            sliderHalf = "金色文字弹出  = <color=green>50%的球";
            slider4Latest = "金色文字弹出  = <color=green>最新的4个球";
            slider3Latest = "金色文字弹出  = <color=green>最新的3个球";
            slider2Latest = "金色文字弹出  = <color=green>最新的2个球";
            sliderLatest = "金色文字弹出  = <color=green>最新的球";
            sliderNONE = "金色文字弹出  = <color=red>无";
            #endregion

            prestigePointFromShooting = $"射击弹珠有<color=green>{Prestige.prestigePointFromShotChance}%</color>的几率获得1点威望分";
        }
        #endregion

        #region Tutorial Strings
        tutString1 = "在游戏盘上的任何地方瞄准并射出弹珠打中彩钉！";
        tutString2 = "<size=24>你刚刚第一次过关了游戏盘，一个新的游戏盘将会生成！每次过关游戏盘后，你的弹珠发射器都会充能。悬停在弹珠发射器上以查看进度。";
        tutString3 = "你刚刚购买了一个新的弹珠！你可以在弹珠升级框内装备每一个弹珠，或者按下数字键 1-9 进行即时装备";
        tutString4 = "一旦弹珠掉入坑中或桶中，弹珠将会被返回";
        tutString5 = "击中彩钉！绿色彩钉会反弹弹珠。金色彩钉会给予金币。橙色“威望彩钉”会给予威望点数！";
        tutString6 = "<size=24>一旦你有足够的金币，你就可以升级你的弹珠并购买新的弹珠！升级弹珠时，每达到第30级，弹珠的金币增量都会增加。按住 TAB 键以购买最大升级";
        #endregion
    }
    #endregion 

    //3
    #region Japanese
    public void JapaneseChangeText()
    {
        language = 3;
        PlayerPrefs.SetInt("languageSelected", language);

        autoDropOff = "自動ドロップ <color=red>(オフ)";
        autoDropOn = "自動ドロップ <color=green>(オン)";

        regularBallUpgrades = "<size=10>レギュラーボールのアップグレード";
        bouncyBallUpgrades = "<size=10>バウンシー・ボール・アップグレード";
        rockBallUgrades = "<size=10>ロック・ボールのアップグレード";
        bombBallUpgrades = "<size=10>ボム・ボールのアップグレード";

        regularBallEquipped = "レギュラーボール装備";
        bouncyBallEquipped = "バウンシーボール装備";
        rockBallEquipped = "ロックボール装備";
        bombBallEquipped = "ボムボール装備";

        //New - Also add to demo
        lowBounce = "低";
        midBounce = "中";
        highBounce = "高";
        noBounce = "なし";
        totalPrestigePointsGained = "獲得プレステージポイント合計：";
        totalRestigePointsSpent = "消費したプレステージポイント合計：";
        chancePrestigePointBucketBUFF = "ボールがバケツに入った時、" + Prestige.rainbowPegPrestigePointChance + "% の確率でプレステージポイント1倍";
        goldFromAllSourcesBUFF = "<size==19>すべてのソースからのゴールド" + Prestige.goldRushIncrease + "倍";
        prestigePointAllSourcesBuff = "<size==17>すべてのソースからのプレステージポイント" + Prestige.prestigeRushIncrease + "倍";

        levelString = "レベル";
        secondAbbreviation = "秒";

        maxString = "最高";
        maxString2 = "(最高)";

        lockedString = "(ロック)";

        firstRedPegString = $"<size=10.5>赤ペグが出現し始める。赤ペグは<color=green>{Prestige.redPegChance1}%</color>の確率で出現します。";
        firstRedPegString2 = "<size=10.5>赤ペグはゴールドとプレステージポイントの両方を与えます。";

        level1NameString = "レベル1 - 森林";
        level2NameString = "レベル2 - 都市";

        bucket1MidString = "バケツ:1<color=green>ミドルサイズ";
        bucketsLevel3 = "バケツ:<color=green> 大1個";
        bucketsLevel4 = "バケツ:<color=green> 大1個 & 小1個";
        bucketsLevel5 = "バケツ:<color=green> 大2個 & 中1個";
        bucketsLevel6 = "バケツ:<color=green> 大1個 & 中1個 & 小1個";
        bucketsLevel7 = "バケツ:<color=green> 大2個";
        bucketsLevel8 = "バケツ:<color=green> 大2個 & 中1個";
        bucketsLevel9 = "バケツ:<color=green> 大2個 & 中2個";
        bucketsLevel10 = "バケツ:<color=green> 大2個 & 中2個 & 小2個";

        redPegSpawnChanceString = "赤ペグの出現確率：";
        redPegsHitString = "赤ペグにヒット：";

        #region Full game variables
        if (GameData.isDemo == false)
        {
            challenge = "チャレンジ #";

            //Upgrades string
            #region Ball Upgrades
            aquaBallUpgrades = "<size=10>アクアボールのアップグレード";
            mudBallUpgrades = "<size=10>マッドボールのアップグレード";
            basketBallUpgrades = "<size=10>バスケットボールのアップグレード";
            plumBallUpgrades = "<size=10>プラムボールのアップグレード";
            stickyBallUpgrades = "<size=10>エッグボールのアップグレード";
            candyBallUpgrades = "<size=10>キャンディーボールのアップグレード";
            cookieBallUpgrades = "<size=10>クッキーボールのアップグレード";
            limeBallUpgrades = "<size=10>ライムボールのアップグレード";
            goldenBallUpgrades = "<size=10>ゴールデンボールアップグレード";
            footballBallUpgrades = "<size=10>フットボールのアップグレード";
            sharpnelBallUpgrades = "<size=10>シュラプネルボールのアップグレード";
            zonicBallUpgrades = "<size=10>リングボールのアップグレード";
            apricotBallUpgrades = "<size=10>アプリコットボールのアップグレード";
            peggoBallUpgrades = "<size=10>ペゴボールのアップグレード";
            ghostBallUpgrades = "<size=10>ゴーストボールのアップグレード";
            starBallUpgrades = "<size=10>スターボールのアップグレード";
            rainbowBallUpgrades = "<size=10>レインボーボールのアップグレード";
            glitchyBallUpgrades = "<size=10>グリッチーボールのアップグレード";
            #endregion

            //Equipped strings
            #region Equipped
            aquaBallEquipped = "アクアボールを装備";
            mudBallEquipped = "マッドボールを装備";
            basketBallEquipped = "バスケットボール を装備";
            plumBallEquipped = "プラムボールを装備";
            stickyBallEquipped = "エッグボールを装備";
            candyBallEquipped = "キャンディボールを装備";
            cookieBallEquipped = "クッキーボールを装備";
            limeBallEquipped = "ライムボールを装備";
            goldenBallEquipped = "ゴールデンボールを装備";
            footballBallEquipped = "サッカーボールを装備";
            sharpnelBallEquipped = "シュラプネルボールを装備";
            zonicBallEquipped = "リングボールを装備";
            apricotBallEquipped = "アプリコットボールを装備";
            peggoBallEquipped = "ペゴボールを装備";
            ghostBallEquipped = "ゴーストボールを装備";
            starBallEquipped = "スターボールを装備";
            rainbowBallEquipped = "レインボーボールを装備";
            glitchyBallEquipped = "グリッチボールを装備";
            #endregion

            //Level names
            #region Level names
            level3NameString = "レベル3 - 暗黒の森";
            level4NameString = "レベル4 - 凍てつく夜";
            level5NameString = "レベル5 - 墓地";
            level6NameString = "レベル6 - 紫の森";
            level7NameString = "レベル7 - クリプト";
            level8NameString = "レベル8 - 蒼の森";
            level9NameString = "レベル9 - 金の洞窟";
            level10NameString = "レベル10 - 宇宙";
            #endregion

            #region gold prestige upgrade text strings
            clearBonusString = "ボードクリア時にゴールドボーナスを受け取れるようになりました。";
            bucketGoldClear = "<size=11>また、ボールがバケツに入ると、ボードクリア・ゴールドボーナスがもらえるようになりました。";
            bucketGoldClear2 = $"<size=11>ボールがバケツに入るたびに、ロックされていないボールのうち最もゴールドが多いボールのゴールドが<color=yellow>+{(Prestige.goldClearBonusFromBucket * 100).ToString("F0")}%</color>され、ボードクリアボーナスに加算されます。";
            goldRushString = $"ゴールデンペグに当たると、<color=yellow>{Prestige.goldRushChance}%</color>の確率でゴールドラッシュが発生します！";
            goldRushString2 = $"ゴールドラッシュになると<color=green>{Prestige.goldRushTimer}</color>秒間、すべてのゴールドが<color=yellow>{Prestige.goldRushIncrease}</color>倍になります。";
            clearTimerString = "ボードクリア・ゴールドボーナスでは、ボードクリアの速さに応じて、獲得ゴールドが増加します。";
            #endregion

            #region prestige upgrades text strings
            prestigeClearBonus = "<size=11>ボードクリア時にプレステージ・ポイントボーナスを受け取れるようになりました！";
            prestigeClearBonus2 = $"<size=11>プレステージペグが<color=orange>{Prestige.prestigeClearBonus1}</color>本命中するごとに、プレステージポイントが<color=orange>1</color>ポイント加算されます。また、プレステージペグは<color=orange>+1</color>プレステージポイントを与えます。";
            prestigePointBucket = "<size=11>ボールがバケツに入ったとき、わずかな確率でプレステージポイントを獲得できるようになりました。";
            prestigeRush = $"プレステージペグに当たると、<color=orange>{Prestige.prestigeRushChance}%</color>の確率でプレステージラッシュが発生します！";
            prestigeRush2 = $"プレステージラッシュは<color=green>{Prestige.prestigeRushTimer}</color>秒間、すべてのプレステージポイントを<color=orange>{Prestige.prestigeRushIncrease}</color>倍にします。";
            #endregion

            #region new pegs upgreades text string
            redPegGoldDouble = "赤ペグから受け取るゴールドが2倍になります。";
            redPegPrestigeDouble = "赤ペグから受け取るプレステージポイントが2倍になります。";

            rainbowPeg1 = $"<size=11>レインボーペグが出現します！レインボーペグは<color=green>{Prestige.rainbowPegChance1}%</color>の確率で発生します。";
            rainbowPeg2 = $"<size=11>レインボーペグは4つのうちバフを1つ選び、<color=green>{Prestige.rainbowPegTimer}</color>秒間持続させます。\nバフ1: 金色のペグからゴールド2倍。\nバフ2: バケツからゴールド2倍。\nバフ3: プレステージポイント2倍。\nバフ4: ボールがバケツに入ると{Prestige.rainbowPegPrestigePointChance}%の確率でプレステージポイント。";
            rainbowPegIncreaseBuffs = "<size=9>ゴールドとプレステージポイントが<color=green>3</color>倍になるバフが追加されました。";
            rainbowPegReceiveAllBuffs = "レインボーペグに当たると、<color=green>4</color>つのバフすべてを獲得します。";

            bombPeg1 = $"ボムペグが出現します！ボムペグの出現確率は<color=green>{Prestige.bombPegChance1}%</color>です。";
            bombPeg2 = "ボムペグに当たったボールは、さらに<color=green>2</color>つに爆発します。";
            bombPeg3Balls = "<size=9>ボムペグが<color=green>3</color>個のボールに爆発するようになりました！";
            bombPeg3to5Balls = "<size=9>ボムペグが<color=green>3-5</color>個のボールになって爆発するようになりました！";

            purplePeg1 = $"紫ペグが出現します！紫ペグの出現確率は<color=green>{Prestige.purplePegChance1}%</color>です。";
            purplePeg2 = $"紫ペグに当たったボールは強化されます。強化されたボールには<color=green>{Prestige.purplePegEnchanceIncrease1}</color>倍のゴールドとプレステージポイントが与えられます。";
            purplePegPrestigePoint = "強化されたボールがバケツに落ちると、プレステージポイントが<color=orange>1</color>ポイントが与えられます。";
            purplePegNextBall = "紫ペグに当たった場合、次にドロップまたはショットされるボールはすでに強化された状態です。";
            #endregion

            //Stats
            #region new stats
            rainbowPegSpawnChance = "レインボーペグの出現率：";
            rainbowPegsHit = "レインボーペグのヒット数：";
            bombPegsSpawnChance = "ボムペグの出現率：";
            bombPegsHit = "ボムペグのヒット数：";
            purplePegsSpawnChance = "紫ペグの出現率：";
            purplePegsHit = "紫ペグのヒット数：";

            totalGoldRush = "ゴールドラッシュ達成回数：";
            totalGoldFromClear = "クリアボーナスのゴールド合計：";
            totalGoldFromShooting = "射撃によるゴールド合計：";

            totalPRestigeRush = "プレステージラッシュの合計回数：";
            totalPrestigePointFromClear = "<size=20>クリアボーナスからのプレステージポイント合計：";
            totalPrestigePointFromBucket = "バケツからのプレステージポイント合計：";
            #endregion

            //Challenges
            #region Challenge strings
            bounceCHstring = $"{Challenges.bounceCH}個のペグでボールを弾ませる。";
            explodeTinyCHstring = $"<size=15>ボムボールを爆発させて{Challenges.explodeTinyCH}個の小さなボー\nルにする";
            basketballCHstring = $"<size=16>バスケットボールを{Challenges.basketballCH}個のペグに当てる";
            eggCHstring = $"<size=16>エッグボールからダブルゴールドを{Challenges.eggCH}回獲得";
            cookieCHstring = $"クッキーボールで{Challenges.cookieCH}ポイント獲得";
            goldenBallCHstring = $"ゴールデンボールから追加ゴールドを{Challenges.goldenBallCH}\n回受け取る";
            footballCHstring = $"フットボールを{Challenges.footballCH}個バケツに入れる";
            tinyRingCHstring = $"<size=19>小さなリングボールを{Challenges.tinyRingCH}個獲得";
            prestigeGemCHstring = $"<size=20>プレステージジェムに{Challenges.prestigeGemCH}個当てる";
            ghostballCHstring = $"<size=17>ゴーストボールを同時に{Challenges.ghostballCH}個画面に入れる";
            starBallCHstring = $"スターボールを{Challenges.starBallCH}個獲得";
            rainbowBallCHstring = $"<size=17>レインボーボールから合計+{Challenges.rainbowBallCH}%のゴール\nドを獲得する";
            glitchyBallCHstring = $"小さなグリッチボール{Challenges.glitchyBallCH}個を獲得";
            sharpnelBallCSstring = $"小さなシュラプネルボールを{Challenges.sharpnelBallCH}個獲得";

            //Rewards
            explodeTinyCHRewardstring = $"報酬：小さなボムボールは、ボムボールのゴールドの<color=yellow>{Challenges.explodeTinyCHReward * 100}%</color>を獲得できます。";
            basketballCHRewardstring = $"<size=10>報酬：バスケットボールのバウンドごとにゴールドが<color=yellow>+{Challenges.basketballCHReward * 100}%</color>加算されます。";
            eggCHRewardstring = $"<size=10>報酬：エッグボールのゴールドが2倍になる確率が<color=yellow>{Challenges.eggCHReward}%</color>になりました。";
            cookieCHRewardstring = $"<size=8.8>報酬：クッキーボールのプレステージポイントが<color=green>{Challenges.cookieCHReward}%</color>の確率で2倍になります。";
            goldenBallCHRewardstring = "<size=9.6>報酬：ゴールデンボールのゴールド獲得確率が<color=yellow>2倍、3倍、5</color>倍になります。";
            footballCHRewardstring = $"<size=8>報酬：フットボールがバケツに落ちると、<color=yellow>{Challenges.footballCHReward}</color>倍のゴールドがもらえるようになります。";
            tinyRingCHRewardstring = $"<size=9>報酬：小さなリングボールは、リングボールのゴールドの<color=yellow>{Challenges.tinyRingCHReward * 100}%</color>を獲得できます。";
            prestigeGemCHRewardstring = $"報酬：プレステージ・ジェムの出現率がアップ";
            ghostballCHRewardstring = $"<size=10.5>報酬：ゴーストボールのゴールドが<color=yellow>+{Challenges.ghostballCHReward * 100}%</color>されるようになりました。";
            starBallCHRewardstring = $"報酬：ペグを<color=green>{Challenges.starBallCHReward}</color>回打つとスターボールが1個出現します。";
            rainbowBallCHRewardstring = $"<size=10>報酬：レインボーボールがペグに当たると、ゴールドが<color=yellow>+{Challenges.rainbowBallCHReward * 100}%</color>されます。";
            glitchyBallCHRewardstring = $"報酬：すべてのボールのバフを改善します。";
            goldScaling = "報酬：ボールレベル30ごとのゴールド増加率を上げます。";
            prestigePegReward = $"報酬：プレステージペグのス出現率が<color=orange>+{Challenges.prestigePegReward}%</color>されます。";
            sharpnelBallCSRewardstring = $"<size=7.6>報酬：小さなシュラプネルボールは、シュラプネルボールのゴールドの<color=green>{Challenges.sharpnelBallCHReward * 100}%</color>が獲得できます。";
            #endregion

            //ACH
            #region ACH string
            clearBoardString = "ボードクリア";
            fullyChargeACHstring = "シューターをフルチャージする";
            chall1String = "チャレンジを完了する";
            purchase1Ballstring = "新しいボールを購入する";
            goldRushACH = "ゴールドラッシュを達成する";
            goldRushACH2 = $"ゴールドラッシュを{Achievements.goldRushNeeded2}回達成する";
            prestigeRushACH = "プレステージラッシュを達成する";
            prestigeRushACH2 = $"プレステージラッシュを{Achievements.prestigeRushNeeded2}回達成する";
            allBufsString = "すべてのバフを同時に獲得";
            #endregion

            #region Slider strings
            sliderAll = "<size=19>ゴールドテキストポップアップ = <color=green>すべてのボール";
            sliderHalf = "<size=19>ゴールドテキストポップアップ = <color=green>ボールの50%";
            slider4Latest = "<size=19>ゴールドテキストポップアップ = <color=green>最新の4つのボール";
            slider3Latest = "<size=19>ゴールドテキストポップアップ = <color=green>最新の3つのボール";
            slider2Latest = "<size=19>ゴールドテキストポップアップ = <color=green>最新の2つのボール";
            sliderLatest = "<size=19>ゴールドテキストポップアップ = <color=green>最新のボール";
            sliderNONE = "<size=19>ゴールドテキストポップアップ = <color=red>なし";
            #endregion

            prestigePointFromShooting = $"<size=11>シュートボールは<color=green>{Prestige.prestigePointFromShotChance}%</color>の確率で、プレステージポイントを1ポイントを獲得します。";
        }
        #endregion

        #region Tutorial Strings
        tutString1 = "ボードの好きなところを狙ってボールを発射しよう！";
        tutString2 = "初めてボードをクリアすると、新しいボードが現れます！ボードがクリアされるたびにボールシューターがチャージされます。ボールシューターにカーソルを合わせると、進行状況を確認できます。";
        tutString3 = "新しいボールを購入しました！ボールアップグレード枠の中にある各ボール、または1～9のキーを押すことで即時装備できます。";
        tutString4 = "ボールが落とし穴やバケツに落ちると、ボールは戻ってきます。";
        tutString5 = "<size=21>ペグを打ちます！緑色のペグはボールを跳ね返します。ゴールドペグはゴールドがもらえます。オレンジ\"プレステージペグ\"はプレステージポイント！";
        tutString6 = "<size=19.8>ゴールドが貯まると、ボールをアップグレードしたり、新しいボールを購入することができます！ ボールのレベルが30に達するごとに、ボールのゴールドの増加量が増加します。TABキーを押しながら最大アップグレードを購入";
        #endregion
    }
    #endregion // 3

    //4
    #region Korean
    public void KoreanChangeText()
    {
        language = 4;
        PlayerPrefs.SetInt("languageSelected", language);

        autoDropOff = "자동 투하 <color=red>(꺼짐)";
        autoDropOn = "자동 투하 <color=green>(켜짐)";

        regularBallUpgrades = "일반 공 업그레이드";
        bouncyBallUpgrades = "탄력 공 업그레이드";
        rockBallUgrades = "단단한 공 업그레이드";
        bombBallUpgrades = "폭탄 공 업그레이드 ";

        regularBallEquipped = "일반 공 장착";
        bouncyBallEquipped = "탄력 공 장착";
        rockBallEquipped = "단단한 공 장착";
        bombBallEquipped = "폭탄 공 장착";

        //New - Also add to demo
        lowBounce = "낮음";
        midBounce = "중간";
        highBounce = "높음 ";
        noBounce = "없음 ";
        totalPrestigePointsGained = "얻은 총 프레스티지 포인트:";
        totalRestigePointsSpent = "사용한 총 프레스티지 포인트: ";
        chancePrestigePointBucketBUFF = "공 하나가 통에 들어갈 때" + Prestige.rainbowPegPrestigePointChance + " 1 프레스티지 포인트에 대한 7% 확률";
        goldFromAllSourcesBUFF = "<size==19>모든 것에서의" + Prestige.goldRushIncrease + "배 황금 ";
        prestigePointAllSourcesBuff = "<size==17>모든 것에서의" + Prestige.prestigeRushIncrease + "배 프레스티지 포인트";

        levelString = "레벨: ";
        secondAbbreviation = "초";

        maxString = "최대";
        maxString2 = "(최대)";

        lockedString = "(잠금해제)";

        firstRedPegString = $"<size=11>빨간 구슬이 나타날 것입니다. 빨간 구슬이 나타날 가능성은 <color=green>{Prestige.redPegChance1}%</color>입니다. ";
        firstRedPegString2 = "<size=11>빨간 구슬은 황금 및 프레스티지 점수 모두를 줍니다. ";

        level1NameString = "레벨 1 - 숲";
        level2NameString = "레벨 2 - 도시";

        bucket1MidString = "통:<color=green> 1개의 중간 크기";
        bucketsLevel3 = "통:<color=green> 큰 크기 1개 ";
        bucketsLevel4 = "통:<color=green> 큰 크기 1개 & 작은 크기 1개";
        bucketsLevel5 = "통:<color=green> 큰 크기 1개 & 중간 크기 1개 ";
        bucketsLevel6 = "통:<color=green> 큰 크기 1개 & 중간 크기 1개 & 작은 크기 1개";
        bucketsLevel7 = "통:<color=green> 큰 크기 2개";
        bucketsLevel8 = "통:<color=green> 큰 크기 2개 & 중간 크기 1개 ";
        bucketsLevel9 = "통:<color=green> 큰 크기 2개 & 중간 크기 2개 ";
        bucketsLevel10 = "통:<color=green> 큰 크기 2개 & 중간 크기 2개 & 작은 크기 2개";

        redPegSpawnChanceString = "빨간 구슬 생성 확률:";
        redPegsHitString = "명중한 빨간 구슬:";

        #region Full game variables
        if (GameData.isDemo == false)
        {
            challenge = "도전 과제 #";

            //Upgrades string
            #region Ball Upgrades
            aquaBallUpgrades = "아쿠아 공 업그레이드 ";
            mudBallUpgrades = "진흙 공 업그레이드 ";
            basketBallUpgrades = "농구공 업그레이드 ";
            plumBallUpgrades = "자두 공 업그레이드 ";
            stickyBallUpgrades = "달걀 공 업그레이드";
            candyBallUpgrades = "사탕 공 업그레이드";
            cookieBallUpgrades = "쿠키 공 업그레이드 ";
            limeBallUpgrades = "라임 공 업그레이드 ";
            goldenBallUpgrades = "황금 공 업그레이드 ";
            footballBallUpgrades = "축구공 업그레이드";
            sharpnelBallUpgrades = "파편 공 업그레이드";
            zonicBallUpgrades = "반지 공 업그레이드";
            apricotBallUpgrades = "살구 공 업그레이드 ";
            peggoBallUpgrades = "페고 공 업그레이드 ";
            ghostBallUpgrades = "귀신 공 업그레이드 ";
            starBallUpgrades = "별 공 업그레이드";
            rainbowBallUpgrades = "무지개 공 업그레이드";
            glitchyBallUpgrades = "글리치 공 업그레이드";
            #endregion

            //Equipped strings
            #region Equipped
            aquaBallEquipped = "아쿠아 공 장착";
            mudBallEquipped = "진흙 공 장착";
            basketBallEquipped = "농구공 장착";
            plumBallEquipped = "자두 공 장착";
            stickyBallEquipped = "달걀 공 장착";
            candyBallEquipped = "사탕 공 장착";
            cookieBallEquipped = "쿠키 공 장착";
            limeBallEquipped = "라임 공 장착";
            goldenBallEquipped = "황금 공 장착";
            footballBallEquipped = "축구공 장착";
            sharpnelBallEquipped = "파편 공 장착";
            zonicBallEquipped = "반지 공 장착";
            apricotBallEquipped = "살구 공 장착 ";
            peggoBallEquipped = "페고 공 장착 ";
            ghostBallEquipped = "귀신 공 장착 ";
            starBallEquipped = "별 공 장착 ";
            rainbowBallEquipped = "무지개 공 장착 ";
            glitchyBallEquipped = "글리치 장착 ";
            #endregion

            //Level names
            #region Level names
            level3NameString = "레벨 3 - 어두운 숲 ";
            level4NameString = "레벨 4 - 꽁꽁 언 밤 ";
            level5NameString = "레벨 5 - 묘지 ";
            level6NameString = "레벨 6 - 보라 숲 ";
            level7NameString = "레벨 7 - 지하실 ";
            level8NameString = "레벨 8 - 파란 숲 ";
            level9NameString = "레벨 9 - 황금 동굴 ";
            level10NameString = "레벨 10 -우주 ";
            #endregion

            #region gold prestige upgrade text strings
            clearBonusString = "보드를 통과할 때마다 황금 보너스를 받게 될 것입니다. ";
            bucketGoldClear = "공이 통으로 들어갈 때 보드 통과 황금 보너스를 받게 될 것입니다. ";
            bucketGoldClear2 = $"공이 통으로 들어갈 때마다, 황금을 가장 많이 가진 잠금해제된 공에서의 <color=yellow>+{(Prestige.goldClearBonusFromBucket * 100).ToString("F0")}%</color> 황금이 보드 통과 보너스에 추가될 것입니다. ";
            goldRushString = $"황금 구슬을 명중하면 황금 러시를 향해 <color=yellow>{Prestige.goldRushChance}%</color> 다가가게 됩니다! ";
            goldRushString2 = $"황금 러시는 <color=green>{Prestige.goldRushTimer}</color>초 동안 얻는 모든 황금을 <color=yellow>{Prestige.goldRushIncrease}</color>배로 높여줄 것입니다. ";
            clearTimerString = "보드를 얼마나 빠르게 통과하는가에 따라 보드 통과 황금 보너스에 더 많은 황금을 받게 될 것입니다. ";
            #endregion

            #region prestige upgrades text strings
            prestigeClearBonus = "공이 통으로 들어갈 때마다, 프레스티지 포인트 보너스를 받게 될 것입니다. ";
            prestigeClearBonus2 = $"매 <color=orange>{Prestige.prestigeClearBonus1}</color>개의 프레스티지 구슬 명중마다, 추가 <color=orange>1</color> 프레스티지 포인트를 받게 될 것입니다. 프레스티지 구슬은 <color=orange>+1</color> 프레스티지 포인트를 줍니다. ";
            prestigePointBucket = "공이 통으로 들어갈 때, 프레스티지 포인트를 받을 작은 가능성을 갖게 됩니다. ";
            prestigeRush = $"프레스티지 구슬을 명중하면 프레스티지 러시를 향해 <color=orange>{Prestige.prestigeRushChance}%</color> 다가가게 됩니다. ";
            prestigeRush2 = $"프레스티지 러시는 <color=green>{Prestige.prestigeRushTimer}</color>초 동안 얻는 모든 프레스티지 포인트를 <color=orange>{Prestige.prestigeRushIncrease}</color>배로 높여줍니다. ";
            #endregion

            #region new pegs upgreades text string
            redPegGoldDouble = "빨간 구슬에서 받는 황금이 두 배가 됩니다. ";
            redPegPrestigeDouble = "빨간 구슬에서 받는 프레스티지 포인트가 두 배가 됩니다. ";

            rainbowPeg1 = $"<size=11>무지개 구슬 생성이 시작될 것입니다! 무지개 구슬이 나타날 확률은 <color=green>{Prestige.rainbowPegChance1}%</color> 입니다. ";
            rainbowPeg2 = $"<size=11>무지개 구슬은 <color=green>{Prestige.rainbowPegTimer}</color>초 동안 지속되는 버프를 4번 제공합니다. \n버프1: 황금 구슬에서의 황금 2배. \n버프2: 통에서의 황금 2배. \n버프3: 프레스티지 포인트 2배. \n버프 4: 공이 통으로 들어갈 때 프레스티지 포인트가 나올 확률 {Prestige.rainbowPegPrestigePointChance}%   ";
            rainbowPegIncreaseBuffs = "<size=10.5>이제 버프는 <color=green>3</color>배의 황금 및 프레스티지 포인트를 제공합니다. ";
            rainbowPegReceiveAllBuffs = "무지개 구슬을 명중하면 <color=green>4</color>개의 모든 버프를 받게 될 것입니다. ";

            bombPeg1 = $"폭탄 구슬 생성이 시작될 것입니다! 폭탄 구슬이 나타날 확률은 <color=green>{Prestige.bombPegChance1}%</color> 입니다. ";
            bombPeg2 = "폭탄 구슬을 명중하는 공이 <color=green>2</color>개로 나눠질 것입니다. ";
            bombPeg3Balls = "폭탄 구슬은 <color=green>3</color>개의 공으로 나눠질 것입니다. ";
            bombPeg3to5Balls = "이제 폭탄 구슬은 <color=green>3-5</color>개의 공으로 나눠질 것입니다. ";

            purplePeg1 = $"보라 구슬 생성이 시작될 것입니다! 보라 구슬이 나타날 확률은 <color=green>{Prestige.purplePegChance1}%</color>입니다. ";
            purplePeg2 = $"보라 구슬을 명중하는 공들이 강화될 것입니다. 강화된 공은 <color=green>{Prestige.purplePegEnchanceIncrease1}</color>배의 황금 및 프레스티지 포인트를 받게 될 것입니다. ";
            purplePegPrestigePoint = "통으로 들어가는 강화된 공은 항상 <color=orange>1</color> 프레스티지 포인트를 줄 것입니다. ";
            purplePegNextBall = "보라 구슬을 명중하면, 다음으로 투하 또는 발사되는 공이 강화됩니다. ";
            #endregion

            //Stats
            #region new stats
            rainbowPegSpawnChance = "무지개 구슬 생성 확률: ";
            rainbowPegsHit = "무지개 구슬 명중: ";
            bombPegsSpawnChance = "폭탄 구슬 생성 확률: ";
            bombPegsHit = "폭탄 구슬 명중:";
            purplePegsSpawnChance = "보라 구슬 생성 확률: ";
            purplePegsHit = "보라 구슬 명중: ";

            totalGoldRush = "황금 러시를 달성한 총 횟수: ";
            totalGoldFromClear = "통과 보너스에서의 총 황금:  ";
            totalGoldFromShooting = "쏜 공에서의 총 황금: ";

            totalPRestigeRush = "프레스티지 러시를 달성한 총 횟수:";
            totalPrestigePointFromClear = "통과 보너스에서의 총 프레스티지 포인트: ";
            totalPrestigePointFromBucket = "통에서의 총 프레스티지 포인트: ";
            #endregion

            //Challenges
            #region Challenge strings
            bounceCHstring = $"탄력 공을 {Challenges.bounceCH}개의 구슬에 튀기기 ";
            explodeTinyCHstring = $"폭탄 공을 {Challenges.explodeTinyCH}개의 작은 공들로 나누기 ";
            basketballCHstring = $"농구공으로 구슬 {Challenges.basketballCH}개 명중시키기 ";
            eggCHstring = $"달걀 공에서의 두 배 황금 {Challenges.eggCH}번 받기 ";
            cookieCHstring = $"<size=16>쿠키 공에서의 추가 {Challenges.cookieCH} 프레스티지 포인트 받기 ";
            goldenBallCHstring = $"황금 공에서의 추가 황금 {Challenges.goldenBallCH}번 받기 ";
            footballCHstring = $"통에 축구공 {Challenges.footballCH}개 넣기 ";
            tinyRingCHstring = $"{Challenges.tinyRingCH}개의 작은 반지 공 만들기 ";
            prestigeGemCHstring = $"프레스티지 보석 {Challenges.prestigeGemCH}개 명중하기 ";
            ghostballCHstring = $"화면 속 귀신 공 {Challenges.ghostballCH}개 한 번에 갖기 ";
            starBallCHstring = $"별 공 {Challenges.starBallCH}개 만들기 ";
            rainbowBallCHstring = $"무지개 공에서의 총 +{Challenges.rainbowBallCH}% 황금 받기 ";
            glitchyBallCHstring = $"작은 글리치 공 {Challenges.glitchyBallCH}개 만들기 ";
            sharpnelBallCSstring = $"작은 파편 공 {Challenges.sharpnelBallCH}개 만들기 ";

            //Rewards
            explodeTinyCHRewardstring = $"보상: 작은 폭탄 공들은 폭탄 공 황금의 <color=yellow>{Challenges.explodeTinyCHReward * 100}%</color>를 줍니다. ";
            basketballCHRewardstring = $"보상: 농구공들은 바운스 당 <color=yellow>+{Challenges.basketballCHReward * 100}%</color> 황금을 줍니다. ";
            eggCHRewardstring = $"보상: 달걀 공들은 두 배 황금을 받을 수 있는 <color=yellow>{Challenges.eggCHReward}%</color> 확률을 갖게 됩니다. ";
            cookieCHRewardstring = $"보상: 쿠키 공들은 두 배 프레스티지 포인트를 받을 수 있는 <color=green>{Challenges.cookieCHReward}%</color> 확률을 갖게 됩니다. ";
            goldenBallCHRewardstring = "보상: 황금 공들에 있어 2배, 3배, 5배로 황금 획득의 확률을 높여줍니다. ";
            footballCHRewardstring = $"보상: 축구공들이 통으로 들어갈 때마다 <color=yellow>{Challenges.footballCHReward}</color>배의 황금을 줍니다. ";
            tinyRingCHRewardstring = $"보상: 작은 반지 공들은 반지 공 황금의 <color=yellow>{Challenges.tinyRingCHReward * 100}%</color>를 줍니다.  ";
            prestigeGemCHRewardstring = $"보상: 더 많은 프레스티지 보석이 생성됩니다. ";
            ghostballCHRewardstring = $"보상: 귀신 공들은 <color=yellow>+{Challenges.ghostballCHReward * 100}%</color> 황금을 제공합니다. ";
            starBallCHRewardstring = $"보상: 보석 공을 생성하는데 <color=green>{Challenges.starBallCHReward}</color>개의 구슬만 필요합니다. ";
            rainbowBallCHRewardstring = $"보상: 무지개 공은 구슬 명중당 <color=yellow>+{Challenges.rainbowBallCHReward * 100}%</color> 황금을 제공합니다. ";
            glitchyBallCHRewardstring = $"보상: 모든 공들의 버프가 향상됩니다. ";
            goldScaling = "보상: 공 레벨 30당 황금 스케일링이 높아집니다.";
            prestigePegReward = $"보상: <color=orange>+{Challenges.prestigePegReward}%</color> 프레스티지 구슬 생성 확률 ";
            sharpnelBallCSRewardstring = $"보상: 작은 파편 공들이 파편 공 황금의 <color=green>{Challenges.sharpnelBallCHReward * 100}%</color>를 줍니다. ";
            #endregion

            //ACH
            #region ACH string
            clearBoardString = "보드 통과하기 ";
            fullyChargeACHstring = "공 쏘는 기계 완전 충전하기 ";
            chall1String = "도전 과제 완료하기 ";
            purchase1Ballstring = "새로운 공 구매하기 ";
            goldRushACH = "황금 러시 달성하기 ";
            goldRushACH2 = $"황금 러시 {Achievements.goldRushNeeded2}번 달성하기 ";
            prestigeRushACH = "프레스티지 러시 달성하기 ";
            prestigeRushACH2 = $"프레스티지 러시 {Achievements.prestigeRushNeeded2}번 달성하기 ";
            allBufsString = "모든 버프 동시에 얻기 ";
            #endregion

            #region Slider strings
            sliderAll = "골드 텍스트 팝업 = <color=green>모든 공";
            sliderHalf = "골드 텍스트 팝업 = <color=green> 공의 50%";
            slider4Latest = "골드 텍스트 팝업 = <color=green>최신 4개의 공";
            slider3Latest = "골드 텍스트 팝업 = <color=green>최신 3개의 공";
            slider2Latest = "골드 텍스트 팝업 = <color=green>최신 2개의 공";
            sliderLatest = "골드 텍스트 팝업 = <color=green>최신 공";
            sliderNONE = "골드 텍스트 팝업 = <color=red>없음";
            #endregion

            prestigePointFromShooting = $"공 발사는 1 프레스티지 포인트를 받을 수 있는 <color=green>{Prestige.prestigePointFromShotChance}%</color> 확률을 가지고 있습니다. ";
        }
        #endregion

        #region Tutorial Strings
        tutString1 = "구슬을 맞추기 위해 보드에 공을 쏠 곳을 조준해 보세요.  ";
        tutString2 = "처음으로 구슬을 다 없애며 보드를 깨끗하게 만들었고 새로운 보드가 생성되었습니다! 보드가 깨끗해질 때마다 공을 쏘는 기계가 충전될 것입니다. 현 진행 상황을 확인해보기 위해 해당 기계 위에 마우스를 움직여 보세요. ";
        tutString3 = "새로운 공을 구매하였습니다! 공 업그레이드 틀 속에 각 공들을 갖추거나, 1-9 숫자 버튼을 눌러 장비를 바로 장착할 수 있습니다. ";
        tutString4 = "구덩이 또는 통에 공이 떨어지는 경우, 공을 다시 돌려받게됩니다. ";
        tutString5 = "구슬을 명중하세요! 녹색 구슬은 공을 튀게합니다. 황금 구슬은 황금을 줍니다. 주황색 \"프레스티지 구슬\"은 프레스티지 점수를 줍니다.  ";
        tutString6 = "<size=23>충분한 황금을 가진 경우, 공을 업그레이드하거나 새로운 공을 구매할 수 있습니다! 매 30번째 레벨에서, 공 황금 증가는 높아집니다. 최대 업그레이드 구매를 위해 탭 버튼을 꾹 눌러 주십시오. ";
        #endregion
    }
    #endregion 

    //5
    #region Russian
    public void RussianChangeText()
    {
        language = 5;
        PlayerPrefs.SetInt("languageSelected", language);

        autoDropOff = "<size=8.1>АВТОМАТИЧЕСКОЕ ВЫПАДЕНИЕ \n<color=red>(ВЫКЛ)";
        autoDropOn = "<size=8.1>АВТОМАТИЧЕСКОЕ ВЫПАДЕНИЕ \n<color=green>(ВКЛ)";

        regularBallUpgrades = "<size=12>Улучшения обычного шара";
        bouncyBallUpgrades = "<size=12>Улучшения надувного шара";
        rockBallUgrades = "<size=12>Улучшения каменного шара";
        bombBallUpgrades = "<size=12>Улучшения шара-бомбы";

        regularBallEquipped = "Выбран обычный шар";
        bouncyBallEquipped = "Выбран надувной шар";
        rockBallEquipped = "Выбран каменный шар";
        bombBallEquipped = "Выбран шар-бомба";

        //New - Also add to demo
        lowBounce = "НИЗК.";
        midBounce = "СРЕДН.";
        highBounce = "ВЫСОК.";
        noBounce = "НЕТ";
        totalPrestigePointsGained = "Всего получено очков престижа:";
        totalRestigePointsSpent = "Всего потрачено очков престижа:";
        chancePrestigePointBucketBUFF = "" + Prestige.rainbowPegPrestigePointChance + "% шанс на 1 очко престижа, если шар попал в корзину";
        goldFromAllSourcesBUFF = "<size==19>" + Prestige.goldRushIncrease + "X золота из всех источников";
        prestigePointAllSourcesBuff = "<size==17>" + Prestige.prestigeRushIncrease + "X очков престижа из всех источников";

        levelString = "УРОВЕНЬ ";
        secondAbbreviation = "с";

        maxString = "МАКС";
        maxString2 = "(МАКС)";

        lockedString = "<size=10>(ЗАБЛОКИРОВАНО)";

        firstRedPegString = $"<size=11>Начнут появляться красные колышки. Шанс появления красных колышков составляет <color=green>{Prestige.redPegChance1}%</color>";
        firstRedPegString2 = "<size=11>Красные колышки дают как золото, так и очки престижа.";

        level1NameString = "Уровень 1 — Лес";
        level2NameString = "Уровень 2 — Город";

        bucket1MidString = "Корзины:<color=green> 1 среднего";
        bucketsLevel3 = "Корзины:<color=green> 1 больших";
        bucketsLevel4 = "Корзины:<color=green> 1 больших и 1 малые";
        bucketsLevel5 = "Корзины:<color=green> 1 больших и 1 средние";
        bucketsLevel6 = "Корзины:<color=green> 1 больших, 1 средние и 1 малые";
        bucketsLevel7 = "Корзины:<color=green> 2 больших";
        bucketsLevel8 = "Корзины:<color=green> 2 больших и 1 средние";
        bucketsLevel9 = "Корзины:<color=green> 2 больших и 2 средние";
        bucketsLevel10 = "Корзины:<color=green> 2 больших, 2 средних и 2 малые";

        redPegSpawnChanceString = "Шанс появления красных колышков:";
        redPegsHitString = "Выбитых красных колышков:";

        #region Full game variables
        if (GameData.isDemo == false)
        {
            challenge = "ЗАДАНИЕ #";

            //Upgrades string
            #region Ball Upgrades
            aquaBallUpgrades = "<size=12>Улучшения водяного шара";
            mudBallUpgrades = "<size=12>Улучшения грязевого шара";
            basketBallUpgrades = "<size=10.5>Улучшения баскетбольного мяча";
            plumBallUpgrades = "<size=12>Улучшения шара-сливы";
            stickyBallUpgrades = "<size=12>Улучшения шара-яйца";
            candyBallUpgrades = "<size=12>Улучшения шара-конфеты";
            cookieBallUpgrades = "<size=12>Улучшения шара-печенья";
            limeBallUpgrades = "<size=12>Улучшения шара-лайма";
            goldenBallUpgrades = "<size=12>Улучшения золотого шара";
            footballBallUpgrades = "<size=12>Улучшения футбольного мяча";
            sharpnelBallUpgrades = "<size=12>Улучшения осколочного шара";
            zonicBallUpgrades = "<size=12>Улучшения шара-кольца";
            apricotBallUpgrades = "<size=12>Улучшения шара-абрикоса";
            peggoBallUpgrades = "<size=12>Улучшения шара-колышка";
            ghostBallUpgrades = "<size=12>Улучшения шара-призрака";
            starBallUpgrades = "<size=12>Улучшения звездного шара";
            rainbowBallUpgrades = "<size=12>Улучшения радужного шара";
            glitchyBallUpgrades = "<size=12>Улучшения глючного шара";
            #endregion

            //Equipped strings
            #region Equipped
            aquaBallEquipped = "Выбран водяной шар";
            mudBallEquipped = "Выбран грязевой шар";
            basketBallEquipped = "<size=27>Выбран баскетбольный мяч";
            plumBallEquipped = "Выбран шар-слива";
            stickyBallEquipped = "Выбран шар-яйцо";
            candyBallEquipped = "Выбран шар-конфета";
            cookieBallEquipped = "Выбран шар-печенье";
            limeBallEquipped = "Выбран шар-лайм";
            goldenBallEquipped = "Выбран золотой шар";
            footballBallEquipped = "Выбран футбольный мяч";
            sharpnelBallEquipped = "Выбран осколочный шар";
            zonicBallEquipped = "Выбран шар-кольцо";
            apricotBallEquipped = "Выбран шар-абрикос";
            peggoBallEquipped = "Выбран шар-колышек";
            ghostBallEquipped = "Выбран шар-призрак";
            starBallEquipped = "Выбран звездный шар";
            rainbowBallEquipped = "Выбран радужный шар";
            glitchyBallEquipped = "Выбран глючный шар";
            #endregion

            //Level names
            #region Level names
            level3NameString = "<size=28>Уровень 3 — Темный лес";
            level4NameString = "<size=26>Уровень 4 — Морозная ночь";
            level5NameString = "<size=28>Уровень 5 — Кладбище";
            level6NameString = "<size=26>Уровень 6 — Фиолетовый лес";
            level7NameString = "<size=28>Уровень 7 — Склеп";
            level8NameString = "<size=28>Уровень 8 — Синий лес";
            level9NameString = "<size=26>Уровень 9 — Золотая пещера";
            level10NameString = "<size=28>Уровень 10 — Космос";
            #endregion

            #region gold prestige upgrade text strings
            clearBonusString = "Теперь за очистку доски вы получите золотой бонус.";
            bucketGoldClear = "Теперь, если шар попадет в корзину, вы также получите золотой бонус за очистку доски.";
            bucketGoldClear2 = $"При попадании шара в корзину к бонусу за очистку доски добавится <color=yellow>+{(Prestige.goldClearBonusFromBucket * 100).ToString("F0")}%</color> золота от освобожденного шара с макс. количеством золота.";
            goldRushString = $"Удар о золотой колышек имеет <color=yellow>{Prestige.goldRushChance}%</color> шанс на ЗОЛОТУЮ ЛИХОРАДКУ!";
            goldRushString2 = $"Золотая лихорадка дает <color=green>{Prestige.goldRushTimer}</color> секунд на <color=yellow>{Prestige.goldRushIncrease}X</color> золота";
            clearTimerString = "Золотой бонус за очистку доски также получит больше золота, с учетом скорости очистки.";
            #endregion

            #region prestige upgrades text strings
            prestigeClearBonus = "Теперь за очистку доски вы получите бонус в виде очков престижа!";
            prestigeClearBonus2 = $"Вы получите <color=orange>+1</color> очко престижа за каждый <color=orange>{Prestige.prestigeClearBonus1}</color>-й удар о колышки престижа. Колышки престижа также дают <color=orange>+1</color> очко престижа.";
            prestigePointBucket = "Теперь у вас есть малый шанс получить очки престижа, если шар попал в корзину.";
            prestigeRush = $"Удар о колышек престижа имеет <color=orange>{Prestige.prestigeRushChance}%</color> шанс на ЛИХОРАДКУ ПРЕСТИЖА!";
            prestigeRush2 = $"Лихорадка престижа дает <color=green>{Prestige.prestigeRushTimer}</color> секунд на <color=orange>{Prestige.prestigeRushIncrease}X</color> очков престижа";
            #endregion

            #region new pegs upgreades text string
            redPegGoldDouble = "Золото от красных колышков удваивается";
            redPegPrestigeDouble = "Очки престижа от красных колышков удваиваются";

            rainbowPeg1 = $"Появятся радужные колышки! Шанс на появление — <color=green>{Prestige.rainbowPegChance1}%</color>.";
            rainbowPeg2 = $"Радужные колышки дают 1 из 4 бонусов на <color=green>{Prestige.rainbowPegTimer}</color> с. \nБонус 1: 2X золота с золотых колышков. \nБонус 2: 2X золота с корзин. \nБонус 3: 2X очков престижа. \nБонус 4: {Prestige.rainbowPegPrestigePointChance}% шанс на очки престижа, если шар попал в корзину.";
            rainbowPegIncreaseBuffs = "Бонусы теперь дают <color=green>3X</color> золота и очков престижа.";
            rainbowPegReceiveAllBuffs = "Удар о радужный колышек теперь дает все <color=green>4</color> бонуса.";

            bombPeg1 = $"Появятся бомбовые колышки! Шанс на появление — <color=green>{Prestige.bombPegChance1}%</color>.";
            bombPeg2 = "Удар шара о бомбовый колышек добавит к взрыву <color=green>2</color> шара.";
            bombPeg3Balls = "Теперь бомбовые колышки разрываются на <color=green>3</color> шара!";
            bombPeg3to5Balls = "Теперь бомбовые колышки разрываются на<color=green>3-5</color> шаров!";

            purplePeg1 = $"Появятся фиолетовые колышки! Шанс на появление — <color=green>{Prestige.purplePegChance1}%</color>.";
            purplePeg2 = $"Удар о фиолетовый колышек усиливает шары. Усиленные шары получат <color=green>{Prestige.purplePegEnchanceIncrease1}X</color> золота и очков престижа.";
            purplePegPrestigePoint = "Усиленные шары, попавшие в корзину, всегда дают <color=orange>1</color> очко престижа.";
            purplePegNextBall = "При ударе о фиолетовый колышек следующий брошенный или пущенный шар будет усиленным.";
            #endregion

            //Stats
            #region new stats
            rainbowPegSpawnChance = "Шанс на появление радужных колышков:";
            rainbowPegsHit = "Ударов о радужные колышки:";
            bombPegsSpawnChance = "Шанс на появление бомбовых колышков:";
            bombPegsHit = "Ударов о бомбовые колышки:";
            purplePegsSpawnChance = "Шанс на появление фиолетовых колышков:";
            purplePegsHit = "Ударов о фиолетовые колышки:";

            totalGoldRush = "Всего золотых лихорадок:";
            totalGoldFromClear = "Всего золота за очистку:";
            totalGoldFromShooting = "Всего золота за запуски:";

            totalPRestigeRush = "Всего лихорадок престижа:";
            totalPrestigePointFromClear = "Всего очков престижа за очистку:";
            totalPrestigePointFromBucket = "Всего очков престижа за корзину:";
            #endregion

            //Challenges
            #region Challenge strings
            bounceCHstring = $"<size=18>Ударьте прыгучий шар о {Challenges.bounceCH} колышков";
            explodeTinyCHstring = $"Взорвите бомбовые шары на {Challenges.explodeTinyCH} \nмини-шаров";
            basketballCHstring = $"<size=17>Ударьте {Challenges.basketballCH} колышков баскетбольным \nмячом";
            eggCHstring = $"Получите двойное золото от шаров-яиц \n({Challenges.eggCH} раз)";
            cookieCHstring = $"Получите +{Challenges.cookieCH} очков престижа от \nшаров-печений";
            goldenBallCHstring = $"Получите доп. золото от золотого шара \n({Challenges.goldenBallCH} раз)";
            footballCHstring = $"Забейте {Challenges.footballCH} футбольных мячей в \nкорзину";
            tinyRingCHstring = $"<size=19>Получите {Challenges.tinyRingCH} мини шаров-колец";
            prestigeGemCHstring = $"Выбейте {Challenges.prestigeGemCH} камней престижа";
            ghostballCHstring = $"Выстройте {Challenges.ghostballCH} шаров-призраков на \nэкране";
            starBallCHstring = $"Получите {Challenges.starBallCH} звездных шаров";
            rainbowBallCHstring = $"Получите +{Challenges.rainbowBallCH}% золота от радужных \nшаров";
            glitchyBallCHstring = $"Получите {Challenges.glitchyBallCH} мини глючных шаров";
            sharpnelBallCSstring = $"Получите {Challenges.sharpnelBallCH} мини осколочных шаров";

            //Rewards
            explodeTinyCHRewardstring = $"<size=8.8>Награда: мини бомбовые шары теперь дают <color=yellow>{Challenges.explodeTinyCHReward * 100}%</color> золота от бомбовых шаров";
            basketballCHRewardstring = $"<size=10.5>Награда: баскетбольные мячи теперь дают <color=yellow>+{Challenges.basketballCHReward * 100}%</color> золота за отскок";
            eggCHRewardstring = $"Награда: <color=yellow>{Challenges.eggCHReward}%</color> шанс на двойное золото за шары-яйца";
            cookieCHRewardstring = $"Награда: у шаров-печенья теперь <color=green>{Challenges.cookieCHReward}%</color> шанс на 2X очки престижа";
            goldenBallCHRewardstring = "<size=10.5>Награда: <color=yellow>2X, 3X, 5X</color> повышение шанса золотых шаров на золото";
            footballCHRewardstring = $"<size=8.6>Награда: футбольные мячи теперь дают <color=yellow>{Challenges.footballCHReward}X</color> золота при попадании в корзину";
            tinyRingCHRewardstring = $"<size=9.6>Награда: мини шары-кольца теперь дают <color=yellow>{Challenges.tinyRingCHReward * 100}%</color> золота за шары-кольца";
            prestigeGemCHRewardstring = $"Награда: появится больше камней престижа";
            ghostballCHRewardstring = $"Награда: шары-призраки теперь дают <color=yellow>+{Challenges.ghostballCHReward * 100}%</color> к золоту";
            starBallCHRewardstring = $"<size=9>Награда: теперь для появления звездного шара нужно <color=green>{Challenges.starBallCHReward}</color> ударов о колышек";
            rainbowBallCHRewardstring = $"<size=9.5>Награда: радужные шары теперь дают <color=yellow>+{Challenges.rainbowBallCHReward * 100}%</color> к золоту за удар о колышек";
            glitchyBallCHRewardstring = $"Награда: улучшение бонусов всех шаров";
            goldScaling = "Награда: +30 золота за уровень шара";
            prestigePegReward = $"Награда: <color=orange>+{Challenges.prestigePegReward}%</color> к появлению колышка престижа";
            sharpnelBallCSRewardstring = $"<size=8.5>Награда: мини осколочные шары теперь дают <color=green>{Challenges.sharpnelBallCHReward * 100}%</color> золота от осколочного шара";
            #endregion

            //ACH
            #region ACH string
            clearBoardString = "Очистите доску";
            fullyChargeACHstring = "Полностью зарядите пушку";
            chall1String = "Выполните задание";
            purchase1Ballstring = "Купите новый шар";
            goldRushACH = "Получите золотую лихорадку";
            goldRushACH2 = $"Получите золотую лихорадку {Achievements.goldRushNeeded2} раз";
            prestigeRushACH = "Получите лихорадку престижа";
            prestigeRushACH2 = $"Получите лихорадку престижа {Achievements.prestigeRushNeeded2} раз";
            allBufsString = "Получите все бонусы одновременно";
            #endregion

            #region Slider strings
            sliderAll = "<size=15.6>Золотые текстовые всплывающие окна = <color=green>ВСЕ ШАРЫ";
            sliderHalf = "<size=15.6>Золотые текстовые всплывающие окна = <color=green>50% ШАРОВ";
            slider4Latest = "<size=15.6>Золотые текстовые всплывающие окна = <color=green>ПОСЛЕДНИЕ 4 ШАРА";
            slider3Latest = "<size=15.6>Золотые текстовые всплывающие окна = <color=green>ПОСЛЕДНИЕ 3 ШАРА";
            slider2Latest = "<size=15.6>Золотые текстовые всплывающие окна = <color=green>ПОСЛЕДНИЕ 2 ШАРА";
            sliderLatest = "<size=15.6>Золотые текстовые всплывающие окна = <color=green>ПОСЛЕДНИЙ ШАР";
            sliderNONE = "<size=15.6>Золотые текстовые всплывающие окна = <color=red>НЕТ";
            #endregion

            prestigePointFromShooting = $"<color=green>{Prestige.prestigePointFromShotChance}%</color> шанс на 1 очко престижа при запуске шара.";
        }
        #endregion

        #region Tutorial Strings
        tutString1 = "<size=21>Цельтесь в любое место на доске, чтобы стрелять шарами в колышки!";
        tutString2 = "Вы только что очистили доску в первый раз, и теперь появится новая доска! Стрелок шаров будет перезаряжаться каждый раз, когда доска будет очищена. Наведите курсор на стрелок шаров, чтобы увидеть прогресс.";
        tutString3 = "Вы только что купили новый шар! Вы можете выбрать каждый шар в рамку для улучшения шаров, или ВЫБРАТЬ МГНОВЕННО, нажимая на клавиши 1-9.";
        tutString4 = "Как только шар упадет в яму или корзину, он будет возвращен обратно.";
        tutString5 = "<size=23>Сбивайте колышки! Зеленые колышки отскакивают от шара. Золотые колышки дают золото. Оранжевые \"Колышки престижа\" дают очки престижа!";
        tutString6 = "<size=21>Когда у вас будет достаточно золота, вы сможете улучшать свои шары и покупать новые! С каждым 30-м уровнем шара растет процент золота за шар. Для покупки максимальных улучшений удерживайте клавишу TAB.";
        #endregion
    }
    #endregion

    //6
    #region German
    public void GermanChangeText()
    {
        language = 6;
        PlayerPrefs.SetInt("languageSelected", language);

        autoDropOff = "<size=9.8>Automatischer Drop <color=red>(AUS)";
        autoDropOn = "<size=9.8>Automatischer Drop <color=green>(EIN)";

        regularBallUpgrades = "<size=12>Upgrades für normale Bälle";
        bouncyBallUpgrades = "<size=12>Upgrades für Flummibälle ";
        rockBallUgrades = "<size=12>Upgrades für Murmeln";
        bombBallUpgrades = "<size=12>Upgrades für Schrapnell";

        regularBallEquipped = "<size=27>Normaler Ball ausgerüstet";
        bouncyBallEquipped = "<size=27>Flummiball ausgerüstet";
        rockBallEquipped = "<size=27>Murmel ausgerüstet";
        bombBallEquipped = "<size=27>Schrapnell ausgerüstet";

        //New - Also add to demo
        lowBounce = "GERING";
        midBounce = "MITTEL";
        highBounce = "STARK";
        noBounce = "NICHT";
        totalPrestigePointsGained = "Insgesamt gewonnene Prestigepunkte: ";
        totalRestigePointsSpent = "Insgesamte ausgegebene Prestigepunkte:";
        chancePrestigePointBucketBUFF = "" + Prestige.rainbowPegPrestigePointChance + "% Chance auf 1 Prestigepunkt, wenn ein Ball in einen Korb trifft";
        goldFromAllSourcesBUFF = "<size==19>" + Prestige.goldRushIncrease + "x Gold aus allen Quellen";
        prestigePointAllSourcesBuff = "<size==17>" + Prestige.prestigeRushIncrease + "x Prestigepunkte aus allen Quellen";

        levelString = "Level ";
        secondAbbreviation = "Sek";

        maxString = "MAX";
        maxString2 = "(MAX)";

        lockedString = "<size=15>(GESPERRT)";

        firstRedPegString = $"<size=11>Rote Pegs beginnen zu spawnen. Die Chance, dass rote Pegs spawnen, liegt bei <color=green>{Prestige.redPegChance1}%</color>";
        firstRedPegString2 = "<size=11>Rote Pegs geben sowohl Gold- als auch Prestigepunkte.";

        level1NameString = "Level 1 - Wald";
        level2NameString = "Level 2 - Stadt";

        bucket1MidString = "Eimer:<color=green> 1 (mittelgroß)";
        bucketsLevel3 = "Eimer:<color=green> 1 (groß)";
        bucketsLevel4 = "Eimer:<color=green> 1 (groß) & 1 (klein)";
        bucketsLevel5 = "Eimer:<color=green> 1 (groß) & 1 (mittel)";
        bucketsLevel6 = "Eimer:<color=green> 1 (groß), 1 (mittel) & 1 (klein)";
        bucketsLevel7 = "Eimer:<color=green> 2 (groß)";
        bucketsLevel8 = "Eimer:<color=green> 2 (groß) & 1 (mittel)";
        bucketsLevel9 = "Eimer:<color=green> 2 (groß) & 2 (mittel)";
        bucketsLevel10 = "Eimer:<color=green> 2 (groß), 2 (mittel) & 2 (klein)";

        redPegSpawnChanceString = "Chance, dass rote Pegs gespawnt werden:";
        redPegsHitString = "Rote Pegs getroffen:";

        #region Full game variables
        if (GameData.isDemo == false)
        {
            challenge = "<size=5.7>HERAUSFORDERUNG #";

            //Upgrades string
            #region Ball Upgrades
            aquaBallUpgrades = "<size=12>Wasserball-Upgrades";
            mudBallUpgrades = "<size=12>Schlammball-Upgrades";
            basketBallUpgrades = "<size=12>Basketball-Upgrades";
            plumBallUpgrades = "<size=12>Pflaumenball-Upgrades";
            stickyBallUpgrades = "<size=12>Eierball-Upgrades";
            candyBallUpgrades = "<size=12>Candy-Ball-Upgrades";
            cookieBallUpgrades = "<size=12>Keksball-Upgrades";
            limeBallUpgrades = "<size=12>Limettenball-Upgrades";
            goldenBallUpgrades = "<size=12>Goldball-Upgrades";
            footballBallUpgrades = "<size=12>Fußball-Upgrades";
            sharpnelBallUpgrades = "<size=11>Schrapnellball-Upgrades";
            zonicBallUpgrades = "<size=12>Ringball-Upgrades";
            apricotBallUpgrades = "<size=11>Aprikosenball-Upgrades";
            peggoBallUpgrades = "<size=12>Peggo-Ball-Upgrades";
            ghostBallUpgrades = "<size=12>Geisterball-Upgrades";
            starBallUpgrades = "<size=12>Sternball-Upgrades";
            rainbowBallUpgrades = "<size=11>Regenbogenball-Upgrades";
            glitchyBallUpgrades = "<size=12>Glitch-Ball-Upgrades";
            #endregion

            //Equipped strings
            #region Equipped
            aquaBallEquipped = "Wasserball ausgerüstet";
            mudBallEquipped = "<size=27>Schlammball ausgerüstet";
            basketBallEquipped = "Basketball ausgerüstet";
            plumBallEquipped = "<size=27>Pflaumenball ausgerüstet";
            stickyBallEquipped = "Eierball ausgerüstet";
            candyBallEquipped = "Candy-Ball ausgerüstet";
            cookieBallEquipped = "Keksball ausgerüstet";
            limeBallEquipped = "<size=27>Limettenball ausgerüstet";
            goldenBallEquipped = "Goldball ausgerüstet";
            footballBallEquipped = "Fußball ausgerüstet";
            sharpnelBallEquipped = "<size=26>Schrapnellball ausgerüstet";
            zonicBallEquipped = "Ringball ausgerüstet";
            apricotBallEquipped = "<size=27>Aprikosenball ausgerüstet";
            peggoBallEquipped = "Peggo-Ball ausgerüstet";
            ghostBallEquipped = "Geisterball ausgerüstet";
            starBallEquipped = "Sternball ausgerüstet";
            rainbowBallEquipped = "<size=25>Regenbogenball ausgerüstet";
            glitchyBallEquipped = "Glitch-Ball ausgerüstet";
            #endregion

            //Level names
            #region Level names
            level3NameString = "Level 3 - Dunkelwald";
            level4NameString = "Level 4 - Eisnacht";
            level5NameString = "Level 5 - Friedhof";
            level6NameString = "<size=29>Level 6 - Violetter Wald";
            level7NameString = "Level 7 - Krypta";
            level8NameString = "<size=31>Level 8 - Blauer Wald";
            level9NameString = "Level 9 - Goldhöhle";
            level10NameString = "Level 10 - Weltraum";
            #endregion

            #region gold prestige upgrade text strings
            clearBonusString = "<size=11>Du erhältst jetzt einen Goldbonus, wenn du das Spielfeld abräumst.";
            bucketGoldClear = "<size=11>Du erhältst jetzt auch einen Goldbonus, wenn ein Ball in einen Korb trifft.";
            bucketGoldClear2 = $"<size=11>Jedes Mal, wenn ein Ball in einen Korb trifft, werden <color=yellow>+{(Prestige.goldClearBonusFromBucket * 100).ToString("F0")}%</color> Gold vom freigeschalteten Ball mit dem meisten Gold zum Bonus für das Abräumen des Spielfelds hinzugefügt.";
            goldRushString = $"<size=11>Wenn du einen Gold-Peg triffst, besteht eine Chance von <color=yellow>{Prestige.goldRushChance}%</color>, einen GOLDRAUSCH auszulösen!";
            goldRushString2 = $"<size=11>Der Goldrausch erhöht <color=green>{Prestige.goldRushTimer}</color> Sekunden lang alles erhaltene Gold <color=yellow>{Prestige.goldRushIncrease}X</color>.";
            clearTimerString = "<size=11>Der Goldbonus für das Abräumen des Spielfelds wird nun auch mehr Gold erhalten, je nachdem, wie schnell ein Spielfeld abgeräumt wird.";
            #endregion

            #region prestige upgrades text strings
            prestigeClearBonus = "Du erhältst jetzt einen Prestigepunktebonus, wenn du das Spielfeld abräumst!";
            prestigeClearBonus2 = $"Du erhältst <color=orange>1</color> zusätzlichen Prestigepunkt für jeweils <color=orange>{Prestige.prestigeClearBonus1}</color> getroffene Prestige-Pegs. Prestige-Pegs geben außerdem <color=orange>+1</color> Prestigepunkt.";
            prestigePointBucket = "<size=10.5>Du hast jetzt eine kleine Chance, Prestigepunkte zu erhalten, wenn ein Ball in einen Korb trifft.";
            prestigeRush = $"<size=11>Wenn du einen Prestige-Peg triffst, hast du eine <color=orange>{Prestige.prestigeRushChance}%</color>-Chance einen PRESTIGERAUSCH auszulösen!";
            prestigeRush2 = $"<size=11>Der Prestigerausch erhöht <color=green>{Prestige.prestigeRushTimer}</color> Sekunden lang alle erhaltenen Prestigepunkte <color=orange>{Prestige.prestigeRushIncrease}X</color>.";
            #endregion

            #region new pegs upgreades text string
            redPegGoldDouble = "Gold durch rote Pegs verdoppelt sich";
            redPegPrestigeDouble = "Prestigepunkte durch rote Pegs verdoppeln sich";

            rainbowPeg1 = $"<size=10>Regenbogen-Pegs beginnen zu spawnen! Die Chance, dass Regenbogen-Pegs spawnen, liegt bei <color=green>{Prestige.rainbowPegChance1}%</color>.";
            rainbowPeg2 = $"<size=10>Regenbogen-Pegs geben 1 von 4 Buffs, die <color=green>{Prestige.rainbowPegTimer}</color> Sekunden lang anhalten. \nBuff 1: 2x Gold von Gold-Pegs. \nBuff 2: 2x Gold von Körben. \nBuff 3: 2x Prestigepunkte. \nBuff 4: {Prestige.rainbowPegPrestigePointChance}% Chance auf Prestigepunkte, wenn ein Ball im Korb landet.";
            rainbowPegIncreaseBuffs = "<size=10>Buffs geben jetzt <color=green>3X</color> Gold und Prestigepunkte.";
            rainbowPegReceiveAllBuffs = "Wenn du einen Regenbogen-Peg triffst, erhältst du jetzt alle <color=green>4</color> Buffs.";

            bombPeg1 = $"<size=10>Schrapnell-Pegs werden jetzt spawnen! Schrapnell-Pegs haben eine Chance von <color=green>{Prestige.bombPegChance1}%</color> zu spawnen.";
            bombPeg2 = "<size=10>Bälle, die den Schrapnell-Peg treffen, explodieren in <color=green>2</color> weitere Bälle.";
            bombPeg3Balls = "Schrapnell-Pegs explodieren jetzt in <color=green>3</color> Bälle!";
            bombPeg3to5Balls = "<size=10>Schrapnell-Pegs explodieren jetzt in <color=green>3-5</color> Bälle!";

            purplePeg1 = $"<size=11>Violette Pegs beginnen zu spawnen! Violette Pegs haben eine Chance von <color=green>{Prestige.purplePegChance1}%</color> zu spawnen.";
            purplePeg2 = $"<size=11>Bälle, die einen violetten Peg treffen, werden aufgewertet. Aufgewertete Bälle erzeugen <color=green>{Prestige.purplePegEnchanceIncrease1}X</color> Gold und Prestigepunkte.";
            purplePegPrestigePoint = "Aufgewertete Bälle, die im Korb landen, geben immer <color=orange>1</color> Prestigepunkt.";
            purplePegNextBall = "Wenn du einen violetten Peg triffst, ist der nächste Ball, der in den Abgrund fällt oder geschossen wird, bereits aufgewertet.";
            #endregion

            //Stats
            #region new stats
            rainbowPegSpawnChance = "Chance auf das Spawnen von Regenbogen-Pegs:";
            rainbowPegsHit = "Getroffene Regenbogen-Pegs:";
            bombPegsSpawnChance = "Chance auf das Spawnen von Schrapnell-Pegs:";
            bombPegsHit = "Getroffene Schrapnell-Pegs:";
            purplePegsSpawnChance = "Chance auf das Spawnen von violetten Pegs:";
            purplePegsHit = "Getroffene violette Pegs:";

            totalGoldRush = "Erreichte Goldrausche insgesamt:";
            totalGoldFromClear = "Gesamtgold durch Abräumboni:";
            totalGoldFromShooting = "Gesamtgold aus Schüssen:";

            totalPRestigeRush = "Gesamtzahl der erreichten Prestigerausche:";
            totalPrestigePointFromClear = "Gesamte Prestigepunkte durch Abräumboni:";
            totalPrestigePointFromBucket = "Gesamte Prestigepunkte durch Korbtreffer:";
            #endregion

            //Challenges
            #region Challenge strings
            bounceCHstring = $"<size=16>Lass einen Flummiball auf {Challenges.bounceCH} Pegs springen";
            explodeTinyCHstring = $"<size=16>Explodiere Schrapnellbälle in {Challenges.explodeTinyCH} kleine \nBälle";
            basketballCHstring = $"Triff {Challenges.basketballCH} Pegs mit dem Basketball";
            eggCHstring = $"Erhalte {Challenges.eggCH}-mal doppeltes Gold von \nEierbällen";
            cookieCHstring = $"Erhalte {Challenges.cookieCH} zusätzliche Prestigepunkte von \nKeksbällen";
            goldenBallCHstring = $"Erhalte {Challenges.goldenBallCH} Mal zusätzliches Gold durch \nden Goldball";
            footballCHstring = $"Triff {Challenges.footballCH} Fußbälle in den Korb";
            tinyRingCHstring = $"Erzeuge {Challenges.tinyRingCH} kleine Ringbälle";
            prestigeGemCHstring = $"Triff {Challenges.prestigeGemCH} Prestige-Edelsteine";
            ghostballCHstring = $"Habe {Challenges.ghostballCH} Geisterbälle gleichzeitig auf \ndem Bildschirm";
            starBallCHstring = $"Erzeuge {Challenges.starBallCH} Sternbälle";
            rainbowBallCHstring = $"Erhalte insgesamt +{Challenges.rainbowBallCH}% Gold aus \nRegenbogenbällen";
            glitchyBallCHstring = $"Erzeuge {Challenges.glitchyBallCH} winzige Glitch-Bälle";
            sharpnelBallCSstring = $"Erzeuge {Challenges.sharpnelBallCH} winzige Schrapnellbälle";

            //Rewards
            explodeTinyCHRewardstring = $"<size=8.6>Belohnung: Winzige Schrapnellbälle geben jetzt <color=yellow>{Challenges.explodeTinyCHReward * 100}%</color> des Schrapnellbälle-Goldes";
            basketballCHRewardstring = $"<size=10.7>Belohnung: Basketbälle geben jetzt <color=yellow>+{Challenges.basketballCHReward * 100}%</color> mehr Gold pro Aufprall";
            eggCHRewardstring = $"<size=11>Belohnung: Eierbälle geben jetzt <color=yellow>{Challenges.eggCHReward}%</color> des doppelten Goldes";
            cookieCHRewardstring = $"<size=8.2>Belohnung: Keksbälle haben jetzt eine Chance von <color=green>{Challenges.cookieCHReward}%</color>, 2x Prestigepunkte zu erhalten";
            goldenBallCHRewardstring = "Belohnung: Erhöhte <color=yellow>2x, 3x und 5x</color> Goldchancen für Goldbälle";
            footballCHRewardstring = $"<size=9.2>Belohnung: Fußbälle geben jetzt <color=yellow>{Challenges.footballCHReward}X</color> Gold, wenn sie in einem Eimer landen";
            tinyRingCHRewardstring = $"<size=10>Belohnung: Winzige Ringbälle geben jetzt <color=yellow>{Challenges.tinyRingCHReward * 100}%</color> des Ringball-Goldes";
            prestigeGemCHRewardstring = $"Belohnung: Mehr Prestige-Edelsteine spawnen";
            ghostballCHRewardstring = $"Belohnung: Geisterbälle geben jetzt <color=yellow>+{Challenges.ghostballCHReward * 100}%</color> mehr Gold";
            starBallCHRewardstring = $"<size=9.6>Belohnung: Es braucht jetzt <color=green>{Challenges.starBallCHReward}</color> Peg-Treffer, um einen Sternball zu spawnen";
            rainbowBallCHRewardstring = $"<size=9.4>Belohnung: Regenbogenbälle geben jetzt <color=yellow>+{Challenges.rainbowBallCHReward * 100}%</color> mehr Gold pro Peg-Treffer";
            glitchyBallCHRewardstring = $"Belohnung: Verbessert die Buffs aller Bälle";
            goldScaling = "Belohnung: Erhöht die Goldskalierung pro Ball auf Stufe 30";
            prestigePegReward = $"Belohnung: <color=orange>+{Challenges.prestigePegReward}%</color> Spawnchance für Prestige-Pegs";
            sharpnelBallCSRewardstring = $"<size=8.7>Belohnung: Winzige Schrapnellbälle geben jetzt <color=green>{Challenges.sharpnelBallCHReward * 100}%</color> des Schrapnellball-Goldes";
            #endregion

            //ACH
            #region ACH string
            clearBoardString = "Räume das Spielfeld ab";
            fullyChargeACHstring = "Lade den Shooter vollständig auf";
            chall1String = "Schließe eine Herausforderung ab";
            purchase1Ballstring = "Kaufe einen neuen Ball";
            goldRushACH = "Erreiche einen Goldrausch";
            goldRushACH2 = $"Erziele {Achievements.goldRushNeeded2} Mal einen Goldrausch";
            prestigeRushACH = "Erreiche einen Prestigerausch";
            prestigeRushACH2 = $"Erziele {Achievements.prestigeRushNeeded2} Mal einen Prestigerausch";
            allBufsString = "Erhalte alle Buffs zur gleichen Zeit";
            #endregion

            #region Slider strings
            sliderAll = "<size=23>Goldene Text-Popups = <color=green>ALLE BÄLLE";
            sliderHalf = "<size=23>Goldene Text-Popups = <color=green>50% DER BÄLLE";
            slider4Latest = "<size=23>Goldene Text-Popups = <color=green>4 NEUSTEN BÄLLE";
            slider3Latest = "<size=23>Goldene Text-Popups = <color=green>3 NEUSTEN BÄLLE";
            slider2Latest = "<size=23>Goldene Text-Popups = <color=green>2 NEUSTEN BÄLLE";
            sliderLatest = "<size=23>Goldene Text-Popups = <color=green>NEUSTER BALL";
            sliderNONE = "<size=23>Goldene Text-Popups = <color=red>KEINE";
            #endregion

            prestigePointFromShooting = $"Das Schießen von Bällen bringt mit einer Wahrscheinlichkeit von <color=green>{Prestige.prestigePointFromShotChance}%</color> 1 Prestigepunkt.";
        }
        #endregion

        #region Tutorial Strings
        tutString1 = "<size=17>Ziele irgendwo auf das Spielfeld, um Bälle auf die Pegs zu schießen!";
        tutString2 = "<size=18>Du hast gerade deine erste Runde abgeschlossen und eine neue Runde beginnt gleich! Dein Ballgeschoss lädt sich jedes Mal auf, wenn das Spielfeld abgeräumt wird. Bewege den Mauszeiger über das Ballgeschoss, um den Fortschritt zu sehen.";
        tutString3 = "<size=18.7>Du hast gerade einen neuen Ball gekauft! Du kannst jeden Ball im Ball-Upgrade-Bereich oder SOFORT AUSRÜSTEN, indem du die Tasten 1-9 drückst.";
        tutString4 = "<size=20>Wenn der Ball in den Abgrund oder den Eimer fällt, wird er zurückteleportiert.";
        tutString5 = "<size=22>Triff die Pegs! Grüne Pegs lassen den Ball abprallen. Goldene Pegs bringen dir Gold ein. Orange \"Prestige-Pegs\" geben Prestigepunkte!";
        tutString6 = "<size=21>Sobald du genug Gold hast, kannst du deine Bälle aufwerten und neue Bälle kaufen! Alle 30 Stufen, die der Ball erreicht, erhöht sich der Goldertrag. Halte TAB gedrückt, um max. Upgrades zu kaufen.";
        #endregion
    }
    #endregion

    //7
    #region French
    public void FrenchChangeText()
    {
        language = 7;
        PlayerPrefs.SetInt("languageSelected", language);

        autoDropOff = "<size=9>DROP AUTOMATIQUE <color=red>(APAGADO)";
        autoDropOn = "<size=9>DROP AUTOMATIQUE <color=green>(ENCENDIDO)";

        regularBallUpgrades = "<size=9>Améliorations des Balles Normales";
        bouncyBallUpgrades = "<size=9>Améliorations des Balles Rebondissantes";
        rockBallUgrades = "<size=9>Améliorations des Balles en Pierre";
        bombBallUpgrades = "<size=9>Améliorations des Balles-Bombe";

        regularBallEquipped = "<size=29>Balle Normale Équipée";
        bouncyBallEquipped = "<size=24>Balle Rebondissante Équipée";
        rockBallEquipped = "<size=29>Balle en Pierre Équipée";
        bombBallEquipped = "<size=29>Balle Bombe Équipée";

        //New - Also add to demo
        lowBounce = "BAS";
        midBounce = "MOYEN";
        highBounce = "HAUT";
        noBounce = "AUCUN";
        totalPrestigePointsGained = "Total des points prestige gagnés : ";
        totalRestigePointsSpent = "Total des points prestige dépensés : ";
        chancePrestigePointBucketBUFF = "" + Prestige.rainbowPegPrestigePointChance + "% de chance d'obtenir 1 point de prestige lorsqu'une balle entre dans un panier";
        goldFromAllSourcesBUFF = "<size==19>" + Prestige.goldRushIncrease + "X plus d'or de toutes sources";
        prestigePointAllSourcesBuff = "<size==17>" + Prestige.prestigeRushIncrease + "X plus de points de prestige de toutes sources";

        levelString = "Niveau ";
        secondAbbreviation = "s";

        maxString = "MAX";
        maxString2 = "(MAX)";

        lockedString = "<size=16>(BLOQUÉ)";

        firstRedPegString = $"<size=10>Les pions rouges commenceront à apparaître. Les pions rouges ont <color=green>{Prestige.redPegChance1}%</color> de chance d'apparaître";
        firstRedPegString2 = "<size=10>Les pions rouges donnent à la fois de l'or et des points de prestige.";

        level1NameString = "Niveau 1 - Forêt";
        level2NameString = "Niveau 2 - Ville";

        bucket1MidString = "Paniers:<color=green> 1 moyens";
        bucketsLevel3 = "Buckets:<color=green> 1 grands";
        bucketsLevel4 = "Buckets:<color=green> 1 grands & 1 petite";
        bucketsLevel5 = "Buckets:<color=green> 1 grands & 1 moyens";
        bucketsLevel6 = "Buckets:<color=green> 1 grands, 1 moyens & 1 petite";
        bucketsLevel7 = "Buckets:<color=green> 2 grands";
        bucketsLevel8 = "Buckets:<color=green> 2 grands & 1 moyens";
        bucketsLevel9 = "Buckets:<color=green> 2 grands & 2 moyens";
        bucketsLevel10 = "Buckets:<color=green> 2 grands, 2 moyens & 2 petite";

        redPegSpawnChanceString = "Chance d'apparition des pions rouges :";
        redPegsHitString = "Pions rouges touchés : ";

        #region Full game variables
        if (GameData.isDemo == false)
        {
            challenge = "DÉFI #";

            //Upgrades string
            #region Ball Upgrades
            aquaBallUpgrades = "<size=9>Améliorations de la Balle Aqua";
            mudBallUpgrades = "<size=9>Améliorations de la Balle Boue";
            basketBallUpgrades = "<size=9>Améliorations de le Ballon de Basket";
            plumBallUpgrades = "<size=9>Améliorations de la Balle Prune";
            stickyBallUpgrades = "<size=9>Améliorations de la Balle Œuf";
            candyBallUpgrades = "<size=9>Améliorations de la Balle Bonbon";
            cookieBallUpgrades = "<size=9>Améliorations de la Balle Cookie";
            limeBallUpgrades = "<size=9>Améliorations de la Balle Citron Vert";
            goldenBallUpgrades = "<size=9>Améliorations de la Balle Or";
            footballBallUpgrades = "<size=9>Améliorations de le Ballon de Football";
            sharpnelBallUpgrades = "<size=9>Améliorations de la Balle Shrapnel";
            zonicBallUpgrades = "<size=9>Améliorations de la Balle Anneau";
            apricotBallUpgrades = "<size=9>Améliorations de la Balle Abricot";
            peggoBallUpgrades = "<size=9>Améliorations de la Balle Peggo";
            ghostBallUpgrades = "<size=9>Améliorations de la Balle Fantôme";
            starBallUpgrades = "<size=9>Améliorations de la Balle Étoile";
            rainbowBallUpgrades = "<size=9>Améliorations de la Balle Arc-en-Ciel";
            glitchyBallUpgrades = "<size=9>Améliorations de la Balle Glitchée";
            #endregion

            //Equipped strings
            #region Equipped
            aquaBallEquipped = "Balle Aqua Équipée";
            mudBallEquipped = "Balle Boue Équipée";
            basketBallEquipped = "<size=23>Ballon de Basketball Équipée";
            plumBallEquipped = "Balle Prune Équipée";
            stickyBallEquipped = "Balle Œuf Équipée";
            candyBallEquipped = "Balle Bonbon Équipée";
            cookieBallEquipped = "Balle Cookie Équipée";
            limeBallEquipped = "<size=29>Balle Citron Vert Équipée";
            goldenBallEquipped = "Balle Or Équipée";
            footballBallEquipped = "<size=24>Ballon de Football Équipée";
            sharpnelBallEquipped = "Balle Shrapnel Équipée";
            zonicBallEquipped = "Balle Anneau Équipée";
            apricotBallEquipped = "Balle Abricot Équipée";
            peggoBallEquipped = "Balle Peggo Équipée";
            ghostBallEquipped = "Balle Fantôme Équipée";
            starBallEquipped = "Balle Étoile Équipée";
            rainbowBallEquipped = "<size=28>Balle arc-en-Ciel Équipée";
            glitchyBallEquipped = "Balle Glitchy Équipée";
            #endregion

            //Level names
            #region Level names
            level3NameString = "<size=29>Niveau 3 - Forêt Obscure";
            level4NameString = "<size=29>Niveau 4 - Nuit glaciale";
            level5NameString = "Niveau 5 - cimetière";
            level6NameString = "<size=29>Niveau 6 - Forêt Violette";
            level7NameString = "Niveau 7 - Crypte";
            level8NameString = "<size=29>Niveau 8 - Forêt Bleue ";
            level9NameString = "<size=29>Niveau 9 - Caverne Dorée ";
            level10NameString = "Niveau 10 - Espace";
            #endregion

            #region gold prestige upgrade text strings
            clearBonusString = "À présent, vous obtenez un bonus en or après avoir vidé le plateau.";
            bucketGoldClear = "<size=10>De plus, un bonus en or vous est accordé lorsqu'une balle entre dans un panier lorsque le plateau est vidé. ";
            bucketGoldClear2 = $"<size=10.5>Chaque fois qu'une balle entre dans un panier, <color=yellow>{(Prestige.goldClearBonusFromBucket * 100).ToString("F0")}%</color> de l'or provenant de la balle déverrouillée possédant le plus d'or seront ajoutés au bonus de vidage du plateau.";
            goldRushString = $"Il y a une probabilité de <color=yellow>{Prestige.goldRushChance}%</color> que toucher un pion doré déclenche une RUÉE VERS L'OR !";
            goldRushString2 = $"Pendant <color=green>{Prestige.goldRushTimer}</color> secondes, la ruée vers l'or multipliera par <color=yellow>{Prestige.goldRushIncrease}X</color> toute quantité d'or reçue.";
            clearTimerString = "<size=11>Désormais, le bonus or pour le vidage du plateau bénéficiera également d'une augmentation proportionnelle à la rapidité avec laquelle le plateau est vidé. ";
            #endregion

            #region prestige upgrades text strings
            prestigeClearBonus = "<size=11>Vous recevez désormais un bonus prestige lors du vidage de plateau !";
            prestigeClearBonus2 = $"<size=11>Pour chaque <color=orange>{Prestige.prestigeClearBonus1}</color> pions prestige touchés, vous obtiendrez un point de prestige supplémentaire. De plus, chaque pion prestige vous octroie également un point bonus prestige supplémentaire. ";
            prestigePointBucket = "<size=9.5>Désormais, vous avez une petite probabilité de gagner des points de prestige lorsqu'une balle tombe dans un panier.";
            prestigeRush = $"<size=11>Si vous touchez un pion prestige, vous avez <color=orange>{Prestige.prestigeRushChance}%</color> de chances de déclencher une RUÉE DE PRESTIGE ! ";
            prestigeRush2 = $"<size=11>La ruée de prestige <color=orange>{Prestige.prestigeRushIncrease}X</color> tous les points de prestige reçus pendant <color=green>{Prestige.prestigeRushTimer}</color> secondes.";
            #endregion

            #region new pegs upgreades text string
            redPegGoldDouble = "L'or reçu des pions rouges est doublé.";
            redPegPrestigeDouble = "Les points de prestige obtenus des pions rouges sont doublés.";

            rainbowPeg1 = $"<size=11>Les pions arc-en-ciel feront leur apparition ! Ils ont une probabilité de <color=green>{Prestige.rainbowPegChance1}%</color> d'apparaître.";
            rainbowPeg2 = $"<size=11>Les pions arc-en-ciel proposent un choix parmi 4 améliorations qui durent <color=green>{Prestige.rainbowPegTimer}</color> secondes chacune. \nAmélioration 1 : 2X or provenant des pions dorés. \nAmélioration 2 : 2X or provenant des paniers. \nAmélioration 3 : 2X points de prestige. \nAmélioration 4 : 7% de chance d'obtenir des points de prestige lorsqu'une balle entre dans un panier.";
            rainbowPegIncreaseBuffs = "<size=10>Les améliorations donnent désormais <color=green>3</color> fois plus d'or et de points de prestige. ";
            rainbowPegReceiveAllBuffs = "Désormais, toucher un pion arc-en-ciel octroiera les <color=green>4</color> améliorations. ";

            bombPeg1 = $"<size=11.5>Des pions bombes vont commencer à apparaître ! Leur chance d'apparaître est de <color=green>{Prestige.bombPegChance1}%</color>. ";
            bombPeg2 = "<size=11.5>Les balles frappant le pion bombe se diviseront en deux nouvelles balles. ";
            bombPeg3Balls = "<size=10>Désormais, les bombes se divisent en <color=green>3</color> balles lorsqu'elles explosent ! ";
            bombPeg3to5Balls = "<size=10>Désormais, les pions bombes explosent en <color=green>3 à 5</color> balles ! ";
            
            purplePeg1 = $"<size=11.5>Des pions violets vont maintenant à faire leur apparition ! Ils ont une probabilité de <color=green>{Prestige.purplePegChance1}%</color> d'apparaître.";
            purplePeg2 = $"<size=11.5>Les balles frappant le pion violet seront boostées, leur attribuant <color=green>{Prestige.purplePegEnchanceIncrease1}X</color> fois plus d'or et de points de prestige. ";
            purplePegPrestigePoint = "Les balles améliorées, lorsqu'elles atterrissent dans le panier, octroient systématiquement <color=orange>1</color> point de prestige. ";
            purplePegNextBall = "Après avoir touché un pion violet, la balle suivante, qu'elle soit lâchée ou tirée, est déjà améliorée. ";
            #endregion

            //Stats
            #region new stats
            rainbowPegSpawnChance = "<size=20>Probabilité de voir apparaître des pions arc-en-ciel : ";
            rainbowPegsHit = "Touches sur les pions arc-en-ciel : ";
            bombPegsSpawnChance = "<size=21>Probabilité de voir apparaître des pions bombe :";
            bombPegsHit = "Touches sur les pions bombe : ";
            purplePegsSpawnChance = "Probabilité de voir apparaître des pions violets :";
            purplePegsHit = "Touches sur les pions violets : ";

            totalGoldRush = "<size=20>Nombre de fois où une ruée vers l'or a été déclenchée : ";
            totalGoldFromClear = "<size=16>Quantité totale d'or obtenue grâce au bonus de niveau terminé : ";
            totalGoldFromShooting = "Quantité totale d'or obtenue par les tirs :";

            totalPRestigeRush = "<size=17.3>Nombre de fois où une ruée vers le prestige a été déclenchée : ";
            totalPrestigePointFromClear = "<size=15>Total des points de prestige obtenus grâce au bonus de niveau terminé :";
            totalPrestigePointFromBucket = "<size=18>Total des points de prestige obtenus à partir du panier : ";
            #endregion

            //Challenges
            #region Challenge strings
            bounceCHstring = $"<size=17.5>Faites rebondir une balle qui rebondit sur \n{Challenges.bounceCH} pions";
            explodeTinyCHstring = $"<size=16>Faites exploser les balles bombes en {Challenges.explodeTinyCH} \npetites balles";
            basketballCHstring = $"<size=18>Frappez {Challenges.basketballCH} pions avec le ballon de \nbasketball";
            eggCHstring = $"Obtenez un double d'or des balles æuf \n{Challenges.eggCH} fois";
            cookieCHstring = $"<size=15>Recevez {Challenges.cookieCH} points de prestige supplémentaires \ndes balles cookie";
            goldenBallCHstring = $"Obtenez un bonus d'or de la balle dorée \n{Challenges.goldenBallCH} fois";
            footballCHstring = $"Placez {Challenges.footballCH} ballons de football ";
            tinyRingCHstring = $"<size=17>Faites apparaître {Challenges.tinyRingCH} petites balles en \nforme d'anneau";
            prestigeGemCHstring = $"<size=21>Touchez {Challenges.prestigeGemCH} gemmes de prestige";
            ghostballCHstring = $"Maintenez simultanément {Challenges.ghostballCH} balles \nfantômes à l'écran";
            starBallCHstring = $"<size=20>Faites apparaître {Challenges.starBallCH} balles étoiles";
            rainbowBallCHstring = $"Recevez un total +{Challenges.rainbowBallCH}% d'or des balles \narc-en-ciel";
            glitchyBallCHstring = $"Faites apparaître {Challenges.glitchyBallCH} petites balles \nglitchées";
            sharpnelBallCSstring = $"<size=15>Faites apparaître {Challenges.sharpnelBallCH} petites balles shrapnel ";

            //Rewards
            explodeTinyCHRewardstring = $"<size=7.9>Récompense : les petites balles bombes offrent désormais <color=yellow>{Challenges.explodeTinyCHReward * 100}%</color> de l'or des balles bombe";
            basketballCHRewardstring = $"<size=7.4>Récompense : les ballons de basketball donnent maintenant un bonus d'or de <color=yellow>+{Challenges.basketballCHReward * 100}%</color> par rebond";
            eggCHRewardstring = $"<size=8>Récompense : les balles æuf ont désormais <color=yellow>{Challenges.eggCHReward}%</color> de chances de recevoir un double d'or";
            cookieCHRewardstring = $"<size=6.8>Récompense : les balles cookie ont désormais <color=green>{Challenges.cookieCHReward}%</color> de chances de recevoir 2X plus de points de prestige";
            goldenBallCHRewardstring = "<size=8.2>Récompense : Accroît les chances d'obtenir de l'or <color=yellow>2X, 3X et 5X</color> pour les balles dorées";
            footballCHRewardstring = $"<size=6.2>Récompense : Lorsqu'ils atterrissent dans un panier, les ballons de football rapportent maintenant <color=yellow>{Challenges.footballCHReward}X</color> plus d'or";
            tinyRingCHRewardstring = $"<size=6.1>Récompense : les petites balles en forme d'anneau rapportent désormais <color=yellow>{Challenges.tinyRingCHReward * 100}%</color> de l'or des balles en forme d'anneau";
            prestigeGemCHRewardstring = $"Récompense : Plus de gemmes de prestige apparaissent";
            ghostballCHRewardstring = $"<size=8>Récompense : Les balles fantômes accordent désormais une augmentation de <color=yellow>{Challenges.ghostballCHReward * 100}%</color> d'or";
            starBallCHRewardstring = $"<size=7.8>Récompense : Pour générer une balle étoile, il faut désormais réussir <color=green>{Challenges.starBallCHReward}</color> coups sur des pions";
            rainbowBallCHRewardstring = $"<size=6>Récompense : Désormais, à chaque fois qu'une balle arc-en-ciel touche un pion, cela accorde un bonus de <color=yellow>+{Challenges.rainbowBallCHReward * 100}%</color> d'or";
            glitchyBallCHRewardstring = $"Récompense : Améliore les avantages de toutes les balles";
            goldScaling = "<size=11>Récompense : Augmente le niveau d'or par niveau de 30 balles";
            prestigePegReward = $"<size=10>Récompense : <color=orange>+{Challenges.prestigePegReward}%</color> de probabilité d'apparition du pion de prestige";
            sharpnelBallCSRewardstring = $"<size=7.3>Récompense : Désormais, les petites balles shrapnel fournissent <color=green>{Challenges.sharpnelBallCHReward * 100}%</color> de l'or des balles shrapnel";
            #endregion

            //ACH
            #region ACH string
            clearBoardString = "Vider le plateau";
            fullyChargeACHstring = "Charger complètement le lanceur";
            chall1String = "Terminer un défi";
            purchase1Ballstring = "Acheter une nouvelle balle";
            goldRushACH = "Terminer une ruée vers l'or";
            goldRushACH2 = $"Terminer une ruée vers l'or {Achievements.goldRushNeeded2} fois";
            prestigeRushACH = "Terminer une ruée de prestige";
            prestigeRushACH2 = $"Terminer une ruée de prestige {Achievements.prestigeRushNeeded2} fois";
            allBufsString = "Acquérir tous les bonus en même temps";
            #endregion

            #region Slider strings
            sliderAll = "<size=22>Pop-ups de texte doré = <color=green>TOUTES LES BALLES";
            sliderHalf = "<size=22>Pop-ups de texte doré = <color=green>50% DES BALLES";
            slider4Latest = "<size=22>Pop-ups de texte doré = <color=green>4 DERNIÈRES BOULES";
            slider3Latest = "<size=22>Pop-ups de texte doré = <color=green>3 DERNIÈRES BOULES";
            slider2Latest = "<size=22>Pop-ups de texte doré = <color=green>2 DERNIÈRES BOULES";
            sliderLatest = "<size=22>Pop-ups de texte doré = <color=green>DERNIÈRE BOULE";
            sliderNONE = "<size=22>Pop-ups de texte doré = <color=red>AUCUNE";
            #endregion

            prestigePointFromShooting = $"Il y a une probabilité de <color=green>{Prestige.prestigePointFromShotChance}%</color> que chaque tir accorde 1 point de prestige.";
        }
        #endregion

        #region Tutorial Strings
        tutString1 = "<size=18>Visez n'importe où sur le plateau pour tirer des balles sur les pions !";
        tutString2 = "<size=18.7>Vous venez de vider le plateau pour la première fois ! Un nouveau plateau va apparaître. Votre lance-balle se rechargera à chaque fois que le plateau sera vidé. Passez votre souris sur le lance-balle pour voir la progression.";
        tutString3 = "<size=16.3>Vous venez d'acheter une nouvelle balle ! Vous avez la possibilité de placer chaque balle dans le cadre de mise à niveau des balles ou de les équiper instantanément en appuyant sur les touches numérotées de 1 à 9.";
        tutString4 = "<size=23>Lorsque la balle atterrie dans le trou ou le panier, elle sera renvoyée.";
        tutString5 = "<size=21>Frappez les pions ! Les pions verts font rebondir la balle. Les pions dorés donnent de l'or. Les pions orange Pions Prestige offrent des points de prestige !";
        tutString6 = "<size=16.5>Lorsque vous avez suffisamment d'or, vous pouvez améliorer vos balles et acheter de nouvelles balles ! En augmentant le niveau de la balle, chaque palier de 30 niveaux accroît le montant de l'augmentation de l'or de la balle. Maintenez TAB enfoncé pour acheter des améliorations maximales.";
        #endregion
    }
    #endregion

    //8
    #region Spanish
    public void SpanishChangeText()
    {
        language = 8;
        PlayerPrefs.SetInt("languageSelected", language);

        autoDropOff = "<size=9.3>Caída Automática <color=red>(DÉSACTIVÉ)";
        autoDropOn = "<size=9.9>Caída Automática <color=green>(ACTIVÉ)";

        regularBallUpgrades = "<size=13>Mejora de bola regular";
        bouncyBallUpgrades = "<size=13>Mejora de bola saltarina";
        rockBallUgrades = "<size=13>Mejora de bola de piedra";
        bombBallUpgrades = "<size=13>Mejora de bola bomba";

        regularBallEquipped = "Bola normal equipada";
        bouncyBallEquipped = "Bola saltarina equipada";
        rockBallEquipped = "Bola de piedra equipada";
        bombBallEquipped = "Bola bomba Equipada";

        //New - Also add to demo
        lowBounce = "BAJO";
        midBounce = "MEDIO";
        highBounce = "ALTO";
        noBounce = "NADA";
        totalPrestigePointsGained = "Total de puntos de prestigio obtenidos:";
        totalRestigePointsSpent = "Total de puntos de prestigio gastados:";
        chancePrestigePointBucketBUFF = "" + Prestige.rainbowPegPrestigePointChance + "% de probabilidad de 1 punto de prestigio cuando una bola entra en un cubo";
        goldFromAllSourcesBUFF = "<size==19>" + Prestige.goldRushIncrease + "X oro de todas las fuentes";
        prestigePointAllSourcesBuff = "<size==17>" + Prestige.prestigeRushIncrease + "X puntos de prestigio de todas las fuentes";

        levelString = "NIVEL ";
        secondAbbreviation = "s";

        maxString = "MAX";
        maxString2 = "(MAX)";

        lockedString = "<size=15.5>(BLOQUEADO)";

        firstRedPegString = $"<size=11>Los pegs rojos empezarán a aparecer. Los pegs rojos tienen un <color=green>{Prestige.redPegChance1}%</color> de posibilidades de aparecer.";
        firstRedPegString2 = "<size=11>Los pegs rojos dan puntos de oro y de prestigio.";

        level1NameString = "Nivel 1 - Bosque";
        level2NameString = "Nivel 2 - Ciudad";

        bucket1MidString = "Cubos:<color=green> 1 medio";
        bucketsLevel3 = "Cubos:<color=green> 1 grande";
        bucketsLevel4 = "Cubos:<color=green> 1 grande & 1 pequeño";
        bucketsLevel5 = "Cubos:<color=green> 1 grande & 1 mediano";
        bucketsLevel6 = "Cubos:<color=green> 1 grande, 1 mediano & 1 pequeño";
        bucketsLevel7 = "Cubos:<color=green> 2 grande";
        bucketsLevel8 = "Cubos:<color=green> 2 grande & 1 mediano";
        bucketsLevel9 = "Cubos:<color=green> 2 grande & 2 mediano";
        bucketsLevel10 = "Cubos:<color=green> 2 grande, 2 mediano & 2 pequeño";

        redPegSpawnChanceString = "Probabilidad de aparición de pegs rojos:";
        redPegsHitString = "Pegs rojos golpeadas:";

        #region Full game variables
        if (GameData.isDemo == false)
        {
            challenge = "DESAFÍO #";

            //Upgrades string
            #region Ball Upgrades
            aquaBallUpgrades = "<size=13>Mejoras de Bola de Agua";
            mudBallUpgrades = "<size=13>Mejoras de Bola de Lodo";
            basketBallUpgrades = "<size=13>Mejoras de Baloncesto";
            plumBallUpgrades = "<size=13>Mejoras de Bola de Ciruela";
            stickyBallUpgrades = "<size=13>Mejoras de Bola de Huevo";
            candyBallUpgrades = "<size=12>Mejoras de Bola de Caramelo";
            cookieBallUpgrades = "<size=13>Mejoras de Bola de Galleta";
            limeBallUpgrades = "<size=13>Mejoras de Bola de Lima";
            goldenBallUpgrades = "<size=13>Mejoras de Bola Dorada";
            footballBallUpgrades = "<size=13>Mejoras de Fútbol";
            sharpnelBallUpgrades = "<size=12>Mejoras de Bola de Esquirlas";
            zonicBallUpgrades = "<size=12>Mejoras de Bola de Aro";
            apricotBallUpgrades = "<size=11>Mejoras de Bola de Albaricoque";
            peggoBallUpgrades = "<size=13>Mejoras de Bola Peggo";
            ghostBallUpgrades = "<size=13>Mejoras de Bola Fantasma";
            starBallUpgrades = "<size=13>Mejoras de Bola Estrella";
            rainbowBallUpgrades = "<size=13>Mejoras de Bola Arcoíris";
            glitchyBallUpgrades = "<size=13>Mejoras de Bola Glitchy";
            #endregion

            //Equipped strings
            #region Equipped
            aquaBallEquipped = "Bola de Agua Equipada";
            mudBallEquipped = "Bola de Lodo Equipada";
            basketBallEquipped = "Baloncesto Equipado";
            plumBallEquipped = "<size=29>Bola de Ciruela Equipada";
            stickyBallEquipped = "Bola de Huevo Equipada";
            candyBallEquipped = "<size=27>Bola de Caramelo Equipada";
            cookieBallEquipped = "<size=29>Bola de Galleta Equipada";
            limeBallEquipped = "Bola de Lima Equipada";
            goldenBallEquipped = "Bola Dorada Equipada";
            footballBallEquipped = "Fútbol Equipado";
            sharpnelBallEquipped = "<size=27>Bola de Esquirlas Equipada";
            zonicBallEquipped = "Bola de Aro Equipada";
            apricotBallEquipped = "<size=25>Bola de Albaricoque Equipada";
            peggoBallEquipped = "Bola Peggo Equipada";
            ghostBallEquipped = "<size=29>Bola Fantasma Equipada";
            starBallEquipped = "Bola Estrella Equipada";
            rainbowBallEquipped = "Bola Arcoíris Equipada";
            glitchyBallEquipped = "Bola Glitchy Equipada";
            #endregion

            //Level names
            #region Level names
            level3NameString = "<size=30>Nivel 3 - Bosque Oscuro";
            level4NameString = "<size=27>Nivel 4 - Noche Congelada";
            level5NameString = "Nivel 5 - Cementerio";
            level6NameString = "<size=30>Nivel 6 - Bosque Morado";
            level7NameString = "Nivel 7 - Cripta";
            level8NameString = "Nivel 8 - Bosque Azul";
            level9NameString = "Nivel 9 - Cueva Dorada";
            level10NameString = "Nivel 10 - Espacio";
            #endregion

            #region gold prestige upgrade text strings
            clearBonusString = "Ahora recibes un bono de oro al limpiar el tablero.";
            bucketGoldClear = "<size=11>Ahora también recibes un bono de oro al limpiar el tablero cuando una bola entra en un cubo.";
            bucketGoldClear2 = $"<size=11>Cada vez que una bola entra en un cubo, se añadirá un <color=yellow>+{(Prestige.goldClearBonusFromBucket * 100).ToString("F0")}%</color> de oro de la bola desbloqueada con más oro al bono de limpieza del tablero.";
            goldRushString = $"<size=11>¡Golpear un peg dorado tiene un <color=yellow>{Prestige.goldRushChance}%</color> de probabilidad de causar una FIEBRE DE ORO!";
            goldRushString2 = $"<size=11>La fiebre de oro aumentará todo el oro recibido por <color=yellow>{Prestige.goldRushIncrease}X</color> durante <color=green>{Prestige.goldRushTimer}</color> segundos.";
            clearTimerString = "El bono de oro por limpiar el tablero ahora también recibirá más oro basado en la velocidad con la que se limpia el tablero.";
            #endregion

            #region prestige upgrades text strings
            prestigeClearBonus = "¡Ahora recibes un bono de puntos de prestigio al limpiar el tablero!";
            prestigeClearBonus2 = $"Recibirás <color=orange>1</color> punto de prestigio extra por cada <color=orange>{Prestige.prestigeClearBonus1}</color> pegs de prestigio golpeadas. Los pegs de prestigio también dan <color=orange>+1</color> puntos de prestigio.";
            prestigePointBucket = "<size=11>Ahora tienes una pequeña probabilidad de recibir puntos de prestigio cuando una bola entra en un cubo.";
            prestigeRush = $"<size=11>¡Golpear un peg de prestigio tiene un <color=orange>{Prestige.prestigeRushChance}%</color> de probabilidad de causar una FIEBRE DE PRESTIGIO!";
            prestigeRush2 = $"<size=11>La fiebre de prestigio aumentará todos los puntos de prestigio recibidos por <color=orange>{Prestige.prestigeRushIncrease}X</color> durante <color=green>{Prestige.prestigeRushTimer}</color> segundos.";
            #endregion

            #region new pegs upgreades text string
            redPegGoldDouble = "El oro recibido de los pegs rojos se duplica.";
            redPegPrestigeDouble = "Los puntos de prestigio recibidos de los pegs rojos se duplican.";

            rainbowPeg1 = $"<size=11>¡Los pegs arcoíris comenzarán a aparecer! Los pegs arcoíris tienen un <color=green>{Prestige.rainbowPegChance1}%</color> de probabilidad de aparecer.";
            rainbowPeg2 = $"<size=11>Los pegs arcoíris otorgarán 1 de 4 mejoras que durarán <color=green>{Prestige.rainbowPegTimer}</color> segundos. \nMejora 1: 2X oro de los pegs dorados. \nMejora 2: 2X oro de los cubos. \nMejora 3: 2X puntos de prestigio. \nMejora 4: 7% de probabilidad de puntos de prestigio cuando una bola entra en un cubo.";
            rainbowPegIncreaseBuffs = "<size=11>Las mejoras ahora otorgan <color=green>3X</color> oro y puntos de prestigio.";
            rainbowPegReceiveAllBuffs = "Golpear un peg arcoíris ahora otorgará las <color=green>4</color> mejoras.";

            bombPeg1 = $"<size=11>¡Los pegs bomba comenzarán a aparecer! Los pegs bomba tienen un <color=green>{Prestige.bombPegChance1}%</color> de probabilidad de aparecer.";
            bombPeg2 = "<size=11>Las bolas que golpeen el peg bomba explotarán en <color=green>2</color> bolas más.";
            bombPeg3Balls = "¡Los pegs bomba ahora explotan en <color=green>3</color> bolas!";
            bombPeg3to5Balls = "<size=11>¡Los pegs bomba ahora explotan en <color=green>3-5</color> bolas!";

            purplePeg1 = $"<size=11>¡Los pegs morados comenzarán a aparecer! Los pegs morados tienen un <color=green>{Prestige.purplePegChance1}%</color> de probabilidad de aparecer.";
            purplePeg2 = $"<size=11>Las bolas que golpeen el peg morado serán mejoradas. Las bolas mejoradas recibirán <color=green>{Prestige.purplePegEnchanceIncrease1}X</color> oro y puntos de prestigio.";
            purplePegPrestigePoint = "Las bolas mejoradas que caigan en el cubo siempre dan <color=orange>1</color> punto de prestigio.";
            purplePegNextBall = "Al golpear un peg morado, la siguiente bola que se deje caer o se dispare ya estará mejorada.";
            #endregion

            //Stats
            #region new stats
            rainbowPegSpawnChance = "Probabilidad de aparición de peg arcoíris:";
            rainbowPegsHit = "Pegs arcoíris golpeados:";
            bombPegsSpawnChance = "Probabilidad de aparición de peg bomba:";
            bombPegsHit = "Pegs bomba golpeados:";
            purplePegsSpawnChance = "Probabilidad de aparición de peg morado:";
            purplePegsHit = "Pegs morados golpeados:";

            totalGoldRush = "Total de veces alcanzado fiebre de oro:";
            totalGoldFromClear = "Total de oro de bono de limpieza:";
            totalGoldFromShooting = "Total de oro de disparos:";

            totalPRestigeRush = "Total de veces alcanzado fiebre de prestigio:";
            totalPrestigePointFromClear = "<size=20.5>Total de puntos de prestigio de bono de limpieza:";
            totalPrestigePointFromBucket = "Total de puntos de prestigio del cubo:";
            #endregion

            //Challenges
            #region Challenge strings
            bounceCHstring = $"<size=18>Rebota una bola rebotadora en {Challenges.bounceCH} pegs";
            explodeTinyCHstring = $"Explota bolas bomba en {Challenges.explodeTinyCH} bolas \ndiminutas";
            basketballCHstring = $"<size=18>Golpea {Challenges.basketballCH} pegs con la bola de \nbaloncesto";
            eggCHstring = $"Recibe doble oro de bolas de huevo {Challenges.eggCH} \nveces";
            cookieCHstring = $"Recibe {Challenges.cookieCH} puntos de prestigio extra de \nbolas de galleta";
            goldenBallCHstring = $"Recibe oro extra de la bola dorada {Challenges.goldenBallCH} \nveces";
            footballCHstring = $"Entra {Challenges.footballCH} bolas de fútbol en el cubo";
            tinyRingCHstring = $"<size=20>Genera {Challenges.tinyRingCH} bolas de aro \ndiminutas";
            prestigeGemCHstring = $"Golpea {Challenges.prestigeGemCH} gemas de prestigio";
            ghostballCHstring = $"Ten {Challenges.ghostballCH} bolas fantasma en la pantalla \nal mismo tiempo";
            starBallCHstring = $"Genera {Challenges.starBallCH} bolas estrella";
            rainbowBallCHstring = $"Recibe un total de +{Challenges.rainbowBallCH}% de oro de \nbolas arcoíris";
            glitchyBallCHstring = $"Genera {Challenges.glitchyBallCH} bolas glitchy diminutas";
            sharpnelBallCSstring = $"Genera {Challenges.sharpnelBallCH} bolas de esquirlas diminutas";

            //Rewards
            explodeTinyCHRewardstring = $"<size=7.5>Recompensa: Las bolas bomba diminutas ahora otorgan el <color=yellow>{Challenges.explodeTinyCHReward * 100}%</color> del oro de las bolas bomba";
            basketballCHRewardstring = $"<size=7.6>Recompensa: Las bolas de baloncesto ahora otorgan un aumento de oro de <color=yellow>+{Challenges.basketballCHReward * 100}%</color> por rebote";
            eggCHRewardstring = $"<size=9.3>Recompensa: Las bolas de huevo ahora tienen un <color=yellow>{Challenges.eggCHReward}%</color> de recibir doble oro";
            cookieCHRewardstring = $"<size=6.6>Recompensa: Las bolas de galleta ahora tienen un <color=green>{Challenges.cookieCHReward}%</color> de probabilidad de recibir 2X puntos de prestigio";
            goldenBallCHRewardstring = "<size=8.1>Recompensa: Aumenta las probabilidades de oro <color=yellow>2X, 3X y 5X</color> para las bolas doradas";
            footballCHRewardstring = $"<size=8.6>Recompensa: Las bolas de fútbol ahora otorgan <color=yellow>{Challenges.footballCHReward}X</color> oro al aterrizar en un cubo";
            tinyRingCHRewardstring = $"<size=7.6>Recompensa: Las bolas de aro diminutas ahora otorgan el <color=yellow>{Challenges.tinyRingCHReward * 100}%</color> del oro de las bolas de aro";
            prestigeGemCHRewardstring = $"Recompensa: Más gemas de prestigio aparecen";
            ghostballCHRewardstring = $"<size=9>Recompensa: Las bolas fantasma ahora otorgan un aumento de oro de <color=yellow>+{Challenges.ghostballCHReward * 100}%</color>";
            starBallCHRewardstring = $"<size=8.6>Recompensa: Ahora se necesitan <color=green>{Challenges.starBallCHReward}</color> golpes de peg para generar una bola estrella";
            rainbowBallCHRewardstring = $"<size=7.5>Recompensa: Las bolas arcoíris ahora otorgan un aumento de oro de <color=yellow>+{Challenges.rainbowBallCHReward * 100}%</color> por golpe de peg";
            glitchyBallCHRewardstring = $"<size=11.7>Recompensa: Mejora las bonificaciones de todas las bolas";
            goldScaling = "<size=11>Recompensa: Aumenta la escala de oro por nivel de bola 30";
            prestigePegReward = $"<size=9.8>Recompensa: <color=orange>+{Challenges.prestigePegReward}%</color> de probabilidad de aparición de peg de prestigio";
            sharpnelBallCSRewardstring = $"<size=6.7>Recompensa: Las bolas de esquirlas diminutas ahora otorgan el <color=green>{Challenges.sharpnelBallCHReward * 100}%</color> del oro de las bolas de esquirlas";
            #endregion

            //ACH
            #region ACH string
            clearBoardString = "Limpiar el tablero";
            fullyChargeACHstring = "Cargar completamente el lanzador";
            chall1String = "Completar un desafío";
            purchase1Ballstring = "Comprar una nueva bola";
            goldRushACH = "Alcanza una fiebre de oro";
            goldRushACH2 = $"Alcanza una fiebre de oro {Achievements.goldRushNeeded2} veces";
            prestigeRushACH = "Alcanza una fiebre de prestigio";
            prestigeRushACH2 = $"Alcanza una fiebre de prestigio {Achievements.prestigeRushNeeded2} veces";
            allBufsString = "Adquiere todas las bonificaciones al mismo tiempo";
            #endregion

            #region Slider strings
            sliderAll = "<size=21>Pop-ups de texto dorado = <color=green>TODAS LAS BOLAS";
            sliderHalf = "<size=21>Pop-ups de texto dorado = <color=green>50% DE LAS BOLAS";
            slider4Latest = "<size=21>Pop-ups de texto dorado = <color=green>4 ÚLTIMAS BOLAS";
            slider3Latest = "<size=21>Pop-ups de texto dorado = <color=green>3 ÚLTIMAS BOLAS";
            slider2Latest = "<size=21>Pop-ups de texto dorado = <color=green>2 ÚLTIMAS BOLAS";
            sliderLatest = "<size=21>Pop-ups de texto dorado = <color=green>ÚLTIMA BOLA";
            sliderNONE = "<size=21>Pop-ups de texto dorado = <color=red>NINGUNA";
            #endregion

            prestigePointFromShooting = $"Disparar bolas tiene un <color=green>{Prestige.prestigePointFromShotChance}%</color> de probabilidad de otorgar 1 punto de prestigio.";
        }
        #endregion

        #region Tutorial Strings
        tutString1 = "<size=16>¡Apunta a cualquier parte del tablero para disparar bolas a los pegs!";
        tutString2 = "<size=19>¡Acabas de despejar el tablero por primera vez y aparecerá un nuevo tablero! Tu lanzador de bolas se cargará cada vez que despejes el tablero. Pasa el ratón por encima del lanzador de bolas para ver el progreso.";
        tutString3 = "<size=19>¡Acabas de comprar una nueva bola! Puedes equipar cada bola dentro del marco de mejora de bolas, o INSTA EQUIPAR pulsando los números 1-9.";
        tutString4 = "<size=21>Una vez que la pelota caiga en la fosa o en el cubo, la pelota será devuelta.";
        tutString5 = "<size=22>¡Golpea los pegs! Los pegs verdes hacen rebotar la bola. Los pegs dorados dan oro. Los \"Pegs de Prestigio\" naranjas dan puntos de prestigio!";
        tutString6 = "<size=20>Cuando tengas suficiente oro, ¡podrás mejorar tus bolas y comprar bolas nuevas! Cada 30 niveles que alcanza la bola, su incremento de oro de bola se incrementa. Mantén presionada TAB para comprar mejoras máximas";
        #endregion
    }
    #endregion

    //<color=green>
    //</color> 

    #region Change gold gain increase
    public void ChangeGoldGainIncrease(float increase)
    {
        if (englishLanguage == true) { goldGainIncreaseString = $"Increase gold gain by <color=yellow>+{increase * 100}%</color>"; }
        if (chineseLanguage == true) { goldGainIncreaseString = $"增加金币获取量<color=yellow>+{increase * 100}%"; }
        if (japaneseLanguage == true) { goldGainIncreaseString = $"ゴールド獲得量が<color=yellow>+{increase * 100}%</color>増加しました"; }
        if (koreanLanguage == true) { goldGainIncreaseString = $"황금 획득은<color=yellow>+{increase * 100}%</color>씩 증가합니다"; }
        if (russianLanguage == true) { goldGainIncreaseString = $"величьте получение золота на <color=yellow>+{increase * 100}%</color>"; }
        if (germanLanguage == true) { goldGainIncreaseString = $"Goldgewinn um <color=yellow>+{increase * 100}%</color> erhöhen"; }
        if (frenchLanguage == true) { goldGainIncreaseString = $"<size=12.5>Augmentez votre réserve d'or de <color=yellow>+{increase * 100}%"; }
        if (spanishLanguage == true) { goldGainIncreaseString = $"Aumenta la ganancia de oro en <color=yellow>+{increase * 100}%"; }
    }
    #endregion

    #region Chance Bucket And GoldenPegs Texts
    public void ChangeBucketAndGoldenPegs(bool isBucket)
    {
        if (isBucket == false)
        {
            if(englishLanguage == true) { goldenPegString = $"GOLDEN PEGS (LVL{BallUpgrades.goldenPegsLevel})"; }
            if (chineseLanguage == true) { goldenPegString = $"黄金彩钉(等级{BallUpgrades.goldenPegsLevel})"; }
            if (japaneseLanguage == true) { goldenPegString = $"ゴールドペグ (レベル{BallUpgrades.goldenPegsLevel})"; }
            if (koreanLanguage == true) { goldenPegString = $"황금 구슬  (레벨 {BallUpgrades.goldenPegsLevel})"; }
            if (russianLanguage == true) { goldenPegString = $"<size=15.5>ЗОЛОТЫЕ ШАРИКИ (УРОВЕНЬ {BallUpgrades.goldenPegsLevel})"; }
            if (germanLanguage == true) { goldenPegString = $"GOLD-PEGS (LEVEL {BallUpgrades.goldenPegsLevel})"; }
            if (frenchLanguage == true) { goldenPegString = $"<size=20.5>PIONS DORÉS (Niveau {BallUpgrades.goldenPegsLevel})"; }
            if (spanishLanguage == true) { goldenPegString = $"PEGS DORADOS (Nivel {BallUpgrades.goldenPegsLevel})"; }
        }
        if (isBucket == true)
        {
            if (englishLanguage == true) { bucketString = $"BUCKET (LVL{BallUpgrades.bucketLevel})"; }
            if (chineseLanguage == true) { bucketString = $"桶(等级{BallUpgrades.bucketLevel})"; }
            if (japaneseLanguage == true) { bucketString = $"バケツ(レベル{BallUpgrades.bucketLevel})"; }
            if (koreanLanguage == true) { bucketString = $"통 (레벨{BallUpgrades.bucketLevel})"; }
            if (russianLanguage == true) { bucketString = $"<size=18.5>КОРЗИНА (УРОВЕНЬ{BallUpgrades.bucketLevel})"; }
            if (germanLanguage == true) { bucketString = $"EIMER (LEVEL {BallUpgrades.bucketLevel})"; }
            if (frenchLanguage == true) { bucketString = $"<size=22>PANIER (Niveau{BallUpgrades.bucketLevel})"; }
            if (spanishLanguage == true) { bucketString = $"CUBO (Nivel{BallUpgrades.bucketLevel})"; }
        }
    }
    #endregion

    #region Chance Golden peg chance
    public void ChangeGoldPegChanceIncrease(float Chance)
    {
        if (englishLanguage == true) { goldenPegChanceString = $"Golden pegs have a <color=yellow>+{Chance}%</color> chance to spawn"; }
        if (chineseLanguage == true) { goldenPegChanceString = $"黄金彩钉生成的几率增加了<color=green>+{Chance}%</color>"; }
        if (japaneseLanguage == true) { goldenPegChanceString = $"ゴールドペグが<color=green>+{Chance}%</color>の確率で出現します"; }
        if (koreanLanguage == true) { goldenPegChanceString = $"황금 구슬이 나타날 가능성은<color=green>+{Chance}%</color>입니다"; }
        if (russianLanguage == true) { goldenPegChanceString = $"<size=10>Шанс появления золотых колышков составляет<color=green> +{Chance}%"; }
        if (germanLanguage == true) { goldenPegChanceString = $"<size=9.5>Die Spawn-Chance von Gold-Pegs erhöht sich um <color=green>+{Chance}%"; }
        if (frenchLanguage == true) { goldenPegChanceString = $"<size=9>Les pions dorés ont une chance <color=green>+{Chance}%</color> de chance d'apparaître"; }
        if (spanishLanguage == true) { goldenPegChanceString = $"<size=9>Los pegs dorados tienen un <color=green>+{Chance}%</color> de probabilidad de aparecer"; }
    }
    #endregion

    //New
    #region Change board clear gold bonus
    public void ChangeGoldClearAmount(float bonus)
    {
        if (englishLanguage == true) { clearBonusAmountString = $"Each time you hit a golden peg, <color=yellow>{(bonus * 100).ToString("F1")}%</color> gold from the unlocked ball with the most gold will be added to the board clear bonus."; }
        if (chineseLanguage == true) { clearBonusAmountString = $"每次击中一个金彩钉，会从有最多金币的已解锁弹珠中增加<color=yellow>{(bonus * 100).ToString("F1")}%</color>的金币到游戏盘清除奖励中。"; }
        if (japaneseLanguage == true) { clearBonusAmountString = $"ゴールドペグを打つたびに、アンロックされたボールのうち最もゴールドの多いボールのゴールドが<color=yellow>{(bonus * 100).ToString("F1")}%</color>加算されます。"; }
        if (koreanLanguage == true) { clearBonusAmountString = $"황금 구슬을 명중할 때마다, 가장 많은 황금이 있는 잠금 해제된 공의 <color=yellow>{(bonus * 100).ToString("F1")}%</color> 황금이 보드 통과 보너스에 추가될 것입니다. "; }
        if (russianLanguage == true) { clearBonusAmountString = $"При каждом ударе о золотой колышек к бонусу за очистку доски добавится <color=yellow>{(bonus * 100).ToString("F1")}%</color> золота от освобожденного шара с максимумом золота."; }
        if (germanLanguage == true) { clearBonusAmountString = $"<size=10>Jedes Mal, wenn du einen Gold-Peg triffst, werden <color=yellow>{(bonus * 100).ToString("F1")}%</color> Gold vom freigespielten Ball mit dem meisten Gold zum Bonus für das Abräumen des Spielfelds hinzugefügt."; }
        if (frenchLanguage == true) { clearBonusAmountString = $"<size=11>Chaque fois que vous frappez un pion doré, <color=yellow>{(bonus * 100).ToString("F1")}%</color> de l'or de la balle déverrouillée avec le plus d'or sera ajouté au bonus de vidage du plateau."; }
        if (spanishLanguage == true) { clearBonusAmountString = $"<size=10>Cada vez que golpeas un peg dorado, se añadirá un <color=yellow>{(bonus * 100).ToString("F1")}%</color> de oro de la bola desbloqueada con más oro al bono de limpieza del tablero."; }
    }
    #endregion

    #region Change gold timer bonus amounr
    public void ChangeGoldTimeBonusAmont(float bonus)
    {
        if (englishLanguage == true) { clearTimerAmount = $"For each second under <color=green>{Prestige.goldClearTimerSeconds}</color> seconds, <color=yellow>+{(bonus * 100).ToString("F0")}%</color> gold from the unlocked ball with the most gold will be added to the board clear bonus."; }
        if (chineseLanguage == true) { clearTimerAmount = $"少于<color=green>{Prestige.goldClearTimerSeconds}</color>秒的每1秒钟，会从有最多金币的已解锁弹珠中增加<color=yellow>+{(bonus * 100).ToString("F0")}%</color>的金币到游戏盘清除奖励中。"; }
        if (japaneseLanguage == true) { clearTimerAmount = $"<color=green>{Prestige.goldClearTimerSeconds}</color>秒未満の1秒ごとに、最もゴールドの多いアンロックボールから<color=yellow>+{(bonus * 100).ToString("F0")}%</color>のゴールドがボードクリアボーナスに加算されます。"; }
        if (koreanLanguage == true) { clearTimerAmount = $"<color=green>{Prestige.goldClearTimerSeconds}</color>초 이하의 매 초마다, 가장 많은 황금이 있는 잠금 해제된 공의 <color=yellow>+{(bonus * 100).ToString("F0")}%</color> 황금이 보드 통과 보너스에 추가될 것입니다. "; }
        if (russianLanguage == true) { clearTimerAmount = $"<size=11>За каждую секунду менее <color=green>{Prestige.goldClearTimerSeconds}</color> с к бонусу за очистку доски добавится <color=yellow>+{(bonus * 100).ToString("F0")}%</color> золота от освобожденного шара с максимумом золота."; }
        if (germanLanguage == true) { clearTimerAmount = $"<size=10>Für jede Sekunde unter <color=green>{Prestige.goldClearTimerSeconds}</color> Sekunden werden <color=yellow>+{(bonus * 100).ToString("F0")}%</color> Gold vom freigeschalteten Ball mit dem meisten Gold zum Bonus für das Abräumen des Spielfelds hinzugefügt."; }
        if (frenchLanguage == true) { clearTimerAmount = $"À chaque seconde inférieure à <color=green>{Prestige.goldClearTimerSeconds}</color> secondes, un supplément de <color=yellow>+{(bonus * 100).ToString("F0")}%</color> de l'or sera ajouté au bonus de vidage du plateau."; }
        if (spanishLanguage == true) { clearTimerAmount = $"<size=11>Por cada segundo por debajo de <color=green>{Prestige.goldClearTimerSeconds}</color> segundos, se añadirá un <color=yellow>+{(bonus * 100).ToString("F0")}%</color> de oro de la bola desbloqueada con más oro al bono de limpieza del tablero."; }
    }
    #endregion

    #region Change double or more gold chances
    public void ChangeDoubleOrMoreGold(float chance, int xIncrease)
    {
        if (englishLanguage == true) { goldDoubleOrMoreChances = $"Golden pegs have a <color=green>{chance}%</color> chance to give <color=yellow>{xIncrease}X</color> gold"; }
        if (chineseLanguage == true) { goldDoubleOrMoreChances = $"黄金彩钉有<color=green>{chance}%</color>的几率获得<color=yellow>{xIncrease}</color>倍金币。"; }
        if (japaneseLanguage == true) { goldDoubleOrMoreChances = $"ゴールドペグは<color=green>{chance}%</color>の確率で<color=yellow>{xIncrease}</color>倍のゴールドを獲得できます。"; }
        if (koreanLanguage == true) { goldDoubleOrMoreChances = $"황금 구슬은 황금 <color=yellow>{xIncrease}</color>배를 줄 수 있는 확률을 <color=green>{chance}%</color> 가지고 있습니다. "; }
        if (russianLanguage == true) { goldDoubleOrMoreChances = $"У золотых колышков есть <color=green>{chance}%</color> шанс на <color=yellow>{xIncrease}x</color> золота"; }
        if (germanLanguage == true) { goldDoubleOrMoreChances = $"Gold-Pegs haben eine Chance von <color=green>{chance}%</color>, <color=yellow>{xIncrease}x</color> Gold zu geben."; }
        if (frenchLanguage == true) { goldDoubleOrMoreChances = $"Il y a une probabilité de <color=green>{chance}%</color> que les pions dorés octroient un gain de <color=yellow>{xIncrease}x</color> d'or."; }
        if (spanishLanguage == true) { goldDoubleOrMoreChances = $"Los pegs dorados tienen un <color=green>{chance}%</color> de probabilidad de otorgar <color=yellow>{xIncrease}x</color> oro."; }
    }
    #endregion

    #region Change bucket double or more gold chances
    public void ChangeDoubleBucketOrMoreGold(float chance, int xIncrease)
    {
        if (englishLanguage == true) { goldBucketDoubleOrMoreChances = $"<size=11>Buckets have a <color=green>{chance}%</color> chance to give <color=yellow>{xIncrease}X</color> gold"; }
        if (chineseLanguage == true) { goldBucketDoubleOrMoreChances = $"桶有<color=green>{chance}%</color>的几率获得<color=yellow>{xIncrease}</color>倍金币。"; }
        if (japaneseLanguage == true) { goldBucketDoubleOrMoreChances = $"<size=10.5>バケツは<color=green>{chance}%</color>の確率で<color=yellow>{xIncrease}</color>倍のゴールドを獲得します。"; }
        if (koreanLanguage == true) { goldBucketDoubleOrMoreChances = $"<size=10.5>통은 황금 <color=yellow>{xIncrease}</color>배를 줄 수 있는 확률을 <color=green>{chance}%</color> 가지고 있습니다. "; }
        if (russianLanguage == true) { goldBucketDoubleOrMoreChances = $"<size=11>У корзин есть <color=green>{chance}%</color> шанс на <color=yellow>{xIncrease}X</color> золота"; }
        if (germanLanguage == true) { goldBucketDoubleOrMoreChances = $"<size=10.5>Körbe haben eine Chance von <color=green>{chance}%</color>, <color=yellow>{xIncrease}X</color> Gold zu geben."; }
        if (frenchLanguage == true) { goldBucketDoubleOrMoreChances = $"<size=9.5>Il y a une probabilité de <color=green>{chance}%</color> que les paniers octroient un gain de <color=yellow>{xIncrease}X</color> d'or."; }
        if (spanishLanguage == true) { goldBucketDoubleOrMoreChances = $"<size=10>Los cubos tienen un <color=green>{chance}%</color> de probabilidad de otorgar <color=yellow>{xIncrease}X</color> oro."; }
    }
    #endregion


    //<color=orange>
    //</color>
    #region Change prestige peg chance
    public void ChangePrestigePegChance(float Chance)
    {
        if (englishLanguage == true) { prestigePegChanceString = $"<color=green>+{Chance}%</color> Prestige peg spawn chance"; }
        if (chineseLanguage == true) { prestigePegChanceString = $"<color=green>+{Chance}%</color>威望彩钉生成几率"; }
        if (japaneseLanguage == true) { prestigePegChanceString = $"<size=10.5>プレステージペグのスポーン確率が<color=green>+{Chance}%"; }
        if (koreanLanguage == true) { prestigePegChanceString = $"<color=green>+{Chance}%</color> 프레스티지 구슬 생성 확률"; }
        if (russianLanguage == true) { prestigePegChanceString = $"<size=11>Шанс появления колышков престижа <color=green>+{Chance}%</color>"; }
        if (germanLanguage == true) { prestigePegChanceString = $"<size=10.5>Chance auf das Spawnen von Prestige-Pegs <color=green>+{Chance}%"; }
        if (frenchLanguage == true) { prestigePegChanceString = $"<size=10><color=green>+{Chance}%</color> de chance d'apparition des pions de prestige."; }
        if (spanishLanguage == true) { prestigePegChanceString = $"<size=10><color=green>+{Chance}% </color>Probabilidad de aparición de los pegs de prestigio"; }
    }
    #endregion


    //Remember to change this on all langauges, as I changes what display.
    #region Change prestige point gain
    public void ChangePrestigePointGain(int points)
    {
        if (englishLanguage == true) { prestigePointsString = $"Prestige pegs now give <color=orange>+{points}</color> prestige points"; }
        if (chineseLanguage == true) { prestigePointsString = $"威望彩钉现在给予<color=orange>+{points}</color>分威望分。"; }
        if (japaneseLanguage == true) { prestigePointsString = $"<size=9.5>プレステージペグのプレステージポイントが<color=orange>+{points}</color>されます。"; }
        if (koreanLanguage == true) { prestigePointsString = $"<size=11>프레스티지 구슬이<color=orange>+{points}</color> 프레스티지 포인트를 줍니다. "; }
        if (russianLanguage == true) { prestigePointsString = $"<size=11>Колышки престижа теперь дают <color=orange>+{points}</color> очко престижа"; }
        if (germanLanguage == true) { prestigePointsString = $"<size=11.5>Prestige-Pegs geben jetzt <color=orange>+{points}</color>  Prestigepunkt"; }
        if (frenchLanguage == true) { prestigePointsString = $"<size=9>Les pions de prestige octroient désormais <color=orange>+{points}</color> point de prestige"; }
        if (spanishLanguage == true) { prestigePointsString = $"<size=10>Los pegs de prestigio ahora otorgan <color=orange>+{points}</color> puntos de prestigio"; }
    }
    #endregion

    //NEW
    #region Change prestige clear bonus amount
    public void ChangePrestigePointClearBonusAmount(int pegsHit, int prestigePoint)
    {
        if (englishLanguage == true) { prestigeClearBonusAmount = $"You will receive <color=orange>{prestigePoint}</color> extra prestige point for each <color=orange>{pegsHit}</color> prestige pegs hit."; }
        if (chineseLanguage == true) { prestigeClearBonusAmount = $"每击中<color=orange>{pegsHit}</color>个威望彩钉，你将额外获得<color=orange>{prestigePoint}</color>分威望分。"; }
        if (japaneseLanguage == true) { prestigeClearBonusAmount = $"<size=11>プレステージペグが<color=orange>{pegsHit}</color>個ヒットするごとに、プレステージポイントが<color=orange>{prestigePoint}</color>ポイント加算されます。"; }
        if (koreanLanguage == true) { prestigeClearBonusAmount = $"매 <color=orange>{pegsHit}</color>개의 프레스티지 구슬이 명중할 때마다 추가 <color=orange>{prestigePoint}</color> 프레스티지 포인트를 받게 될 것입니다. "; }
        if (russianLanguage == true) { prestigeClearBonusAmount = $"Вы получите <color=orange>{prestigePoint}</color> очко престижа за каждые <color=orange>{pegsHit}</color> ударов о колышки престижа."; }
        if (germanLanguage == true) { prestigeClearBonusAmount = $"Du erhältst <color=orange>{prestigePoint}</color> zusätzlichen Prestigepunkt für jeweils <color=orange>{pegsHit}</color> getroffene Prestige-Pegs."; }
        if (frenchLanguage == true) { prestigeClearBonusAmount = $"Vous recevrez <color=orange>{prestigePoint}</color> point de prestige supplémentaire pour chaque <color=orange>{pegsHit}</color> pions de prestige touchés."; }
        if (spanishLanguage == true) { prestigeClearBonusAmount = $"Recibirás <color=orange>{prestigePoint}</color> punto de prestigio extra por cada <color=orange>{pegsHit}</color> pegs de prestigio golpeados. "; }
    }
    #endregion

    #region Change prestige point bucket chance
    public void ChangePrestigePointBucketChance(float chance)
    {
        if (englishLanguage == true) { prestigePointBucketAmount = $"<color=green>{chance}%</color> chance to recieve <color=orange>1</color> prestige point when a ball enteres a bucket."; }
        if (chineseLanguage == true) { prestigePointBucketAmount = $"弹珠进入桶时有<color=green>{chance}%</color>的几率获得1分威望分。"; }
        if (japaneseLanguage == true) { prestigePointBucketAmount = $"ボールがバケツに入ると、<color=green>{chance}%</color>の確率でプレステージポイントを1ポイント獲得します。"; }
        if (koreanLanguage == true) { prestigePointBucketAmount = $"공이 통으로 들어갈 때 1 프레스티지 포인트를 받을 수 있는 확률 <color=green>{chance}%</color> "; }
        if (russianLanguage == true) { prestigePointBucketAmount = $"<color=green>{chance}%</color> шанс на 1 очко престижа, если шар попал в корзину."; }
        if (germanLanguage == true) { prestigePointBucketAmount = $"<color=green>{chance}%</color> Chance, 1 Prestigepunkt zu erhalten, wenn ein Ball in einen Korb trifft."; }
        if (frenchLanguage == true) { prestigePointBucketAmount = $"<size=11>Il y a une probabilité de <color=green>{chance}%</color> de recevoir un point de prestige lorsque qu'une balle pénètre dans un panier."; }
        if (spanishLanguage == true) { prestigePointBucketAmount = $"<size=11.5><color=green>{chance}%</color> de probabilidad de recibir 1 punto de prestigio cuando una bola entra en un cubo."; }
    }
    #endregion

    #region Change 2X or more chance
    public void Change2XorMorePrestigeChance(float chance, int increase)
    {
        if (englishLanguage == true) { prestige2XorMore = $"Prestige pegs have a <color=green>{chance}%</color> chance to receive <color=orange>{increase}X</color> prestige points"; }
        if (chineseLanguage == true) { prestige2XorMore = $"威望彩钉有<color=green>{chance}%</color>的几率获得<color=orange>{increase}</color>倍威望分"; }
        if (japaneseLanguage == true) { prestige2XorMore = $"プレステージペグは、<color=green>{chance}%</color>の確率でプレステージポイントが<color=orange>{increase}</color>倍になります。"; }
        if (koreanLanguage == true) { prestige2XorMore = $"프레스티지 구슬은 프레스티지 포인트 <color=orange>{increase}</color>배를 줄 수 있는 확률 <color=green>{chance}%</color>를 가지고 있습니다. "; }
        if (russianLanguage == true) { prestige2XorMore = $"У колышков престижа есть <color=green>{chance}%</color> шанс на <color=orange>{increase}X</color> очков престижа"; }
        if (germanLanguage == true) { prestige2XorMore = $"Prestige-Pegs haben eine Chance von <color=green>{chance}%</color>, <color=orange>{increase}X</color> Prestigepunkte zu erhalten"; }
        if (frenchLanguage == true) { prestige2XorMore = $"Il y a une probabilité de <color=green>{chance}%</color> que les pions de prestige reçoivent un gain de <color=orange>{increase}X</color> de points de prestige."; }
        if (spanishLanguage == true) { prestige2XorMore = $"Los pegs de prestigio tienen un <color=green>{chance}%</color> de probabilidad de recibir <color=orange>{increase}X</color> puntos de prestigio."; }
    }
    #endregion

    //New pegs - ALL NEW
    #region Change red peg chance
    public void ChangeRedPegChance(float chance)
    {
        if (englishLanguage == true) { redPegChance = $"Red pegs have a <color=green>+{chance}%</color> chance to spawn"; }
        if (chineseLanguage == true) { redPegChance = $"红色彩钉有<color=green>+{chance}%</color>的几率生成"; }
        if (japaneseLanguage == true) { redPegChance = $"赤ペグが出現する確率が<color=green>+{chance}%</color>になりました。"; }
        if (koreanLanguage == true) { redPegChance = $"빨간 구슬이 나타날 확률은 <color=green>+{chance}%</color> 입니다. "; }
        if (russianLanguage == true) { redPegChance = $"<size=10>Плюс<color=green>{chance}%</color> к появлению красных колышков"; }
        if (germanLanguage == true) { redPegChance = $"<size=10>Rote Pegs haben eine Chance von <color=green>+{chance}%</color> zu spawnen"; }
        if (frenchLanguage == true) { redPegChance = $"<size=10>Il y a une chance supplémentaire de <color=green>+{chance}%</color> de faire apparaître des pions rouges."; }
        if (spanishLanguage == true) { redPegChance = $"<size=10>Los pegs rojos tienen un <color=green>+{chance}%</color> de probabilidad de aparecer."; }
    }
    #endregion

    #region Change rainbow peg chance
    public void ChangeRainbowPegChance(float chance)
    {
        if (englishLanguage == true) { rainbowPegChance = $"Rainbow pegs have a <color=green>+{chance}%</color> chance to spawn"; }
        if (chineseLanguage == true) { rainbowPegChance = $"彩虹彩钉有<color=green>+{chance}%</color>的几率生成"; }
        if (japaneseLanguage == true) { rainbowPegChance = $"レインボーペグは<color=green>+{chance}%</color>の確率で出現します。"; }
        if (koreanLanguage == true) { rainbowPegChance = $"무지개 구슬이 나타날 확률은 <color=green>+{chance}%</color> 입니다. "; }
        if (russianLanguage == true) { rainbowPegChance = $"Плюс <color=green>{chance}%</color> к появлению радужных колышков"; }
        if (germanLanguage == true) { rainbowPegChance = $"Regenbogen-Pegs haben eine Chance von <color=green>+{chance}%</color> zu spawnen"; }
        if (frenchLanguage == true) { rainbowPegChance = $"Il y a une probabilité supplémentaire de <color=green>+{chance}%</color> de faire apparaître des pions arc-en-ciel."; }
        if (spanishLanguage == true) { rainbowPegChance = $"Los pegs arcoíris tienen un <color=green>+{chance}%</color> de probabilidad de aparecer."; }
    }
    #endregion

    #region Chance bomb peg chance
    public void ChangeBombPegChance(float chance)
    {
        if (englishLanguage == true) { bombPegChance = $"Bomb pegs have a <color=green>+{chance}%</color> chance to spawn"; }
        if (chineseLanguage == true) { bombPegChance = $"炸弹彩钉有<color=green>+{chance}%</color>的几率生成"; }
        if (japaneseLanguage == true) { bombPegChance = $"ボムペグは<color=green>+{chance}%</color>の確率で出現します。"; }
        if (koreanLanguage == true) { bombPegChance = $"폭탄 구슬이 나타날 확률은 <color=green>+{chance}%</color> 입니다. "; }
        if (russianLanguage == true) { bombPegChance = $"<size=10>Плюс <color=green>{chance}%</color> к появлению бомбовых колышков"; }
        if (germanLanguage == true) { bombPegChance = $"<size=10>Schrapnell-Pegs haben eine Chance von <color=green>+{chance}%</color> zu spawnen"; }
        if (frenchLanguage == true) { bombPegChance = $"<size=9.7>Il y a une probabilité supplémentaire de <color=green>+{chance}%</color> de faire apparaître des pions bombe"; }
        if (spanishLanguage == true) { bombPegChance = $"<size=10>Los pegs bomba tienen un <color=green>+{chance}%</color> de probabilidad de aparecer."; }
    }
    #endregion

    #region Change purple peg chance
    public void ChangePurplePegChance(float chance)
    {
        if (englishLanguage == true) { purplePegChance = $"Purple pegs have a <color=green>+{chance}%</color> chance to spawn"; }
        if (chineseLanguage == true) { purplePegChance = $"紫色彩钉有<color=green>+{chance}%</color>的几率生成"; }
        if (japaneseLanguage == true) { purplePegChance = $"紫ペグは<color=green>+{chance}%</color>の確率で出現します。"; }
        if (koreanLanguage == true) { purplePegChance = $"보라 구슬이 나타날 확률은 <color=green>+{chance}%</color>입니다. "; }
        if (russianLanguage == true) { purplePegChance = $"<size=10>Плюс <color=green>{chance}%</color> к появлению фиолетовых колышков"; }
        if (germanLanguage == true) { purplePegChance = $"<size=10>Violette Pegs haben eine Chance von <color=green>+{chance}%</color> zu spawnen"; }
        if (frenchLanguage == true) { purplePegChance = $"<size=9.5>Il y a une probabilité supplémentaire de <color=green>+{chance}%</color> de faire apparaître des pions violets"; }
        if (spanishLanguage == true) { purplePegChance = $"<size=10>Los pegs morados tienen un <color=green>+{chance}%</color> de probabilidad de aparecer."; }
    }
    #endregion

    #region Change purple peg increases
    public void ChangePurplePegIncrease(float increase)
    {
        if (englishLanguage == true) { purplePegIncrease = $"Enhanced balls now give <color=green>{increase}X</color> gold and prestige points"; }
        if (chineseLanguage == true) { purplePegIncrease = $"强化弹珠现在给予<color=green>{increase}</color>倍金币和威望分"; }
        if (japaneseLanguage == true) { purplePegIncrease = $"強化ボールのゴールドとプレステージポイントが<color=green>{increase}</color>倍になりました。"; }
        if (koreanLanguage == true) { purplePegIncrease = $"강화된 공들은 <color=green>{increase}</color>배의 황금 및 프레스티지 포인트를 줍니다. "; }
        if (russianLanguage == true) { purplePegIncrease = $"Усиленные шары теперь дают <color=green>{increase}X</color> золота и очков престижа"; }
        if (germanLanguage == true) { purplePegIncrease = $"Aufgewertete Bälle geben jetzt <color=green>{increase}X</color> Gold und Prestigepunkte"; }
        if (frenchLanguage == true) { purplePegIncrease = $"Les balles améliorées octroient désormais un gain d'or et de points de prestige multiplié par <color=green>{increase}X</color>"; }
        if (spanishLanguage == true) { purplePegIncrease = $"Las bolas mejoradas ahora otorgan <color=green>{increase}X</color> oro y puntos de prestigio."; }
    }
    #endregion

    //moreShots - NEW
    #region Change more shots
    public void ChangeMoreShots(int shots)
    {
        if (englishLanguage == true) { moreShots = $"You now shoot <color=green>{shots}</color> balls at once!"; }
        if (chineseLanguage == true) { moreShots = $"现在你一次射出<color=green>{shots}</color>个弹珠！"; }
        if (japaneseLanguage == true) { moreShots = $"<size=11><color=green>{shots}</color>つのボールを同時に発射できるようになりました！"; }
        if (koreanLanguage == true) { moreShots = $"한 번에 <color=green>{shots}</color>개의 공을 발사할 수 있습니다!"; }
        if (russianLanguage == true) { moreShots = $"Теперь вы запускаете по <color=green>{shots}</color> шара!"; }
        if (germanLanguage == true) { moreShots = $"Du schießt jetzt <color=green>{shots}</color> Bälle auf einmal!"; }
        if (frenchLanguage == true) { moreShots = $"Maintenant, vous tirez <color=green>{shots}</color> balles à la fois !"; }
        if (spanishLanguage == true) { moreShots = $"¡Ahora disparas <color=green>{shots}</color> bolas a la vez!"; }
    }
    #endregion

    //Active
    #region Change ball shot gold increase
    public void ChangeBallShotGoldIncrease(float increase)
    {
        if (englishLanguage == true) { ballsShotGoldIncreaseString = $"Balls shot give <color=yellow>+{increase * 100}%</color> more gold"; }
        if (chineseLanguage == true) { ballsShotGoldIncreaseString = $"发射的弹珠额外获得<color=yellow>+{increase * 100}%</color> 的金币"; }
        if (japaneseLanguage == true) { ballsShotGoldIncreaseString = $"<size=9.7>ボールショットのゴールド獲得量が<color=yellow>+{increase * 100}%</color>増加しました"; }
        if (koreanLanguage == true) { ballsShotGoldIncreaseString = $"공 발사는 <color=yellow>+{increase * 100}%</color> 이상의 황금을 제공합니다"; }
        if (russianLanguage == true) { ballsShotGoldIncreaseString = $"<size=11>Выстрел шара дает на <color=yellow>+{increase * 100}% </color>больше золота"; }
        if (germanLanguage == true) { ballsShotGoldIncreaseString = $"<size=10.5>Geschossene Bälle geben <color=yellow>+{increase * 100}% </color>mehr Gold"; }
        if (frenchLanguage == true) { ballsShotGoldIncreaseString = $"<size=10>Les balles lancées donnent <color=yellow>+{increase * 100}%</color> d'or supplémentaire."; }
        if (spanishLanguage == true) { ballsShotGoldIncreaseString = $"<size=11>Las bolas disparadas dan <color=yellow>+{increase * 100}%</color> más de oro"; }
    }
    #endregion

    //New
    #region Change start with gold
    public void ChangeStartWithGold(double gold)
    {
        if (englishLanguage == true) { startWithGold = $"Start with <color=yellow>{gold}</color> gold after prestige."; }
        if (chineseLanguage == true) { startWithGold = $"在威望重置后开始时有<color=yellow>{gold}</color>金币。"; }
        if (japaneseLanguage == true) { startWithGold = $"<size=11.5>プレステージ後は<color=yellow>{gold}</color>ゴールドからスタート"; }
        if (koreanLanguage == true) { startWithGold = $"<size=11>프레스티지 이후 <color=yellow>{gold}</color>개의 황금으로 시작합니다. "; }
        if (russianLanguage == true) { startWithGold = $"Начните с <color=yellow>{gold}</color> золота за престиж."; }
        if (germanLanguage == true) { startWithGold = $"<size=11>Beginne mit <color=yellow>{gold}</color> Gold nach Prestige."; }
        if (frenchLanguage == true) { startWithGold = $"<size=9.2>Vous démarrez avec un solde de <color=yellow>{gold}</color> pièces d'or après la réinitialisation de prestige"; }
        if (spanishLanguage == true) { startWithGold = $"<size=11>Comienza con <color=yellow>{gold}</color> de oro después del prestigio."; }
    }
    #endregion

    #region Change more prestige points from shots
    public void ChangeShotsPrestigePoints(int increase)
    {
        if (englishLanguage == true) { morePrestigePointFromShooting = $"Prestige pegs hit with shot balls give <color=orange>{increase}</color> more prestige points"; }
        if (chineseLanguage == true) { morePrestigePointFromShooting = $"射击弹珠击中的威望彩钉会额外给予<color=orange>{increase}</color>分威望分。"; }
        if (japaneseLanguage == true) { morePrestigePointFromShooting = $"プレステージのペグにボールが命中すると、プレステージのポイントが<color=orange>{increase}</color>されます。"; }
        if (koreanLanguage == true) { morePrestigePointFromShooting = $"발사된 구슬들로 명중된 프레스티지 구슬들은 <color=orange>{increase}</color> 이상의 프레스티지 포인트를 줍니다. "; }
        if (russianLanguage == true) { morePrestigePointFromShooting = $"Удары шаров о колышки престижа дают <color=orange>+{increase}</color> очка престижа"; }
        if (germanLanguage == true) { morePrestigePointFromShooting = $"Mit geschossenen Bällen getroffene Prestige-Pegs geben <color=orange>{increase}</color> weitere Prestigepunkte"; }
        if (frenchLanguage == true) { morePrestigePointFromShooting = $"Lorsqu'une balle tirée touche des pions de prestige, cela ajoute <color=orange>{increase}</color> points de prestige de plus."; }
        if (spanishLanguage == true) { morePrestigePointFromShooting = $"Los pegs de prestigio golpeados con bolas disparadas otorgan <color=orange>{increase}</color> puntos de prestigio más."; }
    }
    #endregion

    #region Change gold from shooting
    public void ChangeGoldFromShooting(float percent)
    {
        if (englishLanguage == true) { goldFromShooting = $"You will receive <color=yellow>{(percent * 100).ToString("F0")}%</color> gold from the unlocked ball with the most gold when you shoot a ball."; }
        if (chineseLanguage == true) { goldFromShooting = $"射出弹珠时，你将从有最多金币的已解锁弹珠中获得<color=yellow>{(percent * 100).ToString("F0")}%</color>金币。"; }
        if (japaneseLanguage == true) { goldFromShooting = $"<size=11>ボールをシュートすると、最もゴールドの多いアンロックされたボールから<color=yellow>{(percent * 100).ToString("F0")}%</color>のゴールドがもらえます。"; }
        if (koreanLanguage == true) { goldFromShooting = $"공이 발사될 떄, 가장 많은 황금을 가진 잠금 해제된 공에서 <color=yellow>{(percent * 100).ToString("F0")}%</color> 황금을 받게 될 것입니다. "; }
        if (russianLanguage == true) { goldFromShooting = $"<size=11>При запуске шара, вы получите <color=yellow>{(percent * 100).ToString("F0")}%</color> золота от освобожденного шара с максимумом золота."; }
        if (germanLanguage == true) { goldFromShooting = $"<size=11>Du erhältst <color=yellow>{(percent * 100).ToString("F0")}%</color>Gold vom freigeschalteten Ball mit dem meisten Gold, wenn du einen Ball schießt."; }
        if (frenchLanguage == true) { goldFromShooting = $"<size=11.5>Vous recevrez <color=yellow>{(percent * 100).ToString("F0")}%</color> d'or provenant de la balle déverrouillée possédant le plus d'or lorsque vous tirez une balle."; }
        if (spanishLanguage == true) { goldFromShooting = $"<size=11>Recibirás un <color=yellow>{(percent * 100).ToString("F0")}%</color> de oro de la bola desbloqueada con más oro cuando dispares una bola."; }
    }
    #endregion

    //New level
    #region Change level unlocked
    public void LevelUnlocked(int level)
    {
        if (englishLanguage == true) { levelUnlockedString = $"Unlock level <color=green>{level}</color>!"; }
        if (chineseLanguage == true) { levelUnlockedString = $"解锁等级<color=green>{level}</color>!"; }
        if (japaneseLanguage == true) { levelUnlockedString = $"レベル<color=green>{level}</color>のロックを解除!"; }
        if (koreanLanguage == true) { levelUnlockedString = $"레벨<color=green>{level}</color> 잠금 해제!"; }
        if (russianLanguage == true) { levelUnlockedString = $"Разблокируйте <color=green>{level}</color>уровень!"; }
        if (germanLanguage == true) { levelUnlockedString = $"Schalte Level <color=green>{level}</color> frei!"; }
        if (frenchLanguage == true) { levelUnlockedString = $"Débloquez le niveau <color=green>{level}</color> !"; }
        if (spanishLanguage == true) { levelUnlockedString = $"¡Desbloquear nivel <color=green>{level}</color>!"; }
    }
    #endregion

    #region Change level pegs and boards
    public void LevelPegsAndBoards(int level, int boards, int minPegs, int maxPegs)
    {
        if (englishLanguage == true) { levelBoardsAndPegsString = $"Level <color=green>{level}</color> contains <color=green>{boards}</color> different boards. Each board contains around <color=green>{minPegs}-{maxPegs}</color> pegs"; }

        if (chineseLanguage == true) { levelBoardsAndPegsString = $"第 <color=green>{level}</color> 级包含 <color=green>{boards}</color> 种不同的游戏盘。每个游戏盘包含约 <color=green>{minPegs}</color> - <color=green>{maxPegs}</color> 个彩钉"; }

        if (japaneseLanguage == true) { levelBoardsAndPegsString = $"レベル<color=green>{level}</color>には<color=green>{boards}</color>種類のボードがあります。各ボードには約<color=green>{minPegs}</color> ～ <color=green>{maxPegs}</color> 個のペグがあります"; }

        if (koreanLanguage == true) { levelBoardsAndPegsString = $"레벨<color=green>{level}</color> 는 <color=green>{boards}</color> 개의 다른 보드를 가지고 있습니다. 각 보드는 약 <color=green>{minPegs}</color>-<color=green>{maxPegs}</color> 개의 구슬을 포함합니다"; }

        if (russianLanguage == true) { levelBoardsAndPegsString = $"Уровень <color=green>{level}</color> содержит <color=green>{boards}</color> различных досок. Каждая доска содержит около <color=green>{minPegs}</color>-<color=green>{maxPegs}</color> колышков"; }

        if (germanLanguage == true) { levelBoardsAndPegsString = $"Level <color=green>{level}</color> besteht aus <color=green>{boards}</color> verschiedenen Runden. Jede Runde hat etwa <color=green>{minPegs}</color>-<color=green>{maxPegs}</color> Pegs"; }

        if (frenchLanguage == true) { levelBoardsAndPegsString = $"<size=10.5>Le <color=green>{level}</color> e niveau comprend <color=green>{boards}</color> plateaux différents, chacun contenant environ <color=green>{minPegs}</color> à <color=green>{maxPegs}</color> pions"; }

        if (spanishLanguage == true) { levelBoardsAndPegsString = $"El Nivel <color=green>{level}</color> contiene <color=green>{boards}</color> tableros diferentes. Cada tablero contiene unos <color=green>{minPegs}</color>-<color=green>{maxPegs}</color> pegs"; }
    }
    #endregion

    #region Change level selected
    public void LevelSelected(int level)
    {
        if (englishLanguage == true) { levelSelectedString = $"Level {level} selected!"; }
        if (chineseLanguage == true) { levelSelectedString = $"已选择第{level}级"; }
        if (japaneseLanguage == true) { levelSelectedString = $"レベル{level}選択"; }
        if (koreanLanguage == true) { levelSelectedString = $"레벨{level} 선택 "; }
        if (russianLanguage == true) { levelSelectedString = $"Уровень {level} выбран"; }
        if (germanLanguage == true) { levelSelectedString = $"Level {level} ausgewählt"; }
        if (frenchLanguage == true) { levelSelectedString = $"Niveau {level} sélectionné"; }
        if (spanishLanguage == true) { levelSelectedString = $"<size=39>Nivel {level} Seleccionado"; }
    }
    #endregion

    #region Change level stats
    public void LevelStats(int boardCount, int minBoardCount, int maxBoardCount)
    {
        //Boards
        if (englishLanguage == true) { levelBoardCountString = $"Board count: <color=green>{boardCount}"; }
        if (chineseLanguage == true) { levelBoardCountString = $"游戏盘数量：<color=green>{boardCount}"; }
        if (japaneseLanguage == true) { levelBoardCountString = $"ボード数: <color=green>{boardCount}"; }
        if (koreanLanguage == true) { levelBoardCountString = $"보드 수: <color=green>{boardCount}"; }
        if (russianLanguage == true) { levelBoardCountString = $"Количество досок: <color=green>{boardCount}"; }
        if (germanLanguage == true) { levelBoardCountString = $"Rundenzahl: <color=green>{boardCount}"; }
        if (frenchLanguage == true) { levelBoardCountString = $"Nombre de plateaux : <color=green>{boardCount}"; }
        if (spanishLanguage == true) { levelBoardCountString = $"Recuento de tableros: <color=green>{boardCount}"; }

        //Pegs
        if (englishLanguage == true) { levelPegsCountString = $"Peg Count: <color=green>{minBoardCount}</color>-<color=green>{maxBoardCount}"; }
        if (chineseLanguage == true) { levelPegsCountString = $"彩钉数量：<color=green>{minBoardCount}</color>-<color=green>{maxBoardCount}"; }
        if (japaneseLanguage == true) { levelPegsCountString = $"ペグ数：<color=green>{minBoardCount}</color>-<color=green>{maxBoardCount}"; }
        if (koreanLanguage == true) { levelPegsCountString = $"구슬 수: <color=green>{minBoardCount}</color>-<color=green>{maxBoardCount}"; }
        if (russianLanguage == true) { levelPegsCountString = $"Количество колышков: <color=green>{minBoardCount}</color>-<color=green>{maxBoardCount}"; }
        if (germanLanguage == true) { levelPegsCountString = $"Peg-Zahl:<color=green> {minBoardCount}</color>-<color=green>{maxBoardCount}"; }
        if (frenchLanguage == true) { levelPegsCountString = $"Nombre de pions :<color=green> {minBoardCount}</color>-<color=green>{maxBoardCount}"; }
        if (spanishLanguage == true) { levelPegsCountString = $"Número de pegs: <color=green>{minBoardCount}</color>-<color=green>{maxBoardCount}"; }
    }
    #endregion

    //Challenge needed - ALL NEW
    #region Change clear board
    public static string boardClearCHstring;
    public void ChangeBoardClearText(int level)
    {
        if (englishLanguage == true) { boardClearCHstring = $"Clear all boards on level {level}"; }
        if (chineseLanguage == true) { boardClearCHstring = $"清除所有第{level}级的游戏盘"; }
        if (japaneseLanguage == true) { boardClearCHstring = $"<size=20>レベル{level}ですべてのボードをクリア"; }
        if (koreanLanguage == true) { boardClearCHstring = $"레벨 {level}에서 모든 보드 통과하기 "; }
        if (russianLanguage == true) { boardClearCHstring = $"<size=22>Очистите все доски на Уровне {level}"; }
        if (germanLanguage == true) { boardClearCHstring = $"<size=21>Beende alle Spielfelder auf Level {level}"; }
        if (frenchLanguage == true) { boardClearCHstring = $"<size=20>Vider tous les plateaux au niveau {level}"; }
        if (spanishLanguage == true) { boardClearCHstring = $"<size=19>Limpia todos los tableros en el nivel {level}"; }
    }
    #endregion

    #region Change reach max auto drop
    public static string reachAutoCHstring;
    public void ChangeReachMaxAutoDrop(int balls, string extraText)
    {
        if (englishLanguage == true) { reachAutoCHstring = $"Reach max auto drop on {balls} ball{extraText}"; }
        if (chineseLanguage == true) { reachAutoCHstring = $"达到{balls}个弹珠的自动掉落最大值"; }
        if (japaneseLanguage == true) { reachAutoCHstring = $"<size=16>{balls}つのボールでオートドロップを最大にする"; }
        if (koreanLanguage == true) { reachAutoCHstring = $"{balls}<size=18.5>개의 공으로 최대 자동 투하에 도달하기 "; }
        if (russianLanguage == true) { reachAutoCHstring = $"<size=18>Получите макс. автосброс на {balls} шарах"; }
        if (germanLanguage == true) { reachAutoCHstring = $"<size=17>Erreiche den maximalen Autodrop bei {balls} \nBällen"; }
        if (frenchLanguage == true) { reachAutoCHstring = $"<size=15>Atteindre le maximum de lâcher automatique \nsur {balls} balle{extraText}"; }
        if (spanishLanguage == true) { reachAutoCHstring = $"<size=16>Alcanza el máximo de caída automática en \n{balls} bola{extraText}."; }
    }
    #endregion

    #region Change upgrade ball to level
    public static string upgradeBallToCH;
    public void ChangeUpgradeBallTo(int level)
    {
        if (englishLanguage == true) { upgradeBallToCH = $"Upgrade a ball to level {level}"; }
        if (chineseLanguage == true) { upgradeBallToCH = $"将一个弹珠升级到{level}级"; }
        if (japaneseLanguage == true) { upgradeBallToCH = $"<size=17>ボールをレベル{level}にアップグレードする"; }
        if (koreanLanguage == true) { upgradeBallToCH = $"레벨 {level}까지 공 업그레이드 하기 "; }
        if (russianLanguage == true) { upgradeBallToCH = $"Улучшите шар до {level}-го уровня"; }
        if (germanLanguage == true) { upgradeBallToCH = $"Upgrade einen Ball auf Level {level}"; }
        if (frenchLanguage == true) { upgradeBallToCH = $"<size=18.5>Amélioration de la balle au niveau {level}"; }
        if (spanishLanguage == true) { upgradeBallToCH = $"Mejora una bola al nivel {level}."; }
    }
    #endregion

    #region Change hit golden pegs
    public static string hitGoldenPegsCH;
    public void ChangeHitGoldenPegs(int pegs)
    {
        if (englishLanguage == true) { hitGoldenPegsCH = $"Hit a total of {pegs} golden pegs"; }
        if (chineseLanguage == true) { hitGoldenPegsCH = $"总共击中{pegs}个黄金彩钉"; }
        if (japaneseLanguage == true) { hitGoldenPegsCH = $"ゴールデンペグを合計{pegs}個打つ"; }
        if (koreanLanguage == true) { hitGoldenPegsCH = $"총 {pegs}개의 황금 구슬 명중하기 "; }
        if (russianLanguage == true) { hitGoldenPegsCH = $"<size=17.6>Попадите в {pegs} золотых колышков"; }
        if (germanLanguage == true) { hitGoldenPegsCH = $"Triff insgesamt {pegs} Gold-Pegs"; }
        if (frenchLanguage == true) { hitGoldenPegsCH = $"<size=17>Frapper un total de {pegs} pions dorés"; }
        if (spanishLanguage == true) { hitGoldenPegsCH = $"<size=16.5>Golpea un total de {pegs} pegs dorados."; }
    }
    #endregion

    #region Change hit buckets
    public static string hitBucketsCH;
    public void ChangeHitBuckets(int balls)
    {
        if (englishLanguage == true) { hitBucketsCH = $"Have {balls} balls enter the bucket"; }
        if (chineseLanguage == true) { hitBucketsCH = $"使{balls}个弹珠进入桶中"; }
        if (japaneseLanguage == true) { hitBucketsCH = $"{balls}個のボールをバケツに入れる"; }
        if (koreanLanguage == true) { hitBucketsCH = $"공 {balls}개를 통에 넣기 "; }
        if (russianLanguage == true) { hitBucketsCH = $"Забейте в корзину {balls} шаров"; }
        if (germanLanguage == true) { hitBucketsCH = $"Fange {balls} Bälle in Körben auf"; }
        if (frenchLanguage == true) { hitBucketsCH = $"<size=16.5>Faire entrer {balls} balles dans le panier"; }
        if (spanishLanguage == true) { hitBucketsCH = $"<size=17.5>Haz que {balls} bolas entren en el cubo."; }
    }
    #endregion

    //Challenge rewards - ALL NEW
    #region Change gold increase reward
    public static string goldRewardString;
    public void ChangeGoldReward(float goldIncrease)
    {
        if (englishLanguage == true) { goldRewardString = $"Reward: Increase gold gain by <color=yellow>+{goldIncrease * 100}%"; }
        if (chineseLanguage == true) { goldRewardString = $"奖励：增加<color=yellow>+{goldIncrease * 100}%</color>金币获取"; }
        if (japaneseLanguage == true) { goldRewardString = $"報酬：ゴールド獲得量が<color=yellow>+{goldIncrease * 100}%"; }
        if (koreanLanguage == true) { goldRewardString = $"보상: <color=yellow>+{goldIncrease * 100}%</color> 황금 획득 향상 "; }
        if (russianLanguage == true) { goldRewardString = $"Награда: <color=yellow>+{goldIncrease * 100}%</color> к золоту"; }
        if (germanLanguage == true) { goldRewardString = $"Belohnung: Erhöhe den Goldgewinn um <color=yellow>+{goldIncrease * 100}%"; }
        if (frenchLanguage == true) { goldRewardString = $"Récompense : Augmentez le gain d'or de <color=yellow>+{goldIncrease * 100}%"; }
        if (spanishLanguage == true) { goldRewardString = $"Recompensa: Aumenta la ganancia de oro en <color=yellow>+{goldIncrease * 100}%"; }
    }
    #endregion

    #region Change gold peg chance reward
    public static string goldPegRewardString;
    public void ChangeGoldPegChanceReward(float chance)
    {
        if (englishLanguage == true) { goldPegRewardString = $"Reward: Increase golden peg spawn chance by <color=yellow>+{chance.ToString("F1")}%"; }
        if (chineseLanguage == true) { goldPegRewardString = $"奖励：增加<color=yellow>+{chance.ToString("F1")}%</color>黃金彩钉的生成几率"; }
        if (japaneseLanguage == true) { goldPegRewardString = $"報酬：ゴールドペグの出現率が<color=yellow>+{chance.ToString("F1")}%"; }
        if (koreanLanguage == true) { goldPegRewardString = $"보상: <color=yellow>+{chance.ToString("F1")}%</color> 까지 황금 구슬 생성 확률 향상 "; }
        if (russianLanguage == true) { goldPegRewardString = $"Награда: <color=yellow>+{chance.ToString("F1")}%</color> к появлению золотых колышков"; }
        if (germanLanguage == true) { goldPegRewardString = $"Belohnung: Erhöhe die Chance auf Gold-Pegs um <color=yellow>+{chance.ToString("F1")}%"; }
        if (frenchLanguage == true) { goldPegRewardString = $"<size=9.3>Récompense : Augmentez la chance d'apparition des pions dorés de <color=yellow>+{chance.ToString("F1")}%"; }
        if (spanishLanguage == true) { goldPegRewardString = $"<size=8.8>Recompensa: Aumenta la probabilidad de aparición de pegs dorados en <color=yellow>+{chance.ToString("F1")}%"; }
    }
    #endregion

    #region Change active gold increase reward
    public static string goldActiveRewardString;
    public void ChangeGoldActiveReward(float gold)
    {
        if (englishLanguage == true) { goldActiveRewardString = $"Reward: Increase gold from shot balls by <color=yellow>{gold * 100}%"; }
        if (chineseLanguage == true) { goldActiveRewardString = $"奖励：增加<color=yellow>{gold * 100}%</color>射击弹珠的金币"; }
        if (japaneseLanguage == true) { goldActiveRewardString = $"報酬：ショットボールのゴールド獲得量<color=yellow>{gold * 100}%"; }
        if (koreanLanguage == true) { goldActiveRewardString = $"보상: 발사된 공에서 <color=yellow>{gold * 100}%</color>까지의 황금 향상 "; }
        if (russianLanguage == true) { goldActiveRewardString = $"Награда: <color=yellow>{gold * 100}%</color> к золоту от запуска шаров"; }
        if (germanLanguage == true) { goldActiveRewardString = $"Belohnung: Erhöhe Gold aus geschossenen Bällen um <color=yellow>{gold * 100}%"; }
        if (frenchLanguage == true) { goldActiveRewardString = $"Récompense : Augmentez l'or des balles tirées de <color=yellow>{gold * 100}%"; }
        if (spanishLanguage == true) { goldActiveRewardString = $"<size=10.5>Recompensa: Aumenta el oro de las bolas disparadas en un <color=yellow>{gold * 100}%"; }
    }
    #endregion

    #region Change bucket and gold peg upgrade increase
    public static string bucketAndGoldIncreaseString;
    public void ChangeBucketAndGoldPegIncrease(bool bucket, float increase)
    {
        if(bucket == false)
        {
            if (englishLanguage == true) { bucketAndGoldIncreaseString = $"Reward: Golden pegs will now be upgraded by <color=green>{increase}X"; }
            if (chineseLanguage == true) { bucketAndGoldIncreaseString = $"奖励：黄金彩钉现在将升级<color=green>{increase}</color>倍"; }
            if (japaneseLanguage == true) { bucketAndGoldIncreaseString = $"報酬：ゴールドペグが<color=green>{increase}</color>倍にアップグレード"; }
            if (koreanLanguage == true) { bucketAndGoldIncreaseString = $"보상: 황금 구슬이 <color=green>{increase}</color>배 업그레이드 됩니다. "; }
            if (russianLanguage == true) { bucketAndGoldIncreaseString = $"Награда: улучшение золотых колышков на <color=green>{increase}X</color>"; }
            if (germanLanguage == true) { bucketAndGoldIncreaseString = $"Belohnung: Gold-Pegs werden jetzt um <color=green>{increase}X</color> aufgewertet"; }
            if (frenchLanguage == true) { bucketAndGoldIncreaseString = $"<size=10.2>Récompense : Les pions dorés seront désormais améliorés par <color=green>{increase}X</color>"; }
            if (spanishLanguage == true) { bucketAndGoldIncreaseString = $"<size=11>Recompensa: Los pegs dorados ahora se mejorarán en <color=green>{increase}X</color>"; }
        }
        else
        {
            if (englishLanguage == true) { bucketAndGoldIncreaseString = $"Reward: Bucket will now be upgraded by <color=green>{increase}X"; }
            if (chineseLanguage == true) { bucketAndGoldIncreaseString = $"奖励：桶现在将升级<color=green>{increase}</color>倍"; }
            if (japaneseLanguage == true) { bucketAndGoldIncreaseString = $"報酬：バケツが<color=green>{increase}</color>倍になる。"; }
            if (koreanLanguage == true) { bucketAndGoldIncreaseString = $"보상: 통이 <color=green>{increase}</color>배 업그레이드 됩니다. "; }
            if (russianLanguage == true) { bucketAndGoldIncreaseString = $"Награда: улучшение корзины на <color=green>{increase}X</color>"; }
            if (germanLanguage == true) { bucketAndGoldIncreaseString = $"Belohnung: Korb wird jetzt um <color=green>{increase}X</color> aufgewertet"; }
            if (frenchLanguage == true) { bucketAndGoldIncreaseString = $"<size=10.2>Récompense : Les paniers seront désormais améliorés par <color=green>{increase}X</color>"; }
            if (spanishLanguage == true) { bucketAndGoldIncreaseString = $"<size=11>Recompensa: El cubo ahora se mejorará en <color=green>{increase}X</color>"; }
        }
    }
    #endregion


    //Ach text - NEW
    #region Change ACH
    public void ChangeACHText(int ACH, int achRQ, double gold)
    {
        if(ACH < 5)
        {
            //Chall ach
            if (englishLanguage == true) { achString = $"Complete {achRQ} challenges"; }
            if (chineseLanguage == true) { achString = $"完成{achRQ}个挑战"; }
            if (japaneseLanguage == true) { achString = $"{achRQ}つのチャレンジを完了する"; }
            if (koreanLanguage == true) { achString = $"{achRQ}개의 도전 과제 완료하기 "; }
            if (russianLanguage == true) { achString = $"Выполните {achRQ} заданий"; }
            if (germanLanguage == true) { achString = $"Schließe {achRQ} Herausforderungen ab"; }
            if (frenchLanguage == true) { achString = $"Terminer {achRQ} défis"; }
            if (spanishLanguage == true) { achString = $"Completa {achRQ} desafíos."; }
        }
        else if (ACH < 15)
        {
            //gold gain ach
            if (englishLanguage == true) { achString = $"Have a total of {SetHighNumbers.FormatCoinsGoldShort(gold)} gold"; }
            if (chineseLanguage == true) { achString = $"总共拥有{SetHighNumbers.FormatCoinsGoldShort(gold)}金币"; }
            if (japaneseLanguage == true) { achString = $"合計{SetHighNumbers.FormatCoinsGoldShort(gold)}万ゴールドを獲得する"; }
            if (koreanLanguage == true) { achString = $"총 {SetHighNumbers.FormatCoinsGoldShort(gold)} 황금 가지기"; }
            if (russianLanguage == true) { achString = $"Получите {SetHighNumbers.FormatCoinsGoldShort(gold)} золота"; }
            if (germanLanguage == true) { achString = $"Sammle insgesamt {SetHighNumbers.FormatCoinsGoldShort(gold)} Gold"; }
            if (frenchLanguage == true) { achString = $"Posséder un total de {SetHighNumbers.FormatCoinsGoldShort(gold)} d'or"; }
            if (spanishLanguage == true) { achString = $"Ten un total de {SetHighNumbers.FormatCoinsGoldShort(gold)} de oro."; }
        }
        else if (ACH < 18)
        {
            if (englishLanguage == true) { achString = $"Hit a total of {SetHighNumbers.FormatCoinsGoldShort(achRQ)} pegs"; }
            if (chineseLanguage == true) { achString = $"击中总共{SetHighNumbers.FormatCoinsGoldShort(achRQ)}个彩钉"; }
            if (japaneseLanguage == true) { achString = $"ペグを合計{SetHighNumbers.FormatCoinsGoldShort(achRQ)}本打つ"; }
            if (koreanLanguage == true) { achString = $"총 구슬 {SetHighNumbers.FormatCoinsGoldShort(achRQ)}개 명중하기 "; }
            if (russianLanguage == true) { achString = $"Попадите в {SetHighNumbers.FormatCoinsGoldShort(achRQ)} колышков"; }
            if (germanLanguage == true) { achString = $"Triff insgesamt {SetHighNumbers.FormatCoinsGoldShort(achRQ)} Pegs"; }
            if (frenchLanguage == true) { achString = $"Toucher un total de {SetHighNumbers.FormatCoinsGoldShort(achRQ)} pions "; }
            if (spanishLanguage == true) { achString = $"Golpea un total de {SetHighNumbers.FormatCoinsGoldShort(achRQ)} pegs."; }
        }
        else if (ACH < 20)
        {
            if (englishLanguage == true) { achString = $"Hit {achRQ} red pegs"; }
            if (chineseLanguage == true) { achString = $"击中{achRQ}个红色彩钉"; }
            if (japaneseLanguage == true) { achString = $"赤ペグを{achRQ}回打つ"; }
            if (koreanLanguage == true) { achString = $"빨간 구슬 {achRQ}개 명중하기 "; }
            if (russianLanguage == true) { achString = $"Попадите в {achRQ} красных колышков"; }
            if (germanLanguage == true) { achString = $"Triff {achRQ} rote Pegs"; }
            if (frenchLanguage == true) { achString = $"Toucher {achRQ} pions rouges"; }
            if (spanishLanguage == true) { achString = $"Golpea {achRQ} pegs rojos."; }
        }
        else if (ACH < 22)
        {
            if (englishLanguage == true) { achString = $"Hit {achRQ} rainbow pegs"; }
            if (chineseLanguage == true) { achString = $"击中{achRQ}个彩虹彩钉"; }
            if (japaneseLanguage == true) { achString = $"レインボーペグを{achRQ}回打つ"; }
            if (koreanLanguage == true) { achString = $"무지개 구슬 {achRQ}개 명중하기 "; }
            if (russianLanguage == true) { achString = $"Попадите в {achRQ} радужных колышков"; }
            if (germanLanguage == true) { achString = $"Triff {achRQ} Regenbogen-Pegs"; }
            if (frenchLanguage == true) { achString = $"Toucher {achRQ} pions arc-en-ciel"; }
            if (spanishLanguage == true) { achString = $"Golpea {achRQ} pegs arcoíris."; }
        }
        else if (ACH < 24)
        {
            if (englishLanguage == true) { achString = $"Hit {achRQ} bomb pegs"; }
            if (chineseLanguage == true) { achString = $"击中{achRQ}个炸弹彩钉"; }
            if (japaneseLanguage == true) { achString = $"ボムペグを{achRQ}回打つ"; }
            if (koreanLanguage == true) { achString = $"폭탄 구슬 {achRQ}개 명중하기 "; }
            if (russianLanguage == true) { achString = $"Попадите в {achRQ} бомбовых колышков"; }
            if (germanLanguage == true) { achString = $"Triff {achRQ} Schrapnell-Pegs"; }
            if (frenchLanguage == true) { achString = $"Toucher {achRQ} pions bombe"; }
            if (spanishLanguage == true) { achString = $"Golpea {achRQ} pegs bomba."; }
        }
        else if (ACH < 26)
        {
            if (englishLanguage == true) { achString = $"Hit {achRQ} purple pegs"; }
            if (chineseLanguage == true) { achString = $"击中{achRQ}个紫色彩钉"; }
            if (japaneseLanguage == true) { achString = $"紫のペグを{achRQ}回打つ"; }
            if (koreanLanguage == true) { achString = $"보라 구슬 {achRQ}개 명중하기 "; }
            if (russianLanguage == true) { achString = $"Попадите в {achRQ} фиолетовых колышков"; }
            if (germanLanguage == true) { achString = $"Triff {achRQ} violette Pegs"; }
            if (frenchLanguage == true) { achString = $"Toucher {achRQ} pions violets"; }
            if (spanishLanguage == true) { achString = $"Golpea {achRQ} pegs morados."; }
        }
        else if (ACH < 33)
        {
            if (englishLanguage == true) { achString = $"Purchase {achRQ} new balls"; }
            if (chineseLanguage == true) { achString = $"购买{achRQ}个新弹珠"; }
            if (japaneseLanguage == true) { achString = $"新しいボールを{achRQ}個購入する"; }
            if (koreanLanguage == true) { achString = $"새로운 공 {achRQ}개 구매하기 "; }
            if (russianLanguage == true) { achString = $"Купите {achRQ} новых шаров"; }
            if (germanLanguage == true) { achString = $"Kaufe {achRQ} neue Bälle"; }
            if (frenchLanguage == true) { achString = $"Acheter {achRQ} nouvelles balles"; }
            if (spanishLanguage == true) { achString = $"Compra {achRQ} nuevas bolas."; }
        }
        else if (ACH < 42)
        {
            if (englishLanguage == true) { achString = $"Unlock level {achRQ}"; }
            if (chineseLanguage == true) { achString = $"解锁第{achRQ}级"; }
            if (japaneseLanguage == true) { achString = $"レベル{achRQ}のロックを解除する"; }
            if (koreanLanguage == true) { achString = $"레벨 {achRQ} 잠금해제 하기 "; }
            if (russianLanguage == true) { achString = $"Разблокируйте {achRQ}-й уровень"; }
            if (germanLanguage == true) { achString = $"Schalte Level {achRQ} frei"; }
            if (frenchLanguage == true) { achString = $"Débloquer le niveau {achRQ} "; }
            if (spanishLanguage == true) { achString = $"Desbloquea el nivel {achRQ}."; }
        }
        else if (ACH < 47)
        {
            if (englishLanguage == true) { achString = $"Have a total of {SetHighNumbers.FormatCoinsGoldShort(achRQ)} prestige points"; }
            if (chineseLanguage == true) { achString = $"总共拥有{SetHighNumbers.FormatCoinsGoldShort(achRQ)}点威望分"; }
            if (japaneseLanguage == true) { achString = $"プレステージポイントを合計{SetHighNumbers.FormatCoinsGoldShort(achRQ)}ポイントにする"; }
            if (koreanLanguage == true) { achString = $"총 {SetHighNumbers.FormatCoinsGoldShort(achRQ)} 프레스티지 포인트 갖기 "; }
            if (russianLanguage == true) { achString = $"Получите {SetHighNumbers.FormatCoinsGoldShort(achRQ)} очков престижа"; }
            if (germanLanguage == true) { achString = $"Erreiche insgesamt {SetHighNumbers.FormatCoinsGoldShort(achRQ)} Prestigepunkte"; }
            if (frenchLanguage == true) { achString = $"Posséder un total de {SetHighNumbers.FormatCoinsGoldShort(achRQ)} points prestiges"; }
            if (spanishLanguage == true) { achString = $"Ten un total de {SetHighNumbers.FormatCoinsGoldShort(achRQ)} puntos de prestigio."; }
        }
        else if (ACH < 50)
        {
            if (englishLanguage == true) { achString = $"Shoot {achRQ} balls"; }
            if (chineseLanguage == true) { achString = $"射出{achRQ}个弹珠"; }
            if (japaneseLanguage == true) { achString = $"ボールを{achRQ}個撃つ"; }
            if (koreanLanguage == true) { achString = $"공 {achRQ}개 발사하기 "; }
            if (russianLanguage == true) { achString = $"Запустите {achRQ} шаров"; }
            if (germanLanguage == true) { achString = $"Schieße {achRQ} Bälle"; }
            if (frenchLanguage == true) { achString = $"Tirer {achRQ} balles"; }
            if (spanishLanguage == true) { achString = $"Dispara {achRQ} bolas."; }
        }
        else if (ACH < 55)
        {
            if (englishLanguage == true) { achString = $"Drop {SetHighNumbers.FormatCoinsGoldShort(achRQ)} balls"; }
            if (chineseLanguage == true) { achString = $"掉落{SetHighNumbers.FormatCoinsGoldShort(achRQ)}个弹珠"; }
            if (japaneseLanguage == true) { achString = $"ボールを{SetHighNumbers.FormatCoinsGoldShort(achRQ)}個落とす"; }
            if (koreanLanguage == true) { achString = $"공 {SetHighNumbers.FormatCoinsGoldShort(achRQ)}개 투하하기 "; }
            if (russianLanguage == true) { achString = $"Сбросьте {SetHighNumbers.FormatCoinsGoldShort(achRQ)} шаров"; }
            if (germanLanguage == true) { achString = $"Verliere {SetHighNumbers.FormatCoinsGoldShort(achRQ)} Bälle"; }
            if (frenchLanguage == true) { achString = $"Lâchez {SetHighNumbers.FormatCoinsGoldShort(achRQ)} balles"; }
            if (spanishLanguage == true) { achString = $"Deja caer {SetHighNumbers.FormatCoinsGoldShort(achRQ)} bolas."; }
        }
        else if (ACH < 64)
        {
            if (englishLanguage == true) { achString = $"Purchase {achRQ} prestige upgrades"; }
            if (chineseLanguage == true) { achString = $"购买{achRQ}个威望升级"; }
            if (japaneseLanguage == true) { achString = $"プレステージアップグレードを{achRQ}つ購入する"; }
            if (koreanLanguage == true) { achString = $"{achRQ}번의 프레스티지 업그레이드 구매하기 "; }
            if (russianLanguage == true) { achString = $"Купите {achRQ} улучшений престижа"; }
            if (germanLanguage == true) { achString = $"Kaufe {achRQ} Prestige-Upgrades"; }
            if (frenchLanguage == true) { achString = $"Acheter {achRQ} améliorations de prestige"; }
            if (spanishLanguage == true) { achString = $"Compra {achRQ} mejoras de prestigio."; }
        }
        else if (ACH < 68)
        {
            if (englishLanguage == true) { achString = $"Shoot {achRQ} balls at once"; }
            if (chineseLanguage == true) { achString = $"一次射出{achRQ}个弹珠"; }
            if (japaneseLanguage == true) { achString = $"一度にボール{achRQ}個を撃つ"; }
            if (koreanLanguage == true) { achString = $"한 번에 공 {achRQ}개 발사하기 "; }
            if (russianLanguage == true) { achString = $"Запустите {achRQ} шара сразу"; }
            if (germanLanguage == true) { achString = $"Schieße {achRQ} Bälle auf einmal ab"; }
            if (frenchLanguage == true) { achString = $"Tirer {achRQ} balles en même temps"; }
            if (spanishLanguage == true) { achString = $"Dispara {achRQ} bolas a la vez."; }
        }
        else if (ACH < 71)
        {
            if (englishLanguage == true) { achString = $"Clear the board {achRQ} times"; }
            if (chineseLanguage == true) { achString = $"清除游戏盘{achRQ}次"; }
            if (japaneseLanguage == true) { achString = $"ボードを{achRQ}回クリア"; }
            if (koreanLanguage == true) { achString = $"보드 {achRQ}번 통과하기 "; }
            if (russianLanguage == true) { achString = $"Очистите доску {achRQ} раз"; }
            if (germanLanguage == true) { achString = $"Räume {achRQ} Mal das Spielfeld ab"; }
            if (frenchLanguage == true) { achString = $"Vider le plateau {achRQ} fois"; }
            if (spanishLanguage == true) { achString = $"Limpia el tablero {achRQ} veces."; }
        }
        else if (ACH < 74)
        {
            if (englishLanguage == true) { achString = $"Fully charge the shooter {achRQ} times"; }
            if (chineseLanguage == true) { achString = $"完全充能发射器{achRQ}次"; }
            if (japaneseLanguage == true) { achString = $"シューターを{achRQ}回フルチャージする"; }
            if (koreanLanguage == true) { achString = $"공 쏘는 기계 {achRQ}번 완전 충전하기 "; }
            if (russianLanguage == true) { achString = $"Полностью зарядите пушку {achRQ} раз"; }
            if (germanLanguage == true) { achString = $"Lade den Shooter {achRQ}-mal vollständig auf"; }
            if (frenchLanguage == true) { achString = $"Charger complètement le lanceur {achRQ} fois"; }
            if (spanishLanguage == true) { achString = $"Carga completamente el lanzador {achRQ} veces."; }
        }
    }
    #endregion


    #region Change Charge percent and balls shot
    public void SetChargePercentAndBallShot(float chargeAmount, int balls)
    {
        if (englishLanguage == true) { chargedUpAmountString = $"<color=green>{chargeAmount.ToString("F0")}%</color> Charged up"; }
        if (chineseLanguage == true) { chargedUpAmountString = $"<color=green>{chargeAmount.ToString("F0")}%</color>充能！"; }
        if (japaneseLanguage == true) { chargedUpAmountString = $"<color=green>{chargeAmount.ToString("F0")}%</color>チャージアップ!"; }
        if (koreanLanguage == true) { chargedUpAmountString = $"<color=green>{chargeAmount.ToString("F0")}%</color>충전! "; }
        if (russianLanguage == true) { chargedUpAmountString = $"<color=green>{chargeAmount.ToString("F0")}%</color> заряда!"; }
        if (germanLanguage == true) { chargedUpAmountString = $"<color=green>{chargeAmount.ToString("F0")}% </color>aufgeladen!"; }
        if (frenchLanguage == true) { chargedUpAmountString = $"Rechargé à <color=green>{chargeAmount.ToString("F0")}% </color>!"; }
        if (spanishLanguage == true) { chargedUpAmountString = $"<color=green>{chargeAmount.ToString("F0")}%</color> Cargado!"; }

        if (englishLanguage == true) { ballsShotString = $"<color=green>{balls}</color> balls will be shot in a rapid succession once the shooter is fully charged"; }
        if (chineseLanguage == true) { ballsShotString = $"<color=green>{balls}</color>个弹珠将在发射器充能满后快速连续发射。"; }
        if (japaneseLanguage == true) { ballsShotString = $"チャージが完了すると<color=green>{balls}</color>発の連射が行われます"; }
        if (koreanLanguage == true) { ballsShotString = $"공을 쏘는 기계가 완전히 충전되면,<color=green>{balls}</color>개의 공이 빠르게 연속 발사됩니다 "; }
        if (russianLanguage == true) { ballsShotString = $"После полной зарядки стрелка будет выпущено <color=green>{balls}</color> шаров в быстрой последовательности"; }
        if (germanLanguage == true) { ballsShotString = $"Sobald das Ballgeschoss voll aufgeladen ist, werden <color=green>{balls}</color> Bälle in schneller Folge geschossen"; }
        if (frenchLanguage == true) { ballsShotString = $"Lorsque le lanceur est complètement chargé, <color=green>{balls}</color> balles seront tirées successivement à grande vitesse."; }
        if (spanishLanguage == true) { ballsShotString = $"Se dispararán <color=green>{balls}</color> bolas en rápida sucesión una vez que el tirador esté completamente cargado"; }
    }
    #endregion

    //New
    #region All ball hover text 
    public void SetBallDesText()
    {
        if (englishLanguage == true)
        {
            #region Balls Descriptions
            regularBallDesString = "*Regular balls shot will be returned upon entering the bucket or falling into the pit.";
            bouncyBallDesString = "*Bouncy balls are good for clearing out multiple pegs that are far away from each other";
            rockBallDesString = "*Rock balls are good for clearing out pegs that are close to each other.";
            bombBallDesString = $"*The bomb ball explodes into 4 small balls when it comes in contact with a peg. \n\n*Each small ball gives {BallUpgrades.tinyBallPercentTotal * 100}% of the bomb gold. \n\n*Shot bomb balls will be returned once the bomb ball or 4 small balls enteres the bucket or falls into the pit.";
            #endregion

            if (GameData.isDemo == false)
            {
                #region Ball descriptions
                //Ball descriptions
                aquaBallDesString = "*Aqua balls are similar to the regular balls!";

                mudBallDesString = "*Mud balls are similar to the regular balls!";

                basketBallDesString = $"*Whenever a basketball hits a peg, the ball gold gets increased by +{(BallUpgrades.basketBallBonus * 100).ToString("F0")}%. This gets reset upon landing in the bucket or the pit. Gold increase bonus is applied after all other gold increases are calculated.";
                plumBallDesString = "*Plum balls are similar to the regular balls!";

                stickyBallDesString = $"*Hitting golden pegs have a {BallUpgrades.stickyBallDoubleGoldChance}% chance to double the gold received.";

                candyBallDesString = "*Candy balls are similar to the regular balls!";

                cookieBallDesString = $"*If a cookie ball collides with a prestige peg, there is a {BallUpgrades.cookieDoubleChance}% chance to receive 2X prestige points.";

                limeBallDesString = "*Lime balls are similar to the regular balls!";

                goldBallDesString = $"*Golden balls have chances to receive more gold when colliding with golden pegs!\n\n*{BallUpgrades.goldBallDoubleChance}% Chance to receive double gold.\n\n*{BallUpgrades.goldBallTrippleChance}% Chance to receive triple gold.\n\n*{BallUpgrades.goldBall5XGold}% Chance to receive 5X gold.";

                footBallDesString = $"*Footballs give {(BallUpgrades.footBallBucketIncrease).ToString("F2")}X bonus gold from landing in the bucket.";

                sharpnelBallDesString = $"*Shrapnel balls have a {BallUpgrades.sharpnelChance1}% chance to spawn a tiny shrapnel ball whenever it hits a peg. It also has a {BallUpgrades.sharpnelChance2}% chance to spawn a tiny shrapnel ball when it collides with anything other than a peg.\n\n*Tiny shrapnel balls give {(BallUpgrades.smallSharpnelGold * 100).ToString("F0")}% of the shrapnels ball gold.";

                ringBallDesString = $"*Ring balls have a {BallUpgrades.ringBallSpawnChance}% chance to spawn another ring ball whenever it collides with anything other than a peg. \n\n*The spawned ring balls give {(BallUpgrades.spawnedRingGold * 100).ToString("F0")}% of the ring balls gold.";

                apricotBallDesString = "*Apricot balls are similar to the regular balls!";

                peggoBallDesString = $"*Purchasing the peggo balls will spawn prestige gems on the board, which only the peggo ball can hit.\n\n*Prestige gems gives 2X prestige points";

                ghostBallDesString = $"*Ghost balls passes through everything and can only land in the bucket. \n\n*For every ghost ball that is currently on screen, all balls get a +{(BallUpgrades.ghostBallGoldIncrease * 100).ToString("F0")}% gold increase. Gold increase bonus is applied after all other gold increases are calculated.";

                starBallDesString = $"*For every {BallUpgrades.starBallPegsHitNeeded} pegs the star balls hit, another star ball will spawn.\n\n*Spawned star balls will spawn exactly like auto-dropped balls.";

                rainbowBallDesString = $"*The rainbow ball gives a +{(BallUpgrades.rainbowBallGoldIncrease * 100).ToString("F0")}% gold increase to all balls every time it hits a peg. This will stack with multiple rainbow balls. Gold increase bonus is applied after all other gold increases are calculated.\n\n*The bonus from 1 rainbow ball is removed upon entering the bucket or the pit.";

                glitchyBallDesString = "*The glitchy ball contains the bonuses from all other balls.";
                #endregion
            }
        }
        else if (chineseLanguage == true)
        {
            #region Balls Descriptions
            regularBallDesString = "*普通弹珠发射后进入桶或落入坑中将被返回。";
            bouncyBallDesString = "*弹力弹珠适合清除彼此相距较远的多个彩钉。";
            rockBallDesString = "*岩石弹珠适合清除彼此相距较近的彩钉。";
            bombBallDesString = $"*炸弹弹珠与彩钉接触时会爆炸成4个小弹珠。\n\n*每个小弹珠给出炸弹金币的30%。\n\n*发射的炸弹弹珠将在炸弹弹珠或4个小弹珠进入桶或落入坑中时返回。";
            #endregion

            if (GameData.isDemo == false)
            {
                #region Ball descriptions
                //Ball descriptions
                aquaBallDesString = "*水弹珠与普通弹珠类似！";

                mudBallDesString = "*泥弹珠与普通弹珠类似！";

                basketBallDesString = $"*每当篮球弹珠击中一个彩钉时，弹珠的金币会增加+{(BallUpgrades.basketBallBonus * 100).ToString("F0")}%。当弹珠落入桶中或坑中时，这个加成会重置。金币增加奖励在计算所有其他金币增加后应用";

                plumBallDesString = "*梅花球与普通球类似！";

                stickyBallDesString = $"*击中金色彩钉有{BallUpgrades.stickyBallDoubleGoldChance}%的几率使获得的金币翻倍。";

                candyBallDesString = "*糖果弹珠与普通弹珠类似！";
                cookieBallDesString = $"*如果饼干弹珠与威望彩钉碰撞，有{BallUpgrades.cookieDoubleChance}%的几率获得2倍威望分。";

                limeBallDesString = "*青柠弹珠与普通弹珠类似！";

                goldBallDesString = $"*黄金弹珠在碰撞金色彩钉时有几率获得更多金币！\n\n*{BallUpgrades.goldBallDoubleChance}%的几率获得双倍金币，\n\n*{BallUpgrades.goldBallTrippleChance}%的几率获得三倍金币，\n\n*{BallUpgrades.goldBall5XGold}%的几率获得5倍金币。";

                footBallDesString = $"*足球弹珠在落入桶中时给予{(BallUpgrades.footBallBucketIncrease).ToString("F2")}倍的金币奖励。";

                sharpnelBallDesString = $"*弹片弹珠在击中彩钉时有{BallUpgrades.sharpnelChance1}%的几率生成一个小弹片弹珠。当它与非彩钉物体碰撞时也有{BallUpgrades.sharpnelChance2}%的几率生成一个小弹片弹珠。\n\n小弹片弹珠给予弹片弹珠金币的{(BallUpgrades.smallSharpnelGold * 100).ToString("F0")}%。";

                ringBallDesString = $"*环形弹珠在与非彩钉物体碰撞时有{BallUpgrades.ringBallSpawnChance}%的几率生成另一个环形弹珠。生成的环形弹珠给予环形弹珠金币的{(BallUpgrades.spawnedRingGold * 100).ToString("F0")}%。";

                apricotBallDesString = "*杏子弹珠与普通弹珠类似！";

                peggoBallDesString = $"*购买Peggo弹珠将会在游戏盘上生成威望宝石，且只有Peggo弹珠可以击中威望宝石。\n\n威望宝石给予2倍威望分。";

                ghostBallDesString = $"*鬼魂弹珠可以穿透一切，且只能落在桶中。\n\n每个当前屏幕上的鬼魂弹珠会使所有弹珠的金币增加+{(BallUpgrades.ghostBallGoldIncrease * 100).ToString("F0")}%。金币增加奖励在计算所有其他金币增加后应用。";

                starBallDesString = $"*每当星星弹珠击中{BallUpgrades.starBallPegsHitNeeded}个彩钉时，会生成另一个星星弹珠。生成的星星弹珠将像自动掉落的弹珠一样生成。";

                rainbowBallDesString = $"*彩虹弹珠每次击中彩钉时，所有弹珠的金币都会增加+{(BallUpgrades.rainbowBallGoldIncrease * 100).ToString("F0")}%，这会与多个彩虹弹珠迭加。\n\n金币增加奖励在计算所有其他金币增加后应用。一个彩虹弹珠的奖励在进入桶或坑后会被移除。";

                glitchyBallDesString = "*故障弹珠包含所有其他弹珠的奖励。";
                #endregion
            }
        }
        else if (koreanLanguage == true)
        {
            #region Balls Descriptions
            regularBallDesString = "*일반 공들은 통 또는 구덩이에 빠지자마자 다시 돌려받습니다.";
            bouncyBallDesString = "*탄력 공은 서로 멀리 떨어져 있는 여러 구슬들을 없애는데 탁월합니다. ";
            rockBallDesString = "*단단한 공은 서로 가까이 있는 구슬들을 없애는데 탁월합니다. ";
            bombBallDesString = $"*폭탄 공은 구슬과 부딪힐 때 4개의 작은 공들을 만들어냅니다.\n\n 각각의 작은 공은 {BallUpgrades.tinyBallPercentTotal * 100}%의 황금을 줄 것입니다. \n\n폭탄 공 또는 4개의 작은 공들이 통에 들어가거나 구덩이로 떨어질 때 다시 돌아오게 될 것입니다. ";
            #endregion

            if (GameData.isDemo == false)
            {
                #region Ball descriptions
                //Ball descriptions
                aquaBallDesString = "*아쿠아 공들은 일반 공들과 비슷합니다. ";

                mudBallDesString = "*진흙 공들은 일반 공들과 비슷합니다. ";

                basketBallDesString = $"*농구공이 구슬을 명중할 때마다, 공 황금은 +{(BallUpgrades.basketBallBonus * 100).ToString("F0")}%까지 높아집니다. 통 또는 구덩이로 떨어지면 초기화됩니다. 황금 증가 보너스는 모든 황금 증가가 계산되고난 후 적용될 것입니다. ";

                plumBallDesString = "*자두볼은 일반 공들과 비슷합니다. ";

                stickyBallDesString = $"*황금 구슬 명중은 받게될 황금을 2배로 늘려주는 확률을 {BallUpgrades.stickyBallDoubleGoldChance}% 가지고 있습니다. ";

                candyBallDesString = "*사탕 공들은 일반 공들과 비슷합니다. ";
                cookieBallDesString = $"*쿠키 공이 프레스티지 구슬과 충돌하면 2배의 프레스티지 포인트를 받을 수 있는 확률을 {BallUpgrades.cookieDoubleChance}% 가지게 됩니다. ";

                limeBallDesString = "*라임 공들은 일반 공들과 비슷합니다. ";

                goldBallDesString = $"*황금 공들이 황금 구슬들과 충돌할 때, 더 많은 황금을 받을 수 있는 확률을 갖게 될 것입니다! 두 배 황금을 받게 될 \n\n*{BallUpgrades.goldBallDoubleChance}%의 확률. 세 배 황금을 받게 될 \n\n*{BallUpgrades.goldBallTrippleChance}%의 확률. 다섯 배 황금을 받게 될 \n\n*{BallUpgrades.goldBall5XGold}%의 확률.  ";

                footBallDesString = $"*축구공은 통으로 떨어질 때 {(BallUpgrades.footBallBucketIncrease).ToString("F2")}배의 보너스 황금을 줍니다. ";

                sharpnelBallDesString = $"*파편 공들은 구슬을 명중할 때마다 작은 파편 공을 만들어낼 수 있는 확률을 {BallUpgrades.sharpnelChance1}%를 갖게 됩니다. 또한 구슬 외 다른 것과 충돌할 때, 작은 파편 공을 만들어낼 수 있는 확률을 {BallUpgrades.sharpnelChance2}%갖게 됩니다.  작은 파편 공들은 파편 공 황금의 {(BallUpgrades.smallSharpnelGold * 100).ToString("F0")}%를 줍니다. ";

                ringBallDesString = $"*반지 공들은 구슬 외 다른 것과 충돌할 때, 또 다른 반지 공을 만들어내는 확률을 {BallUpgrades.ringBallSpawnChance}% 갖게 됩니다. 생성된 반지 공은 반지 공 황금의 {(BallUpgrades.spawnedRingGold * 100).ToString("F0")}%를 줍니다. ";

                apricotBallDesString = "*살구 공들은 일반 공들과 비슷합니다. ";

                peggoBallDesString = $"*페고 공들을 구매하면 보드에 페고 공들만 명중할 수 있는 프레스티지 보석이 나타나게 됩니다. 프레스티지 보석은 2배의 프레스티지 포인트를 줍니다. ";

                ghostBallDesString = $"*귀신 공들은 모든 것을 피해 통으로만 들어갈 수 있습니다. 현재 화면에 있는 모든 귀신 공들에 있어, 모든 공들은 +{(BallUpgrades.ghostBallGoldIncrease * 100).ToString("F0")}% 황금 상승을 받게 됩니다. 황금 상승 보너스는 모든 다른 황금 상승들이 계산되고 난 후 적용될 것입니다. ";

                starBallDesString = $"*별 공이 명중하는 매 10개의 구슬마다, 또 다른 별 공이 나타날 것입니다. 생성된 별 공은 자동 투하되는 공들과 똑같이 나타납니다. ";

                rainbowBallDesString = $"*무지개 공이 하나의 구슬을 명중할 때마다 모든 공들에게 +{(BallUpgrades.rainbowBallGoldIncrease * 100).ToString("F0")}% 황금 상승을 제공합니다. 이는 여러 무지개 공들에 쌓일 것입니다. 황금 상승 보너스는 모든 다른 황금 상승이 계산되고 난 후 적용될 것입니다. 무지개 공 1개의 보너스는 통 또는 구덩이에 들어가면 없어지게 됩니다. ";

                glitchyBallDesString = "*글리치 공은 모든 다른 공에서의 바운스를 포함합니다. ";
                #endregion
            }
        }
        else if (japaneseLanguage == true)
        {
            #region Balls Descriptions
            regularBallDesString = "*通常のボールはバケツに入ったり、ピットに落ちると戻ってきます。";
            bouncyBallDesString = "*跳ね玉は離れた複数のペグを消すのに適しています。";
            rockBallDesString = "*ロックボールは近くにあるペグを消すのに適しています。";
            bombBallDesString = $"*ボム・ボールはペグに接触すると爆発して4つの小さなボールになります。\n\n*各小玉は爆弾の金貨の{BallUpgrades.tinyBallPercentTotal * 100}％を与えます。\n\n*発射したボム・ボールは、ボム・ボールか4つのスモールボールがバケツに入るか落とし穴に落ちると戻ってきます。";
            #endregion

            if (GameData.isDemo == false)
            {
                #region Ball descriptions
                //Ball descriptions
                aquaBallDesString = "*アクアボールは通常のボールと似ています！";

                mudBallDesString = "*マッドボールは通常のボールと似ています！";

                basketBallDesString = $"*バスケットボールがペグに当たるたびに、ボールのゴールドが+{(BallUpgrades.basketBallBonus * 100).ToString("F0")}%されます。これは、バケツや落とし穴に落ちるとリセットされます。ゴールド増加ボーナスは、他のすべてのゴールド増加が計算された後に適用されます。";

                plumBallDesString = "*プラムボールは通常のボールと似ています!";

                stickyBallDesString = $"*ゴールドペグに当たると、{BallUpgrades.stickyBallDoubleGoldChance}%の確率でゴールドが2倍になります。";

                candyBallDesString = "*キャンディーボールは通常のボールと似ています！";

                cookieBallDesString = $"*クッキーボールがプレステージペグにぶつかると、{BallUpgrades.cookieDoubleChance}%の確率でプレステージポイントが2倍になります。";

                limeBallDesString = "*ライムボールは通常のボールと似ています！";

                goldBallDesString = $"*ゴールドボールがゴールドペグに衝突すると、より多くのゴールドを獲得できるチャンスがあります！\n*{BallUpgrades.goldBallDoubleChance}%の確率でゴールドが2倍になります。\n*{BallUpgrades.goldBallTrippleChance}%の確率で3倍のゴールドがもらえます。\n*{BallUpgrades.goldBall5XGold}%の確率で5倍のゴールドがもらえます。";

                footBallDesString = $"*<size=11>フットボールはバケツに落ちると{(BallUpgrades.footBallBucketIncrease).ToString("F2")}倍のボーナスゴールドがもらえます。";

                sharpnelBallDesString = $"*シュラプネルボールは、ペグにぶつかるたびに{BallUpgrades.sharpnelChance1}%の確率で小さなシュラプネルボールが出現します。また、ペグ以外のものにぶつかると{BallUpgrades.sharpnelChance2}%の確率で小さなシュラプネルボールが出現します。小さなシュラプネルボールは、シュラプネルボールのゴールドの{(BallUpgrades.smallSharpnelGold * 100).ToString("F0")}%です。";

                ringBallDesString = $"*リングボールはペグ以外のものと衝突するたびに{BallUpgrades.ringBallSpawnChance}%の確率で別のリングボールをが出現します。出現したリングボールはリングボールのゴールドの{(BallUpgrades.spawnedRingGold * 100).ToString("F0")}%です。";

                apricotBallDesString = "*アプリコットボールは通常のボールと似ています！";

                peggoBallDesString = $"*ペゴボールを購入すると、ペゴボールだけが打つことのできるプレステージジェムがボード上に生まれます。プレステージ宝石はプレステージポイントを2倍にします。";

                ghostBallDesString = $"*ゴーストボールはすべてを通り抜け、バケツにしか到達しません。現在画面上にあるゴーストボール1個につき、すべてのボールのゴールドが+{(BallUpgrades.ghostBallGoldIncrease * 100).ToString("F0")}%増加します。ゴールド増加ボーナスは、他のすべてのゴールド増加が計算された後に適用されます。";

                starBallDesString = $"*スターボールが{BallUpgrades.starBallPegsHitNeeded}個のペグに当たるごとに、別のスターボールが出現します。ス出現したスターボールは、自動ドロップしたボールとまったく同じように出現します。";

                rainbowBallDesString = $"*レインボーボールはペグに当たるたびに、すべてのボールに+{(BallUpgrades.rainbowBallGoldIncrease * 100).ToString("F0")}%のゴールドを加算します。これは複数のレインボーボールと累計します。ゴールド増加のボーナスは、他のすべてのゴールド増加が計算された後に適用される。レインボーボール1個のボーナスは、バケツや落とし穴に入ると無効になります。";

                glitchyBallDesString = "*グリッチボールには、他のすべてのボールのボーナスが含まれています。";
                #endregion
            }
        }
        else if (spanishLanguage == true)
        {
            #region Balls Descriptions
            regularBallDesString = "*Las bolas normales disparadas se devolverán al entrar en el cubo o caer en el foso.";
            bouncyBallDesString = "*Las bolas saltarinas son buenas para eliminar varios pegs que están lejos unos de otros.";
            rockBallDesString = "*Las bolas de piedra son buenas para eliminar pegs que están cerca unos de otros.";
            bombBallDesString = $"*<size=11.5>La bola bomba explota en 4 bolas pequeñas cuando entra en contacto con un peg.\n\n *Cada bola pequeña da un {BallUpgrades.tinyBallPercentTotal * 100}% del oro de la bomba. \n\n*Las bolas bomba se devolverán cuando la bola bomba o las 4 bolas pequeñas entren en el cubo o caigan en el pozo.";
            #endregion

            if (GameData.isDemo == false)
            {
                #region Ball descriptions
                //Ball descriptions
                aquaBallDesString = "*¡Las bolas de agua son similares a las bolas regulares!";

                mudBallDesString = "*¡Las bolas de lodo son similares a las bolas regulares!";

                basketBallDesString = $"*<size=11.5>Cada vez que una bola de baloncesto golpea un peg, el oro de la bola aumenta en un +{(BallUpgrades.basketBallBonus * 100).ToString("F0")}%. Esto se reinicia al aterrizar en el cubo o en el hoyo. La bonificación de aumento de oro se aplica después de que se calculen todos los demás aumentos de oro.";

                plumBallDesString = "*¡Las bolas de ciruela son similares a las bolas regulares!";

                stickyBallDesString = $"*<size=12>Golpear pegs dorados tiene un {BallUpgrades.stickyBallDoubleGoldChance}% de probabilidad de duplicar el oro recibido.";

                candyBallDesString = "*¡Las bolas de caramelo son similares a las bolas regulares!";

                cookieBallDesString = $"*<size=12>Si una bola de galleta choca con un peg de prestigio, hay un {BallUpgrades.cookieDoubleChance}% de probabilidad de recibir 2X puntos de prestigio.";

                limeBallDesString = "*¡Las bolas de lima son similares a las bolas regulares!";

                goldBallDesString = $"*<size=11>Las bolas doradas tienen probabilidades de recibir más oro al chocar con pegs dorados. \n\n*{BallUpgrades.goldBallDoubleChance}% de probabilidad de recibir doble oro. \n\n*{BallUpgrades.goldBallTrippleChance}% de probabilidad de recibir triple oro. \n\n*{BallUpgrades.goldBall5XGold}% de probabilidad de recibir 5X oro.";

                footBallDesString = $"*Las bolas de fútbol otorgan un {(BallUpgrades.footBallBucketIncrease).ToString("F2")}X de bono de oro al aterrizar en el cubo.";

                sharpnelBallDesString = $"*<size=11.5>Las bolas de esquirlas tienen un {BallUpgrades.sharpnelChance1}% de probabilidad de generar una bola de esquirlas diminuta cada vez que golpean un peg. También tienen un {BallUpgrades.sharpnelChance2}% de probabilidad de generar una bola de esquirlas diminuta cuando chocan con cualquier cosa que no sea un peg. Las bolas de esquirlas diminutas otorgan el {(BallUpgrades.smallSharpnelGold * 100).ToString("F0")}% del oro de las bolas de esquirlas.";

                ringBallDesString = $"*Las bolas de aro tienen un {BallUpgrades.ringBallSpawnChance}% de probabilidad de generar otra bola de aro cada vez que chocan con cualquier cosa que no sea un peg. Las bolas de aro generadas otorgan el {(BallUpgrades.spawnedRingGold * 100).ToString("F0")}% del oro de las bolas de aro.";

                apricotBallDesString = "*¡Las bolas de albaricoque son similares a las bolas regulares!";

                peggoBallDesString = $"*<size=14>Comprar las bolas peggo generará gemas de prestigio en el tablero, que solo la bola peggo puede golpear. Las gemas de prestigio otorgan 2X puntos de prestigio.";

                ghostBallDesString = $"*Las bolas fantasma atraviesan todo y solo pueden aterrizar en el cubo. Por cada bola fantasma que esté en pantalla, todas las bolas reciben un aumento de oro de +{(BallUpgrades.ghostBallGoldIncrease * 100).ToString("F0")}%. La bonificación de aumento de oro se aplica después de que se calculen todos los demás aumentos de oro.";

                starBallDesString = $"*Por cada {BallUpgrades.starBallPegsHitNeeded} pegs que golpeen las bolas estrella, se generará otra bola estrella. Las bolas estrella generadas se generarán exactamente como las bolas caídas automáticamente.";

                rainbowBallDesString = $"*La bola arcoíris otorga un aumento de oro de +{(BallUpgrades.rainbowBallGoldIncrease * 100).ToString("F0")}% a todas las bolas cada vez que golpea un peg. Esto se acumulará con múltiples bolas arcoíris. La bonificación de aumento de oro se aplica después de que se calculen todos los demás aumentos de oro. La bonificación de 1 bola arcoíris se elimina al entrar en el cubo o en el hoyo.";

                glitchyBallDesString = "*<size=12.5>La bola glitchy contiene las bonificaciones de todas las demás bolas.";
                #endregion
            }

        }
        else if (germanLanguage == true)
        {
            #region Balls Descriptions
            regularBallDesString = "*Regulär geschossene Bälle werden zurückgegeben, wenn sie in den Eimer oder in den Abgrund fallen.";
            bouncyBallDesString = "*Flummibälle sind gut geeignet, um mehrere, weit voneinander entfernte Pflöcke auszuräumen.";
            rockBallDesString = "*Murmeln sind gut geeignet, um nahe beieinander liegende Pegs auszuräumen.";
            bombBallDesString = $"*Das Schrapnell explodiert in 4 kleine Kugeln, wenn es mit einem Peg in Berührung kommt.\n\n Jede kleine Kugel gibt 30% des Schrapnellgoldes.\n\n Geschossene Schrapnelle werden zurückgegeben, wenn das Schrapnell oder 4 kleine Splitterkugeln in den Eimer oder in den Abgrund fallen.";
            #endregion

            if (GameData.isDemo == false)
            {
                #region Ball descriptions
                //Ball descriptions
                aquaBallDesString = "*Wasserbälle sind den normalen Bällen ähnlich!";

                mudBallDesString = "*Schlammbälle sind den normalen Bällen ähnlich!";

                basketBallDesString = $"*<size=11.5>Jedes Mal, wenn ein Basketball einen Peg trifft, wird das Ballgold um +{(BallUpgrades.basketBallBonus * 100).ToString("F0")}% erhöht. Diese Erhöhung wird zurückgesetzt, wenn der Ball im Korb oder im Abgrund landet. Der Goldzuwachsbonus wird nach der Berechnung aller anderen Goldzuwächse angewandt.";

                plumBallDesString = "*Pflaumenbällchen sind den normalen Bällen ähnlich!";

                stickyBallDesString = $"*Wenn du Gold-Pegs triffst, besteht eine Chance von {BallUpgrades.stickyBallDoubleGoldChance}%, dass sich das erhaltene Gold verdoppelt.";

                candyBallDesString = "*Candy-Bälle sind den normalen Bällen ähnlich!";
                cookieBallDesString = $"*Wenn ein Keksball mit einem Prestige-Peg kollidiert, besteht eine Chance von {BallUpgrades.cookieDoubleChance}%, 2x Prestigepunkte zu erhalten.";

                limeBallDesString = "*Limettenbälle sind den normalen Bällen ähnlich!";

                goldBallDesString = $"*Goldene Bälle haben die Chance, mehr Gold zu erhalten, wenn sie mit Gold-Pegs kollidieren! \n\n*{BallUpgrades.goldBallDoubleChance}% Chance auf 2x Gold. \n\n*{BallUpgrades.goldBallTrippleChance}% Chance auf 3x Gold. \n\n*{BallUpgrades.goldBall5XGold}% Chance auf 5x Gold.";

                footBallDesString = $"*Fußbälle geben {(BallUpgrades.footBallBucketIncrease).ToString("F2")}X Bonusgold, wenn sie im Korb landen.";

                sharpnelBallDesString = $"*<size=11.5>Schrapnellbälle haben eine Chance von {BallUpgrades.sharpnelChance1}%, einen kleinen Schrapnellsplitter zu erzeugen, wenn sie einen Peg treffen. Außerdem besteht eine Chance von {BallUpgrades.sharpnelChance2}%, dass ein Schrapnellsplitter entsteht, wenn er mit einem anderen Gegenstand als einem Peg zusammenstößt. Winzige Schrapnellsplitter geben {(BallUpgrades.smallSharpnelGold * 100).ToString("F0")}% des Schrapnellballgoldes.";

                ringBallDesString = $"*Ringbälle haben eine Chance von {BallUpgrades.ringBallSpawnChance}%, einen weiteren Ringball zu erzeugen, wenn sie mit etwas anderem als einem Peg kollidieren. Die gespawnten Ringbälle geben {(BallUpgrades.spawnedRingGold * 100).ToString("F0")}% des Ringballgoldes.";

                apricotBallDesString = "*Aprikosenbälle sind den normalen Bällen ähnlich!";

                peggoBallDesString = $"*<size=13>Wenn du die Peggo-Bälle kaufst, werden Prestige-Edelsteine auf dem Spielfeld erscheinen, die nur der Peggo-Ball treffen kann. Prestige-Edelsteine geben 2x Prestigepunkte";

                ghostBallDesString = $"*Geisterbälle gehen durch alles hindurch und können nur im Korb landen. Für jeden Geisterball, der sich gerade auf dem Bildschirm befindet, erhalten alle Bälle einen Goldzuwachs von +{(BallUpgrades.ghostBallGoldIncrease * 100).ToString("F0")}%. Der Goldzuwachsbonus wird angewendet, nachdem alle anderen Goldzuwächse berechnet wurden.";

                starBallDesString = $"*Für je {BallUpgrades.starBallPegsHitNeeded} Pegs, die der Sternball trifft, wird ein weiterer Sternball erzeugt. Gespawnte Sternbälle spawnen genauso wie automatisch gedroppte Bälle.";

                rainbowBallDesString = $"*Der Regenbogenball gibt allen Bällen einen Goldzuwachs von +{(BallUpgrades.rainbowBallGoldIncrease * 100).ToString("F0")}%, wenn er einen Peg trifft. Dieser Bonus ist bei mehreren Regenbogenbällen stapelbar. Der Goldzuwachsbonus wird angewendet, nachdem alle anderen Goldzuwächse berechnet wurden. Der Bonus von 1 Regenbogenball wird beim treffen des Korbs oder des Abgrunds entfernt.";

                glitchyBallDesString = "*Der Glitch-Ball enthält die Boni von allen anderen Bällen.";
                #endregion
            }
        }
        else if (russianLanguage == true)
        {
            #region Balls Descriptions
            regularBallDesString = "*Обычные выпущенные шары при попадании в корзину или падении в яму возвращаются обратно.";
            bouncyBallDesString = "*Надувные шары помогают выбить несколько колышков, расположенных на большом расстоянии друг от друга.";
            rockBallDesString = "*Каменные шары хорошо подходят для выбивания колышков, расположенных близко друг к другу.";
            bombBallDesString = $"*Шар-бомба при соприкосновении с колышком разрывается на 4 маленьких шарика.\n\n *Каждый маленький шарик дает {BallUpgrades.tinyBallPercentTotal * 100}% золота от стоимости шара-бомбы.\n\n *Выстрел шарами-бомбами будет возвращен, как только шар-бомба или 4 маленьких шарика попадут в корзину или упадут в яму.";
            #endregion

            if (GameData.isDemo == false)
            {
                #region Ball descriptions
                //Ball descriptions
                aquaBallDesString = "*Водяные шары похожи на обычные!";

                mudBallDesString = "*Грязевые шары похожи на обычные!";

                basketBallDesString = $"*При ударе баскетбольного мяча о колышек, золото мяча повышается на {(BallUpgrades.basketBallBonus * 100).ToString("F0")}%. Это значение сбрасывается при попадании в корзину или яму. Бонус прироста золота применяется после расчета всех прочих приростов золота.";

                plumBallDesString = "*Сливовые шары похожи на обычные!";

                stickyBallDesString = $"*Удар о золотой колышек имеет {BallUpgrades.stickyBallDoubleGoldChance}% шанс на удвоение золота.";

                candyBallDesString = "*Шары-конфеты похожи на обычные!";

                cookieBallDesString = $"*Удар шара-печенья о колышек престижа имеет {BallUpgrades.cookieDoubleChance}% шанс на 2X очков престижа.";

                limeBallDesString = "*Шары-лаймы похожи на обычные!";

                goldBallDesString = $"*У золотых шаров есть шанс получить больше золота при ударе о золотые колышки! \n\n*{BallUpgrades.goldBallDoubleChance}% шанс на удвоение золота. \n\n*{BallUpgrades.goldBallTrippleChance}% шанс на утроение золота. \n\n*{BallUpgrades.goldBall5XGold}% шанс на 5Х золота.";

                footBallDesString = $"*Футбольные мячи дают {(BallUpgrades.footBallBucketIncrease).ToString("F2")}X золота за попадание в корзину.";

                sharpnelBallDesString = $"*У осколочных шаров есть {BallUpgrades.sharpnelChance1}% шанс на мини осколочный шар при ударе о колышек. Также есть {BallUpgrades.sharpnelChance2}% шанс на мини осколочный шар при ударе о что-либо, кроме колышка. Мини осколочные шары дают {(BallUpgrades.smallSharpnelGold * 100).ToString("F0")}% золота от осколочного шара.";

                ringBallDesString = $"*Шары-кольца имеют {BallUpgrades.ringBallSpawnChance}% шанс на еще один шар-кольцо при ударе о что-либо, кроме колышка. Полученные шары-кольца дают {(BallUpgrades.spawnedRingGold * 100).ToString("F0")}% золота от шара-кольца.";

                apricotBallDesString = "*Шары-абрикосы похожи на обычные!";

                peggoBallDesString = $"*При покупке шаров-колышков, на доске появляются камни престижа, которые можно сбить только шаром-колышком. Камни престижа дают 2X очков престижа";

                ghostBallDesString = $"*Шары-призраки проходят сквозь все и могут попасть только в корзину. За каждый шар-призрак на экране, все шары получат +{(BallUpgrades.ghostBallGoldIncrease * 100).ToString("F0")}% к золоту. Бонус прироста золота применяется после расчета всех прочих приростов золота.";

                starBallDesString = $"*За каждые {BallUpgrades.starBallPegsHitNeeded} ударов звездных шаров о колышки дается еще один звездный шар. Звездные шары появляются так же, как и автоматически сброшенные шары.";

                rainbowBallDesString = $"*Радужный шар дает +{(BallUpgrades.rainbowBallGoldIncrease * 100).ToString("F0")}% золота ко всем шарам, попадающим в колышек. Этот бонус суммируется от нескольких радужных шаров. Бонус прироста золота применяется после расчета всех прочих приростов золота. Бонус от 1 радужного шара снимается при попадании в корзину или яму.";

                glitchyBallDesString = "*Глючный шар содержит бонусы от всех прочих шаров.";
                #endregion
            }
        }
        else if (frenchLanguage == true)
        {
            #region Balls Descriptions
            regularBallDesString = "*Les balles ordinaires seront récupérées une fois qu'elles auront atteint le panier ou tombé dans le trou.";
            bouncyBallDesString = "*Les balles rebondissantes sont idéales pour éliminer plusieurs pions éloignés les uns des autres. ";
            rockBallDesString = "*Les balles de pierre sont efficaces pour éliminer les pions qui sont proches les uns des autres.";
            bombBallDesString = $"*La balle-bombe explose en 4 petites balles lorsqu'elle entre en contact avec un pion. Chaque petite balle rapporte 30% de l'or dans la bombe. Les balles-bombe seront récupérées une fois qu'elles auront atteint le panier ou tombé dans le trou. ";
            #endregion

            if (GameData.isDemo == false)
            {
                #region Ball descriptions
                //Ball descriptions
                aquaBallDesString = "*Les balles Aqua sont similaires aux balles normales !";

                mudBallDesString = "*Les balles Boue sont similaires aux balles normales !";

                basketBallDesString = $"*<size=10.3>Chaque fois qu'un ballon de basket touche un pion, l'or de la balle augmente de +{(BallUpgrades.basketBallBonus * 100).ToString("F0")}%. Cette augmentation est réinitialisée lorsque le ballon atterrit dans le panier ou dans la fosse. Le bonus d'augmentation de l'or est appliqué après le calcul de toutes les autres augmentations.";

                plumBallDesString = "*Les balles prune sont similaires aux balles normales !";

                stickyBallDesString = $"*Il y a {BallUpgrades.stickyBallDoubleGoldChance}% de probabilité que toucher un pion doré double l'or reçu.";

                candyBallDesString = "*Les balles Bonbons sont similaires aux balles normales ! ";

                cookieBallDesString = $"*Si une balle cookie heurte un pion de prestige, il y a {BallUpgrades.cookieDoubleChance}% de chance de recevoir 2 fois plus de points de prestige.";

                limeBallDesString = "*Les balles Citron Vert sont similaires aux balles normales ! ";

                goldBallDesString = $"*<size=11>Les balles dorées ont une probabilité recevoir plus d'or lorsqu'elles heurtent des pions dorés ! \n\n*{BallUpgrades.goldBallDoubleChance}% de chance de recevoir le double d'or. \n\n*{BallUpgrades.goldBallTrippleChance}% de chance de recevoir le triple d'or. \n\n*{BallUpgrades.goldBall5XGold}% de chance de recevoir 5 fois plus d'or. ";

                footBallDesString = $"*Les ballons de football accordent un bonus d'or augmenté de {(BallUpgrades.footBallBucketIncrease).ToString("F2")}X lorsqu'ils tombent dans le panier.";

                sharpnelBallDesString = $"*<size=10.5>Les balles schrapnel ont une probabilité de {BallUpgrades.sharpnelChance1}% de faire apparaître une petite balle schrapnel chaque fois qu'elles touchent un pion. Elles ont également une chance de {BallUpgrades.sharpnelChance2}% de faire apparaître une petite balle schrapnel lorsqu'elles entrent en collision avec autre chose qu'un pion. Les petites balles schrapnel octroient {(BallUpgrades.smallSharpnelGold * 100).ToString("F0")}% de l'or de la balle schrapnel.";

                ringBallDesString = $"*<size=11>Les balles en forme d'anneau ont une probabilité de {BallUpgrades.ringBallSpawnChance}% de faire apparaître une autre balle anneau lorsqu'elles entrent en collision avec autre chose qu'un pion. Les balles anneaux générées octroient {(BallUpgrades.spawnedRingGold * 100).ToString("F0")}% de l'or des balles en forme d'anneau.";

                apricotBallDesString = "*Les balles abricot sont similaires aux balles normales !";

                peggoBallDesString = $"*L'achat des balles Peggo fera apparaître des gemmes de prestige sur le plateau, que seule la balle Peggo peut toucher. Les gemmes de prestige accordent 2 fois plus de points de prestige.";

                ghostBallDesString = $"*Les balles fantômes traversent tout et ne peuvent atterrir que dans le panier. Pour chaque balle fantôme présente à l'écran, toutes les balles bénéficient d'une augmentation de +{(BallUpgrades.ghostBallGoldIncrease * 100).ToString("F0")}% d'or. Le bonus d'augmentation d'or est appliqué après le calcul de toutes les autres augmentations d'or.";

                starBallDesString = $"*<size=11>Pour chaque série de {BallUpgrades.starBallPegsHitNeeded} pions touchés par les balles étoiles, une autre balle étoile apparaîtra. Les balles étoiles générées apparaîtront exactement comme les balles automatiquement lâchées.";

                rainbowBallDesString = $"*<size=11>La balle arc-en-ciel offre une augmentation de +{(BallUpgrades.rainbowBallGoldIncrease * 100).ToString("F0")}% d'or à toutes les balles chaque fois qu'elle touche un pion. Cela s'accumulera avec plusieurs balles arc-en-ciel. Le bonus d'augmentation d'or est appliqué après le calcul de toutes les autres augmentations d'or. Le bonus d'une balle arc-en-ciel est supprimé lorsqu'elle entre dans le panier ou la fosse.";

                glitchyBallDesString = "*La balle glitchée contient les bonus de toutes les autres balles.";
                #endregion
            }
        }
    }
    #endregion

    //Buff hover
    #region Change buff hover
    public void ChangeBuffHover(int buffX, int buff)
    {
        if(buff == 1)
        {
            if (englishLanguage == true) { goldFromPegsBUFF = $"<size=20>{buffX}X gold from pegs"; }
            if (chineseLanguage == true) { goldFromPegsBUFF = $"<size=19>從彩钉获得的{buffX}倍金币"; }
            if (japaneseLanguage == true) { goldFromPegsBUFF = $"<size=20>ペグからのゴールド{buffX}倍"; }
            if (koreanLanguage == true) { goldFromPegsBUFF = $"<size=20>구슬에서의 {buffX}배 황금 "; }
            if (russianLanguage == true) { goldFromPegsBUFF = $"<size=18>{buffX}X золота из колышков"; }
            if (germanLanguage == true) { goldFromPegsBUFF = $"<size=20>{buffX}x Gold von Pegs"; }
            if (frenchLanguage == true) { goldFromPegsBUFF = $"<size=17>{buffX}X plus d'or des pions"; }
            if (spanishLanguage == true) { goldFromPegsBUFF = $"<size=20>{buffX}X oro de pegs"; }
        }
        if (buff == 2)
        {
            if (englishLanguage == true) { goldFromBucketsBUFF = $"<size=20>{buffX}X gold from buckets"; }
            if (chineseLanguage == true) { goldFromBucketsBUFF = $"<size=18>從桶中获得的{buffX}倍金币"; }
            if (japaneseLanguage == true) { goldFromBucketsBUFF = $"<size=18>バケツからのゴールド{buffX}倍"; }
            if (koreanLanguage == true) { goldFromBucketsBUFF = $"<size=20>통에서의 {buffX}배 황금 "; }
            if (russianLanguage == true) { goldFromBucketsBUFF = $"<size=20>{buffX}X золота из корзин"; }
            if (germanLanguage == true) { goldFromBucketsBUFF = $"<size=20>{buffX}x Gold aus Körben"; }
            if (frenchLanguage == true) { goldFromBucketsBUFF = $"<size=17>{buffX}X plus d'or des paniers"; }
            if (spanishLanguage == true) { goldFromBucketsBUFF = $"<size=19>{buffX}X oro de cubos"; }
        }
        if (buff == 3)
        {
            if (englishLanguage == true) { prestigePointsBUFF = $"<size=17>{buffX}X prestige points from prestige pegs"; }
            if (chineseLanguage == true) { prestigePointsBUFF = $"<size=22>{buffX}倍威望分"; }
            if (japaneseLanguage == true) { prestigePointsBUFF = $"<size=16>プレステージポイント{buffX}倍"; }
            if (koreanLanguage == true) { prestigePointsBUFF = $"<size=17>프레스티지 포인트 {buffX}배"; }
            if (russianLanguage == true) { prestigePointsBUFF = $"<size=17>{buffX}X очков престижа"; }
            if (germanLanguage == true) { prestigePointsBUFF = $"<size=18>{buffX}x Prestigepunkte"; }
            if (frenchLanguage == true) { prestigePointsBUFF = $"<size=16>{buffX}X plus de points prestige"; }
            if (spanishLanguage == true) { prestigePointsBUFF = $"<size=16>{buffX}X puntos de prestigio"; }
        }
    }
    #endregion
}
