using UnityEngine;

public class enemyRangedAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float attackRange = 10f;
    public float attackCooldown = 2f;
    private float cooldownTimer;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
        {
            player = playerObject.transform;
        }
        cooldownTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if(distanceToPlayer <= attackRange && cooldownTimer <= 0f)
        {
            Shoot();
            cooldownTimer = attackCooldown;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
    }
}
