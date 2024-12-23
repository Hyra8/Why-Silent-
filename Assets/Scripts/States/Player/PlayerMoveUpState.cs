using UnityEngine;

public class PlayerMoveUpState : State
{
    private Animator animator;
    private Animator outfitAnimator;

    public PlayerMoveUpState(GameObject owner, StateMachine stateMachine, Animator animator, Animator outfitAnimator) : base(owner, stateMachine)
    {
        this.animator = animator;
        this.outfitAnimator = outfitAnimator;
    }

    public override void Enter()
    {
        animator.Play("Player_Move_Up");
        outfitAnimator.Play("Outfit_Move_Up");
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
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            stateMachine.ChangeState(new PlayerIdleUpState(owner, stateMachine, animator, outfitAnimator));
        }
    }
}