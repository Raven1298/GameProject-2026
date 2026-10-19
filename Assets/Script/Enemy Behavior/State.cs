using UnityEditor.Callbacks;
using UnityEngine;

public abstract class State
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected Rigidbody2D rb;
    protected EnemyConfig config;
    protected EnemySenses senses;
    protected EnemyMovement enemy;
    protected State(EnemyMovement enemy){
        rb = enemy.rb;
        config = enemy.config;
        senses = enemy.senses;
        this.enemy = enemy;
    }
    public virtual void Enter(){}
    public virtual void Update(){}
    public virtual void FixedUpdate(){}
    public virtual void Exit(){}
 
}
