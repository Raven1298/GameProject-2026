using UnityEngine;

public class breakableWall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject breakableWallPrefab;
    EnemyHealth enemyHealth;
    
    void Start()
    {
        Quaternion rotation = Quaternion.Euler(0f, 0f, 90f);
        GameObject breakableWall = Instantiate(breakableWallPrefab, transform.position, rotation);
        enemyHealth = breakableWall.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(breakableWallPrefab == null)
        {
            Destroy(gameObject);
        }
        
        if(enemyHealth.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
