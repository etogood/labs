using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public sealed class NpcBrain : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform danger;

    [Header("Distances")]
    public float chaseRadius = 12f;
    public float dangerRadius = 6f;

    private NavMeshAgent _agent;
    private NpcContext _ctx;

    private INpcStrategy _current;
    private readonly WanderStrategy _wander = new();
    private ChasePlayerStrategy _chase;
    private AvoidDangerStrategy _avoid;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _ctx = new NpcContext(transform, player, _agent);

        _chase = new ChasePlayerStrategy();
        if (danger)
            _avoid = new AvoidDangerStrategy(danger);
    }

    private void OnEnable() => SwitchTo(_wander);

    private void Update()
    {
        PickStrategy();
        _current.Tick(_ctx);
    }

    private void PickStrategy()
    {
        if (danger && Vector3.Distance(transform.position, danger.position) < dangerRadius)
        {
            if (_current != _avoid)
                SwitchTo(_avoid);
            return;
        }

        if (player && Vector3.Distance(transform.position, player.position) < chaseRadius)
        {
            if (_current != _chase)
                SwitchTo(_chase);
            return;
        }

        if (_current != _wander)
            SwitchTo(_wander);
    }

    private void SwitchTo(INpcStrategy next)
    {
        _current?.Exit(_ctx);
        _current = next;
        _current?.Enter(_ctx);
    }
}
