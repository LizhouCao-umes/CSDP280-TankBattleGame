using UnityEngine;

public class RepairItem : MonoBehaviour
{
    [SerializeField] private float healAmount = 30f;
    [SerializeField] private GameObject pickupEffect;   // optional VFX

    private void OnTriggerEnter(Collider other)
    {
        // Look for TankHealth on the object that touched this
        TankHealth health = other.GetComponentInParent<TankHealth>();
        if (health == null) return;

        // Heal the tank
        health.Heal(healAmount);

        // Optional: play effect
        if (pickupEffect != null)
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

        // Destroy the item after pickup
        Destroy(gameObject);
    }

    private void Update()
    {
        // Optional: spin to look nice
        transform.Rotate(0f, 60f * Time.deltaTime, 0f, Space.World);
    }
}
