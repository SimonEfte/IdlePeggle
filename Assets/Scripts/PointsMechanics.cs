using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsMechanics : MonoBehaviour
{
    public AllStats statsScript;
    public Challenges challScript;
    public Achievements achScript;
    public BallUpgrades ballUPScript;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("saveTextPopUp")) 
        { 
            popUpSliderNumber = 7;
            textPopUpSlider.value = popUpSliderNumber;
            TextPopUpSliderValue();
        }
        else 
        {
            popUpSliderNumber = PlayerPrefs.GetInt("saveTextPopUp");

            textPopUpSlider.value = popUpSliderNumber;
            TextPopUpSliderValue();
        }

        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.15f);
        CheckWhichBallsToSpawnText();
    }

    #region Set gold PEG
    public void SetGold(double gold, Vector2 pos, int layer, float goldMultiplierIncrease, bool spawnText)
    {
        bool isBallShot = false;
        if (layer == 9 || layer == 16) { isBallShot = true; }
        else if (layer == 15) { isBallShot = false; }
        else if (layer == 18) { isBallShot = true; }

        double goldAmount = 0;
        float goldMultiplier = 0;
        goldMultiplier += goldMultiplierIncrease;
        if (isBallShot == true) { goldAmount = (gold * (BallUpgrades.goldenPegsIncrease)) * (Prestige.activeGoldIncrease + Prestige.prestigeGoldIncrease + 1); }
        if (isBallShot == false) { goldAmount = (gold * (BallUpgrades.goldenPegsIncrease)) * (Prestige.prestigeGoldIncrease + 1); }

        if (BallUpgrades.ghostBallPurchased == true)
        {
            goldAmount *= (1 + BallUpgrades.totalGhostBallIncrease + BallUpgrades.totalRainbowBallIncrease);
        }

        bool hit2XOrMore = false;
        if (Prestige.G_Upgrade27Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X2goldChance) { goldMultiplier += 2; hit2XOrMore = true; }
        }
        if (Prestige.G_Upgrade28Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X3goldChance) { goldMultiplier += 3; hit2XOrMore = true;  }
        }
        if (Prestige.G_Upgrade29Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X5goldChance) { goldMultiplier += 5; hit2XOrMore = true;  }
        }
        if (Prestige.G_Upgrade30Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X10goldChance) { goldMultiplier += 10; hit2XOrMore = true;  }
        }

        if(Levels.isRainbowGoldPeg == true && Levels.isGoldRush == true) { goldMultiplier += (Prestige.rainbowPegIncrease + Prestige.goldRushIncrease); }
        else if(Levels.isRainbowGoldPeg == true) { goldMultiplier += Prestige.rainbowPegIncrease; }
        else if (Levels.isGoldRush == true) { goldMultiplier += Prestige.goldRushIncrease; }

        if(goldMultiplier == 0)
        {
            BallUpgrades.points += goldAmount * (goldMultiplier + 1);
            AllStats.totalGold += goldAmount * (goldMultiplier + 1);
            AllStats.totalPegGold += goldAmount * (goldMultiplier + 1);
        }
        else
        {
            BallUpgrades.points += goldAmount * (goldMultiplier);
            AllStats.totalGold += goldAmount * (goldMultiplier);
            AllStats.totalPegGold += goldAmount * (goldMultiplier);
        }

        float textSpawnChance = 0;

        if (AllStats.greenPegChance > 43 && BallUpgrades.textSpawnChance < 25) { textSpawnChance = 0;}
        else { textSpawnChance = BallUpgrades.textSpawnChance; }

        float random2 = Random.Range(0f, 100f);
      
        if(random2 > textSpawnChance && spawnText == true)
        {
            TextMeshProUGUI pegPointText = ObjectPool.instance.GetPegPointPopUpFromPool();

            double totalGoldAmount;

            if (goldMultiplier == 0)
            {
                totalGoldAmount = goldAmount * (goldMultiplier + 1);
            }
            else
            {
                totalGoldAmount = goldAmount * (goldMultiplier);
            }

            if(totalGoldAmount > 100 || totalGoldAmount < 1) { pegPointText.text = "+" + SetHighNumbers.FormatCoinsGoldShort(totalGoldAmount); }
            else if (totalGoldAmount % 1 == 0)
            {
                pegPointText.text = "+" + SetHighNumbers.FormatCoinsGoldShort(totalGoldAmount);
            }
            else
            {
                pegPointText.text = "+" + totalGoldAmount.ToString("F1");
            }

            if (isBallShot == true) { pegPointText.gameObject.layer = 25; }
            else { pegPointText.gameObject.layer = 26; }

            pegPointText.transform.position = pos;
            pegPointText.transform.localScale = new Vector3(1f, 1f, 1f);
        }
       
        if(achScript != null) { achScript.CheckGoldGainACH(); }
    }
    #endregion

    #region Set gold BUCKET
    public void SetBucket(double gold, Vector2 pos,  int layer, float goldMultiplierIncrease, bool isFootball, bool spawnText)
    {
        bool isBallShot = false;
        if (layer == 9 || layer == 16) { isBallShot = true; }
        else if (layer == 15) { isBallShot = false; }
        else if (layer == 18) { isBallShot = true; }

        double goldAmount = 0;
        float goldeMultiplier = 0;
        goldeMultiplier += goldMultiplierIncrease;
        if(isFootball == true) { goldeMultiplier += BallUpgrades.footBallBucketIncrease; }
        if (isBallShot == true) { goldAmount = (gold * (BallUpgrades.bucketIncrease)) * (Prestige.activeGoldIncrease + Prestige.prestigeGoldIncrease + 1); }
        if (isBallShot == false) { goldAmount = (gold * (BallUpgrades.bucketIncrease)) * (Prestige.prestigeGoldIncrease + 1); }

        if (BallUpgrades.ghostBallPurchased == true)
        {
            goldAmount *= (1 + BallUpgrades.totalGhostBallIncrease + BallUpgrades.totalRainbowBallIncrease);
        }

        bool hit2XOrMore = false;
        if (Prestige.G_Upgrade31Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X2bucketGoldChance) { goldeMultiplier += 2; hit2XOrMore = true;  }
        }
        if (Prestige.G_Upgrade32Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X3bucketGoldChance) { goldeMultiplier += 3; hit2XOrMore = true;  }
        }
        if (Prestige.G_Upgrade33Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X5bucketGoldChance) { goldeMultiplier += 5; hit2XOrMore = true; }
        }
        if (Prestige.G_Upgrade34Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X8bucketGoldChance) { goldeMultiplier += 8; hit2XOrMore = true;}
        }
        if (Prestige.G_Upgrade35Purchased == true && hit2XOrMore == false)
        {
            float random = Random.Range(0f, 100f); if (random < Prestige.X10bucketGoldChance) { goldeMultiplier += 10; hit2XOrMore = true;  }
        }

        if (Levels.isRainbowGoldBucket == true && Levels.isGoldRush == true) { goldeMultiplier += (Prestige.rainbowPegIncrease + Prestige.goldRushIncrease); }
        else if (Levels.isRainbowGoldBucket == true) { goldeMultiplier += Prestige.rainbowPegIncrease; }
        else if (Levels.isGoldRush == true) { goldeMultiplier += Prestige.goldRushIncrease; }

        AllStats.totalBallsPit += 1;
        if(goldeMultiplier == 0)
        {
            BallUpgrades.points += goldAmount;
            AllStats.totalGold += goldAmount;
            AllStats.totalPitGold += goldAmount;
        }
        else
        {
            BallUpgrades.points += goldAmount * (goldeMultiplier);
            AllStats.totalGold += goldAmount * (goldeMultiplier);
            AllStats.totalPitGold += goldAmount * (goldeMultiplier);
        }


        double totalGoldAmount;

        if (goldeMultiplier == 0)
        {
            totalGoldAmount = goldAmount;
        }
        else
        {
            totalGoldAmount = goldAmount * (goldeMultiplier);
        }

        float textSpawnChance = 0;

        if (AllStats.greenPegChance > 43 && BallUpgrades.textSpawnChance < 25) { textSpawnChance = 0; }
        else { textSpawnChance = BallUpgrades.textSpawnChance; }

        float random2 = Random.Range(0f, 100f);
        if(random2 > textSpawnChance && spawnText == true)
        {
            TextMeshProUGUI pegPointText = ObjectPool.instance.GetPegPointPopUpFromPool();

            if (totalGoldAmount > 100 || totalGoldAmount < 1) { pegPointText.text = "+" + SetHighNumbers.FormatCoinsGoldShort(totalGoldAmount); }
            else if (totalGoldAmount % 1 == 0)
            {
                pegPointText.text = "+" + SetHighNumbers.FormatCoinsGoldShort(totalGoldAmount);
            }
            else
            {
                pegPointText.text = "+" + totalGoldAmount.ToString("F1");
            }

            if (isBallShot == true) { pegPointText.gameObject.layer = 27; }
            else { pegPointText.gameObject.layer = 28; }

            pegPointText.transform.position = pos;
        }

        if (achScript != null) { achScript.CheckGoldGainACH(); }
    }
    #endregion

    #region Prestige points
    public void HitPrestigePeg(int prestigePoints, Vector2 pos, bool isCookieBall, bool isDouble, bool isEnchaned)
    {
        int totalMultiplier = 0;
        
        if(isDouble == true) { totalMultiplier += 2; }

        if(isCookieBall == true)
        {
            int random = Random.Range(0, 100);
            if(random < BallUpgrades.cookieDoubleChance)
            {
                totalMultiplier += 2;

                Challenges.cookieBallExtraCount += prestigePoints;
                if (Challenges.challCompleted[27] == false && Challenges.challFinished[27] == false)
                {
                    if (SettingsOptions.isInChallengeTab == true)
                    {
                        challScript.ChallengeProgress(28, Challenges.cookieBallExtraCount);
                    }
                    challScript.CheckCompleted(28, Challenges.cookieBallExtraCount);
                }
            }
        }

        bool hitMulti = false;

        if(Prestige.PU_Upgrade21Purchased == true)
        {
            float random = Random.Range(0f, 100f);
            if(random < Prestige.X2prestigePointChance) { totalMultiplier += 2; hitMulti = true;  }
        }
        if (Prestige.PU_Upgrade22Purchased == true && hitMulti == false)
        {
            float random = Random.Range(0f, 100f);
            if (random < Prestige.X3prestigePointChance) { totalMultiplier += 3; hitMulti = true; }
        }
        if (Prestige.PU_Upgrade23Purchased == true && hitMulti == false)
        {
            float random = Random.Range(0f, 100f);
            if (random < Prestige.X5prestigePointChance) { totalMultiplier += 5; hitMulti = true;  }
        }
        if (Prestige.PU_Upgrade24Purchased == true && hitMulti == false)
        {
            float random = Random.Range(0f, 100f);
            if (random < Prestige.X10prestigePointChance) { totalMultiplier += 10; hitMulti = true;  }
        }

        if (Levels.isRainbowPRestige == true) { totalMultiplier += Prestige.rainbowPegIncrease; }
        if (Levels.isPRestigeRush == true) { totalMultiplier += Prestige.prestigeRushIncrease; }

        float textSpawnChance = 0;

        if (AllStats.greenPegChance > 43 && BallUpgrades.textSpawnChance < 25) { textSpawnChance = 0; }
        else { textSpawnChance = BallUpgrades.textSpawnChance; }

        bool spawnText = true;

        float random2 = Random.Range(0f, 100f);
        TextMeshProUGUI prestigeText = null;

        if (random2 > textSpawnChance)
        {
            spawnText = true;
            prestigeText = ObjectPool.instance.GetPrestigeTextFromPool();
            prestigeText.gameObject.layer = 29;

            prestigeText.transform.position = pos;
            prestigeText.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else { spawnText = false; }

        if (totalMultiplier == 0)
        {
            if(spawnText == true) { prestigeText.text = "+" + prestigePoints; }
            if(Prestige.ppOverflow == false)
            {
                Prestige.prestigePoints += prestigePoints;
                AllStats.totalPRestigePoints += prestigePoints;
            }
            else
            {
                Prestige.prestigePointsOverFlow += prestigePoints;
                AllStats.totalPrestigePointOverflow += prestigePoints;
            }
        }
        else
        {
            if (isEnchaned == true)
            {
                float increase = 0;
                increase = totalMultiplier + Prestige.purplePegIncrease;

                int totalPrestigePoints = 0;

                totalPrestigePoints = Mathf.RoundToInt(increase * prestigePoints);

                if (spawnText == true) { prestigeText.text = "+" + totalPrestigePoints; }

                if (Prestige.ppOverflow == false)
                {
                    Prestige.prestigePoints += totalPrestigePoints;
                    AllStats.totalPRestigePoints += totalPrestigePoints;
                }
                else
                {
                    Prestige.prestigePointsOverFlow += prestigePoints;
                    AllStats.totalPrestigePointOverflow += prestigePoints;
                }
            }
            else
            {
                if (spawnText == true) { prestigeText.text = "+" + prestigePoints * (totalMultiplier); }

                if (Prestige.ppOverflow == false)
                {
                    Prestige.prestigePoints += prestigePoints * (totalMultiplier);
                    AllStats.totalPRestigePoints += prestigePoints * (totalMultiplier);
                }
                else
                {
                    Prestige.prestigePointsOverFlow += prestigePoints * (totalMultiplier);
                    AllStats.totalPrestigePointOverflow += prestigePoints * (totalMultiplier);
                }
            }

            //Debug.Log(totalMultiplier);
        }

        if (achScript != null) { achScript.CheckTotalPrestigeACH(); }
    }
    #endregion

    public Slider textPopUpSlider;
    public static int popUpSliderNumber;
    public TextMeshProUGUI textPopUpSliderText;

    public void TextPopUpSliderValue()
    {
        popUpSliderNumber = (int)textPopUpSlider.value;
        if(popUpSliderNumber == 7) { textPopUpSliderText.text = LocalizationStrings.sliderAll; }
        if (popUpSliderNumber == 6) { textPopUpSliderText.text = LocalizationStrings.sliderHalf; CheckWhichBallsToSpawnText(); }
        if (popUpSliderNumber == 5) { textPopUpSliderText.text = LocalizationStrings.slider4Latest; CheckWhichBallsToSpawnText(); }
        if (popUpSliderNumber == 4) { textPopUpSliderText.text = LocalizationStrings.slider3Latest; CheckWhichBallsToSpawnText(); }
        if (popUpSliderNumber == 3) { textPopUpSliderText.text = LocalizationStrings.slider2Latest; CheckWhichBallsToSpawnText(); }
        if (popUpSliderNumber == 2) { textPopUpSliderText.text = LocalizationStrings.sliderLatest; CheckWhichBallsToSpawnText(); }
        if (popUpSliderNumber == 1) { textPopUpSliderText.text = LocalizationStrings.sliderNONE; SetOff(); }

        PlayerPrefs.SetInt("saveTextPopUp", popUpSliderNumber);
    }

    public static bool spawnBall1Text, spawnBall2Text, spawnBall3Text, spawnBall4Text, spawnBall5Text, spawnBall6Text, spawnBall7Text, spawnBall8Text, spawnBall9Text, spawnBall10Text, spawnBall11Text, spawnBall12Text, spawnBall13Text, spawnBall14Text, spawnBall15Text, spawnBall16Text, spawnBall17Text, spawnBall18Text, spawnBall19Text, spawnBall20Text, spawnBall21Text, spawnBall22Text;

    public void SetOff()
    {
        spawnBall1Text = false; spawnBall2Text = false; spawnBall3Text = false; spawnBall4Text = false; spawnBall5Text = false;
        spawnBall6Text = false; spawnBall7Text = false; spawnBall8Text = false; spawnBall9Text = false; spawnBall10Text = false;
        spawnBall11Text = false; spawnBall12Text = false; spawnBall13Text = false; spawnBall14Text = false; spawnBall15Text = false;
        spawnBall16Text = false; spawnBall17Text = false; spawnBall18Text = false; spawnBall19Text = false; spawnBall20Text = false;
        spawnBall21Text = false; spawnBall22Text = false;
    }

    public void CheckWhichBallsToSpawnText()
    {
        SetOff();
        int totalBalls = 0;

        if (popUpSliderNumber == 6) { totalBalls = (1 + BallUpgrades.ballsPurchased) / 2; }
        else if (popUpSliderNumber == 5) { totalBalls = 4; }
        else if (popUpSliderNumber == 4) { totalBalls = 3; }
        else if (popUpSliderNumber == 3) { totalBalls = 2; }
        else if (popUpSliderNumber == 2) { totalBalls = 1; }
        int spawnAmount = 0;

        if (BallUpgrades.glitchyBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall22Text = true; }
        if (BallUpgrades.rainbowBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall21Text = true; }
        if (BallUpgrades.starBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall20Text = true; }
        if (BallUpgrades.ghostBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall19Text = true; }
        if (BallUpgrades.peggoBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall18Text = true; }
        if (BallUpgrades.apricotBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall17Text = true; }
        if (BallUpgrades.zonicBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall16Text = true; }
        if (BallUpgrades.sharpnelBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall15Text = true; }
        if (BallUpgrades.footballBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall14Text = true; }
        if (BallUpgrades.goldenBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall13Text = true; }
        if (BallUpgrades.limeBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall12Text = true; }
        if (BallUpgrades.cookieBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall11Text = true; }
        if (BallUpgrades.candyBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall10Text = true; }
        if (BallUpgrades.stickyBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall9Text = true; }
        if (BallUpgrades.plumBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall8Text = true; }
        if (BallUpgrades.basketBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall7Text = true;  }
        if (BallUpgrades.mudBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall6Text = true; }
        if (BallUpgrades.aquaBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall5Text = true; }
        if (BallUpgrades.bombBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall4Text = true; }
        if (BallUpgrades.rockBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall3Text = true; }
        if (BallUpgrades.bouncyBallPurchased && spawnAmount != totalBalls) { spawnAmount += 1; spawnBall2Text = true; }
        if(BallUpgrades.bouncyBallPurchased == false) { spawnBall1Text = true; }
        if(BallUpgrades.ballsPurchased < totalBalls) { spawnBall1Text = true; }
    }
}
