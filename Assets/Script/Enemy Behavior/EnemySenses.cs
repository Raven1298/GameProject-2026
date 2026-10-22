using UnityEngine;

public class EnemySenses : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private EnemyMovement enemy;
    [SerializeField] private EnemyConfig config;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;


    


    public bool IsAtCliff(){
        
        return !Physics2D.Raycast(groundCheck.position, Vector2.down, config.groundCheckDistance, config.groundLayer);
    }

    public bool IsAtWall(){
        Vector2 direction = Vector2.right * enemy.FacingDirections;
        return Physics2D.Raycast(wallCheck.position, direction, config.wallCheckDistance, config.wallLayer);
    }
}
