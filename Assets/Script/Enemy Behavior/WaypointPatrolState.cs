using UnityEngine;

public class WaypointPatrolState : State
{
    private Transform[] points;
    private int index;

    public WaypointPatrolState(EnemyMovement enemy, Transform[] points) : base(enemy){
        this.points = points;
    }

    public override void Enter(){
        if (config.isFlying) rb.gravityScale = 0f;
    }

    public override void FixedUpdate()
    {
        Vector2 target = points[index].position;
        Vector2 toTarget = target - rb.position;

        if (toTarget.magnitude < 0.2f){
            index = (index + 1) % points.Length;   // loop back to the first point
            return;
        }

        int dir = toTarget.x > 0 ? 1 : -1;
        if (Mathf.Abs(toTarget.x) > 0.1f && dir != enemy.FacingDirections) enemy.Flip();

        if (config.isFlying)
            rb.linearVelocity = toTarget.normalized * config.flySpeed;
        else
            rb.linearVelocity = new Vector2(dir * config.patrolSpeed, rb.linearVelocity.y);
    }
}