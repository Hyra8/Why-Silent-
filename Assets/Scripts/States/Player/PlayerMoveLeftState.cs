using UnityEngine;

public class PlayerMoveLeftState : State
{
    private Animator animator;
    private Animator outfitAnimator;

    public PlayerMoveLeftState(GameObject owner, StateMachine stateMachine, Animator animator, Animator outfitAnimator) : base(owner, stateMachine)
    {
        this.animator = animator;
        this.outfitAnimator = outfitAnimator;
    }

    public override void Enter()
    {
        animator.Play("Player_Move_Left");
        outfitAnimator.Play("Outfit_Move_Left");
    }

    public override void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            return;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            stateMachine.ChangeState(new PlayerIdleLeftState(owner, stateMachine, animator, outfitAnimator));
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