using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wideLineMove : MonoBehaviour
{
    public Animation animationn;

    private void OnEnable()
    {
        animationn = GetComponent<Animation>();
        int random = Random.Range(1,3);
        if(random == 1) { animationn.Play("lineMove"); }
        if (random == 2) { animationn.Play("lineMove2"); }
    }
}
