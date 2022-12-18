using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SNAPscript : MonoBehaviour
{

    public AudioClip sword;
    public AudioClip slash;
    public AudioClip scream1;
    public AudioClip scream2;
    AudioSource audioSource;

void Start() {
    audioSource = GetComponent<AudioSource>(); //Unity is looking for the AudioSource component
}
[YarnCommand("playsword")]
        public void DrawSword()
    {
        audioSource.PlayOneShot(sword, 1F);
    }
[YarnCommand("playslash")]
        public void Slash()
    {
        audioSource.PlayOneShot(slash, 1F);
    }
[YarnCommand("playscream1")]
    public void Scream1()
    {
        audioSource.PlayOneShot(scream1, 1F);
    }
[YarnCommand("playscream2")]
    public void Scream2()
    {
        audioSource.PlayOneShot(scream2, 1F);
    }
}
