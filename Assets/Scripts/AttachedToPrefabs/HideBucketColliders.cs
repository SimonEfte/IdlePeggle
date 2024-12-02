using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBucketColliders : MonoBehaviour
{
    public GameObject colliderRight, colliderLeft;
    public bool isMidRight1, isMidRight2, isMidLeft1, isMidLeft2, isTinyRight1, isTinyRight2, isTinyLeft1, isTinyLeft2, isBigRight1, isBigRight2, isBigLeft1, isBigLeft2;

    public void Awake()
    {
        if (gameObject.name == "BounceColliderLeft_TINYISTRIGGER_1") { isTinyLeft1 = true; }
        if (gameObject.name == "BounceColliderRight_TINYISTRIGGER_1") { isTinyRight1 = true; }
        if (gameObject.name == "BounceColliderLeft_TINYISTRIGGER_2") { isTinyLeft2 = true; }
        if (gameObject.name == "BounceColliderRight_TINYISTRIGGER_2") { isTinyRight2 = true; }

        if (gameObject.name == "BounceColliderRight_MID_ISTRIGGER_1") { isMidRight1 = true; }
        if (gameObject.name == "BounceColliderLeft_MID_ISTRIGGER_1") { isMidLeft1 = true; }
        if (gameObject.name == "BounceColliderRight_MID_ISTRIGGER_2") { isMidRight2 = true; }
        if (gameObject.name == "BounceColliderLeft_MID_ISTRIGGER_2") { isMidLeft2 = true; }

        if (gameObject.name == "BounceColliderLeft_BIGISTRIGGER_1") { isBigLeft1 = true; }
        if (gameObject.name == "BounceColliderRight_BIGISTRIGGER_1") { isBigRight1 = true; }
        if (gameObject.name == "BounceColliderLeft_BIGISTRIGGER_2") { isBigLeft2 = true; }
        if (gameObject.name == "BounceColliderRight_BIGISTRIGGER_2") { isBigRight2 = true; }
    }

    private void OnEnable()
    {
        colliderRight.SetActive(true);
        colliderLeft.SetActive(true);

        midLeftCollideW_MID = false;
        midLeftCollideW_BIG1 = false;
        midLeftCollideW_BIG2 = false;
        midRightCollideW_MID = false;
        midRightCollideW_BIG1 = false;
        midRightCollideW_BIG2 = false;
        tinyLeftCollideW_TINY = false;
        tinyRightCollideW_TINY = false;
        tinyLeftCollideW_MID1 = false;
        tinyLeftCollideW_MID2 = false;
        tinyRightCollideW_MID1 = false;
        tinyRightCollideW_MID2 = false;
        tinyLeftCollideW_BIG1 = false;
        tinyLeftCollideW_BIG2 = false;
        tinyRightCollideW_BIG1 = false;
        tinyRightCollideW_BIG2 = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        if(collision.gameObject.layer == 6) { return; }
        else if (collision.gameObject.layer == 8) { return; }
        else if (collision.gameObject.layer == 9) { return; }
        else if (collision.gameObject.layer == 15) { return; }
        else if (collision.gameObject.layer == 16) { return; }

        #region Tiny collide with tiny
        if (isTinyLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderSMALL_2")
            {
                tinyLeftCollideW_TINY = true;
                colliderLeft.SetActive(false);
            }
        }
        else if (isTinyRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderSMALL_2")
            {
                tinyRightCollideW_TINY = true;
                colliderRight.SetActive(false);
            }
        }
        else if (isTinyLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderSMALL_1")
            {
                tinyLeftCollideW_TINY = true;
                colliderLeft.SetActive(false);
            }
        }
        else if (isTinyRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderSMALL_2")
            {
                tinyRightCollideW_TINY = true;
                colliderRight.SetActive(false);
            }
        }
        #endregion

        #region Tiny collide with mid
        if (isTinyRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_2")
            {
                tinyRightCollideW_MID2 = true;
                colliderRight.SetActive(false);
            }
            else if (collision.gameObject.name == "FullColliderMID_1")
            {
                tinyRightCollideW_MID1 = true;
                colliderRight.SetActive(false); 
            }
        }
        else if (isTinyLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_2")
            {
                tinyLeftCollideW_MID2 = true;
                colliderLeft.SetActive(false);
            }
            else if (collision.gameObject.name == "FullColliderMID_1")
            {
                tinyLeftCollideW_MID1 = true;
                colliderLeft.SetActive(false);
            }
        }
        else if (isTinyRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_1")
            {
                tinyRightCollideW_MID1 = true;
                colliderRight.SetActive(false);
            }
            else if (collision.gameObject.name == "FullColliderMID_2")
            {
                tinyRightCollideW_MID2 = true;
                colliderRight.SetActive(false);
            }
        }
        else if (isTinyLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_1")
            {
                tinyLeftCollideW_MID1 = true;
                colliderLeft.SetActive(false);
            }
            else if (collision.gameObject.name == "FullColliderMID_2")
            {
                tinyLeftCollideW_MID2 = true;
                colliderLeft.SetActive(false); 
            }
        }
        #endregion

        #region Tiny collide with big
        if (isTinyRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                tinyRightCollideW_BIG2 = true;
                colliderRight.SetActive(false);
            }
            else if (collision.gameObject.name == "FullColliderBIG_1")
            {
                tinyRightCollideW_BIG1 = true;
                colliderRight.SetActive(false);
            }
        }
        else if (isTinyLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                tinyLeftCollideW_BIG2 = true;
                colliderLeft.SetActive(false);

            }
            else if (collision.gameObject.name == "FullColliderBIG_1")
            {
                tinyLeftCollideW_BIG1 = true;
                colliderLeft.SetActive(false);
            }
        }
        else if (isTinyRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                tinyRightCollideW_BIG1 = true;
                colliderRight.SetActive(false);
            }
            else if (collision.gameObject.name == "FullColliderBIG_2")
            {
                tinyRightCollideW_BIG2 = true;
                colliderRight.SetActive(false);
            }
        }
        else if (isTinyLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                tinyLeftCollideW_BIG1 = true;
                colliderLeft.SetActive(false);
            }
            else if (collision.gameObject.name == "FullColliderBIG_2")
            {
                tinyLeftCollideW_BIG2 = true;
                colliderLeft.SetActive(false);
            }
        }
        #endregion

        #region Mid collide with mid
        if (isMidRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_2")
            {
                colliderRight.SetActive(false);
                midRightCollideW_MID = true;
            }
        }
        else if (isMidLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_2")
            {
                colliderLeft.SetActive(false);
                midLeftCollideW_MID = true;
            }
        }
        else if (isMidRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_1")
            {
                colliderRight.SetActive(false);
                midRightCollideW_MID = true;
            }
        }
        else if (isMidLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_1")
            {
                colliderLeft.SetActive(false);
                midLeftCollideW_MID = true;
            }
        }
        #endregion

        #region Mid collide with big
        if (isMidRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                colliderRight.SetActive(false);
                midRightCollideW_BIG2 = true;
            }
            else if (collision.gameObject.name == "FullColliderBIG_1") { colliderRight.SetActive(false); midRightCollideW_BIG1 = true; }
        }
        else if (isMidLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                colliderLeft.SetActive(false);
                midLeftCollideW_BIG2 = true;
            }
            else if (collision.gameObject.name == "FullColliderBIG_1") { colliderLeft.SetActive(false); midLeftCollideW_BIG1 = true; }
        }
        else if (isMidRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                colliderRight.SetActive(false);
                midRightCollideW_BIG1 = true;
            }
            else if (collision.gameObject.name == "FullColliderBIG_2") 
            { 
                colliderRight.SetActive(false); midRightCollideW_BIG2 = true; 
            }
        }
        else if (isMidLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                colliderLeft.SetActive(false);
                midLeftCollideW_BIG1 = true;
            }
            else if (collision.gameObject.name == "FullColliderBIG_2") 
            {
                colliderLeft.SetActive(false); midLeftCollideW_BIG2 = true; 
            }
        }
        #endregion

        #region Big collide with big
        if (isBigRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                colliderRight.SetActive(false);
            }
        }
        else if (isBigLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                colliderLeft.SetActive(false);
            }
        }
        else if (isBigRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                colliderRight.SetActive(false);
            }
        }
        else if (isBigLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                colliderLeft.SetActive(false);
            }
        }
        #endregion
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        #region Tiny exit tiny
        if (isTinyLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderSMALL_2")
            {
                tinyLeftCollideW_TINY = false;
                SetTinyRightActive();
            }
        }
        else if (isTinyRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderSMALL_2")
            {
                tinyRightCollideW_TINY = false;
                SetTinyRightActive();
            }
        }
        else if (isTinyLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderSMALL_1")
            {
                tinyLeftCollideW_TINY = false;
                SetTinyRightActive();
            }
        }
        else if (isTinyLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderSMALL_2")
            {
                tinyLeftCollideW_TINY = false;
                SetTinyRightActive();
            }
        }
        #endregion

        #region Tiny collide with mid
        if (isTinyRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_2")
            {
                tinyRightCollideW_MID2 = false;
                SetTinyRightActive();
            }
            else if (collision.gameObject.name == "FullColliderMID_1") 
            {
                tinyRightCollideW_MID1 = false;
                SetTinyRightActive();
            }
        }
        else if (isTinyLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_2")
            {
                tinyLeftCollideW_MID2 = false;
                SetTinyLeftActive();
            }
            else if (collision.gameObject.name == "FullColliderMID_1")
            {
                tinyLeftCollideW_MID1 = false;
                SetTinyLeftActive();
            }
        }
        else if (isTinyRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_1")
            {
                tinyRightCollideW_MID1 = false;
                SetTinyRightActive();
            }
            else if (collision.gameObject.name == "FullColliderMID_2")
            {
                tinyRightCollideW_MID2 = false;
                SetTinyRightActive();
            }
        }
        else if (isTinyLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_1")
            {
                tinyLeftCollideW_MID1 = false;
                SetTinyLeftActive();
            }
            else if (collision.gameObject.name == "FullColliderMID_2") 
            {
                tinyLeftCollideW_MID2 = false;
                SetTinyLeftActive();
            }
        }
        #endregion

        #region Tiny exit big
        if (isTinyRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                tinyRightCollideW_BIG2 = false;
                SetMidRight1ActiveOrInactive();
            }
            else if (collision.gameObject.name == "FullColliderBIG_1")
            {
                tinyRightCollideW_BIG1 = false;
                SetMidRight1ActiveOrInactive();
            }
        }
        else if (isTinyLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                tinyLeftCollideW_BIG2 = false;
                SetMidLeft1ActiveOrInactive();
            }
            else if (collision.gameObject.name == "FullColliderBIG_1")
            {
                tinyLeftCollideW_BIG1 = false;
                SetMidLeft1ActiveOrInactive();
            }
        }
        else if (isTinyRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                tinyRightCollideW_BIG1 = false;
                SetMidRight1ActiveOrInactive();
            }
            else if (collision.gameObject.name == "FullColliderBIG_2")
            {
                tinyRightCollideW_BIG2 = false;
                SetMidRight1ActiveOrInactive();
            }
        }
        else if (isTinyLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                tinyLeftCollideW_BIG1 = false;
                SetMidLeft1ActiveOrInactive();
            }
            else if (collision.gameObject.name == "FullColliderBIG_2")
            {
                tinyLeftCollideW_BIG2 = false;
                SetMidLeft1ActiveOrInactive();
            }
        }
        #endregion

        #region Mid exit mid collision
        if (isMidRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_2")
            {
                midRightCollideW_MID = false;
                SetMidRight1ActiveOrInactive();
            }
        }
        else if (isMidLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_2" )
            {
                midLeftCollideW_MID = false;
                SetMidLeft1ActiveOrInactive();
            }
        }
        else if(isMidRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_1")
            {
                midRightCollideW_MID = false;
                SetMidRight1ActiveOrInactive();
            }
        }
        else if (isMidLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderMID_1")
            {
                midLeftCollideW_MID = false;
                SetMidLeft1ActiveOrInactive();
            }
        }
        #endregion

        #region Mid exit big collision
        if (isMidRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                midRightCollideW_BIG2 = false;
                SetMidRight1ActiveOrInactive();
            }
            else if (collision.gameObject.name == "FullColliderBIG_1")
            {
                midRightCollideW_BIG1 = false;
                SetMidRight1ActiveOrInactive();
            }
        }
        else if (isMidLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                midLeftCollideW_BIG2 = false;
                SetMidLeft1ActiveOrInactive();
            }
            else if (collision.gameObject.name == "FullColliderBIG_1") 
            {
                midLeftCollideW_BIG1 = false;
                SetMidLeft1ActiveOrInactive();
            }
        }
        else if (isMidRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                midRightCollideW_BIG1 = false;
                SetMidRight1ActiveOrInactive();
            }
            else if (collision.gameObject.name == "FullColliderBIG_2")
            {
                midRightCollideW_BIG2 = false;
                SetMidRight1ActiveOrInactive();
            }
        }
        else if (isMidLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                midLeftCollideW_BIG1 = false;
                SetMidLeft1ActiveOrInactive();
            }
            else if (collision.gameObject.name == "FullColliderBIG_2") 
            {
                midLeftCollideW_BIG2 = false;
                SetMidLeft1ActiveOrInactive();
            }
        }
        #endregion

        #region Big exit big collision
        if (isBigRight1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                colliderRight.SetActive(true);
            }
        }
        else if (isBigLeft1 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_2")
            {
                colliderLeft.SetActive(true);
            }
        }
        else if (isBigRight2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                colliderRight.SetActive(true);
            }
        }
        else if (isBigLeft2 == true)
        {
            if (collision.gameObject.name == "FullColliderBIG_1")
            {
                colliderLeft.SetActive(true);
            }
        }
        #endregion
    }

    public bool midLeftCollideW_MID, midLeftCollideW_BIG1, midLeftCollideW_BIG2, midRightCollideW_MID, midRightCollideW_BIG1, midRightCollideW_BIG2;

    public void SetMidRight1ActiveOrInactive()
    {
       if (midRightCollideW_MID == false && midRightCollideW_BIG1 == false && midRightCollideW_BIG2 == false) { colliderRight.SetActive(true); }
    }

    public void SetMidLeft1ActiveOrInactive()
    {
        if (midLeftCollideW_MID == false && midLeftCollideW_BIG1 == false && midLeftCollideW_BIG2 == false) { colliderLeft.SetActive(true); }
    }

    public bool tinyLeftCollideW_TINY, tinyRightCollideW_TINY, tinyLeftCollideW_MID1, tinyLeftCollideW_MID2, tinyRightCollideW_MID1, tinyRightCollideW_MID2, tinyLeftCollideW_BIG1, tinyLeftCollideW_BIG2, tinyRightCollideW_BIG1, tinyRightCollideW_BIG2;

    public void SetTinyRightActive()
    {
        if (tinyRightCollideW_TINY == false && tinyRightCollideW_MID1 == false && tinyRightCollideW_MID2 == false && tinyRightCollideW_BIG1 == false && tinyRightCollideW_BIG2 == false) { colliderRight.SetActive(true); }
    }

    public void SetTinyLeftActive()
    {
        if (tinyLeftCollideW_TINY == false && tinyLeftCollideW_MID1 == false && tinyLeftCollideW_MID2 == false && tinyLeftCollideW_BIG1 == false && tinyLeftCollideW_BIG2 == false) { colliderLeft.SetActive(true); }
    }
}
