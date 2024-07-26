using System.Collections.Generic;

public class AgentSimulation
{
    public int AgentCount { get { return m_agentList.Count; } }

    private List<IAgent> m_agentList;

    public AgentSimulation()
    {
        m_agentList = new List<IAgent>();
    }

    public void AddAgent(IAgent agent)
    {
        m_agentList.Add(agent);
    }

    public void RemoveAgent(IAgent agent)
    {
        m_agentList.Remove(agent);
    }
}
