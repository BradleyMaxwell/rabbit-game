using UnityEngine;

public class PlayerHealth : Health // contains the logic that occurs specifically with the player's health
{
    private PlayerHealthInfo playerHealthInfo; // needed because current health is stored in scriptable object for player
    [SerializeField] private GameEvent onPlayerHealthChanged; // raise the player health changed event when the health changing functions are called

    private void Awake()
    {
        // only allow the HealthInfo scriptable object to be the player specific one
        if (HealthInfo is PlayerHealthInfo)
        {
            playerHealthInfo = (PlayerHealthInfo)HealthInfo;
        }
        else
        {
            Debug.LogError("the HealthInfo must be of type PlayerHealthInfo for the player.");
        }
    }

    // needs to event that player health change raises here

    protected override void Die()
    {
        Debug.Log("player has died");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void TakeDamage(int damage)
    {
        playerHealthInfo.CurrentHealth = Mathf.Max(0, playerHealthInfo.CurrentHealth - damage);
        onPlayerHealthChanged.Raise();
        if (playerHealthInfo.CurrentHealth == 0)
        {
            Die();
        }
    }

    public override void RestoreHealth(int amount)
    {
        playerHealthInfo.CurrentHealth = Mathf.Min(playerHealthInfo.MaxHealth, playerHealthInfo.CurrentHealth + amount);
        onPlayerHealthChanged.Raise();
    }

    protected override void ResetCurrentHealth()
    {
        playerHealthInfo.CurrentHealth = playerHealthInfo.MaxHealth;
    }
}
