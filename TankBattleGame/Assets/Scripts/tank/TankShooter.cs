using UnityEngine;

public class TankShooter : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private Rigidbody rbHull; // optional for recoil

    public void Shoot(GameObject bulletPrefab, float power)
    {
        if (!muzzle || !bulletPrefab) return;
        var bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);

        // Set owner for friendly-fire check
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.owner = gameObject;   // this tank
        }


        if (bullet.TryGetComponent<Rigidbody>(out var rb))
            rb.AddForce(muzzle.forward * power, ForceMode.Impulse);

        // Optional recoil
        if (rbHull) rbHull.AddForce(-muzzle.forward * (power * 0.1f), ForceMode.Impulse);
    }
}

