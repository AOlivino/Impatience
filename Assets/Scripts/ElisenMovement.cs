using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class ElisenMovement : MonoBehaviour
{
    public float Speed = 8f;
    public CharacterController controller;
    public Rigidbody2D rb;
    public Animator animator; //gets a reference to our animator, which controls changing sprites with movements
    public static bool AttackMode = false;
    Vector2 movement;
    public static Vector2 lastDirection;
    public DialogueRunner dialogueRunner;
    public DialogueAdvanceInput dialogueInput;

    // Start is called before the first frame update
    void Start()
    {
        lastDirection = Vector2.zero;
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }


    // Update is called once per frame
    void Update()
    {

            if (SceneManager.GetSceneByName("Parlor").isLoaded && FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
            {
                return;
            }

            // every time we LEAVE dialogue we have to make sure we disable the input again
            if (SceneManager.GetSceneByName("Parlor").isLoaded && dialogueInput.enabled)
            {
                dialogueInput.enabled = false;
            }


        movement.x = Input.GetAxisRaw("Horizontal"); //moves horizontal, x = left and right
        movement.y = Input.GetAxisRaw("Vertical"); //moves vertical, y = up and down
        
        if (movement.x != 0)
            {
            lastDirection.x = movement.x;
            lastDirection.y = 0;
            }

        if (movement.y != 0)
            {
            lastDirection.y = movement.y;
            lastDirection.x = 0;
            }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Slash"))
            {
            
            animator.SetFloat("Horizontal", movement.x); //Takes the Horizontal parameter of the Animator and uses the sprites there for x movement
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude); //Controls movement speed
            }

        if (Input.GetKeyDown(KeyCode.LeftControl) && AttackMode == false) //&& means both sides of these must be true
            {
            Attack();
            }
            else if (AttackMode == true && SceneManager.GetSceneByName("Parlor").isLoaded)
            {
            Debug.Log("Oops, can't do that here.");
            dialogueRunner.StartDialogue("Scolding");
            }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && AttackMode == true)
            {
            StopAttacking();
            }

        animator.SetFloat("LastMoveX", lastDirection.x);
        animator.SetFloat("LastMoveY", lastDirection.y);


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Title Screen");
            }

        }
        

        [YarnCommand("attackstart")]
        void Attack() {
            AttackMode = true;
            animator.SetTrigger("Attacking");
        }

        [YarnCommand("attackend")]
        void StopAttacking() {
            AttackMode = false;
            animator.SetTrigger("Attackend");
        }


    void FixedUpdate()
        {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Slash")) //! = not true, so this only plays if this is NOT true
            rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime); //position of player plus Vector2 (x,y) variable, plus speed variable with time to keep things running smoothly
        }

    }
