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
        return Physics2D.Raycast(wallCheck.position, Vector2.right, config.wallCheckDistance, config.wallLayer);
    }

    private void OnDrawGizmosSelected(){

        //Ground Check
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * config.groundCheckDistance);

        //Wall check
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * enemy.FacingDirections * config.wallCheckDistance);
    }



}
