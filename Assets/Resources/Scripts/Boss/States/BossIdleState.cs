using UnityEngine;
public class BossIdleState : State
{
    private BossStateMachine bossContext;
    private float curTime;
    public BossIdleState(BossStateMachine currentContext) : base(currentContext)
    {
        bossContext = currentContext;
    }
    public override void EnterState()
    {
        bossContext.Anim.Play("Idle");
        bossContext.AppliedMovementX = 0f;
        bossContext.AppliedMovementY = 0f;
        curTime = 0f;
    }
    public override void UpdateState()
    {
        curTime += Time.deltaTime;
        CheckSwitchStates();
    }
    public override void ExitState()
    {
    }

    public override void CheckSwitchStates()
    {
        if (curTime > bossContext.TimeInIdle)
        {
            if (bossContext.CurrentStage >= 2 && bossContext.GrappleInRange())
            {
                SwitchState(new BossGrappleState(bossContext));
            }
            else if (bossContext.InRange())
            {
                SwitchState(new BossAttackState(bossContext));
            } else
            {   
                SwitchState(new BossWalkState(bossContext));
            }
        } 
    }
}
