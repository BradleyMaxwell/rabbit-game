using UnityEngine;

public abstract class Health : MonoBehaviour // the base class for character health logic
{
    [SerializeField] private HealthInfo healthInfo; // where the persistent data about the character's health is stored

    protected virtual void OnEnable()
    {
        ResetCurrentHealth(); // when a character with health prefab is enabled it's current health should be reset to 100%
    }

    public abstract void TakeDamage(int damage);

    public abstract void RestoreHealth(int amount);

    protected abstract void Die(); // players and enemies will trigger different logic when they die

    protected abstract void ResetCurrentHealth(); // used to reset the current health when the object with health is enabled

    protected HealthInfo HealthInfo
    {
        get { return healthInfo; }
    }
}
