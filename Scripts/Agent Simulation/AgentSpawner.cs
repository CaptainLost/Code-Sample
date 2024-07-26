using Zenject;

public class AgentSpawner : ITickable
{
    private readonly AgentSimulation m_agentSimulation;
    private readonly Agent.Factory m_simpleAgentFactory;

    public AgentSpawner(AgentSimulation agentSimulation, Agent.Factory simpleAgentFactory)
    {
        m_agentSimulation = agentSimulation;
        m_simpleAgentFactory = simpleAgentFactory;
    }

    public void Initialize()
    {
        m_simpleAgentFactory.Create();
    }

    public void Tick()
    {
        
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
}
