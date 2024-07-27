using System;
using UnityEngine;
using Zenject;

public class Agent : MonoBehaviour, IAgent, IPoolable<IMemoryPool>, IDisposable
{
    private AgentRegistry m_agentRegistry;
    private AgentSimulationBoundary m_simulationBoundary;
    private IMemoryPool m_memoryPool;

    public IDamagable Damagable { get; private set; }

    [Inject]
    public void Construct(AgentRegistry agentRegistry, AgentSimulationBoundary simulationBoundary, IDamagable damagable)
    {
        m_agentRegistry = agentRegistry;
        m_simulationBoundary = simulationBoundary;
        Damagable = damagable;
    }

    public void OnSpawned(IMemoryPool memoryPool)
    {
        m_memoryPool = memoryPool;

        transform.position = m_simulationBoundary.GetRandomSimulationPos();

        m_agentRegistry.AddAgent(this);
        Damagable.ResetHealth();
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
