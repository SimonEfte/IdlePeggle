using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsAndFrames : MonoBehaviour
{
    public GameObject prestigeScreen, ball1Screen, ball2Screen, ball3Screen;
    public AudioManager audioManager;
    public GameObject allObjects;
    public GameObject equippedFrame;
    public GameObject ballUpgradeFrame;

    public Image toBallFrame2BTN, toBallFrame3BTN;
    public static float smallEquipSize, bigEquipSize;
    public Button toFrame2BTN, toFrame3BTN;

    public bool isRaycastTargetEnabled = true;
    public GameObject hookHooked, hookUnhooked;

    public void Start()
    {
        smallEquipSize = 0.736f;
        bigEquipSize = 1.228f;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);

        SetFRameBTNS();

        SetAllInactive();

        if (BallUpgrades.ballNumberEquipped < 10) { BallUpgrades.isBallEquippedScreen1 = true; BallUpgrades.isBallEquippedScreen2 = false; BallUpgrades.isBallEquippedScreen3 = false; ball1Screen.SetActive(true); BallUpgrades.isInBallScreen1 = true; }

        else if (BallUpgrades.ballNumberEquipped > 9 && BallUpgrades.ballNumberEquipped < 19) { BallUpgrades.isBallEquippedScreen2 = true; BallUpgrades.isBallEquippedScreen1 = false; BallUpgrades.isBallEquippedScreen3 = false; ball2Screen.SetActive(true); BallUpgrades.isInBallScreen2 = true; }

        else { BallUpgrades.isBallEquippedScreen1 = false; BallUpgrades.isBallEquippedScreen2 = false; BallUpgrades.isBallEquippedScreen3 = true; ball3Screen.SetActive(true); BallUpgrades.isInBallScreen3 = true; }

        allObjects.SetActive(true); equippedFrame.SetActive(true);
    }

    public void SetFRameBTNS()
    {
        if (GameData.isDemo == true)
        {
            toFrame2BTN.interactable = false;
            toBallFrame2BTN.color = new Color(toBallFrame2BTN.color.r, toBallFrame2BTN.color.g, toBallFrame2BTN.color.b, 0.5f);
        }
        else
        {
            if (BallUpgrades.stickyBallPurchased == true)
            {
                toFrame2BTN.interactable = true;
                toBallFrame2BTN.color = new Color(toBallFrame2BTN.color.r, toBallFrame2BTN.color.g, toBallFrame2BTN.color.b, 1f);
                toBallFrame2BTN.raycastTarget = enabled;
            }
            else
            {
                toFrame2BTN.interactable = false;
                toBallFrame2BTN.color = new Color(toBallFrame2BTN.color.r, toBallFrame2BTN.color.g, toBallFrame2BTN.color.b, 0.5f);
                toBallFrame2BTN.raycastTarget = !enabled;
            }

            if (BallUpgrades.peggoBallPurchased == true)
            {
                toFrame3BTN.interactable = true;
                toBallFrame3BTN.color = new Color(toBallFrame3BTN.color.r, toBallFrame3BTN.color.g, toBallFrame3BTN.color.b, 1f); toBallFrame3BTN.raycastTarget = enabled;
            }
            else
            {
                toFrame3BTN.interactable = false;
                toBallFrame3BTN.color = new Color(toBallFrame3BTN.color.r, toBallFrame3BTN.color.g, toBallFrame3BTN.color.b, 0.5f);
                toBallFrame3BTN.raycastTarget = !enabled;
            }
        }
    }

    public void ToPrestigeTab()
    {
        ballUpgradeFrame.SetActive(false);
        hookHooked.SetActive(false);
        hookUnhooked.SetActive(true);
        BallUpgrades.isHooked = false;

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SetAllInactive();
        prestigeScreen.SetActive(true);
        ClickSound();
        equippedFrame.SetActive(false);
    }

    public void AwayFromPrestigeTab()
    {
        SetAllInactive();
        allObjects.SetActive(true);
        ball1Screen.SetActive(true);
        ClickSound();
        BallUpgrades.isInBallScreen1 = true;
        if(BallUpgrades.isBallEquippedScreen1 == true) { equippedFrame.SetActive(true); }
    }

    public void ToBallScreen2()
    {
        SetAllInactive();
        allObjects.SetActive(true);
        ball2Screen.SetActive(true);
        ClickSound();
        BallUpgrades.isInBallScreen2 = true;
        if (BallUpgrades.isBallEquippedScreen2 == true) { equippedFrame.SetActive(true); }
    }

    public void BackFromBallScreen2()
    {
        SetAllInactive();
        allObjects.SetActive(true);
        ball1Screen.SetActive(true);
        ClickSound();
        BallUpgrades.isInBallScreen1 = true;
        if (BallUpgrades.isBallEquippedScreen1 == true) { equippedFrame.SetActive(true); }
    }

    public void ToBallScreen3()
    {
        SetAllInactive();
        allObjects.SetActive(true);
        ball3Screen.SetActive(true);
        ClickSound();
        BallUpgrades.isInBallScreen3 = true;
        if (BallUpgrades.isBallEquippedScreen3 == true) { equippedFrame.SetActive(true); }
    }

    public void BackFromBallScreen3()
    {
        SetAllInactive();
        allObjects.SetActive(true);
        ball2Screen.SetActive(true);
        ClickSound();
        BallUpgrades.isInBallScreen2 = true;
        if (BallUpgrades.isBallEquippedScreen2 == true) { equippedFrame.SetActive(true); }
    }

    public void SetAllInactive()
    {
       

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        equippedFrame.SetActive(false);
        BallUpgrades.isInBallScreen1 = false;
        BallUpgrades.isInBallScreen2 = false;
        BallUpgrades.isInBallScreen3 = false;
        allObjects.SetActive(false);
        prestigeScreen.SetActive(false);
        ball1Screen.SetActive(false);
        if(GameData.isDemo == false)
        {
            ball2Screen.SetActive(false);
            ball3Screen.SetActive(false);
        }
        ClickSound();
    }

    public void ClickSound()
    {
        int random = Random.Range(1, 3);
        if (random == 1) { audioManager.Play("UIClick1"); }
        if (random == 2) { audioManager.Play("UIClick2"); }
    }
}
