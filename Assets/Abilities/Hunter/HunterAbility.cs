using UnityEngine;

[CreateAssetMenu(fileName = "HunterAbility", menuName = "Ability/Enemy/Hunter")]
public class HunterAbility : TargetedAbility
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
