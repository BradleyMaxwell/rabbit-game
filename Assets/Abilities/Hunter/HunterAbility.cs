using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HunterAbility : TargetedAbility
{
    private HunterAbilityInfo hunterAbilityInfo; // get hunter specific information from the ability scriptable object
    [SerializeField] private Transform gunTip; // child object of the weapon which is the origin of the bullet projectile
    [SerializeField] private GameObject bulletPrefab;
    private PlayerActions playerActions;

    protected override void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.Playing.Test.performed += TestUse;

        base.Awake(); // firstly makes sure the info object is for a targeted ability, then makes sure it is for a hunter ability
        if (abilityInfo is not HunterAbilityInfo)
        {
            throw new ArgumentException("hunter's ability info must be a HunterAbilityInfo scriptable object");
        }
        else
        {
            hunterAbilityInfo = (HunterAbilityInfo)abilityInfo;
            Debug.Log(hunterAbilityInfo.BulletTravelSpeed);
        }
    }
    
    public void OnEnable()
    {
        playerActions.Enable();
    }

    public void OnDisable()
    {
        playerActions.Disable();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void TestUse(InputAction.CallbackContext context)
    {
        Debug.Log("testing hunter ability");

        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation); // creates a bullet instance at the tip of the gun facing the same direction as the gun
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(bulletRB.transform.forward * 30f, ForceMode.Impulse); // velocity change keeps the bullet travel speed constant
    }

    public override IEnumerator Use(GameObject target) // shoot a bullet from the tip of the hunter's gun to a target
    {
        // hunter needs to aim at their target throughout the cast before firing
        yield return StartCoroutine(AimDuringCast(target)); // hunter will wait until the cast has finished

        // projectile needs to be spawned at the tip of the gun and travel towards the target
        StartCooldown();
    }
}
