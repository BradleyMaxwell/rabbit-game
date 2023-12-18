using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetedAbility : Ability // the parent targeted ability which any targeted ability derives from 
{
    [SerializeField] protected float range; // the maximum distance the user can be from their target to use the ability
    
    public float Range
    {
        get { return range; }
    }
}
