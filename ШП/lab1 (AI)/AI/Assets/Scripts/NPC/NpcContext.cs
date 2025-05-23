using UnityEngine;
using UnityEngine.AI;

public sealed class NpcContext
{
    public readonly Transform Self;
    public readonly Transform Player;
    public readonly NavMeshAgent Agent;

    public NpcContext(Transform self, Transform player, NavMeshAgent agent)
    {
        Self = self;
        Player = player;
        Agent = agent;
    }
}
