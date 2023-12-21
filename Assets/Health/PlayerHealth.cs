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
        int newHealth = Mathf.Max(0, playerHealthInfo.CurrentHealth - damage);
        if (newHealth != playerHealthInfo.CurrentHealth)
        {
            playerHealthInfo.CurrentHealth = newHealth;
            onPlayerHealthChanged.Raise();
            Debug.Log("player health change event raised");
        }

        if (playerHealthInfo.CurrentHealth == 0)
        {
            Die();
        }
    }

    public override void RestoreHealth(int amount)
    {
        int newHealth = Mathf.Min(playerHealthInfo.MaxHealth, playerHealthInfo.CurrentHealth + amount);
        if (newHealth != playerHealthInfo.CurrentHealth)
        {
            playerHealthInfo.CurrentHealth = newHealth;
            onPlayerHealthChanged.Raise(); // the player health changed event should only be raised if the player's health actually changes
        }
    }

    protected override void ResetCurrentHealth()
    {
        RestoreHealth(playerHealthInfo.MaxHealth); // will heal the player all the way up to 100% health
    }
}
