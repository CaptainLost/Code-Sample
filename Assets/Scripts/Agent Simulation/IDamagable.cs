public interface IDamagable
{
    float CurrentHealth { get; }
    float MaxHealth { get; }

    void ResetHealth();
    void ReceiveDamage(float amountOfDamage);
    bool IsDead();
}
