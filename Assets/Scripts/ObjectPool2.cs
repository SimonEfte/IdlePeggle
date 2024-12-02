using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool2 : MonoBehaviour
{
    public static ObjectPool2 instance;

    public Transform ballsParent, coinParent;

    [SerializeField] private GameObject aquaBallPrefab;
    private Queue<GameObject> aquaBallPool = new Queue<GameObject>();
    [SerializeField] private int aquaBallPoolsize = 50;
    public static float aquaBallSize;

    [SerializeField] private GameObject mudBallPrefab;
    private Queue<GameObject> mudBallPool = new Queue<GameObject>();
    [SerializeField] private int mudBallPoolsize = 50;
    public static float mudBallSize;

    [SerializeField] private GameObject basketBallPrefab;
    private Queue<GameObject> basketBallPool = new Queue<GameObject>();
    [SerializeField] private int basketBallPoolsize = 50;
    public static float basketBallSize;

    [SerializeField] private GameObject plumBallPrefab;
    private Queue<GameObject> plumBallPool = new Queue<GameObject>();
    [SerializeField] private int plumBallPoolsize = 50;
    public static float plumBallSize;

    [SerializeField] private GameObject stickyBallPrefab;
    private Queue<GameObject> stickyBallPool = new Queue<GameObject>();
    [SerializeField] private int stickyBallPoolsize = 50;
    public static float stickyBallSize;

    [SerializeField] private GameObject candyBallPrefab;
    private Queue<GameObject> candyBallPool = new Queue<GameObject>();
    [SerializeField] private int candyBallPoolsize = 50;
    public static float candyBallSize;

    [SerializeField] private GameObject cookieBallPrefab;
    private Queue<GameObject> cookieBallPool = new Queue<GameObject>();
    [SerializeField] private int cookieBallPoolsize = 50;
    public static float cookieBallSize;

    [SerializeField] private GameObject limeBallPrefab;
    private Queue<GameObject> limeBallPool = new Queue<GameObject>();
    [SerializeField] private int limeBallPoolsize = 50;
    public static float limeBallSize;

    [SerializeField] private GameObject goldenBallPrefab;
    private Queue<GameObject> goldenBallPool = new Queue<GameObject>();
    [SerializeField] private int goldenBallPoolsize = 50;
    public static float goldenBallSize;

    [SerializeField] private GameObject footballBallPrefab;
    private Queue<GameObject> footballBallPool = new Queue<GameObject>();
    [SerializeField] private int footballBallPoolsize = 50;
    public static float footballBallSize;

    [SerializeField] private GameObject sharpnelBallPrefab;
    private Queue<GameObject> sharpnelBallPool = new Queue<GameObject>();
    [SerializeField] private int sharpnelBallPoolsize = 50;
    public static float sharpnelBallSize;

    [SerializeField] private GameObject zonicBallPrefab;
    private Queue<GameObject> zonicBallPool = new Queue<GameObject>();
    [SerializeField] private int zonicBallPoolsize = 50;
    public static float zonicBallSize;

    [SerializeField] private GameObject apricotBallPrefab;
    private Queue<GameObject> apricotBallPool = new Queue<GameObject>();
    [SerializeField] private int apricotBallPoolsize = 50;
    public static float apricotBallSize;

    [SerializeField] private GameObject peggoBallPrefab;
    private Queue<GameObject> peggoBallPool = new Queue<GameObject>();
    [SerializeField] private int peggoBallPoolsize = 50;
    public static float peggoBallSize;

    [SerializeField] private GameObject ghostBallPrefab;
    private Queue<GameObject> ghostBallPool = new Queue<GameObject>();
    [SerializeField] private int ghostBallPoolsize = 50;
    public static float ghostBallSize;

    [SerializeField] private GameObject starBallPrefab;
    private Queue<GameObject> starBallPool = new Queue<GameObject>();
    [SerializeField] private int starBallPoolsize = 50;
    public static float starBallSize;

    [SerializeField] private GameObject rainbowBallPrefab;
    private Queue<GameObject> rainbowBallPool = new Queue<GameObject>();
    [SerializeField] private int rainbowBallPoolsize = 50;
    public static float rainbowBallSize;

    [SerializeField] private GameObject glitchyBallPrefab;
    private Queue<GameObject> glitchyBallPool = new Queue<GameObject>();
    [SerializeField] private int glitchyBallPoolsize = 50;
    public static float glitchyBallSize;

    [SerializeField] private GameObject tinySharpelBallPrefab;
    private Queue<GameObject> tinySharpelBallPool = new Queue<GameObject>();
    [SerializeField] private int tinySharpelBallPoolsize = 50;
    public static float tinySharpelBallSize;

    [SerializeField] private GameObject tinyRingBallPrefab;
    private Queue<GameObject> tinyRingBallPool = new Queue<GameObject>();
    [SerializeField] private int tinyRingBallPoolsize = 50;
    public static float tinyRingBallSize;

    [SerializeField] private GameObject tinyGlitchyBallPrefab;
    private Queue<GameObject> tinyGlitchyBallPool = new Queue<GameObject>();
    [SerializeField] private int tinyGlitchyBallPoolsize = 50;
    public static float tinyGlitchyBallSize;

    [SerializeField] private GameObject goldCoinPrefab;
    private Queue<GameObject> goldCoinPool = new Queue<GameObject>();
    [SerializeField] private int goldCoinPoolSize = 20;
    public static float goldCoinSize;

    [SerializeField] private GameObject prestigeGemPrefab;
    private Queue<GameObject> prestigeGemPool = new Queue<GameObject>();
    [SerializeField] private int prestigeGemPoolSize = 15;
    public static float prestigeGemSize;

    private void Awake()
    {
        goldCoinSize = 0.3f;
        prestigeGemSize = 0.35f;

        tinyGlitchyBallSize = 0.3f;
        tinyRingBallSize = 0.35f;
        tinySharpelBallSize = 0.25f;
        aquaBallSize = 0.4f;
        mudBallSize = 0.35f;
        basketBallSize = 0.48f;
        plumBallSize = 0.4f;
        stickyBallSize = 0.3f;
        candyBallSize = 0.45f;
        cookieBallSize = 0.5f;
        limeBallSize = 0.38f;
        goldenBallSize = 0.45f;
        footballBallSize = 0.5f;
        sharpnelBallSize = 0.55f;
        zonicBallSize = 0.5f;
        apricotBallSize = 0.4f;
        peggoBallSize = 0.4f;
        ghostBallSize = 0.6f;
        starBallSize = 0.45f;
        rainbowBallSize = 0.45f;
        glitchyBallSize = 0.45f;

        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        #region Aqua Ball
        for (int i = 0; i < aquaBallPoolsize; i++)
        {
            GameObject aquaBall = Instantiate(aquaBallPrefab);
            aquaBallPool.Enqueue(aquaBall);
            aquaBall.SetActive(false);
            aquaBall.transform.SetParent(ballsParent);
            aquaBall.transform.localScale = new Vector3(aquaBallSize, aquaBallSize, aquaBallSize);
        }
        #endregion

        #region Mud Ball
        for (int i = 0; i < mudBallPoolsize; i++)
        {
            GameObject mudBall = Instantiate(mudBallPrefab);
            mudBallPool.Enqueue(mudBall);
            mudBall.SetActive(false);
            mudBall.transform.SetParent(ballsParent);
            mudBall.transform.localScale = new Vector3(mudBallSize, mudBallSize, mudBallSize);
        }
        #endregion

        #region Basket Ball
        for (int i = 0; i < basketBallPoolsize; i++)
        {
            GameObject basketBall = Instantiate(basketBallPrefab);
            basketBallPool.Enqueue(basketBall);
            basketBall.SetActive(false);
            basketBall.transform.SetParent(ballsParent);
            basketBall.transform.localScale = new Vector3(basketBallSize, basketBallSize, basketBallSize);
        }
        #endregion

        #region Plum Ball
        for (int i = 0; i < plumBallPoolsize; i++)
        {
            GameObject plumBall = Instantiate(plumBallPrefab);
            plumBallPool.Enqueue(plumBall);
            plumBall.SetActive(false);
            plumBall.transform.SetParent(ballsParent);
            plumBall.transform.localScale = new Vector3(plumBallSize, plumBallSize, plumBallSize);
        }
        #endregion

        #region Sticky Ball
        for (int i = 0; i < stickyBallPoolsize; i++)
        {
            GameObject stickyBall = Instantiate(stickyBallPrefab);
            stickyBallPool.Enqueue(stickyBall);
            stickyBall.SetActive(false);
            stickyBall.transform.SetParent(ballsParent);
            stickyBall.transform.localScale = new Vector3(stickyBallSize, stickyBallSize, stickyBallSize);
        }
        #endregion

        #region Candy Ball
        for (int i = 0; i < candyBallPoolsize; i++)
        {
            GameObject candyBall = Instantiate(candyBallPrefab);
            candyBallPool.Enqueue(candyBall);
            candyBall.SetActive(false);
            candyBall.transform.SetParent(ballsParent);
            candyBall.transform.localScale = new Vector3(candyBallSize, candyBallSize, candyBallSize);
        }
        #endregion

        #region Cookie Ball
        for (int i = 0; i < cookieBallPoolsize; i++)
        {
            GameObject cookieBall = Instantiate(cookieBallPrefab);
            cookieBallPool.Enqueue(cookieBall);
            cookieBall.SetActive(false);
            cookieBall.transform.SetParent(ballsParent);
            cookieBall.transform.localScale = new Vector3(cookieBallSize, cookieBallSize, cookieBallSize);
        }
        #endregion

        #region Lime Ball
        for (int i = 0; i < limeBallPoolsize; i++)
        {
            GameObject limeBall = Instantiate(limeBallPrefab);
            limeBallPool.Enqueue(limeBall);
            limeBall.SetActive(false);
            limeBall.transform.SetParent(ballsParent);
            limeBall.transform.localScale = new Vector3(limeBallSize, limeBallSize, limeBallSize);
        }
        #endregion

        #region Golden Ball
        for (int i = 0; i < goldenBallPoolsize; i++)
        {
            GameObject goldenBall = Instantiate(goldenBallPrefab);
            goldenBallPool.Enqueue(goldenBall);
            goldenBall.SetActive(false);
            goldenBall.transform.SetParent(ballsParent);
            goldenBall.transform.localScale = new Vector3(goldenBallSize, goldenBallSize, goldenBallSize);
        }
        #endregion

        #region Football Ball
        for (int i = 0; i < footballBallPoolsize; i++)
        {
            GameObject footballBall = Instantiate(footballBallPrefab);
            footballBallPool.Enqueue(footballBall);
            footballBall.SetActive(false);
            footballBall.transform.SetParent(ballsParent);
            footballBall.transform.localScale = new Vector3(footballBallSize, footballBallSize, footballBallSize);
        }
        #endregion

        #region Sharpnel Ball
        for (int i = 0; i < sharpnelBallPoolsize; i++)
        {
            GameObject sharpnelBall = Instantiate(sharpnelBallPrefab);
            sharpnelBallPool.Enqueue(sharpnelBall);
            sharpnelBall.SetActive(false);
            sharpnelBall.transform.SetParent(ballsParent);
            sharpnelBall.transform.localScale = new Vector3(sharpnelBallSize, sharpnelBallSize, sharpnelBallSize);
        }
        #endregion

        #region Zonic Ball
        for (int i = 0; i < zonicBallPoolsize; i++)
        {
            GameObject zonicBall = Instantiate(zonicBallPrefab);
            zonicBallPool.Enqueue(zonicBall);
            zonicBall.SetActive(false);
            zonicBall.transform.SetParent(ballsParent);
            zonicBall.transform.localScale = new Vector3(zonicBallSize, zonicBallSize, zonicBallSize);
        }
        #endregion

        #region Apricot Ball
        for (int i = 0; i < apricotBallPoolsize; i++)
        {
            GameObject apricotBall = Instantiate(apricotBallPrefab);
            apricotBallPool.Enqueue(apricotBall);
            apricotBall.SetActive(false);
            apricotBall.transform.SetParent(ballsParent);
            apricotBall.transform.localScale = new Vector3(apricotBallSize, apricotBallSize, apricotBallSize);
        }
        #endregion

        #region Peggo Ball
        for (int i = 0; i < peggoBallPoolsize; i++)
        {
            GameObject peggoBall = Instantiate(peggoBallPrefab);
            peggoBallPool.Enqueue(peggoBall);
            peggoBall.SetActive(false);
            peggoBall.transform.SetParent(ballsParent);
            peggoBall.transform.localScale = new Vector3(peggoBallSize, peggoBallSize, peggoBallSize);
        }
        #endregion

        #region Ghost Ball
        for (int i = 0; i < ghostBallPoolsize; i++)
        {
            GameObject ghostBall = Instantiate(ghostBallPrefab);
            ghostBallPool.Enqueue(ghostBall);
            ghostBall.SetActive(false);
            ghostBall.transform.SetParent(ballsParent);
            ghostBall.transform.localScale = new Vector3(ghostBallSize, ghostBallSize, ghostBallSize);
        }
        #endregion

        #region Star Ball
        for (int i = 0; i < starBallPoolsize; i++)
        {
            GameObject starBall = Instantiate(starBallPrefab);
            starBallPool.Enqueue(starBall);
            starBall.SetActive(false);
            starBall.transform.SetParent(ballsParent);
            starBall.transform.localScale = new Vector3(starBallSize, starBallSize, starBallSize);
        }
        #endregion

        #region Rainbow Ball
        for (int i = 0; i < rainbowBallPoolsize; i++)
        {
            GameObject rainbowBall = Instantiate(rainbowBallPrefab);
            rainbowBallPool.Enqueue(rainbowBall);
            rainbowBall.SetActive(false);
            rainbowBall.transform.SetParent(ballsParent);
            rainbowBall.transform.localScale = new Vector3(rainbowBallSize, rainbowBallSize, rainbowBallSize);
        }
        #endregion

        #region Glitchy Ball
        for (int i = 0; i < glitchyBallPoolsize; i++)
        {
            GameObject glitchyBall = Instantiate(glitchyBallPrefab);
            glitchyBallPool.Enqueue(glitchyBall);
            glitchyBall.SetActive(false);
            glitchyBall.transform.SetParent(ballsParent);
            glitchyBall.transform.localScale = new Vector3(glitchyBallSize, glitchyBallSize, glitchyBallSize);
        }
        #endregion

        #region Tiny Sharpnel Ball
        for (int i = 0; i < tinySharpelBallPoolsize; i++)
        {
            GameObject tinySharpnel = Instantiate(tinySharpelBallPrefab);
            tinySharpelBallPool.Enqueue(tinySharpnel);
            tinySharpnel.SetActive(false);
            tinySharpnel.transform.SetParent(ballsParent);
            tinySharpnel.transform.localScale = new Vector3(tinySharpelBallSize, tinySharpelBallSize, tinySharpelBallSize);
        }
        #endregion

        #region Tiny Ring Ball
        for (int i = 0; i < tinyRingBallPoolsize; i++)
        {
            GameObject tinySharpnel = Instantiate(tinyRingBallPrefab);
            tinyRingBallPool.Enqueue(tinySharpnel);
            tinySharpnel.SetActive(false);
            tinySharpnel.transform.SetParent(ballsParent);
            tinySharpnel.transform.localScale = new Vector3(tinyRingBallSize, tinyRingBallSize, tinyRingBallSize);
        }
        #endregion

        #region Tiny Glitchy
        for (int i = 0; i < tinyGlitchyBallPoolsize; i++)
        {
            GameObject glitchy = Instantiate(tinyGlitchyBallPrefab);
            tinyGlitchyBallPool.Enqueue(glitchy);
            glitchy.SetActive(false);
            glitchy.transform.SetParent(ballsParent);
            glitchy.transform.localScale = new Vector3(tinyGlitchyBallSize, tinyGlitchyBallSize, tinyGlitchyBallSize);
        }
        #endregion

        #region Gold Coin
        for (int i = 0; i < goldCoinPoolSize; i++)
        {
            GameObject goldCoin = Instantiate(goldCoinPrefab);
            goldCoinPool.Enqueue(goldCoin);
            goldCoin.SetActive(false);
            goldCoin.transform.SetParent(coinParent);
            goldCoin.transform.localScale = new Vector3(goldCoinSize, goldCoinSize, goldCoinSize);
        }
        #endregion

        #region Prestige Gem
        for (int i = 0; i < prestigeGemPoolSize; i++)
        {
            GameObject prestigeGem = Instantiate(prestigeGemPrefab);
            prestigeGemPool.Enqueue(prestigeGem);
            prestigeGem.SetActive(false);
            prestigeGem.transform.SetParent(coinParent);
            prestigeGem.transform.localScale = new Vector3(prestigeGemSize, prestigeGemSize, prestigeGemSize);
        }
        #endregion
    }

    #region Aqua Ball
    public GameObject GetAquaBallFromPool()
    {
        if (aquaBallPool.Count > 0)
        {
            GameObject aquaBall = aquaBallPool.Dequeue();
            aquaBall.SetActive(true);
            return aquaBall;
        }
        else
        {
            GameObject aquaBall = Instantiate(aquaBallPrefab);
            return aquaBall;
        }
    }

    public void ReturnAquaBallFromPool(GameObject aquaBall)
    {
        aquaBallPool.Enqueue(aquaBall);
        aquaBall.SetActive(false);
    }
    #endregion

    #region Mud Ball
    public GameObject GetMudBallFromPool()
    {
        if (mudBallPool.Count > 0)
        {
            GameObject mudBall = mudBallPool.Dequeue();
            mudBall.SetActive(true);
            return mudBall;
        }
        else
        {
            GameObject mudBall = Instantiate(mudBallPrefab);
            return mudBall;
        }
    }

    public void ReturnMudBallFromPool(GameObject mudBall)
    {
        mudBallPool.Enqueue(mudBall);
        mudBall.SetActive(false);
    }
    #endregion

    #region Basket Ball
    public GameObject GetBasketBallFromPool()
    {
        if (basketBallPool.Count > 0)
        {
            GameObject basketBall = basketBallPool.Dequeue();
            basketBall.SetActive(true);
            return basketBall;
        }
        else
        {
            GameObject basketBall = Instantiate(basketBallPrefab);
            return basketBall;
        }
    }

    public void ReturnBasketBallFromPool(GameObject basketBall)
    {
        basketBallPool.Enqueue(basketBall);
        basketBall.SetActive(false);
    }
    #endregion

    #region Plum Ball
    public GameObject GetPlumBallFromPool()
    {
        if (plumBallPool.Count > 0)
        {
            GameObject plumBall = plumBallPool.Dequeue();
            plumBall.SetActive(true);
            return plumBall;
        }
        else
        {
            GameObject plumBall = Instantiate(plumBallPrefab);
            return plumBall;
        }
    }

    public void ReturnPlumBallFromPool(GameObject plumBall)
    {
        plumBallPool.Enqueue(plumBall);
        plumBall.SetActive(false);
    }
    #endregion

    #region Sticky Ball
    public GameObject GetStickyBallFromPool()
    {
        if (stickyBallPool.Count > 0)
        {
            GameObject stickyBall = stickyBallPool.Dequeue();
            stickyBall.SetActive(true);
            return stickyBall;
        }
        else
        {
            GameObject stickyBall = Instantiate(stickyBallPrefab);
            return stickyBall;
        }
    }

    public void ReturnStickyBallFromPool(GameObject stickyBall)
    {
        stickyBallPool.Enqueue(stickyBall);
        stickyBall.SetActive(false);
    }
    #endregion

    #region Candy Ball
    public GameObject GetCandyBallFromPool()
    {
        if (candyBallPool.Count > 0)
        {
            GameObject candyBall = candyBallPool.Dequeue();
            candyBall.SetActive(true);
            return candyBall;
        }
        else
        {
            GameObject candyBall = Instantiate(candyBallPrefab);
            return candyBall;
        }
    }

    public void ReturnCandyBallFromPool(GameObject candyBall)
    {
        candyBallPool.Enqueue(candyBall);
        candyBall.SetActive(false);
    }
    #endregion

    #region Cookie Ball
    public GameObject GetCookieBallFromPool()
    {
        if (cookieBallPool.Count > 0)
        {
            GameObject cookieBall = cookieBallPool.Dequeue();
            cookieBall.SetActive(true);
            return cookieBall;
        }
        else
        {
            GameObject cookieBall = Instantiate(cookieBallPrefab);
            return cookieBall;
        }
    }

    public void ReturnCookieBallFromPool(GameObject cookieBall)
    {
        cookieBallPool.Enqueue(cookieBall);
        cookieBall.SetActive(false);
    }
    #endregion

    #region Lime Ball
    public GameObject GetLimeBallFromPool()
    {
        if (limeBallPool.Count > 0)
        {
            GameObject limeBall = limeBallPool.Dequeue();
            limeBall.SetActive(true);
            return limeBall;
        }
        else
        {
            GameObject limeBall = Instantiate(limeBallPrefab);
            return limeBall;
        }
    }

    public void ReturnLimeBallFromPool(GameObject limeBall)
    {
        limeBallPool.Enqueue(limeBall);
        limeBall.SetActive(false);
    }
    #endregion

    #region Golden Ball
    public GameObject GetGoldenBallFromPool()
    {
        if (goldenBallPool.Count > 0)
        {
            GameObject goldenBall = goldenBallPool.Dequeue();
            goldenBall.SetActive(true);
            return goldenBall;
        }
        else
        {
            GameObject goldenBall = Instantiate(goldenBallPrefab);
            return goldenBall;
        }
    }

    public void ReturnGoldenBallFromPool(GameObject goldenBall)
    {
        goldenBallPool.Enqueue(goldenBall);
        goldenBall.SetActive(false);
    }
    #endregion

    #region Football Ball
    public GameObject GetFootballBallFromPool()
    {
        if (footballBallPool.Count > 0)
        {
            GameObject footballBall = footballBallPool.Dequeue();
            footballBall.SetActive(true);
            return footballBall;
        }
        else
        {
            GameObject footballBall = Instantiate(footballBallPrefab);
            return footballBall;
        }
    }

    public void ReturnFootballBallFromPool(GameObject footballBall)
    {
        footballBallPool.Enqueue(footballBall);
        footballBall.SetActive(false);
    }
    #endregion

    #region Sharpnel Ball
    public GameObject GetSharpnelBallFromPool()
    {
        if (sharpnelBallPool.Count > 0)
        {
            GameObject sharpnelBall = sharpnelBallPool.Dequeue();
            sharpnelBall.SetActive(true);
            return sharpnelBall;
        }
        else
        {
            GameObject sharpnelBall = Instantiate(sharpnelBallPrefab);
            return sharpnelBall;
        }
    }

    public void ReturnSharpnelBallFromPool(GameObject sharpnelBall)
    {
        sharpnelBallPool.Enqueue(sharpnelBall);
        sharpnelBall.SetActive(false);
    }
    #endregion

    #region Zonic Ball
    public GameObject GetZonicBallFromPool()
    {
        if (zonicBallPool.Count > 0)
        {
            GameObject zonicBall = zonicBallPool.Dequeue();
            zonicBall.SetActive(true);
            return zonicBall;
        }
        else
        {
            GameObject zonicBall = Instantiate(zonicBallPrefab);
            return zonicBall;
        }
    }

    public void ReturnZonicBallFromPool(GameObject zonicBall)
    {
        zonicBallPool.Enqueue(zonicBall);
        zonicBall.SetActive(false);
    }
    #endregion

    #region Apricot Ball
    public GameObject GetApricotBallFromPool()
    {
        if (apricotBallPool.Count > 0)
        {
            GameObject apricotBall = apricotBallPool.Dequeue();
            apricotBall.SetActive(true);
            return apricotBall;
        }
        else
        {
            GameObject apricotBall = Instantiate(apricotBallPrefab);
            return apricotBall;
        }
    }

    public void ReturnApricotBallFromPool(GameObject apricotBall)
    {
        apricotBallPool.Enqueue(apricotBall);
        apricotBall.SetActive(false);
    }
    #endregion

    #region Peggo Ball
    public GameObject GetPeggoBallFromPool()
    {
        if (peggoBallPool.Count > 0)
        {
            GameObject peggoBall = peggoBallPool.Dequeue();
            peggoBall.SetActive(true);
            return peggoBall;
        }
        else
        {
            GameObject peggoBall = Instantiate(peggoBallPrefab);
            return peggoBall;
        }
    }

    public void ReturnPeggoBallFromPool(GameObject peggoBall)
    {
        peggoBallPool.Enqueue(peggoBall);
        peggoBall.SetActive(false);
    }
    #endregion

    #region Ghost Ball
    public GameObject GetGhostBallFromPool()
    {
        if (ghostBallPool.Count > 0)
        {
            GameObject ghostBall = ghostBallPool.Dequeue();
            ghostBall.SetActive(true);
            return ghostBall;
        }
        else
        {
            GameObject ghostBall = Instantiate(ghostBallPrefab);
            return ghostBall;
        }
    }

    public void ReturnGhostBallFromPool(GameObject ghostBall)
    {
        ghostBallPool.Enqueue(ghostBall);
        ghostBall.SetActive(false);
    }
    #endregion

    #region Star Ball
    public GameObject GetStarBallFromPool()
    {
        if (starBallPool.Count > 0)
        {
            GameObject starBall = starBallPool.Dequeue();
            starBall.SetActive(true);
            return starBall;
        }
        else
        {
            GameObject starBall = Instantiate(starBallPrefab);
            return starBall;
        }
    }

    public void ReturnStarBallFromPool(GameObject starBall)
    {
        starBallPool.Enqueue(starBall);
        starBall.SetActive(false);
    }
    #endregion

    #region Rainbow Ball
    public GameObject GetRainbowBallFromPool()
    {
        if (rainbowBallPool.Count > 0)
        {
            GameObject rainbowBall = rainbowBallPool.Dequeue();
            rainbowBall.SetActive(true);
            return rainbowBall;
        }
        else
        {
            GameObject rainbowBall = Instantiate(rainbowBallPrefab);
            return rainbowBall;
        }
    }

    public void ReturnRainbowBallFromPool(GameObject rainbowBall)
    {
        rainbowBallPool.Enqueue(rainbowBall);
        rainbowBall.SetActive(false);
    }
    #endregion

    #region Glitchy Ball
    public GameObject GetGlitchyBallFromPool()
    {
        if (glitchyBallPool.Count > 0)
        {
            GameObject glitchyBall = glitchyBallPool.Dequeue();
            glitchyBall.SetActive(true);
            return glitchyBall;
        }
        else
        {
            GameObject glitchyBall = Instantiate(glitchyBallPrefab);
            return glitchyBall;
        }
    }

    public void ReturnGlitchyBallFromPool(GameObject glitchyBall)
    {
        glitchyBallPool.Enqueue(glitchyBall);
        glitchyBall.SetActive(false);
    }
    #endregion

    #region Tiny Sharpnel Ball
    public GameObject GetTinyShaprnelBallFromPool()
    {
        if (tinySharpelBallPool.Count > 0)
        {
            GameObject tinySharpnel = tinySharpelBallPool.Dequeue();
            tinySharpnel.SetActive(true);
            return tinySharpnel;
        }
        else
        {
            GameObject tinySharpnel = Instantiate(tinySharpelBallPrefab);
            return tinySharpnel;
        }
    }

    public void ReturnTinyShaprnelBallFromPool(GameObject tinySharpnel)
    {
        tinySharpelBallPool.Enqueue(tinySharpnel);
        tinySharpnel.SetActive(false);
    }
    #endregion

    #region Tiny Ring Ball
    public GameObject GetTinyRingBallFromPool()
    {
        if (tinyRingBallPool.Count > 0)
        {
            GameObject tinyRing = tinyRingBallPool.Dequeue();
            tinyRing.SetActive(true);
            return tinyRing;
        }
        else
        {
            GameObject tinyRing = Instantiate(tinyRingBallPrefab);
            return tinyRing;
        }
    }

    public void ReturnTinyRingBallFromPool(GameObject tinyRing)
    {
        tinyRingBallPool.Enqueue(tinyRing);
        tinyRing.SetActive(false);
    }
    #endregion

    #region Tiny Ring Ball
    public GameObject GetTinyGlitchyBallFromPool()
    {
        if (tinyGlitchyBallPool.Count > 0)
        {
            GameObject glitchyBall = tinyGlitchyBallPool.Dequeue();
            glitchyBall.SetActive(true);
            return glitchyBall;
        }
        else
        {
            GameObject glitchyBall = Instantiate(tinyGlitchyBallPrefab);
            return glitchyBall;
        }
    }

    public void ReturnTinyGlitchyBallFromPool(GameObject glitchyBall)
    {
        tinyGlitchyBallPool.Enqueue(glitchyBall);
        glitchyBall.SetActive(false);
    }
    #endregion

    #region Gold Coin
    public GameObject GetGoldCoinFromPool()
    {
        if (goldCoinPool.Count > 0)
        {
            GameObject goldCoin = goldCoinPool.Dequeue();
            goldCoin.SetActive(true);
            return goldCoin;
        }
        else
        {
            GameObject goldCoin = Instantiate(goldCoinPrefab);
            return goldCoin;
        }
    }

    public void ReturnGoldCoinFromPool(GameObject goldCoin)
    {
        goldCoinPool.Enqueue(goldCoin);
        goldCoin.SetActive(false);
    }
    #endregion

    #region PrestigeGem
    public GameObject GetPrestigeGemFromPool()
    {
        if (prestigeGemPool.Count > 0)
        {
            GameObject prestigeGem = prestigeGemPool.Dequeue();
            prestigeGem.SetActive(true);
            return prestigeGem;
        }
        else
        {
            GameObject prestigeGem = Instantiate(prestigeGemPrefab);
            return prestigeGem;
        }
    }

    public void ReturnPrestigeGemFromPool(GameObject prestigeGem)
    {
        prestigeGemPool.Enqueue(prestigeGem);
        prestigeGem.SetActive(false);
    }
    #endregion
}
