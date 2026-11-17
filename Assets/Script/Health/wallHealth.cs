using UnityEngine;

public class wallHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxHealth = 5f;
    
    
    public float currentHealth;

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
        HasTakenDamage = true;
        
        currentHealth -= damageAmount;
        
        if(currentHealth <= 0){
            Die();
        }
    }

    public bool HasTakenDamage { get; set; } = false;

    private void Die(){
        Destroy(gameObject);
    }
}
