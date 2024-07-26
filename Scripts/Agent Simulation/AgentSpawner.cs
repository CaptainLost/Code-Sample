using UnityEngine;
using Zenject;

public class AgentSpawner : IInitializable, ITickable
{
    private readonly AgentSimulation m_agentSimulation;
    private readonly Agent.Factory m_simpleAgentFactory;
    private readonly AgentSimulationSettings m_agentSimulationSettings;

    private float m_nextAgentSpawnDelay;
    private float m_lastAgentSpawnTime;

    public AgentSpawner(AgentSimulation agentSimulation, Agent.Factory simpleAgentFactory, AgentSimulationSettings agentSimulationSettings)
    {
        m_agentSimulation = agentSimulation;
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
        m_agentSimulation.AddAgent(agent);
    }

    public void DespawnAgent(Agent agent)
    {
        m_agentSimulation.RemoveAgent(agent);
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

        if (m_agentSimulation.AgentCount >= m_agentSimulationSettings.MaxAmountOfAgents)
            return false;

        return true;
    }

    private void SetNextAgentSpawnDelay()
    {
        m_nextAgentSpawnDelay = Random.Range(m_agentSimulationSettings.AgentSpawnDelayMin, m_agentSimulationSettings.AgentSpawnDelayMax);
    }
}
