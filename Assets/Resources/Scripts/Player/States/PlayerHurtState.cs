using UnityEngine;
public class PlayerHurtState : State
{
    private PlayerStateMachine playerContext;
    private PlayerStateFactory playerFactory;
    public PlayerHurtState(PlayerStateMachine currentContext, PlayerStateFactory pFactory) : base(currentContext, pFactory)
    {
        playerContext = currentContext;
        playerFactory = pFactory;
    }
    public override void EnterState()
    {
        playerContext.Anim.SetBool("isHurt", true);
        playerContext.AppliedMovementX = 0f;
        playerContext.AppliedMovementY = 0f;
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        playerContext.IsHurt = false;
        playerContext.Anim.SetBool("isHurt", false);
    }

    public override void CheckSwitchStates()
    {
        if (!playerContext.HurtFinished)
        {
            return;
        }
        playerContext.HurtFinished = false;
        if (playerContext.IsHitPressed)
        {
            SwitchState(playerFactory.Attack());
        }
        else if (playerContext.IsMovementPressed && playerContext.IsRunPressed)
        {
            SwitchState(playerFactory.Run());
        } else if (playerContext.IsMovementPressed)
        {   
            SwitchState(playerFactory.Walk());
        } else
        {
            SwitchState(playerFactory.Idle());
        }
    }
}
