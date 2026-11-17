using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 12;
    public bool isBlocking = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.fKey.isPressed)
        {
            isBlocking = true;
        }
        else
        {
            isBlocking = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            health -= damage / 2; // Reduce damage by half when blocking
        }
        else
        {
            health -= damage;
        }
        SoundManager.PlaySound(SoundType.playerHurt, .2f);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
