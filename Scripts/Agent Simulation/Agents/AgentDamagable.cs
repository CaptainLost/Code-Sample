public class AgentDamagable : IDamagable
{
    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }

    public AgentDamagable(AgentSettings agentSettings)
    {
        CurrentHealth = agentSettings.StartHealth;
    }

    public void ReceiveDamage(float amountOfDamage)
    {
        CurrentHealth -= amountOfDamage;
    }

    public bool IsDead()
    {
        return CurrentHealth <= 0f;
    }
}
