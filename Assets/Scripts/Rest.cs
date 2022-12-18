using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Rest : MonoBehaviour
{
private Transform enemies;
private float within_range = 25f;
public DialogueRunner dialogueRunner;
public Text waittext;

    // Update is called once per frame
    void Start()
    {
        enemies = GameObject.FindWithTag("Enemy").transform;
        waittext.gameObject.SetActive(false);
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, enemies.position); //measures distance between you and enemies
        if(Input.GetKeyDown(KeyCode.Z) && dist <= within_range) {
        dialogueRunner.StartDialogue("Rest");
        waittext.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Z) && dist >= within_range) {
        waittext.gameObject.SetActive(true);
        }
        
    }
}