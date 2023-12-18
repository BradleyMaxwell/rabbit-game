using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AbilityManager : MonoBehaviour // behaviour script for enemy abilities to use it and track cooldown
{
    [SerializeField] protected Ability ability; // stores information about this enemy's ability
    [SerializeField] private float cooldownRemaining; // how much time remains until the ability can be used again

    // Update is called once per frame
    protected virtual void Update()
    {
        if (cooldownRemaining > 0) // if there is any remaining cooldown on the ability then reduce the remaining cooldown each frame
        {
            cooldownRemaining -= Time.deltaTime;
        }
    }

    public bool IsOffCooldown()
    {
        if (cooldownRemaining <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void StartCooldown()
    {
        cooldownRemaining = ability.Cooldown; // set the cooldown remaining to the cooldown of the ability
    }
}
