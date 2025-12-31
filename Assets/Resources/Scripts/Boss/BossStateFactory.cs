public class BossStateFactory : StateFactory
{
    BossStateMachine bossContext;
    public BossStateFactory(BossStateMachine currentContext) : base(currentContext)
    {
        bossContext = currentContext;
    }

    public override State Idle()
    {
        return new BossIdleState(bossContext, this);
    }

    public override State Walk()
    {
        return new BossWalkState(bossContext, this);
    }

    public override State Attack()
    {
        return new BossAttackState(bossContext, this);
    }

    public override State Hurt()
    {
        return new BossHurtState(bossContext, this);
    }

    public State PhaseOneIntro()
    {
        return new BossPhaseOneIntroState(bossContext, this);
    }
}