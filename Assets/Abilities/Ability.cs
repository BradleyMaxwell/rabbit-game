using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject // the base script that all types of abilities derive from which defines common information
{
    [SerializeField] protected new string name;
    [SerializeField] protected float cooldown; // how long until the ability is ready to be used again after use
    [SerializeField] protected float castTime; // how long it takes the ability to be executed in seconds
    [SerializeField] protected string description; // an explanation of how the ability works

    public string Name
    {
        get { return name; }
    }
    
    public float Cooldown
    {
        get { return cooldown; }
    }

    public float CastTime
    {
        get { return castTime; }
    }

    public string Description
    {
        get { return description; }
    }
}
