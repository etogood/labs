public sealed class ChasePlayerStrategy : INpcStrategy
{
    private readonly float _stopDistance;

    public ChasePlayerStrategy(float stopDistance = 1.5f)
    {
        _stopDistance = stopDistance;
    }

    public void Tick(NpcContext ctx)
    {
        if (!ctx.Player) return;

        ctx.Agent.SetDestination(ctx.Player.position);

        if (ctx.Agent.remainingDistance <= _stopDistance && !ctx.Agent.pathPending)
            ctx.Agent.isStopped = true;
        else
            ctx.Agent.isStopped = false;
    }
}