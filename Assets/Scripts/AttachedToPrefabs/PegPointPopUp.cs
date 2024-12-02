using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PegPointPopUp : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private Animation popUpAnim;
    public float moveSpeed;
    public float waitTime;
    public Color prestigePointColor;
    public bool hitPit;
    public bool isPrestige, isGold;

    public void Awake()
    {
        popUpAnim = GetComponent<Animation>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public static int numberOfTextOnScreen;
    private void OnEnable()
    {
        /*if(Prestige.isLoaded == true)
        {
            if (isGold == true)
            {
                numberOfTextOnScreen += 1;
                if (numberOfTextOnScreen > 1300) { Debug.Log(numberOfTextOnScreen); }
            }
        }
        */

        popUpAnim.Play("PegPointPopUp");

        hitPit = false;
        StartCoroutine(MoveAndFade());
    }
    
    private IEnumerator MoveAndFade()
    {
        yield return new WaitForSeconds(0.02f);

        if (gameObject.layer == 27 || gameObject.layer == 28) { hitPit = true;  }
        else if(gameObject.layer == 25 || gameObject.layer == 26) { hitPit = false; }
        else if (gameObject.layer == 29)
        {
            hitPit = false;
        }

        #region Hit golden peg
        if (hitPit == false)
        {
            moveSpeed = 0.6f; waitTime = 0.8f;

            // Move upwards
            float elapsedTime = 0f;
            Vector3 initialPosition = transform.position;
            Vector3 targetPosition = initialPosition + Vector3.up;

            while (elapsedTime < moveSpeed)
            {
                transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveSpeed);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
            if(isPrestige == true) { ObjectPool.instance.ReturnPRestigeTextFromPool(textMeshPro); }
            else { ObjectPool.instance.ReturnPegPopUpFromPool(textMeshPro); numberOfTextOnScreen -= 1; }
        }
        #endregion

        #region hit bucket
        if (hitPit == true)
        {
            popUpAnim.Play("PitTextAnim");

            yield return new WaitForSeconds(0.7f);
            if (isPrestige == true) { ObjectPool.instance.ReturnPRestigeTextFromPool(textMeshPro); }
            else { ObjectPool.instance.ReturnPegPopUpFromPool(textMeshPro); numberOfTextOnScreen -= 1; }
        }
        #endregion
    }

}
