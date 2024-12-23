using UnityEngine;

public class PatrolState : State
{
    public PatrolState(GameObject owner, StateMachine stateMachine) : base(owner, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entered Idle State");
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        Debug.Log("Exited Idle State");
    }
}
