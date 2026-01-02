using UnityEngine;

public class PlayerShootState : State
{
    private PlayerStateMachine playerContext;
    public PlayerShootState(PlayerStateMachine currentContext) : base(currentContext)
    {
        playerContext = currentContext;
    }
    public override void EnterState()
    {
        playerContext.Anim.SetTrigger("Shoot");
        playerContext.AppliedMovementX = 0f;
        playerContext.AppliedMovementY = 0f;
        // // Trigger shoot logic: Instantiate projectile (add this)
        // if (playerContext.ProjectilePrefab != null && playerContext.FirePoint != null)
        // {
        //     Instantiate(playerContext.ProjectilePrefab, playerContext.FirePoint.position, playerContext.FirePoint.rotation);
        // }
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {

    }

    public override void CheckSwitchStates()
    {
        if (playerContext.IsHurt)
        {
            SwitchState(new PlayerHurtState(playerContext));
        }
        else if (!playerContext.ShootFinished)
        {
            return;
        }
        playerContext.ShootFinished = false; 
        if (playerContext.IsMovementPressed && playerContext.IsRunPressed)
        {
            SwitchState(new PlayerRunState(playerContext));
        } else if (playerContext.IsMovementPressed)
        {   
            SwitchState(new PlayerWalkState(playerContext));
        } else
        {
            SwitchState(new PlayerIdleState(playerContext));
        }
    }
}
