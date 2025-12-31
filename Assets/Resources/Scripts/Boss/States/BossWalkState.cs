using UnityEngine;
public class BossWalkState : State
{
    private BossStateMachine bossContext;
    private BossStateFactory bossFactory;
    public BossWalkState(BossStateMachine currentContext, BossStateFactory pFactory) : base(currentContext, pFactory)
    {
        bossContext = currentContext;
        bossFactory = pFactory;
    }
    public override void EnterState()
    {
        Debug.Log("walking");
        bossContext.Anim.SetBool("isWalking", true);
        Debug.Log(bossContext.Anim.GetBool("isWalking"));
        
    }
    public override void UpdateState()
    {
        Vector3 target = new Vector3(bossContext.Player.gameObject.transform.position.x, bossContext.RB.gameObject.transform.position.y, 0f);
        Vector3 currentPos = new Vector3(bossContext.RB.gameObject.transform.position.x, bossContext.RB.gameObject.transform.position.y, 0f);
        Vector3 direction = (target - currentPos).normalized;
        bossContext.AppliedMovementX = direction.x * bossContext.MoveSpeed;
        
        
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        bossContext.Anim.SetBool("isWalking", false);
    }

    public override void CheckSwitchStates()
    {
        if (bossContext.IsHurt)
        {
            SwitchState(bossFactory.Hurt());
        }
        else if (bossContext.InRange())
        {
            SwitchState(bossFactory.Attack());
        }
    }
}
