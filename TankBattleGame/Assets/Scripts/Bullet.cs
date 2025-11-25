using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 25f;
    [SerializeField] private float lifeTime = 5f;

    // Optional: to avoid hitting the shooter itself
    public GameObject owner;

    private void Start()
    {
        // Destroy bullet after a few seconds so it does not live forever
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ignore collision with the owner (the tank that fired)
        if (owner != null && collision.gameObject == owner)
            return;

        // Find TankHealth on the thing we hit (or its parent)
        TankHealth health = collision.collider.GetComponentInParent<TankHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        // Destroy bullet after impact
        Destroy(gameObject);
    }
}
