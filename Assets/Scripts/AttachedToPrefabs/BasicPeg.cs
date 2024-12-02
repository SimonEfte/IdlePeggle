using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicPeg : MonoBehaviour
{
    public static int boardClearGoldHit, boardClearPrestigeHit;

    private Collider2D ballCollider;
    public Transform basicPeg, goldPeg, prestigePeg, redPeg, bombPeg, rainbowPeg, purplePeg;

    public GameObject levels;
    public Levels levelScripts;

    public GameObject chall;
    public Challenges challScript;

    public static int totalGoldenPegs, totalPrestigePegs, totalRedPegs, totalBombPegs, totalRainbowPegs, totalPurplePegs;

    private Animation anim;
    public bool isChallActive;

    public void Awake()
    {
        chall = GameObject.Find("ChallengesScriptExclude_Keep_MainGame");
        if(chall != null) { challScript = chall.GetComponent<Challenges>(); isChallActive = true; }
        else { isChallActive = false; }

        anim = GetComponent<Animation>();

        levels = GameObject.Find("LevelsScipt");
        levelScripts = levels.GetComponent<Levels>();

        basicPeg = transform.Find("BasicPeg");
        goldPeg = transform.Find("GoldPeg");
        prestigePeg = transform.Find("PrestigePeg");
        redPeg = transform.Find("RedPeg");
        bombPeg = transform.Find("BombPeg");
        rainbowPeg = transform.Find("RainbowPeg");
        purplePeg = transform.Find("PurplePeg");

        ballCollider = GetComponent<Collider2D>();
    }

    public bool isGreenPeg, isGoldPeg, isPrestigePeg, isRedPeg, isBombPeg, isRainbowPeg, isPurplePeg;

    public void OnEnable()
    {
        isBoardClearned = false;

        isGoldPeg = false;
        isPrestigePeg = false;
        isRedPeg = false;
        isGreenPeg = false;
        isBombPeg = false;
        isRainbowPeg = false;
        isPurplePeg = false;
        hitPeg = false;

        float randomGold = Random.Range(0f, 100f);
        float randomPrestigePeg = Random.Range(0f, (100f - Prestige.goldenPegChance));
        float randomRedPeg = Random.Range(0f, (100f - (Prestige.goldenPegChance + Prestige.prestigePegChance)));
        float randomRainbowPeg = Random.Range(0f, (100f - (Prestige.goldenPegChance + Prestige.prestigePegChance + Prestige.redPegChance)));
        float randomBombPeg = Random.Range(0f, (100f - (Prestige.goldenPegChance + Prestige.prestigePegChance + Prestige.redPegChance + Prestige.rainbowPegChance)));
        float randomPurplePeg = Random.Range(0f, (100f - (Prestige.goldenPegChance + Prestige.prestigePegChance + Prestige.redPegChance + Prestige.rainbowPegChance + Prestige.purplePegChance)));

        if (randomGold < Prestige.goldenPegChance)
        { 
            goldPeg.gameObject.SetActive(true);
            gameObject.layer = 12;
            totalGoldenPegs += 1;
            isGoldPeg = true;
        }
        else if(randomPrestigePeg < Prestige.prestigePegChance) 
        { 
            prestigePeg.gameObject.SetActive(true);
            gameObject.layer = 13;
            totalPrestigePegs += 1;
            isPrestigePeg = true;
        }
        else if(Prestige.isRedPegUnlocked == true && randomRedPeg < Prestige.redPegChance)
        {
            redPeg.gameObject.SetActive(true);
            gameObject.layer = 14;
            totalRedPegs += 1;
            isRedPeg = true;
        }
        else if (Prestige.NP_Upgrade8Purchased == true && randomRainbowPeg < Prestige.rainbowPegChance)
        {
            rainbowPeg.gameObject.SetActive(true);
            gameObject.layer = 11;
            totalRainbowPegs += 1;
            isRainbowPeg = true;
        }
        else if (Prestige.NP_Upgrade17Purchased == true && randomBombPeg < Prestige.bombPegChance)
        {
            bombPeg.gameObject.SetActive(true);
            gameObject.layer = 21;
            totalBombPegs += 1;
            isBombPeg = true;
        }
        else if (Prestige.NP_Upgrade26Purchased == true && randomPurplePeg < Prestige.purplePegChance)
        {
            purplePeg.gameObject.SetActive(true);
            gameObject.layer = 22;
            totalPurplePegs += 1;
            isPurplePeg = true;
        }
        else
        {
            if(AllStats.greenPegChance < 0.1f)
            {
                goldPeg.gameObject.SetActive(true);
                gameObject.layer = 12;
                totalGoldenPegs += 1;
                isGoldPeg = true;
            }
            else
            {
                isGreenPeg = true;
                basicPeg.gameObject.SetActive(true); gameObject.layer = 11;
            }
        }

        MainShooter.totalPegs += 1;

        ballCollider.enabled = true;
        gameObject.transform.localScale = new Vector3(0.205f, 0.205f, 0.205f);
        originalScale = transform.localScale;

        //Debug.Log(MainShooter.totalPegs);
    }

    public void OnDisable()
    {
        if (coroutine != null) 
        { 
            StopCoroutine(coroutine);
            coroutine = null;
        }
        SetAllPegsIactive();
    }

    public bool hitPeg;
    public bool isBoardClearned;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hitPeg == false)
        {
            if (collision.gameObject.layer == 9 || collision.gameObject.layer == 15 || collision.gameObject.layer == 16 || collision.gameObject.layer == 19|| collision.gameObject.layer == 20)
            {
                SetStats();
                coroutine = StartCoroutine(HitPegAndAnim());
                levelScripts.CheckACH();
            }
        }
    }

    public float scaleIncreaseAmount = 0.025f;
    public float scaleUpDuration = 0.13f;
    public float scaleDownDuration = 0.15f;

    private Vector3 originalScale;
    private Coroutine coroutine;

    private IEnumerator HitPegAndAnim()
    {
        hitPeg = true;
        anim.Play("pegHitAnim");
        ballCollider.enabled = false;
        MainShooter.totalPegsHit += 1;

        if (MainShooter.totalPegsHit == MainShooter.totalPegs && isBoardClearned == false)
        {
            isBoardClearned = true;
            WaitForClearedBoard();
        }

        while (anim.isPlaying)
        {
            yield return null;
        }

        ObjectPool.instance.ReturnPegsFromPool(gameObject);
    }

    public void SetStats()
    {
        if (isGreenPeg == true) { AllStats.greenPegsHit += 1; }
        if (isGoldPeg == true) 
        {
            AllStats.goldenPegsHit += 1; boardClearGoldHit += 1;

            if(isChallActive == true)
            {
                if (Challenges.challCompleted[17] == false && Challenges.challFinished[17] == false) { challScript.CheckCompleted(18, AllStats.goldenPegsHit); }
                if (Challenges.challCompleted[18] == false && Challenges.challFinished[18] == false) { challScript.CheckCompleted(19, AllStats.goldenPegsHit); }
                if (Challenges.challCompleted[19] == false && Challenges.challFinished[19] == false) { challScript.CheckCompleted(20, AllStats.goldenPegsHit); }

                if (SettingsOptions.isInChallengeTab == true)
                {
                    if (Challenges.challCompleted[17] == false && Challenges.challFinished[17] == false) { challScript.ChallengeProgress(18, AllStats.goldenPegsHit); }
                    if (Challenges.challCompleted[18] == false && Challenges.challFinished[18] == false) { challScript.ChallengeProgress(19, AllStats.goldenPegsHit); }
                    if (Challenges.challCompleted[19] == false && Challenges.challFinished[19] == false) { challScript.ChallengeProgress(20, AllStats.goldenPegsHit); }
                }
            }

            if (Prestige.G_Upgrade51Purchased == true)
            {
                if(Levels.isGoldRush == false)
                {
                    float random = Random.Range(0f, 100f);
                    if (random < Prestige.goldRushChance) { levelScripts.StartGoldRush(); }
                    //if (random < 0.5f) { levelScripts.StartGoldRush(); }
                }
            }
        }
        if (isPrestigePeg == true) 
        {
            AllStats.prestigePegsHit += 1; boardClearPrestigeHit += 1;

            if (Prestige.PU_Upgrade44Purchased == true)
            {
                if (Levels.isPRestigeRush == false)
                {
                    float random = Random.Range(0f, 100f);
                    if (random < Prestige.prestigeRushChance) { levelScripts.StartPrestigeRush(); }
                    //if (random < 0.5f) { levelScripts.StartPrestigeRush(); }
                }
            }
        }

        if(isRainbowPeg == true)
        {
            levelScripts.RainbowPegAudio();
            AllStats.rainbowPegsHit += 1;

            if (Prestige.NP_Upgrade16Purchased == false)
            {
                int random;

                random = Random.Range(1, 5);

                if (random == 1) { levelScripts.StartRainbowBuff(1); }
                if (random == 2) { levelScripts.StartRainbowBuff(2); }
                if (random == 3) { levelScripts.StartRainbowBuff(3); }
                if (random == 4) { levelScripts.StartRainbowBuff(4); }
            }
            else
            {
                levelScripts.StartRainbowBuff(1);
                levelScripts.StartRainbowBuff(2);
                levelScripts.StartRainbowBuff(3);
                levelScripts.StartRainbowBuff(4);
            }

            if (Levels.isRainbowGoldBucket == true && Levels.isRainbowGoldPeg == true && Levels.isRainbowPRestige == true && Levels.isRainbowPRestigeBucket == true)
            { 
           
            }
            else
            {
               
            }
        }

        AllStats.totalPegsHit += 1;
        if (isRedPeg == true) { AllStats.redPegsHit += 1; }
        if (isBombPeg == true) { AllStats.bombPegsHit += 1; }
        if (isPurplePeg == true) { AllStats.purplePegHit += 1; }
    }

    public static Coroutine boardClearCoroutine;

    public void WaitForClearedBoard()
    {
        MainShooter.totalPegsHit = 0;
        MainShooter.totalPegs = 0;
        levelScripts.SetRandomBoard(false);
        AllStats.totalBoardsCleared += 1;
    }

    public void SetAllPegsIactive()
    {
        basicPeg.gameObject.SetActive(false);
        goldPeg.gameObject.SetActive(false);
        prestigePeg.gameObject.SetActive(false);
        redPeg.gameObject.SetActive(false);
        bombPeg.gameObject.SetActive(false);
        rainbowPeg.gameObject.SetActive(false);
        purplePeg.gameObject.SetActive(false);
    }
}
