using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction;
    public float lifeSpawn = 2f;
    public float speed;
    public float damageAmount = 1f;
    public LayerMask enemyLayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = direction * speed;
        RotateProjectile();
        Destroy(gameObject, lifeSpawn);
    }

    private void RotateProjectile()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if((enemyLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damageAmount);
            Destroy(gameObject);
        }
        
    }
}
