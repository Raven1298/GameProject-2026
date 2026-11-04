using UnityEngine;
using UnityEngine.InputSystem;

public class rangedAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform launchPoint;
    public Transform launchPoint2;
    public GameObject projectilePrefab;
    private Vector2 aimDirection = Vector2.right;
    public float shootCooldown = .5f;
    private float shootTimer;
    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        
        HandleAiming();
        
        if (Keyboard.current.lKey.wasPressedThisFrame && shootTimer <= 0f)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        
        if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            GameObject projectile = Instantiate(projectilePrefab, launchPoint2.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().direction = aimDirection;
            shootTimer = shootCooldown;
        }
        else
        {
            GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().direction = aimDirection;  
            shootTimer = shootCooldown;
        }        
        
    }

    private void HandleAiming()
    {
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            aimDirection = Vector2.right;
        }
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            aimDirection = Vector2.left;
        }
    }
}
