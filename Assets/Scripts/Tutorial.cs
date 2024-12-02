using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour, IDataPersistence
{
    public Animation tutIdleAnim;
    public Image tutorialFrame;
    public GameObject tutorialFramePos;
    public TextMeshProUGUI tutText;
    public RectTransform tutFrameSize;

    public static bool playedTutorial;
    public int numberOfTutorialFrames;
    public static bool firstTimeClearBoard;
    public bool firstClear, firstBall;

    public Button okButton;

    public AudioManager audioManager;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.15f);

        if(firstTimeClearBoard == true || clickedOkFirstClear == true)
        {
            playedTutorial = true;
        }

        if (playedTutorial == false)
        {
            okButton.interactable = true;

            tutorialFramePos.SetActive(true);
            tutorialFrame.gameObject.SetActive(true);

            tutFrameSize.sizeDelta = new Vector2(290, 166);
            tutText.text = LocalizationStrings.tutString1;
            tutTextNumber = 1;
            tutText.fontSize = 22;

            tutorialFrame.pixelsPerUnitMultiplier = 1.8f;
            tutorialFrame.gameObject.transform.localPosition = new Vector2(-175, -61);

            tutorialFramePos.transform.localPosition = new Vector2(-379, 472);

            tutIdleAnim.Play("tutorialSpawn");
            StartCoroutine(Idle());
        }
    }

    public void ClickOk()
    {
        ClickSound();
        okButton.interactable = false;

        tutIdleAnim.Play("tutorialDeSpawn");
        tutIdleAnim.Stop("TutorialIdle");

        numberOfTutorialFrames += 1;
        if(numberOfTutorialFrames > 5) { playedTutorial = true; }
        if(isFirstClear == true) { clickedOkFirstClear = true; }
        StartCoroutine(Idle());
        StartCoroutine(SetNewPos());
    }

    public int tutTextNumber;
    public static bool clickedOkFirstClear;
    public bool isFirstClear;

    public void Update()
    {
        if(playedTutorial == false)
        {
            if(firstTimeClearBoard == true && firstClear == false && numberOfTutorialFrames > 3 && clickedOkFirstClear == false)
            {
                isFirstClear = true;
                tutorialFramePos.SetActive(true);

                firstClear = true;

                tutFrameSize.sizeDelta = new Vector2(290, 315);
                tutText.text = LocalizationStrings.tutString2;
                tutTextNumber = 2;
                tutText.fontSize = 20;
                tutorialFrame.pixelsPerUnitMultiplier = 1.8f;
                tutorialFrame.gameObject.transform.localPosition = new Vector2(-205, -157);

                tutorialFramePos.transform.localPosition = new Vector2(-333, 478);

                tutIdleAnim.Play("tutorialSpawn");
                StartCoroutine(Idle());
                okButton.interactable = true;
            }

            if(BallUpgrades.firstTimePurchaseNewBall == true && firstBall == false)
            {
                firstBall = true;

                tutorialFramePos.SetActive(true);

                tutFrameSize.sizeDelta = new Vector2(290, 236);
                tutText.text = LocalizationStrings.tutString3;
                tutTextNumber = 3;
                tutText.fontSize = 20;
                tutorialFrame.pixelsPerUnitMultiplier = 1.8f;
                tutorialFrame.gameObject.transform.localPosition = new Vector2(-205, -60);

                tutorialFramePos.transform.localPosition = new Vector2(609, 54);

                tutIdleAnim.Play("tutorialSpawn");
                StartCoroutine(Idle());
                okButton.interactable = true;
            }
        }
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(0.7f);
        tutIdleAnim.Play("TutorialIdle");
    }

    IEnumerator SetNewPos()
    {
        yield return new WaitForSeconds(0.33f);
        okButton.interactable = true;
        tutIdleAnim.Play("tutorialSpawn");
        if (numberOfTutorialFrames == 1)
        {
            tutFrameSize.sizeDelta = new Vector2(290, 207);
            tutText.text = LocalizationStrings.tutString4;
            tutTextNumber = 4;
            tutText.fontSize = 25;
            tutorialFrame.pixelsPerUnitMultiplier = 1.8f;
            tutorialFramePos.transform.localPosition = new Vector2(380, 258);

            tutorialFrame.gameObject.transform.localPosition = new Vector2(-209, -61);
        }

        if (numberOfTutorialFrames == 2)
        {
            tutFrameSize.sizeDelta = new Vector2(290, 275);
            tutText.text = LocalizationStrings.tutString5;
            tutTextNumber = 5;
            tutText.fontSize = 25;
            tutorialFrame.pixelsPerUnitMultiplier = 1.8f;
            tutorialFramePos.transform.localPosition = new Vector2(-270, -24);

            tutorialFrame.gameObject.transform.localPosition = new Vector2(-209, -61);
        }

        if (numberOfTutorialFrames == 3)
        {
            tutFrameSize.sizeDelta = new Vector2(290, 315);
            tutText.text = LocalizationStrings.tutString6;
            tutTextNumber = 6;
            tutText.fontSize = 25;
            tutorialFrame.pixelsPerUnitMultiplier = 1.8f;
            tutorialFramePos.transform.localPosition = new Vector2(440, 49);
        }

        if (numberOfTutorialFrames > 3) { tutorialFramePos.SetActive(false); }
    }

    public void SetNewText()
    {
        if(tutorialFramePos.activeInHierarchy == true)
        {
            if(tutTextNumber == 1) { tutText.text = LocalizationStrings.tutString1; }
            if (tutTextNumber == 2) { tutText.text = LocalizationStrings.tutString2; }
            if (tutTextNumber == 3) { tutText.text = LocalizationStrings.tutString3; }
            if (tutTextNumber == 4) { tutText.text = LocalizationStrings.tutString4; }
            if (tutTextNumber == 5) { tutText.text = LocalizationStrings.tutString5; }
            if (tutTextNumber == 6) { tutText.text = LocalizationStrings.tutString6; }
        }
    }

    public void ClickSound()
    {
        int random = Random.Range(1, 3);
        if (random == 1) { audioManager.Play("UIClick1"); }
        if (random == 2) { audioManager.Play("UIClick2"); }
    }

    #region Load Data
    public void LoadData(GameData data)
    {
        playedTutorial = data.playedTutorial;
        firstTimeClearBoard = data.firstTimeClearBoard;
        clickedOkFirstClear = data.clickedOkFirstClear;
    }
    #endregion

    #region Save Data
    public void SaveData(ref GameData data)
    {
        data.playedTutorial = playedTutorial;
        data.firstTimeClearBoard = firstTimeClearBoard;
        data.clickedOkFirstClear = clickedOkFirstClear;
    }
    #endregion

}
