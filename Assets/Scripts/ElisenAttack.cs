using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElisenAttack : MonoBehaviour
{
    public Animator animator;
    public static bool AttackMode = false;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    static Vector2 lastDirection = ElisenMovement.lastDirection;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && AttackMode == false)
            {
            AttackMode = true;
            animator.SetBool("AttackMode", true); //a bool checks if something is true or false. this activates it.
            animator.SetTrigger("Attacking");
            }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && AttackMode == true)
            {
            AttackMode = false;
            animator.SetBool("AttackMode", false);
            animator.SetTrigger("Attackend");
            }

        if (Input.GetKeyDown(KeyCode.Space) && AttackMode == true)
            {
            Attack();
            Debug.Log("Slash!");
            }
    }

    void Attack()
        {
        //Play the attack animation
        animator.SetTrigger("Slash");

        //Creates a circle that sees enemies in our range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Deal damage
        foreach(Collider2D enemy in hitEnemies)
            {
            enemy.GetComponent<Enemyy>().TakeDamage(20); //calling a void from another script
            }
        }



}

