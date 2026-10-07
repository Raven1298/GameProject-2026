using UnityEngine;
using UnityEngine.InputSystem;

public class meleeAttack : MonoBehaviour
{   

    private RaycastHit2D[] hits;

    public Transform attackTransform;
    public float attackRange = 1f;
    private LayerMask attackableLayer;
    public float damageAmount = 1f;
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
        if(Keyboard.current.spaceKey.wasPressedThisFrame && attackTimeCounter >= timeBtwAttacks){
            attackTimeCounter = 0f;
            
            Attack();
        }

        attackTimeCounter += Time.deltaTime;
    }

    void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

        for(int i = 0; i < hits.Length; i++){
            IDamage iDamage = hits[i].collider.gameObject.GetComponent<IDamage>();

            if(iDamage != null){
                iDamage.Damage(damageAmount);
            }
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
