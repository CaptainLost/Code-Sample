using UnityEngine;
using Zenject;

public class AgentSpawner : IInitializable, ITickable
{
    private readonly AgentRegistry m_agentRegistry;
    private readonly Agent.Factory m_simpleAgentFactory;
    private readonly AgentSimulationSettings m_agentSimulationSettings;

    private float m_nextAgentSpawnDelay;
    private float m_lastAgentSpawnTime;

    public AgentSpawner(AgentRegistry agentRegistry, Agent.Factory simpleAgentFactory, AgentSimulationSettings agentSimulationSettings)
    {
        m_agentRegistry = agentRegistry;
        m_simpleAgentFactory = simpleAgentFactory;
        m_agentSimulationSettings = agentSimulationSettings;
    }

    public void Initialize()
    {
        SetNextAgentSpawnDelay();
        CreateInitialAgents();
    }

    public void Tick()
    {
        if (!CanSpawnAgent())
            return;

        m_lastAgentSpawnTime = Time.time;

        SetNextAgentSpawnDelay();
        SpawnAgent();
    }

    public void SpawnAgent()
    {
        Agent agent = m_simpleAgentFactory.Create();
    }

    public void DespawnAgent(Agent agent)
    {
        agent.Dispose();
    }

    private void CreateInitialAgents()
    {
        int randomAmountOfInitialAgents = Random.Range(m_agentSimulationSettings.StartAmountOfAgentsMin, m_agentSimulationSettings.StartAmountOfAgentsMax + 1);

        for (int i = 0; i < randomAmountOfInitialAgents; i++)
        {
            SpawnAgent();
        }
    }

    private bool CanSpawnAgent()
    {
        if (m_lastAgentSpawnTime + m_nextAgentSpawnDelay > Time.time)
            return false;

        if (m_agentRegistry.AgentCount >= m_agentSimulationSettings.MaxAmountOfAgents)
            return false;

        return true;
    }

    private void SetNextAgentSpawnDelay()
    {
        m_nextAgentSpawnDelay = Random.Range(m_agentSimulationSettings.AgentSpawnDelayMin, m_agentSimulationSettings.AgentSpawnDelayMax);
    }
}
