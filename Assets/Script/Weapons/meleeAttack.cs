using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class meleeAttack : MonoBehaviour
{   

    public Transform attackPoint;
    public Transform attackPointL;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int damage = 1;
    
    
    public float cooldown = 1.5f;
    private float timer;

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(Keyboard.current.jKey.wasPressedThisFrame && (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed))
        {
            AttackR();
        }
        else if(Keyboard.current.jKey.wasPressedThisFrame && (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed))
        {
            AttackL();
        }
        else if(Keyboard.current.jKey.wasPressedThisFrame)
        {
            AttackR();
        }
    }
    
    void AttackR()
    {
        if(timer <= 0)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            if(enemies.Length > 0)
            {
                foreach(Collider2D enemy in enemies)
                {
                    enemy.GetComponent<EnemyHealth>().Damage(damage);
                    
                }
            }

            Debug.Log("Attack");
            timer = cooldown;
        }
    }
    void AttackL()
    {
        if(timer <= 0)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointL.position, attackRange, enemyLayers);
            if(enemies.Length > 0)
            {
                foreach(Collider2D enemy in enemies)
                {
                    enemy.GetComponent<EnemyHealth>().Damage(damage);
                    
                }
            }

            Debug.Log("Attack");
            timer = cooldown;
        }
    }

    private void OnDrawGizzmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
