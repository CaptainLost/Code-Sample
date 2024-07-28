using Zenject;

public class AgentDeathHandler
{
    private readonly Agent m_agent;
    private readonly SignalBus m_signalBus;

    public AgentDeathHandler(Agent agent, SignalBus signalBus)
    {
        m_agent = agent;
        m_signalBus = signalBus;
    }

    public void Die()
    {
        m_signalBus.Fire(new AgentDeathSignal(m_agent));
        m_agent.Dispose();
    }
}
