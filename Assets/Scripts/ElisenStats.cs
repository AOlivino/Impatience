using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ElisenStats : MonoBehaviour
{

    public Text moneytext;
    public Text healthtext;
    public Text daystext;
    public static int money = 250; //static means it'll remain permanently
    public int maxHealth = 100;
    public int dayspassed = 1;
    public int currentHealth;
    public Animator animator;
    public DialogueRunner dialogueRunner;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        moneytext.gameObject.SetActive(true);
        healthtext.gameObject.SetActive(true);
        }

    // Update is called once per frame
    void Update()
    {
        moneytext.text = "Gold: " + money;
        healthtext.text = "Health: " + currentHealth;
        daystext.text = "Day " + dayspassed;
        }

    [YarnCommand("earn")]
    void GetMoney() //A function that, when referenced in other parts of code, tells the code to use this particular code
        {
        money += 50;
        }

    [YarnCommand("dayend")]
    void EndDay() //A function that, when referenced in other parts of code, tells the code to use this particular code
        {
        dayspassed++;
                if (money >= 750) {
    dialogueRunner.Stop();        
    dialogueRunner.StartDialogue("Victory");
}
        }


    public void TakeDamage(int damage) //int means integer. damage is called below
        {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        if (currentHealth <= 0)
            {
            Die();
            dialogueRunner.StartDialogue("Death");
            }

        }

    void Die()
        {
        animator.SetBool("IsDead", true);
        this.enabled = false; //if elisen dies, the script is disabled
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        }

    [YarnCommand("rest")]
    void Rest()
        {
        currentHealth = maxHealth;
        }

    }
