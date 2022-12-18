using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour
{
    [SerializeField]
    public float Walkspeed = 1f;
    private float Canattack;

    public Transform target;
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    public bool nonhostile;
    public Rigidbody2D rb;
    public static int money = ElisenStats.money;
    private float within_range = 15f;
    public bool flip;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.Find("Player").transform;

    }

    void OnTriggerEnter2D(Collider2D other) //if the player enters a boundary
        {
        if (other.gameObject.tag == "Player")
            {
            target = other.transform;
            }
        }

    void OnTriggerExit2D(Collider2D other) //if player exits boundary
        {
        if (other.gameObject.tag == "Player") //checks the tag of an object nearby
            {
            target = null; //No target to pursuit
            }
        }

    void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "Player") //checks the tag of an object nearby
            {
            //Play the attack animation
            animator.SetTrigger("EnemyAttack");
            collision.gameObject.GetComponent<ElisenStats>().TakeDamage(10); //calling a void from another script
            }
        }

    void Update() {

        float dist = Vector2.Distance(target.position, transform.position);
        Vector2 scale = transform.localScale;

        if (dist <= within_range)
            {
            Attack();
            }



        transform.localScale = scale;

        }

    public void Attack()
        {
    float step = Walkspeed * Time.deltaTime; //establishes itself as a variable, taking walkspeed plus the time it takes to move
    transform.position = Vector2.MoveTowards(transform.position, target.position, step); //Same as Lerp, which moves the object towards a destination. 


        Vector2 scale = transform.localScale; //keeps track of the current scale and establishes scale.
        if (target.transform.position.x > transform.position.x)
            {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        transform.localScale = scale; //creates a variable for scale
        }

    public void TakeDamage(int damage)
        {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;


        if (currentHealth <= 0)
            {
            Die();
            ElisenStats.money += 5;
            }

        }

    void Die()
        {
        animator.SetBool("IsDead", true);
        this.enabled = false;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        }
}
