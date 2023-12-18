using UnityEngine;

[CreateAssetMenu(fileName = "HunterAbilityInfo", menuName = "Ability Info/Enemy/Hunter")]
public class HunterAbilityInfo : TargetedAbilityInfo
{
    [SerializeField] private float bulletTravelSpeed; // how fast the hunter's bullet travels when it is fired
    [SerializeField] private int damage;

    public float BulletTravelSpeed
    {
        get { return bulletTravelSpeed; }
    }

    public int Damage
    {
        get { return damage; }
    }
}
