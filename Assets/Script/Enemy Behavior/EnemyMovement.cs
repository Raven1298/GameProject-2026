using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Variables
    public int FacingDirections
    {
        get;
        private set;
    } = 1;

    //Components
    public Rigidbody2D rb{
        get;
        private set;
    }

    public EnemyConfig config;
    public EnemySenses senses{
        get;
        private set;
    }

    public StateMachine StateMachine
    {
        get;
        private set;
    }

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        StateMachine = new StateMachine();
        senses = GetComponent<EnemySenses>();
        
    }

    public void Start()
    {
        State startState = config.isFlying ? new flyingPatrol(this) : new PatrolState(this);
        StateMachine.Initalize(startState);
    }

    private void Update() => StateMachine.CurrentState.Update();
    private void FixedUpdate() => StateMachine.CurrentState?.FixedUpdate();

    public void Flip()
    {
        FacingDirections *= -1;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * FacingDirections;
        transform.localScale = scale;
    }
}
