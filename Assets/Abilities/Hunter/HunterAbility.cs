using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HunterAbility : TargetedAbility
{
    private HunterAbilityInfo hunterAbilityInfo; // get hunter specific information from the ability scriptable object
    [SerializeField] private Transform gunTip; // child object of the weapon which is the origin of the bullet projectile
    [SerializeField] private GameObject bulletPrefab;

    protected override void Awake()
    {
        base.Awake(); // firstly makes sure the info object is for a targeted ability, then makes sure it is for a hunter ability
        if (abilityInfo is not HunterAbilityInfo)
        {
            throw new ArgumentException("hunter's ability info must be a HunterAbilityInfo scriptable object");
        }
        else
        {
            hunterAbilityInfo = (HunterAbilityInfo)abilityInfo;
        }
    }

    protected override void Update()
    {
        base.Update();
    }

    public override IEnumerator Use(GameObject target) // shoot a bullet from the tip of the hunter's gun to a target
    {
        inUse = true; // signal that the hunter has started using their ability
        
        // hunter needs to aim at their target throughout the cast before firing
        yield return StartCoroutine(AimDuringCast(target)); // hunter will wait until the cast has finished

        // fire the bullet prefab in the direction the hunter's gun is facing
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation); // creates a bullet instance at the tip of the gun facing the same direction as the gun
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(bulletRB.transform.forward * hunterAbilityInfo.BulletTravelSpeed, ForceMode.VelocityChange); // velocity change keeps the bullet travel speed constant

        // set the ability on cooldown once the effect is finished
        StartCooldown();
    }
}
