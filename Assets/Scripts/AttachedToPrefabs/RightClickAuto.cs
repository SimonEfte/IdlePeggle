using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickAuto : MonoBehaviour, IPointerClickHandler
{
    public int ballHover;

    public BallUpgrades ballUpgradeScript;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (ballHover == 2 && BallUpgrades.bouncyBallPurchased == false) { return; }
            if (ballHover == 3 && BallUpgrades.rockBallPurchased == false) { return; }
            if (ballHover == 4 && BallUpgrades.bombBallPurchased == false) { return; }
            if (ballHover == 5 && BallUpgrades.aquaBallPurchased == false) { return; }
            if (ballHover == 6 && BallUpgrades.mudBallPurchased == false) { return; }
            if (ballHover == 7 && BallUpgrades.basketBallPurchased == false) { return; }
            if (ballHover == 8 && BallUpgrades.plumBallPurchased == false) { return; }
            if (ballHover == 9 && BallUpgrades.stickyBallPurchased == false) { return; }
            if (ballHover == 10 && BallUpgrades.candyBallPurchased == false) { return; }
            if (ballHover == 11 && BallUpgrades.cookieBallPurchased == false) { return; }
            if (ballHover == 12 && BallUpgrades.limeBallPurchased == false) { return; }
            if (ballHover == 13 && BallUpgrades.goldenBallPurchased == false) { return; }
            if (ballHover == 14 && BallUpgrades.footballBallPurchased == false) { return; }
            if (ballHover == 15 && BallUpgrades.sharpnelBallPurchased == false) { return; }
            if (ballHover == 16 && BallUpgrades.zonicBallPurchased == false) { return; }
            if (ballHover == 17 && BallUpgrades.apricotBallPurchased == false) { return; }
            if (ballHover == 18 && BallUpgrades.peggoBallPurchased == false) { return; }
            if (ballHover == 19 && BallUpgrades.ghostBallPurchased == false) { return; }
            if (ballHover == 20 && BallUpgrades.starBallPurchased == false) { return; }
            if (ballHover == 21 && BallUpgrades.rainbowBallPurchased == false) { return; }
            if (ballHover == 22 && BallUpgrades.glitchyBallPurchased == false) { return; }

            ballUpgradeScript.RightClickToggle(ballHover);
        }
    }
}
