using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BlackBox : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Start()
    {
        FadeOut();
    }
[YarnCommand("fadein")]
       public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }

[YarnCommand("fadeout")]
        public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}
