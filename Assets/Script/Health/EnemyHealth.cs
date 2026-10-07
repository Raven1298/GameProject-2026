using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamage
{
    public float maxHealth = 3f;
    
    private float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damageAmount){
        currentHealth -= damageAmount;
        
        if(currentHealth <= 0){
            Die();
        }
    }

    private void Die(){
        Destroy(gameObject);
    }
}
