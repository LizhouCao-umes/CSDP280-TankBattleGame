using UnityEngine;

[CreateAssetMenu(menuName = "Tank/TankConfig")]
public class TankConfig : ScriptableObject
{
    [Header("Hull")]
    public float moveSpeed = 2f;
    public float turnSpeed = 60f;

    [Header("Turret")]
    public float turretYawSpeed = 90f;
    public float cannonPitchSpeed = 90f;
    public float minPitch = -5f;  // degrees
    public float maxPitch = 25f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float shootPower = 1000f;
}
