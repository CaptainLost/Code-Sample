public interface IAgent
{
    // We assume that every agent can be damaged
    IDamagable Damagable { get; }
}
