using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Ability : MonoBehaviour // behaviour script for enemies to use their ability and track cooldown
{
    [SerializeField] protected AbilityInfo abilityInfo; // stores information about this enemy's ability
    [SerializeField] private float cooldownRemaining; // how much time remains until the ability can be used again
    protected bool inUse; // indicates if the ability is in use at any moment to lock it from being recast 

    // Update is called once per frame
    protected virtual void Update()
    {
        if (cooldownRemaining > 0) // cooldown remaining should reduce over time if there is any time left
        {
            cooldownRemaining -= Time.deltaTime;
        }
    }

    public void StartCooldown() // flag the ability is no longer in use and start the cooldown timer
    {
        inUse = false; // ability is over so it is safe to indicate as not being in use anymore
        cooldownRemaining = abilityInfo.Cooldown; // set the cooldown remaining to the cooldown of the ability
    }

    public bool CanUse()
    {
        if (cooldownRemaining <= 0 && inUse == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
