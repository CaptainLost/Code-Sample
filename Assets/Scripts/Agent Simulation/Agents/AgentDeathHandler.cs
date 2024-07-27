public class AgentDeathHandler
{
    private readonly Agent m_agent;

    public AgentDeathHandler(Agent agent)
    {
        m_agent = agent;
    }

    public void Die()
    {
        m_agent.Dispose();
    }
}
