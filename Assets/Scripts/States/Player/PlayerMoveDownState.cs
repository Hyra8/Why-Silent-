using UnityEngine;

public class PlayerMoveDownState : State
{
    private Animator animator;
    private Animator outfitAnimator;

    public PlayerMoveDownState(GameObject owner, StateMachine stateMachine, Animator animator, Animator outfitAnimator) : base(owner, stateMachine)
    {
        this.animator = animator;
        this.outfitAnimator = outfitAnimator;
    }

    public override void Enter()
    {
        animator.Play("Player_Move_Down");
        outfitAnimator.Play("Outfit_Move_Down");
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
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            stateMachine.ChangeState(new PlayerIdleDownState(owner, stateMachine, animator, outfitAnimator));
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            stateMachine.ChangeState(new PlayerMoveUpState(owner, stateMachine, animator, outfitAnimator));
        }
    }
}
