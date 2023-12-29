using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealthInfo", menuName = "Info/Health/Player")]
public class PlayerHealthInfo : HealthInfo // need this so that the player's health is in a scriptable object to reduce dependancies for scripts that use the health e.g. UI elements
{
    [SerializeField] private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
}
