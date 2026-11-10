using UnityEngine;

public class ChaseState : State{
    private Transform target;

    public ChaseState(EnemyMovement enemy, Transform target) : base(enemy){
        this.target = target;
    }    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void FixedUpdate(){
        float dx = target.position.x - rb.position.x;
        int dir = dx > 0 ? 1: - 1;

        //face the player
        if (Mathf.Abs(dx) > 0.1f && dir != enemy.FacingDirections){
            enemy.Flip();
        }    

        if (config.isFlying){
            Vector2 toTarget = ((Vector2)target.position - rb.position).normalized;
            rb.linearVelocity = toTarget * config.chaseSpeed;
        }
        else{
            if (senses.IsAtWall() || senses.IsAtCliff()){
                rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
                return;
            }
            rb.linearVelocity = new Vector2(dir* config.chaseSpeed, rb.linearVelocity.y);
        }
    }
}
