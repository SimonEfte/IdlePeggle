using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OfflineProgression : MonoBehaviour
{
    public TextMeshProUGUI offlineGainsText, timePassedText;
    public GameObject offlineBar;

    public double offlineGoldAmoint;
    public float offlinePrestigePointAmount;

    public AudioManager audioManager;
    public Levels levelScript;

    void Start()
    {
        if(GameData.isDemo == false)
        {
            if (PlayerPrefs.HasKey("OfflineProgression"))
            {
                StartCoroutine(SetOfflineProgress());
            }
        }
    }

    IEnumerator SetOfflineProgress()
    {
        yield return new WaitForSeconds(0.12f);
        offlineBar.SetActive(true);

        //Getting time
        DateTime lastLogIn = DateTime.Parse(PlayerPrefs.GetString("OfflineProgression"));
        TimeSpan timeSpan = DateTime.Now - lastLogIn;

        #region text
        if (LocalizationStrings.englishLanguage == true) { timePassedText.text = String.Format("Time gone:<color=green> {0} Days {1} Hours {2} Minutes {3} seconds", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); }

        else if (LocalizationStrings.japaneseLanguage == true) { timePassedText.text = String.Format("経過時間：<color=green> {0} 日 {1} 時間 {2} 分 {3} 秒", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); }

        else if (LocalizationStrings.germanLanguage == true) { timePassedText.text = String.Format("<size=6.5>Vergangene Zeit:<color=green> {0} Tage {1} Stunden {2} Minuten {3} Sekunden", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); }

        else if (LocalizationStrings.russianLanguage == true) { timePassedText.text = String.Format("Прошедшее время:<color=green> {0} дня {1} часов {2} минуты {3} секунд", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); }

        else if (LocalizationStrings.frenchLanguage == true) { timePassedText.text = String.Format("Temps écoulé :<color=green> {0} jours {1} heures {2} minutes {3} secondes", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); }

        else if (LocalizationStrings.spanishLanguage == true) { timePassedText.text = String.Format("<size=6.5>Tiempo transcurrido:<color=green> {0} días {1} horas {2} minutos {3} segundos", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); }

        else if (LocalizationStrings.chineseLanguage == true) { timePassedText.text = String.Format("时间过去了:<color=green> {0} 天 {1} 小时 {2} 分钟 {3} 秒", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); }

        else if (LocalizationStrings.koreanLanguage == true) { timePassedText.text = String.Format("지난 시간::<color=green> {0} 일 {1} 시간 {2} 분 {3} 초", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); }
        #endregion

        //Offline gold amount

        //int totalMinutes = ((int)timeSpan.TotalDays)) * 60;

        CheckBallPurchased();

        double highestGold = highestGoldd * (Prestige.prestigeGoldIncrease + 1);
        offlineGoldAmoint = ((highestGold / ballAutoTtime) * ((int)timeSpan.TotalMinutes));
        offlineGoldAmoint *= 2.2f;

        //618 lines

        if (Prestige.NP_Upgrade1Purchased == true) { offlineGoldAmoint *= 1.2f; } 
        if (Prestige.NP_Upgrade6Purchased == true) { offlineGoldAmoint *= 1.25f; }
        if (Prestige.NP_Upgrade8Purchased == true) { offlineGoldAmoint *= 1.25f; } 
        if (Prestige.NP_Upgrade15Purchased == true) { offlineGoldAmoint *= 1.25f; }
        if (Prestige.NP_Upgrade16Purchased == true) { offlineGoldAmoint *= 1.25f; }
        if (Prestige.NP_Upgrade26Purchased == true) { offlineGoldAmoint *= 1.25f; } 
        if (Prestige.NP_Upgrade34Purchased == true) { offlineGoldAmoint *= 1.25f; }

        if (Prestige.purchasedLevel3 == true) { offlineGoldAmoint *= 1.15f; }
        if (Prestige.purchasedLevel5 == true) { offlineGoldAmoint *= 1.15f; }
        if (Prestige.purchasedLevel7 == true) { offlineGoldAmoint *= 1.15f; }
        if (Prestige.purchasedLevel9 == true) { offlineGoldAmoint *= 1.15f; }
        if (Prestige.purchasedLevel10 == true) { offlineGoldAmoint *= 1.15f; }

        if (Prestige.G_Upgrade6Purchased == true) { offlineGoldAmoint *= 1.1f; }
        if (Prestige.G_Upgrade7Purchased == true) { offlineGoldAmoint *= 1.1f; }
        if (Prestige.G_Upgrade12Purchased == true) { offlineGoldAmoint *= 1.7f; }
        if (Prestige.G_Upgrade14Purchased == true) { offlineGoldAmoint *= 1.2f; }
        if (Prestige.G_Upgrade17Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade19Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade23Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade26Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade30Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade31Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade35Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade39Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade40Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade41Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade45Purchased == true) { offlineGoldAmoint *= 1.3f; }
        if (Prestige.G_Upgrade50Purchased == true) { offlineGoldAmoint *= 4.5f; }

        if (Prestige.moreShots1Purchased == true) { offlineGoldAmoint *= 1.25f; } //1
        if (Prestige.moreShots2Purchased == true) { offlineGoldAmoint *= 1.25f; }
        if (Prestige.moreShots3Purchased == true) { offlineGoldAmoint *= 1.25f; }
        if (Prestige.moreShots4Purchased == true) { offlineGoldAmoint *= 1.25f; }

        int divideBy = 10;

        //Offline prestige point
        float prestigePointGain = Prestige.prestigePointsIncrease * ((int)BallUpgrades.offlineProgressTextChance + (int)Prestige.prestigePegChance);

        if(Prestige.PU_Upgrade12Purchased == true) { divideBy -= 1; }
        if (Prestige.PU_Upgrade36Purchased == true) { divideBy -= 1; }
        if (Prestige.PU_Upgrade44Purchased == true) { divideBy -= 1; }

        if (Prestige.purchasedLevel4 == true) { divideBy -= 1; }
        if (Prestige.purchasedLevel8 == true) { divideBy -= 1; }

        if (Prestige.NP_Upgrade8Purchased == true) { divideBy -= 1; }
        if (Prestige.NP_Upgrade26Purchased == true) { divideBy -= 1; }
        if (Prestige.NP_Upgrade34Purchased == true) { divideBy -= 1; }
        if (Prestige.NP_Upgrade15Purchased == true) { divideBy -= 1; }

        if (divideBy < 2) { prestigePointGain *= 6; }
        else if (divideBy < 4) { prestigePointGain *= 5; }
        else if (divideBy < 6) { prestigePointGain *= 3; }
        else if (divideBy < 8) { prestigePointGain *= 2; }

        offlinePrestigePointAmount = (prestigePointGain / divideBy) * ((int)timeSpan.TotalMinutes);
        if((int)BallUpgrades.offlineProgressTextChance == 0) { offlinePrestigePointAmount = 0; }

        //632
        //21

        #region Text
        if (LocalizationStrings.englishLanguage == true) { offlineGainsText.text = $"You hit a lot of pegs, giving you a total of <color=yellow>{SetHighNumbers.FormatCoinsGoldShort(offlineGoldAmoint)}</color> gold and <color=orange>{offlinePrestigePointAmount.ToString("F0")}</color> prestige points!"; }

        if (LocalizationStrings.japaneseLanguage == true) { offlineGainsText.text = $"多くの紫のペグを打ち、合計<color=yellow>{SetHighNumbers.FormatCoinsGoldShort(offlineGoldAmoint)}</color>のゴールドと<color=orange>{offlinePrestigePointAmount.ToString("F0")}</color>のプレステージポイントを獲得しました！"; }

        if (LocalizationStrings.germanLanguage == true) { offlineGainsText.text = $"hast du viele violette Pegs getroffen, was dir insgesamt <color=yellow>{SetHighNumbers.FormatCoinsGoldShort(offlineGoldAmoint)}</color> Gold und <color=orange>{offlinePrestigePointAmount.ToString("F0")}</color> Prestigepunkte eingebracht hat!"; }

        if (LocalizationStrings.russianLanguage == true) { offlineGainsText.text = $"Вы попали в много фиолетовых колышков, что дало вам в сумме <color=yellow>{SetHighNumbers.FormatCoinsGoldShort(offlineGoldAmoint)}</color> золота и <color=orange>{offlinePrestigePointAmount.ToString("F0")}</color> очков престижа!"; }

        if (LocalizationStrings.frenchLanguage == true) { offlineGainsText.text = $"YVous avez touché beaucoup de pions violets, vous donnant un total de <color=yellow>{SetHighNumbers.FormatCoinsGoldShort(offlineGoldAmoint)}</color> d'or et <color=orange>{offlinePrestigePointAmount.ToString("F0")}</color> points prestiges !"; }

        if (LocalizationStrings.spanishLanguage == true) { offlineGainsText.text = $"¡Golpeaste muchos pegs morados, dándote un total de <color=yellow>{SetHighNumbers.FormatCoinsGoldShort(offlineGoldAmoint)}</color> de oro y <color=orange>{offlinePrestigePointAmount.ToString("F0")}</color> puntos de prestigio!"; }

        if (LocalizationStrings.chineseLanguage == true) { offlineGainsText.text = $"你击中了很多紫色彩钉，给你带来了共计<color=yellow>{SetHighNumbers.FormatCoinsGoldShort(offlineGoldAmoint)}</color>金币和<color=orange>{offlinePrestigePointAmount.ToString("F0")}</color> 点威望分！"; }

        if (LocalizationStrings.koreanLanguage == true) { offlineGainsText.text = $"많은 보라 구슬을 명중하여 총<color=yellow>{SetHighNumbers.FormatCoinsGoldShort(offlineGoldAmoint)}</color> 골드와 <color=orange>{offlinePrestigePointAmount.ToString("F0")}</color> 프레스티지 포인트를 얻었습니다!"; }
        #endregion
    }

    public float ballAutoTtime;
    public double highestGoldd;

    #region check purchased balls
    public void CheckBallPurchased()
    {
        ballAutoTtime = BallUpgrades.basicBallAutoDropTime; highestGoldd = BallUpgrades.regularBallGold;

        if (BallUpgrades.isRedBallAutoPurchased && BallUpgrades.bouncyBallPurchased) { ballAutoTtime = BallUpgrades.redBallAutoDropTime; highestGoldd = BallUpgrades.redBallGold; }

        if (BallUpgrades.isRockBallAutoPurchased == true && BallUpgrades.rockBallPurchased) { ballAutoTtime = BallUpgrades.rockBallAutoDropTime; highestGoldd = BallUpgrades.rockBallGold; }

        if (BallUpgrades.isBombBallAutoPurchased == true && BallUpgrades.bombBallPurchased) { ballAutoTtime = BallUpgrades.bombBallAutoDropTime; highestGoldd = BallUpgrades.bombBallGold; }

        if (BallUpgrades.isAquaBallAutoPurchased == true && BallUpgrades.aquaBallPurchased) { ballAutoTtime = BallUpgrades.aquaBallAutoDropTime; highestGoldd = BallUpgrades.aquaBallGold; }

        if (BallUpgrades.isMudBallAutoPurchased == true && BallUpgrades.mudBallPurchased) { ballAutoTtime = BallUpgrades.mudBallAutoDropTime; highestGoldd = BallUpgrades.mudBallGold; }

        if (BallUpgrades.isBasketBallAutoPurchased == true && BallUpgrades.basketBallPurchased) { ballAutoTtime = BallUpgrades.basketBallAutoDropTime; highestGoldd = BallUpgrades.basketBallGold; }

        if (BallUpgrades.isPlumBallAutoPurchased == true && BallUpgrades.plumBallPurchased) { ballAutoTtime = BallUpgrades.plumBallAutoDropTime; highestGoldd = BallUpgrades.plumBallGold; }

        if (BallUpgrades.isStickyBallAutoPurchased == true && BallUpgrades.stickyBallPurchased) { ballAutoTtime = BallUpgrades.stickyBallAutoDropTime; highestGoldd = BallUpgrades.stickyBallGold; }

        if (BallUpgrades.isCandyBallAutoPurchased == true && BallUpgrades.candyBallPurchased) { ballAutoTtime = BallUpgrades.candyBallAutoDropTime; highestGoldd = BallUpgrades.candyBallGold; }

        if (BallUpgrades.isCookieBallAutoPurchased == true && BallUpgrades.cookieBallPurchased) { ballAutoTtime = BallUpgrades.cookieBallAutoDropTime; highestGoldd = BallUpgrades.cookieBallGold; }

        if (BallUpgrades.isLimeBallAutoPurchased == true && BallUpgrades.limeBallPurchased) { ballAutoTtime = BallUpgrades.limeBallAutoDropTime; highestGoldd = BallUpgrades.limeBallGold; }

        if (BallUpgrades.isGoldenBallAutoPurchased == true && BallUpgrades.goldenBallPurchased) { ballAutoTtime = BallUpgrades.goldenBallAutoDropTime; highestGoldd = BallUpgrades.goldenBallGold; }

        if (BallUpgrades.isFootballBallAutoPurchased == true && BallUpgrades.footballBallPurchased) { ballAutoTtime = BallUpgrades.footballBallAutoDropTime; highestGoldd = BallUpgrades.footballBallGold; }

        if (BallUpgrades.isSharpnelBallAutoPurchased == true && BallUpgrades.sharpnelBallPurchased) { ballAutoTtime = BallUpgrades.sharpnelBallAutoDropTime; highestGoldd = BallUpgrades.sharpnelBallGold; }

        if (BallUpgrades.isZonicBallAutoPurchased == true && BallUpgrades.zonicBallPurchased) { ballAutoTtime = BallUpgrades.zonicBallAutoDropTime; highestGoldd = BallUpgrades.zonicBallGold; }

        if (BallUpgrades.isApricotBallAutoPurchased == true && BallUpgrades.apricotBallPurchased) { ballAutoTtime = BallUpgrades.apricotBallAutoDropTime; highestGoldd = BallUpgrades.apricotBallGold; }

        if (BallUpgrades.isPeggoBallAutoPurchased == true && BallUpgrades.peggoBallPurchased) { ballAutoTtime = BallUpgrades.peggoBallAutoDropTime; highestGoldd = BallUpgrades.peggoBallGold; }

        if (BallUpgrades.isGhostBallAutoPurchased == true && BallUpgrades.ghostBallPurchased) { ballAutoTtime = BallUpgrades.ghostBallAutoDropTime; highestGoldd = BallUpgrades.ghostBallGold; }

        if (BallUpgrades.isStarBallAutoPurchased == true && BallUpgrades.starBallPurchased) { ballAutoTtime = BallUpgrades.starBallAutoDropTime; highestGoldd = BallUpgrades.starBallGold; }

        if (BallUpgrades.isRainbowBallAutoPurchased == true && BallUpgrades.rainbowBallPurchased) { ballAutoTtime = BallUpgrades.rainbowBallAutoDropTime; highestGoldd = BallUpgrades.rainbowBallGold; }

        if (BallUpgrades.isGlitchyBallAutoPurchased == true && BallUpgrades.glitchyBallPurchased) { ballAutoTtime = BallUpgrades.glitchyBallAutoDropTime; highestGoldd = BallUpgrades.glitchyBallGold; }
    }
    #endregion

    public void ClickOk()
    {
        offlineBar.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        audioManager.Play("UIClick1");

        BallUpgrades.points += offlineGoldAmoint;
        AllStats.totalGold += offlineGoldAmoint;

        Prestige.prestigePoints += (int)offlinePrestigePointAmount;
        AllStats.totalPRestigePoints += (int)offlinePrestigePointAmount;
    }

    public void SetTime()
    {
        PlayerPrefs.SetString("OfflineProgression", DateTime.Now.ToString());
    }

    private void OnApplicationQuit()
    {
        if(GameData.isDemo == false) { SetTime(); }
    }

    //Test 1
    //32184 - > 3947
    //4 - > 2

    //Test 2 
    //16.49M - > 1.66M
    //54 - > 5

    //Test 3
    //83.6qd - > 6.9qd
    //722 - > 23

    //Test 4
    //9.735sx - > 1.04sx
    //6225 - > 142

    //Test 5
    //101.9sp - > 16.774sp
    //38132 - > 1660

    //Test 6
    //310dd - > 28dd
    //241859 - > 12576

}
