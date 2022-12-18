using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SpriteSwitcher : MonoBehaviour
{

    public Sprite neutral, annoyed, pissed, snap;
    public DialogueRunner dialogueRunner;

    

[YarnCommand("changeto_neutral")]
    public void SpriteChange1()
    {
        if (GetComponent<SpriteRenderer>().sprite != neutral) 
     gameObject.GetComponent<SpriteRenderer>().sprite = neutral;
}

[YarnCommand("changeto_annoyed")]
    public void SpriteChange2()
    {
        if (GetComponent<SpriteRenderer>().sprite != annoyed) 
     gameObject.GetComponent<SpriteRenderer>().sprite = annoyed;
}

[YarnCommand("changeto_pissed")]
    public void SpriteChange3()
    {
        if (GetComponent<SpriteRenderer>().sprite != pissed) 
     gameObject.GetComponent<SpriteRenderer>().sprite = pissed;
}

[YarnCommand("changeto_snap")]
    public void SpriteChange4()
    {
        if (GetComponent<SpriteRenderer>().sprite != snap) 
     gameObject.GetComponent<SpriteRenderer>().sprite = snap;
}

[YarnCommand("spritein")]
    public void SpriteIn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
}

[YarnCommand("spriteout")]
    public void SpriteOut()
    {
        GetComponent<SpriteRenderer>().enabled = false;
}


    public void FadeIn()
    {
        if (GetComponent<SpriteRenderer>().sprite != snap) 
     gameObject.GetComponent<SpriteRenderer>().sprite = snap;
}

[YarnCommand("pause")]
public static void TimeStop() {
Time.timeScale = 0f;
}
[YarnCommand("resume")]
public static void TimeResume() {
Time.timeScale = 1f;
}

    }
