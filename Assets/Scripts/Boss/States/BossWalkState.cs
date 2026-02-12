using UnityEngine;
public class BossWalkState : State
{
    private BossStateMachine dogContext;
    public BossWalkState(BossStateMachine currentContext) : base(currentContext)
    {
        dogContext = currentContext;
    }
    public override void EnterState()
    {
        dogContext.Anim.Play("Walk");
        
    }
    public override void UpdateState()
    {
        Vector3 target = new Vector3(dogContext.Player.gameObject.transform.position.x, dogContext.RB.gameObject.transform.position.y, 0f);
        Vector3 currentPos = new Vector3(dogContext.RB.gameObject.transform.position.x, dogContext.RB.gameObject.transform.position.y, 0f);
        Vector3 direction = (target - currentPos).normalized;
        dogContext.AppliedMovementX = direction.x * dogContext.MoveSpeed;
        
        CheckSwitchStates();
    }
    public override void ExitState()
    {
    }

    public override void CheckSwitchStates()
    {
        if (dogContext.IsStunned)
        {   
            SwitchState(new BossStunState(dogContext));
        } else if (dogContext.InRange())
        {
            SwitchState(new BossAttackState(dogContext));
        }
    }
}
