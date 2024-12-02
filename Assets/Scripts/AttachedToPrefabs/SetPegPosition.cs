using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPegPosition : MonoBehaviour
{
    public void OnEnable()
    {
        GameObject pegHit = ObjectPool.instance.GetPegHitFromPool();
        pegHit.transform.position = gameObject.transform.position;
        GameObject Peg = ObjectPool.instance.GetPegsFromPool();
        Peg.transform.position = gameObject.transform.position;
    }
}
