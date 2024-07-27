public class AgentDamagable : IDamagable
{
    private readonly AgentDeathHandler m_deathHandler;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }

    public AgentDamagable(AgentSettings agentSettings, AgentDeathHandler deathHandler)
    {
        m_deathHandler = deathHandler;

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
