using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class meleeAttack : MonoBehaviour
{   

    private RaycastHit2D[] hits;

    public Transform attackTransform;
    public float attackRange = 1f;
    private LayerMask attackableLayer;
    public float damageAmount = 1f;
    public float timeBtwAttacks = 0.35f;
    private float attackTimeCounter;

    public bool shouldBeDamaging { get; private set; } = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        attackTimeCounter = timeBtwAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.jKey.wasPressedThisFrame && attackTimeCounter >= timeBtwAttacks){
            attackTimeCounter = 0f;
            
            //Attack();
            HitboxFlasher flasher = GetComponent<HitboxFlasher>();
            if (flasher != null)
            {
                flasher.Flash(Color.red, 0.15f);
            }
            Debug.Log("Thats an attack");
            SoundManager.PlaySound(SoundType.Attack, .5f);
        }

        attackTimeCounter += Time.deltaTime;
    }

    /*
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
    */

    public IEnumerator DamageWhileSlashIsActive()
    {
        
        shouldBeDamaging = true;
        
        while (shouldBeDamaging)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

            for(int i = 0; i < hits.Length; i++){
                IDamage iDamage = hits[i].collider.gameObject.GetComponent<IDamage>();

                if(iDamage != null && !iDamage.HasTakenDamage){
                    iDamage.Damage(damageAmount);
                }
            }
            yield return null; // Wait for the next frame before checking again
        }
    }

   

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("Hitbox"))
    {
        HitboxFlasher flasher = GetComponent<HitboxFlasher>();
        if (flasher != null)
        {
            flasher.Flash(Color.white, 0.15f);
        }
    }
    }

    void ShouldBeDamagingToTrue()
    {
        shouldBeDamaging = true;
    }

    void ShouldBeDamagingToFalse()
    {
        shouldBeDamaging = false;
    }
}
