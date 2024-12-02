using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegHit : MonoBehaviour
{
    public static int pegHitAmount;
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        ObjectPool.instance.ReturnPegHitFromPool(gameObject);
        pegHitAmount -= 1;
    }
}
