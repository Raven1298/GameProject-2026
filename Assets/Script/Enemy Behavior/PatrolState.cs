using UnityEditor.Callbacks;
using UnityEngine;

public class PatrolState : State
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PatrolState(EnemyMovement enemy) : base(enemy){}

    public override void FixedUpdate()
    {
        if(senses.IsAtWall() || senses.IsAtCliff()){
            enemy.Flip();
            return;
        }
        rb.linearVelocity = new Vector2(config.patrolSpeed * enemy.FacingDirections, rb.linearVelocity.y);
    }

}
