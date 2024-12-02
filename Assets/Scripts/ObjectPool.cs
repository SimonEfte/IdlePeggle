using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public Transform ballsParent, pegsParent, pegHitParent;
    public Transform textPopUpParent;

    #region Balls
    [SerializeField] private GameObject basicBallPrefab;
    private Queue<GameObject> basicBallPool = new Queue<GameObject>();
    [SerializeField] private int basicBallPoolSize = 50;
    public static float basicBallSize;

    [SerializeField] private GameObject redBallPrefab;
    private Queue<GameObject> redBallPool = new Queue<GameObject>();
    [SerializeField] private int redBallPoolSize = 50;
    public static float redBallSize;

    [SerializeField] private GameObject rockBallPrefab;
    private Queue<GameObject> rockBallPool = new Queue<GameObject>();
    [SerializeField] private int rockBallPoolSize = 50;
    public static float rockBallSize;

    [SerializeField] private GameObject bombBallPrefab;
    private Queue<GameObject> bombBallPool = new Queue<GameObject>();
    [SerializeField] private int bombBallPoolSize = 50;
    public static float bombBallSize;

    [SerializeField] private GameObject tinyBallPrefab;
    private Queue<GameObject> tinyBallPool = new Queue<GameObject>();
    [SerializeField] private int tinyBallPoolsize = 50;
    public static float tinyBallSize;
    #endregion

    #region Texts
    [SerializeField] private TextMeshProUGUI pegPointTextPrefab;
    private Queue<TextMeshProUGUI> pegPointPool = new Queue<TextMeshProUGUI>();
    [SerializeField] private int pegPointPoolSize = 70;
    public static float pegPointSize;

    [SerializeField] private TextMeshProUGUI prestigeTextPrefab;
    private Queue<TextMeshProUGUI> prestigeTextPool = new Queue<TextMeshProUGUI>();
    [SerializeField] private int prestigeTextPoolSize = 150;
    public static float prestigePegSize;
    #endregion

    [SerializeField] private GameObject pegsPrefab;
    private Queue<GameObject> pegsPool = new Queue<GameObject>();
    [SerializeField] private int pegsPoolSize = 50;
    public static float pegsSize;


    [SerializeField] private GameObject pegHitPrefab;
    private Queue<GameObject> pegHitPool = new Queue<GameObject>();
    [SerializeField] private int pegHitPoolSize = 50;
    public static float pegHitSize;

    public void Awake()
    {
        pegsSize = 0.205f;
        pegHitSize = 0.22f;

        basicBallSize = 0.4f;
        pegPointSize = 0.9f;
        prestigePegSize = 1.2f;
        redBallSize = 0.34f;
        rockBallSize = 0.55f;
        bombBallSize = 0.5f;
        tinyBallSize = 0.7f;

        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        #region Regular Ball
        for (int i = 0; i < basicBallPoolSize; i++)
        {
            GameObject basicBall = Instantiate(basicBallPrefab);
            basicBallPool.Enqueue(basicBall);
            basicBall.SetActive(false);
            basicBall.transform.SetParent(ballsParent);
            basicBall.transform.localScale = new Vector3(basicBallSize, basicBallSize, basicBallSize);
        }
        #endregion

        #region Red Ball/BouncyBall
        for (int i = 0; i < redBallPoolSize; i++)
        {
            GameObject redBall = Instantiate(redBallPrefab);
            redBallPool.Enqueue(redBall);
            redBall.SetActive(false);
            redBall.transform.SetParent(ballsParent);
            redBall.transform.localScale = new Vector3(redBallSize, redBallSize, redBallSize);
        }
        #endregion

        #region Point Text
        for (int i = 0; i < pegPointPoolSize; i++)
        {
            TextMeshProUGUI pointText = Instantiate(pegPointTextPrefab);
            pegPointPool.Enqueue(pointText);
            pointText.gameObject.SetActive(false);
            pointText.transform.SetParent(textPopUpParent);
            pointText.transform.localScale = new Vector3(pegPointSize, pegPointSize, pegPointSize);
        }
        #endregion

        #region Point Text
        for (int i = 0; i < prestigeTextPoolSize; i++)
        {
            TextMeshProUGUI prestigeText = Instantiate(prestigeTextPrefab);
            prestigeTextPool.Enqueue(prestigeText);
            prestigeText.gameObject.SetActive(false);
            prestigeText.transform.SetParent(textPopUpParent);
            prestigeText.transform.localScale = new Vector3(prestigePegSize, prestigePegSize, prestigePegSize);
        }
        #endregion

        #region Rock Ball
        for (int i = 0; i < rockBallPoolSize; i++)
        {
            GameObject rockBall = Instantiate(rockBallPrefab);
            rockBallPool.Enqueue(rockBall);
            rockBall.SetActive(false);
            rockBall.transform.SetParent(ballsParent);
            rockBall.transform.localScale = new Vector3(rockBallSize, rockBallSize, rockBallSize);
        }
        #endregion

        #region Bomb Ball
        for (int i = 0; i < bombBallPoolSize; i++)
        {
            GameObject bombBall = Instantiate(bombBallPrefab);
            bombBallPool.Enqueue(bombBall);
            bombBall.SetActive(false);
            bombBall.transform.SetParent(ballsParent);
            bombBall.transform.localScale = new Vector3(bombBallSize, bombBallSize, bombBallSize);
        }
        #endregion

        #region Tiny Ball
        for (int i = 0; i < tinyBallPoolsize; i++)
        {
            GameObject tinyBall = Instantiate(tinyBallPrefab);
            tinyBallPool.Enqueue(tinyBall);
            tinyBall.SetActive(false);
            tinyBall.transform.SetParent(ballsParent);
            tinyBall.transform.localScale = new Vector3(tinyBallSize, tinyBallSize, tinyBallSize);
        }
        #endregion

        #region Peg hit
        for (int i = 0; i < pegHitPoolSize; i++)
        {
            GameObject pegHit = Instantiate(pegHitPrefab);
            pegHitPool.Enqueue(pegHit);
            pegHit.SetActive(false);
            pegHit.transform.SetParent(pegHitParent);
            pegHit.transform.localScale = new Vector3(pegHitSize, pegHitSize, pegHitSize);
        }
        #endregion

        #region All pegs
        for (int i = 0; i < pegsPoolSize; i++)
        {
            GameObject pegs = Instantiate(pegsPrefab);
            pegsPool.Enqueue(pegs);
            pegs.SetActive(false);
            pegs.transform.SetParent(pegsParent);
            pegs.transform.localScale = new Vector3(pegsSize, pegsSize, pegsSize);
        }
        #endregion
    }


    #region Basic Ball
    public GameObject GetBasicBallFromPool()
    {
        if (basicBallPool.Count > 0)
        {
            GameObject basicBall = basicBallPool.Dequeue();
            basicBall.SetActive(true);
            return basicBall;
        }
        else
        {
            GameObject basicBall = Instantiate(basicBallPrefab);
            return basicBall;
        }
    }

    public void ReturnBasicBallFromPool(GameObject basicBall)
    {
        basicBallPool.Enqueue(basicBall);
        basicBall.SetActive(false);
    }
    #endregion

    #region Red Ball
    public GameObject GetRedBallFromPool()
    {
        if (redBallPool.Count > 0)
        {
            GameObject redBall = redBallPool.Dequeue();
            redBall.SetActive(true);
            return redBall;
        }
        else
        {
            GameObject redBall = Instantiate(redBallPrefab);
            return redBall;
        }
    }

    public void ReturnRedBallFromPool(GameObject redBall)
    {
        redBallPool.Enqueue(redBall);
        redBall.SetActive(false);
    }
    #endregion

    #region Rock Ball
    public GameObject GetRockBallFromPool()
    {
        if (rockBallPool.Count > 0)
        {
            GameObject rockBall = rockBallPool.Dequeue();
            rockBall.SetActive(true);
            return rockBall;
        }
        else
        {
            GameObject rockBall = Instantiate(rockBallPrefab);
            return rockBall;
        }
    }

    public void ReturnRockBallFromPool(GameObject rockBall)
    {
        rockBallPool.Enqueue(rockBall);
        rockBall.SetActive(false);
    }
    #endregion

    #region Bomb Ball
    public GameObject GetBombBallFromPool()
    {
        if (bombBallPool.Count > 0)
        {
            GameObject bombBall = bombBallPool.Dequeue();
            bombBall.SetActive(true);
            return bombBall;
        }
        else
        {
            GameObject bombBall = Instantiate(bombBallPrefab);
            return bombBall;
        }
    }

    public void ReturnBombBallFromPool(GameObject bombBall)
    {
        bombBallPool.Enqueue(bombBall);
        bombBall.SetActive(false);
    }
    #endregion

    #region Tiny Ball
    public GameObject GetTinyBallFromPool()
    {
        if (tinyBallPool.Count > 0)
        {
            GameObject tinyBall = tinyBallPool.Dequeue();
            tinyBall.SetActive(true);
            return tinyBall;
        }
        else
        {
            GameObject tinyBall = Instantiate(tinyBallPrefab);
            return tinyBall;
        }
    }

    public void ReturnTinyBallFromPool(GameObject tinyBall)
    {
        tinyBallPool.Enqueue(tinyBall);
        tinyBall.SetActive(false);
    }
    #endregion

    #region Peg Point Pop Up
    public TextMeshProUGUI GetPegPointPopUpFromPool()
    {
        if (pegPointPool.Count > 0)
        {
            TextMeshProUGUI pegPupUp = pegPointPool.Dequeue();
            pegPupUp.gameObject.SetActive(true);
            return pegPupUp;
        }
        else
        {
            TextMeshProUGUI pegPupUp = Instantiate(pegPointTextPrefab);
            return pegPupUp;
        }
    }

    public void ReturnPegPopUpFromPool(TextMeshProUGUI pegPopUp)
    {
        pegPointPool.Enqueue(pegPopUp);
        pegPopUp.gameObject.SetActive(false);
    }
    #endregion

    #region Prestige text
    public TextMeshProUGUI GetPrestigeTextFromPool()
    {
        if (prestigeTextPool.Count > 0)
        {
            TextMeshProUGUI prestigeText = prestigeTextPool.Dequeue();
            prestigeText.gameObject.SetActive(true);
            return prestigeText;
        }
        else
        {
            TextMeshProUGUI prestigeText = Instantiate(prestigeTextPrefab);
            return prestigeText;
        }
    }

    public void ReturnPRestigeTextFromPool(TextMeshProUGUI prestigeText)
    {
        prestigeTextPool.Enqueue(prestigeText);
        prestigeText.gameObject.SetActive(false);
    }
    #endregion

    #region Pegs
    public GameObject GetPegsFromPool()
    {
        if (pegsPool.Count > 0)
        {
            GameObject pegs = pegsPool.Dequeue();
            pegs.SetActive(true);
            return pegs;
        }
        else
        {
            GameObject pegs = Instantiate(pegsPrefab);
            return pegs;
        }
    }

    public void ReturnPegsFromPool(GameObject pegs)
    {
        pegsPool.Enqueue(pegs);
        pegs.SetActive(false);
    }
    #endregion

    #region Peg Hit
    public GameObject GetPegHitFromPool()
    {
        if (pegHitPool.Count > 0)
        {
            PegHit.pegHitAmount += 1;
            GameObject pegHit = pegHitPool.Dequeue();
           
            pegHit.SetActive(true);
            return pegHit;
        }
        else
        {
            GameObject pegHit = Instantiate(pegHitPrefab);
            return pegHit;
        }
    }

    public void ReturnPegHitFromPool(GameObject pegHit)
    {
        pegHitPool.Enqueue(pegHit);
        pegHit.SetActive(false);
    }
    #endregion
}
