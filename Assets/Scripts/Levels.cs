using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Levels : MonoBehaviour, IDataPersistence
{
    public static int levelChosen;

    public GameObject level1Background, level1Walls;
    public GameObject level2Background, level2Walls;
    public GameObject level3Background, level4Background, level5Background, level6Background, level7Background, level8Background, level9Background, level10Background;
    public Transform level1Levels, level2Levels, level3Levels, level4Levels, level5Levels, level6Levels, level7Levels, level8Levels, level9Levels, level10Levels;

    public static int fullFillShots;

    public void Awake()
    {
        #region Load clear saves
        if(GameData.isDemo == false)
        {
            for (int i = 0; i < lvl1Clear.Length; i++)
            {
                lvl1Clear[i] = PlayerPrefs.GetInt("clear" + i);
            }

            for (int i = 0; i < lvl2Clear.Length; i++)
            {
                lvl2Clear[i] = PlayerPrefs.GetInt("clear2" + i);
            }

            for (int i = 0; i < lvl3Clear.Length; i++)
            {
                lvl3Clear[i] = PlayerPrefs.GetInt("clear3" + i);
            }

            for (int i = 0; i < lvl4Clear.Length; i++)
            {
                lvl4Clear[i] = PlayerPrefs.GetInt("clear4" + i);
            }

            for (int i = 0; i < lvl5Clear.Length; i++)
            {
                lvl5Clear[i] = PlayerPrefs.GetInt("clear5" + i);
            }

            for (int i = 0; i < lvl6Clear.Length; i++)
            {
                lvl6Clear[i] = PlayerPrefs.GetInt("clear6" + i);
            }

            for (int i = 0; i < lvl7Clear.Length; i++)
            {
                lvl7Clear[i] = PlayerPrefs.GetInt("clear7" + i);
            }

            for (int i = 0; i < lvl8Clear.Length; i++)
            {
                lvl8Clear[i] = PlayerPrefs.GetInt("clear8" + i);
            }

            for (int i = 0; i < lvl9Clear.Length; i++)
            {
                lvl9Clear[i] = PlayerPrefs.GetInt("clear9" + i);
            }

            for (int i = 0; i < lvl10Clear.Length; i++)
            {
                lvl10Clear[i] = PlayerPrefs.GetInt("clear10" + i);
            }
        }
        #endregion
       
        #region Load level boards
        for (int i = 0; i < 15; i++)
        {
            level2Boards[i] = Instantiate(level2BoardsPrefabs[i]);
            level2Boards[i].transform.SetParent(level2Levels);
            level2Boards[i].transform.localScale = new Vector3(1, 1, 1);
            level2Boards[i].transform.localPosition = new Vector3(-9.2f, 0, 0);
        }

        if(GameData.isDemo == false)
        {
            for (int i = 0; i < 16; i++)
            {
                level3Boards[i] = Instantiate(level3BoardsPrefabs[i]);
                level3Boards[i].transform.SetParent(level3Levels);
                level3Boards[i].transform.localScale = new Vector3(1, 1, 1);
                level3Boards[i].transform.localPosition = new Vector3(-9.2f, 0, 0);
            }

            for (int i = 0; i < 16; i++)
            {
                level4Boards[i] = Instantiate(level4BoardsPrefabs[i]);
                level4Boards[i].transform.SetParent(level4Levels);
                level4Boards[i].transform.localScale = new Vector3(1, 1, 1);
                level4Boards[i].transform.localPosition = new Vector3(-9.2f, 0, 0);
            }

            for (int i = 0; i < 17; i++)
            {
                level5Boards[i] = Instantiate(level5BoardsPrefabs[i]);
                level5Boards[i].transform.SetParent(level5Levels);
                level5Boards[i].transform.localScale = new Vector3(1, 1, 1);
                level5Boards[i].transform.localPosition = new Vector3(-9f, 0, 0);
            }

            for (int i = 0; i < 17; i++)
            {
                level6Boards[i] = Instantiate(level6BoardsPrefabs[i]);
                level6Boards[i].transform.SetParent(level6Levels);
                level6Boards[i].transform.localScale = new Vector3(1, 1, 1);
                level6Boards[i].transform.localPosition = new Vector3(-9.2f, 0, 0);
            }

            for (int i = 0; i < 18; i++)
            {
                level7Boards[i] = Instantiate(level7BoardsPrefabs[i]);
                level7Boards[i].transform.SetParent(level7Levels);
                level7Boards[i].transform.localScale = new Vector3(1, 1, 1);
                level7Boards[i].transform.localPosition = new Vector3(0, 0, 0);
            }

            for (int i = 0; i < 18; i++)
            {
                level8Boards[i] = Instantiate(level8BoardsPrefabs[i]);
                level8Boards[i].transform.SetParent(level8Levels);
                level8Boards[i].transform.localScale = new Vector3(1, 1, 1);
                level8Boards[i].transform.localPosition = new Vector3(0, 0, 0);
            }

            for (int i = 0; i < 19; i++)
            {
                level9Boards[i] = Instantiate(level9BoardsPrefabs[i]);
                level9Boards[i].transform.SetParent(level9Levels);
                level9Boards[i].transform.localScale = new Vector3(1, 1, 1);
                level9Boards[i].transform.localPosition = new Vector3(0, 0, 0);
            }

            for (int i = 0; i < 20; i++)
            {
                level10Boards[i] = Instantiate(level10BoardsPrefabs[i]);
                level10Boards[i].transform.SetParent(level10Levels);
                level10Boards[i].transform.localScale = new Vector3(1, 1, 1);
                level10Boards[i].transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        #endregion
    }

    public void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
       
        #region Check if board clear is 0
        if (board1Clears == 0) 
        {
            for (int i = 0; i < lvl1Clear.Length; i++)
            {
                lvl1Clear[i] = 0;
                PlayerPrefs.SetInt("clear" + i, lvl1Clear[i]);
                Challenges.challFinished[0] = false;
                Challenges.challCompleted[0] = false;
            }
        }
        if (board2Clears == 0)
        {
            for (int i = 0; i < lvl2Clear.Length; i++)
            {
                lvl2Clear[i] = 0;
                PlayerPrefs.SetInt("clear2" + i, lvl2Clear[i]);

                Challenges.challFinished[1] = false;
                Challenges.challCompleted[1] = false;
            }
        }
        if (board3Clears == 0)
        {
            for (int i = 0; i < lvl3Clear.Length; i++)
            {
                lvl3Clear[i] = 0;
                PlayerPrefs.SetInt("clear3" + i, lvl3Clear[i]);
                Challenges.challFinished[2] = false;
                Challenges.challCompleted[2] = false;
            }
        }
        if (board4Clears == 0)
        {
            for (int i = 0; i < lvl4Clear.Length; i++)
            {
                lvl4Clear[i] = 0;
                PlayerPrefs.SetInt("clear4" + i, lvl4Clear[i]);
                Challenges.challFinished[3] = false;
                Challenges.challCompleted[3] = false;
            }
        }
        if (board5Clears == 0)
        {
            for (int i = 0; i < lvl5Clear.Length; i++)
            {
                lvl5Clear[i] = 0;
                PlayerPrefs.SetInt("clear5" + i, lvl5Clear[i]);
                Challenges.challFinished[4] = false;
                Challenges.challCompleted[4] = false;
            }
        }
        if (board6Clears == 0)
        {
            for (int i = 0; i < lvl6Clear.Length; i++)
            {
                lvl6Clear[i] = 0;
                PlayerPrefs.SetInt("clear6" + i, lvl6Clear[i]);
                Challenges.challFinished[5] = false;
                Challenges.challCompleted[5] = false;
            }
        }
        if (board7Clears == 0)
        {
            for (int i = 0; i < lvl7Clear.Length; i++)
            {
                lvl7Clear[i] = 0;
                PlayerPrefs.SetInt("clear7" + i, lvl7Clear[i]);
                Challenges.challFinished[6] = false;
                Challenges.challCompleted[6] = false;
            }
        }
        if (board8Clears == 0)
        {
            for (int i = 0; i < lvl8Clear.Length; i++)
            {
                lvl8Clear[i] = 0;
                PlayerPrefs.SetInt("clear8" + i, lvl8Clear[i]);
                Challenges.challFinished[7] = false;
                Challenges.challCompleted[7] = false;
            }
        }
        if (board9Clears == 0)
        {
            for (int i = 0; i < lvl9Clear.Length; i++)
            {
                lvl9Clear[i] = 0;
                PlayerPrefs.SetInt("clear9" + i, lvl9Clear[i]);
                Challenges.challFinished[8] = false;
                Challenges.challCompleted[8] = false;
            }
        }
        if (board10Clears == 0)
        {
            for (int i = 0; i < lvl10Clear.Length; i++)
            {
                lvl10Clear[i] = 0;
                PlayerPrefs.SetInt("clear10" + i, lvl10Clear[i]);
                Challenges.challFinished[9] = false;
                Challenges.challCompleted[9] = false;
            }
        }
        #endregion

        SetNewText();

        SetLevel();
    }

    public int time;
    public Coroutine timerCoroutine;

    IEnumerator NewLevelTimer()
    {
        while (time < Prestige.goldClearTimerSeconds)
        {
            yield return new WaitForSeconds(1f);
            time += 1;
        }
    }

    #region Reset
    public void ResetLevelVariables()
    {
        goldClearBonusAnim.gameObject.SetActive(false);
        prestigePointClearBonusAnim.gameObject.SetActive(false);
            

        board1Clears = 0;
        board2Clears = 0;
        board3Clears = 0;
        board4Clears = 0;
        board5Clears = 0;
        board6Clears = 0;
        board7Clears = 0;
        board8Clears = 0;
        board9Clears = 0;
        board10Clears = 0;

        for (int i = 0; i < lvl1Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear" + i, 0);
        }

        for (int i = 0; i < lvl2Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear2" + i, 0);
        }

        for (int i = 0; i < lvl3Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear3" + i, 0);
        }

        for (int i = 0; i < lvl4Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear4" + i, 0);
        }

        for (int i = 0; i < lvl5Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear5" + i, 0);
        }

        for (int i = 0; i < lvl6Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear6" + i, 0);
        }

        for (int i = 0; i < lvl7Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear7" + i, 0);
        }

        for (int i = 0; i < lvl8Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear8" + i, 0);
        }

        for (int i = 0; i < lvl9Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear9" + i, 0);
        }

        for (int i = 0; i < lvl10Clear.Length; i++)
        {
            PlayerPrefs.SetInt("clear10" + i, 0);
        }
    }
    #endregion

    #region Set Level
    public void SetLevel()
    {
        SetAllIncative();

        level2Walls.SetActive(true);

        //Prestige.levelSelected = 10;

        if (Prestige.levelSelected == 1)
        {
            level1Levels.gameObject.SetActive(true);
            level1Background.SetActive(true);
        }
        else if (Prestige.levelSelected == 2)
        {
            level2Levels.gameObject.SetActive(true);
            level2Background.SetActive(true);
        }

        if(GameData.isDemo == false)
        {
            if (Prestige.levelSelected == 3)
            {
                level3Levels.gameObject.SetActive(true);
                level3Background.SetActive(true);
            }
            else if (Prestige.levelSelected == 4)
            {
                level4Levels.gameObject.SetActive(true);
                level4Background.SetActive(true);
            }
            else if(Prestige.levelSelected == 5)
            {
                level5Levels.gameObject.SetActive(true);
                level5Background.SetActive(true);
            }
            else if(Prestige.levelSelected == 6)
            {
                level6Levels.gameObject.SetActive(true);
                level6Background.SetActive(true);
            }
            else if(Prestige.levelSelected == 7)
            {
                level7Levels.gameObject.SetActive(true);
                level7Background.SetActive(true);
            }
            else if(Prestige.levelSelected == 8)
            {
                level8Levels.gameObject.SetActive(true);
                level8Background.SetActive(true);
            }
            else if(Prestige.levelSelected == 9)
            {
                level9Levels.gameObject.SetActive(true);
                level9Background.SetActive(true);
            }
            else if(Prestige.levelSelected == 10)
            {
                level10Levels.gameObject.SetActive(true);
                level10Background.SetActive(true);
            }
        }
        else
        {
            if(Prestige.levelSelected > 2)
            {
                if (Prestige.purchasedLevel2 == true)
                {
                    Prestige.levelSelected = 2;
                    level2Levels.gameObject.SetActive(true);
                    level2Background.SetActive(true);
                }
                else
                {
                    Prestige.levelSelected = 1;
                    level1Levels.gameObject.SetActive(true);
                    level1Background.SetActive(true);
                }
            }
        }

        SetRandomBoard(true);
    }
    #endregion

    #region Set All Levels Inactive
    public void SetAllIncative()
    {
        level1Walls.SetActive(false);
        level2Walls.SetActive(false);

        level1Levels.gameObject.SetActive(false);
        level2Levels.gameObject.SetActive(false);
        if(GameData.isDemo == false)
        {
            if(challScript != null)
            {
                level3Levels.gameObject.SetActive(false);
                level4Levels.gameObject.SetActive(false);
                level5Levels.gameObject.SetActive(false);
                level6Levels.gameObject.SetActive(false);
                level7Levels.gameObject.SetActive(false);
                level8Levels.gameObject.SetActive(false);
                level9Levels.gameObject.SetActive(false);
                level10Levels.gameObject.SetActive(false);
            }
        }

        level1Background.SetActive(false);
        level2Background.SetActive(false);
        if(GameData.isDemo == false)
        {
            if (challScript != null)
            {
                level3Background.SetActive(false);
                level4Background.SetActive(false);
                level5Background.SetActive(false);
                level6Background.SetActive(false);
                level7Background.SetActive(false);
                level8Background.SetActive(false);
                level9Background.SetActive(false);
                level10Background.SetActive(false);
            }
        }
    }
    #endregion

    public int levelNumber, level2Number, level3Number, level4Number, level5Number, level6Number, level7Number, level8Number, level9Number, level10Number;

    #region Cancel Board Anim
    public Coroutine level1Coroutine, level2Coroutine, level3Coroutine, level4Coroutine, level5Coroutine, level6Coroutine, level7Coroutine, level8Coroutine, level9Coroutine, level10Coroutine, coinCoroutine;

    public void CancelBoardAnim()
    {
        if(Prestige.levelSelected == 1) { if (level1Coroutine != null) { StopCoroutine(level1Coroutine); level1Coroutine = null; } }
        else if (Prestige.levelSelected == 2) { if (level2Coroutine != null) { StopCoroutine(level2Coroutine); level2Coroutine = null; } }
        else if(Prestige.levelSelected == 3) { if (level3Coroutine != null) { StopCoroutine(level3Coroutine); level3Coroutine = null; } }
        else if (Prestige.levelSelected == 4) { if (level4Coroutine != null) { StopCoroutine(level4Coroutine); level4Coroutine = null; } }
        else if (Prestige.levelSelected == 5) { if (level5Coroutine != null) { StopCoroutine(level5Coroutine); level5Coroutine = null; } }
        else if(Prestige.levelSelected == 6) { if (level6Coroutine != null) { StopCoroutine(level6Coroutine); level6Coroutine = null; } }
        else if(Prestige.levelSelected == 7) { if (level7Coroutine != null) { StopCoroutine(level7Coroutine); level7Coroutine = null; } }
        else if (Prestige.levelSelected == 8) { if (level8Coroutine != null) { StopCoroutine(level8Coroutine); level8Coroutine = null; } }
        else if(Prestige.levelSelected == 9) { if (level9Coroutine != null) { StopCoroutine(level9Coroutine); level9Coroutine = null; } }
        else if(Prestige.levelSelected == 10) { if (level10Coroutine != null) { StopCoroutine(level10Coroutine); level10Coroutine = null; } }
        
        if(coinCoroutine != null) { StopCoroutine(coinCoroutine); coinCoroutine = null; }

        if(goldRushCoroutine != null) 
        {
            StopCoroutine(goldRushCoroutine); goldRushCoroutine = null; goldRushIcon.SetActive(false);
            goldRushCircleAnim.gameObject.SetActive(false);
            goldRushTextAnim.gameObject.SetActive(false);
        }
        if (prestigeRushCoroutine != null) 
        {
            StopCoroutine(prestigeRushCoroutine); prestigeRushCoroutine = null; prestigeRushIcon.SetActive(false);
            prestigeRushCircleAnim.gameObject.SetActive(false);
            prestigeRushTextAnim.gameObject.SetActive(false);
        }
        if(rainbowCoroutine != null) 
        {
            StopCoroutine(rainbowCoroutine); rainbowCoroutine = null;
            rainbowGoldPegIcon.SetActive(false);
            rainbowGoldBucketIcon.SetActive(false);
            rainbowPrestigeIcon.SetActive(false);
            rainbowPrestigeBucketIcon.SetActive(false);
        }

        isGoldRush = false;
        isPRestigeRush = false;
        isRainbowGoldBucket = false;
        isRainbowGoldPeg = false;
        isRainbowPRestige = false;
        isRainbowPRestigeBucket = false;
    }
    #endregion 

    #region Set random board
    public GameObject ballHitParent;

    public void SetRandomBoard(bool firstTime)
    {
        if (Prestige.G_Upgrade20Purchased == true)
        {
            StartCoroutine(SetTimer());
        }

        if (BallUpgrades.peggoBallPurchased == true) {
            if (firstTime == false) { coinCoroutine = StartCoroutine(SetPeggoCoinsAndGems(true)); }
            if (firstTime == true) { coinCoroutine = StartCoroutine(SetPeggoCoinsAndGems(false)); }
        }
        if(firstTime == false) { StartCoroutine(BoardClearedAnimation()); }

        if(Prestige.levelSelected == 1)
        { 
            if(firstTime == false) { level1Coroutine = StartCoroutine(NewBoardLevel1(true)); }
            if (firstTime == true) { level1Coroutine = StartCoroutine(NewBoardLevel1(false)); }
        }
        else if (Prestige.levelSelected == 2)
        {
            if (firstTime == false) { level2Coroutine = StartCoroutine(NewBoardLevel2(true)); }
            if (firstTime == true) { level2Coroutine = StartCoroutine(NewBoardLevel2(false)); }
        }

        if(GameData.isDemo == false)
        {
            if (Prestige.levelSelected == 3)
            {
                if (firstTime == false) { level3Coroutine = StartCoroutine(NewBoardLevel3(true)); }
                if (firstTime == true) { level3Coroutine = StartCoroutine(NewBoardLevel3(false)); }
            }
            else if (Prestige.levelSelected == 4)
            {
                if (firstTime == false) { level4Coroutine = StartCoroutine(NewBoardLevel4(true)); }
                if (firstTime == true) { level4Coroutine = StartCoroutine(NewBoardLevel4(false)); }
            }

            else if (Prestige.levelSelected == 5)
            {
                if (firstTime == false) { level5Coroutine = StartCoroutine(NewBoardLevel5(true)); }
                if (firstTime == true) { level5Coroutine = StartCoroutine(NewBoardLevel5(false)); }
            }
            else if (Prestige.levelSelected == 6)
            {
                if (firstTime == false) { level6Coroutine = StartCoroutine(NewBoardLevel6(true)); }
                if (firstTime == true) { level6Coroutine = StartCoroutine(NewBoardLevel6(false)); }
            }
            else if (Prestige.levelSelected == 7)
            {
                if (firstTime == false) { level7Coroutine = StartCoroutine(NewBoardLevel7(true)); }
                if (firstTime == true) { level7Coroutine = StartCoroutine(NewBoardLevel7(false)); }
            }
            else if (Prestige.levelSelected == 8)
            {
                if (firstTime == false) { level8Coroutine = StartCoroutine(NewBoardLevel8(true)); }
                if (firstTime == true) { level8Coroutine = StartCoroutine(NewBoardLevel8(false)); }
            }
            else if (Prestige.levelSelected == 9)
            {
                if (firstTime == false) { level9Coroutine = StartCoroutine(NewBoardLevel9(true)); }
                if (firstTime == true) { level9Coroutine = StartCoroutine(NewBoardLevel9(false)); }
            }
            else if (Prestige.levelSelected == 10)
            {
                if (firstTime == false) { level10Coroutine = StartCoroutine(NewBoardLevel10(true)); }
                if (firstTime == true) { level10Coroutine = StartCoroutine(NewBoardLevel10(false)); }
            }
        }
        else
        {
            if(Prestige.levelSelected > 2)
            {
                if (Prestige.purchasedLevel2 == true)
                {
                    Prestige.levelSelected = 2;
                    if (firstTime == false) { level1Coroutine = StartCoroutine(NewBoardLevel1(true)); }
                    if (firstTime == true) { level1Coroutine = StartCoroutine(NewBoardLevel1(false)); }
                }
                else
                {
                    Prestige.levelSelected = 1;
                    if (firstTime == false) { level2Coroutine = StartCoroutine(NewBoardLevel2(true)); }
                    if (firstTime == true) { level2Coroutine = StartCoroutine(NewBoardLevel2(false)); }
                }
            }
        }
    }
    #endregion

    IEnumerator SetTimer()
    {
        yield return new WaitForSeconds(1);
        if (Prestige.G_Upgrade20Purchased == true)
        {
            timerCoroutine = StartCoroutine(NewLevelTimer());
        }
    }

    #region Set Coind and gems
    IEnumerator SetPeggoCoinsAndGems(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }

        coinAndGemParent.SetActive(false);

        //yield return new WaitForSeconds(0.1f);

        coinAndGemParent.SetActive(true);

        int randomPrestigeGems = Random.Range(1,4);

        for (int i = 0; i < randomPrestigeGems; i++)
        {
            GameObject gems = ObjectPool2.instance.GetPrestigeGemFromPool();
        }
        if(Challenges.challCompleted[31] == true) 
        {
            for (int i = 0; i < randomPrestigeGems; i++)
            {
                GameObject gems = ObjectPool2.instance.GetPrestigeGemFromPool();
            }
        }
    }
    #endregion

    #region Level 1
    public GameObject[] level1BoardsPrefabs;
    public GameObject[] levelBoards;
     
    IEnumerator NewBoardLevel1(bool noWait)
    {
        if(noWait == true) { yield return new WaitForSeconds(1.1f); }

        SetPegHitParent();

        if (levelBoards[levelNumber].activeInHierarchy == true) { levelBoards[levelNumber].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 15);
        } while (levelNumber == randomLevel);

        levelBoards[randomLevel].SetActive(true); levelNumber = randomLevel;
    }
    #endregion

    #region Level 2
    public GameObject[] level2BoardsPrefabs;
    public GameObject[] level2Boards;

    IEnumerator NewBoardLevel2(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level2Boards[level2Number].activeInHierarchy == true) { level2Boards[level2Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 15);
        } while (level2Number == randomLevel);

        level2Boards[randomLevel].SetActive(true); level2Number = randomLevel;
    }
    #endregion

    #region Level 3
    public GameObject[] level3BoardsPrefabs;
    public GameObject[] level3Boards;

    IEnumerator NewBoardLevel3(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level3Boards[level3Number].activeInHierarchy == true) { level3Boards[level3Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 16);
        } while (level3Number == randomLevel);

        level3Boards[randomLevel].SetActive(true); level3Number = randomLevel;
    }
    #endregion

    #region Level 4
    public GameObject[] level4BoardsPrefabs;
    public GameObject[] level4Boards;

    IEnumerator NewBoardLevel4(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level4Boards[level4Number].activeInHierarchy == true) { level4Boards[level4Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 16);
        } while (level4Number == randomLevel);

        level4Boards[randomLevel].SetActive(true); level4Number = randomLevel;
    }
    #endregion

    #region Level 5
    public GameObject[] level5BoardsPrefabs;
    public GameObject[] level5Boards;

    IEnumerator NewBoardLevel5(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level5Boards[level5Number].activeInHierarchy == true) { level5Boards[level5Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 17);
        } while (level5Number == randomLevel);

        level5Boards[randomLevel].SetActive(true); level5Number = randomLevel;
    }
    #endregion

    #region Level 6
    public GameObject[] level6BoardsPrefabs;
    public GameObject[] level6Boards;

    IEnumerator NewBoardLevel6(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level6Boards[level6Number].activeInHierarchy == true) { level6Boards[level6Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 17);
        } while (level6Number == randomLevel);

        level6Boards[randomLevel].SetActive(true); level6Number = randomLevel;
    }
    #endregion

    #region Level 7
    public GameObject[] level7BoardsPrefabs;
    public GameObject[] level7Boards;

    IEnumerator NewBoardLevel7(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level7Boards[level7Number].activeInHierarchy == true) { level7Boards[level7Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 18);
        } while (level7Number == randomLevel);

        level7Boards[randomLevel].SetActive(true); level7Number = randomLevel;
    }
    #endregion

    #region Level 8
    public GameObject[] level8BoardsPrefabs;
    public GameObject[] level8Boards;

    IEnumerator NewBoardLevel8(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level8Boards[level8Number].activeInHierarchy == true) { level8Boards[level8Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 18);
        } while (level8Number == randomLevel);

        level8Boards[randomLevel].SetActive(true); level8Number = randomLevel;
    }
    #endregion

    #region Level 9
    public GameObject[] level9BoardsPrefabs;
    public GameObject[] level9Boards;

    IEnumerator NewBoardLevel9(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level9Boards[level9Number].activeInHierarchy == true) { level9Boards[level9Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 19);
        } while (level9Number == randomLevel);

        level9Boards[randomLevel].SetActive(true); level9Number = randomLevel;
    }
    #endregion

    #region Level 10
    public GameObject[] level10BoardsPrefabs;
    public GameObject[] level10Boards;

    IEnumerator NewBoardLevel10(bool noWait)
    {
        if (noWait == true) { yield return new WaitForSeconds(1.1f); }
        SetPegHitParent();
        if (level10Boards[level10Number].activeInHierarchy == true) { level10Boards[level10Number].SetActive(false); }

        int randomLevel;

        do
        {
            randomLevel = Random.Range(0, 20);
        } while (level10Number == randomLevel);

        level10Boards[randomLevel].SetActive(true); level10Number = randomLevel;
    }
    #endregion

    public void SetPegHitParent()
    {
        ballHitParent.SetActive(false);
        ballHitParent.SetActive(true);
    }

    #region Get highest value ball gold
    public static double currentHighestValueBall;
    public void HighestValueBallGold()
    {
        currentHighestValueBall = 0;
        if(BallUpgrades.regularBallGold > currentHighestValueBall) { currentHighestValueBall = BallUpgrades.regularBallGold; }
        if (BallUpgrades.redBallGold > currentHighestValueBall && BallUpgrades.bouncyBallPurchased == true) { currentHighestValueBall = BallUpgrades.redBallGold; }
        if (BallUpgrades.rockBallGold > currentHighestValueBall && BallUpgrades.rockBallPurchased == true) { currentHighestValueBall = BallUpgrades.rockBallGold; }
        if (BallUpgrades.bombBallGold > currentHighestValueBall && BallUpgrades.bombBallPurchased == true) { currentHighestValueBall = BallUpgrades.bombBallGold; }
        if (BallUpgrades.aquaBallGold > currentHighestValueBall && BallUpgrades.aquaBallPurchased == true) { currentHighestValueBall = BallUpgrades.aquaBallGold; }
        if (BallUpgrades.mudBallGold > currentHighestValueBall && BallUpgrades.mudBallPurchased == true) { currentHighestValueBall = BallUpgrades.mudBallGold; }
        if (BallUpgrades.basketBallGold > currentHighestValueBall && BallUpgrades.basketBallPurchased == true) { currentHighestValueBall = BallUpgrades.basketBallGold; }
        if (BallUpgrades.plumBallGold > currentHighestValueBall && BallUpgrades.plumBallPurchased == true) { currentHighestValueBall = BallUpgrades.plumBallGold; }
        if (BallUpgrades.stickyBallGold > currentHighestValueBall && BallUpgrades.stickyBallPurchased == true) { currentHighestValueBall = BallUpgrades.stickyBallGold; }
        if (BallUpgrades.candyBallGold > currentHighestValueBall && BallUpgrades.candyBallPurchased == true) { currentHighestValueBall = BallUpgrades.candyBallGold; }
        if (BallUpgrades.cookieBallGold > currentHighestValueBall && BallUpgrades.cookieBallPurchased == true) { currentHighestValueBall = BallUpgrades.cookieBallGold; }
        if (BallUpgrades.limeBallGold > currentHighestValueBall && BallUpgrades.limeBallPurchased == true) { currentHighestValueBall = BallUpgrades.limeBallGold; }
        if (BallUpgrades.goldenBallGold > currentHighestValueBall && BallUpgrades.goldenBallPurchased == true) { currentHighestValueBall = BallUpgrades.goldenBallGold; }
        if (BallUpgrades.footballBallGold > currentHighestValueBall && BallUpgrades.footballBallPurchased == true) { currentHighestValueBall = BallUpgrades.footballBallGold; }
        if (BallUpgrades.sharpnelBallGold > currentHighestValueBall && BallUpgrades.sharpnelBallPurchased == true) { currentHighestValueBall = BallUpgrades.sharpnelBallGold; }
        if (BallUpgrades.zonicBallGold > currentHighestValueBall && BallUpgrades.zonicBallPurchased == true) { currentHighestValueBall = BallUpgrades.zonicBallGold; }
        if (BallUpgrades.apricotBallGold > currentHighestValueBall && BallUpgrades.apricotBallPurchased == true) { currentHighestValueBall = BallUpgrades.apricotBallGold; }
        if (BallUpgrades.peggoBallGold > currentHighestValueBall && BallUpgrades.peggoBallPurchased == true) { currentHighestValueBall = BallUpgrades.peggoBallGold; }
        if (BallUpgrades.ghostBallGold > currentHighestValueBall && BallUpgrades.ghostBallPurchased == true) { currentHighestValueBall = BallUpgrades.ghostBallGold; }
        if (BallUpgrades.starBallGold > currentHighestValueBall && BallUpgrades.starBallPurchased == true) { currentHighestValueBall = BallUpgrades.starBallGold; }
        if (BallUpgrades.rainbowBallGold > currentHighestValueBall && BallUpgrades.rainbowBallPurchased == true) { currentHighestValueBall = BallUpgrades.rainbowBallGold; }
        if (BallUpgrades.glitchyBallGold > currentHighestValueBall && BallUpgrades.glitchyBallPurchased == true) { currentHighestValueBall = BallUpgrades.glitchyBallGold; }

        currentHighestValueBall *= (1 + Prestige.prestigeGoldIncrease);
    }
    #endregion

    public void GiveClearChall(int chall)
    {
        if (challScript != null)
        {
            if (chall == 1) { board1Clears += 1; PlayerPrefs.SetInt("clear" + chall, 1); challScript.CheckCompleted(1, board1Clears); }
            else if (chall == 2) { board2Clears += 1; PlayerPrefs.SetInt("clear2" + chall, 1); challScript.CheckCompleted(2, board2Clears); }
            else if (chall == 3) { board3Clears += 1; PlayerPrefs.SetInt("clear3" + chall, 1); challScript.CheckCompleted(3, board3Clears); }
            else if (chall == 4) { board4Clears += 1; PlayerPrefs.SetInt("clear4" + chall, 1); challScript.CheckCompleted(4, board4Clears); }
            else if (chall == 5) { board5Clears += 1; PlayerPrefs.SetInt("clear5" + chall, 1); challScript.CheckCompleted(5, board5Clears); }
            else if (chall == 6) { board6Clears += 1; PlayerPrefs.SetInt("clear6" + chall, 1); challScript.CheckCompleted(6, board6Clears); }
            else if (chall == 7) { board7Clears += 1; PlayerPrefs.SetInt("clear7" + chall, 1); challScript.CheckCompleted(7, board7Clears); }
            else if (chall == 8) { board8Clears += 1; PlayerPrefs.SetInt("clear8" + chall, 1); challScript.CheckCompleted(8, board8Clears); }
            else if (chall == 9) { board9Clears += 1; PlayerPrefs.SetInt("clear9" + chall, 1); challScript.CheckCompleted(9, board9Clears); }
            else if (chall == 10) { board10Clears += 1; PlayerPrefs.SetInt("clear10" + chall, 1); challScript.CheckCompleted(10, board10Clears); }
        }
    }

    #region Board clearing animation
    public Animation boardClearedAnim, boardClearedCircle, goldClearBonusAnim, prestigePointClearBonusAnim;
    public Image middleFill;

    public Coroutine fullFillCoroutine;
    public static int middleFillIncrement;
    public TextMeshProUGUI middlePercentText, boardClearGoldText, prestigePointClearBonusText;
    public Animation middlePercentAnim;

    public TextMeshProUGUI chargeAmountText, ballsAmountText;
    public static float fullChargeAmount;
    public AudioManager audioManager;

    public GameObject coinAndGemParent;
    public double totalClearBonus;
    public double boardClearBonus;
    public double timerGoldBunus;
    public double bucketClearBonus;
    public int secondsUnderTimer;

    public static int board1Clears, board2Clears, board3Clears, board4Clears, board5Clears, board6Clears, board7Clears, board8Clears, board9Clears, board10Clears;

    public Challenges challScript;
    public int[] lvl1Clear = new int[15];
    public int[] lvl2Clear = new int[15];
    public int[] lvl3Clear = new int[16];
    public int[] lvl4Clear = new int[16];
    public int[] lvl5Clear = new int[17];
    public int[] lvl6Clear = new int[17];
    public int[] lvl7Clear = new int[18];
    public int[] lvl8Clear = new int[18];
    public int[] lvl9Clear = new int[19];
    public int[] lvl10Clear = new int[20];

    public Achievements achScript;

    public int level1Clears, level2Clears, level3Clears, level4Clears, level5Clears, level6Clears, level7Clears, level8Clears, level9Clears, level10Clears;

    IEnumerator BoardClearedAnimation()
    {
        #region Check board clear challenges progress
        if(challScript != null)
        {
            if (Prestige.levelSelected == 1) 
            { 
                if (Challenges.challCompleted[0] == false && Challenges.challFinished[0] == false) 
                { 
                    if (lvl1Clear[levelNumber] != 1) 
                    { 
                        lvl1Clear[levelNumber] = 1; board1Clears += 1; challScript.CheckCompleted(1, board1Clears); PlayerPrefs.SetInt("clear" + levelNumber, lvl1Clear[levelNumber]); 
                    } 
                }
            }

            else if (Prestige.levelSelected == 2) 
            {
                if (Challenges.challCompleted[1] == false && Challenges.challFinished[1] == false) 
                { 
                    if (lvl2Clear[level2Number] != 1)
                    { 
                        lvl2Clear[level2Number] = 1; board2Clears += 1; challScript.CheckCompleted(2, board2Clears); PlayerPrefs.SetInt("clear2" + level2Number, lvl2Clear[level2Number]);
                    } 
                }
            }

            else if (Prestige.levelSelected == 3) { if (Challenges.challCompleted[2] == false && Challenges.challFinished[2] == false) { if (lvl3Clear[level3Number] != 1) { lvl3Clear[level3Number] = 1; board3Clears += 1; challScript.CheckCompleted(3, board3Clears); PlayerPrefs.SetInt("clear3" + level3Number, lvl3Clear[level3Number]); } } }

            else if (Prestige.levelSelected == 4) { if (Challenges.challCompleted[3] == false && Challenges.challFinished[3] == false) { if (lvl4Clear[level4Number] != 1) { lvl4Clear[level4Number] = 1; board4Clears += 1; challScript.CheckCompleted(4, board4Clears); PlayerPrefs.SetInt("clear4" + level4Number, lvl4Clear[level4Number]); } } }

            else if (Prestige.levelSelected == 5) { if (Challenges.challCompleted[4] == false && Challenges.challFinished[4] == false) { if (lvl5Clear[level5Number] != 1) { lvl5Clear[level5Number] = 1; board5Clears += 1; challScript.CheckCompleted(5, board5Clears); PlayerPrefs.SetInt("clear5" + level5Number, lvl5Clear[level5Number]); } } }

            else if (Prestige.levelSelected == 6) { if (Challenges.challCompleted[5] == false && Challenges.challFinished[5] == false) { if (lvl6Clear[level6Number] != 1) { lvl6Clear[level6Number] = 1; board6Clears += 1; challScript.CheckCompleted(6, board6Clears); PlayerPrefs.SetInt("clear6" + level6Number, lvl6Clear[level6Number]); } } }

            else if (Prestige.levelSelected == 7) { if (Challenges.challCompleted[6] == false && Challenges.challFinished[6] == false) { if (lvl7Clear[level7Number] != 1) { lvl7Clear[level7Number] = 1; board7Clears += 1; challScript.CheckCompleted(7, board7Clears); PlayerPrefs.SetInt("clear7" + level7Number, lvl7Clear[level7Number]); } } }

            else if (Prestige.levelSelected == 8) { if (Challenges.challCompleted[7] == false && Challenges.challFinished[7] == false) { if (lvl8Clear[level8Number] != 1) { lvl8Clear[level8Number] = 1; board8Clears += 1; challScript.CheckCompleted(8, board8Clears); PlayerPrefs.SetInt("clear8" + level8Number, lvl8Clear[level8Number]); } } }

            else if (Prestige.levelSelected == 9) { if (Challenges.challCompleted[8] == false && Challenges.challFinished[8] == false) { if (lvl9Clear[level9Number] != 1) { lvl9Clear[level9Number] = 1; board9Clears += 1; challScript.CheckCompleted(9, board9Clears); PlayerPrefs.SetInt("clear9" + level9Number, lvl9Clear[level9Number]); } } }

            else if (Prestige.levelSelected == 10) { if (Challenges.challCompleted[9] == false && Challenges.challFinished[9] == false) { if (lvl10Clear[level10Number] != 1) { lvl10Clear[level10Number] = 1; board10Clears += 1; challScript.CheckCompleted(10, board10Clears); PlayerPrefs.SetInt("clear10" + level10Number, lvl10Clear[level10Number]); } } }
        }
        #endregion

        #region Check is board clear 50+
        if(Prestige.levelSelected == 1)
        {
            level1Clears += 1;
            if (level1Clears > 75) 
            {
                if (board1Clears != 15) { board1Clears += 1; challScript.CheckCompleted(1, board1Clears);  }
            }
        }
        if (Prestige.levelSelected == 2)
        {
            level2Clears += 1;
            if (level2Clears > 75)
            {
                if (board2Clears != 15) { board2Clears += 1; challScript.CheckCompleted(2, board2Clears);  }
            }
        }
        if (Prestige.levelSelected == 3)
        {
            level3Clears += 1;
            if (level3Clears > 75)
            {
                if (board3Clears != 16) { board3Clears += 1; challScript.CheckCompleted(3, board3Clears);  }
            }
        }
        if (Prestige.levelSelected == 4)
        {
            level4Clears += 1;
            if (level4Clears > 75)
            {
                if (board4Clears != 16) { board4Clears += 1; challScript.CheckCompleted(4, board4Clears); }
            }
        }
        if (Prestige.levelSelected == 5)
        {
            level5Clears += 1;
            if (level5Clears > 75)
            {
                if (board5Clears != 17) { board5Clears += 1; challScript.CheckCompleted(5, board5Clears);  }
            }
        }
        if (Prestige.levelSelected == 6)
        {
            level6Clears += 1;
            if (level6Clears > 75)
            {
                if (board6Clears != 17) { board6Clears += 1; challScript.CheckCompleted(6, board6Clears); }
            }
        }
        if (Prestige.levelSelected == 7)
        {
            level7Clears += 1;
            if (level7Clears > 75)
            {
                if (board7Clears != 18) { board7Clears += 1; challScript.CheckCompleted(7, board7Clears);  }
            }
        }
        if (Prestige.levelSelected == 8)
        {
            level8Clears += 1;
            if (level8Clears > 75)
            {
                if (board8Clears != 18) { board8Clears += 1; challScript.CheckCompleted(8, board8Clears);  }
            }
        }
        if (Prestige.levelSelected == 9)
        {
            level9Clears += 1;
            if (level9Clears > 75)
            {
                if (board9Clears != 19) { board9Clears += 1; challScript.CheckCompleted(9, board9Clears); }
            }
        }
        if (Prestige.levelSelected == 10)
        {
            level10Clears += 1;
            if (level10Clears > 75)
            {
                if (board10Clears != 20) { board10Clears += 1; challScript.CheckCompleted(10, board10Clears);}
            }
        }


        #endregion

        if (challScript != null)
        {
            if (SettingsOptions.isInChallengeTab == true)
            {
                int clears = 0;
                if (Prestige.levelSelected == 1) { clears = board1Clears; }
                else if (Prestige.levelSelected == 2) { clears = board2Clears; }
                else if (Prestige.levelSelected == 3) { clears = board3Clears; }
                else if (Prestige.levelSelected == 4) { clears = board4Clears; }
                else if (Prestige.levelSelected == 5) { clears = board5Clears; }
                else if (Prestige.levelSelected == 6) { clears = board6Clears; }
                else if (Prestige.levelSelected == 7) { clears = board7Clears; }
                else if (Prestige.levelSelected == 8) { clears = board8Clears; }
                else if (Prestige.levelSelected == 9) { clears = board9Clears; }
                else if (Prestige.levelSelected == 10) { clears = board10Clears; }

                challScript.ChallengeProgress(Prestige.levelSelected, clears);
            }
        }
      
        audioManager.Play("BoardCleared");

        middlePercentText.gameObject.SetActive(true);
        middlePercentText.text = "+" + ((1f / middleFillIncrement) * 100).ToString("F0") + "%";
        middlePercentAnim.Play();

        middleFill.fillAmount += (1f / middleFillIncrement);
        if(middleFill.fillAmount >= 0.99f)
        {
            AllStats.timesFullyCharge += 1;
            if(achScript != null) { achScript.CheckFullChargeACH(); }
            fullFillCoroutine = StartCoroutine(FullFillShooting()); 
        }

        fullChargeAmount = middleFill.fillAmount;

        float floatAmount = (fullChargeAmount * 100);
        locScript.SetChargePercentAndBallShot(floatAmount, fullFillShots);
        chargeAmountText.text = LocalizationStrings.chargedUpAmountString;

        boardClearedCircle.gameObject.SetActive(true);
        boardClearedAnim.gameObject.SetActive(true);
        boardClearedAnim.Play();
        boardClearedCircle.Play();

        if (Prestige.G_Upgrade12Purchased == true)
        {
            HighestValueBallGold();
         
            if(Prestige.G_Upgrade20Purchased == true)
            {
                if(time > 20) { time = 20; }
                secondsUnderTimer = (Prestige.goldClearTimerSeconds - time);
                timerGoldBunus = (currentHighestValueBall * Prestige.totalTimerGoldClearBonus) * secondsUnderTimer;
                if (timerCoroutine != null) { StopCoroutine(timerCoroutine); timerCoroutine = null; }
            }
            if (Prestige.G_Upgrade19Purchased == true)
            {
                bucketClearBonus = BucketCollision.bucketGoldClearCount * (currentHighestValueBall * Prestige.goldClearBonusFromBucket);
            }

            boardClearBonus = (currentHighestValueBall * Prestige.totalGoldClearBonus) * BasicPeg.boardClearGoldHit;

            if (isGoldRush == false) 
            {
                totalClearBonus = (timerGoldBunus + boardClearBonus) + bucketClearBonus;
            }
            else 
            {
                totalClearBonus = ((timerGoldBunus + boardClearBonus) + bucketClearBonus) * Prestige.goldRushIncrease; 
            }

            boardClearGoldText.text = "+" + SetHighNumbers.FormatCoinsGoldShort(totalClearBonus);
            BallUpgrades.points += totalClearBonus;
            AllStats.totalGold += totalClearBonus;
            AllStats.goldFromClear += totalClearBonus;

            time = 0;

            goldClearBonusAnim.gameObject.SetActive(true);
            goldClearBonusAnim.Play();
        }

        BucketCollision.bucketGoldClearCount = 0;
        BasicPeg.boardClearGoldHit = 0;

        if (Prestige.PU_Upgrade12Purchased == true)
        {
            int prestigePointBonus = 0;

            if (Prestige.PU_Upgrade16Purchased == true) { prestigePointBonus = (BasicPeg.boardClearPrestigeHit / Prestige.prestigeClearHitsNeeded) * 2; }
            else { prestigePointBonus = BasicPeg.boardClearPrestigeHit / Prestige.prestigeClearHitsNeeded; }

            if (isPRestigeRush == true) 
            {
                prestigePointBonus *= Prestige.prestigeRushIncrease;
            }

            if(prestigePointBonus < 1) { prestigePointBonus = 0; }
            else
            {
                Prestige.prestigePoints += prestigePointBonus;
                AllStats.totalPRestigePoints += prestigePointBonus;
            }
            prestigePointClearBonusText.text = "+" + prestigePointBonus;
            prestigePointClearBonusAnim.gameObject.SetActive(true);
            prestigePointClearBonusAnim.Play();

            AllStats.prestigePointFromClear += prestigePointBonus;
        }

        BasicPeg.boardClearPrestigeHit = 0;

        yield return new WaitForSeconds(1f);

        if (Prestige.G_Upgrade12Purchased == true)
        {
            goldClearBonusAnim.gameObject.SetActive(false);
        }

        if (Prestige.PU_Upgrade12Purchased == true)
        {
            prestigePointClearBonusAnim.gameObject.SetActive(false);
        }

        boardClearedAnim.gameObject.SetActive(false);
        boardClearedCircle.gameObject.SetActive(false);
        BasicPeg.totalPrestigePegs = 0;
        BasicPeg.totalGoldenPegs = 0;
        middlePercentText.gameObject.SetActive(false);

        if(Tutorial.clickedOkFirstClear == false)
        {
            if (Tutorial.firstTimeClearBoard == false)
            {
                Tutorial.firstTimeClearBoard = true;
            }
        }

        if (achScript != null)
        {
            achScript.CheckGoldGainACH();
            achScript.CheckTotalPrestigeACH();
            achScript.CheckBoardClears();
        }
    }
    #endregion

    public Coroutine goldRushCoroutine, prestigeRushCoroutine;

    #region GoldRush
    public static bool isGoldRush;
    public Animation goldRushCircleAnim, goldRushTextAnim;
    public GameObject goldRushIcon;
    public TextMeshProUGUI goldRushTimerText;
    public static int goldTimer;

    public void StartGoldRush()
    {
        isGoldRush = true;
        goldRushCoroutine = StartCoroutine(GoldRush());
    }

    IEnumerator GoldRush()
    {
        audioManager.Play("GoldRush");
        AllStats.timesGoldRush += 1;
        if (achScript != null) { achScript.CheckBuffsACH(); }

        goldRushCircleAnim.gameObject.SetActive(true);
        goldRushTextAnim.gameObject.SetActive(true);
        goldRushCircleAnim.Play();
        goldRushTextAnim.Play();

        goldRushIcon.SetActive(true);

        yield return new WaitForSeconds(1);
        goldRushCircleAnim.gameObject.SetActive(false);
        goldRushTextAnim.gameObject.SetActive(false);

        int timer = 0;
        while (timer < Prestige.goldRushTimer)
        {
            goldTimer = Prestige.goldRushTimer - timer;

            if (BuffsToolTip.buffCurrentlyHovering == 5) { rainbowTimerText.text = goldTimer.ToString("F0"); }

            // goldRushTimerText.text = (Prestige.goldRushTimer - time).ToString("F0");
            yield return new WaitForSeconds(1);
            timer += 1;
        }

        if (MobileScript.isMobile == false)
        {
            if (BuffsToolTip.buffCurrentlyHovering == 5) { buffFrame.SetActive(false); }
        }
        rainbowTimerText.text = 0.ToString("F0");
        goldRushIcon.SetActive(false);
        isGoldRush = false;
    }
    #endregion

    #region Prestige rush
    public static bool isPRestigeRush;
    public Animation prestigeRushCircleAnim, prestigeRushTextAnim;
    public GameObject prestigeRushIcon;
    public TextMeshProUGUI prestigeRushTimerText;
    public static int prestigeTimer;

    public void StartPrestigeRush()
    {
        isPRestigeRush = true;
        prestigeRushCoroutine = StartCoroutine(PrestigeRush());
    }

    IEnumerator PrestigeRush()
    {
        audioManager.Play("PrestigeRush");
        AllStats.timesPrestigeRush += 1;
        if (achScript != null) { achScript.CheckBuffsACH(); }

        prestigeRushCircleAnim.gameObject.SetActive(true);
        prestigeRushTextAnim.gameObject.SetActive(true);
        prestigeRushCircleAnim.Play();
        prestigeRushTextAnim.Play();

        prestigeRushIcon.SetActive(true);

        yield return new WaitForSeconds(1);
        prestigeRushCircleAnim.gameObject.SetActive(false);
        prestigeRushTextAnim.gameObject.SetActive(false);

        prestigeTimer = 2;

        int timer = 0;
        while (timer < Prestige.prestigeRushTimer)
        {
            prestigeTimer = Prestige.prestigeRushTimer - timer;

            if (BuffsToolTip.buffCurrentlyHovering == 6) { rainbowTimerText.text = prestigeTimer.ToString("F0"); }
            yield return new WaitForSeconds(1);
            timer += 1;
        }

        rainbowTimerText.text = 0.ToString("F0");

        if (MobileScript.isMobile == false)
        {
            if (BuffsToolTip.buffCurrentlyHovering == 6) { buffFrame.SetActive(false); }
        }

        prestigeRushIcon.SetActive(false);
        isPRestigeRush = false;
    }
    #endregion

    #region Rainbow buffs
    public static bool isRainbowGoldPeg, isRainbowPRestige, isRainbowPRestigeBucket, isRainbowGoldBucket;
    public GameObject rainbowGoldPegIcon, rainbowGoldBucketIcon, rainbowPrestigeIcon, rainbowPrestigeBucketIcon;
    public TextMeshProUGUI rainbowTimerText;
    public Coroutine rainbowCoroutine;
    public TextMeshProUGUI rGold1X, rGold2X, rPrestige1X, rPrestige2x;

    public void StartRainbowBuff(int buff)
    {
        if (buff == 1 && isRainbowGoldPeg == true) { rainbowTimer1 = 5; }
        if (buff == 2 && isRainbowGoldBucket == true) { rainbowTimer2 = 5; }
        if (buff == 3 && isRainbowPRestige == true) { rainbowTimer3 = 5; }
        if (buff == 4 && isRainbowPRestigeBucket == true) { rainbowTimer4 = 5; }

        if (buff == 1 && isRainbowGoldPeg == false) { rainbowCoroutine = StartCoroutine(RainbowBuffs(buff)); }
        if (buff == 2 && isRainbowGoldBucket == false) { rainbowCoroutine = StartCoroutine(RainbowBuffs(buff)); }
        if (buff == 3 && isRainbowPRestige == false) { rainbowCoroutine = StartCoroutine(RainbowBuffs(buff)); }
        if (buff == 4 && isRainbowPRestigeBucket == false) { rainbowCoroutine = StartCoroutine(RainbowBuffs(buff)); }
    }
    public GameObject buffFrame;

    public static int rainbowTimer1, rainbowTimer2, rainbowTimer3, rainbowTimer4;
    IEnumerator RainbowBuffs(int buff)
    {
        int timer = 0;

        if (buff == 1) { rainbowGoldPegIcon.SetActive(true); isRainbowGoldPeg = true; rGold1X.text = "X" + Prestige.rainbowPegIncrease; }
        if (buff == 2) { rainbowGoldBucketIcon.SetActive(true); isRainbowGoldBucket = true; rGold2X.text = "X" + Prestige.rainbowPegIncrease; }
        if (buff == 3) { rainbowPrestigeIcon.SetActive(true); isRainbowPRestige = true; rPrestige1X.text = "X" + Prestige.rainbowPegIncrease; }
        if (buff == 4) { rainbowPrestigeBucketIcon.SetActive(true); isRainbowPRestigeBucket = true; rPrestige2x.text = Prestige.rainbowPegPrestigePointChance + "%"; }

        if (achScript != null) { achScript.CheckBuffsACH(); }

        while (timer < Prestige.rainbowPegTimer)
        {
            if (buff == 1) { rainbowTimer1 = Prestige.rainbowPegTimer - timer; }
            if (buff == 2) { rainbowTimer2 = Prestige.rainbowPegTimer -  timer; }
            if (buff == 3) { rainbowTimer3 = Prestige.rainbowPegTimer -  timer; }
            if (buff == 4) { rainbowTimer4 = Prestige.rainbowPegTimer -  timer; }

            if (BuffsToolTip.buffCurrentlyHovering == 1) { rainbowTimerText.text = rainbowTimer1.ToString("F0"); }
            if (BuffsToolTip.buffCurrentlyHovering == 2) { rainbowTimerText.text = rainbowTimer2.ToString("F0"); }
            if (BuffsToolTip.buffCurrentlyHovering == 3) { rainbowTimerText.text = rainbowTimer3.ToString("F0"); }
            if (BuffsToolTip.buffCurrentlyHovering == 4) { rainbowTimerText.text = rainbowTimer4.ToString("F0"); }

            yield return new WaitForSeconds(1);

            if(rainbowTimer1 == 5) { timer = 0; }
            if (rainbowTimer2 == 5) { timer = 0; }
            if (rainbowTimer3 == 5) { timer = 0; }
            if (rainbowTimer4 == 5) { timer = 0; }

            timer += 1;
        }

        if(MobileScript.isMobile == false)
        {
            if (BuffsToolTip.buffCurrentlyHovering == 1 && buff == 1) { buffFrame.SetActive(false); }
            if (BuffsToolTip.buffCurrentlyHovering == 2 && buff == 2) { buffFrame.SetActive(false); }
            if (BuffsToolTip.buffCurrentlyHovering == 3 && buff == 3) { buffFrame.SetActive(false); }
            if (BuffsToolTip.buffCurrentlyHovering == 4 && buff == 4) { buffFrame.SetActive(false); }
        }

        if (buff == 1) { rainbowTimerText.text = 0.ToString("F0"); rainbowGoldPegIcon.SetActive(false); isRainbowGoldPeg = false; }
        if (buff == 2) { rainbowTimerText.text = 0.ToString("F0"); rainbowGoldBucketIcon.SetActive(false); isRainbowGoldBucket = false; }
        if (buff == 3) { rainbowTimerText.text = 0.ToString("F0"); rainbowPrestigeIcon.SetActive(false); isRainbowPRestige = false; }
        if (buff == 4) { rainbowTimerText.text = 0.ToString("F0"); rainbowPrestigeBucketIcon.SetActive(false); isRainbowPRestigeBucket = false; }
    }
    #endregion

    #region full fill shooting
    public float fillShootingWait;
    public static bool isFullFillShooting;
    public MainShooter mainShooter;
    public int increment;
    public LocalizationStrings locScript;

    IEnumerator FullFillShooting()
    {
        yield return new WaitForSeconds(0.6f);

        middleFillIncrement += 1;

        isFullFillShooting = true;
        middleFill.fillAmount = 0;
        fullChargeAmount = 0;
        float waitTime;
        waitTime = 1.7f;

        fillShootingWait = 0f;
        while (fillShootingWait < waitTime)
        {
            mainShooter.ShootFullFill();
            fillShootingWait += waitTime / fullFillShots;
        
            increment++;

            yield return new WaitForSeconds(waitTime / fullFillShots);
        }

        isFullFillShooting = false;
        float floatAmount = (fullChargeAmount * 100);
        locScript.SetChargePercentAndBallShot(floatAmount, fullFillShots);
        chargeAmountText.text = LocalizationStrings.chargedUpAmountString;
    }

    public void ResetFullFill()
    {
        if(timerCoroutine != null) { StopCoroutine(timerCoroutine); timerCoroutine = null; }

        if(fullFillCoroutine != null) { StopCoroutine(fullFillCoroutine); fullFillCoroutine = null; }
        middleFill.fillAmount = 0;
        fullChargeAmount = 0;
        isFullFillShooting = false;
    }

    public void SetNewText()
    {
        float floatAmount = (fullChargeAmount * 100);
        middleFill.fillAmount = fullChargeAmount;
        locScript.SetChargePercentAndBallShot(floatAmount, fullFillShots);
        chargeAmountText.text = LocalizationStrings.chargedUpAmountString;
        ballsAmountText.text = LocalizationStrings.ballsShotString;
    }
    #endregion

    #region check peg ach
    public void CheckACH()
    {
        if (achScript != null) { achScript.CheckPegACH(); }
    }
    #endregion

    #region Load Data
    public void LoadData(GameData data)
    {
        middleFillIncrement = data.middleFillIncrement;
        fullFillShots = data.fullFillShots;
        fullChargeAmount = data.fullChargeAmount;

        board1Clears = data.board1Clears;
        board2Clears = data.board2Clears;
        board3Clears = data.board3Clears;
        board4Clears = data.board4Clears;
        board5Clears = data.board5Clears;
        board6Clears = data.board6Clears;
        board7Clears = data.board7Clears;
        board8Clears = data.board8Clears;
        board9Clears = data.board9Clears;
        board10Clears = data.board10Clears;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.middleFillIncrement = middleFillIncrement;
        data.fullFillShots = fullFillShots;
        data.fullChargeAmount = fullChargeAmount;

        data.board1Clears = board1Clears;
        data.board2Clears = board2Clears;
        data.board3Clears = board3Clears;
        data.board4Clears = board4Clears;
        data.board5Clears = board5Clears;
        data.board6Clears = board6Clears;
        data.board7Clears = board7Clears;
        data.board8Clears = board8Clears;
        data.board9Clears = board9Clears;
        data.board10Clears = board10Clears;
    }
    #endregion

    public OverlappingSounds soundsScript;
    public void RainbowPegAudio()
    {
        soundsScript.HitRainbowPeg();
    }

    //Level 2
    //Board 1 = 160
    //Board 2 = 144
    //Board 3 = 121
    //Board 4 = 136
    //Board 5 = 120
    //Board 6 = 135
    //Board 7 = 147
    //Board 8 = 156
    //Board 9 = 132
    //Board 10 = 128
    //Board 11 = 140
    //Board 12 = 144
    //Board 13 = 144
    //Board 14 = 153
    //Board 15 = 145

    //Level 3 (160-180)
    //Board 1 = 170
    //Board 2 = 171
    //Board 3 = 160
    //Board 4 = 160
    //Board 5 = 168
    //Board 6 = 162
    //Board 7 = 158
    //Board 8 = 170
    //Board 9 = 184
    //Board 10 = 160
    //Board 11 = 180
    //Board 12 = 160
    //Board 13 = 168
    //Board 14 = 160
    //Board 15 = 176
    //Board 16 = 180

    //Level4 (180-200)
    //Board 1 = 192
    //Board 2 = 180
    //Board 3 = 196
    //Board 4 = 180
    //Board 5 = 175
    //Board 6 = 187
    //Board 7 = 192
    //Board 8 = 176
    //Board 9 = 184
    //Board 10 = 176
    //Board 11 = 172
    //Board 12 = 200 
    //Board 13 = 196
    //Board 14 = 192
    //Board 15 = 186 
    //Board 16 = 196

    //Level 5 (197-220)
    //Board 1 = 214
    //Board 2 = 201
    //Board 3 = 199
    //Board 4 = 216
    //Board 5 = 200
    //Board 6 = 210
    //Board 7 = 216
    //Board 8 = 197 //Ad more
    //Board 9 = 207
    //Board 10 = 218
    //Board 11 = 208
    //Board 12 = 224
    //Board 13 = 203
    //Board 14 = 204
    //Board 15 = 216
    //Board 16 = 210
    //Board 17 = 207

    //Level 6 (220-240)
    //Board 1 = 238
    //Board 2 = 240
    //Board 3 = 208
    //Board 4 = 238
    //Board 5 = 220
    //Board 6 = 224
    //Board 7 = 218
    //Board 8 = 234
    //Board 9 = 243
    //Board 10 = 240
    //Board 11 = 234
    //Board 12 = 238
    //Board 13 = 240
    //Board 14 = 235
    //Board 15 = 219
    //Board 16 = 231
    //Board 17 = 224

    //Level 7 (240-260)
    //Board 1 = 240
    //Board 2 = 252
    //Board 3 = 250
    //Board 4 = 248
    //Board 5 = 252
    //Board 6 = 252
    //Board 7 = 260
    //Board 8 = 247
    //Board 9 = 264
    //Board 10 = 242
    //Board 11 = 261 
    //Board 12 = 255
    //Board 13 = 260
    //Board 14 = 258
    //Board 15 = 240
    //Board 16 = 255
    //Board 17 = 252
    //Board 18 = 252

    //Level 8 (260-280)
    //Board 1 = 264
    //Board 2 = 276
    //Board 3 = 268
    //Board 4 = 276
    //Board 5 = 280
    //Board 6 = 274
    //Board 7 = 282
    //Board 8 = 275
    //Board 9 = 270
    //Board 10 = 270
    //Board 11 = 272
    //Board 12 = 280
    //Board 13 = 270
    //Board 14 = 280
    //Board 15 = 260
    //Board 16 = 260 
    //Board 17 = 280
    //Board 18 = 276

    //Level 9 (280-310)
    //Board 1 = 288
    //Board 2 = 294
    //Board 3 = 304
    //Board 4 = 300
    //Board 5 = 308
    //Board 6 = 280
    //Board 7 = 285
    //Board 8 = 297
    //Board 9 = 300
    //Board 10 = 292
    //Board 11 = 289
    //Board 12 = 280
    //Board 13 = 300
    //Board 14 = 301
    //Board 15 = 288
    //Board 16 = 306 
    //Board 17 = 288
    //Board 18 = 289
    //Board 19 = 288

    //Level 10 (310-350)
    //Board 1 = 320
    //Board 2 = 336
    //Board 3 = 280
    //Board 4 = 350
    //Board 5 = 348
    //Board 6 = 351
    //Board 7 = 320
    //Board 8 = 315
    //Board 9 = 350
    //Board 10 = 315
    //Board 11 = 306
    //Board 12 = 315
    //Board 13 = 324
    //Board 14 = 336
    //Board 15 = 336
    //Board 16 = 350
    //Board 17 = 320
    //Board 18 = 338
    //Board 19 = 336
    //Board 20 = 350
}
