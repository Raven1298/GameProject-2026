using UnityEngine;

public class EnemyDetection : MonoBehaviour{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    private EnemyMovement enemy;


    private void Awake(){
        enemy = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other){
        if (other.transform == player){
            enemy.StateMachine.ChangeState(new ChaseState(enemy, player));
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.transform == player)
        {
            enemy.StateMachine.ChangeState(enemy.CreatePatrolState());
        }
        
    }

}
