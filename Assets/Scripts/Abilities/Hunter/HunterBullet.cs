using UnityEngine;

[RequireComponent(typeof(BoxCollider))] // bullet needs this so it can collide with other game objects
public class HunterBullet : MonoBehaviour // attached to the hunter bullet prefab to handle its logic when fired
{
    private int damage; // set by the hunter ability before it is fired

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Health collisionHealth = collision.gameObject.GetComponent<Health>(); // check if the object that the bullet collides with has a health component
        if (collisionHealth != null)
        {
            collisionHealth.TakeDamage(damage);
        }
    }

    public int Damage
    {
        set { damage = value; }
    }
}
