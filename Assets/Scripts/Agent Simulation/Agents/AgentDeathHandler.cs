using Zenject;

public class AgentDeathHandler
{
    private readonly Agent m_agent;
    private readonly SignalBus m_signalBus;
    private readonly Explosion.Factory m_explosionFactory;

    public AgentDeathHandler(Agent agent, SignalBus signalBus, Explosion.Factory explosionFactory)
    {
        m_agent = agent;
        m_signalBus = signalBus;
        m_explosionFactory = explosionFactory;
    }

    public void Die()
    {
        m_signalBus.Fire(new AgentDeathSignal(m_agent));
        m_agent.Dispose();

        Explosion explosionEffect = m_explosionFactory.Create();
        explosionEffect.transform.position = m_agent.transform.position;
    }
}
