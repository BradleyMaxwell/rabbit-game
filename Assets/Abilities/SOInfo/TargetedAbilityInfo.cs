using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetedAbilityInfo : AbilityInfo // information that all targeted abilities have in common
{
    [SerializeField] protected float range; // the maximum distance the user can be from their target to use the ability
    
    public float Range
    {
        get { return range; }
    }
}
