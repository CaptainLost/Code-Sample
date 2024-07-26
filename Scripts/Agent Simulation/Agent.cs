using System;
using UnityEngine;
using Zenject;

public class Agent : MonoBehaviour, IAgent, IPoolable<IMemoryPool>, IDisposable
{
    private AgentRegistry m_agentRegistry;
    private IMemoryPool m_memoryPool;

    [Inject]
    public void Construct(AgentRegistry agentRegistry)
    {
        m_agentRegistry = agentRegistry;
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
