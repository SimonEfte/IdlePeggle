using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicBall : MonoBehaviour
{
    public GameObject ballUpgrades;
    public BallUpgrades ballUpgradeScript;
    public Collider2D objectCollider;
    public Rigidbody2D ballRigidbody;
    public float initialForce;
    public bool isBombBall, isAutoBombBall;
    public static int tinyBallsCount;
    public bool hitPegWithBomb;

    public GameObject bombIcon;
    public ParticleSystem bombParticle;

    public GameObject particleGlow;
    public ExecuteParticleSystems particleGlowScript;

    public GameObject sounds;
    public AudioManager audioManager;

    public GameObject overlappingSound;
    public OverlappingSounds overLappingScript;

    public GameObject pointsMechanics;
    public PointsMechanics pointsMechanicsScript;

    public GameObject chall;
    public Challenges challScript;
    public bool isChallActive;

    public bool isRegularBall, isBouncyBall, isRockBall, isTinyBall, isAquaBall, isMudBall, isBasketBall, isPlumBall, isStickyBall, isCandyBall, isCookieBall, isLimeBall, isGoldenBall, isFootball, isSharpnelBall, isZonicBall, isApricotBall, isPeggoBall, isGhostBall, isStarBall, isRainbowBall, isGlitchyBall, isTinySharpnel, isTinyRing, isTinyGlitchyBall;

    public static int ghostBallsOnScreen;
    public static int totalRainbowBallHitPegs;
    public int rainbowPegsHit;

    public bool spawnText;

    public void Awake()
    {
        maxTinyGlitchyBalls = 5;
        maxTinyRingBalls = 5;

        chall = GameObject.Find("ChallengesScriptExclude_Keep_MainGame");
        if (chall != null) { challScript = chall.GetComponent<Challenges>(); isChallActive = true; }

        pointsMechanics = GameObject.Find("AllPointsMechanics");
        pointsMechanicsScript = pointsMechanics.GetComponent<PointsMechanics>();

        overlappingSound = GameObject.Find("OverlappingSounds");
        overLappingScript = overlappingSound.GetComponent<OverlappingSounds>();

        sounds = GameObject.Find("Audio");
        audioManager = sounds.GetComponent<AudioManager>();

        particleGlow = GameObject.Find("ParticleSystems");
        particleGlowScript = particleGlow.GetComponent<ExecuteParticleSystems>();

        initialForce = 8f;
        objectCollider = GetComponent<Collider2D>();
        ballRigidbody = GetComponent<Rigidbody2D>();

        ballUpgrades = GameObject.Find("BallUpgrades");
        ballUpgradeScript = ballUpgrades.GetComponent<BallUpgrades>();

        if (gameObject.tag == "BombBall")
        {
            bombIcon = transform.Find("BombIcon").gameObject;
            bombParticle = transform.Find("BombParticle")?.GetComponent<ParticleSystem>();
            isBombBall = true;
        }

        if (gameObject.tag == "BasicBall") { isRegularBall = true; }
        else if (gameObject.tag == "RedBall") { isBouncyBall = true; }
        else if (gameObject.tag == "RockBall") { isRockBall = true; }
        else if (gameObject.tag == "TinyBall") { isTinyBall = true; }
    }

    public bool isColliderActive;

    public void OnEnable()
    {
        spawnText = false;
        hitBombPeg = false;
        tinyRingBallCount = 0;
        hitPurplePeg = false;
        pitIncrease = 0;
        goldenBallIncrease = 0;

        if (isGlitchyBall == true)
        {
            tinyGlitchyBallCount = 0;
            glitchyBallIncrease = 0;
            glitchyHitPegFirstTime = false;
        }

        if (isBasketBall == true)
        {
            basketBallIncrase = 0;
        }
       
        else if( isRainbowBall == true) { rainbowPegsHit = 0; }
        else if (isGlitchyBall == true) { rainbowPegsHit = 0; }

        isColliderActive = false;

        hitBucket = false; hitPit = false;
        hitPegWithBomb = false;

        if (isBombBall == true)
        {
            objectCollider.enabled = true; isColliderActive = true;
            bombIcon.transform.position = gameObject.transform.position;
            bombIcon.SetActive(true);
            ballRigidbody.constraints = RigidbodyConstraints2D.None;
        }
        else if(isTinyBall == true || isTinySharpnel == true || isTinyRing || isTinyGlitchyBall)
        {
            // Generate a random direction
            Vector2 randomDirection = Random.insideUnitCircle.normalized;

            // Apply the force to the ball
            ballRigidbody.AddForce(randomDirection * initialForce, ForceMode2D.Impulse);

            #region challenge stuff
            if (isChallActive == true)
            {
                if (isTinyBall == true)
                {
                    if (Challenges.challCompleted[24] == false && Challenges.challFinished[24] == false)
                    {
                        Challenges.tinyBallsCount += 1;
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(25, Challenges.tinyBallsCount);
                        }
                        challScript.CheckCompleted(25, Challenges.tinyBallsCount);
                    }
                }
                else if (isTinyRing == true)
                {
                    if (Challenges.challCompleted[30] == false && Challenges.challFinished[30] == false)
                    {
                        Challenges.tinyRingBallsCount += 1;
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(31, Challenges.tinyRingBallsCount);
                        }
                        challScript.CheckCompleted(31, Challenges.tinyRingBallsCount);
                    }
                }
                else if (isTinyGlitchyBall == true)
                {
                    Challenges.tinyGlitchyBallsSpawned += 1;
                    if (Challenges.challCompleted[35] == false && Challenges.challFinished[35] == false)
                    {
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(36, Challenges.tinyGlitchyBallsSpawned);
                        }
                        challScript.CheckCompleted(36, Challenges.tinyGlitchyBallsSpawned);
                    }
                }
                else if (isTinySharpnel == true)
                {
                    Challenges.tinySharpnelCount += 1;
                    if (Challenges.challCompleted[36] == false && Challenges.challFinished[36] == false)
                    {
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(37, Challenges.tinySharpnelCount);
                        }
                        challScript.CheckCompleted(37, Challenges.tinySharpnelCount);
                    }
                }
            }
            #endregion

        }

        #region points
        if (isBombBall == false)
        {
            isBombBall = false; isAutoBombBall = false;
        }

        if (isRegularBall == true)
        {
            ballPoints = BallUpgrades.regularBallGold;
        }
        else if (isBouncyBall == true)
        {
            ballPoints = BallUpgrades.redBallGold;
        }
        else if (isRockBall == true)
        {
            ballPoints = BallUpgrades.rockBallGold;
        }
        else if (isAquaBall == true)
        {
            ballPoints = BallUpgrades.aquaBallGold;
        }
        else if (isMudBall == true)
        {
            ballPoints = BallUpgrades.mudBallGold;
        }
        else if (isBasketBall == true)
        {
            SetBasketBallGold();
        }
        else if (isPlumBall == true)
        {
            ballPoints = BallUpgrades.plumBallGold;
        }
        else if (isStickyBall == true)
        {
            ballPoints = BallUpgrades.stickyBallGold;
        }
        else if (isCandyBall)
        {
            ballPoints = BallUpgrades.candyBallGold;
        }
        else if (isCookieBall)
        {
            ballPoints = BallUpgrades.cookieBallGold;
        }
        else if (isLimeBall)
        {
            ballPoints = BallUpgrades.limeBallGold;
        }
        else if (isGoldenBall)
        {
            ballPoints = BallUpgrades.goldenBallGold;
            originalGoldenBallGold = ballPoints;
        }
        else if (isFootball)
        {
            ballPoints = BallUpgrades.footballBallGold;
        }
        else if (isSharpnelBall)
        {
            ballPoints = BallUpgrades.sharpnelBallGold;
        }
        else if (isZonicBall)
        {
            ballPoints = BallUpgrades.zonicBallGold;
        }
        else if (isApricotBall)
        {
            ballPoints = BallUpgrades.apricotBallGold;
        }
        else if (isPeggoBall)
        {
            ballPoints = BallUpgrades.peggoBallGold;
        }
        else if (isGhostBall)
        {
            ghostBallsOnScreen += 1;

            if (isChallActive == true)
            {
                if (Challenges.challCompleted[32] == false && Challenges.challFinished[32] == false)
                {
                    if (SettingsOptions.isInChallengeTab == true)
                    {
                        challScript.ChallengeProgress(33, ghostBallsOnScreen);
                    }
                    challScript.CheckCompleted(33, ghostBallsOnScreen);
                }
            }

            ballPoints = BallUpgrades.ghostBallGold;
        }
        else if (isStarBall)
        {
            ballPoints = BallUpgrades.starBallGold;
        }
        else if (isRainbowBall)
        {
            ballPoints = BallUpgrades.rainbowBallGold;
        }
        else if (isGlitchyBall)
        {
            ghostBallsOnScreen += 1;
            SetGlitchyBallGold();
        }
        else if (isBombBall == true)
        {
            if (gameObject.layer == 9 || gameObject.layer == 16)
            {
                ballPoints = BallUpgrades.bombBallGold; objectCollider.enabled = true;
            }
            if (gameObject.layer == 15)
            {
                ballPoints = BallUpgrades.bombBallGold;
            }
        }
        else if (isTinyBall == true)
        {
            ballPoints = BallUpgrades.bombBallGold * BallUpgrades.tinyBallPercent;
        }
        else if (isTinySharpnel == true)
        {
            ballPoints = BallUpgrades.sharpnelBallGold * BallUpgrades.smallSharpnelGold;
        }
        else if (isTinyRing == true)
        {
            ballPoints = BallUpgrades.zonicBallGold * BallUpgrades.spawnedRingGold;
        }
        else if (isTinyGlitchyBall == true)
        {
            ballPoints = (BallUpgrades.glitchyBallGold * BallUpgrades.tinyBallPercent);
        }


        if(Prestige.NP_Upgrade26Purchased == true)
        {
            purpleBallPoints = ballPoints;
        }

        if (enhancedStartCount > 0) { enhancedStartCount -= 1; hitPurplePeg = true; }
        #endregion

        #region Check text pop up spawn
        if (PointsMechanics.popUpSliderNumber == 7) { spawnText = true; }
        else if (PointsMechanics.popUpSliderNumber == 1) { spawnText = false; }
        else
        {
            if(isGlitchyBall && PointsMechanics.spawnBall22Text == true) { spawnText = true; }
            else if (isRainbowBall && PointsMechanics.spawnBall21Text == true) { spawnText = true; }
            else if (isStarBall && PointsMechanics.spawnBall20Text == true) { spawnText = true; }
            else if (isGhostBall && PointsMechanics.spawnBall19Text == true) { spawnText = true; }
            else if (isPeggoBall && PointsMechanics.spawnBall18Text == true) { spawnText = true; }
            else if (isApricotBall && PointsMechanics.spawnBall17Text == true) { spawnText = true; }
            else if (isZonicBall && PointsMechanics.spawnBall16Text == true) { spawnText = true; }
            else if (isSharpnelBall && PointsMechanics.spawnBall15Text == true) { spawnText = true; }
            else if (isFootball && PointsMechanics.spawnBall14Text == true) { spawnText = true; }
            else if (isGoldenBall && PointsMechanics.spawnBall13Text == true) { spawnText = true; }
            else if (isLimeBall && PointsMechanics.spawnBall12Text == true) { spawnText = true; }
            else if (isCookieBall && PointsMechanics.spawnBall11Text == true) { spawnText = true; }
            else if (isCandyBall && PointsMechanics.spawnBall10Text == true) { spawnText = true; }
            else if (isStickyBall && PointsMechanics.spawnBall9Text == true) { spawnText = true; }
            else if (isPlumBall && PointsMechanics.spawnBall8Text == true) { spawnText = true; }
            else if (isBasketBall && PointsMechanics.spawnBall7Text == true) { spawnText = true; }
            else if (isMudBall && PointsMechanics.spawnBall6Text == true) { spawnText = true; }
            else if (isAquaBall && PointsMechanics.spawnBall5Text == true) { spawnText = true; }
            else if (isBombBall && PointsMechanics.spawnBall4Text == true) { spawnText = true; }
            else if (isRockBall && PointsMechanics.spawnBall3Text == true) { spawnText = true; }
            else if (isBouncyBall && PointsMechanics.spawnBall2Text == true) { spawnText = true; }
            else if (isRegularBall && PointsMechanics.spawnBall1Text == true) { spawnText = true; }
        }
        #endregion
    }

    public double purpleBallPoints;

    public double ballPoints;
    private string gameObjectName;
    public double originalGoldenBallGold;
    public bool glitchyHitPegFirstTime;

    public void SetBasketBallGold()
    {
        ballPoints = BallUpgrades.basketBallGold * (basketBallIncrase + 1);
    }

    public void SetGlitchyBallGold()
    {
        ballPoints = BallUpgrades.glitchyBallGold * (glitchyBallIncrease + 1);
    }

    public static int starBallPegsHit, glitchyBallStarbuffPegsHit;

    public Vector2 redPegPos;
    public bool stickyHitGreen;
    public float basketBallIncrase, glitchyBallIncrease;
    public bool hitPurplePeg;
    public int prestigePoints;
    public static int enhancedStartCount;
    public int maxTinyGlitchyBalls, maxTinyRingBalls, tinyGlitchyBallCount, tinyRingBallCount;
    public bool hitBombPeg; //lolTest
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            overLappingScript.HitGreenPegSound();
        }

        #region Hit Purple peg
        if (Prestige.NP_Upgrade26Purchased == true) 
        {
            if (collision.gameObject.layer == 22 && hitPurplePeg == false)
            {
                overLappingScript.HitPurplePeg();

                hitPurplePeg = true;
                if (Prestige.NP_Upgrade34Purchased == true)
                {
                    enhancedStartCount += 1;
                }
            } 
        }
        #endregion

        #region Glitchy ball hit pegs
        if (isGlitchyBall == true)
        {
            //Sticky is done
            //Cookie ball is done
            //Golden ball is done
            //Football is done
            //Ring ball intead gives bonus chances to shrapnel ball
            //Peggo ball is done

            //Bomb buff
            if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14 || collision.gameObject.layer == 21 || collision.gameObject.layer == 22)
            {
                if(glitchyHitPegFirstTime == false)
                {
                    SpawnTinyGlitchy();
                    SpawnTinyGlitchy();
                }
                glitchyHitPegFirstTime = true;

                int random1 = Random.Range(0, 100);

                if (random1 < (BallUpgrades.sharpnelChance1 - 10))
                {
                    if(tinyGlitchyBallCount < maxTinyGlitchyBalls) {  SpawnTinyGlitchy(); }
                }

                //Rainbow
                rainbowPegsHit += 1;
                totalRainbowBallHitPegs += 1;

                //Basketball
                glitchyBallIncrease += BallUpgrades.basketBallBonus;
                SetGlitchyBallGold();
            }

            //Sharpnel buff
            int random2 = Random.Range(0, 100);
            if (collision.gameObject.layer == 6)
            {
                if (random2 < (BallUpgrades.sharpnelChance2 - 1))
                {
                    if (tinyGlitchyBallCount < maxTinyGlitchyBalls) { SpawnTinyGlitchy(); }
                }
            }
        }
        #endregion

        #region Rainbow ball hit pegs
        if (isRainbowBall == true)
        {
            if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14 || collision.gameObject.layer == 21 || collision.gameObject.layer == 22)
            {
                rainbowPegsHit += 1;
                totalRainbowBallHitPegs += 1;

                if (isChallActive == true)
                {
                    if (Challenges.challCompleted[34] == false && Challenges.challFinished[34] == false)
                    {
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(35, (int)System.Math.Round(BallUpgrades.totalRainbowBallIncrease * 100));
                        }
                        challScript.CheckCompleted(35, (int)System.Math.Round(BallUpgrades.totalRainbowBallIncrease * 100));
                    }
                }
            }
        }
        #endregion

        #region Star ball hit pegs
        if (isStarBall == true)
        {
            if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14 || collision.gameObject.layer == 21 || collision.gameObject.layer == 22)
            {
                starBallPegsHit += 1;
                if (starBallPegsHit == BallUpgrades.starBallPegsHitNeeded)
                {
                    starBallPegsHit = 0;
                    ballUpgradeScript.SpawnStarBall();

                    if (isChallActive == true)
                    {
                        Challenges.starBallsSpawned += 1;
                        if (Challenges.challCompleted[33] == false && Challenges.challFinished[33] == false)
                        {
                            if (SettingsOptions.isInChallengeTab == true)
                            {
                                challScript.ChallengeProgress(34, Challenges.starBallsSpawned);
                            }
                            challScript.CheckCompleted(34, Challenges.starBallsSpawned);
                        }
                    }
                }
            }
        }
        #endregion

        #region Ring ball hit walls
        if (isZonicBall == true)
        {
            if (collision.gameObject.layer == 6)
            {
                int random = Random.Range(0,100);
                if (random < BallUpgrades.ringBallSpawnChance && tinyRingBallCount < maxTinyRingBalls)
                {
                    tinyRingBallCount += 1;
                    GameObject tinyRing = ObjectPool2.instance.GetTinyRingBallFromPool();
                    if (gameObject.layer == 9)
                    {
                        tinyRing.layer = 9;
                    }
                    else if (gameObject.layer == 15)
                    {
                        tinyRing.layer = 15;
                    }
                    else if (gameObject.layer == 16)
                    {
                        tinyRing.layer = 16;
                    }

                    tinyRing.transform.position = gameObject.transform.position;
                }
            }
        }
        #endregion

        #region Sharpnel hit pegs or walls
        if (isSharpnelBall == true)
        {
            int random1 = Random.Range(0, 100);
            int random2 = Random.Range(0, 100);

            if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14 || collision.gameObject.layer == 21 || collision.gameObject.layer == 22)
            {
                if (random1 < BallUpgrades.sharpnelChance1)
                {
                    SpawnTinySharpnelBall();
                }
            }
            else if (collision.gameObject.layer == 6)
            {
                if (random2 < BallUpgrades.sharpnelChance2)
                {
                    SpawnTinySharpnelBall();
                }
            }
        }
        #endregion

        #region Basketball hit pegs
        if (isBasketBall == true)
        {
            if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14 || collision.gameObject.layer == 21 || collision.gameObject.layer == 22)
            {
                basketBallIncrase += BallUpgrades.basketBallBonus;
                SetBasketBallGold();

                if (isChallActive == true)
                {
                    Challenges.basketBallPegHitCount += 1;
                    if (Challenges.challCompleted[25] == false && Challenges.challFinished[25] == false)
                    {
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(26, Challenges.basketBallPegHitCount);
                        }
                        challScript.CheckCompleted(26, Challenges.basketBallPegHitCount);
                    }
                }
            }
        }
        #endregion

        #region bomb hit Pegs
        if (isBombBall == true)
        {
            if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14 || collision.gameObject.layer == 21 || collision.gameObject.layer == 22)
            {
                if(hitPegWithBomb == false)
                {
                    ballRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                    bombIcon.SetActive(false);
                    hitPegWithBomb = true;
                    GameObject tinyBall1 = ObjectPool.instance.GetTinyBallFromPool();
                    GameObject tinyBall2 = ObjectPool.instance.GetTinyBallFromPool();
                    GameObject tinyBall3 = ObjectPool.instance.GetTinyBallFromPool();
                    GameObject tinyBall4 = ObjectPool.instance.GetTinyBallFromPool();

                    if(gameObject.layer == 9)
                    {
                        tinyBall1.layer = 9;
                        tinyBall2.layer = 9;
                        tinyBall3.layer = 9;
                        tinyBall4.layer = 9;
                    }
                    else if(gameObject.layer == 15)
                    {
                        tinyBall1.layer = 15;
                        tinyBall2.layer = 15;
                        tinyBall3.layer = 15;
                        tinyBall4.layer = 15;
                    }
                    else if (gameObject.layer == 16)
                    {
                        tinyBall1.layer = 16;
                        tinyBall2.layer = 16;
                        tinyBall3.layer = 16;
                        tinyBall4.layer = 16;
                    }

                    tinyBall1.transform.position = gameObject.transform.position;
                    tinyBall2.transform.position = gameObject.transform.position;
                    tinyBall3.transform.position = gameObject.transform.position;
                    tinyBall4.transform.position = gameObject.transform.position;

                    objectCollider.enabled = false;
                    bombParticle.Play();
                    int random = Random.Range(1,4);
                    if(random == 1) { audioManager.Play("Bomb1"); }
                    if (random == 2) { audioManager.Play("Bomb2"); }
                    if (random == 3) { audioManager.Play("Bomb3"); }
                    StartCoroutine(WaitForExplosion());
                }
            }
        }
        #endregion

        #region Gold Peg
        if (collision.gameObject.layer == 12)
        {
            if(isStickyBall == true || isGlitchyBall == true)
            {
                int random = Random.Range(0, 100);
                if (random < BallUpgrades.stickyBallDoubleGoldChance)
                {
                    if(hitPurplePeg == true) 
                    {
                        pointsMechanicsScript.SetGold(ballPoints, collision.transform.position, gameObject.layer, 2f + Prestige.purplePegIncrease, spawnText);
                    }
                    else
                    {
                        pointsMechanicsScript.SetGold(ballPoints, collision.transform.position, gameObject.layer, 2, spawnText); 
                    }

                    if (isChallActive == true)
                    {
                        Challenges.eggDoubleGoldCount += 1;
                        if (Challenges.challCompleted[26] == false && Challenges.challFinished[26] == false)
                        {
                            if (SettingsOptions.isInChallengeTab == true)
                            {
                                challScript.ChallengeProgress(27, Challenges.eggDoubleGoldCount);
                            }
                            challScript.CheckCompleted(27, Challenges.eggDoubleGoldCount);
                        }
                    }
                }
                else 
                {
                    if (hitPurplePeg == true) 
                    {
                        pointsMechanicsScript.SetGold(ballPoints, collision.transform.position, gameObject.layer, 0 + Prestige.purplePegIncrease, spawnText); 
                    }
                    else 
                    {
                        pointsMechanicsScript.SetGold(ballPoints, collision.transform.position, gameObject.layer, 0, spawnText); 
                    }
                }
            }
            else if (isGoldenBall == true || isGlitchyBall == true)
            { 
                SetBallGoldChance();
                if (hitPurplePeg == true) 
                {
                    pointsMechanicsScript.SetGold(ballPoints, collision.transform.position, gameObject.layer, goldenBallIncrease + Prestige.purplePegIncrease, spawnText); 
                }
                else 
                {
                    pointsMechanicsScript.SetGold(ballPoints, collision.transform.position, gameObject.layer, goldenBallIncrease, spawnText); 
                }
            }
            else
            {
                if (hitPurplePeg == true)
                { 
                    pointsMechanicsScript.SetGold(ballPoints, collision.transform.position, gameObject.layer, 0 + Prestige.purplePegIncrease, spawnText);
                }
                else 
                {
                    pointsMechanicsScript.SetGold(ballPoints, collision.transform.position, gameObject.layer, 0, spawnText); 
                }
            }
        
            overLappingScript.HitGoldPeg();
        }
        #endregion

        #region Prestige Peg
        if (collision.gameObject.layer == 13)
        {
            if(gameObject.layer == 9) { prestigePoints = Prestige.prestigePointsIncrease + Prestige.extraPrestigePoints; }
            else { prestigePoints = Prestige.prestigePointsIncrease; }

            overLappingScript.HitPrestigePeg();

            if(hitPurplePeg == false)
            {
                if (isCookieBall == false) { pointsMechanicsScript.HitPrestigePeg(prestigePoints, collision.transform.position, false, false, false); }
                if (isCookieBall == true || isGlitchyBall == true) { pointsMechanicsScript.HitPrestigePeg(prestigePoints, collision.transform.position, true, false, false); }
            }
            else
            {
                if (isCookieBall == false) { pointsMechanicsScript.HitPrestigePeg(prestigePoints, collision.transform.position, false, false, true); }
                if (isCookieBall == true || isGlitchyBall == true) { pointsMechanicsScript.HitPrestigePeg(prestigePoints, collision.transform.position, true, false, true); }
            }
         
        }
        #endregion

        #region Red Peg
        if (collision.gameObject.layer == 14)
        {
            redPegPos = collision.transform.position;
            if(gameObject != null) { StartCoroutine(HitRedPeg(redPegPos)); }
            overLappingScript.HitRedPeg();
        }
        #endregion

        #region Hit bomb peg
        if (Prestige.NP_Upgrade17Purchased == true)
        {
            if(isTinyBall == false && isTinyGlitchyBall == false && isTinyRing == false && isTinySharpnel == false)
            {
                if (collision.gameObject.layer == 21)
                {
                    if(hitBombPeg == false)
                    {
                        overLappingScript.HitBombPeg();
                        hitBombPeg = true;

                        int random = Random.Range(Prestige.bombBallBalls1, Prestige.bombBallBalls2);
                        for (int i = 0; i < random; i++)
                        {
                            GameObject ballToShoot = null;

                            if (isRegularBall == true) { ballToShoot = ObjectPool.instance.GetBasicBallFromPool(); }
                            else if (isBouncyBall == true) { ballToShoot = ObjectPool.instance.GetRedBallFromPool(); }
                            else if (isRockBall == true) { ballToShoot = ObjectPool.instance.GetRockBallFromPool(); ; }
                            else if (isBombBall == true) { ballToShoot = ObjectPool.instance.GetBombBallFromPool(); }
                            else if (isAquaBall == true) { ballToShoot = ObjectPool2.instance.GetAquaBallFromPool(); }
                            else if (isMudBall == true) { ballToShoot = ObjectPool2.instance.GetMudBallFromPool(); }
                            else if (isBasketBall == true) { ballToShoot = ObjectPool2.instance.GetBasketBallFromPool(); }
                            else if (isPlumBall == true) { ballToShoot = ObjectPool2.instance.GetPlumBallFromPool(); }
                            else if (isStickyBall == true) { ballToShoot = ObjectPool2.instance.GetStickyBallFromPool(); }
                            else if (isCandyBall == true) { ballToShoot = ObjectPool2.instance.GetCandyBallFromPool(); }
                            else if (isCookieBall == true) { ballToShoot = ObjectPool2.instance.GetCookieBallFromPool(); }
                            else if (isLimeBall == true) { ballToShoot = ObjectPool2.instance.GetLimeBallFromPool(); }
                            else if (isGoldenBall == true) { ballToShoot = ObjectPool2.instance.GetGoldenBallFromPool(); }
                            else if (isFootball == true) { ballToShoot = ObjectPool2.instance.GetFootballBallFromPool(); }
                            else if (isSharpnelBall == true) { ballToShoot = ObjectPool2.instance.GetSharpnelBallFromPool(); }
                            else if (isZonicBall == true) { ballToShoot = ObjectPool2.instance.GetZonicBallFromPool(); }
                            else if (isApricotBall == true) { ballToShoot = ObjectPool2.instance.GetApricotBallFromPool(); }
                            else if (isPeggoBall == true)
                            {
                                ballToShoot = ObjectPool2.instance.GetPeggoBallFromPool();
                            }
                            else if (isStarBall == true) { ballToShoot = ObjectPool2.instance.GetStarBallFromPool(); }
                            else if (isRainbowBall == true) { ballToShoot = ObjectPool2.instance.GetRainbowBallFromPool(); }
                            else if (isGlitchyBall == true)
                            {
                                ballToShoot = ObjectPool2.instance.GetGlitchyBallFromPool();
                            }

                            ballToShoot.transform.position = collision.transform.position;
                            if (isPeggoBall == true)
                            {
                                ballToShoot.layer = 19;
                            }
                            else if (isGlitchyBall == true)
                            {
                                ballToShoot.layer = 20;
                            }
                            else
                            {
                                if (gameObject.layer == 9) { ballToShoot.layer = 16; }
                                else { ballToShoot.layer = 15; }
                            }

                            BombPegSpawnBalls(ballToShoot);
                        }
                    }
                }
            }
        }
        #endregion

        #region Bounby ball challenge
        if (isBouncyBall == true)
        {
            if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14 || collision.gameObject.layer == 21 || collision.gameObject.layer == 22)
            {
                if (isChallActive == true)
                {
                    bouncyBallPegHit += 1;
                    if (bouncyBallPegHit > Challenges.redBallBounceCount) { Challenges.redBallBounceCount = bouncyBallPegHit; }

                    if (Challenges.challCompleted[23] == false && Challenges.challFinished[23] == false)
                    {
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(24, Challenges.redBallBounceCount);
                        }
                        challScript.CheckCompleted(24, Challenges.redBallBounceCount);
                    }
                }
            }
        }
        #endregion
    }

    public int bouncyBallPegHit;

    #region Hit Bomb Peg

    public void BombPegSpawnBalls(GameObject ball)
    {
        // Generate a random direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Apply the force to the ball
        ball.GetComponent<Rigidbody2D>().AddForce(randomDirection * 10, ForceMode2D.Impulse);
    }
    #endregion

    #region Spawn tiny glitchy
    public void SpawnTinyGlitchy()
    {
        tinyGlitchyBallCount += 1;
        GameObject tinyGlitchyBall = ObjectPool2.instance.GetTinyGlitchyBallFromPool();
        if (gameObject.layer == 9) { tinyGlitchyBall.layer = 9; }
        else { tinyGlitchyBall.layer = 15; }
        tinyGlitchyBall.transform.position = gameObject.transform.position;
    }
    #endregion

    #region Spawn tiny sharpnel
    public void SpawnTinySharpnelBall()
    {
        GameObject tinyShaprnel = ObjectPool2.instance.GetTinyShaprnelBallFromPool();
        if (gameObject.layer == 9)
        {
            tinyShaprnel.layer = 9;
        }
        else if (gameObject.layer == 15)
        {
            tinyShaprnel.layer = 15;
        }
        else if (gameObject.layer == 16)
        {
            tinyShaprnel.layer = 16;
        }

        tinyShaprnel.transform.position = gameObject.transform.position;
    }
    #endregion

    #region Set Golden Ball Chances
    public int goldenBallIncrease;
    public void SetBallGoldChance()
    {
        int random2X = Random.Range(0, 100);
        int random3X = Random.Range(0, 100);
        int random5X = Random.Range(0, 100);

        if (random2X < BallUpgrades.goldBallDoubleChance) { goldenBallIncrease = 2; MoreGoldFromGoldenBAlls(); }
        else if (random3X < BallUpgrades.goldBallTrippleChance) { goldenBallIncrease = 3; MoreGoldFromGoldenBAlls(); }
        else if (random5X < BallUpgrades.goldBall5XGold) { goldenBallIncrease = 5; MoreGoldFromGoldenBAlls(); }
        else { goldenBallIncrease = 0; }
    }
    #endregion

    public void MoreGoldFromGoldenBAlls()
    {
        if (isChallActive == true)
        {
            Challenges.goldenBallExtraCount += 1;
            if (Challenges.challCompleted[28] == false && Challenges.challFinished[28] == false)
            {
                if (SettingsOptions.isInChallengeTab == true)
                {
                    challScript.ChallengeProgress(29, Challenges.goldenBallExtraCount);
                }
                challScript.CheckCompleted(29, Challenges.goldenBallExtraCount);
            }
        }
    }

    public bool hitBucket, hitPit;
    public int ballEnteredPit;
    public int pitIncrease;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 18)
        {
            return;
        }
        if (isGhostBall == true)
        {
            if (collision.gameObject.layer == 6 || collision.gameObject.layer == 5 || collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14 || collision.gameObject.layer == 21 || collision.gameObject.layer == 22)
            {
                return;
            }
        }

        //totalBallShots

        #region Bucket
        if (collision.gameObject.layer == 8)
        {
            if(isFootball == true)
            {
                if (isChallActive == true)
                {
                    Challenges.footballBucketCount += 1;
                    if (Challenges.challCompleted[29] == false && Challenges.challFinished[29] == false)
                    {
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(30, Challenges.footballBucketCount);
                        }
                        challScript.CheckCompleted(30, Challenges.footballBucketCount);
                    }
                }
            }

            if(hitBucket == false)
            {
                bool isFootballll = false;
                if(isFootball == true || isGlitchyBall) { isFootballll = true; }
                else if(isGoldenBall == true) { SetBallGoldChance(); }
               
                if(hitPurplePeg == true) { pointsMechanicsScript.SetBucket(ballPoints, collision.transform.position, gameObject.layer, goldenBallIncrease + Prestige.purplePegIncrease, isFootballll, spawnText); }
                else { pointsMechanicsScript.SetBucket(ballPoints, collision.transform.position, gameObject.layer, goldenBallIncrease, isFootballll, spawnText); }
                hitBucket = true;

                if(hitPurplePeg == true)
                {
                    if (AllStats.greenPegChance > 43 && BallUpgrades.textSpawnChance < 25) { textSpawnChance = 0; }
                    else { textSpawnChance = BallUpgrades.textSpawnChance; }

                    float random2 = Random.Range(0f, 100f);

                    if (random2 > textSpawnChance)
                    {
                        TextMeshProUGUI pegPointText = ObjectPool.instance.GetPrestigeTextFromPool();
                        pegPointText.transform.position = collision.transform.position;
                        pegPointText.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                        pegPointText.GetComponent<Animation>().Play("PitTextAnim");

                        if (Levels.isPRestigeRush == false)
                        {
                            pegPointText.text = "+1";
                        }
                        else
                        {
                            pegPointText.text = "+3";
                        }
                    }

                    if (Levels.isPRestigeRush == false)
                    {
                        Prestige.prestigePoints += 1;
                    }
                    else
                    {
                        Prestige.prestigePoints += 3;
                    }
                }
            }
        }

        if(hitBucket == false)
        {
            if (collision.gameObject.layer == 10)
            {
                if (hitPit == false)
                {
                    hitPit = true;
                }
            }
        }
        #endregion

        #region Return to pool
        if (hitPit == false || hitBucket == false)
        {
            hitPit = true; hitBucket = true;
            if (isRegularBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball1MS += 1;
                    if(Prestige.ball1MS == Prestige.totalBallShots)
                    {
                        Prestige.ball1MS = 0;
                        MainShooter.basicBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 1) { ballUpgradeScript.SetActiveBalls(MainShooter.basicBallsAvailable); }
                    }
                }

                ObjectPool.instance.ReturnBasicBallFromPool(gameObject);
            }
            else if (isBouncyBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball2MS += 1;
                    if (Prestige.ball2MS == Prestige.totalBallShots)
                    {
                        Prestige.ball2MS = 0;
                        MainShooter.redBallsAviable += 1;
                        if (BallUpgrades.ballNumberEquipped == 2) { ballUpgradeScript.SetActiveBalls(MainShooter.redBallsAviable); }
                    }
                }
                bouncyBallPegHit = 0;
                ObjectPool.instance.ReturnRedBallFromPool(gameObject);
            }
            else if (isRockBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball3MS += 1;
                    if (Prestige.ball3MS == Prestige.totalBallShots)
                    {
                        Prestige.ball3MS = 0;
                        MainShooter.rockBallsAviable += 1;
                        if (BallUpgrades.ballNumberEquipped == 3) { ballUpgradeScript.SetActiveBalls(MainShooter.rockBallsAviable); }
                    }
                }
                ObjectPool.instance.ReturnRockBallFromPool(gameObject);
            }
            else if (isBombBall == true)
            {
                if (gameObject.layer == 9)
                {
                    int leftOver = 0;
                    tinyBallsCount += 4;
                    if (tinyBallsCount >= (4 * Prestige.totalBallShots)) 
                    {
                        leftOver = tinyBallsCount - (4 * Prestige.totalBallShots);
                        MainShooter.bombBallsAviable += 1; tinyBallsCount = leftOver; 
                    }
                    if (BallUpgrades.ballNumberEquipped == 4) { ballUpgradeScript.SetActiveBalls(MainShooter.bombBallsAviable); }
                }
                ObjectPool.instance.ReturnBombBallFromPool(gameObject);
            }
            else if (isAquaBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball5MS += 1;
                    if (Prestige.ball5MS == Prestige.totalBallShots)
                    {
                        Prestige.ball5MS = 0;
                        MainShooter.aquaBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 5) { ballUpgradeScript.SetActiveBalls(MainShooter.aquaBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnAquaBallFromPool(gameObject);
            }
            else if (isMudBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball6MS += 1;
                    if (Prestige.ball6MS == Prestige.totalBallShots)
                    {
                        Prestige.ball6MS = 0;
                        MainShooter.mudBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 6) { ballUpgradeScript.SetActiveBalls(MainShooter.mudBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnMudBallFromPool(gameObject);
            }
            else if (isBasketBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball7MS += 1;
                    if (Prestige.ball7MS == Prestige.totalBallShots)
                    {
                        Prestige.ball7MS = 0;
                        MainShooter.basketBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 7) { ballUpgradeScript.SetActiveBalls(MainShooter.basketBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnBasketBallFromPool(gameObject);
            }
            else if (isPlumBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball8MS += 1;
                    if (Prestige.ball8MS == Prestige.totalBallShots)
                    {
                        Prestige.ball8MS = 0;
                        MainShooter.plumBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 8) { ballUpgradeScript.SetActiveBalls(MainShooter.plumBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnPlumBallFromPool(gameObject);
            }
            else if (isStickyBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball9MS += 1;
                    if (Prestige.ball9MS == Prestige.totalBallShots)
                    {
                        Prestige.ball9MS = 0;
                        MainShooter.stickyBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 9) { ballUpgradeScript.SetActiveBalls(MainShooter.stickyBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnStickyBallFromPool(gameObject);
            }
            else if (isCandyBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball10MS += 1;
                    if (Prestige.ball10MS == Prestige.totalBallShots)
                    {
                        Prestige.ball10MS = 0;
                        MainShooter.candyBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 10) { ballUpgradeScript.SetActiveBalls(MainShooter.candyBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnCandyBallFromPool(gameObject);
            }
            else if (isCookieBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball11MS += 1;
                    if (Prestige.ball11MS == Prestige.totalBallShots)
                    {
                        Prestige.ball11MS = 0;
                        MainShooter.cookieBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 11) { ballUpgradeScript.SetActiveBalls(MainShooter.cookieBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnCookieBallFromPool(gameObject);
            }
            else if (isLimeBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball12MS += 1;
                    if (Prestige.ball12MS == Prestige.totalBallShots)
                    {
                        Prestige.ball12MS = 0;
                        MainShooter.limeBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 12) { ballUpgradeScript.SetActiveBalls(MainShooter.limeBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnLimeBallFromPool(gameObject);
            }
            else if (isGoldenBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball13MS += 1;
                    if (Prestige.ball13MS == Prestige.totalBallShots)
                    {
                        Prestige.ball13MS = 0;
                        MainShooter.goldenBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 13) { ballUpgradeScript.SetActiveBalls(MainShooter.goldenBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnGoldenBallFromPool(gameObject);
            }
            else if (isFootball == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball14MS += 1;
                    if (Prestige.ball14MS == Prestige.totalBallShots)
                    {
                        Prestige.ball14MS = 0;
                        MainShooter.footballBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 14) { ballUpgradeScript.SetActiveBalls(MainShooter.footballBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnFootballBallFromPool(gameObject);
            }
            else if (isSharpnelBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball15MS += 1;
                    if (Prestige.ball15MS == Prestige.totalBallShots)
                    {
                        Prestige.ball15MS = 0;
                        MainShooter.sharpnelBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 15) { ballUpgradeScript.SetActiveBalls(MainShooter.sharpnelBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnSharpnelBallFromPool(gameObject);
            }
            else if (isZonicBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball16MS += 1;
                    if (Prestige.ball16MS == Prestige.totalBallShots)
                    {
                        Prestige.ball16MS = 0;
                        MainShooter.zonicBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 16) { ballUpgradeScript.SetActiveBalls(MainShooter.zonicBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnZonicBallFromPool(gameObject);
            }
            else if (isApricotBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball17MS += 1;
                    if (Prestige.ball17MS == Prestige.totalBallShots)
                    {
                        Prestige.ball17MS = 0;
                        MainShooter.apricotBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 17) { ballUpgradeScript.SetActiveBalls(MainShooter.apricotBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnApricotBallFromPool(gameObject);
            }
            else if (isPeggoBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball18MS += 1;
                    if (Prestige.ball18MS == Prestige.totalBallShots)
                    {
                        Prestige.ball18MS = 0;
                        MainShooter.peggoBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 18) { ballUpgradeScript.SetActiveBalls(MainShooter.peggoBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnPeggoBallFromPool(gameObject);
            }
            else if (isGhostBall == true)
            {
                ghostBallsOnScreen -= 1;
                if (gameObject.layer == 9)
                {
                    Prestige.ball19MS += 1;
                    if (Prestige.ball19MS == Prestige.totalBallShots)
                    {
                        Prestige.ball19MS = 0;
                        MainShooter.ghostBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 19) { ballUpgradeScript.SetActiveBalls(MainShooter.ghostBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnGhostBallFromPool(gameObject);
            }
            else if (isStarBall == true)
            {
                if (gameObject.layer == 9)
                {
                    Prestige.ball20MS += 1;
                    if (Prestige.ball20MS == Prestige.totalBallShots)
                    {
                        Prestige.ball20MS = 0;
                        MainShooter.starBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 20) { ballUpgradeScript.SetActiveBalls(MainShooter.starBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnStarBallFromPool(gameObject);
            }
            else if (isRainbowBall == true)
            {
                totalRainbowBallHitPegs -= rainbowPegsHit;
                rainbowPegsHit = 0;
                if (gameObject.layer == 9)
                {
                    Prestige.ball21MS += 1;
                    if (Prestige.ball21MS == Prestige.totalBallShots)
                    {
                        Prestige.ball21MS = 0;
                        MainShooter.rainbowBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 21) { ballUpgradeScript.SetActiveBalls(MainShooter.rainbowBallsAvailable); }
                    }
                }

                BallUpgrades.totalRainbowBallIncrease = totalRainbowBallHitPegs * BallUpgrades.rainbowBallGoldIncrease;

                if (isChallActive == true)
                {
                    if (Challenges.challCompleted[34] == false && Challenges.challFinished[34] == false)
                    {
                        if (SettingsOptions.isInChallengeTab == true)
                        {
                            challScript.ChallengeProgress(35, (int)System.Math.Round(BallUpgrades.totalRainbowBallIncrease * 100));
                        }
                        challScript.CheckCompleted(35, (int)System.Math.Round(BallUpgrades.totalRainbowBallIncrease * 100));
                    }
                }
              
                ObjectPool2.instance.ReturnRainbowBallFromPool(gameObject);
            }
            else if (isGlitchyBall == true)
            {
                ghostBallsOnScreen -= 1;
                totalRainbowBallHitPegs -= rainbowPegsHit;
                rainbowPegsHit = 0;

                if (gameObject.layer == 9)
                {
                    Prestige.ball22MS += 1;
                    if (Prestige.ball22MS == Prestige.totalBallShots)
                    {
                        Prestige.ball22MS = 0;
                        MainShooter.glitchyBallsAvailable += 1;
                        if (BallUpgrades.ballNumberEquipped == 22) { ballUpgradeScript.SetActiveBalls(MainShooter.glitchyBallsAvailable); }
                    }
                }
                ObjectPool2.instance.ReturnGlitchyBallFromPool(gameObject);
            }
            else if (isTinyBall == true)
            {
                if (gameObject.layer == 9)
                {
                    int leftOver = 0;
                    tinyBallsCount += 1;
                    if (tinyBallsCount >= (4 * Prestige.totalBallShots))
                    {
                        leftOver = tinyBallsCount - (4 * Prestige.totalBallShots);
                        MainShooter.bombBallsAviable += 1; tinyBallsCount = leftOver;
                    }
                    if (BallUpgrades.ballNumberEquipped == 4) { ballUpgradeScript.SetActiveBalls(MainShooter.bombBallsAviable); }
                }
                ObjectPool.instance.ReturnTinyBallFromPool(gameObject);
            }
            else if (isTinyGlitchyBall == true)
            {
                ObjectPool2.instance.ReturnTinyGlitchyBallFromPool(gameObject);
            }
            else if (isTinySharpnel == true)
            {
                ObjectPool2.instance.ReturnTinyShaprnelBallFromPool(gameObject);
            }
            else if (isTinyRing == true)
            {
                ObjectPool2.instance.ReturnTinyRingBallFromPool(gameObject);
            }
        }
        #endregion
    }

    public float textSpawnChance;

    #region Hit Red Peg
    IEnumerator HitRedPeg(Vector2 pos)
    {
        overLappingScript.HitPrestigePeg();

        if(Prestige.NP_Upgrade6Purchased == true) { pointsMechanicsScript.SetGold(ballPoints, pos, gameObject.layer, 2, spawnText); }
        else { pointsMechanicsScript.SetGold(ballPoints, pos, gameObject.layer, 0, spawnText); }
     
        yield return new WaitForSeconds(0.095f);
        if (Prestige.NP_Upgrade7Purchased == true) { pointsMechanicsScript.HitPrestigePeg(Prestige.prestigePointsIncrease, pos, false, true, false); }
        else { pointsMechanicsScript.HitPrestigePeg(Prestige.prestigePointsIncrease, pos, false, false, false); }
    }
    #endregion

    IEnumerator WaitForExplosion()
    {
        yield return new WaitForSeconds(0.7f);
        ObjectPool.instance.ReturnBombBallFromPool(gameObject);
    }
}
