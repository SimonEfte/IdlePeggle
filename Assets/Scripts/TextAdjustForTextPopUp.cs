using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAdjustForTextPopUp : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    public void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.05f);
        float preferredWidth = textMeshPro.GetPreferredValues().x;
        textMeshPro.rectTransform.sizeDelta = new Vector2(preferredWidth, textMeshPro.rectTransform.sizeDelta.y);
    }

  
}
