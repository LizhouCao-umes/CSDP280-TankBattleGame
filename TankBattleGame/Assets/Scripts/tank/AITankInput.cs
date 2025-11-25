using UnityEngine;

public class AITankInput : MonoBehaviour, ITankInput
{
    // Example: simple “drive forward and wiggle”
    public float MoveAxis { get; private set; }
    public float TurnAxis { get; private set; }
    public float TurretYawAxis { get; private set; }
    public float CannonPitchAxis { get; private set; }
    public bool FirePressed { get; private set; }

    [SerializeField] private float wiggleSpeed = 1f;

    private void Update()
    {
        MoveAxis = 1f;
        TurnAxis = Mathf.Sin(Time.time * wiggleSpeed) > 0 ? 0.2f : -0.2f;

        // Point turret slowly right; occasionally fire
        TurretYawAxis = 0.2f;
        CannonPitchAxis = 0f;
        // FirePressed = Random.value < 0.01f;
    }
}
