using Zenject;

public class AgentDamagable : IDamagable
{
    private readonly IAgent m_agent;
    private readonly IDeathHandler m_deathHandler;
    private readonly SignalBus m_signalBus;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }

    public AgentDamagable(IAgent agent, WanderingAgentSettings agentSettings, IDeathHandler deathHandler, SignalBus signalBus)
    {
        m_agent = agent;
        m_deathHandler = deathHandler;
        m_signalBus = signalBus;

        MaxHealth = agentSettings.StartHealth;

        ResetHealth();
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void ReceiveDamage(float amountOfDamage)
    {
        CurrentHealth -= amountOfDamage;

        m_signalBus.Fire(new AgentDamagedSignal(m_agent));

        if (IsDead())
        {
            m_deathHandler.Die();
        }
    }

    public bool IsDead()
    {
        return CurrentHealth <= 0f;
    }
}
