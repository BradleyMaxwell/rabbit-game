using System.Collections;
using UnityEngine;

public class HunterAbilityManager : TargetedAbilityManager
{
    private HunterAbility hunterAbility; // get hunter specific information from the ability scriptable object
    [SerializeField] private Transform gunTip; // child object of the weapon which is the origin of the bullet projectile
    [SerializeField] private GameObject bulletPrefab;

    protected override void Update()
    {
        base.Update();
    }

    public override IEnumerator Use(GameObject target) // shoot a bullet from the tip of the hunter's gun to a target
    {
        // hunter needs to aim at their target throughout the cast before firing
        yield return StartCoroutine(AimDuringCast(target)); // hunter will wait until the cast has finished

        // projectile needs to be spawned at the tip of the gun and travel towards the target
        Debug.Log("Hunter ability used!");
        GameObject.Instantiate(bulletPrefab);
        StartCooldown();
    }
}
