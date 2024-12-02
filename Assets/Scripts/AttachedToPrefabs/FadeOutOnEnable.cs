using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutOnEnable : MonoBehaviour
{
    public Animation anim;

    public void Awake()
    {
        //anim.GetComponent<Animation>();
    }

    public void OnEnable()
    {
        anim.Play("ChildPopUpFade");
    }
}
