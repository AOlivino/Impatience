using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// attached to the non-player characters, and stores the name of the Yarn
/// node that should be run when you talk to them.
public class NPC : MonoBehaviour
{

    public string characterName = "";

    public string talkToNode = "";


    void Start()
    {
        {
            Yarn.Unity.DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        }
    }
}