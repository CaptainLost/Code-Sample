using System;
using UnityEngine;
using Zenject;
using AIBehaviourTree;

public class Agent : MonoBehaviour, IAgent, IPoolable<IMemoryPool>, IDisposable
{
    [SerializeField]
    private float m_moveSpeed;

    private AgentRegistry m_agentRegistry;
    private AgentSimulationBoundary m_simulationBoundary;
    private BehaviourTree m_behaviourTree;
    private IMemoryPool m_memoryPool;

    private PatrolStrategy m_patrolStrategy;

    public IDamagable Damagable { get; private set; }

    [Inject]
    public void Construct(AgentRegistry agentRegistry, AgentSimulationBoundary simulationBoundary, BehaviourTree behaviourTree, IDamagable damagable)
    {
        m_agentRegistry = agentRegistry;
        m_simulationBoundary = simulationBoundary;
        m_behaviourTree = behaviourTree;
        Damagable = damagable;
    }

    private void Awake()
    {
        m_patrolStrategy = new PatrolStrategy(transform, m_moveSpeed, m_simulationBoundary);
        BehaviourLeaf patrolLeaf = new BehaviourLeaf("Patrol", m_patrolStrategy);

        m_behaviourTree.AddChild(patrolLeaf);
    }

    private void Update()
    {
        m_behaviourTree.Process();
    }

    public void OnSpawned(IMemoryPool memoryPool)
    {
        m_memoryPool = memoryPool;

        transform.position = m_simulationBoundary.GetRandomSimulationPos();

        m_agentRegistry.AddAgent(this);
        Damagable.ResetHealth();
        m_patrolStrategy.SetRandomMoveDirection();
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
