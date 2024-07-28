using System;
using UnityEngine;
using Zenject;
using AIBehaviourTree;

public class WanderingAgent : MonoBehaviour, IAgent, IPoolable<IMemoryPool>, IDisposable
{
    [SerializeField]
    private float m_moveSpeed;

    private AgentRegistry m_agentRegistry;
    private AgentSimulationBoundary m_simulationBoundary;
    private BehaviourTree m_behaviourTree;
    private IMemoryPool m_memoryPool;

    private WanderingAgentData m_agentData;
    private WanderStrategy m_wanderStrategy;

    public IDamagable Damagable { get; private set; }
    public IAgentData AgentData => m_agentData;

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
        m_wanderStrategy = new WanderStrategy(transform, m_moveSpeed, m_simulationBoundary);
        BehaviourLeaf patrolLeaf = new BehaviourLeaf("Patrol", m_wanderStrategy);
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
        m_agentData = new WanderingAgentData();

        m_agentRegistry.AddAgent(this);
        Damagable.ResetHealth();
        m_wanderStrategy.SetRandomMoveDirection();
    }

    public void OnDespawned()
    {
        m_agentRegistry.RemoveAgent(this);
    }

    public void Dispose()
    {
        m_memoryPool.Despawn(this);
    }

    public class Factory : PlaceholderFactory<WanderingAgent>
    {

    }
}
