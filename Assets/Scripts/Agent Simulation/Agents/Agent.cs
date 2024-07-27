using System;
using UnityEngine;
using Zenject;

public class Agent : MonoBehaviour, IAgent, IPoolable<IMemoryPool>, IDisposable
{
    private AgentRegistry m_agentRegistry;
    private IMemoryPool m_memoryPool;

    public IDamagable Damagable { get; private set; }

    [Inject]
    public void Construct(AgentRegistry agentRegistry, IDamagable damagable)
    {
        m_agentRegistry = agentRegistry;
        Damagable = damagable;
    }

    public void OnSpawned(IMemoryPool memoryPool)
    {
        m_memoryPool = memoryPool;

        m_agentRegistry.AddAgent(this);
    }

    public void OnDespawned()
    {
        m_agentRegistry.RemoveAgent(this);
    }

    public void Dispose()
    {
        m_memoryPool.Despawn(this);
    }

    public class Factory : PlaceholderFactory<Agent>
    {

    }
}
