using UnityEngine;
using UnityEngine.UIElements;

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
