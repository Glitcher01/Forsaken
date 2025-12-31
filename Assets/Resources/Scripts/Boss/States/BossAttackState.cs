using UnityEngine;

public class BossAttackState : State
{
    private BossStateMachine bossContext;
    private BossStateFactory bossFactory;
    public BossAttackState(BossStateMachine currentContext, BossStateFactory pFactory) : base(currentContext, pFactory)
    {
        
        bossContext = currentContext;
        bossFactory = pFactory;
    }
    public override void EnterState()
    {
        bossContext.AttackFinished = 0;
        Debug.Log("attacking");
        bossContext.Anim.SetBool("isAttacking", true);
        bossContext.AppliedMovementX = 0f;
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        bossContext.AttackFinished = 0;
        bossContext.Anim.SetBool("isAttacking", false);
    }

    public override void CheckSwitchStates()
    {
        if (bossContext.IsHurt)
        {
            SwitchState(bossFactory.Hurt());
        }
        else if (bossContext.AttackFinished == 1)
        {
            Debug.Log("switching to idle");
            SwitchState(bossFactory.Idle());
        }
        
    }
}
