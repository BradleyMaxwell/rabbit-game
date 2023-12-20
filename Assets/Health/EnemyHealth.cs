using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    [SerializeField] private int currentHealth; // enemies have their health stored in the MonoBehaviour because it is specific to the prefab instance
    // health change event for the enemy prefab here
    
    protected override void Die()
    {
        Debug.Log(gameObject.name + "has died");
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
        // raise the health change event here
    }

    public override void RestoreHealth(int amount)
    {
        CurrentHealth = Mathf.Min(HealthInfo.MaxHealth, CurrentHealth + amount);
        // raise the health change event for the enemy here
    }

    protected override void ResetCurrentHealth()
    {
        CurrentHealth = HealthInfo.MaxHealth;
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
}
