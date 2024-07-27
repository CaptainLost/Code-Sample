public interface IDamagable
{
    float CurrentHealth { get; }
    float MaxHealth { get; }

    void ReceiveDamage(float amountOfDamage);
    bool IsDead();
}
