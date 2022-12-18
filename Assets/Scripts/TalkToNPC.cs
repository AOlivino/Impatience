using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TalkToNPC : MonoBehaviour
{

public bool playerIsClose;
public DialogueRunner dialogueRunner;
    // Update is called once per frame
    void Start()
    {
        playerIsClose = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerIsClose) {
        dialogueRunner.StartDialogue("Work");
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") 
        {
            playerIsClose = true;
        }

            void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player") 
        {
            playerIsClose = false;
        }
            }

    }
    }