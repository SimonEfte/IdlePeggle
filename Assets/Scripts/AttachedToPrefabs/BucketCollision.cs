using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BucketCollision : MonoBehaviour
{
    public SpriteRenderer bucketGlow1, bucketGlow2, bucketGlow3, bucketGlow4, bucketGlow5;
    public Coroutine glowCoroutine;
    public int glowNumber;
    public OverlappingSounds overlappingSounds;
    public static int bucketGoldClearCount;

    public GameObject chall;
    public Challenges challScript;

    public GameObject stats;
    public AllStats statsScript;

    public void Awake()
    {
        chall = GameObject.Find("ChallengesScriptExclude_Keep_MainGame");
        if(chall != null) { challScript = chall.GetComponent<Challenges>(); }

        stats = GameObject.Find("StatsScript");
        statsScript = stats.GetComponent<AllStats>();
    }

    private void OnDisable()
    {
        SetBucketGlow(bucketGlow1);
        SetBucketGlow(bucketGlow2);
        SetBucketGlow(bucketGlow3);
        SetBucketGlow(bucketGlow4);
        SetBucketGlow(bucketGlow5);

        StopAllCoroutines();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(challScript == true)
        {
            if (Challenges.challCompleted[20] == false && Challenges.challFinished[20] == false) { challScript.CheckCompleted(21, AllStats.totalBallsPit); }
            if (Challenges.challCompleted[21] == false && Challenges.challFinished[21] == false) { challScript.CheckCompleted(22, AllStats.totalBallsPit); }
            if (Challenges.challCompleted[22] == false && Challenges.challFinished[22] == false) { challScript.CheckCompleted(23, AllStats.totalBallsPit); }

            if (SettingsOptions.isInChallengeTab == true)
            {
                if (Challenges.challCompleted[20] == false && Challenges.challFinished[20] == false) { challScript.ChallengeProgress(21, AllStats.totalBallsPit); }
                if (Challenges.challCompleted[21] == false && Challenges.challFinished[21] == false) { challScript.ChallengeProgress(22, AllStats.totalBallsPit); }
                if (Challenges.challCompleted[22] == false && Challenges.challFinished[22] == false) { challScript.ChallengeProgress(23, AllStats.totalBallsPit); }
            }
        }

        if (Prestige.G_Upgrade19Purchased == true) { bucketGoldClearCount += 1; }
        if (Prestige.PU_Upgrade17Purchased == true) 
        {
            float random = Random.Range(0f, 100f);
            if(random < Prestige.prestigeBucketChance)
            {
                OnePrestigePoint();
            }
        }
        if(Prestige.NP_Upgrade8Purchased == true)
        {
            if (Levels.isRainbowPRestigeBucket == true)
            {
                float random = Random.Range(0f, 100f);
                if (random < Prestige.rainbowPegPrestigePointChance)
                {
                    OnePrestigePoint();
                }
            }
        }

        overlappingSounds.HitBucket();

        int randomGlow;

        do
        {
            randomGlow = Random.Range(1, 6);
        } while (randomGlow == glowNumber);

        glowNumber = randomGlow;

        if(glowNumber == 1) { StartCoroutine(BucketGlow(bucketGlow1)); }
        if (glowNumber == 2) { StartCoroutine(BucketGlow(bucketGlow2)); }
        if (glowNumber == 3) { StartCoroutine(BucketGlow(bucketGlow3)); }
        if (glowNumber == 4) { StartCoroutine(BucketGlow(bucketGlow4)); }
        if (glowNumber == 5) { StartCoroutine(BucketGlow(bucketGlow5)); }
    }

    public float textSpawnChance;

    public void OnePrestigePoint()
    {
        if (AllStats.greenPegChance > 43 && BallUpgrades.textSpawnChance < 25) { textSpawnChance = 0; }
        else { textSpawnChance = BallUpgrades.textSpawnChance; }

        float random2 = Random.Range(0f, 100f);

        if (random2 > textSpawnChance)
        {
            TextMeshProUGUI pegPointText = ObjectPool.instance.GetPrestigeTextFromPool();
            pegPointText.transform.position = gameObject.transform.position;
            pegPointText.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            pegPointText.GetComponent<Animation>().Play("PitTextAnim");

            if (Levels.isPRestigeRush == true)
            {
                pegPointText.text = "+3";
            }
            else
            {
                pegPointText.text = "+1";
            }
        }

        if(Levels.isPRestigeRush == true)
        {
            Prestige.prestigePoints += 3;
            AllStats.totalPRestigePoints += 3;
            AllStats.prestigePointsFromBucket += 3;
        }
        else
        {
            Prestige.prestigePoints += 1;
            AllStats.totalPRestigePoints += 1;
            AllStats.prestigePointsFromBucket += 1;
        }

        statsScript.DisplayPrestigePointStats();
    }

    IEnumerator BucketGlow(SpriteRenderer spriteRenderer)
    {
        // Set initial alpha to 0
        Color targetColor = spriteRenderer.color;
        targetColor.a = 0f;
        spriteRenderer.color = targetColor;

        // Fade in
        float duration = 0.2f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            targetColor.a = Mathf.Lerp(0f, 0.5f, timer / duration);
            spriteRenderer.color = targetColor;
            yield return null;
        }

        // Wait for 3 seconds
        yield return new WaitForSeconds(0.25f);

        // Fade out
        duration = 0.2f;
        timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            targetColor.a = Mathf.Lerp(0.5f, 0f, timer / duration);
            spriteRenderer.color = targetColor;
            yield return null;
        }
    }
    public void SetBucketGlow(SpriteRenderer spriteRenderer)
    {
        Color targetColor = spriteRenderer.color;
        targetColor.a = 0f;
        spriteRenderer.color = targetColor;
    }


}
