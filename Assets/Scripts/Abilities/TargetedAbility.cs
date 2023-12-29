using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetedAbility : Ability // handles logic and information about an enemy's targeted ability needed for the scene
{
    private TargetedAbilityInfo targetedAbilityInfo; // for using data specific to targeted abilities

    protected virtual void Awake() // made child targeted ability scripts inherit this so they can use the same logic to ensure that the info is for a targeted ability
    {
        if (abilityInfo is not TargetedAbilityInfo)
        {
            throw new ArgumentException("ability scriptable object must be a targeted ability");
        }
        else
        {
            targetedAbilityInfo = (TargetedAbilityInfo)abilityInfo;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update(); // use the cooldown logic from the base enemy ability behaviour script
    }

    public abstract IEnumerator Use(GameObject target); // derived targeted abilities will have to implement their own use effect 

    protected IEnumerator AimDuringCast(GameObject target) // user will rotate to face their target while they are casting the ability
    {
        float castTimeRemaining = abilityInfo.CastTime; // this will go down every frame until the cast is finished
        while (castTimeRemaining > 0)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); // make sure the rotation is only around the y axis
            transform.LookAt(targetPosition);
            castTimeRemaining -= Time.deltaTime;
            yield return null;
        }
    }

    public bool IsInRange(Transform target) // returns if the distance between the user and the target is within the range
    {
        Vector3 userPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
        if (Vector3.Distance(userPosition, targetPosition) <= targetedAbilityInfo.Range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
