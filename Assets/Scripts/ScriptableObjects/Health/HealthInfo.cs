using UnityEngine;

[CreateAssetMenu(fileName = "New HealthInfo", menuName = "Info/Health")]
public class HealthInfo : ScriptableObject
{
    [SerializeField] private int maxHealth;

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
}
