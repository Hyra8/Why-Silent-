using UnityEngine;

public class PlayerIdleRightState : State
{
    private Animator animator;
    private Animator outfitAnimator;

    public PlayerIdleRightState(GameObject owner, StateMachine stateMachine, Animator animator, Animator outfitAnimator) : base(owner, stateMachine)
    {
        this.animator = animator;
        this.outfitAnimator = outfitAnimator;
    }

    public override void Enter()
    {
        animator.Play("Player_Idle_Right");
        outfitAnimator.Play("Outfit_Idle_Right");
    }

    public override void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            stateMachine.ChangeState(new PlayerMoveLeftState(owner, stateMachine, animator, outfitAnimator));
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            stateMachine.ChangeState(new PlayerMoveRightState(owner, stateMachine, animator, outfitAnimator));
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            stateMachine.ChangeState(new PlayerMoveDownState(owner, stateMachine, animator, outfitAnimator));
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            stateMachine.ChangeState(new PlayerMoveUpState(owner, stateMachine, animator, outfitAnimator));
        }
    }
}