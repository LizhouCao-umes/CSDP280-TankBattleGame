using UnityEngine;

[RequireComponent(typeof(TankMotor))]
public class TankController : MonoBehaviour
{
    [SerializeField] private TankConfig config;
    [SerializeField] private TurretMotor turret;
    [SerializeField] private TankShooter shooter;

    private TankMotor motor;
    private ITankInput input;

    private void Awake()
    {
        motor = GetComponent<TankMotor>();
        input = GetComponent<ITankInput>(); // any provider on this GameObject
        if (input == null)
            Debug.LogWarning("No ITankInput found. Add a KeyboardTankInput / AITankInput / NetworkTankInput.");
    }

    private void FixedUpdate()
    {
        if (input == null || config == null) return;
        motor.MoveAndTurn(input.MoveAxis, input.TurnAxis, config.moveSpeed, config.turnSpeed);
    }

    private void Update()
    {
        if (input == null || config == null) return;

        if (turret)
            turret.Aim(input.TurretYawAxis, input.CannonPitchAxis,
                       config.turretYawSpeed, config.cannonPitchSpeed,
                       config.minPitch, config.maxPitch);

        if (input.FirePressed && shooter)
            shooter.Shoot(config.bulletPrefab, config.shootPower);
    }
}
