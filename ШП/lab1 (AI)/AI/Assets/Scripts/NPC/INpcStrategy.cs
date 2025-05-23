public interface INpcStrategy
{
    void Tick(NpcContext ctx);
    
    void Enter(NpcContext ctx) { }
    
    void Exit(NpcContext ctx) { }
}
