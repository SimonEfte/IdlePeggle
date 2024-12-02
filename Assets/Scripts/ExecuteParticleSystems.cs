using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteParticleSystems : MonoBehaviour
{

    #region Pit Glows
    public Image level1X1GlowLeft, level1X1GlowRigt, level1X2GlowLeft, level1X2GlowRight, level1X3GlowLeft, level1X3GlowRight, level1X5Glow;


    public void SetCorrectGlow(string pitNumber)
    {
        if(pitNumber == "X1Left") { StartCoroutine(SetPitGlowParticle(level1X1GlowLeft)); }
        if (pitNumber == "X1Right") { StartCoroutine(SetPitGlowParticle(level1X1GlowRigt)); }
        if (pitNumber == "X2Right") { StartCoroutine(SetPitGlowParticle(level1X2GlowRight)); }
        if (pitNumber == "X2Left") { StartCoroutine(SetPitGlowParticle(level1X2GlowLeft)); }
        if (pitNumber == "X3Left") { StartCoroutine(SetPitGlowParticle(level1X3GlowLeft)); }
        if (pitNumber == "X3Right") { StartCoroutine(SetPitGlowParticle(level1X3GlowRight)); }
        if (pitNumber == "X5Pit") { StartCoroutine(SetPitGlowParticle(level1X5Glow)); }
    }

    IEnumerator SetPitGlowParticle(Image pit)
    {
        // Set initial alpha to 0
        Color targetColor = pit.color;
        targetColor.a = 0f;
        pit.color = targetColor;

        // Fade in
        float duration = 0.22f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            targetColor.a = Mathf.Lerp(0f, 0.8f, timer / duration);
            pit.color = targetColor;
            yield return null;
        }

        // Fade out
        duration = 0.22f;
        timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            targetColor.a = Mathf.Lerp(0.8f, 0f, timer / duration);
            pit.color = targetColor;
            yield return null;
        }
    }
    #endregion

}
