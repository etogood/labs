using UnityEngine;
using UnityEngine.AI;

public sealed class WanderStrategy : INpcStrategy
{
    private readonly float _radius;
    private readonly float _idleTime;
    private float _timer;
    private Vector3 _target;

    public WanderStrategy(float radius = 10f, float idleTime = 2f)
    {
        _radius = radius;
        _idleTime = idleTime;
    }

    public void Enter(NpcContext ctx)
    {
        PickNewPoint(ctx);
    }

    public void Tick(NpcContext ctx)
    {
        _timer += Time.deltaTime;
        if (_timer >= _idleTime && !ctx.Agent.pathPending && ctx.Agent.remainingDistance < 0.3f)
            PickNewPoint(ctx);
    }

    private void PickNewPoint(NpcContext ctx)
    {
        _timer = 0f;
        var random = Random.insideUnitSphere * _radius + ctx.Self.position;
        if (!NavMesh.SamplePosition(random, out var hit, _radius, NavMesh.AllAreas))
            return;
        _target = hit.position;
        ctx.Agent.SetDestination(_target);
    }
}
