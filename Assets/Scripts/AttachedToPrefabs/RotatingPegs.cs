using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPegs : MonoBehaviour
{
    Coroutine rotationCoroutine;
    public float rotationSpeed;
    public bool right;

    void OnEnable()
    {
        int random = Random.Range(55, 130);
        int random2 = Random.Range(1,3);
        if(random2 == 1) { right = true; }
        else { right = false; }

        rotationSpeed = random;
        rotationCoroutine = StartCoroutine(RotateCoroutine());
    }

    void OnDisable()
    {
        if (rotationCoroutine != null)
            StopCoroutine(rotationCoroutine); rotationCoroutine = null;
    }

    IEnumerator RotateCoroutine()
    {
        while (true)
        {
            if(right == true) { transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime); }
            if (right == false) { transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); }
            yield return null; // Yielding null waits until the next frame
        }
    }
}
