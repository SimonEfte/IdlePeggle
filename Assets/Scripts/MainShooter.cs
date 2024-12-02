using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainShooter : MonoBehaviour
{
    public float launchForce;
    public Transform shotPoint;
    public Transform shotPointS2_1, shotPointS2_2, shotPointS3_1, shotPointS3_2, shotPointS3_3, shotPointS4_1, shotPointS4_2, shotPointS4_3, shotPointS4_4, shotPointS5_1, shotPointS5_2, shotPointS5_3, shotPointS5_4, shotPointS5_5;

    public GameObject ballPoint, ballAim;
    public GameObject allBallPoints, allBallPoints2, allBallPoints3, allBallPoints4, allBallPoints5;
    public GameObject[] ballPoints, ballPoints2, ballPoints3, ballPoints4, ballPoints5;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    public Transform pointParent, pointParent2, pointParent3, pointParent4, pointParent5;

    Vector2 direction, aimDirection;

    public static int basicBallsAvailable, redBallsAviable, rockBallsAviable, bombBallsAviable, aquaBallsAvailable, mudBallsAvailable, basketBallsAvailable, plumBallsAvailable, stickyBallsAvailable, candyBallsAvailable,cookieBallsAvailable,limeBallsAvailable,goldenBallsAvailable, footballBallsAvailable, sharpnelBallsAvailable, zonicBallsAvailable, apricotBallsAvailable,peggoBallsAvailable, ghostBallsAvailable,starBallsAvailable,rainbowBallsAvailable, glitchyBallsAvailable;

    public static int totalPegs;
    public static int totalPegsHit;

    public BallUpgrades ballUpgradesScript;

    public AudioManager audioManager;
    public AllStats statsScript;
    public OverlappingSounds overlappingSoundsScript;

    public void Start()
    {
        StartCoroutine(Wait());
    }

    public GameObject shooter1, shooters2, shooters3, shooters4, shooters5;
    public bool isLoaded;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);

        pointParent.gameObject.SetActive(false);
        if (Prestige.moreShots1Purchased == true) { pointParent2.gameObject.SetActive(false); }
        if (Prestige.moreShots2Purchased == true) { pointParent3.gameObject.SetActive(false); }
        if (Prestige.moreShots3Purchased == true) { pointParent4.gameObject.SetActive(false); }
        if (Prestige.moreShots4Purchased == true) { pointParent5.gameObject.SetActive(false); }

        SetBallPoints();

        startAuto = true;
        startAutoRedBall = true;
        startAutoRockBall = true;
        startAutoBombBall = true;

        if(GameData.isDemo == false)
        {
            startAutoAquaBall = true;
            startAutoMudBall = true;
            startAutoBasketBall = true;
            startAutoPlumBall = true;
            startAutoStickyBall = true;
            startAutoCandyBall = true;
            startAutoCookieBall = true;
            startAutoLimeBall = true;
            startAutoGoldenBall = true;
            startAutoFootballBall = true;
            startAutoShrapnelBall = true;
            startAutoZonicBall = true;
            startAutoApricotBall = true;
            startAutoPeggoBall = true;
            startAutoGhostBall = true;
            startAutoStarBall = true;
            startAutoRainbowBall = true;
            startAutoGlitchyBall = true;
        }
     
        basicBallsAvailable = BallUpgrades.totalRegularBalls;
        redBallsAviable = BallUpgrades.totalRedBalls;
        rockBallsAviable = BallUpgrades.totalRockBalls;
        bombBallsAviable = BallUpgrades.totalBombBalls;

        if(GameData.isDemo == false)
        {
            aquaBallsAvailable = BallUpgrades.totalAquaBalls;
            mudBallsAvailable = BallUpgrades.totalMudBalls;
            basketBallsAvailable = BallUpgrades.totalBasketBalls;
            plumBallsAvailable = BallUpgrades.totalPlumBalls;
            stickyBallsAvailable = BallUpgrades.totalStickyBalls;
            candyBallsAvailable = BallUpgrades.totalCandyBalls;
            cookieBallsAvailable = BallUpgrades.totalCookieBalls;
            limeBallsAvailable = BallUpgrades.totalLimeBalls;
            goldenBallsAvailable = BallUpgrades.totalGoldenBalls;
            footballBallsAvailable = BallUpgrades.totalFootballBalls;
            sharpnelBallsAvailable = BallUpgrades.totalSharpnelBalls;
            zonicBallsAvailable = BallUpgrades.totalZonicBalls;
            apricotBallsAvailable = BallUpgrades.totalApricotBalls;
            peggoBallsAvailable = BallUpgrades.totalPeggoBalls;
            ghostBallsAvailable = BallUpgrades.totalGhostBalls;
            starBallsAvailable = BallUpgrades.totalStarBalls;
            rainbowBallsAvailable = BallUpgrades.totalRainbowBalls;
            glitchyBallsAvailable = BallUpgrades.totalGlitchyBalls;
        }
      
        isLoaded = true;
    }
    public bool setShooter1, setShooter2, setShooter3, setShooter4, setShooter5;

    public void SetBallPoints()
    {
        shooter1.SetActive(false);
        shooters2.SetActive(false);
        shooters3.SetActive(false);
        shooters4.SetActive(false);
        shooters5.SetActive(false);

        if (Prestige.totalBallShots == 2) { shooters2.SetActive(true); }
        if (Prestige.totalBallShots == 1) { shooter1.SetActive(true); }
        if (Prestige.totalBallShots == 3) { shooters3.SetActive(true); }
        if (Prestige.totalBallShots == 4) { shooters4.SetActive(true); }
        if (Prestige.totalBallShots == 5) { shooters5.SetActive(true); }

        #region Set points
        if (Prestige.totalBallShots == 1) 
        {
            if (setShooter1 == false)
            {
               
                ballPoints = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    setShooter1 = true;
                    ballPoints[i] = Instantiate(ballPoint, shotPoint.position, Quaternion.identity);
                    ballPoints[i].transform.SetParent(pointParent);
                    ballPoints[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }
        }
        if (Prestige.totalBallShots == 2)
        {
            if (setShooter1 == false)
            {
                ballPoints = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    setShooter1 = true;
                    ballPoints[i] = Instantiate(ballPoint, shotPoint.position, Quaternion.identity);
                    ballPoints[i].transform.SetParent(pointParent);
                    ballPoints[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if(setShooter2 == false)
            {
                ballPoints2 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    setShooter2 = true;
                    ballPoints2[i] = Instantiate(ballPoint, shotPointS2_2.position, Quaternion.identity);
                    ballPoints2[i].transform.SetParent(pointParent2);
                    ballPoints2[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }
        }
        if (Prestige.totalBallShots == 3)
        {
            if (setShooter1 == false)
            {
                ballPoints = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    setShooter1 = true;
                    ballPoints[i] = Instantiate(ballPoint, shotPoint.position, Quaternion.identity);
                    ballPoints[i].transform.SetParent(pointParent);
                    ballPoints[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter2 == false)
            {
                ballPoints2 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    setShooter2 = true;
                    ballPoints2[i] = Instantiate(ballPoint, shotPointS2_2.position, Quaternion.identity);
                    ballPoints2[i].transform.SetParent(pointParent2);
                    ballPoints2[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter3 == false)
            {
                setShooter3 = true;
                ballPoints3 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    ballPoints3[i] = Instantiate(ballPoint, shotPointS3_3.position, Quaternion.identity);
                    ballPoints3[i].transform.SetParent(pointParent3);
                    ballPoints3[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }
        }
        if (Prestige.totalBallShots == 4)
        {
            if (setShooter1 == false)
            {
                ballPoints = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    setShooter1 = true;
                    ballPoints[i] = Instantiate(ballPoint, shotPoint.position, Quaternion.identity);
                    ballPoints[i].transform.SetParent(pointParent);
                    ballPoints[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter2 == false)
            {
                setShooter2 = true;
                ballPoints2 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    ballPoints2[i] = Instantiate(ballPoint, shotPointS2_2.position, Quaternion.identity);
                    ballPoints2[i].transform.SetParent(pointParent2);
                    ballPoints2[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter3 == false)
            {
                setShooter3 = true;
                ballPoints3 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    ballPoints3[i] = Instantiate(ballPoint, shotPointS3_3.position, Quaternion.identity);
                    ballPoints3[i].transform.SetParent(pointParent3);
                    ballPoints3[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter4 == false)
            {
                setShooter4 = true;
                ballPoints4 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    ballPoints4[i] = Instantiate(ballPoint, shotPointS4_4.position, Quaternion.identity);
                    ballPoints4[i].transform.SetParent(pointParent4);
                    ballPoints4[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }
        }
        if (Prestige.totalBallShots == 5) 
        {
            if (setShooter1 == false)
            {
                ballPoints = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    setShooter1 = true;
                    ballPoints[i] = Instantiate(ballPoint, shotPoint.position, Quaternion.identity);
                    ballPoints[i].transform.SetParent(pointParent);
                    ballPoints[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter2 == false)
            {
                setShooter2 = true;
                ballPoints2 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    ballPoints2[i] = Instantiate(ballPoint, shotPointS2_2.position, Quaternion.identity);
                    ballPoints2[i].transform.SetParent(pointParent2);
                    ballPoints2[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter3 == false)
            {
                setShooter3 = true;
                ballPoints3 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    ballPoints3[i] = Instantiate(ballPoint, shotPointS3_3.position, Quaternion.identity);
                    ballPoints3[i].transform.SetParent(pointParent3);
                    ballPoints3[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter4 == false)
            {
                setShooter4 = true;
                ballPoints4 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    ballPoints4[i] = Instantiate(ballPoint, shotPointS4_4.position, Quaternion.identity);
                    ballPoints4[i].transform.SetParent(pointParent4);
                    ballPoints4[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }

            if (setShooter5 == false)
            {
                ballPoints5 = new GameObject[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    setShooter5 = true;
                    ballPoints5[i] = Instantiate(ballPoint, shotPointS5_5.position, Quaternion.identity);
                    ballPoints5[i].transform.SetParent(pointParent5);
                    ballPoints5[i].transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                }
            }
        }
        #endregion
    }

    public bool startAuto, startAutoRedBall, startAutoRockBall, startAutoBombBall, startAutoAquaBall, startAutoMudBall, startAutoBasketBall, startAutoPlumBall, startAutoStickyBall;
    public bool startAutoCandyBall;
    public bool startAutoCookieBall;
    public bool startAutoLimeBall;
    public bool startAutoGoldenBall;
    public bool startAutoFootballBall;
    public bool startAutoShrapnelBall;
    public bool startAutoZonicBall;
    public bool startAutoApricotBall;
    public bool startAutoPeggoBall;
    public bool startAutoGhostBall;
    public bool startAutoStarBall;
    public bool startAutoRainbowBall;
    public bool startAutoGlitchyBall;

    public ParticleSystem smoke1, smoke2Shots_1, smoke2Shots_2, smoke3Shots_1, smoke3Shots_2, smoke3Shots_3, smoke4Shots_1, smoke4Shots_2, smoke4Shots_3, smoke4Shots_4, smoke5Shots_1, smoke5Shots_2, smoke5Shots_3, smoke5Shots_4, smoke5Shots_5;
    public GameObject aimObject;
    private bool isKnockback;

    public GameObject debugIndicator;

    public void SetIndicatorInactive()
    {
        debugIndicator.SetActive(false);
    }

    void Update()
    {
        if (SetAimOfAnOn.isHoveringBoard == true && Levels.isFullFillShooting == false)
        {
            pointParent.gameObject.SetActive(true);
            if (Prestige.moreShots1Purchased == true) { pointParent2.gameObject.SetActive(true); }
            if (Prestige.moreShots2Purchased == true) { pointParent3.gameObject.SetActive(true); }
            if (Prestige.moreShots3Purchased == true) { pointParent4.gameObject.SetActive(true); }
            if (Prestige.moreShots4Purchased == true) { pointParent5.gameObject.SetActive(true); }
            //ballAim.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 aimPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - aimPosition;

            transform.right = direction;
        }


        if (Levels.isFullFillShooting == true)
        {
            allBallPoints.gameObject.SetActive(false);
            if (Prestige.moreShots1Purchased == true) { pointParent2.gameObject.SetActive(false); }
            if (Prestige.moreShots2Purchased == true) { pointParent3.gameObject.SetActive(false); }
            if (Prestige.moreShots3Purchased == true) { pointParent4.gameObject.SetActive(false); }
            if (Prestige.moreShots4Purchased == true) { pointParent5.gameObject.SetActive(false); }
        }


        if (!Input.GetMouseButton(0))
        {
            if(isCoroutinePlaying == true) 
            {
                if (shootingCoroutine != null)
                {
                    StopCoroutine(shootingCoroutine);
                    shootingCoroutine = null;
                }
            }

            startCount = 0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (SetAimOfAnOn.isHoveringBoard)
            {
                ShootBall();
                // Start the coroutine when the mouse button is pressed and hovering over the board
                if(shootingCoroutine == null) { shootingCoroutine = StartCoroutine(ShootBallCoroutine()); }
            }
        }

        if (Input.GetMouseButtonUp(0) || AudioOptionsManager.altTabbed == true)
        {
            AudioOptionsManager.altTabbed = false;
            // Stop the coroutine when the mouse button is released
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
                startCount = 0f;
                isCoroutinePlaying = false;
            }
        }

        if (isLoaded == true)
        {
            if(Prestige.isPrestiged == false)
            {
                #region Set aim points
                if (Prestige.totalBallShots == 1)
                {
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPoint);
                    }
                }
                if (Prestige.totalBallShots == 2)
                {
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS2_1);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints2[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS2_2);
                    }
                }
                if (Prestige.totalBallShots == 3)
                {
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS3_1);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints2[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS3_2);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints3[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS3_3);
                    }
                }
                if (Prestige.totalBallShots == 4)
                {
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS4_1);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints2[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS4_2);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints3[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS4_3);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints4[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS4_4);
                    }
                }
                if (Prestige.totalBallShots == 5)
                {
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS5_1);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints2[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS5_2);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints3[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS5_3);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints4[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS5_4);
                    }
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        ballPoints5[i].transform.position = PointsPosition(i * spaceBetweenPoints, shotPointS5_5);
                    }
                }
                #endregion
            }
        }
    }

    public float startCount;
    private Coroutine shootingCoroutine;
    public bool isCoroutinePlaying;

    private IEnumerator ShootBallCoroutine()
    {
        isCoroutinePlaying = true;

        while (true)
        {
            startCount += 2.5f;

            if (startCount >= 20f)
            {
                startCount = 0f;
                ShootBall();
            }

            // Wait for a short period before the next increment
            yield return new WaitForSeconds(0.015f); // This interval can be adjusted
        }
    }

    public void ResetMoreShots()
    {
        shooter1.SetActive(true);
        shooters2.SetActive(false);
        shooters3.SetActive(false);
        shooters4.SetActive(false);
        shooters5.SetActive(false);

        pointParent2.gameObject.SetActive(false); 
        pointParent3.gameObject.SetActive(false); 
        pointParent4.gameObject.SetActive(false); 
        pointParent5.gameObject.SetActive(false); 
    }

    #region Shooter KnockBack
    IEnumerator MainShooterKnockback()
    {
        Vector2 originalPosition = aimObject.transform.localPosition;

        // Create a new Vector2 with only the X-component modified
        Vector2 backwardPosition = new Vector2(originalPosition.x - 1 * 13, originalPosition.y);

        float elapsedTime = 0f;
        float duration = 0.08f; // Adjust the duration of each movement

        while (elapsedTime < duration)
        {
            aimObject.transform.localPosition = Vector2.Lerp(originalPosition, backwardPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure aimObject is exactly at the backward position
        aimObject.transform.localPosition = backwardPosition;

        yield return new WaitForSeconds(0.01f); // Adjust the delay between movements

        // Move aimObject back to its original position
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            aimObject.transform.localPosition = Vector2.Lerp(backwardPosition, originalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        aimObject.transform.localPosition = originalPosition;
        isKnockback = false;
    }
    #endregion

    public void SmokeAnKnockback()
    {
        StartCoroutine(MainShooterKnockback());
        if (Prestige.totalBallShots == 1) { smoke1.Play(); }
        if (Prestige.totalBallShots == 2) { smoke2Shots_1.Play(); smoke2Shots_2.Play(); }
        if (Prestige.totalBallShots == 3) { smoke3Shots_1.Play(); smoke3Shots_2.Play(); smoke3Shots_3.Play(); }
        if (Prestige.totalBallShots == 4) { smoke4Shots_1.Play(); smoke4Shots_2.Play(); smoke4Shots_3.Play(); smoke4Shots_4.Play(); }
        if (Prestige.totalBallShots == 5) { smoke5Shots_1.Play(); smoke5Shots_2.Play(); smoke5Shots_3.Play(); smoke5Shots_4.Play(); smoke5Shots_5.Play(); }
    }

    public GameObject excludeGameObject;
    public Achievements achScript;

    #region Shoot ball
    public void ShootBall()
    {
        if (SetAimOfAnOn.isHoveringBoard == true && Prestige.isInPrestigeScreen == false)
        {
            #region Ball 1 - Regular
            if (BallUpgrades.ballNumberEquipped == 1)
            {
                if (basicBallsAvailable > 0)
                {
                    basicBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(basicBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject basicBall = ObjectPool.instance.GetBasicBallFromPool();
                        basicBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(basicBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 2 - Bouncy Ball
            else if (BallUpgrades.ballNumberEquipped == 2)
            {
                if (redBallsAviable > 0)
                {
                    redBallsAviable -= 1;
                    ballUpgradesScript.SetActiveBalls(redBallsAviable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject redBall = ObjectPool.instance.GetRedBallFromPool();
                        redBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(redBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 3 - Rock Ball
            else if (BallUpgrades.ballNumberEquipped == 3)
            {
                if (rockBallsAviable > 0)
                {
                    rockBallsAviable -= 1;
                    ballUpgradesScript.SetActiveBalls(rockBallsAviable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject rockBall = ObjectPool.instance.GetRockBallFromPool();
                        rockBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(rockBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 4 Bomb Ball
            else if(BallUpgrades.ballNumberEquipped == 4)
            {
                if (bombBallsAviable > 0)
                {
                    bombBallsAviable -= 1;
                    ballUpgradesScript.SetActiveBalls(bombBallsAviable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject bombBalls = ObjectPool.instance.GetBombBallFromPool();
                        bombBalls.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(bombBalls, countPluss);
                    }
                }
            }
            #endregion

            //Mull Game
            #region Ball 5 Aqua Ball
            else if(BallUpgrades.ballNumberEquipped == 5)
            {
                if (aquaBallsAvailable > 0)
                {
                    aquaBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(aquaBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject aquaBall = ObjectPool2.instance.GetAquaBallFromPool();
                        aquaBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(aquaBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 6 Mud Ball
            else if(BallUpgrades.ballNumberEquipped == 6)
            {
                if (mudBallsAvailable > 0)
                {
                    mudBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(mudBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject mudBall = ObjectPool2.instance.GetMudBallFromPool();
                        mudBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(mudBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 7 Basket Ball
            else if(BallUpgrades.ballNumberEquipped == 7)
            {
                if (basketBallsAvailable > 0)
                {
                    basketBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(basketBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject basketBall = ObjectPool2.instance.GetBasketBallFromPool();
                        basketBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(basketBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 8 Plum Ball
            else if(BallUpgrades.ballNumberEquipped == 8)
            {
                if (plumBallsAvailable > 0)
                {
                    plumBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(plumBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject plumBall = ObjectPool2.instance.GetPlumBallFromPool();
                        plumBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(plumBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 9 Sticky Ball
            else if(BallUpgrades.ballNumberEquipped == 9)
            {
                if (stickyBallsAvailable > 0)
                {
                    stickyBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(stickyBallsAvailable);
                    BallShootAudio();
                    int countPluss = 0;

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject stickyBall = ObjectPool2.instance.GetStickyBallFromPool();
                        stickyBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(stickyBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 10 Candy Ball
            else if (BallUpgrades.ballNumberEquipped == 10)
            {
                if (candyBallsAvailable > 0)
                {
                    candyBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(candyBallsAvailable);
                    BallShootAudio();
                    int countPluss = 0;

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject candyBall = ObjectPool2.instance.GetCandyBallFromPool();
                        candyBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(candyBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 11 Cookie Ball
            else if (BallUpgrades.ballNumberEquipped == 11)
            {
                if (cookieBallsAvailable > 0)
                {
                    cookieBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(cookieBallsAvailable);
                    BallShootAudio();
                    int countPluss = 0;

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject cookieBall = ObjectPool2.instance.GetCookieBallFromPool();
                        cookieBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(cookieBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 12 Lime Ball
            else if (BallUpgrades.ballNumberEquipped == 12)
            {
                if (limeBallsAvailable > 0)
                {
                    limeBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(limeBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject limeBall = ObjectPool2.instance.GetLimeBallFromPool();
                        limeBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(limeBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 13 Golden Ball
            else if (BallUpgrades.ballNumberEquipped == 13)
            {
                if (goldenBallsAvailable > 0)
                {
                    goldenBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(goldenBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject goldenBall = ObjectPool2.instance.GetGoldenBallFromPool();
                        goldenBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(goldenBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 14 Football Ball
            else if (BallUpgrades.ballNumberEquipped == 14)
            {
                if (footballBallsAvailable > 0)
                {
                    footballBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(footballBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject footballBall = ObjectPool2.instance.GetFootballBallFromPool();
                        footballBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(footballBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 15 Shrapnel Ball
            else if (BallUpgrades.ballNumberEquipped == 15)
            {
                if (sharpnelBallsAvailable > 0)
                {
                    sharpnelBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(sharpnelBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject shrapnelBall = ObjectPool2.instance.GetSharpnelBallFromPool();
                        shrapnelBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(shrapnelBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 16 Zonic Ball
            else if (BallUpgrades.ballNumberEquipped == 16)
            {
                if (zonicBallsAvailable > 0)
                {
                    zonicBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(zonicBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject zonicBall = ObjectPool2.instance.GetZonicBallFromPool();
                        zonicBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(zonicBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 17 Apricot Ball
            else if (BallUpgrades.ballNumberEquipped == 17)
            {
                if (apricotBallsAvailable > 0)
                {
                    apricotBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(apricotBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject apricotBall = ObjectPool2.instance.GetApricotBallFromPool();
                        apricotBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(apricotBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 18 Peggo Ball
            else if (BallUpgrades.ballNumberEquipped == 18)
            {
                if (peggoBallsAvailable > 0)
                {
                    peggoBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(peggoBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject peggoBall = ObjectPool2.instance.GetPeggoBallFromPool();
                        peggoBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(peggoBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 19 Ghost Ball
            else if (BallUpgrades.ballNumberEquipped == 19)
            {
                if (ghostBallsAvailable > 0)
                {
                    ghostBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(ghostBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject ghostBall = ObjectPool2.instance.GetGhostBallFromPool();
                        ghostBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(ghostBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 20 Star Ball
            else if (BallUpgrades.ballNumberEquipped == 20)
            {
                if (starBallsAvailable > 0)
                {
                    starBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(starBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject starBall = ObjectPool2.instance.GetStarBallFromPool();
                        starBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(starBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 21 Rainbow Ball
            else if (BallUpgrades.ballNumberEquipped == 21)
            {
                if (rainbowBallsAvailable > 0)
                {
                    rainbowBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(rainbowBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject rainbowBall = ObjectPool2.instance.GetRainbowBallFromPool();
                        rainbowBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(rainbowBall, countPluss);
                    }
                }
            }
            #endregion

            #region Ball 22 Glitchy Ball
            else if (BallUpgrades.ballNumberEquipped == 22)
            {
                if (glitchyBallsAvailable > 0)
                {
                    glitchyBallsAvailable -= 1;
                    ballUpgradesScript.SetActiveBalls(glitchyBallsAvailable);
                    int countPluss = 0;
                    BallShootAudio();

                    for (int i = 0; i < Prestige.totalBallShots; i++)
                    {
                        GameObject glitchyBall = ObjectPool2.instance.GetGlitchyBallFromPool();
                        glitchyBall.layer = 9;
                        countPluss += 1;
                        ShootABallTesting(glitchyBall, countPluss);
                    }
                }
            }
            #endregion
        }
    }

    public void BallShootAudio()
    {
        overlappingSoundsScript.HitMainShooter();
    }
    #endregion

    #region Shoot a ball testing
    public void ShootABallTesting(GameObject ball, int count)
    {
        if (Prestige.A_Upgrade22Purchased == true)
        {
            GoldFromShooting();
        }


        if (Prestige.totalBallShots == 2) 
        {
            if(count == 1)
            {
                ball.transform.position = shotPointS2_1.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 2)
            {
                ball.transform.position = shotPointS2_2.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
        }
        else if (Prestige.totalBallShots == 1) 
        {
            ball.transform.position = shotPoint.transform.position;
            ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }
        else if (Prestige.totalBallShots == 3) 
        {
            if (count == 1)
            {
                ball.transform.position = shotPointS3_1.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 2)
            {
                ball.transform.position = shotPointS3_2.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 3)
            {
                ball.transform.position = shotPointS3_3.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
        }
        else if (Prestige.totalBallShots == 4) 
        {
            if (count == 1)
            {
                ball.transform.position = shotPointS4_1.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 2)
            {
                ball.transform.position = shotPointS4_2.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 3)
            {
                ball.transform.position = shotPointS4_3.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 4)
            {
                ball.transform.position = shotPointS4_4.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
        }
        else if (Prestige.totalBallShots == 5)
        {
            if (count == 1)
            {
                ball.transform.position = shotPointS5_1.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 2)
            {
                ball.transform.position = shotPointS5_2.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 3)
            {
                ball.transform.position = shotPointS5_3.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 4)
            {
                ball.transform.position = shotPointS5_4.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
            if (count == 5)
            {
                ball.transform.position = shotPointS5_5.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
        }

        if (isKnockback == false) { isKnockback = true; SmokeAnKnockback(); }
        AllStats.totalBallsShot += 1;
        if (SettingsOptions.isInStats == true) { DisplayAllStats(); }
        if (achScript != null) { achScript.CheckBallsShotACH(); }
    }
    #endregion

    #region Gold from shooting
    public Levels levelsScript;
    public PointsMechanics pointsMechanicsScript;

    public void GoldFromShooting() 
    {
        levelsScript.HighestValueBallGold();
        TextMeshProUGUI pegPointText = ObjectPool.instance.GetPegPointPopUpFromPool();
        pegPointText.gameObject.layer = 25;
        double gold = Levels.currentHighestValueBall * Prestige.goldFromShooting;

        if (gold < 100)
        {
            if (gold % 1 == 0)
            {
                pegPointText.text = "+" + gold.ToString("F0");
            }
            else
            {
                pegPointText.text = "+" + gold.ToString("F1");
            }
        }
        else
        {
            pegPointText.text = "+" + SetHighNumbers.FormatCoinsGoldShort(gold);
        }

        BallUpgrades.points += gold;
        AllStats.totalGold += gold;
        AllStats.goldFromShooting += gold;

        statsScript.DisplayTotalGold();

        pegPointText.transform.position = shotPoint.transform.position;
        pegPointText.transform.localScale = new Vector3(1f, 1f, 1f);

        if(Prestige.A_Upgrade28Purchased == true)
        {
            float random = Random.Range(0f,100f);
            if(random < Prestige.prestigePointFromShotChance)
            {
                TextMeshProUGUI prestigeText = ObjectPool.instance.GetPrestigeTextFromPool();
                prestigeText.transform.position = shotPoint.transform.position;
                prestigeText.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                prestigeText.gameObject.layer = 25;
                prestigeText.text = "+1";
            }
        }

        if (achScript != null) { achScript.CheckGoldGainACH(); }
    }
    #endregion

    #region ShootFullFill
    public static int randomAmount;

    public void ShootFullFill()
    {
        AllStats.totalBallsShot += 1;
        audioManager.Play("Ball1");
        float randomRotation = Random.Range(0f, -180f); // Adjust the range as needed
        Quaternion randomQuaternion = Quaternion.Euler(0f, 0f, randomRotation);

        gameObject.transform.rotation = randomQuaternion;

        if (isKnockback == false) { isKnockback = true; SmokeAnKnockback(); }

        randomAmount = 0;

        //Start with 1 for the regular ball
        randomAmount += 1;
        if (BallUpgrades.bouncyBallPurchased == true) { randomAmount += 1; }
        if (BallUpgrades.rockBallPurchased == true) { randomAmount += 1; }
        if (BallUpgrades.bombBallPurchased == true) { randomAmount += 1; }
        if(GameData.isDemo == false)
        {
            if (BallUpgrades.aquaBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.mudBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.basketBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.plumBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.stickyBallPurchased == true) { randomAmount += 1; }

            if (BallUpgrades.candyBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.cookieBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.limeBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.goldenBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.footballBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.sharpnelBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.zonicBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.apricotBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.peggoBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.ghostBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.starBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.rainbowBallPurchased == true) { randomAmount += 1; }
            if (BallUpgrades.glitchyBallPurchased == true) { randomAmount += 1; }
        }

        int random = Random.Range(0, randomAmount);
        int countPluss = 0;
        for (int i = 0; i < Prestige.totalBallShots; i++)
        {
            countPluss += 1;
            
            GameObject newBall = null;
            if (random == 0)
            {
                newBall = ObjectPool.instance.GetBasicBallFromPool();
            }
            else if (random == 1)
            {
                newBall = ObjectPool.instance.GetRedBallFromPool();
            }
            else if (random == 2)
            {
                newBall = ObjectPool.instance.GetRockBallFromPool();
            }
            else if (random == 3)
            {
                newBall = ObjectPool.instance.GetBombBallFromPool();
            }
            else if (random == 4)
            {
                newBall = ObjectPool2.instance.GetAquaBallFromPool();
            }
            else if (random == 5)
            {
                newBall = ObjectPool2.instance.GetMudBallFromPool();
            }
            else if (random == 6)
            {
                newBall = ObjectPool2.instance.GetBasketBallFromPool();
            }
            else if (random == 7)
            {
                newBall = ObjectPool2.instance.GetPlumBallFromPool();
            }
            else if(random == 8)
            {
                newBall = ObjectPool2.instance.GetStickyBallFromPool();
            }
            else if(random == 9)
            {
                newBall = ObjectPool2.instance.GetCandyBallFromPool();
            }
            else if (random == 10)
            {
                newBall = ObjectPool2.instance.GetCookieBallFromPool();
            }
            else if (random == 11)
            {
                newBall = ObjectPool2.instance.GetLimeBallFromPool();
            }
            else if (random == 12)
            {
                newBall = ObjectPool2.instance.GetGoldenBallFromPool();
            }
            else if (random == 13)
            {
                newBall = ObjectPool2.instance.GetFootballBallFromPool();
            }
            else if (random == 14)
            {
                newBall = ObjectPool2.instance.GetSharpnelBallFromPool();
            }
            else if (random == 15)
            {
                newBall = ObjectPool2.instance.GetZonicBallFromPool();
            }
            else if (random == 16)
            {
                newBall = ObjectPool2.instance.GetApricotBallFromPool();
            }
            else if (random == 17)
            {
                newBall = ObjectPool2.instance.GetPeggoBallFromPool();
            }
            else if (random == 18)
            {
                newBall = ObjectPool2.instance.GetGhostBallFromPool();
            }
            else if (random == 19)
            {
                newBall = ObjectPool2.instance.GetStarBallFromPool();
            }
            else if (random == 20)
            {
                newBall = ObjectPool2.instance.GetRainbowBallFromPool();
            }
            else if (random == 21)
            {
                newBall = ObjectPool2.instance.GetGlitchyBallFromPool();
            }

            if (newBall != null)
            {
                newBall.layer = 16;
                ShootABallTesting(newBall, countPluss);
            }
        }

     

        if (SettingsOptions.isInStats == true) { DisplayAllStats(); }
    }
    #endregion

    Vector2 PointsPosition(float t, Transform pos)
    {
        Vector2 position = (Vector2)pos.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    public Coroutine auto1Coroutine, auto2Coroutine, auto3Coroutine, auto4Coroutine, auto5Coroutine, auto6Coroutine, auto7Coroutine, auto8Coroutine, auto9Coroutine, auto10Coroutine, auto11Coroutine, auto12Coroutine, auto13Coroutine, auto14Coroutine, auto15Coroutine, auto16Coroutine, auto17Coroutine, auto18Coroutine, auto19Coroutine, auto20Coroutine, auto21Coroutine, auto22Coroutine;

    #region Auto ball drop
    public void Auto1()
    {
        if (BallUpgrades.isRegularBallAutoPurchased == true)
        {
            if (auto1Coroutine == null) { auto1Coroutine = StartCoroutine(AutoBallDrop()); }
        }
    }

    IEnumerator AutoBallDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.basicBallAutoDropTime);
        if(BallUpgrades.isBall1AutoTurnedOff == false)
        {
            GameObject basicBall = ObjectPool.instance.GetBasicBallFromPool();
            basicBall.layer = 15;

            SetRandomDropPos(basicBall);
        }
        auto1Coroutine = null; auto1Coroutine = StartCoroutine(AutoBallDrop());
    }
    #endregion

    #region Red ball drop
    public void Auto2()
    {
        if (BallUpgrades.isRedBallAutoPurchased == true)
        {
            if (auto2Coroutine == null) { auto2Coroutine = StartCoroutine(RedBallautoDrop()); }
        }
    }

    IEnumerator RedBallautoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.redBallAutoDropTime);
        if (BallUpgrades.isBall2AutoTurnedOff == false)
        {
            GameObject redBall = ObjectPool.instance.GetRedBallFromPool();
            redBall.layer = 15;

            SetRandomDropPos(redBall);
        }
        
        auto2Coroutine = null; auto2Coroutine = StartCoroutine(RedBallautoDrop());
    }
    #endregion

    #region Rock ball drop
    public void Auto3()
    {
        if(BallUpgrades.isRockBallAutoPurchased == true)
        {
            if (auto3Coroutine == null) { auto3Coroutine = StartCoroutine(RockBallAutoDrop()); }
        }
    }

    IEnumerator RockBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.rockBallAutoDropTime);
        if (BallUpgrades.isBall3AutoTurnedOff == false)
        {
            GameObject rockBall = ObjectPool.instance.GetRockBallFromPool();
            rockBall.layer = 15;

            SetRandomDropPos(rockBall);
        }
       
        auto3Coroutine = null; auto3Coroutine = StartCoroutine(RockBallAutoDrop());
    }
    #endregion

    #region Bomb ball drop
    public void Auto4()
    {
        if (BallUpgrades.isBombBallAutoPurchased == true)
        {
            if (auto4Coroutine == null) { auto4Coroutine = StartCoroutine(BombBallAutoDrop()); }
        }
    }

    IEnumerator BombBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.bombBallAutoDropTime);
        if (BallUpgrades.isBall4AutoTurnedOff == false)
        {
            GameObject bombBall = ObjectPool.instance.GetBombBallFromPool();
            bombBall.layer = 15;

            SetRandomDropPos(bombBall);
        }
        
        auto4Coroutine = null; auto4Coroutine = StartCoroutine(BombBallAutoDrop());
    }
    #endregion

    //Full Game
    #region Aqua Ball drop
    public void Auto5()
    {
        if (BallUpgrades.isAquaBallAutoPurchased == true)
        {
            if (auto5Coroutine == null) { auto5Coroutine = StartCoroutine(AquaBallAutoDrop()); }
        }
    }

    IEnumerator AquaBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.aquaBallAutoDropTime);
        if (BallUpgrades.isBall5AutoTurnedOff == false)
        {
            GameObject aquaBall = ObjectPool2.instance.GetAquaBallFromPool();
            aquaBall.layer = 15;

            SetRandomDropPos(aquaBall);
        }
          
        auto5Coroutine = null; auto5Coroutine = StartCoroutine(AquaBallAutoDrop());
    }
    #endregion

    #region Mud Ball drop
    public void Auto6()
    {
        if (BallUpgrades.isMudBallAutoPurchased == true)
        {
            if (auto6Coroutine == null) { auto6Coroutine = StartCoroutine(MudBallAutoDrop()); }
        }
    }

    IEnumerator MudBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.mudBallAutoDropTime);
        if (BallUpgrades.isBall6AutoTurnedOff == false)
        {
            GameObject mudBall = ObjectPool2.instance.GetMudBallFromPool();
            mudBall.layer = 15;

            SetRandomDropPos(mudBall);
        }
        
        auto6Coroutine = null; auto6Coroutine = StartCoroutine(MudBallAutoDrop());
    }
    #endregion

    #region Basket Ball drop
    public void Auto7()
    {
        if (BallUpgrades.isBasketBallAutoPurchased == true)
        {
            if (auto7Coroutine == null) { auto7Coroutine = StartCoroutine(BasketBallAutoDrop()); }
        }
    }

    IEnumerator BasketBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.basketBallAutoDropTime);
        if (BallUpgrades.isBall7AutoTurnedOff == false)
        {
            GameObject basketBall = ObjectPool2.instance.GetBasketBallFromPool();
            basketBall.layer = 15;

            SetRandomDropPos(basketBall);
        }
       
        auto7Coroutine = null; auto7Coroutine = StartCoroutine(BasketBallAutoDrop());
    }
    #endregion

    #region Plum Ball drop
    public void Auto8()
    {
        if (BallUpgrades.isPlumBallAutoPurchased == true)
        {
            if (auto8Coroutine == null) { auto8Coroutine = StartCoroutine(PlumBallAutoDrop()); }
        }
    }

    IEnumerator PlumBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.plumBallAutoDropTime);
        if (BallUpgrades.isBall8AutoTurnedOff == false)
        {
            GameObject plumBall = ObjectPool2.instance.GetPlumBallFromPool();
            plumBall.layer = 15;

            SetRandomDropPos(plumBall);
        }
          
        auto8Coroutine = null; auto8Coroutine = StartCoroutine(PlumBallAutoDrop());
    }
    #endregion

    #region Sticky Ball drop
    public void Auto9()
    {
        if (BallUpgrades.isStickyBallAutoPurchased == true)
        {
            if (auto9Coroutine == null) { auto9Coroutine = StartCoroutine(StickyBallAutoDrop()); }
        }
    }

    IEnumerator StickyBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.stickyBallAutoDropTime);
        if (BallUpgrades.isBall9AutoTurnedOff == false)
        {
            GameObject stickyBall = ObjectPool2.instance.GetStickyBallFromPool();
            stickyBall.layer = 15;

            SetRandomDropPos(stickyBall);
        }
      
        auto9Coroutine = null; auto9Coroutine = StartCoroutine(StickyBallAutoDrop());
    }
    #endregion

    #region Candy Ball drop
    public void Auto10()
    {
        if (BallUpgrades.isCandyBallAutoPurchased == true)
        {
            if (auto10Coroutine == null) { auto10Coroutine = StartCoroutine(CandyBallAutoDrop()); }
        }
    }

    IEnumerator CandyBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.candyBallAutoDropTime);
        if (BallUpgrades.isBall10AutoTurnedOff == false)
        {
            GameObject candyBall = ObjectPool2.instance.GetCandyBallFromPool();
            candyBall.layer = 15;

            SetRandomDropPos(candyBall);
        }
          
        auto10Coroutine = null; auto10Coroutine = StartCoroutine(CandyBallAutoDrop());
    }
    #endregion

    #region Cookie Ball drop
    public void Auto11()
    {
        if (BallUpgrades.isCookieBallAutoPurchased == true)
        {
            if (auto11Coroutine == null) { auto11Coroutine = StartCoroutine(CookieBallAutoDrop()); }
        }
    }

    IEnumerator CookieBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.cookieBallAutoDropTime);
        if (BallUpgrades.isBall11AutoTurnedOff == false)
        {
            GameObject cookieBall = ObjectPool2.instance.GetCookieBallFromPool();
            cookieBall.layer = 15;

            SetRandomDropPos(cookieBall);
        }
         
        auto11Coroutine = null; auto11Coroutine = StartCoroutine(CookieBallAutoDrop());
    }
    #endregion

    #region Lime Ball drop
    public void Auto12()
    {
        if (BallUpgrades.isLimeBallAutoPurchased == true)
        {
            if (auto12Coroutine == null) { auto12Coroutine = StartCoroutine(LimeBallAutoDrop()); }
        }
    }

    IEnumerator LimeBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.limeBallAutoDropTime);
        if (BallUpgrades.isBall12AutoTurnedOff == false)
        {
            GameObject limeBall = ObjectPool2.instance.GetLimeBallFromPool();
            limeBall.layer = 15;

            SetRandomDropPos(limeBall);
        }
        
        auto12Coroutine = null; auto12Coroutine = StartCoroutine(LimeBallAutoDrop());
    }
    #endregion

    #region Golden Ball drop
    public void Auto13()
    {
        if (BallUpgrades.isGoldenBallAutoPurchased == true)
        {
            if (auto13Coroutine == null) { auto13Coroutine = StartCoroutine(GoldenBallAutoDrop()); }
        }
    }

    IEnumerator GoldenBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.goldenBallAutoDropTime);
        if (BallUpgrades.isBall13AutoTurnedOff == false)
        {
            GameObject goldenBall = ObjectPool2.instance.GetGoldenBallFromPool();
            goldenBall.layer = 15;

            SetRandomDropPos(goldenBall);
        }
        
        auto13Coroutine = null; auto13Coroutine = StartCoroutine(GoldenBallAutoDrop());
    }
    #endregion

    #region Football Ball drop
    public void Auto14()
    {
        if (BallUpgrades.isFootballBallAutoPurchased == true)
        {
            if (auto14Coroutine == null) { auto14Coroutine = StartCoroutine(FootballBallAutoDrop()); }
        }
    }

    IEnumerator FootballBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.footballBallAutoDropTime);
        if (BallUpgrades.isBall14AutoTurnedOff == false)
        {
            GameObject footballBall = ObjectPool2.instance.GetFootballBallFromPool();
            footballBall.layer = 15;

            SetRandomDropPos(footballBall);
        }
        
        auto14Coroutine = null; auto14Coroutine = StartCoroutine(FootballBallAutoDrop());
    }
    #endregion

    #region Sharpnel Ball drop
    public void Auto15()
    {
        if (BallUpgrades.isSharpnelBallAutoPurchased == true)
        {
            if (auto15Coroutine == null) { auto15Coroutine = StartCoroutine(SharpnelBallAutoDrop()); }
        }
    }

    IEnumerator SharpnelBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.sharpnelBallAutoDropTime);
        if (BallUpgrades.isBall15AutoTurnedOff == false)
        {
            GameObject sharpnelBall = ObjectPool2.instance.GetSharpnelBallFromPool();
            sharpnelBall.layer = 15;

            SetRandomDropPos(sharpnelBall);
        }
          
        auto15Coroutine = null; auto15Coroutine = StartCoroutine(SharpnelBallAutoDrop());
    }
    #endregion

    #region Zonic Ball drop
    public void Auto16()
    {
        if (BallUpgrades.isZonicBallAutoPurchased == true)
        {
            if (auto16Coroutine == null) { auto16Coroutine = StartCoroutine(ZonicBallAutoDrop()); }
        }
    }

    IEnumerator ZonicBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.zonicBallAutoDropTime);
        if (BallUpgrades.isBall16AutoTurnedOff == false)
        {
            GameObject zonicBall = ObjectPool2.instance.GetZonicBallFromPool();
            zonicBall.layer = 15;

            SetRandomDropPos(zonicBall);
        }
        
        auto16Coroutine = null; auto16Coroutine = StartCoroutine(ZonicBallAutoDrop());
    }
    #endregion

    #region Apricot Ball drop
    public void Auto17()
    {
        if (BallUpgrades.isApricotBallAutoPurchased == true)
        {
            if (auto17Coroutine == null) { auto17Coroutine = StartCoroutine(ApricotBallAutoDrop()); }
        }
    }

    IEnumerator ApricotBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.apricotBallAutoDropTime);
        if (BallUpgrades.isBall17AutoTurnedOff == false)
        {
            GameObject apricotBall = ObjectPool2.instance.GetApricotBallFromPool();
            apricotBall.layer = 15;

            SetRandomDropPos(apricotBall);
        }
        
        auto17Coroutine = null; auto17Coroutine = StartCoroutine(ApricotBallAutoDrop());
    }
    #endregion

    #region Peggo Ball drop
    public void Auto18()
    {
        if (BallUpgrades.isPeggoBallAutoPurchased == true)
        {
            if (auto18Coroutine == null) { auto18Coroutine = StartCoroutine(PeggoBallAutoDrop()); }
        }
    }

    IEnumerator PeggoBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.peggoBallAutoDropTime);
        if (BallUpgrades.isBall18AutoTurnedOff == false)
        {
            GameObject peggoBall = ObjectPool2.instance.GetPeggoBallFromPool();
            peggoBall.layer = 15;

            SetRandomDropPos(peggoBall);
        }
         
        auto18Coroutine = null; auto18Coroutine = StartCoroutine(PeggoBallAutoDrop());
    }
    #endregion

    #region Ghost Ball drop
    public void Auto19()
    {
        if (BallUpgrades.isGhostBallAutoPurchased == true)
        {
            if (auto19Coroutine == null) { auto19Coroutine = StartCoroutine(GhostBallAutoDrop()); }
        }
    }

    IEnumerator GhostBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.ghostBallAutoDropTime);
        if (BallUpgrades.isBall19AutoTurnedOff == false)
        {
            GameObject ghostBall = ObjectPool2.instance.GetGhostBallFromPool();
            ghostBall.layer = 15;

            float random = Random.Range(-900, 260);
            ghostBall.transform.localPosition = new Vector2(random, 630);

            if (SettingsOptions.isInStats == true) { SetStats(); }

            AllStats.totalBallsDropped += 1;
            if (SettingsOptions.isInStats == true) { SetStats(); }
            if (achScript != null) { achScript.CheckBallsDroppedACH(); }
        }

        auto19Coroutine = null; auto19Coroutine = StartCoroutine(GhostBallAutoDrop());
    }
    #endregion

    #region Star Ball drop
    public void Auto20()
    {
        if (BallUpgrades.isStarBallAutoPurchased == true)
        {
            if (auto20Coroutine == null) { auto20Coroutine = StartCoroutine(StarBallAutoDrop()); }
        }
    }

    IEnumerator StarBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.starBallAutoDropTime);
        if (BallUpgrades.isBall20AutoTurnedOff == false)
        {
            GameObject starBall = ObjectPool2.instance.GetStarBallFromPool();
            starBall.layer = 15;

            SetRandomDropPos(starBall);
        }
         
        auto20Coroutine = null; auto20Coroutine = StartCoroutine(StarBallAutoDrop());
    }
    #endregion

    #region Rainbow Ball drop
    public void Auto21()
    {
        if (BallUpgrades.isRainbowBallAutoPurchased == true)
        {
            if (auto21Coroutine == null) { auto21Coroutine = StartCoroutine(RainbowBallAutoDrop()); }
        }
    }

    IEnumerator RainbowBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.rainbowBallAutoDropTime);
        if (BallUpgrades.isBall21AutoTurnedOff == false)
        {
            GameObject rainbowBall = ObjectPool2.instance.GetRainbowBallFromPool();
            rainbowBall.layer = 15;

            SetRandomDropPos(rainbowBall);
        }
         
        auto21Coroutine = null; auto21Coroutine = StartCoroutine(RainbowBallAutoDrop());
    }
    #endregion

    #region Glitchy Ball drop
    public void Auto22()
    {
        if (BallUpgrades.isGlitchyBallAutoPurchased == true)
        {
            if (auto22Coroutine == null) { auto22Coroutine = StartCoroutine(GlitchyBallAutoDrop()); }
        }
    }

    IEnumerator GlitchyBallAutoDrop()
    {
        yield return new WaitForSeconds(BallUpgrades.glitchyBallAutoDropTime);
        if (BallUpgrades.isBall22AutoTurnedOff == false)
        {
            GameObject glitchyBall = ObjectPool2.instance.GetGlitchyBallFromPool();
            glitchyBall.layer = 15;

            SetRandomDropPos(glitchyBall);
        }
         
        auto22Coroutine = null; auto22Coroutine = StartCoroutine(GlitchyBallAutoDrop());
    }
    #endregion


    public void SetRandomDropPos(GameObject ball)
    {
        float random = Random.Range(-900, 260);
        ball.transform.localPosition = new Vector2(random, 700);

        AllStats.totalBallsDropped += 1;
        if (SettingsOptions.isInStats == true) { SetStats(); }
        if(achScript != null) { achScript.CheckBallsDroppedACH(); }
    }

    public void SetStats()
    {
        DisplayAllStats(); 
    }

    public void DisplayAllStats()
    {
        statsScript.DisplayGeneralStats();
    }

    #region Reset
    public void ResetAutoDrops()
    {
        BallUpgrades.isRegularBallAutoPurchased = false;
        BallUpgrades.isRedBallAutoPurchased = false;
        BallUpgrades.isRockBallAutoPurchased = false;
        BallUpgrades.isBombBallAutoPurchased = false;
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

        if (auto1Coroutine != null) { StopCoroutine(auto1Coroutine); auto1Coroutine = null; }
        if (auto2Coroutine != null) { StopCoroutine(auto2Coroutine); auto2Coroutine = null; }
        if (auto3Coroutine != null) { StopCoroutine(auto3Coroutine); auto3Coroutine = null; }
        if (auto4Coroutine != null) { StopCoroutine(auto4Coroutine); auto4Coroutine = null; }
        if (auto5Coroutine != null) { StopCoroutine(auto5Coroutine); auto5Coroutine = null; }
        if (auto6Coroutine != null) { StopCoroutine(auto6Coroutine); auto6Coroutine = null; }
        if (auto7Coroutine != null) { StopCoroutine(auto7Coroutine); auto7Coroutine = null; }
        if (auto8Coroutine != null) { StopCoroutine(auto8Coroutine); auto8Coroutine = null; }
        if (auto9Coroutine != null) { StopCoroutine(auto9Coroutine); auto9Coroutine = null; }
        if (auto10Coroutine != null) { StopCoroutine(auto10Coroutine); auto10Coroutine = null; }
        if (auto11Coroutine != null) { StopCoroutine(auto11Coroutine); auto11Coroutine = null; }
        if (auto12Coroutine != null) { StopCoroutine(auto12Coroutine); auto12Coroutine = null; }
        if (auto13Coroutine != null) { StopCoroutine(auto13Coroutine); auto13Coroutine = null; }
        if (auto14Coroutine != null) { StopCoroutine(auto14Coroutine); auto14Coroutine = null; }
        if (auto15Coroutine != null) { StopCoroutine(auto15Coroutine); auto15Coroutine = null; }
        if (auto16Coroutine != null) { StopCoroutine(auto16Coroutine); auto16Coroutine = null; }
        if (auto17Coroutine != null) { StopCoroutine(auto17Coroutine); auto17Coroutine = null; }
        if (auto18Coroutine != null) { StopCoroutine(auto18Coroutine); auto18Coroutine = null; }
        if (auto19Coroutine != null) { StopCoroutine(auto19Coroutine); auto19Coroutine = null; }
        if (auto20Coroutine != null) { StopCoroutine(auto20Coroutine); auto20Coroutine = null; }
        if (auto21Coroutine != null) { StopCoroutine(auto21Coroutine); auto21Coroutine = null; }
        if (auto22Coroutine != null) { StopCoroutine(auto22Coroutine); auto22Coroutine = null; }
    }
    #endregion
}
