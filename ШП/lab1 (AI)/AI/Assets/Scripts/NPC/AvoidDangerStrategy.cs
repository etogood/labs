using UnityEngine;

public sealed class AvoidDangerStrategy : INpcStrategy
{
    private readonly Transform _danger;
    private readonly float _fleeDistance;

    public AvoidDangerStrategy(Transform danger, float fleeDistance = 8f)
    {
        _danger = danger;
        _fleeDistance = fleeDistance;
    }

    public void Tick(NpcContext ctx)
    {
        var dir = (ctx.Self.position - _danger.position).normalized;
        var point = ctx.Self.position + dir * _fleeDistance;

        if (
            UnityEngine.AI.NavMesh.SamplePosition(
                point,
                out var hit,
                _fleeDistance,
                UnityEngine.AI.NavMesh.AllAreas
            )
        )
            ctx.Agent.SetDestination(hit.position);
    }
}
