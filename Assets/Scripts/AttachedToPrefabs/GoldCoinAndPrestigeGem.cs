using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinAndPrestigeGem : MonoBehaviour
{
    public GameObject chall;
    public Challenges challScript;

    public bool isGoldCoin, isPrestigePeg;

    public GameObject pointsMechanics;
    public PointsMechanics pointsMechanicsScript;

    public double peggoPoints, glitchyPoints;
    public int peggoPrestigePoints;

    public void Awake()
    {
        chall = GameObject.Find("ChallengesScriptExclude_Keep_MainGame");
        if (chall != null)
        {
            challScript = chall.GetComponent<Challenges>();
        }

        pointsMechanics = GameObject.Find("AllPointsMechanics");
        pointsMechanicsScript = pointsMechanics.GetComponent<PointsMechanics>();

        if (gameObject.tag == "GoldCoin") { isGoldCoin = true; }
        if (gameObject.tag == "PrestigeGem") { isPrestigePeg = true; }
    }

    private void OnEnable()
    {
        if(isGoldCoin== true)
        {
            peggoPoints = (BallUpgrades.peggoBallGold * (1 + Prestige.activeGoldIncrease + Prestige.prestigeGoldIncrease));
            glitchyPoints = (BallUpgrades.glitchyBallGold * (1 + Prestige.activeGoldIncrease + Prestige.prestigeGoldIncrease));
        }

        SetPos();
    }

    public void SetPos()
    {
        int randomx = Random.Range(-887, 264);
        int random7 = Random.Range(198, -400);

        gameObject.transform.localPosition = new Vector2(randomx, random7);
    }

    public void Chall()
    {
        Challenges.prestigeGemsHit += 1;
        if (Challenges.challCompleted[31] == false && Challenges.challFinished[31] == false)
        {
            if (SettingsOptions.isInChallengeTab == true)
            {
                challScript.ChallengeProgress(32, Challenges.prestigeGemsHit);
            }
            challScript.CheckCompleted(32, Challenges.prestigeGemsHit);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            SetPos();
        }

        if (collision.gameObject.layer == 19)
        {
            Chall();

            if (isPrestigePeg == true)
            {
                pointsMechanicsScript.HitPrestigePeg(Prestige.prestigePointsIncrease, collision.transform.position, false, true, false);

                ObjectPool2.instance.ReturnPrestigeGemFromPool(gameObject);
            }
        }
        else if (collision.gameObject.layer == 20)
        {
            Chall();

            if (isPrestigePeg == true)
            {
                pointsMechanicsScript.HitPrestigePeg(Prestige.prestigePointsIncrease, collision.transform.position, false, true, false);

                ObjectPool2.instance.ReturnPrestigeGemFromPool(gameObject);
            }
        }
    }

    private void OnDisable()
    {
        if (isGoldCoin == true)
        {
            ObjectPool2.instance.ReturnGoldCoinFromPool(gameObject);
        }
        if (isPrestigePeg == true)
        {
            ObjectPool2.instance.ReturnPrestigeGemFromPool(gameObject);
        }
    }
}
