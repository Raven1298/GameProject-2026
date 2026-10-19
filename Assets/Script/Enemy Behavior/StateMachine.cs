using Unity.VisualScripting;
using UnityEngine;

public class StateMachine
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public State CurrentState{
        get;
        private set;
        
    }

    public void Initalize(State startingState){
        CurrentState = startingState;
        CurrentState.Enter();
    }
}
