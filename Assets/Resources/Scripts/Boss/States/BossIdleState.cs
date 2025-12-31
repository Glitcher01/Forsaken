using UnityEngine;
public class BossIdleState : State
{
    private BossStateMachine bossContext;
    private BossStateFactory bossFactory;
    private float curTime;
    public BossIdleState(BossStateMachine currentContext, BossStateFactory pFactory) : base(currentContext, pFactory)
    {
        bossContext = currentContext;
        bossFactory = pFactory;
    }
    public override void EnterState()
    {
        Debug.Log("idle");
        bossContext.Anim.SetBool("isIdle", true);
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
        bossContext.Anim.SetBool("isIdle", false);
    }

    public override void CheckSwitchStates()
    {
        if (bossContext.IsHurt)
        {
            SwitchState(bossFactory.Hurt());
        }
        else if (curTime > bossContext.TimeInIdle && bossContext.InRange())
        {
            SwitchState(bossFactory.Attack());
        } else if (curTime > bossContext.TimeInIdle)
        {   
            SwitchState(bossFactory.Walk());
        } 
    }
}
