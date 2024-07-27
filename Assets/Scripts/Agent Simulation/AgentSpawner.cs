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
        // If we can't spawn agent postpone cooldown, so it won't spawn immediately
        if (!CanSpawnAgent())
        {
            ResetCooldown();
            return;
        }

        if (!IsCooldownReady())
            return;

        ResetCooldown();
        SetNextAgentSpawnDelay();
        SpawnAgent();
    }

    public void SpawnAgent()
    {
        m_simpleAgentFactory.Create();
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
        if (m_agentRegistry.AgentCount >= m_agentSimulationSettings.MaxAmountOfAgents)
            return false;

        return true;
    }

    private bool IsCooldownReady()
    {
        if (m_lastAgentSpawnTime + m_nextAgentSpawnDelay > Time.time)
            return false;

        return true;
    }

    private void ResetCooldown()
    {
        m_lastAgentSpawnTime = Time.time;
    }

    private void SetNextAgentSpawnDelay()
    {
        m_nextAgentSpawnDelay = Random.Range(m_agentSimulationSettings.AgentSpawnDelayMin, m_agentSimulationSettings.AgentSpawnDelayMax);
    }
}
