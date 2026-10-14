using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    public PlayerHealth playerHealth;
    public int damage;
    public float timeBtwAttacks = 0.15f;
    private float attackTimeCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTimeCounter = timeBtwAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        
        attackTimeCounter += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && attackTimeCounter >= timeBtwAttacks)
        {
            playerHealth.TakeDamage(damage);
            attackTimeCounter = 0f;
        }
    }
}
