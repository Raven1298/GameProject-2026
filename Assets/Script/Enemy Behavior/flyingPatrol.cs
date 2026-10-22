using System.Numerics;
using UnityEngine;

public class flyingPatrol : State{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timer;

    public flyingPatrol(EnemyMovement enemy) : base(enemy){}
    void Start(){
        rb.gravityScale = 0;
        
    }

    // Update is called once per frame
    public override void FixedUpdate(){
        if (senses.IsAtWall()){
            enemy.Flip();
        }

        timer += Time.fixedDeltaTime;

        float bobY = Mathf.Cos(timer * config.bobFrequency) * config.bobAmplitude * config.bobFrequency;
        rb.linearVelocity = new UnityEngine.Vector2(config.flySpeed * enemy.FacingDirections, bobY);
        
    }
}
